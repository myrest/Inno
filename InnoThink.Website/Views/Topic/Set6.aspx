<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ Import Namespace="InnoThink.Website.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    尋找產品機會缺口
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
    <style type="text/css">
        .right {
            float: right;
            top: -10px;
            position: relative;
            padding-right: 14px;
        }

        .description {
            display: block;
        }

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
        }

        #bottom0 {
            width: 740px;
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
            height: 370px;
            padding-left: 5px;
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
            padding-top: 10px;
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

        .body0 #body2 #best1 {
            height: 300px;
            z-index: 0;
            float: left;
            margin-right: 5px;
            margin-left: 15px;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #CCFFFF;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            padding-top: 10px;
            padding-left: 5px;
        }

        .body0 #body2 #best2 {
            width: 22%;
            height: 300px;
            float: left;
            margin-right: 5px;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #CCFFFF;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            padding-left: 5px;
            padding-top: 10px;
            margin-left: 5px;
        }

        .body0 #body2 #best3 {
            width: 22%;
            height: 300px;
            float: left;
            margin-left: 5px;
            margin-right: 5px;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #CCFFFF;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            padding-left: 5px;
            padding-top: 10px;
        }

        .body0 #body2 #best4 {
            width: 22%;
            height: 300px;
            float: left;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #CCFFFF;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            margin-left: 5px;
            margin-right: 10px;
            padding-left: 5px;
            padding-top: 10px;
        }

        #best-2p {
            height: 15px;
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

        .body0 #body3 #best-5 {
            width: 24%;
            z-index: 1;
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

        .body0 #body4 #best-5p {
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
            margin-top: 5px;
        }

        .body0 #body2-b {
            height: 25px;
            padding-top: 10px;
            color: #000000;
            text-shadow: 0px 0px;
        }

        .body0 #body3 #best-5 #best-9 {
            margin-left: 5px;
            margin-right: 5px;
            border-radius: 30px;
            text-align: center;
            padding-top: 5px;
            background-color: #F2F2F2;
        }

        .body0 #body3 #best-5 #best-10 {
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

        .body0 #body3 #best-5 #best-17 {
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

        .body0 #best-ma1 {
            margin-left: 15px;
            margin-right: 15px;
            padding-left: 10px;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #FFCCFF;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
        }

        .body0 #body-4a {
            width: 95%;
            border-radius: 10px;
            background-color: #F2F2F2;
            height: 20px;
            padding-top: 8px;
            margin-bottom: 10px;
            text-align: center;
            margin-left: 10px;
        }
    </style>
    <link href="<%= Url.CdnContent("/CSS/jquery.fileupload-ui.css") %>" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        Best6ViewModel Model = (Best6ViewModel)ViewData["Model"];
        var BestE = Model.Listing.Where(x => x.Type == InnoThink.Domain.Constancy.BestType.E).ToList();
        var BestS = Model.Listing.Where(x => x.Type == InnoThink.Domain.Constancy.BestType.S).ToList();
        var BestT = Model.Listing.Where(x => x.Type == InnoThink.Domain.Constancy.BestType.T).ToList();
    %>
    <table class="body0 StepBody">
        <tr>
            <td>
                <div id="body1">
                    <%
                        QuickControllBarViewModel QCBAR = new QuickControllBarViewModel() { ControlMainTitle = "尋找產品機會缺口", ControlSubTitle = "尋找產品機會缺口" };
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
                <div id="best-2p">
                    1. 尋找GAP<span class="right"><!-- input type="button" id="EndBest" value="結束Best分析" / --></span>
                </div>
                <div id="best-ma1">
                    <table width="95%" border="0" align="center">
                        <tr>
                            <td colspan="5" align="left">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="left">根據以下分類結果發現： (請打勾)
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <table width="95%" border="0" align="center" class="GroupTable">
                                    <tr>
                                        <td>
                                            <table width="100%" border="0" align="center">
                                                <tr>
                                                    <td align="center" bgcolor="#FFB7FF">S 分類結果
                                                    </td>
                                                </tr>
                                                <%
                                                    foreach (var item in BestS)
                                                    {
                                                        string checkboxHTML = string.Format("<input type=\"checkbox\" name=\"chkGroupName\" id=\"chk_{0}\" value=\"{0}\" />", item.BestIdeaGroupSN);
                                                %>
                                                <tr>
                                                    <td align="center">
                                                        <label for="chk_<%=item.BestIdeaGroupSN %>">
                                                            <%=checkboxHTML %>
                                                            <span><% =item.GroupName %></span>(<% =item.Ranking %>)
                                                        </label>
                                                    </td>
                                                </tr>
                                                <%
                                                    }
                                                %>
                                            </table>
                                        </td>
                                        <td>
                                            <table width="100%" border="0" align="center">
                                                <tr>
                                                    <td align="center" bgcolor="#FFB7FF">E 分類結果
                                                    </td>
                                                </tr>
                                                <%
                                                    foreach (var item in BestE)
                                                    {
                                                        string checkboxHTML = string.Format("<input type=\"checkbox\" name=\"chkGroupName\" id=\"chk_{0}\" value=\"{0}\" />", item.BestIdeaGroupSN);
                                                %>
                                                <tr>
                                                    <td align="center">
                                                        <label for="chk_<%=item.BestIdeaGroupSN %>">
                                                            <%=checkboxHTML %>
                                                            <span><% =item.GroupName %></span>(<% =item.Ranking %>)
                                                        </label>
                                                    </td>
                                                </tr>
                                                <%
                                                    }
                                                %>
                                            </table>
                                        </td>
                                        <td>
                                            <table width="100%" border="0" align="center">
                                                <tr>
                                                    <td align="center" bgcolor="#FFB7FF">T 分類結果
                                                    </td>
                                                </tr>
                                                <%
                                                    foreach (var item in BestT)
                                                    {
                                                        string checkboxHTML = string.Format("<input type=\"checkbox\" name=\"chkGroupName\" id=\"chk_{0}\" value=\"{0}\" />", item.BestIdeaGroupSN);
                                                %>
                                                <tr>
                                                    <td align="center">
                                                        <label for="chk_<%=item.BestIdeaGroupSN %>">
                                                            <%=checkboxHTML %>
                                                            <span><% =item.GroupName %></span>(<% =item.Ranking %>)
                                                        </label>
                                                    </td>
                                                </tr>
                                                <%
                                                    }
                                                %>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">&nbsp;
                            </td>
                        </tr>
                        <tr style="<%=HideStyle%>">
                            <td width="16%" align="left">1. 我的GAP：
                            </td>
                            <td width="84%" colspan="4" align="left">
                                <input type="text" id="mygap" size="40" />
                            </td>
                        </tr>
                        <tr style="<%=HideStyle%>">
                            <td>2. 說明：
                            </td>
                            <td colspan="4">
                                <textarea cols="56" rows="3" id="description"></textarea>
                            </td>
                        </tr>
                        <tr style="<%=HideStyle%>">
                            <td valign="top">3. 圖檔上傳：
                            </td>
                            <td colspan="4" valign="top">
                                <form id="file_upload" runat="server">
                                    <div id="filediv">
                                        <input type="file" name="Uploadfile" multiple="" />
                                        <button>
                                            上傳</button>
                                        <div>
                                            檔案上傳
                                        </div>
                                    </div>
                                    <table id="files">
                                    </table>
                                </form>
                                <span id="deluploadfile"></span>
                            </td>
                        </tr>
                        <tr style="<%=HideStyle%>">
                            <td colspan="5" align="right">
                                <button id="savebtn">
                                    新增</button>
                                <span id="btnofupdate" class="hidden">
                                    <button id="updatebtn">
                                        修改</button>
                                    <button id="cancle">
                                        取消</button>
                                </span>
                            </td>
                        </tr>
                        <tr style="<%=HideStyle%>">
                            <td colspan="5">&nbsp;
                            </td>
                        </tr>
                    </table>
                </div>

                <div id="body2-a">
                    2. GAP整理<span id="notice" style="background-color: rgb(255, 195, 195);" class="hidden">
                        資料已更新</span>
                </div>
                <div id="body3">
                    <div id="body-4a">
                        經由Set分析所找出的GAP
                    </div>
                    <table width="95%" border="0" align="center" id="tbitems">
                        <tr id="itemTemplate" class="hidden">
                            <td width="3%" valign="top">
                                <span class="itemsn"></span>.
                            </td>
                            <td width="18%" valign="top">
                                <img src="/pic/pen-1.png" width="11" height="11" alt="" class="edit clickable" />
                                <img src="/pic/Delete.png" width="10" height="10" alt="刪除" sn="0" settype="" class="delete clickable" />
                                <span class="category"></span>：
                            </td>
                            <td width="79%" valign="top">
                                <span class="description"></span>
                                <span class="related"></span>
                                <span class="image"></span>
                            </td>
                        </tr>
                        <%
                            int i = 0;
                            foreach (var item in Model.GAPListing)
                            {
                                i++;
                                string image = string.IsNullOrEmpty(item.Document) ? "" : string.Format("<p><img class=\"image\" src=\"{0}\" /></p>", item.Document);
                                string sns = string.Join(",", item.IdeaDetails.Select(x => x.BestIdeaGroupSN).ToArray());
                                string relate = string.Join("、", item.IdeaDetails.Select(x => x.Idea).ToArray());
                        %>
                        <tr>
                            <td width="3%" valign="top">
                                <span class="itemsn">
                                    <%=i %></span>.
                            </td>
                            <td width="18%" valign="top">
                                <img src="/pic/pen-1.png" width="11" height="11" alt="" class="edit clickable" sn="<% =item.SN %>" sns="<% =sns %>" />
                                <img src="/pic/Delete.png" width="10" height="10" alt="刪除" sn="<% =item.SN %>" class="delete clickable" />
                                <span class="category"><% =item.MyGAP %></span>：
                            </td>
                            <td width="79%" valign="top">
                                <span class="description"><% =item.Description %></span>
                                <span class="related"><% =relate %></span>
                                <% =image %>
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
        Best6ViewModel Model = (Best6ViewModel)ViewData["Model"];
    %>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload.js") %>"></script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload-ui.js") %>"></script>
    <script type="text/javascript">
        var TopicSN = '<% =Model.TopicSN %>';
        TopicSN = parseInt(TopicSN, 10);
        /*global $ */
        $(function () {
            $('#EndBest').on('click', Step.ToBestEnd);

            //bind event for save data.
            $('#savebtn').on('click', Step.SaveData);
            $('.edit').on('click', Step.GetBestData);
            $('.delete.clickable').unbind().on('click', Step.Delete);
            $('#cancle').on('click', Step.CancleUpdate);
            $('#updatebtn').on('click', Step.UpdateData);

            Step.$Template = $('#itemTemplate').clone().removeClass('hidden').removeAttr('id');

            $('#file_upload').fileUploadUI({
                url: '/FileUploadService/UploadBest6Image',
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
                        $('#deluploadfile').html('');
                        var delbtn = ' <button id="deleteimage" class="ui-state-default ui-corner-all ui-icon ui-icon-cancel clickable" title="刪除" />'
                        var tmpimg = '<img src="/Upload/_temp/' + file.tmpfn + '" />'
                        return $('<tr><td>' + tmpimg + '<br>' + file.fn + '(' + file.fs + ') ' + delbtn + '<\/td><\/tr>');
                    } else {
                        utility.showPopUp(file.msg, 1);
                    }
                }
            });
        });

        var Step = {
            $MyGAP: $('#mygap'),
            $Description: $('#description'),
            $Template: '',
            SN: 0,
            ClearForm: function () {
                Step.$Description.val('');
                Step.$MyGAP.val('');
                $('.GroupTable input[type="checkbox"]').prop('checked', false);
                $('#files').html('');
                $('#deluploadfile').html('');
                Step.SN = 0;
            }
            , CancleUpdate: function () {
                Step.ClearForm();
                $('#btnofupdate').hide();
                $('#savebtn').show();
            }
            , GetBestData: function () {
                Step.CancleUpdate();
                var $this = $(this);
                Step.SN = $this.attr('sn');
                var sns = $this.attr('sns').split(',');
                //check related check box.
                $('.GroupTable input[type="checkbox"]').prop('checked', false);
                $.each(sns, function (index, obj) {
                    $('#chk_' + obj).prop('checked', true);
                });

                //input box and textarea
                var mygap = $this.parent().parent().find('.category').html();
                var descript = $this.parent().parent().find('.description').html();
                var fullFileName = $this.parent().parent().find('.image').attr('src');
                Step.$MyGAP.val(mygap);
                Step.$Description.val(descript);

                //uploaded file
                if (fullFileName != undefined) {
                    var index = fullFileName.lastIndexOf("/") + 1;
                    var filename = fullFileName.substr(index, fullFileName.length - 4 - index);
                    $('#deluploadfile').html(filename + ' <button id="deleteimage" class="ui-state-default ui-corner-all ui-icon ui-icon-cancel clickable" title="刪除" />');
                    $('#deleteimage').on('click', Step.DeleteImage);
                }

                $('#btnofupdate').show();
                $('#savebtn').hide();
            }
            , Delete: function () {
                var $this = $(this);
                var sn = $this.attr('sn');
                utility.showPopUp('真的要刪除它嗎？', 3, function () { Step._Delete(sn); });
            }
            , _Delete: function (sn) {
                var para = {
                    'BESTSN': parseInt(sn, 10)
                };
                utility.ajaxQuiet('TopicService/DeleteGAP', para);
            },
            SyncRemoveUI: function (data) {
                var sn = data;
                $('#tbitems').find('.edit.clickable[sn=' + sn + ']').closest('tr').remove();
                $.each($('#tbitems').find('.itemsn'), function (index, obj) {
                    $(obj).html(index + 1);
                });
            }
            , UpdateData: function () {
                var para = Step.GetPara();
                utility.ajaxQuiet('TopicService/UpdateBestGAP', para);
                Step.CancleUpdate();
            }
            , DeleteImage: function () {
                var para = {
                    'SN': Step.SN
                };
                utility.ajaxQuiet('FileUploadService/TempDeleteBestImage', para);
                $('#deluploadfile').html('');
            }
            , GetPara: function () {
                var mygap = Step.$MyGAP.val().trim();
                var description = Step.$Description.val().trim();
                if (mygap == '') {
                    utility.showPopUp('請輸入[我的GAP]', 1);
                    return false;
                }
                if (description == '') {
                    utility.showPopUp('請輸入[說明]', 1);
                    return false;
                }
                if ($('.GroupTable input[type="checkbox"]:checked').length == 0) {
                    utility.showPopUp('請核選分類結果。', 1);
                    return false;
                }
                var SNs = $.map($('.GroupTable input[type="checkbox"]:checked'), function (data) {
                    return $(data).val();
                });
                SNs = JSON.stringify(SNs)

                var para = {
                    'MyGAP': Step.$MyGAP.val()
                    , 'Description': Step.$Description.val()
                    , 'SNs': SNs
                    , 'TopicSN': TopicSN
                    , 'BestGAPSN': Step.SN
                };
                return para;
            }
            , SaveData: function () {
                Step.SN = 0;
                var para = Step.GetPara();
                if (para === false) {
                    return false;
                } else {
                    utility.ajaxQuiet('TopicService/NewBestGAP', para);
                    Step.ClearForm();
                }
            }
            , ToBestEnd: function () {
                var endfun = function () {
                    var para = { 'TopicSN': TopicSN };
                    var cb = function (result) {
                        utility.showPopUp(result.msg, 1);
                    }
                    utility.ajaxQuiet('TopicService/BestEnd', para, cb, cb);
                };
                utility.showPopUp('您確定要結束Best分析法？', 3, endfun);

            }
            , syncUI: function (data) {
                var MyGAPs = Array();
                var SNs = Array();
                $.each(data.IdeaDetails, function (index, obj) {
                    MyGAPs.push(obj.Idea);
                    SNs.push(obj.BestIdeaGroupSN);
                });
                MyGAPs = MyGAPs.join('、');
                SNs = SNs.join(',');

                var $html = Step.$Template.clone();
                $html = $html.find('.itemsn').html($('#tbitems tr').length).end()
                        .find('.edit').attr('sn', data.SN).end()
                        .find('.edit').attr('sns', SNs).end()
                        .find('.category').html(data.MyGAP).end()
                        .find('.description').html(data.Description).end()
                        .find('.related').html(MyGAPs).end()
                        .find('.image').html('<img src="' + data.Document + '" />').end();
                var $obj = $('#tbitems .edit[sn=' + data.SN + ']');
                if ($obj.length > 0) {
                    var $orgobj = $obj.parent().parent();
                    $html.find('.itemsn').html($orgobj.find('.itemsn').html().trim());
                    $obj.parent().parent().html($html.html());
                } else {
                    $('#tbitems').append($html);
                }
                $('#tbitems .edit').unbind().on('click', Step.GetBestData);
                $('#notice').show(500);
                setTimeout(function () {
                    $('#notice').hide(500);
                }, 3000);
            }
        }
    </script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/SyncInno.js") %>"></script>
</asp:Content>