<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnvValues.aspx.cs" Inherits="InnoThink.Website.ToolsPage.EnvValues" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <%
        string path = HttpContext.Current.Server.MapPath("\\App_Data");
        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(path);
        System.IO.FileInfo[] fis = di.GetFiles();
        foreach (System.IO.FileInfo fi in fis)
        {
            string fn = string.Format("(<a href=\"./Downloadappdata.aspx?f={0}&v=1\">ViewOnline</a>)", fi.Name);
            fn += string.Format("<a href=\"./Downloadappdata.aspx?f={0}\">{1}</a>&nbsp;", fi.Name, fi.Name);
            Response.Write(fn + "<BR>");

        }

        string uipara = (Request.QueryString["folder"] != null) ? Request.QueryString["folder"].ToString() : "";
        path = HttpContext.Current.Server.MapPath("\\") + uipara;
        di = new System.IO.DirectoryInfo(path);
        Response.Write(string.Format("Get folders path = {0}<BR>", path));
        di = new System.IO.DirectoryInfo(path);
        System.IO.DirectoryInfo[] dis = di.GetDirectories();
        foreach (System.IO.DirectoryInfo dri in dis)
        {
            Response.Write(string.Format("{0}<BR>", dri.Name));
            System.IO.DirectoryInfo[] fls = dri.GetDirectories();
            fls.ToList().ForEach(x =>
            {
                Response.Write(string.Format("&nbsp;&nbsp;{0}<BR>", x.Name));
                System.IO.FileInfo[] fns = x.GetFiles();
                fns.ToList().ForEach(y =>
                    {
                        Response.Write(string.Format("&nbsp;&nbsp;&nbsp;&nbsp;{0}<BR>", y.Name));
                    }
                    );
            });
        }
        Response.Write("======================<BR>");

    %>
    </div>
    </form>
</body>
</html>
