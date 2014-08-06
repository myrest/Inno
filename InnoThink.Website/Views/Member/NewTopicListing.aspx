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
        TopicSimpleViewModel Model = (TopicSimpleViewModel)ViewData["Model"];
    %>
    <div class="body0">
        <div id="body1">
            最新發起議題
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
                    <%
                        if (!item.isJoined)
                        {
                            Response.Write(string.Format("&nbsp;&nbsp;<a href=\"#\" class=\"jointopic\" data-id=\"{0}\">我要參加</a>", item.SN));
                            Response.Write(string.Format("&nbsp;&nbsp;<a href=\"#\" class=\"visit\" data-id=\"{0}\">參觀參觀</a>", item.SN));
                        }
                        else
                        {
                            Response.Write(string.Format("&nbsp;&nbsp;<a href=\"#\" class=\"visit\" data-id=\"{0}\">開始討論</a>", item.SN));
                        }

                        bool isAdmin = (bool)ViewData["_isAdmin"];
                        if (isAdmin)
                        {
                            Response.Write(string.Format("&nbsp;&nbsp;<a href=\"#\" class=\"delTopic\" data-id=\"{0}\">刪除</a>", item.SN));
                        }
                    %>
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
            $('.jointopic').on('click', cnTop._jointopic);
            $('.delTopic').on('click', cnTop._delTopic);
            $('.visit').on('click', cnTop._visit);
        });
        var cnTop = {
            _delTopic: function () {
                var cb = function (result) {
                    var fn = function () {
                        location.reload();
                    }
                    utility.showPopUp(result.msg, 1, fn);
                }
                var ecb = function (result) {
                    utility.showPopUp(result.msg, 1);
                }
                var param = { SN: $(this).data('id') };
                utility.ajaxQuiet('TopicService/DeleteTopic', param, cb, ecb);
            },
            _jointopic: function () {
                var param = { SN: $(this).data('id') };
                utility.service("MemberService/JoinTopic", param, "POST", function (data) {
                    if (data.code > 0) {
                        var redirto = utility.getRedirUrl('Member', 'UserInfo') + '?' + (new Date()).getMilliseconds();
                        utility.showPopUp("參加申請已送出", 1, function () { window.location.href = redirto; });
                    } else {
                        utility.showPopUp(data.msg, 1);
                    }
                });
            },
            _visit: function () {
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
