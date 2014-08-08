using CWB.Web.Configuration;
using InnoThink.Core.Constancy;
using InnoThink.Core.MVC.BaseController;
using InnoThink.Core.Utility;
using InnoThink.Website.Communication;
using InnoThink.Website.Models.FileUpload;
using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace InnoThink.Website.Controllers.Service
{
    public class FileUploadServiceController : BaseController
    {
        private static readonly long ImageMaxLengthLimit = 2 * 1024 * 1024;

        public FileUploadServiceController()
            : base(Permission.Private)
        {
        }

        [HttpPost]
        public JsonResult UploadPersonIcon(HttpPostedFileBase Uploadfile)
        {
            UploadFileResult result = new UploadFileResult() { };

            //Check image dimensions.
            int ImageWidth = 90;
            int ImageHeight = 100;
            if (Uploadfile != null)
            {
                Image img = Image.FromStream(Uploadfile.InputStream);
                if (img.Width > ImageWidth || img.Height > ImageHeight)
                {
                    result.setErrorMessage(string.Format("您的圖片尺寸({0}x{1})，超過限制 ({0}x{1}pixel)", img.Width, img.Height, ImageWidth, ImageHeight));
                }
                else
                {
                    try
                    {
                        //Using LoginId MD5 for Icon file name.
                        MD5 md5hash = MD5.Create();
                        string FileName = GetMd5Hash(md5hash, sessionData.trading.LoginId) + Path.GetExtension(Uploadfile.FileName);
                        result.FileName = Uploadfile.FileName;
                        result.FileType = Uploadfile.ContentType;
                        result.FileSize = ConvertFileSize(Uploadfile.ContentLength);
                        sessionData.trading._tempFileName = FileName;
                        string TempFileFullName = string.Format("{0}{1}/{2}", Server.MapPath("~/"), AppConfigManager.SystemSetting.FileUpLoadTempFolder, FileName);
                        Uploadfile.SaveAs(TempFileFullName);
                        result.JsonReturnCode = 1;
                    }
                    catch (Exception ex)
                    {
                        result.setException(ex, "UploadPersonIcon");
                    }
                }
            }
            if (result.JsonReturnCode < 1)
            {
                sessionData.ClearTempValue();
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UploadTeamLogo(HttpPostedFileBase Uploadfile)
        {
            //Check image dimensions.
            int ImageWidth = 150;
            int ImageHeight = 150;

            //This must be using in Step 1, get the Topic SN from SessionData.
            UploadFileResult result = new UploadFileResult() { };
            if (Uploadfile != null)
            {
                Image img = Image.FromStream(Uploadfile.InputStream);
                if (img.Width > ImageWidth || img.Height > ImageHeight)
                {
                    result.setErrorMessage(string.Format("圖片尺寸超過限制 ({0}x{1}pixel)", ImageWidth, ImageHeight));
                }
                else
                {
                    try
                    {
                        //Using LoginId MD5 for Icon file name.
                        MD5 md5hash = MD5.Create();
                        string FileName = GetMd5Hash(md5hash, sessionData.trading._tempInt.ToString()) + Path.GetExtension(Uploadfile.FileName);
                        result.FileName = Uploadfile.FileName;
                        result.FileType = Uploadfile.ContentType;
                        result.FileSize = ConvertFileSize(Uploadfile.ContentLength);
                        result.TempFileName = FileName;
                        sessionData.trading._tempFileName = FileName;
                        Uploadfile.SaveAs(string.Format("{0}{1}/{2}", Server.MapPath("~/"), AppConfigManager.SystemSetting.FileUpLoadTempFolder, FileName));
                        result.JsonReturnCode = 1;
                        //Update client's team logo
                        string logoPath = StringUtility.ConvertTempPath(FileName);
                        string ImgHtml = string.Format("<img src=\"{0}\" />", logoPath);
                        CommServer.Instance.syncUIInfo(sessionData.trading._tempInt, "teamlogo", ImgHtml, "", "");
                    }
                    catch (Exception ex)
                    {
                        result.setException(ex, "UploadPersonIcon");
                    }
                }
            }
            if (result.JsonReturnCode < 1)
            {
                sessionData.ClearTempValue();
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UploadResult(HttpPostedFileBase Uploadfile)
        {
            //Check image dimensions.
            int ImageWidth = 150;
            int ImageHeight = 150;
            string PreFix = "Result";
            UploadFileResult result = CheckAndSaveUploadFile(Uploadfile, ImageWidth, ImageHeight, PreFix);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UploadScenario(HttpPostedFileBase Uploadfile)
        {
            //Check image dimensions.
            int ImageWidth = 150;
            int ImageHeight = 150;
            string PreFix = "Scenario";
            UploadFileResult result = CheckAndSaveUploadFile(Uploadfile, ImageWidth, ImageHeight, PreFix);
            if (!result.IsImage)
            {
                result.setErrorMessage("只能上傳圖檔");
            }
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UploadBest1Image(HttpPostedFileBase Uploadfile)
        {
            //Check image dimensions.
            int ImageWidth = 150;
            int ImageHeight = 150;
            string PreFix = "Best1";
            UploadFileResult result = CheckAndSaveUploadFile(Uploadfile, ImageWidth, ImageHeight, PreFix);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UploadBest2Image(HttpPostedFileBase Uploadfile)
        {
            //Check image dimensions.
            int ImageWidth = 150;
            int ImageHeight = 150;
            string PreFix = "Best2";
            UploadFileResult result = CheckAndSaveUploadFile(Uploadfile, ImageWidth, ImageHeight, PreFix);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult TempDeleteBestImage(int SN)
        {
            UploadFileResult result = new UploadFileResult() { };
            sessionData.trading._tempFileName = "DELETE";
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult UploadBest6Image(HttpPostedFileBase Uploadfile)
        {
            //Check image dimensions.
            int ImageWidth = 150;
            int ImageHeight = 150;
            string PreFix = "Best6";
            UploadFileResult result = CheckAndSaveUploadFile(Uploadfile, ImageWidth, ImageHeight, PreFix);
            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private UploadFileResult CheckAndSaveUploadFile(HttpPostedFileBase Uploadfile, int ImageWidth, int ImageHeight, string PreFix)
        {
            //This must be get the Topic SN from SessionData.
            UploadFileResult result = new UploadFileResult() { };
            if (Uploadfile != null)
            {
                Image img;
                try
                {
                    //if the file size is to large, then make as is not image.
                    if (Uploadfile.ContentLength > ImageMaxLengthLimit)
                    {
                        result.IsImage = false;
                    }
                    else
                    {
                        result.IsImage = true;
                        //Is Image need to check image size
                        img = Image.FromStream(Uploadfile.InputStream);
                        if (img.Width > ImageWidth || img.Height > ImageHeight)
                        {
                            result.setErrorMessage(string.Format("圖片尺寸超過限制 ({0}x{1}pixel)", ImageWidth, ImageHeight));
                        }
                    }
                }
                catch
                {
                    result.IsImage = false;
                }

                try
                {
                    //Using LoginId MD5 for template file name.
                    MD5 md5hash = MD5.Create();
                    string FileName = PreFix + GetMd5Hash(md5hash, sessionData.trading.sn.ToString()) + Path.GetExtension(Uploadfile.FileName);
                    result.FileName = Uploadfile.FileName;//User's uploaded file name.
                    result.FileType = Uploadfile.ContentType;
                    result.FileSize = ConvertFileSize(Uploadfile.ContentLength);
                    result.TempFileName = FileName;//Server given name.

                    //Handle for file name and is image or not.
                    sessionData.trading._tempFileName = FileName;
                    sessionData.trading._OrignFileName = Uploadfile.FileName;
                    sessionData.trading._isImage = result.IsImage;

                    Uploadfile.SaveAs(string.Format("{0}{1}/{2}", Server.MapPath("~/"), AppConfigManager.SystemSetting.FileUpLoadTempFolder, FileName));
                    result.setMessage("Done");
                }
                catch (Exception ex)
                {
                    result.setException(ex, "CheckAndSaveUploadFile");
                }
            }
            if (result.JsonReturnCode < 1)
            {
                sessionData.ClearTempValue();
            }
            return result;
        }

        private string ConvertFileSize(decimal FileSize)
        {
            decimal k = 1024;
            decimal m = k * 1024;
            int maxSize = 25;
            if (FileSize > m * maxSize)
            {
                throw new Exception(string.Format("上傳檔案大小超過限制{0}M", maxSize));
            }
            else
            {
                if (FileSize < k)
                {
                    return string.Format("{0}B", FileSize);
                }
                else if (FileSize < m)
                {
                    return string.Format("{0}K", Math.Round(FileSize / k, 1));
                }
                else
                {
                    return string.Format("{0}M", Math.Round(FileSize / m, 1));
                }
            }
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            int MaxLength = 10;
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            string result = sBuilder.ToString();
            if (result.Length > MaxLength)
            {
                result = result.Substring(0, MaxLength);
            }
            return result;
        }
    }
}