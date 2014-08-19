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
        <%
            bool isAdmin = (bool)ViewData["_isAdmin"];
            if (isAdmin)
            {
        %>
        <h1>系統管理專區</h1>
        <a href="/Admin/AdminListing">管理使用者</a><br />
        <a href="/Admin/TeamGroupListing">管理團隊名稱</a><br />
        <a href="/Admin/TopicManage">議題管理</a><br />
        <%
            }
        %>
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.query.js") %>"></script>
</asp:Content>