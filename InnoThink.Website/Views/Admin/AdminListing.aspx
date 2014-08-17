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
            管理使用者
        </div>
        <%
            List<InnoThink.Domain.BackofficeUser_Info> model = ViewData["Model"] as List<InnoThink.Domain.BackofficeUser_Info>;
        %>
        <button id="Add" class="align-right">Add New</button>
        <table>
            <tr>
                <td>
                    SN.
                </td>
                <td>
                    LoginId
                </td>
                <td>
                    Manage
                </td>
            </tr>
            <%
                int i = 1;
                foreach (var item in model)
                {
            %>
            <tr>
                <td>
                    <% =i++ %>
                </td>
                <td>
                    <% =item.LoginId %>
                </td>
                <td sn="<% =item.BackofficeUserSN %>">
                    <a href="javascript:void(0);" class="delete">Delete</a> | 
                    <a href="javascript:void(0);" class="edit">Edit</a>
                </td>
            </tr>
            <%
                }
                
            %>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.query.js") %>"></script>
    <script>
        ///<reference path="./lib/jquery-1.9.1-vsdoc.js" />
        ///<reference path="common.js" />

        var Adj = {
            init: function () {
                $('#Add').on('click', Adj.Edit);
                $('.delete').on('click', Adj.Delete);
                $('.edit').on('click', Adj.Edit);
            },
            Delete: function () {
                var sn = $(this).parent().attr('sn');
                var param = {
                    SN: sn
                };
                var cb = function () {
                    window.location.reload();
                }
                utility.ajaxQuiet('AdminService/DeleteAdmin', param, cb, utility.ecb);
            },
            Edit: function () {
                var sn = $(this).parent().attr('sn');
                if (sn == undefined) { sn = 0 };
                var param = {
                    SN: sn
                };
                var editurl = utility.getRedirUrl('Admin', 'AdminEdit', 'SN=' + sn);
                location.href = editurl;
            }
        };

        $(function () {
            Adj.init();
            //JSON.stringify(possessList)
        });
    </script>
</asp:Content>
