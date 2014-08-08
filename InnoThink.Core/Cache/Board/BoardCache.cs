using InnoThink.Core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace InnoThink.Core.Cache.Board
{
    public class BoardCache
    {
        private static readonly DbBoardTable dbBoard = new DbBoardTable() { };

        private static Dictionary<int, List<BoardModel>> PrivateBoard = new Dictionary<int, List<BoardModel>>() { };
        private static Dictionary<int, List<BoardModel>> PublicBoard = new Dictionary<int, List<BoardModel>> { };
        private static readonly int MessageMax = 10;
        private static Timer BoardTimer;
        private static readonly object LockProcess = new object();

        public static void InitialCache()
        {
            //Get date from DB to Cache [Private].
            var data = dbBoard.GetAllDataByPublishType(0);
            data.ForEach(x =>
            {
                AddBoardFromDB(x, PrivateBoard);
            });
            //Get date from DB to Cache [Publc].
            data = dbBoard.GetAllDataByPublishType(1);
            data.ForEach(x =>
            {
                AddBoardFromDB(x, PublicBoard);
            });
        }

        static BoardCache()
        {
            int Mins = 1000 * 60;
            BoardTimer = new Timer();
            BoardTimer.Elapsed += new ElapsedEventHandler(BoardTimer_Elapsed);
            BoardTimer.Interval = 5 * Mins;
            BoardTimer.Enabled = true;
        }

        private static void AddBoardFromDB(DbBoardContent BoardData, Dictionary<int, List<BoardModel>> target)
        {
            if (!target.Any(x => x.Key == BoardData.TopicSN))
            {
                target[BoardData.TopicSN] = new List<BoardModel>() { };
            }
            target[BoardData.TopicSN].Add(new BoardModel()
            {
                Content = BoardData.Content,
                DateCreated = BoardData.DateCreated,
                ImagePath = BoardData.UserIcon,
                LoginId = BoardData.UserLoginId,
                Saved = true,
                UserName = BoardData.UserName,
                UserSN = BoardData.UserSN
            });
        }

        private static void BoardTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (LockProcess)
            {
                BoardTimer.Enabled = false;
                _doBoardUpdate(0);
                _doBoardUpdate(1);
                BoardTimer.Enabled = true;
            }
        }

        /// <summary>
        /// Process Board update
        /// </summary>
        /// <param name="BoardType">1 -> Public, 0 -> Private</param>
        private static void _doBoardUpdate(int BoardType)
        {
            bool NeedUpdate = false;
            Dictionary<int, List<BoardModel>> TargetBoard;
            switch (BoardType)
            {
                case 0:
                    TargetBoard = PrivateBoard;
                    break;

                case 1:
                    TargetBoard = PublicBoard;
                    break;

                default:
                    throw new Exception(string.Format("Board Type [{0}] is not defined.", BoardType));
            }

            //Get all Topic SN
            List<int> TopicSNs = TargetBoard.GroupBy(x => x.Key).Select(y => y.Key).ToList();
            TopicSNs.ForEach(x =>
            {
                NeedUpdate = TargetBoard[x].Any(y => y.Saved == false);
                if (NeedUpdate)
                {
                    //Make data model
                    var model = TargetBoard[x].Select(y => new DbBoardTableModel()
                    {
                        Content = y.Content,
                        DateCreated = y.DateCreated,
                        PublishType = BoardType,
                        TopicSN = x,
                        UserSN = y.UserSN
                    }).ToList();
                    dbBoard.UpdateBoard(model, x, BoardType);
                    TargetBoard[x].ForEach(y => y.Saved = true);
                }
            });
        }

        /// <summary>
        /// Update user picture, if user has change user's image.
        /// </summary>
        /// <param name="UserSN">User's SN</param>
        /// <param name="NewPicture">New full picture path for ui display purpose.</param>
        public static void ChangePersionPicture(int UserSN, string NewPicture)
        {
            PrivateBoard.ToList().ForEach(x => x.Value.Where(y => y.UserSN == UserSN).ToList().ForEach(z =>
            {
                z.ImagePath = NewPicture;
            }));
            PublicBoard.ToList().ForEach(x => x.Value.Where(y => y.UserSN == UserSN).ToList().ForEach(z =>
            {
                z.ImagePath = NewPicture;
            }));
        }

        public static List<BoardModel> GetAllPrivateBoard(int TopicSN)
        {
            return GetAllBoard(TopicSN, 0);
        }

        public static List<BoardModel> GetAllPublicBoard(int TopicSN)
        {
            return GetAllBoard(TopicSN, 1);
        }

        private static List<BoardModel> GetAllBoard(int TopicSN, int PublishType)
        {
            Dictionary<int, List<BoardModel>> target;
            if (PublishType == 0)
            {
                target = PrivateBoard;
            }
            else
            {
                target = PublicBoard;
            }
            var data = target.Where(x => x.Key == TopicSN).FirstOrDefault();
            return data.Value;
        }

        public static void AddBoardMessage(DbBoardContent data)
        {
            if (data.PublishType == 0)
            {
                AddBoardMessage(data, PrivateBoard);
            }
            else
            {
                AddBoardMessage(data, PublicBoard);
            }
        }

        private static void AddBoardMessage(DbBoardContent data, Dictionary<int, List<BoardModel>> Cache)
        {
            int TopicSN = data.TopicSN;
            BoardModel model = new BoardModel()
            {
                Content = data.Content,
                DateCreated = data.DateCreated,
                ImagePath = data.UserIcon,
                LoginId = data.UserLoginId,
                Saved = false,
                UserName = data.UserName,
                UserSN = data.UserSN
            };

            Dictionary<int, List<BoardModel>> target = Cache;
            if (target.Keys.Contains(TopicSN))
            {
                target[TopicSN].Add(model);
                if (target[TopicSN].Count > MessageMax)
                {
                    target[TopicSN].RemoveAt(0);
                }
            }
            else
            {
                target.Add(TopicSN, new List<BoardModel>() { model });
            }
        }
    }

    public class BoardModel
    {
        public string ImagePath { get; set; }

        public string UserName { get; set; }

        public string LoginId { get; set; }

        public int UserSN { get; set; }

        public DateTime DateCreated { get; set; }

        public string DateUI
        {
            get
            {
                return DateCreated.ToString("HH:mm:ss");
            }
        }

        public string Content { get; set; }

        public bool Saved { get; set; }
    }
}