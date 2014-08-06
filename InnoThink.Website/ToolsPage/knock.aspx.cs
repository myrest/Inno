using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InnoThink.Website.ToolsPage
{
    public partial class knock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsValidRequest())
            {
                Session["EnableToolPage"] = true;
            }
            else
            {
                Session["EnableToolPage"] = null;
                this.EndRequest();
            }
        }

        private bool IsValidRequest()
        {
            return true;
        }

        private void EndRequest()
        {
            Response.Redirect("~/Views/Shared/Error.aspx", true);
            Response.StatusCode = 404;
            Response.End();
        }
    }
}