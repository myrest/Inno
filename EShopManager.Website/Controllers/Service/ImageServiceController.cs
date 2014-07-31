﻿using System.Drawing;
using System.Web.Mvc;
using EShopManager.Core.Constancy;
using EShopManager.Core.MVC;
using EShopManager.Website.Models.Image;

namespace EShopManager.Website.Controllers.Service
{
    public class ImageServiceController : Controller
    {
        public ImageServiceController() { }

        //
        // GET: /ImageService/

        public ImageResult Index()
        {
            CImgVerify cI = new CImgVerify();
            Bitmap bmp = cI.GenerateImage("");
            ImageResult ir = new ImageResult(ControllerContext, bmp);
            return ir;
        }

        //
        // GET: /Captcha/
        public ImageResult Captcha()
        {
            CImgVerify cI = new CImgVerify();
            string sTxt = cI.GetRandomAlphaNumeric();
            Session.Add(SessionKeys.Captcha.ToString(), sTxt); ;
            Bitmap bmp = cI.GenerateImage(sTxt);
            ImageResult ir = new ImageResult(ControllerContext, bmp);
            return ir;
        }
    }
}
