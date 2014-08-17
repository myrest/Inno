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
            InnoThink.Domain.BackofficeUser_Info model = ViewData["Model"] as InnoThink.Domain.BackofficeUser_Info;
        %>
        <div id="body1">
            管理使用者權限
        </div>
        登入帳號:
        <%
            if (model.BackofficeUserSN == 0)
            {
                //Insert
        %>
        <input type="text" id="UserLoginId" value="" autofocus  />
        <%
            }
            else
            {
                //Update
                Response.Write(model.LoginId);
            }
        %><br />
        登入密碼: <input type="password" id="Password" value="" /><br />
        <input type="hidden" id="SN" value="<% =model.BackofficeUserSN%>" />
        設定權限為:<label for="sys"><input type="radio" name="Position" id="sys" value="111" />
            系統管理者</label>&nbsp;
        <label for="admin">
            <input type="radio" name="Position" id="admin" value="11" checked />
            老師</label>&nbsp;
        <br />
        <input type="button" id="savebtn" value="送出" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.query.js") %>"></script>
    <script>
        ///<reference path="./lib/jquery-1.9.1-vsdoc.js" />
        ///<reference path="common.js" />

        var Adj = {
            init: function () {
                $('#savebtn').on('click', Adj.AdjustUserPosition);
                Utils.textBoxsOnEnter(Adj.AdjustUserPosition);
            },
            AdjustUserPosition: function () {
                var cb = function (data) {
                    utility.showPopUp(data.msg, 1, function () {
                        location.href = utility.getRedirUrl('Admin', 'AdminListing');
                    });
                };
                var ecb = function (data) {
                    utility.showPopUp(data.msg, 1, function () {
                        $('#UserLoginId').focus();
                    });
                };
                var $position = $('input[name=Position]:checked');
                var param = {
                    LoginId: $('#UserLoginId').val(),
                    Level: $position.val(),
                    SN: $('#SN').val(),
                    Password: $('#Password').val()
                };
                utility.ajaxQuiet('AdminService/AdjustUserPosition', param, cb, ecb);
            }
        };

        $(function () {
            Adj.init();
            //JSON.stringify(possessList)
        });
    </script>
</asp:Content>
