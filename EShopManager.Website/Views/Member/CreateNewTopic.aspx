<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="EShopManager.Core.MVC.Extensions" %>
<%@ Import Namespace="EShopManager.Core.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    歡迎來到 InnoThink
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="body0">
        <div id="body1">
            建立新的議題
        </div>
        <table>
            <tr>
                <td>
                    議題：
                </td>
                <td>
                    <input type="text" id="subject" size="80" />
                </td>
            </tr>
            <tr>
                <td>
                    開放範圍：
                </td>
                <td>
                    <label for="all">
                        <input type="radio" id="all" name="opento" value="<% =(int)TopicPublishType.All %>" />全部</label>
                    <label for="all">
                        <input type="radio" id="tg" name="opento" value="<% =(int)TopicPublishType.TeamGroup %>" />同一團隊</label>
                    <label for="all">
                        <input type="radio" id="private" name="opento" value="<% =(int)TopicPublishType.Private %>" checked="checked" />儘自己</label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="button" id="save" value="建立" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script>
        $(function () {
            Utils.textBoxsOnEnter(cnTop._save, $('#subject'));
            $('#save').on('click', cnTop._save);
            $('#subject').focus();
        });
        var cnTop = {
            _save: function () {
                if ($('#subject').val().length === 0) {
                    utility.showPopUp('請輸您要建立的新議題。', 1, function () { $("#subject").focus(); });
                }
                else {
                    var $opento = $('input[name=opento]:checked');
                    var param = { subject: $('#subject').val(), opento: $opento.val() };
                    utility.service("MemberService/NewTopic", param, "POST", function (data) {
                        if (data.code > 0) {
                            var redirto = utility.getRedirUrl('Member', 'UserInfo') + '?' + (new Date()).getMilliseconds();
                            utility.showPopUp("建立完成", 1, function () { window.location.href = redirto; });
                        } else {
                            utility.showPopUp(data.msg, 1);
                        }
                    });
                }
            }
        };
    </script>
</asp:Content>
