<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="EShopManager.Core.MVC.Extensions" %>
<%@ Import Namespace="EShopManager.Website.Models" %>
<%@ Import Namespace="EShopManager.Core" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    歡迎來到 InnoThink
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
    <style type="text/css">
        .right
        {
            float: right;
            top: -10px;
            position: relative;
            padding-right:14px;
        }
        #header
        {
            height: 50px;
            margin-left: 0px;
            margin-right: 0px;
            margin-top: 0px;
            background-color: #F2F2F2;
            z-index: 0;
        }
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
        }
        #headerlogo
        {
            width: 150px;
            position: static;
            left: 629px;
            top: -5px;
            z-index: 2;
            float: left;
            margin-left: 0px;
        }
        #headerword
        {
            width: 740px;
            position: absolute;
            font-size: small;
            height: 48px;
            float: right;
            z-index: 1;
            padding-top: 0px;
            margin-left: -370px;
            left: 50%;
            margin-top: 0px;
        }
        #header #headerword #header-word2
        {
            padding-top: 25px;
            float: right;
        }
        .body0
        {
            width: 740px;
            margin-left: -370px;
            position: relative;
            left: 50%;
            height: auto;
            border-radius: 20px;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            background-image: url(/pic/back-3.jpg);
            font-size: small;
            top: 8px;
            padding-bottom: 17px;
        }
        #bottom0
        {
            width: 740px;
            margin-left: -370px;
            left: 50%;
            position: relative;
            top: 15px;
            text-align: center;
            font-size: small;
            margin-bottom: 10px;
            padding-bottom: 10px;
            display: inline-block;
        }
        #talk0 #talk1
        {
            margin-top: 10px;
            margin-right: 10px;
            position: static;
            -webkit-box-shadow: 0px 0px 0px #CCCCCC;
            box-shadow: 0px 0px 0px #CCCCCC;
            width: 260px;
            border-collapse: collapse;
            margin-bottom: 0px;
        }
        #talk0 #talk2
        {
            margin-left: 10px;
            margin-right: 10px;
            position: static;
            -webkit-box-shadow: 0px 0px 0px #CCCCCC;
            box-shadow: 0px 0px 0px #CCCCCC;
            width: 260px;
            border-collapse: collapse;
        }
        .body0 #body1
        {
            height: 25px;
            background-color: #4FA3C7;
            border-top-left-radius: 20px;
            border-top-right-radius: 20px;
            color: #FFFFFF;
            padding-top: 8px;
            text-align: center;
        }
        .body0 #body2
        {
            height: auto;
            padding-left: 15px;
            margin-left: 15px;
            margin-right: 15px;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #FFFFCC;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            padding-top: 10px;
        }
        
        #talk0 #talk1 #talk-up1
        {
            background-color: #F2F2F2;
            height: 20px;
            color: #000000;
            border-top-left-radius: 10px;
            padding-top: 8px;
        }
        
        
        #otherteam
        {
            width: 250px;
            position: fixed;
            left: 0px;
            top: 50px;
            z-index: 4;
            margin-top: 10px;
            margin-left: 0px;
            float: left;
            margin-bottom: 0px;
            bottom: 0px;
            height: 800px;
            font-size: small;
            -webkit-box-shadow: 1px 0px 1px #CCCCCC;
            box-shadow: 1px 0px 1px #CCCCCC;
            background-color: #FFFFFF;
        }
        #otherteam #otherteam1
        {
            background-color: #FFFFFF;
        }
        #otherteam #otherteam1 #otherteam-up
        {
            height: 20px;
            border-top-right-radius: 10px;
            background-color: #F2F2F2;
        }
        #otherteam #otherteam1 #otherteam-1-center
        {
        }
        #otherteam #otherteam2 #otherteam-2-center
        {
            padding-left: 10px;
        }
        #otherteam #otherteam2
        {
        }
        #otherteam #otherteam2 #otherteam-up2
        {
            height: 20px;
            border-top-right-radius: 10px;
            background-color: #F2F2F2;
            padding-top: 8px;
        }
        #otherteam #otherteam1 #otherteam-up1
        {
            height: 20px;
            border-top-right-radius: 10px;
            background-color: #F2F2F2;
            padding-top: 8px;
        }
        
        table.body0 .Div1
        {
            padding-top: 9px;
        }
        
        .body0 #body-3
        {
            height: auto;
            padding-left: 15px;
            margin-left: 15px;
            margin-right: 15px;
            margin-top: 10px;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #FFFFFF;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            padding-top: 10px;
            width: 94%;
        }
        .body0 #body-5
        {
            height: 15pt;
            padding-top: 10px;
        }
        .body0 #body-3 #body-4a
        {
            width: 95%;
            border-radius: 10px;
            background-color: #F2F2F2;
            height: 20px;
            padding-top: 8px;
            margin-bottom: 10px;
            text-align: center;
        }
        #talk0 #talk-out1
        {
            margin-left: 10px;
            margin-right: 10px;
            margin-top: 5px;
            -webkit-box-shadow: 0px 1px #CCCCCC;
            box-shadow: 0px 1px #CCCCCC;
            padding-left: 10px;
        }
        #talk0 #talk-out2
        {
            margin-left: 10px;
            margin-right: 10px;
            margin-top: 5px;
            -webkit-box-shadow: 0px 1px #CCCCCC;
            box-shadow: 0px 1px #CCCCCC;
            padding-left: 10px;
        }
        #talk0 #talk-up2
        {
            height: 20px;
            padding-top: 8px;
            color: #000000;
            background-color: #F2F2F2;
            margin-top: 10px;
            border-top-left-radius: 10px;
            text-align: left;
        }
    </style>
    <link href="<%= Url.CdnContent("/CSS/jquery.fileupload-ui.css") %>" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        SessionData sessionData = new SessionData();
        string LoginId = string.Empty;
        string LoginName = string.Empty;
        if (sessionData != null && sessionData.trading != null)
        {
            LoginId = sessionData.trading.LoginId;
            LoginName = sessionData.trading.UserName;
        }
        
        Step0ViewModel Model = (Step0ViewModel)ViewData["Model"];
        //if the temp leader is same as the member, will make the member has leader's role.
        if (string.Compare(Model.Leader, LoginName, true) == 0)
        {
            ViewData["IsLeader"] = true;
        }
    %>
    <script type="text/javascript">
        var LoginId = '<%=LoginId %>';
    </script>
    <table class="body0">
        <tr>
            <td>
                <div id="body1">
                    <%
                        QuickControllBarViewModel QCBAR = new QuickControllBarViewModel() { ControlMainTitle = "第1單元介紹", ControlSubTitle = "認識朋友-1", isFirstStep = true };
                        ViewData["QCBAR"] = QCBAR;
                        Html.RenderPartial("~/Views/Shared/QuickControlBar.ascx");
                        bool IsTeamMember = (bool)ViewData["IsTeamMember"];
                        bool NotTeamMember = !IsTeamMember;
                        string HideEditClass = string.Empty;
                        string HideStyle = string.Empty;
                        if (NotTeamMember)
                        {
                            HideEditClass = "hidden";
                            HideStyle = "display:none;";
                        }
                    %>
                </div>
                <div id="body-5" style="<%=HideStyle%>">
                    1. 資料填寫：<span class="right"><input type="button" id="leavetopic" value="退出議題" /></span></div>
                <div id="body2" style="<%=HideStyle%>">
                    <table width="95%" border="0" align="center">
                        <tr>
                            <td colspan="2" valign="top" bgcolor="#FFFF99">
                                1.自我介紹：
                            </td>
                            <td width="83%" bgcolor="#FFFF99">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                                &nbsp;
                            </td>
                            <td width="83%">
                                <textarea name="Description" cols="63" rows="3" id="Description"><%=Model.MyDescription %></textarea>
                            </td>
                        </tr>
                        <!--
                        <tr>
                            <td colspan="3" bgcolor="#FFFF99">
                                2. 我的隊友 (請畫出一個隊友的畫像)：
                            </td>
                        </tr>
                        <tr>
                            <td width="4%">
                                &nbsp;
                            </td>
                            <td width="13%">
                                要畫隊友：
                            </td>
                            <td width="83%">
                                <%
                                    foreach (var item in Model.TeamMembers)
                                    {
                                %>
                                <input type="radio" name="drowFor" id="drowFor" value="<%=item.Key %>">
                                <%=item.Value.UserName%>
                                <%
                                    }
                                %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                隊友圖像：
                            </td>
                            <td>
                                <form id="file_upload" runat="server">
                                <div id="filediv">
                                    <input type="file" name="Uploadfile" multiple="">
                                    <button>
                                        上傳</button>
                                    <div>
                                        檔案上傳</div>
                                </div>
                                <table id="files">
                                </table>
                                </form>
                            </td>
                        </tr>
                        -->
                        <tr>
                            <td colspan="3" bgcolor="#FFFF99">
                                2. 選擇隊長：
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                隊長人選：
                            </td>
                            <td width="83%">
                                <%
                                    foreach (var item in Model.TeamMembers)
                                    {
                                        string chkflag = (item.Value.UserSn == Model.LeaderVoteTo) ? " Checked=\"checked\"" : "";
                                %>
                                <input type="radio" name="LeaderVote" value="<%=item.Key %>" <% =chkflag %>>
                                <% =item.Value.UserName%>
                                (<span id="voteNums_<% =item.Value.UserSn %>"><% =item.Value.VoteNums %></span>)
                                <%
                                    }
                                %>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                &nbsp;
                            </td>
                            <td valign="top">
                                &nbsp;
                            </td>
                            <td align="right">
                                <input type="button" name="saveData" id="saveData" value="填寫完畢">
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="Div1">
                    2. 團隊資料展示：
                </div>
                <div id="body-3">
                    <div id="body-4a">
                        團隊成員介紹&nbsp;&nbsp;( 暫定隊長為：<span id="LeaderName"><% =Model.Leader %></span> )</div>
                    <table width="95%" border="0" align="center" id="allmember">
                        <%
                            foreach (var item in Model.TeamMembers)
                            {
                        %>
                        <tr class="<% =item.Value.UserSn %>">
                            <td width="15%" rowspan="2">
                                <%
                                string Picture = string.Empty;
                                if (!string.IsNullOrEmpty(item.Value.Picture))
                                {
                                    Picture = string.Format("<img src=\"{0}\" class=\"picimg\" />", item.Value.Picture);
                                    Response.Write(Picture);
                                }
                                %>
                            </td>
                            <td width="27%" valign="top">
                                姓名：<span class="username"><% =item.Value.UserName %></span>
                            </td>
                            <td valign="top">
                                專長領域：<span class="Profess"><% =item.Value.Professional %></span>
                            </td>
                        </tr>
                        <tr class="<% =item.Value.UserSn %>">
                            <td height="78" colspan="2" valign="top" class="descript">
                                <% =item.Value.Description.Replace("\n", "<br>") %>
                            </td>
                        </tr>
                        <%
                            }
                        %>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <%
        Step0ViewModel Model = (Step0ViewModel)ViewData["Model"];
    %>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload.js") %>"></script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload-ui.js") %>"></script>
    <script>
        var TopicSN = '<% =Model.TopicSN %>';
        TopicSN = parseInt(TopicSN, 10);
        /*global $ */
        $(function () {
            //bind event for save data.
            $('#saveData').on('click', Step0.SaveData);
            $('.next').on('click', Step0.ToStep1);
            $('#leavetopic').on('click', Step0.LeaveTopic);

            $('#file_upload').fileUploadUI({
                url: '/FileUploadService/UploadPersonIcon',
                method: 'POST',
                uploadTable: $('#files'),
                downloadTable: $('#files'),
                buildUploadRow: function (files, index) {
                    return $('<tr><td>' + files[index].name + '<\/td>' +
                            '<td class="file_upload_progress"><div><\/div><\/td>' +
                            '<td class="file_upload_cancel">' +
                            '<button class="ui-state-default ui-corner-all" title="Cancel">' +
                            '<span class="ui-icon ui-icon-cancel">Cancel<\/span>' +
                            '<\/button><\/td><\/tr>');
                },
                buildDownloadRow: function (file) {
                    return $('<tr><td>' + file.name + '<\/td><\/tr>');
                }
            });
        });

        var Step0 = {
            $Description: $('#Description'),
            $LeaderVote: $('input[name=LeaderVote]'),
            SaveData: function () {
                var voteto = $('input[name=LeaderVote]:checked');
                var descript = (Step0.$Description.val().trim().length > 0) ? Step0.$Description.val() : ' ';
                var para = { 'Descript': descript, 'LeaderVote': voteto.val(), 'TopicSN': TopicSN };
                utility.ajaxQuiet('TopicService/UpdateUnit1Description', para);
            }
            , LeaveTopic: function () {
                var para = { 'TopicSN': TopicSN };
                var cb = function (result) {
                    var rd = function () {
                        var url = utility.getRedirUrl('Home', 'Index');
                        location.href = url;
                    }
                    utility.showPopUp(result.msg, 1, rd);
                };
                var ecb = function (result) {
                    utility.showPopUp(result.msg, 1);
                };
                utility.ajaxQuiet('TopicService/LeaveTopic', para, cb, ecb);
            }
            , ToStep1: function () {
                var para = { 'TopicSN': TopicSN };
                var ecb = function (result) {
                    utility.showPopUp(result.msg, 1);
                }
                utility.ajaxQuiet('TopicService/GotoStep1', para, null, ecb);
            }
        }


    </script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/SyncInno.js") %>"></script>
</asp:Content>
