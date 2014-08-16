<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ Import Namespace="InnoThink.Website.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    第1單元介紹：認識朋友-2
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
    <style type="text/css">
        #header {
            height: 50px;
            margin-left: 0px;
            margin-right: 0px;
            margin-top: 0px;
            background-color: #F2F2F2;
            z-index: 0;
        }

        body {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
        }

        #headerlogo {
            width: 150px;
            position: static;
            left: 629px;
            top: -5px;
            z-index: 2;
            float: left;
            margin-left: 0px;
        }

        #headerword {
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

        #header #headerword #header-word2 {
            padding-top: 25px;
            float: right;
        }

        .body0 {
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

        #bottom0 {
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

        #talk0 #talk1 {
            margin-top: 10px;
            margin-right: 10px;
            position: static;
            -webkit-box-shadow: 0px 0px 0px #CCCCCC;
            box-shadow: 0px 0px 0px #CCCCCC;
            width: 260px;
            border-collapse: collapse;
            margin-bottom: 0px;
        }

        #talk0 #talk2 {
            margin-left: 10px;
            margin-right: 10px;
            position: static;
            -webkit-box-shadow: 0px 0px 0px #CCCCCC;
            box-shadow: 0px 0px 0px #CCCCCC;
            width: 260px;
            border-collapse: collapse;
        }

        .body0 #body1 {
            height: 25px;
            background-color: #4FA3C7;
            border-top-left-radius: 20px;
            border-top-right-radius: 20px;
            color: #FFFFFF;
            padding-top: 8px;
            text-align: center;
        }

        .body0 #body2 {
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

        #talk0 #talk1 #talk-up1 {
            background-color: #F2F2F2;
            height: 20px;
            color: #000000;
            border-top-left-radius: 10px;
            padding-top: 8px;
        }

        #otherteam {
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

            #otherteam #otherteam1 {
                background-color: #FFFFFF;
            }

                #otherteam #otherteam1 #otherteam-up {
                    height: 20px;
                    border-top-right-radius: 10px;
                    background-color: #F2F2F2;
                }

                #otherteam #otherteam1 #otherteam-1-center {
                }

            #otherteam #otherteam2 #otherteam-2-center {
                padding-left: 10px;
            }

            #otherteam #otherteam2 {
            }

                #otherteam #otherteam2 #otherteam-up2 {
                    height: 20px;
                    border-top-right-radius: 10px;
                    background-color: #F2F2F2;
                    padding-top: 8px;
                }

            #otherteam #otherteam1 #otherteam-up1 {
                height: 20px;
                border-top-right-radius: 10px;
                background-color: #F2F2F2;
                padding-top: 8px;
            }

        table.body0 .Div1 {
            padding-top: 9px;
        }

        .body0 #body-3 {
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

        .body0 #body-5 {
            height: 15pt;
            padding-top: 10px;
        }

        .body0 #body-3 #body-4a {
            width: 95%;
            border-radius: 10px;
            background-color: #F2F2F2;
            height: 20px;
            padding-top: 8px;
            margin-bottom: 10px;
            text-align: center;
        }

        #talk0 #talk-out1 {
            margin-left: 10px;
            margin-right: 10px;
            margin-top: 5px;
            -webkit-box-shadow: 0px 1px #CCCCCC;
            box-shadow: 0px 1px #CCCCCC;
            padding-left: 10px;
        }

        #talk0 #talk-out2 {
            margin-left: 10px;
            margin-right: 10px;
            margin-top: 5px;
            -webkit-box-shadow: 0px 1px #CCCCCC;
            box-shadow: 0px 1px #CCCCCC;
            padding-left: 10px;
        }

        #talk0 #talk-up2 {
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
        Step1ViewModel Model = (Step1ViewModel)ViewData["Model"];
        string OnlyRead = Model.IsLeader ? "" : " readonly ";
    %>
    <table class="body0 step1Body">
        <tr>
            <td>
                <div id="body1">
                    <%
                        QuickControllBarViewModel QCBAR = new QuickControllBarViewModel() { ControlMainTitle = "第1單元介紹", ControlSubTitle = "認識朋友-2" };
                        ViewData["QCBAR"] = QCBAR;
                        Html.RenderPartial("~/Views/Shared/QuickControlBar.ascx");
                        bool IsTeamMember = (bool)ViewData["IsTeamMember"];
                        bool NotTeamMember = !IsTeamMember;
                        string HideEditClass = string.Empty;
                        string HideStyle = string.Empty;
                        if (NotTeamMember)
                        {
                            HideEditClass = "hide";
                            HideStyle = "display:none;";
                        }
                    %>
                </div>
                <div id="body-5" style="<%=HideStyle%>">
                    1. 資料填寫：
                </div>
                <div id="body2" style="<%=HideStyle%>">
                    <table width="95%" border="0" align="center">
                        <colgroup>
                            <col width="auto" />
                            <col width="100px" />
                            <col width="auto" />
                            <col width="auto" />
                        </colgroup>
                        <tr>
                            <td colspan="4" valign="top" bgcolor="#FFFF99">1. 隊長投票結果：
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" valign="top">
                                <table>
                                    <tr>
                                        <td valign="top">隊長人選：
                                        </td>
                                        <td>
                                            <%
                                                var leader = Model.TeamMembers.Where(x => x.Key == Model.LeaderUserSN);
                                                var leaderpic = string.Empty;
                                                if (leader.Count() > 0)
                                                {
                                                    leaderpic = leader.First().Value.Picture;
                                                }

                                            %>
                                            <img src="<% =leaderpic %>" alt="" />
                                        </td>
                                        <td>
                                            <table>
                                                <%
                                                    foreach (var item in Model.TeamMembers)
                                                    {
                                                %>
                                                <tr>
                                                    <td>
                                                        <% =item.Value.UserName %>
                                                    </td>
                                                    <td>票數：<% =item.Value.VoteNums %>票
                                                        <%
                                                        if (item.Value.UserSN == Model.LeaderUserSN)
                                                        {
                                                            Response.Write(string.Format("（恭喜{0}當選隊長!!）", item.Value.UserName));
                                                        }
                                                        Response.Write("<br /></td></tr>");
                                                    }
                                                        %>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" bgcolor="#FFFF99">2. 我的團隊：(由隊長填寫)
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td>隊名：
                            </td>
                            <td>
                                <%
                                    if (Model.IsLeader)
                                    {
                                %>
                                <input name="TeamName" type="text" id="TeamName" size="40" <% =OnlyRead %> class="syncInput"
                                    value="<% =Model.TeamName%>">
                                <%
                                    }
                                    else
                                    {
                                %>
                                <span id="TeamName">
                                    <% =Model.TeamName%></span>
                                <%
                                    }
                                %>
                            </td>
                            <td rowspan="4" style="text-align: left; vertical-align: top;">
                                <span id="teamlogo">
                                    <% =Model.LogoImage %></span>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td>議題：
                            </td>
                            <td>
                                <%
                                    if (Model.IsLeader)
                                    {
                                %>
                                <input name="Subject" type="text" id="Subject" size="40" <% =OnlyRead %> class="syncInput"
                                    value="<% =Model.Subject%>">
                                <%
                                    }
                                    else
                                    {
                                %>
                                <span id="Subject">
                                    <% =Model.Subject%></span>
                                <%
                                    }
                                %>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td>目的：
                            </td>
                            <td>
                                <%
                                    if (Model.IsLeader)
                                    {
                                %>
                                <input name="Target" type="text" id="Target" size="40" <% =OnlyRead %> class="syncInput"
                                    value="<% =Model.Target %>">
                                <%
                                    }
                                    else
                                    {
                                %>
                                <span id="Target">
                                    <% =Model.Target %></span>
                                <%
                                    }
                                %>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td>團隊 LOGO：
                            </td>
                            <td>
                                <%
                                    if (Model.IsLeader)
                                    {
                                %>
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
                                <%
                                    }
                                    else
                                    {
                                        Response.Write("&nbsp;");
                                    }
                                %>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">&nbsp;
                            </td>
                            <td valign="top">工作分配：
                            </td>
                            <td colspan="2">
                                <table>
                                    <%
                                        foreach (var item in Model.TeamMembers)
                                        {
                                            Response.Write("<tr><td align=\"right\">");
                                            Response.Write(item.Value.UserName + "：");
                                            Response.Write("</td><td>");
                                            if (Model.IsLeader)
                                            {
                                    %>
                                    <input type="text" name="HandleJob" UserSN="<% =item.Value.UserSN %>" size="40" class="syncInput"
                                        value="<% =item.Value.HandleJob %>" />
                                    <%
                                            }
                                            else
                                            {
                                    %>
                                    <span class="HandleJob" UserSN="<% =item.Value.UserSN %>">
                                        <% =item.Value.HandleJob %></span>
                                    <%
                                            }
                                    %>
                                    <%
                                            Response.Write("</td></tr>");
                                        }
                                    %>
                                </table>
                            </td>
                        </tr>
                        <%
                            if (Model.IsLeader)
                            {
                        %>
                        <tr>
                            <td valign="top">&nbsp;
                            </td>
                            <td valign="top">&nbsp;
                            </td>
                            <td colspan="2" align="right">
                                <input type="button" name="saveData" id="saveData" value="填寫完畢">
                            </td>
                        </tr>
                        <%
                            }
                        %>
                    </table>
                </div>
                <div class="Div1">
                    2. 團隊資料展示：
                </div>
                <div id="body-3">
                    <div id="body-4a">
                        團隊成員介紹
                    </div>
                    <table width="95%" border="0" align="center" id="TeamInfo">
                        <tr>
                            <td height="21">成立時間：
                            </td>
                            <td colspan="2" valign="top">
                                <span id="UIDateCreated">
                                    <% =Model.DateCreated %></span>
                            </td>
                            <td width="18%" rowspan="19" align="center" valign="top">
                                <p>
                                    <br>
                                    <span id="UIimg">
                                        <% =Model.LogoImage %></span>
                                    <br>
                                    <span id="UITeamName">
                                        <% =Model.TeamName %></span>
                                    <br>
                                    LOGO
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%">議題：
                            </td>
                            <td colspan="2" valign="top">
                                <span id="UISubject">
                                    <% =Model.Subject %></span>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%">目的：
                            </td>
                            <td colspan="2" valign="top">
                                <span id="UITarget">
                                    <% =Model.Target %></span>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%" height="9" rowspan="5">工作分配：
                            </td>
                            <td colspan="2" valign="top">
                                <span id="UIJobList">
                                    <%
                                        foreach (var item in Model.TeamMembers)
                                        {
                                            Response.Write(string.Format("{0}負責{1}<br>", item.Value.UserName, item.Value.HandleJob));
                                        }
                                    %>
                                </span>
                            </td>
                        </tr>
                    </table>
                    <table width="95%" border="0" align="center" id="allmember">
                        <%
                            foreach (var item in Model.TeamMembers)
                            {
                        %>
                        <tr class="<% =item.Value.UserSN %>">
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
                            <td width="27%" valign="top">姓名：<span class="username"><% =item.Value.UserName %></span>
                            </td>
                            <td valign="top">專長領域：<span class="Profess"><% =item.Value.Professional %></span>
                            </td>
                        </tr>
                        <tr class="<% =item.Value.UserSN %>">
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
        Step1ViewModel Model = (Step1ViewModel)ViewData["Model"];
    %>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload.js") %>"></script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload-ui.js") %>"></script>
    <script>
        var TopicSN = '<% =Model.TopicSN %>';
        TopicSN = parseInt(TopicSN, 10);
        /*global $ */
        $(function () {
            //bind event for save data.
            $('.syncInput').on('change', Step1.SyncInfo);
            $('.next').on('click', Step1.ToStep2);
            $('.prev').on('click', Step1.ToStep0);

            Utils.textBoxsOnEnter(Step1.SaveData, $('.syncInput'));
            $('#saveData').on('click', Step1.SaveData);

            $('#file_upload').fileUploadUI({
                url: '/FileUploadService/UploadTeamLogo',
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
                        $('#teamlogo').html('');
                    }
                }
            });
        });

        var Step1 = {
            $TeamName: $('#TeamName'),
            $Subject: $('#Subject'),
            $Target: $('#Target'),
            SaveData: function () {
                //make job handle
                var handlejob = $.map($('input[name="HandleJob"]'), function (data) {
                    var rtn = $(data).attr('UserSN') + ',' + $(data).val();
                    return rtn;
                });
                handlejob = JSON.stringify(handlejob)
                var para = {
                    'TopicSN': TopicSN
                    , 'TeamName': Step1.$TeamName.val()
                    , 'Subject': Step1.$Subject.val()
                    , 'Target': Step1.$Target.val()
                    , 'HandleJob_ALL': handlejob
                };
                utility.ajaxQuiet('TopicService/UpdateTopicStep1', para);
            }
            , SyncInfo: function () {
                var objectname = this.name;
                var value = $(this).val().trim();
                var objectattr = '';
                var objectattvalue = '';
                var attr = $(this).attr('UserSN');
                if (value.length > 0) {
                    if (typeof (attr) !== 'undefined' && attr !== false) {
                        objectattr = 'UserSN';
                        objectattvalue = $(this).attr('UserSN');
                    }
                    //Send to server for sync each client.
                    inno198.conn.server.syncUIInfo(TopicSN, objectname, value, objectattr, objectattvalue);
                }
            }
            , ToStep2: function () {
                var para = { 'TopicSN': TopicSN };
                var ecb = function (result) {
                    utility.showPopUp(result.msg, 1);
                }
                utility.ajaxQuiet('TopicService/GotoBest1', para, null, ecb);
            }
            , ToStep0: function () {
                var para = { 'TopicSN': TopicSN };
                var ecb = function (result) {
                    utility.showPopUp(result.msg, 1);
                }
                utility.ajaxQuiet('TopicService/GotoStep0', para, null, ecb);
            }
            , syncUI: function (topic, users) {
                $('#UIDateCreated').html(topic.DateCreated.substring(0, 10));
                $('#UISubject').html(topic.Subject);
                $('#UITarget').html(topic.Target);
                $('#UIimg').html('<image src="' + topic.LogoImg + '" />');
                $('#UITeamName').html(topic.TeamName);
                var joblist = '';
                $.each(users, function () {
                    joblist += this.Key + '負責' + this.Value + '<br>';
                });
                $('#UIJobList').html(joblist);
            }
        }
    </script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/SyncInno.js") %>"></script>
</asp:Content>