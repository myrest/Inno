<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ Import Namespace="InnoThink.Website.Models" %>
<%@ Import Namespace="InnoThink.Domain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    歡迎來到 InnoThink
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
    <link href="<%= Url.CdnContent("/CSS/jquery.fileupload-ui.css") %>" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        User_Info Model = (User_Info)ViewData["Model"];
        string Picture = string.Empty;
        if (!string.IsNullOrEmpty(Model.Picture))
        {
            Picture = string.Format("<img src=\"{0}\" />", Model.Picture);
        }
        string TeamGroupID = ViewData["TeamGroupID"].ToString();
    %>
    <div class="body0">
        <div id="body1">
            會員專區
        </div>
        <table>
            <tr>
                <td>名稱：
                </td>
                <td>
                    <input type="text" id="UserName" value="<% =Model.UserName %>" />
                </td>
            </tr>
            <tr>
                <td>個人專長：
                </td>
                <td>
                    <input type="text" id="Professional" value="<% =Model.Professional %>" />
                </td>
            </tr>
            <tr>
                <td>所屬群組：
                </td>
                <td>
                    <input type="text" id="TeamGroupID" value="<% =TeamGroupID %>" /><br />
                    若您不曉得您的所屬群組，請留空即可。
                </td>
            </tr>
            <tr>
                <td>
                    <span id="icon"><% =Picture %></span>
                </td>
                <td>
                    <form id="file_upload" runat="server">
                        <div id="filediv">
                            <input type="file" name="Uploadfile" multiple="">
                            <button>
                                上傳</button>
                            <div>
                                檔案上傳
                            </div>
                        </div>
                        <table id="files">
                        </table>
                    </form>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="button" value="送出" id="save" />
                    <input type="button" value="取消" id="cancle" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload.js") %>"></script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload-ui.js") %>"></script>
    <script>
        $(function () {
            $('#save').on('click', updateMyInfo._Save);
            $('#cancle').on('click', function () { history.go(-1); });
        });
        var updateMyInfo = {
            _Save: function () {
                var TeamGroupID = $('#TeamGroupID').val();
                var param = { Professional: $('#Professional').val(), UserName: $('#UserName').val(), TeamGroupID: TeamGroupID };
                utility.service("MemberService/UpdateMyInfo", param, "POST", function (data) {
                    if (data.code > 0) {
                        var redirto = '/Member/UserInfo' + '?' + (new Date()).getMilliseconds();
                        utility.showPopUp(data.msg, 1, function () { window.location.href = redirto; });
                    } else {
                        utility.showPopUp(data.msg, 1);
                    }
                });
            }
        };
        /*global $ */
        $(function () {
            $('#file_upload').fileUploadUI({
                url: '/FileUploadService/UploadPersonIcon',
                method: 'POST',
                uploadTable: $('#files'),
                downloadTable: $('#files'),
                buildUploadRow: function (files, index) {
                    $('#files').html('');
                    return $('<tr><td>' + files[index].name + '(' + files[index].size + ')<\/td>' +
                            '<td class="file_upload_progress"><div><\/div><\/td>' +
                            '<td class="file_upload_cancel">' +
                            '<button class="ui-state-default ui-corner-all" title="取消">' +
                            '<span class="ui-icon ui-icon-cancel">取消<\/span>' +
                            '<\/button><\/td><\/tr>');
                },
                buildDownloadRow: function (file) {
                    if (file.code > 0) {
                        return $('<tr><td>' + file.fn + '(' + file.fs + ')<\/td><\/tr>');
                    } else {
                        utility.showPopUp(file.msg, 1);
                    }
                }
            });
        });
    </script>
</asp:Content>