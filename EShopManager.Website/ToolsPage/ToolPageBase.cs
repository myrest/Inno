using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace EShopManager.Website.ToolsPage
{
    public class ToolPageBase : System.Web.UI.Page
    {
        public ToolPageBase()
        {
            EnableViewState = true;
        }

        protected override void OnInit(EventArgs e)
        {
            bool bypassEntrance;

            IList domains = new List<string>
            {
                "localhost:4444"
            };

            if (domains.Contains(Request.ServerVariables["HTTP_HOST"]))
                bypassEntrance = true;
            else
                bypassEntrance = false;

            if (!bypassEntrance && Session["EnableToolPage"] == null)
            {
                this.EndRequest();
            }

            base.OnInit(e);
        }

        protected void EndRequest()
        {
            Response.Redirect("~/Views/Shared/Error.aspx", true);

            Response.StatusCode = 404;
            Response.End();
        }
    }
}
