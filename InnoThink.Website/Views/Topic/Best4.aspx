<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ Import Namespace="InnoThink.Website.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    宏觀情境分析：第一次KJ法
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
            left: 50%;
            border-radius: 20px;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            background-image: url(/pic/back-3.jpg);
            font-size: small;
            display: inline-block;
        }

        #bottom0 {
            margin-left: -370px;
            left: 50%;
            position: relative;
            text-align: center;
            font-size: small;
            margin-top: 10px;
            padding-bottom: 10px;
        }

        #talk0 #talk1 {
            margin-top: 10px;
            margin-left: 10px;
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
            padding-left: 5px;
            display: inline-block;
        }

        .body0 #body3 {
            padding-left: 5px;
            margin-left: 15px;
            margin-right: 15px;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #FFFFFF;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            display: inline-block;
            display: flex;
        }

        .body0 #body4 {
            height: 300px;
            padding-left: 10px;
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

        .body0 #body2 .bestblock {
            z-index: 0;
            float: left;
            margin-left: 15px;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #CCFFFF;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            padding-top: 10px;
            padding-left: 5px;
        }

        .body0 #body2 #best0 {
            height: 25px;
            padding-top: 10px;
            text-shadow: 0px 0px;
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

        .body0 #body3 .best-5 {
            width: 24%;
            float: left;
            margin-left: 0px;
            margin-right: 0px;
            border-radius: 30px;
            padding-left: 5px;
            padding-top: 10px;
            display: inline-block;
        }

        .body0 #body3 #best-6 {
            width: 24%;
            height: 250px;
            z-index: 1;
            float: left;
            margin-left: 0px;
            margin-right: 0px;
            border-radius: 30px;
            padding-left: 5px;
            padding-top: 10px;
            -webkit-box-shadow: px px;
            box-shadow: px px;
        }

        .body0 #body3 #best-7 {
            width: 24%;
            height: 250px;
            float: left;
            z-index: 1;
            border-radius: 30px;
            padding-left: 5px;
            padding-top: 10px;
            margin-left: 0px;
            margin-right: 0px;
            -webkit-box-shadow: px 0px;
            box-shadow: px 0px;
        }

        .body0 #body3 #best-8 {
            width: 24%;
            height: 250px;
            z-index: 1;
            float: left;
            margin-left: 0px;
            margin-right: 0px;
            border-radius: 30px;
            padding-left: 5px;
            padding-top: 10px;
            -webkit-box-shadow: px px;
            box-shadow: px px;
        }

        .body0 #body4 .best-5p {
            width: 24%;
            height: 250px;
            z-index: 1;
            float: left;
            margin-left: 0px;
            margin-right: 0px;
            border-radius: 30px;
            padding-left: 5px;
            padding-top: 10px;
            -webkit-box-shadow: px px;
            box-shadow: px px;
        }

        .body0 #body4 #best-6p {
            width: 24%;
            height: 250px;
            z-index: 1;
            float: left;
            margin-left: 0px;
            margin-right: 0px;
            border-radius: 30px;
            padding-left: 5px;
            padding-top: 10px;
            -webkit-box-shadow: px px;
            box-shadow: px px;
        }

        .body0 #body4 #best-7p {
            width: 24%;
            height: 250px;
            float: left;
            z-index: 1;
            border-radius: 30px;
            padding-left: 5px;
            padding-top: 10px;
            margin-left: 0px;
            margin-right: 0px;
            -webkit-box-shadow: px 0px;
            box-shadow: px 0px;
        }

        .body0 #body4 #best-8p {
            width: 24%;
            height: 250px;
            z-index: 1;
            float: left;
            margin-left: 0px;
            margin-right: 0px;
            border-radius: 30px;
            padding-left: 5px;
            padding-top: 10px;
            -webkit-box-shadow: px px;
            box-shadow: px px;
        }

        .body0 #body2-a {
            padding-top: 10px;
            height: 25px;
            color: #000000;
            text-shadow: 0px 0px;
        }

        .body0 #body2-b {
            height: 25px;
            padding-top: 10px;
            color: #000000;
            text-shadow: 0px 0px;
        }

        .body0 #body3 .best-5 .best-9 {
            margin-left: 5px;
            margin-right: 5px;
            border-radius: 30px;
            text-align: center;
            background-color: #F2F2F2;
        }

        .best-9 {
            padding: 5px 0px 5px 0px;
        }

        .body0 #body3 .best-5 #best-10 {
            background-color: #FFFFCC;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            margin-top: 10px;
            padding-top: 10px;
            height: 300px;
            -webkit-box-shadow: 5px 0px 5px #CCCCCC;
            box-shadow: 5px 0px 5px #CCCCCC;
            margin-left: 5px;
            margin-right: 5px;
        }

        .body0 #body3 #best-6 #best-11 {
            margin-left: 5px;
            margin-right: 5px;
            border-radius: 30px;
            text-align: center;
            padding-top: 5px;
            background-color: #F2F2F2;
        }

        .body0 #body3 #best-6 #best-12 {
            background-color: #FFFFCC;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            margin-top: 10px;
            padding-top: 10px;
            height: 300px;
            -webkit-box-shadow: 5px 0px 5px #CCCCCC;
            box-shadow: 5px 0px 5px #CCCCCC;
            margin-left: 5px;
            margin-right: 5px;
        }

        .body0 #body3 #best-7 #best-13 {
            margin-left: 5px;
            margin-right: 5px;
            border-radius: 30px;
            text-align: center;
            height: 20px;
            padding-top: 5px;
            background-color: #F2F2F2;
        }

        .body0 #body3 #best-7 #best-14 {
            background-color: #FFFFCC;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            margin-top: 10px;
            padding-top: 10px;
            height: 300px;
            -webkit-box-shadow: 5px 0px 5px #CCCCCC;
            box-shadow: 5px 0px 5px #CCCCCC;
            margin-left: 5px;
            margin-right: 5px;
        }

        .body0 #body3 #best-8 #best-15 {
            margin-left: 5px;
            margin-right: 5px;
            border-radius: 30px;
            text-align: center;
            height: 20px;
            padding-top: 5px;
            background-color: #F2F2F2;
        }

        .body0 #body3 #best-8 #best-16 {
            background-color: #FFFFCC;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            margin-top: 10px;
            padding-top: 10px;
            height: 300px;
            -webkit-box-shadow: 5px 0px 5px #CCCCCC;
            box-shadow: 5px 0px 5px #CCCCCC;
            margin-left: 5px;
            margin-right: 5px;
        }

        .body0 #body3 .best-5 .best-17 {
            background-color: #CCFFFF;
            border-top-left-radius: 10px;
            border-bottom-right-radius: 10px;
            margin-top: 10px;
            padding-top: 10px;
            padding-bottom: 5px;
            -webkit-box-shadow: 5px 0px 5px #CCCCCC;
            box-shadow: 5px 0px 5px #CCCCCC;
            margin-left: 5px;
            margin-right: 5px;
            padding-left: 5px;
            padding-right: 5px;
            text-align: center;
        }

        .body0 #body3 #best-6 #best-18 {
            background-color: #CCFFFF;
            border-top-left-radius: 10px;
            border-bottom-right-radius: 10px;
            margin-top: 10px;
            padding-top: 10px;
            height: 110px;
            -webkit-box-shadow: 5px 0px 5px #CCCCCC;
            box-shadow: 5px 0px 5px #CCCCCC;
            margin-left: 5px;
            margin-right: 5px;
            padding-left: 5px;
            padding-right: 5px;
            text-align: center;
        }

        .body0 #body3 #best-7 #best-19 {
            background-color: #CCFFFF;
            border-top-left-radius: 10px;
            border-bottom-right-radius: 10px;
            margin-top: 10px;
            padding-top: 10px;
            height: 110px;
            -webkit-box-shadow: 5px 0px 5px #CCCCCC;
            box-shadow: 5px 0px 5px #CCCCCC;
            margin-left: 5px;
            margin-right: 5px;
            padding-left: 5px;
            padding-right: 5px;
            text-align: center;
        }

        .body0 #body3 #best-8 #best-20 {
            background-color: #CCFFFF;
            border-top-left-radius: 10px;
            border-bottom-right-radius: 10px;
            margin-top: 10px;
            padding-top: 10px;
            height: 110px;
            -webkit-box-shadow: 5px 0px 5px #CCCCCC;
            box-shadow: 5px 0px 5px #CCCCCC;
            margin-left: 5px;
            margin-right: 5px;
            padding-left: 5px;
            padding-right: 5px;
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
        Best4ViewModel Model = (Best4ViewModel)ViewData["Model"];
        var BestB = Model.Listing.Where(x => x.Type == InnoThink.Domain.Constancy.BestType.B).ToList();
        var BestE = Model.Listing.Where(x => x.Type == InnoThink.Domain.Constancy.BestType.E).ToList();
        var BestS = Model.Listing.Where(x => x.Type == InnoThink.Domain.Constancy.BestType.S).ToList();
        var BestT = Model.Listing.Where(x => x.Type == InnoThink.Domain.Constancy.BestType.T).ToList();

        var GroupB = Model.GroupListing.Where(x => x.Type == InnoThink.Domain.Constancy.BestType.B).ToList();
        var GroupE = Model.GroupListing.Where(x => x.Type == InnoThink.Domain.Constancy.BestType.E).ToList();
        var GroupS = Model.GroupListing.Where(x => x.Type == InnoThink.Domain.Constancy.BestType.S).ToList();
        var GroupT = Model.GroupListing.Where(x => x.Type == InnoThink.Domain.Constancy.BestType.T).ToList();
    %>
    <table class="body0 StepBody">
        <tr>
            <td>
                <div id="body1">
                    <%
                        QuickControllBarViewModel QCBAR = new QuickControllBarViewModel() { ControlMainTitle = "宏觀情境分析", ControlSubTitle = "第一次KJ法" };
                        ViewData["QCBAR"] = QCBAR;
                        Html.RenderPartial("~/Views/Shared/QuickControlBar.ascx");
                        bool IsTeamMember = (bool)ViewData["IsTeamMember"];
                        bool NotTeamMember = !IsTeamMember;
                        string HideEditClass = string.Empty;
                        string HideStyle = string.Empty;
                        bool isClose = (bool)ViewData["IsClose"];
                        if (NotTeamMember || isClose)
                        {
                            HideEditClass = "hide";
                            HideStyle = "display:none;";
                        }
                    %>
                </div>
                <div id="body2" style="<%=HideStyle%>">
                    <div id="best0">
                        1. 整理 BEST 便條紙
                    </div>
                    <div class="bestblock">
                        <table width="85%" border="0" align="center" id="bestB">
                            <tr>
                                <td align="center">B 分類標題
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input type="text" name="groupname" value="想法" size="19" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" bgcolor="#99FFFF">分類包含內容：
                                </td>
                            </tr>
                            <%
                                foreach (var item in BestB)
                                {
                            %>
                            <tr>
                                <td valign="top">
                                    <label for="chk_<%=item.BestIdeaSN %>">
                                        <input type="checkbox" name="chkTypeB" id="chk_<%=item.BestIdeaSN %>" value="<%=item.BestIdeaSN %>" />
                                        <% =item.Idea %>(<% =item.Ranking %>)
                                    </label>
                                </td>
                            </tr>
                            <%
                                }
                            %>
                            <tr>
                                <td align="right">
                                    <input type="button" class="btnsave" value="送出分類" />
                                    <span class="spanUpdate hidden">
                                        <input type="button" class="btnUpdate" value="更新" />
                                        <input type="button" class="btnCancle" value="取消" />
                                    </span>
                                </td>
                            </tr>
                            <tr style="line-height: 4px;">
                                <td>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="bestblock">
                        <table width="85%" border="0" align="center" id="bestE">
                            <tr>
                                <td align="center">E 分類標題
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input type="text" name="groupname" value="想法" size="19" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" bgcolor="#99FFFF">分類包含內容：
                                </td>
                            </tr>
                            <%
                                foreach (var item in BestE)
                                {
                            %>
                            <tr>
                                <td valign="top">
                                    <label for="chk_<%=item.BestIdeaSN %>">
                                        <input type="checkbox" name="chkTypeE" id="chk_<%=item.BestIdeaSN %>" value="<%=item.BestIdeaSN %>" />
                                        <% =item.Idea %>(<% =item.Ranking %>)
                                    </label>
                                </td>
                            </tr>
                            <%
                                }
                            %>
                            <tr>
                                <td align="right">
                                    <input type="button" class="btnsave" value="送出分類" />
                                    <span class="spanUpdate hidden">
                                        <input type="button" class="btnUpdate" value="更新" />
                                        <input type="button" class="btnCancle" value="取消" />
                                    </span>
                                </td>
                            </tr>
                            <tr style="line-height: 4px;">
                                <td>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="bestblock">
                        <table width="85%" border="0" align="center" id="bestS">
                            <tr>
                                <td align="center">S 分類標題
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input type="text" name="groupname" value="想法" size="19">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" bgcolor="#99FFFF">分類包含內容：
                                </td>
                            </tr>
                            <%
                                foreach (var item in BestS)
                                {
                            %>
                            <tr>
                                <td valign="top">
                                    <label for="chk_<%=item.BestIdeaSN %>">
                                        <input type="checkbox" name="chkTypeS" id="chk_<%=item.BestIdeaSN %>" value="<%=item.BestIdeaSN %>" />
                                        <% =item.Idea %>(<% =item.Ranking %>)
                                    </label>
                                </td>
                            </tr>
                            <%
                                }
                            %>
                            <tr>
                                <td align="right">
                                    <input type="button" class="btnsave" value="送出分類" />
                                    <span class="spanUpdate hidden">
                                        <input type="button" class="btnUpdate" value="更新" />
                                        <input type="button" class="btnCancle" value="取消" />
                                    </span>
                                </td>
                            </tr>
                            <tr style="line-height: 4px;">
                                <td>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="bestblock">
                        <table width="85%" border="0" align="center" id="bestT">
                            <tr>
                                <td align="center">T 分類標題
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input type="text" name="groupname" value="想法" size="19" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" bgcolor="#99FFFF">分類包含內容：
                                </td>
                            </tr>
                            <%
                                foreach (var item in BestT)
                                {
                            %>
                            <tr>
                                <td valign="top">
                                    <label for="chk_<%=item.BestIdeaSN %>">
                                        <input type="checkbox" name="chkTypeT" id="chk_<%=item.BestIdeaSN %>" value="<%=item.BestIdeaSN %>" />
                                        <% =item.Idea %>(<% =item.Ranking %>)
                                    </label>
                                </td>
                            </tr>
                            <%
                                }
                            %>
                            <tr>
                                <td align="right">
                                    <input type="button" class="btnsave" value="送出分類" />
                                    <span class="spanUpdate hidden">
                                        <input type="button" class="btnUpdate" value="更新" />
                                        <input type="button" class="btnCancle" value="取消" />
                                    </span>
                                </td>
                            </tr>
                            <tr style="line-height: 4px;">
                                <td>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <!-- Template start -->
                <div id="ItemTemplate" class="best-17 hidden">
                    <table width="98%" border="0">
                        <tr>
                            <td bgcolor="#99FFFF">
                                <span class="itemNo"></span>. <span class="groupName"></span>
                                <img src="/pic/pen-1.png" class="clickable edit" width="11" height="11" alt="" sn="0"
                                    sns="" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">包含：
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- Template end-->
                <div id="body2-a">
                    2. BEST 分類結果 <span id="notice" style="background-color: rgb(255, 195, 195);" class="hidden">資料已更新</span>
                </div>
                <div id="body3">
                    <div id="resultB" class="best-5">
                        <div class="best-9">
                            B 分類結果
                        </div>
                        <%
                            int i = 0;
                            foreach (var item in GroupB)
                            {
                                i++;
                                string sns = string.Join(",", item.IdeaDetails.Select(x => x.BestIdeaSN).ToArray());
                        %>
                        <div class="best-17">
                            <table width="98%" border="0">
                                <tr>
                                    <td bgcolor="#99FFFF">
                                        <span class="itemNo">
                                            <%=i %></span>. <span class="groupName">
                                                <%=item.GroupName %></span>
                                        <img src="/pic/pen-1.png" class="clickable edit" width="11" height="11" alt="" sn="<%=item.SN %>"
                                            sns="<%=sns %>" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">包含：
                                    </td>
                                </tr>
                                <%
                                foreach (var sub in item.IdeaDetails)
                                {
                                %>
                                <tr>
                                    <td bgcolor="#FFFFCC">
                                        <%=sub.Idea %>
                                    </td>
                                </tr>
                                <%
                                }
                                %>
                            </table>
                        </div>
                        <%
                            }
                        %>
                    </div>
                    <div id="resultE" class="best-5">
                        <div class="best-9">
                            E 分類結果
                        </div>
                        <%
                            i = 0;
                            foreach (var item in GroupE)
                            {
                                i++;
                                string sns = string.Join(",", item.IdeaDetails.Select(x => x.BestIdeaSN).ToArray());
                        %>
                        <div class="best-17">
                            <table width="98%" border="0">
                                <tr>
                                    <td bgcolor="#99FFFF">
                                        <span class="itemNo">
                                            <%=i %></span>. <span class="groupName">
                                                <%=item.GroupName %></span>
                                        <img src="/pic/pen-1.png" class="clickable edit" width="11" height="11" alt="" sn="<%=item.SN %>"
                                            sns="<%=sns %>" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">包含：
                                    </td>
                                </tr>
                                <%
                                foreach (var sub in item.IdeaDetails)
                                {
                                %>
                                <tr>
                                    <td bgcolor="#FFFFCC">
                                        <%=sub.Idea %>
                                    </td>
                                </tr>
                                <%
                                }
                                %>
                            </table>
                        </div>
                        <%
                            }
                        %>
                    </div>
                    <div id="resultS" class="best-5">
                        <div class="best-9">
                            S 分類結果
                        </div>
                        <%
                            i = 0;
                            foreach (var item in GroupS)
                            {
                                i++;
                                string sns = string.Join(",", item.IdeaDetails.Select(x => x.BestIdeaSN).ToArray());
                        %>
                        <div class="best-17">
                            <table width="98%" border="0">
                                <tr>
                                    <td bgcolor="#99FFFF">
                                        <span class="itemNo">
                                            <%=i %></span>. <span class="groupName">
                                                <%=item.GroupName %></span>
                                        <img src="/pic/pen-1.png" class="clickable edit" width="11" height="11" alt="" sn="<%=item.SN %>"
                                            sns="<%=sns %>" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">包含：
                                    </td>
                                </tr>
                                <%
                                foreach (var sub in item.IdeaDetails)
                                {
                                %>
                                <tr>
                                    <td bgcolor="#FFFFCC">
                                        <%=sub.Idea %>
                                    </td>
                                </tr>
                                <%
                                }
                                %>
                            </table>
                        </div>
                        <%
                            }
                        %>
                    </div>
                    <div id="resultT" class="best-5">
                        <div class="best-9">
                            T 分類結果
                        </div>
                        <%
                            i = 0;
                            foreach (var item in GroupT)
                            {
                                i++;
                                string sns = string.Join(",", item.IdeaDetails.Select(x => x.BestIdeaSN).ToArray());
                        %>
                        <div class="best-17">
                            <table width="98%" border="0">
                                <tr>
                                    <td bgcolor="#99FFFF">
                                        <span class="itemNo">
                                            <%=i %></span>. <span class="groupName">
                                                <%=item.GroupName %></span>
                                        <img src="/pic/pen-1.png" class="clickable edit" width="11" height="11" alt="" sn="<%=item.SN %>"
                                            sns="<%=sns %>" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">包含：
                                    </td>
                                </tr>
                                <%
                                foreach (var sub in item.IdeaDetails)
                                {
                                %>
                                <tr>
                                    <td bgcolor="#FFFFCC">
                                        <%=sub.Idea %>
                                    </td>
                                </tr>
                                <%
                                }
                                %>
                            </table>
                        </div>
                        <%
                            }
                        %>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <%
        Best4ViewModel Model = (Best4ViewModel)ViewData["Model"];
    %>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload.js") %>"></script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload-ui.js") %>"></script>
    <script>
        var TopicSN = '<% =Model.TopicSN %>';
        TopicSN = parseInt(TopicSN, 10);
        /*global $ */
        $(function () {
            $('.next').on('click', Step.ToBest5);
            $('.prev').on('click', Step.ToBest3);

            $('.btnsave').on('click', Step.SaveData);
            $('.btnUpdate').on('click', Step.UpdateData);
            $('.btnCancle').on('click', Step.CancleUpdateEvent);
            $('#body2 input[name="groupname"]').on('focus', Step.CheckDefault);
            $('#body2 input[name="groupname"]').on('blur', Step.SetAsDefault);
            $('.edit').on('click', Step.GetBestData);

            Step.$Template = $('#ItemTemplate').clone().removeClass('hidden').removeAttr('id');
            $('#ItemTemplate').remove();
        });

        var Step = {
            $Template: '',
            SN: 0,
            CheckDefault: function () {
                var $this = $(this);
                if ($this.val() == '想法') {
                    $this.val('');
                }
            },
            SetAsDefault: function () {
                var $this = $(this);
                if ($this.val() == '') {
                    $this.val('想法');
                }
            },
            CancleUpdateEvent: function () {
                var $table = $(this).parent().parent().parent().parent().parent();
                Step.CancleUpdate($table);
            },
            CancleUpdate: function ($table) {
                $table.find('input[name="groupname"]').val('想法');
                $table.find('input[type="checkbox"]').prop('checked', false);
                $table.find('.btnsave').show();
                $table.find('.spanUpdate').hide();
                Step.SN = 0;
            }
            , GetBestData: function () {
                var $this = $(this);
                //Get Type
                var type = 'best' + $this.parent().parent().parent().parent().parent().parent().attr('id').substr(6, 1);
                var GroupName = $this.parent().find('.groupName').html().trim();
                var sns = $this.attr('sns').split(',');

                $('#' + type + ' .btnsave').hide();
                $('#' + type + ' .spanUpdate').show();
                $('#' + type + ' input[name="groupname"]').val(GroupName);

                $('#' + type + ' input[type="checkbox"]').prop('checked', false);
                $.each(sns, function (index, item) {
                    var $obj = $('#chk_' + item);
                    $obj.prop('checked', true);
                });
                Step.SN = $this.attr('sn');
            },
            GetPara: function ($table) {
                var type = $table.attr('id');
                var groupName = $table.find('[name="groupname"]').val();
                if (groupName == '想法') {
                    utility.showPopUp('請輸入您想要的內容。', 1);
                    return false;
                }
                if ($table.find('[type="checkbox"]:checked').length == 0) {
                    utility.showPopUp('請核選您要分類的項目。', 1);
                    return false;
                }
                var SNs = $.map($table.find('[type="checkbox"]:checked'), function (data) {
                    return $(data).val();
                });
                SNs = JSON.stringify(SNs)

                var para = {
                    'TopicSN': TopicSN
                    , 'Type': type
                    , 'GroupName': groupName
                    , 'BestIdeaSNs': SNs
                    , 'BestIdeaGroupSN': Step.SN
                };
                return para;
            }
            , SaveData: function () {
                var $table = $(this).parent().parent().parent().parent();
                var para = Step.GetPara($table);
                if (para === false) {
                    return false;
                } else {
                    utility.ajaxQuiet('TopicService/NewBestIdeaGroup', para);
                    Step.CancleUpdate($table);
                }
            }
            , UpdateData: function () {
                var $table = $(this).parent().parent().parent().parent();
                var para = Step.GetPara($table);
                if (para === false) {
                    return false;
                } else {
                    utility.ajaxQuiet('TopicService/UpdateBestIdeaGroup', para);
                    Step.CancleUpdate($table);
                }
            }
            , ToBest5: function () {
                var para = { 'TopicSN': TopicSN };
                var ecb = function (result) {
                    utility.showPopUp(result.msg, 1);
                }
                utility.ajaxQuiet('TopicService/GotoBest5', para, null, ecb);
            }
            , ToBest3: function () {
                var para = { 'TopicSN': TopicSN };
                var ecb = function (result) {
                    utility.showPopUp(result.msg, 1);
                }
                utility.ajaxQuiet('TopicService/GotoBest3', para, null, ecb);
            }
            , syncUI: function (data) {
                //check sn is existing.
                var $objtype = $('#result' + data.TypeUI);
                var $html = Step.$Template.clone();
                //Make sub items
                var subItems = '';
                $.each(data.IdeaDetails, function (index, item) {
                    var idea = item.Idea;
                    subItems += '<tr><td bgcolor="#FFFFCC">' + idea + '</td></tr>';
                });
                //Get all BestIdeaSN as string.
                var sns = $.map(data.IdeaDetails, function (obj) {
                    return obj.BestIdeaSN;
                }).join();

                $html = $html.find('.itemNO').html($objtype.find('table').length + 1).end()
                        .find('.edit').attr('sn', data.SN).end()
                        .find('.edit').attr('sns', sns).end()
                        .find('.groupName').html(data.GroupName).end();
                $html.find('table').append(subItems);
                var $obj = $objtype.find('.edit[sn=' + data.SN + ']');
                if ($obj.length > 0) {
                    var $orgobj = $obj.parent().parent().parent().parent().parent();
                    $html.find('.itemNO').html($orgobj.find('.itemNO').html().trim());
                    $obj.parent().parent().parent().parent().html($html.html());
                } else {
                    $objtype.append($html);
                }
                $objtype.find('.edit').unbind().on('click', Step.GetBestData);
                $('#notice').show(500);
                setTimeout(function () {
                    $('#notice').hide(500);
                }, 3000);

            }
        }
    </script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/SyncInno.js") %>"></script>
</asp:Content>