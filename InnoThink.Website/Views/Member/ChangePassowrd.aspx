<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ Import Namespace="InnoThink.Website.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    變更密碼
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="body0">
        <div id="body1">
            變更密碼
        </div>
        <table>
            <tr>
                <td>
                    新密碼：
                </td>
                <td>
                    <input type="password" name="NewPassword" id="NewPassword" autofocus />
                </td>
            </tr>
            <tr>
                <td>
                    確認新密碼：
                </td>
                <td>
                    <input type="password" name="ConfPassword" id="ConfPassword" />
                </td>
            </tr>
            <tr>
                <td>
                    舊密碼：
                </td>
                <td>
                    <input type="password" name="OldPassword" id="OldPassword" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="button" id="save" value="送出" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script>
        $(function () {
            $('#save').on('click', fns.ChangePassword);
            Utils.textBoxsOnEnter(fns.ChangePassword, $('#MainContent input'));
        });
        var fns = {
            isEmpth: function (val, columnname) {
                if (val.length < 1) {
                    utility.showPopUp(columnname + "為必填欄位。", 1);
                    return true;
                } else {
                    return false;
                }
            },
            ChangePassword: function () {
                var newpwd = $('#NewPassword').val().trim();
                var conpwd = $('#ConfPassword').val().trim();
                var oldpwd = $('#OldPassword').val().trim();

                if (fns.isEmpth(newpwd, "新密碼")) {
                    return false;
                }
                if (fns.isEmpth(conpwd, "確認密碼")) {
                    return false;
                }
                if (fns.isEmpth(oldpwd, "舊密碼")) {
                    return false;
                }
                if (newpwd != conpwd) {
                    utility.showPopUp("您兩次輸入的密碼不同。", 1);
                    return false;
                }

                var param = { NewPassword: newpwd, OldPassword: oldpwd };

                var cb = function (result) {
                    utility.showPopUp(result.msg, 1);
                }
                utility.ajaxQuiet('MemberService/ChangePassword', param, cb, cb);

            }
        };
    </script>
</asp:Content>
