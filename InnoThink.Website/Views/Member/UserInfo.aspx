<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    歡迎來到 InnoThink
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="body0">
        <div id="body1">
            會員專區
        </div>
        <h3>我想要:</h3>
        <a href="/Member/UpdateMyInfo">修改個人資料</a><br />
        <a href="/Member/ChangePassowrd">修改密碼</a><br />
        <a href="/Member/CreateNewTopic">建立新的議題</a><br />
        <!-- <a href="/Member/JoinedTopic">查看正在參加的議題</a><br /> -->
        <%
            bool isAdmin = (bool)ViewData["_isAdmin"];
            if (isAdmin)
            {
        %>
        <h1>系統管理專區</h1>
        <a href="/Admin/AdjustUserPosition">管理使用者權限</a><br />
        <a href="/Admin/CreateTeamGroup">建立新的團隊名稱</a><br />
        <a href="/Admin/TeamGroupListing">管理團隊名稱</a><br />
        <%
            }
        %>
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.query.js") %>"></script>
</asp:Content>