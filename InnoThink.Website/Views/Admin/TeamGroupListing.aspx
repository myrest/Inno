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
        TeamGroupListViewModel Model = (TeamGroupListViewModel)ViewData["Model"];
    %>
    <div class="body0">
        <div id="body1">
            團隊名稱管理
        </div>
        <button class="align-right" onclick="location='/Admin/CreateTeamGroup';">建立新的團隊名稱</button>
        <table class="fancytable">
            <tr class="headerrow">
                <td>&nbsp;SN
                </td>
                <td>團隊名稱
                </td>
                <td>團隊代碼
                </td>
                <td>功能
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
                    <%=item.GroupName %>
                </td>
                <td>
                    <%=item.TeamGroupID %>
                </td>
                <td>
                    <a href="/Admin/TeamGroupMemberListing?SN=<%=item.TeamGroupSN %>">管理成員</a>
                    &nbsp;&nbsp;<a href="#" class="deltg" data-id="<%=item.TeamGroupSN %>">刪除</a>
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
    <script>
        $(function () {
            $('.deltg').on('click', cnTop._delTeamGroup);
        });
        var cnTop = {
            _delTeamGroup: function () {
                var cb = function (result) {
                    var fn = function () {
                        location.href = utility.getRedirUrl('Admin', 'TeamGroupListing');
                    }
                    utility.showPopUp(result.msg, 1, fn);
                }
                var ecb = function (result) {
                    utility.showPopUp(result.msg, 1);
                }
                var param = { SN: $(this).data('id') };
                utility.ajaxQuiet('AdminService/DeleteTeamGroup', param, cb, ecb);
            }
        };
    </script>
</asp:Content>