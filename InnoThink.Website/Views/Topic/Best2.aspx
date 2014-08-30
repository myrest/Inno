<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ Import Namespace="InnoThink.Website.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    宏觀情境分析：BEST便條紙
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
            height: 200px;
        }

        .body0 .body3 {
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
            width: 22%;
            height: 150px;
            z-index: 0;
            float: left;
            margin-right: 5px;
            margin-left: 15px;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #FFFFCC;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            padding-top: 10px;
            padding-left: 5px;
        }

        .body0 #body2 #best2 {
            width: 22%;
            height: 150px;
            float: left;
            margin-right: 5px;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #FFFFCC;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            padding-left: 5px;
            padding-top: 10px;
            margin-left: 5px;
        }

        .body0 #body2 #best3 {
            width: 22%;
            height: 150px;
            float: left;
            margin-left: 5px;
            margin-right: 5px;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #FFFFCC;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            padding-left: 5px;
            padding-top: 10px;
        }

        .body0 #body2 #best4 {
            width: 22%;
            height: 150px;
            float: left;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #FFFFCC;
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

        .body0 .body3 .best-5 {
            width: 24%;
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

        .body0 .body3 #best-6 {
            width: 24%;
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

        .body0 .body3 #best-7 {
            width: 24%;
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

        .body0 .body3 #best-8 {
            width: 24%;
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
            text-shadow: 0px 0px;
            padding-left: 6px;
        }

        .body0 #body2-b {
            height: 25px;
            padding-top: 10px;
            color: #000000;
            text-shadow: 0px 0px;
        }

        .body0 .body3 .best-5 .best-9 {
            margin-left: 5px;
            margin-right: 5px;
            border-radius: 30px;
            text-align: center;
            padding-top: 5px;
            background-color: #F2F2F2;
        }

        .body0 .body3 .best-5 #best-10 {
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

        .body0 .body3 #best-6 #best-11 {
            margin-left: 5px;
            margin-right: 5px;
            border-radius: 30px;
            text-align: center;
            padding-top: 5px;
            background-color: #F2F2F2;
        }

        .body0 .body3 #best-6 #best-12 {
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

        .body0 .body3 #best-7 #best-13 {
            margin-left: 5px;
            margin-right: 5px;
            border-radius: 30px;
            text-align: center;
            height: 20px;
            padding-top: 5px;
            background-color: #F2F2F2;
        }

        .body0 .body3 #best-7 #best-14 {
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

        .body0 .body3 #best-8 #best-15 {
            margin-left: 5px;
            margin-right: 5px;
            border-radius: 30px;
            text-align: center;
            height: 20px;
            padding-top: 5px;
            background-color: #F2F2F2;
        }

        .body0 .body3 #best-8 #best-16 {
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

        .body0 .body3 .best-5 .best-17 {
            background-color: #FFFFCC;
            border-top-left-radius: 10px;
            border-bottom-right-radius: 10px;
            margin-top: 10px;
            padding-top: 10px;
            display: block;
            -webkit-box-shadow: 5px 0px 5px #CCCCCC;
            box-shadow: 5px 0px 5px #CCCCCC;
            margin-left: 5px;
            margin-right: 5px;
            padding-left: 5px;
            padding-right: 5px;
            text-align: center;
        }

        .body0 .body3 #best-6 #best-18 {
            background-color: #FFFFCC;
            border-top-left-radius: 10px;
            border-bottom-right-radius: 10px;
            margin-top: 10px;
            padding-top: 10px;
            display: block;
            -webkit-box-shadow: 5px 0px 5px #CCCCCC;
            box-shadow: 5px 0px 5px #CCCCCC;
            margin-left: 5px;
            margin-right: 5px;
            padding-left: 5px;
            padding-right: 5px;
            text-align: center;
        }

        .body0 .body3 #best-7 #best-19 {
            background-color: #FFFFCC;
            border-top-left-radius: 10px;
            border-bottom-right-radius: 10px;
            margin-top: 10px;
            padding-top: 10px;
            display: block;
            -webkit-box-shadow: 5px 0px 5px #CCCCCC;
            box-shadow: 5px 0px 5px #CCCCCC;
            margin-left: 5px;
            margin-right: 5px;
            padding-left: 5px;
            padding-right: 5px;
            text-align: center;
        }

        .body0 .body3 #best-8 #best-20 {
            background-color: #FFFFCC;
            border-top-left-radius: 10px;
            border-bottom-right-radius: 10px;
            margin-top: 10px;
            padding-top: 10px;
            display: block;
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
        Best2ViewModel Model = (Best2ViewModel)ViewData["Model"];
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
                        QuickControllBarViewModel QCBAR = new QuickControllBarViewModel() { ControlMainTitle = "宏觀情境分析", ControlSubTitle = "BEST便條紙" };
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
                <div id="body2" style="<%=HideStyle%>">
                    <div id="best0">
                        1. BEST 便條紙
                    </div>
                    <div id="best1">
                        <table width="85%" border="0" align="center" id="TypeB">
                            <tr>
                                <td align="center">Business 商業分析
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input name="idea" type="text" value="想法" size="19">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <textarea name="description" cols="16" rows="3">說明</textarea>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <input type="button" name="savebtn" value="送出Idea">
                                    <input type="button" name="updatebtn" value="修改" class="hidden">
                                    <input type="button" name="cancle" value="取消" class="hidden">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="best2">
                        <table width="85%" border="0" align="center" id="TypeE">
                            <tr>
                                <td align="center">Economic 經濟分析
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input name="idea" type="text" value="想法" size="19">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <textarea name="description" cols="16" rows="3">說明</textarea>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <input type="button" name="savebtn" value="送出Idea">
                                    <input type="button" name="updatebtn" value="修改" class="hidden">
                                    <input type="button" name="cancle" value="取消" class="hidden">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="best3">
                        <table width="85%" border="0" align="center" id="TypeS">
                            <tr>
                                <td align="center">Society 社會分析
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input name="idea" type="text" value="想法" size="19">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <textarea name="description" cols="16" rows="3">說明</textarea>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <input type="button" name="savebtn" value="送出Idea">
                                    <input type="button" name="updatebtn" value="修改" class="hidden">
                                    <input type="button" name="cancle" value="取消" class="hidden">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="best4">
                        <table width="85%" border="0" align="center" id="TypeT">
                            <tr>
                                <td align="center">Technology 科技分析
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input name="idea" type="text" value="想法" size="19">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <textarea name="description" cols="16" rows="3">說明</textarea>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <input type="button" name="savebtn" value="送出Idea">
                                    <input type="button" name="updatebtn" value="修改" class="hidden">
                                    <input type="button" name="cancle" value="取消" class="hidden">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <p>
                        &nbsp;
                    </p>
                </div>
                <div id="body2-a">
                    2. BEST 白報紙 <span id="notice" style="background-color: rgb(255, 195, 195);" class="hidden">資料已更新</span>
                </div>
                <div class="body3">
                    <div class="best-5" id="BlockTypeB">
                        <div class="best-9">
                            B 白報紙
                        </div>
                        <div class="best-17 hidden" id="ItemTemplate">
                            <table width="98%" border="0">
                                <tr>
                                    <td align="center" bgcolor="#FFFF99">
                                        <span class="itemsn"></span>. <span class="idea"></span>
                                        <img src="/pic/pen-1.png" width="11" height="11" alt="" sn="0" class="edit clickable" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <span class="description"></span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%
                            int i = 0;
                            foreach (var item in BestB)
                            {
                                i++;
                        %>
                        <div class="best-17">
                            <table width="98%" border="0">
                                <tr>
                                    <td align="center" bgcolor="#FFFF99">
                                        <span class="itemsn">
                                            <% =i %></span>. <span class="idea">
                                                <% =item.Idea %></span>
                                        <img src="/pic/pen-1.png" width="11" height="11" alt="" sn="<% =item.SN %>" class="edit clickable" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <span class="description">
                                            <% =item.Description %></span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%
                            }
                        %>
                    </div>
                    <div class="best-5" id="BlockTypeE">
                        <div class="best-9">
                            E 白報紙
                        </div>
                        <%
                            i = 0;
                            foreach (var item in BestE)
                            {
                                i++;
                        %>
                        <div class="best-17">
                            <table width="98%" border="0">
                                <tr>
                                    <td align="center" bgcolor="#FFFF99">
                                        <span class="itemsn">
                                            <% =i %></span>. <span class="idea">
                                                <% =item.Idea %></span>
                                        <img src="/pic/pen-1.png" width="11" height="11" alt="" sn="<% =item.SN %>" class="edit clickable" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <span class="description">
                                            <% =item.Description %></span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%
                            }
                        %>
                    </div>
                    <div class="best-5" id="BlockTypeS">
                        <div class="best-9">
                            S 白報紙
                        </div>
                        <%
                            i = 0;
                            foreach (var item in BestS)
                            {
                                i++;
                        %>
                        <div class="best-17">
                            <table width="98%" border="0">
                                <tr>
                                    <td align="center" bgcolor="#FFFF99">
                                        <span class="itemsn">
                                            <% =i %></span>. <span class="idea">
                                                <% =item.Idea %></span>
                                        <img src="/pic/pen-1.png" width="11" height="11" alt="" sn="<% =item.SN %>" class="edit clickable" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <span class="description">
                                            <% =item.Description %></span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%
                            }
                        %>
                    </div>
                    <div class="best-5" id="BlockTypeT">
                        <div class="best-9">
                            T 白報紙
                        </div>
                        <%
                            i = 0;
                            foreach (var item in BestT)
                            {
                                i++;
                        %>
                        <div class="best-17">
                            <table width="98%" border="0">
                                <tr>
                                    <td align="center" bgcolor="#FFFF99">
                                        <span class="itemsn">
                                            <% =i %></span>. <span class="idea">
                                                <% =item.Idea %></span>
                                        <img src="/pic/pen-1.png" width="11" height="11" alt="" sn="<% =item.SN %>" class="edit clickable" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <span class="description">
                                            <% =item.Description %></span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%
                            }
                        %>
                    </div>
                    <!--
                <div id="body2-b">
                    3. BEST 資料庫 (快速增加BEST內容)</div>
                <div id="body4">
                    <div id="best-5p">
                        <table width="95%" border="0" align="center">
                            <tr>
                                <td colspan="2" bgcolor="#FFFF99">
                                    B資料庫
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox3" id="checkbox3">
                                    便利資源供給
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox4" id="checkbox4">
                                    跨領域
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox20" id="checkbox20">
                                    跨領域
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox" id="checkbox28">
                                    便利資源供給
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox" id="checkbox27">
                                    跨領域
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox" id="checkbox26">
                                    跨領域
                                </td>
                            </tr>
                            <tr>
                                <td width="33%">
                                    <input type="button" name="button5" id="button5" value="增加">
                                </td>
                                <td width="67%">
                                    more
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="best-6p">
                        <table width="95%" border="0" align="center">
                            <tr>
                                <td colspan="2" bgcolor="#FFFF99">
                                    E 資料庫
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox5" id="checkbox7">
                                    便利資源供給
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox5" id="checkbox8">
                                    跨領域
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox5" id="checkbox9">
                                    跨領域
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox" id="checkbox25">
                                    便利資源供給
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox" id="checkbox24">
                                    跨領域
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox" id="checkbox23">
                                    跨領域
                                </td>
                            </tr>
                            <tr>
                                <td width="33%">
                                    <input type="button" name="button7" id="button6" value="增加">
                                </td>
                                <td width="67%">
                                    more
                                </td>
                            </tr>
                        </table>
                        <p>
                            &nbsp;</p>
                        <p>
                            &nbsp;</p>
                    </div>
                    <div id="best-7p">
                        <table width="95%" border="0" align="center">
                            <tr>
                                <td colspan="2" bgcolor="#FFFF99">
                                    S 資料庫
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox6" id="checkbox12">
                                    便利資源供給
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox6" id="checkbox13">
                                    跨領域
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox6" id="checkbox14">
                                    跨領域
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox" id="checkbox10">
                                    便利資源供給
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox" id="checkbox5">
                                    跨領域
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox" id="checkbox">
                                    跨領域
                                </td>
                            </tr>
                            <tr>
                                <td width="33%">
                                    <input type="button" name="button6" id="button7" value="增加">
                                </td>
                                <td width="67%">
                                    more
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="best-8p">
                        <table width="95%" border="0" align="center">
                            <tr>
                                <td colspan="2" bgcolor="#FFFF99">
                                    T 資料庫
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox7" id="checkbox17">
                                    便利資源供給
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox7" id="checkbox18">
                                    跨領域
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox7" id="checkbox19">
                                    跨領域
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox" id="checkbox22">
                                    便利資源供給
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox" id="checkbox21">
                                    跨領域
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <input type="checkbox" name="checkbox" id="checkbox15">
                                    跨領域
                                </td>
                            </tr>
                            <tr>
                                <td width="33%">
                                    <input type="button" name="button8" id="button8" value="增加">
                                </td>
                                <td width="67%">
                                    more
                                </td>
                            </tr>
                        </table>
                    </div>
                -->
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <%
        Best2ViewModel Model = (Best2ViewModel)ViewData["Model"];
    %>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload.js") %>"></script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload-ui.js") %>"></script>
    <script>
        var TopicSN = '<% =Model.TopicSN %>';
        TopicSN = parseInt(TopicSN, 10);
        /*global $ */
        $(function () {
            $('.next').on('click', Step.ToBest3);
            $('.prev').on('click', Step.ToBest1);

            $('.edit').on('click', Step.GetBestData);
            $('[name="savebtn"]').on('click', Step.SaveData);
            $('[name="cancle"]').on('click', Step.CancleUpdate);
            $('[name="updatebtn"]').on('click', Step.UpdateData);
            $('#body2 input, #body2 textarea').on('focus', Step.CheckDefault);
            $('#body2 input, #body2 textarea').on('blur', Step.SetAsDefault);

            Step.$Template = $('#ItemTemplate').clone().removeClass('hidden').removeAttr('id');
            $('#ItemTemplate').remove();

            $('#file_upload').fileUploadUI({
                url: '/FileUploadService/UploadBest1Image',
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

        var Step = {
            $Template: '',
            SN: 0,
            CheckDefault: function () {
                var $this = $(this);
                if ($this.val() == '想法' || $this.val() == '說明') {
                    $this.val('');
                }
            },
            SetAsDefault: function () {
                var $this = $(this);
                if ($this.val() == '') {
                    var type = $this.attr('name');
                    if (type == 'idea') {
                        $this.val('想法');
                    } else {
                        $this.val('說明');
                    }
                }
            },
            ClearForm: function ($obj) {
                $obj.find('[name="idea"]').val('想法');
                $obj.find('[name="description"]').val('說明');
            }
            , CancleUpdate: function () {
                Step.ClearForm($('#body2'));
                $('[name="savebtn"]').show();
                $('[name="updatebtn"]').hide();
                $('[name="cancle"]').hide();
                Step.SN = 0;
            }
            , GetBestData: function () {
                Step.CancleUpdate();
                //Get information from UI.
                var $this = $(this).parent().parent().parent();
                Step.SN = $(this).attr('sn');
                var idea = $this.find('.idea').html().trim();
                var description = $this.find('.description').html().trim();

                //Set to the Form
                var $type = $this.parent().parent().parent();
                var typename = $type.attr('id').substr(5, 5);
                var $form = $('#' + typename);
                $form.find('[name="idea"]').val(idea);
                $form.find('[name="description"]').val(description);

                $('[name="savebtn"]').show();
                $('[name="updatebtn"]').hide();
                $('[name="cancle"]').hide();

                $form.find('[name="savebtn"]').hide();
                $form.find('[name="updatebtn"]').show();
                $form.find('[name="cancle"]').show();

            }
            , DeleteImage: function () {
                var para = {
                    'SN': Step.SN
                };
                utility.ajaxQuiet('FileUploadService/TempDeleteBestImage', para);
                $('#deluploadfile').html('');
            }
            , SaveData: function () {
                var $table = $(this).first().parent().parent().parent().parent();
                var type = $table.attr('id');
                var idea = $table.find('[name="idea"]').val();
                var description = $table.find('[name="description"]').val();
                if (idea == '想法' || description == '說明') {
                    utility.showPopUp('請輸入您想要的內容。', 1);
                    return;
                }
                var para = {
                    'TopicSN': TopicSN
                    , 'Type': type
                    , 'Idea': idea
                    , 'Description': description
                };
                utility.ajaxQuiet('TopicService/NewBestIdea', para);
                Step.ClearForm($table);
            }
            , UpdateData: function () {
                var $table = $(this).first().parent().parent().parent().parent();
                var idea = $table.find('[name="idea"]').val();
                var description = $table.find('[name="description"]').val();
                if (idea == '想法' || description == '說明') {
                    utility.showPopUp('請輸入您想要的內容。', 1);
                    return;
                }
                var para = {
                    'SN': Step.SN
                    , 'Idea': idea
                    , 'Description': description
                };
                utility.ajaxQuiet('TopicService/UpdateBestIdea', para);
                Step.CancleUpdate();
            }
            , ToBest1: function () {
                var para = { 'TopicSN': TopicSN };
                var ecb = function (result) {
                    utility.showPopUp(result.msg, 1);
                }
                utility.ajaxQuiet('TopicService/GotoBest1', para, null, ecb);
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
                //var ItemNums =
                var $objtype = $('#BlockType' + data.TypeUI);
                var objLength = $objtype.find('table').length + 1;
                var $html = Step.$Template.clone();
                $html = $html.find('.itemsn').html(objLength).end()
                        .find('.edit').attr('sn', data.SN).end()
                        .find('.idea').html(data.Idea).end()
                        .find('.description').html(data.Description).end();
                var $obj = $objtype.find('.edit[sn=' + data.SN + ']');
                if ($obj.length > 0) {
                    var _sn = $obj.parent().parent().parent().parent().find('.itemsn').first().html();
                    $html.find('.itemsn').html(_sn);
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