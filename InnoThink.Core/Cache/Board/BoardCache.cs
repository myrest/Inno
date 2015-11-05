using InnoThink.Core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using InnoThink.BLL.Board;
using InnoThink.Core.Constancy;
using InnoThink.Domain.Constancy;
using InnoThink.Domain;
using InnoThink.Domain.InnoThinkMain.Binding;
using InnoThink.Core.Utility;
using Rest.Core.Utility;

namespace InnoThink.Core.Cache.Board
{
    public class BoardCache
    {
        private static Dictionary<int, List<BoardUI>> PrivateBoard = new Dictionary<int, List<BoardUI>>() { };
        private static Dictionary<int, List<BoardUI>> PublicBoard = new Dictionary<int, List<BoardUI>> { };

        #region Deal with cache
        static void InitialCache()
        {
            //Get date from DB to Cache [Private].
            var board = new Board_Manager().GetByLimitedRecord();
            board.ToList().ForEach(x =>
            {
                AddToCache(x);
            });
        }

        private static void InitialCache(BoardType bt, int TopicSN)
        {
            var board = new Board_Manager().GetByLimitedRecord(bt, TopicSN);
            board.OrderBy(x => x.BoardSN).ToList().ForEach(x =>
                {
                    AddToCache(x);
                });
        }

        private static void AddToCache(BoardUI board)
        {
            if (board.PublishType == (int)BoardType.Public)
            {
                _AddToCache(PublicBoard, board);
            }
            else
            {
                _AddToCache(PrivateBoard, board);
            }
        }

        private static void _AddToCache(Dictionary<int, List<BoardUI>> target, BoardUI board)
        {
            if (!target.Any(x => x.Key == board.TopicSN))
            {
                target[board.TopicSN] = new List<BoardUI>() { };
            }
            //modify user's picture
            board.Picture = StringUtility.ConvertPicturePath(board.Picture);
            if (target[board.TopicSN].Count() > 10)
            {
                target[board.TopicSN].RemoveAt(0);
            }
            target[board.TopicSN].Add(board);
        }
        #endregion

        /// <summary>
        /// Update user picture, if user has change user's image.
        /// </summary>
        /// <param name="UserSN">User's SN</param>
        /// <param name="NewPicture">New full picture path for ui display purpose.</param>
        public static void ChangePersionPicture(int UserSN, string NewPicture)
        {
            PrivateBoard.ToList().ForEach(x => x.Value.Where(y => y.UserSN == UserSN).ToList().ForEach(z =>
            {
                z.Picture = NewPicture;
            }));
            PublicBoard.ToList().ForEach(x => x.Value.Where(y => y.UserSN == UserSN).ToList().ForEach(z =>
            {
                z.Picture = NewPicture;
            }));
        }

        public static List<BoardUI> GetAllBoard(int TopicSN, BoardType boardType)
        {
            List<BoardUI> rtn = new List<BoardUI>() { };
            rtn = PrivateBoard.Where(x => x.Key == TopicSN).FirstOrDefault().Value;
            if (rtn == null || rtn.Count() == 0)
            {
                InitialCache(boardType, TopicSN);
            }

            switch (boardType)
            {
                case BoardType.Private:
                    return PrivateBoard.Where(x => x.Key == TopicSN).FirstOrDefault().Value;
                default:
                    return PublicBoard.Where(x => x.Key == TopicSN).FirstOrDefault().Value;
            }
        }

        public static void AddBoardMessage(BoardUI data)
        {
            AddToCache(data);
            new Board_Manager().Insert(data);
        }
    }
}