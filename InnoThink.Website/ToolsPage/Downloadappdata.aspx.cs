using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace InnoThink.Website.ToolsPage
{
    public partial class Downloadappdata : ToolPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fname = Request.QueryString["f"];
            string fullfilepath = HttpContext.Current.Server.MapPath("\\App_Data\\") + fname;
            if (File.Exists(fullfilepath))
            {
                //using (FileStream fileStream = new FileStream(fullfilepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite) ;
                FileStream fileStream = new FileStream(fullfilepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                if (fileStream.Length > 0)
                {
                    Response.Clear();
                    Response.ClearContent();
                    Response.ClearHeaders();

                    if (!string.IsNullOrEmpty(Request.QueryString["v"]) && (Request.QueryString["v"] == "1"))
                    {
                        Response.ContentType = "text/plain";
                    }
                    else
                    {
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + fname);
                        Response.ContentType = "application/octet-stream";
                    }


                    byte[] bytes = new byte[(int)fileStream.Length];
                    fileStream.Read(bytes, 0, bytes.Length);
                    fileStream.Close();
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
                else
                {
                    Response.Write(string.Format("File [{0}] file size = 0.", fullfilepath));
                }
            }
            else
            {
                Response.Write(string.Format("File [{0}] is not exist.", fullfilepath));
            }
        }
    }
}
