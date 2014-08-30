<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ Import Namespace="InnoThink.Website.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    宏觀情境分析：BEST第2次重要性分析
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
    <style type="text/css">
        .emptyLine {
            line-height: 1px;
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
            padding-left: 5px;
        }

        .body0 #body3 {
            height: 580px;
            padding-left: 5px;
            margin-left: 15px;
            margin-right: 15px;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #FFFFFF;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
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

        .body0 #body2 .importblock {
            width: 98%;
            z-index: 0;
            float: left;
            margin-right: 5px;
            margin-left: 10px;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #CCFFFF;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            padding-top: 10px;
            padding-left: 5px;
            margin-bottom: 15px;
        }

        .body0 #body2 #best2 {
            width: 47%;
            height: 200px;
            float: left;
            margin-right: 10px;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #CCFFFF;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            padding-left: 5px;
            padding-top: 10px;
            margin-left: 5px;
            margin-bottom: 15px;
        }

        .body0 #body2 #best3 {
            width: 47%;
            height: 200px;
            float: left;
            margin-left: 10px;
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
            width: 47%;
            height: 200px;
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

        .body0 #body3 #best-5 {
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
            background-color: #CCCCCC;
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
            background-color: #CCCCCC;
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
            background-color: #CCCCCC;
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
            background-color: #CCCCCC;
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
    </style>
    <link href="<%= Url.CdnContent("/CSS/jquery.fileupload-ui.css") %>" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        Best5ViewModel Model = (Best5ViewModel)ViewData["Model"];
        var BestB = Model.Listing.Where(x => x.Type == InnoThink.Domain.Constancy.BestType.B).ToList();
        var BestE = Model.Listing.Where(x => x.Type == InnoThink.Domain.Constancy.BestType.E).ToList();
        var BestS = Model.Listing.Where(x => x.Type == InnoThink.Domain.Constancy.BestType.S).ToList();
        var BestT = Model.Listing.Where(x => x.Type == InnoThink.Domain.Constancy.BestType.T).ToList();
    %>
    <table class="body0 StepBody">
        <tr>
            <td>
                <div id="body1">
                    <%
                        QuickControllBarViewModel QCBAR = new QuickControllBarViewModel() { ControlMainTitle = "宏觀情境分析", ControlSubTitle = "BEST第2次重要性分析" };
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
                <div id="body2">
                    <div id="best0">
                        1. BEST 第2次重要性分析
                    </div>
                    <table width="98%">
                        <colgroup>
                            <col width="50%" />
                            <col width="50%" />
                            <col width="50%" />
                            <col width="50%" />
                        </colgroup>
                        <tr style="vertical-align: top;">
                            <td>
                                <div class="importblock">
                                    <table width="90%" border="0" align="center">
                                        <tr>
                                            <td colspan="2" align="left" bgcolor="#99FFFF">B 重要性分析：
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="35%" align="left" valign="top">&nbsp;
                                            </td>
                                            <td width="58%" align="center" valign="top">1 最不重要← →5 最重要
                                            </td>
                                        </tr>
                                        <%
                                            var i = 0;
                                            string bgColor = "bgcolor=\"#99FFFF\"";
                                            string BtnBGColor = string.Empty;
                                            foreach (var item in BestB)
                                            {
                                                i++;
                                                string strBGColor = (i % 2 == 0) ? "" : bgColor;
                                        %>
                                        <tr>
                                            <td width="35%" align="left" valign="top" <% =strBGColor %>>
                                                <% =item.GroupName %>
                                            </td>
                                            <td align="center" valign="top" <% =strBGColor %>>
                                                <%
                                                for (int x = 1; x < 6; x++)
                                                {
                                                    string selected = (x == item.Rank) ? "checked=\"checked\"" : "";
                                                    string radiosample = "<label for=\"id{0}\"><input type=\"radio\" name=\"{1}\" id=\"id{0}\" value=\"{2}\" {3}>{2}</label>";
                                                    string radio = string.Format(radiosample, x.ToString() + item.BestIdeaGroupSN.ToString(), "idea" + item.BestIdeaGroupSN.ToString(), x, selected);
                                                    Response.Write(radio);
                                                }
                                                %>
                                            </td>
                                        </tr>
                                        <%
                                            }
                                            BtnBGColor = (i % 2 == 1) ? "" : bgColor;
                                        %>
                                        <tr>
                                            <td colspan="2" align="right" valign="top" <%=BtnBGColor %>>
                                                <input type="button" name="updatebtn" value="送　出" style="<%=HideStyle%>" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right" valign="top" class="emptyLine">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td>
                                <div class="importblock">
                                    <table width="90%" border="0" align="center">
                                        <tr>
                                            <td colspan="2" align="left" bgcolor="#99FFFF">E 重要性分析：
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="35%" align="left" valign="top">&nbsp;
                                            </td>
                                            <td width="58%" align="center" valign="top">1 最不重要← →5 最重要
                                            </td>
                                        </tr>
                                        <%
                                            i = 0;
                                            bgColor = "bgcolor=\"#99FFFF\"";
                                            BtnBGColor = string.Empty;
                                            foreach (var item in BestE)
                                            {
                                                i++;
                                                string strBGColor = (i % 2 == 0) ? "" : bgColor;
                                        %>
                                        <tr>
                                            <td width="35%" align="left" valign="top" <% =strBGColor %>>
                                                <% =item.GroupName %>
                                            </td>
                                            <td align="center" valign="top" <% =strBGColor %>>
                                                <%
                                                for (int x = 1; x < 6; x++)
                                                {
                                                    string selected = (x == item.Rank) ? "checked=\"checked\"" : "";
                                                    string radiosample = "<label for=\"id{0}\"><input type=\"radio\" name=\"{1}\" id=\"id{0}\" value=\"{2}\" {3}>{2}</label>";
                                                    string radio = string.Format(radiosample, x.ToString() + item.BestIdeaGroupSN.ToString(), "idea" + item.BestIdeaGroupSN.ToString(), x, selected);
                                                    Response.Write(radio);
                                                }
                                                %>
                                            </td>
                                        </tr>
                                        <%
                                            }
                                            BtnBGColor = (i % 2 == 1) ? "" : bgColor;
                                        %>
                                        <tr>
                                            <td colspan="2" align="right" valign="top" <%=BtnBGColor %>>
                                                <input type="button" name="updatebtn" value="送　出" style="<%=HideStyle%>" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right" valign="top" class="emptyLine">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr style="vertical-align: top;">
                            <td>
                                <div class="importblock">
                                    <table width="90%" border="0" align="center">
                                        <tr>
                                            <td colspan="2" align="left" bgcolor="#99FFFF">S 重要性分析：
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="35%" align="left" valign="top">&nbsp;
                                            </td>
                                            <td width="58%" align="center" valign="top">1 最不重要← →5 最重要
                                            </td>
                                        </tr>
                                        <%
                                            i = 0;
                                            bgColor = "bgcolor=\"#99FFFF\"";
                                            BtnBGColor = string.Empty;
                                            foreach (var item in BestS)
                                            {
                                                i++;
                                                string strBGColor = (i % 2 == 0) ? "" : bgColor;
                                        %>
                                        <tr>
                                            <td width="35%" align="left" valign="top" <% =strBGColor %>>
                                                <% =item.GroupName %>
                                            </td>
                                            <td align="center" valign="top" <% =strBGColor %>>
                                                <%
                                                for (int x = 1; x < 6; x++)
                                                {
                                                    string selected = (x == item.Rank) ? "checked=\"checked\"" : "";
                                                    string radiosample = "<label for=\"id{0}\"><input type=\"radio\" name=\"{1}\" id=\"id{0}\" value=\"{2}\" {3}>{2}</label>";
                                                    string radio = string.Format(radiosample, x.ToString() + item.BestIdeaGroupSN.ToString(), "idea" + item.BestIdeaGroupSN.ToString(), x, selected);
                                                    Response.Write(radio);
                                                }
                                                %>
                                            </td>
                                        </tr>
                                        <%
                                            }
                                            BtnBGColor = (i % 2 == 1) ? "" : bgColor;
                                        %>
                                        <tr>
                                            <td colspan="2" align="right" valign="top" <%=BtnBGColor %>>
                                                <input type="button" name="updatebtn" value="送　出" style="<%=HideStyle%>" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right" valign="top" class="emptyLine">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td>
                                <div class="importblock">
                                    <table width="90%" border="0" align="center">
                                        <tr>
                                            <td colspan="2" align="left" bgcolor="#99FFFF">T 重要性分析：
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="35%" align="left" valign="top">&nbsp;
                                            </td>
                                            <td width="58%" align="center" valign="top">1 最不重要← →5 最重要
                                            </td>
                                        </tr>
                                        <%
                                            i = 0;
                                            bgColor = "bgcolor=\"#99FFFF\"";
                                            BtnBGColor = string.Empty;
                                            foreach (var item in BestT)
                                            {
                                                i++;
                                                string strBGColor = (i % 2 == 0) ? "" : bgColor;
                                        %>
                                        <tr>
                                            <td width="35%" align="left" valign="top" <% =strBGColor %>>
                                                <% =item.GroupName %>
                                            </td>
                                            <td align="center" valign="top" <% =strBGColor %>>
                                                <%
                                                for (int x = 1; x < 6; x++)
                                                {
                                                    string selected = (x == item.Rank) ? "checked=\"checked\"" : "";
                                                    string radiosample = "<label for=\"id{0}\"><input type=\"radio\" name=\"{1}\" id=\"id{0}\" value=\"{2}\" {3}>{2}</label>";
                                                    string radio = string.Format(radiosample, x.ToString() + item.BestIdeaGroupSN.ToString(), "idea" + item.BestIdeaGroupSN.ToString(), x, selected);
                                                    Response.Write(radio);
                                                }
                                                %>
                                            </td>
                                        </tr>
                                        <%
                                            }
                                            BtnBGColor = (i % 2 == 1) ? "" : bgColor;
                                        %>
                                        <tr>
                                            <td colspan="2" align="right" valign="top" <%=BtnBGColor %>>
                                                <input type="button" name="updatebtn" value="送　出" style="<%=HideStyle%>" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right" valign="top" class="emptyLine">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <%
        Best5ViewModel Model = (Best5ViewModel)ViewData["Model"];
    %>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload.js") %>"></script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload-ui.js") %>"></script>
    <script>
        var TopicSN = '<% =Model.TopicSN %>';
        TopicSN = parseInt(TopicSN, 10);
        /*global $ */
        $(function () {
            $('.next').on('click', Step.ToBest6);
            $('.prev').on('click', Step.ToBest4);

            $('[name="updatebtn"]').on('click', Step.UpdateData);
        });

        var Step = {
            UpdateData: function () {
                var $div = $(this).parent().parent().parent().parent().parent();
                var type = $div.attr('id');
                var Ranks = $.map($div.find('[type="radio"]:checked'), function (data) {
                    var IdeaSN = $(data).attr('name').substr(4);
                    var value = $(data).val();
                    var rtn = IdeaSN + ',' + value;
                    return rtn;
                });
                Ranks = JSON.stringify(Ranks)
                var para = {
                    'Ranks': Ranks
                };
                utility.ajaxQuiet('TopicService/UpdateBestIdeaGroupRank', para);
            }
            , ToBest6: function () {
                var para = { 'TopicSN': TopicSN };
                var ecb = function (result) {
                    utility.showPopUp(result.msg, 1);
                }
                utility.ajaxQuiet('TopicService/GotoBest6', para, null, ecb);
            }
            , ToBest4: function () {
                var para = { 'TopicSN': TopicSN };
                var ecb = function (result) {
                    utility.showPopUp(result.msg, 1);
                }
                utility.ajaxQuiet('TopicService/GotoBest4', para, null, ecb);
            }
            , syncUI: function (data) {
                //check sn is existing.
                //var ItemNums =
                var $objtype = $('#BlockType' + data.TypeUI);
                var $html = Step.$Template.clone();
                $html = $html.find('.itemsn').html($objtype.length + 1).end()
                        .find('.edit').attr('sn', data.SN).end()
                        .find('.idea').html(data.Idea).end()
                        .find('.description').html(data.Description).end();
                var $obj = $objtype.find('.edit[sn=' + data.SN + ']');
                if ($obj.length > 0) {
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