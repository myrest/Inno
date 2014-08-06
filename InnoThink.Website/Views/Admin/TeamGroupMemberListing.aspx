<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ Import Namespace="InnoThink.Website.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    歡迎來到 InnoThink
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        UsersViewModel Model = (UsersViewModel)ViewData["Model"];
    %>
    <div class="body0">
        <div id="body1">
            團隊 (<%=Model.TeamGroupName %>) 成員管理
        </div>
        <input type="text" id="LoginId" autofocus /><input type="button" id="savebtn" value="新增" /><br />
        請輸入要新增的登入帳號
        <table>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    成員
                </td>
                <td>
                    功能
                </td>
            </tr>
            <%
                int i = 0;
                if (Model != null && Model.DataResult != null && Model.DataResult.Count() > 0)
                {
                    foreach (var item in Model.DataResult)
                    {
                        i++;
            %>
            <tr>
                <td>
                    <%=i %>
                </td>
                <td>
                    <%=item.UserName %>(<%=item.LoginId %>)
                </td>
                <td>
                    &nbsp;&nbsp;<a href="#" class="del" data-sn="<%=item.SN %>">刪除</a>
                </td>
            </tr>
            <%
                    }
                }
            %>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <%
        UsersViewModel Model = (UsersViewModel)ViewData["Model"];
    %>
    <script>
        $(function () {
            $('#savebtn').on('click', cnTop._AddNew);
            $('.del').on('click', cnTop._Delete);
            Utils.textBoxsOnEnter(cnTop._AddNew, $('#LoginId'));
        });
        var cnTop = {
            _AddNew: function () {
                if ($('#LoginId').val().trim().length == 0) {
                    return false;
                }
                var cb = function (result) {
                    location.reload();
                }
                var ecb = function (result) {
                    var fn = function () {
                        $('#LoginId').focus();
                    }
                    utility.showPopUp(result.msg, 1, fn);
                }
                var param = { LoginId: $('#LoginId').val(), TeamGroupSN: '<% =Model.TeamGroupSN %>' };
                utility.ajaxQuiet('AdminService/AddTeamGroupMember', param, cb, ecb);
            }
            , _Delete: function () {
                var cb = function (result) {
                    location.reload();
                }
                var ecb = function (result) {
                    utility.showPopUp(result.msg, 1);
                }
                var param = { SN: $(this).data('sn') };
                utility.ajaxQuiet('AdminService/DeleteTeamGroupMember', param, cb, ecb);
            }
        };
    </script>
</asp:Content>
