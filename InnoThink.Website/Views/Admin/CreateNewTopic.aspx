<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ Import Namespace="InnoThink.Core.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    歡迎來到 InnoThink
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="body0">
        <div id="body1">
            建立團隊議題
        </div>
        <table>
            <tr>
                <td>議題：
                </td>
                <td>
                    <input type="text" id="Subject" size="80" />
                </td>
            </tr>
            <tr>
                <td>團隊序號：
                </td>
                <td>
                    <input type="text" id="TeamGroupId" size="80" />
                </td>
            </tr>
            <tr>
                <td>是否為沙箱：
                </td>
                <td>
                    <label for="isSandBox">
                    <input type="checkbox" id="isSandBox" />是
                    </label>
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
            Utils.textBoxsOnEnter(cnTop._save, $('#Subject'));
            $('#save').on('click', cnTop._save);
            $('#Subject').focus();
        });
        var cnTop = {
            _save: function () {
                if ($('#Subject').val().length === 0) {
                    utility.showPopUp('請輸您要建立的新議題。', 1, function () { $("#Subject").focus(); });
                }
                if ($('#TeamGroupId').val().length === 0) {
                    utility.showPopUp('請輸您要建立群組代碼。', 1, function () { $("#TeamGroupId").focus(); });
                }
                else {
                    var isSandBox = $('#isSandBox:checked').length > 0 ? true : false;
                    var param = { Subject: $('#Subject').val(), TeamGroupId: $('#TeamGroupId').val(), isSandBox: isSandBox };
                    utility.service("AdminService/NewTopic", param, "POST", function (data) {
                        if (data.code > 0) {
                            var redirto = utility.getRedirUrl('Admin', 'TopicManage') + '?' + (new Date()).getMilliseconds();
                            utility.showPopUp(data.msg, 1, function () { window.location.href = redirto; });
                        } else {
                            utility.showPopUp(data.msg, 1);
                        }
                    });
                }
            }
        };
    </script>
</asp:Content>