<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ Import Namespace="InnoThink.Website.Models" %>
<%@ Import Namespace="InnoThink.Domain.InnoThinkMain.Binding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    功能需求重要性分析
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
    <style type="text/css">
        #body-4a
        {
            width: 95%;
            border-radius: 10px;
            background-color: #F2F2F2;
            height: 20px;
            padding-top: 8px;
            margin-bottom: 10px;
            text-align: center;
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
        
        #talk0 #talk1
        {
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
            padding-left: 5px;
            height: 200px;
        }
        
        .body0 .body3
        {
            padding-left: 5px;
            margin-left: 15px;
            margin-right: 15px;
            border-top-left-radius: 30px;
            border-bottom-right-radius: 30px;
            background-color: #FFFFFF;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
        }
        
        .body0 #body4
        {
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
        
        #talk0 #talk1 #talk-up1
        {
            background-color: #F2F2F2;
            height: 20px;
            color: #000000;
            border-top-left-radius: 10px;
            padding-top: 8px;
        }
        
        .body0 #body2 #best1
        {
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
        
        .body0 #body2 #best2
        {
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
        
        .body0 #body2 #best3
        {
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
        
        .body0 #body2 #best4
        {
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
        
        .body0 #body2 #best0
        {
            height: 25px;
            padding-top: 10px;
            text-shadow: 0px 0px;
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
        
        .body0 .body3 .best-5
        {
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
        
        .body0 .body3 #best-6
        {
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
        
        .body0 .body3 #best-7
        {
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
        
        .body0 .body3 #best-8
        {
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
        
        .body0 #body4 .best-5p
        {
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
        
        .body0 #body4 #best-6p
        {
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
        
        .body0 #body4 #best-7p
        {
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
        
        .body0 #body4 #best-8p
        {
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
        
        .body0 #body2-a
        {
            padding-top: 10px;
            height: 25px;
            text-shadow: 0px 0px;
            padding-left: 6px;
        }
        
        .body0 #body2-b
        {
            height: 25px;
            padding-top: 10px;
            color: #000000;
            text-shadow: 0px 0px;
        }
        
        .body0 .body3 .best-5 .best-9
        {
            margin-left: 5px;
            margin-right: 5px;
            border-radius: 30px;
            text-align: center;
            padding-top: 5px;
            background-color: #F2F2F2;
        }
        
        .body0 .body3 .best-5 #best-10
        {
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
        
        .body0 .body3 #best-6 #best-11
        {
            margin-left: 5px;
            margin-right: 5px;
            border-radius: 30px;
            text-align: center;
            padding-top: 5px;
            background-color: #F2F2F2;
        }
        
        .body0 .body3 #best-6 #best-12
        {
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
        
        .body0 .body3 #best-7 #best-13
        {
            margin-left: 5px;
            margin-right: 5px;
            border-radius: 30px;
            text-align: center;
            height: 20px;
            padding-top: 5px;
            background-color: #F2F2F2;
        }
        
        .body0 .body3 #best-7 #best-14
        {
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
        
        .body0 .body3 #best-8 #best-15
        {
            margin-left: 5px;
            margin-right: 5px;
            border-radius: 30px;
            text-align: center;
            height: 20px;
            padding-top: 5px;
            background-color: #F2F2F2;
        }
        
        .body0 .body3 #best-8 #best-16
        {
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
        
        .body0 .body3 .best-5 .best-17
        {
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
        
        .body0 .body3 #best-6 #best-18
        {
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
        
        .body0 .body3 #best-7 #best-19
        {
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
        
        .body0 .body3 #best-8 #best-20
        {
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
        List<LikerScaleBindingView> Model = ViewData["Model"] as List<LikerScaleBindingView>;
        int TopicSN = (int)ViewData["TopicSN"];
        Response.Write(string.Format(@"<input type=""hidden"" id=""TopicSN"" value=""{0}"">", TopicSN));
    %>
    <table class="body0 StepBody">
        <tr>
            <td>
                <div id="body1">
                    <%
                        QuickControllBarViewModel QCBAR = new QuickControllBarViewModel() { ControlMainTitle = "功能需求分析", ControlSubTitle = "功能需求重要性分析" };
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
                        1. 功能需求重要性分析：
                    </div>
                    <%
                        foreach (var item in Model)
                        {
                            int CategoryId = item.CategoryType;
                    %>
                    <div id="Block<%=CategoryId %>" class="InputArea LightYellow LSSetting">
                        <table border="0" align="center">
                            <tr>
                                <td colspan="2" align="left" bgcolor="#FFFF99">
                                    <%=item.CategoryName %>：
                                </td>
                            </tr>
                            <tr>
                                <td width="35%" align="left" valign="top">
                                    &nbsp;
                                </td>
                                <td width="58%" align="center" valign="top">
                                    1 最不重要← →5 最重要
                                </td>
                            </tr>
                            <%
                            var i = 0;
                            string bgColor = "bgcolor=\"#FFFF99\"";
                            string BtnBGColor = string.Empty;
                            foreach (var subitem in item.Item)
                            {
                                i++;
                                string strBGColor = (i % 2 == 0) ? "" : bgColor;
                            %>
                            <tr>
                                <td <% =strBGColor %>>
                                    <%=subitem.ItemName %>
                                </td>
                                <td <% =strBGColor %>>
                                    <%
                                string radioName = subitem.ItemSN.ToString();
                                for (int x = 1; x < 6; x++)
                                {
                                    string selected = (x == subitem.Rank) ? "checked=\"checked\"" : "";
                                    string radioID = x.ToString() + subitem.ItemSN.ToString();
                                    string radioValue = string.Format("{0}-{1}-{2}", CategoryId, subitem.ItemSN, x);
                                    string radiosample = "<label for=\"id{0}\"><input type=\"radio\" name=\"n{1}\" id=\"id{0}\" value=\"{2}\" {4}>{3}</label>";
                                    string radio = string.Format(radiosample, radioID, radioName, radioValue, x, selected);
                                    Response.Write(radio);
                                }
                                    %>
                                </td>
                            </tr>
                            <%
                            }
                            BtnBGColor = (i % 2 == 1) ? "" : bgColor;
                            %>
                        </table>
                    </div>
                    <%
                        }
                    %>
                    <div class="align-right">
                        <input type="button" name="savebtn" value="儲存">
                    </div>
                    <div class="align-center">
                        議題 ：<% =ViewData["Subject"] %>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <script>
        var TopicSN = '<%=ViewData["TopicSN"].ToString() %>';
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload.js") %>"></script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload-ui.js") %>"></script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/SyncInno.js") %>"></script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/LikerScale/LikerScale.js") %>"></script>
</asp:Content>
