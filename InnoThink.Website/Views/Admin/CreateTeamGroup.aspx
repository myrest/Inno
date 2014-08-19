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
            建立團隊
        </div>
        團隊名稱:<input type="text" id="TeamName" />
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
                $('#savebtn').on('click', Adj.Action);
                Utils.textBoxsOnEnter(Adj.Action, $('#savebtn'));
            },
            Action: function () {
                var cb = function (data) {
                    utility.showPopUp(data.msg, 1, function () {
                        location.href = utility.getRedirUrl('Admin', 'TeamGroupListing');
                    });
                };
                var ecb = function (data) {
                    utility.showPopUp(data.msg, 1);
                }
                var param = { TeamGroupName: $('#TeamName').val() };
                utility.ajaxQuiet('AdminService/CreateTeamGroup', param, cb, ecb);
            }
        };

        $(function () {
            Adj.init();
            //JSON.stringify(possessList)
        });
    </script>
</asp:Content>