<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="EShopManager.Core.MVC.Extensions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    歡迎來到 InnoThink
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="body0">
        <div id="body1">
            管理使用者權限
        </div>
        登入帳號:<input type="text" id="UserLoginId" /><br />
        調整權限為:<label for="sys"><input type="radio" name="Position" id="sys"  value="111" />
            系統管理者</label>&nbsp;
        <label for="admin">
            <input type="radio" name="Position" id="admin"  value="11" />
            一般管理者</label>&nbsp;
        <label for="user">
            <input type="radio" name="Position" id="user" value="1" checked="checked" />
            使用者</label>
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
                Utils.textBoxsOnEnter(Adj.AdjustUserPosition, $('#savebtn'));
            },
            AdjustUserPosition: function () {
                var cb = function (data) {
                    utility.showPopUp(data.msg, 1, function () {
                        location.href = utility.getRedirUrl('Member', 'UserInfo');
                    });
                };
                var ecb = function (data) {
                    utility.showPopUp(data.msg, 1);
                }
                var $position = $('input[name=Position]:checked');
                var param = { UserLoginId: $('#UserLoginId').val(), Position: $position.val() };
                utility.ajaxQuiet('AdminService/AdjustUserPosition', param, cb, ecb);
            }
        };

        $(function () {
            Adj.init();
            //JSON.stringify(possessList)
        });
    </script>
</asp:Content>
