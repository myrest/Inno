using InnoThink.Core.Cache.Board;
using InnoThink.Core.Constancy;
using InnoThink.Core.DB;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Core.Utility;
using InnoThink.Website.Communication;
using InnoThink.Website.Models;
using Rest.Core.Utility;
using System;
using System.Web.Mvc;
using InnoThink.BLL.User;
using InnoThink.Domain.InnoThinkMain.Binding;
using InnoThink.Domain.Constancy;

namespace InnoThink.Website.Controllers.Service
{
    public class BoardServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(BoardServiceController));

        

        public BoardServiceController()
            : base(Permission.Private)
        {
        }

        [HttpPost]
        public JsonResult SendPublicMessage(string Message, int TopicSN)
        {
            ResultBase result = SendBoardMessage(Message, TopicSN, (int)BoardType.Public);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult SendPrivateMessage(string Message, int TopicSN)
        {
            ResultBase result = SendBoardMessage(Message, TopicSN, (int)BoardType.Private);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private ResultBase SendBoardMessage(string Message, int TopicSN, int PublishType)
        {
            ResultBase result = new ResultBase() { };
            User_Manager um = new User_Manager();
            var user = um.GetBySN(sessionData.trading.UserSN);
            BoardUI model = new BoardUI()
            {
                Content = Message,
                DateCreated = DateTime.Now,
                PublishType = PublishType,
                TopicSN = TopicSN,
                Picture = StringUtility.ConvertPicturePath(user.Picture),
                LoginId = user.LoginId,
                UserName = user.UserName,
                UserSN = user.UserSN,
                ContentType = (int)BoardContentType.Message
            };
            BoardCache.AddBoardMessage(model);
            CommServer.Instance.syncUIBoardMessage(model);
            result.JsonReturnCode = 1;
            return result;
        }
    }
}