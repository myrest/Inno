<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<table width="230" border="0" align="center" cellpadding="3">
    <tr>
        <td>
            <img src="/pic/slogo-2.jpg" width="22" height="20" alt="" />
    <%
        bool isAdmin = (bool)ViewData["_isAdmin"];
        if (!isAdmin)
        {
            Response.Write("<a href=\"/Member/UserInfo\">會員專區</a>");
        }
        else
        {
            Response.Write("<a href=\"/Admin/Admin\">管理專區</a>");
        }
    %>
        </td>
    </tr>
    <tr>
        <td>
            <img src="/pic/slogo-2.jpg" width="22" height="20" alt="" />
    <%
        if (!isAdmin)
        {
            Response.Write("<a href=\"/Member/NewTopicListing\">查看最新的議題</a>");
        }
        else
        {
            Response.Write("<a href=\"/Admin/TopicManage\">議題管理</a>");
        }
    %>
        </td>
    </tr>
    <tr>
        <td>
            <img src="/pic/slogo-2.jpg" width="22" height="20" alt="" />
            <a href="#" id="JoinedTopic">正在參加的議題</a>
        </td>
    </tr>
</table>
