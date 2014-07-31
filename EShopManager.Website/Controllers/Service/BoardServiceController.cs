using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShopManager.Core.Utility;
using EShopManager.Core.DB;
using EShopManager.Website.Models;
using CWB.Web;
using CWB.Web.Configuration;
using EShopManager.Core.Constancy;
using EShopManager.Core;
using EShopManager.Core.MVC.BaseController;
using EShopManager.Website.Models.Topic;
using EShopManager.Website.Communication;
using EShopManager.Core.Model.Topic;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
using EShopManager.Core.Cache.Board;

namespace EShopManager.Website.Controllers.Service
{
    public class BoardServiceController : BaseController
    {
        //
        // GET: /LoginServiced/
        private static readonly SysLog Log = SysLog.GetLogger(typeof(BoardServiceController));
        private static readonly DbUserTable dbUser = new DbUserTable() { };

        public BoardServiceController()
            : base(Permission.Private)
        {
        }

        [HttpPost]
        public JsonResult SendPublicMessage(string Message, int TopicSN)
        {
            ResultBase result = SendBoardMessage(Message, TopicSN, 1);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult SendPrivateMessage(string Message, int TopicSN)
        {
            ResultBase result = SendBoardMessage(Message, TopicSN, 0);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private ResultBase SendBoardMessage(string Message, int TopicSN, int PublishType)
        {
            ResultBase result = new ResultBase() { };
            var user = dbUser.getUserBySN(sessionData.trading.sn);
            DbBoardContent model = new DbBoardContent()
            {
                Content = Message,
                DateCreated = DateTime.Now,
                PublishType = PublishType,
                TopicSN = TopicSN,
                UserIcon = StringUtility.ConvertPicturePath(user.Picture),
                UserLoginId = user.LoginId,
                UserName = user.UserName,
                UserSN = user.SN
            };
            BoardCache.AddBoardMessage(model);
            CommServer.Instance.syncUIBoardMessage(model);
            result.JsonReturnCode = 1;
            return result;
        }


    }
}
