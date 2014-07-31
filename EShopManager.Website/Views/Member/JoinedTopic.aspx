<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="EShopManager.Core.MVC.Extensions" %>
<%@ Import Namespace="EShopManager.Website.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    歡迎來到 InnoThink
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%
    TopicSimpleViewModel Model = (TopicSimpleViewModel)ViewData["Model"];
%>
    <div class="body0">
        <div id="body1">
            已參加並且正在進行中的議題
        </div>
        <table>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    議題
                </td>
                <td>
                    隊名
                </td>
                <td>
                    &nbsp;
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
                    <%=item.Subject %>
                </td>
                <td>
                    <%=item.TeamName %>
                </td>
                <td>
                    <a href="#" class="Start" data-id="<%=item.SN %>">開始討論</a>
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
            $('.Start').on('click', cnStart._Start);
        });
        var cnStart = {
            _Start: function () {
                var param = { SN: $(this).data('id') };
                utility.service("TopicService/CheckTopic", param, "POST", function (data) {
                    if (data.code > 0) {
                        var redirto = data.msg + '&' + (new Date()).getMilliseconds();
                        window.location.href = redirto;
                    } else {
                        utility.showPopUp(data.msg, 1);
                    }
                });
            }
        };
    </script>
</asp:Content>
