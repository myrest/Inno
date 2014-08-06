<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ Import Namespace="InnoThink.Website.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    歡迎來到 InnoThink
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
    <style type="text/css">
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
            position: absolute;
            left: 50%;
            border-radius: 20px;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            background-image: url(/pic/back-3.jpg);
            font-size: small;
            top: 65px;
        }
        #bottom0
        {
            width: 740px;
            margin-left: -370px;
            left: 50%;
            position: absolute;
            top: 870px;
            text-align: center;
            font-size: small;
            margin-bottom: 10px;
            padding-bottom: 10px;
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
        .body0 #body-2
        {
            float: left;
            width: 500px;
            height: 300px;
        }
        .body0 #body-3
        {
            float: right;
            width: 240px;
            height: 700px;
        }
        .body0 #body-4
        {
            float: left;
            width: 500px;
            height: 700px;
        }
        .body0 #body-4 #body4-1a
        {
            height: 25px;
            background-color: #F2F2F2;
            padding-top: 8px;
        }
        .body0 #body-4 #body4-1b
        {
            width: 31%;
            float: left;
            height: 150px;
            margin-bottom: 10px;
            background-color: #FFFFFF;
            margin-left: 10px;
        }
        .body0 #body-4 #body4-1c
        {
            width: 29%;
            float: left;
            background-color: #FFFFFF;
            padding-left: 10px;
            margin-left: 10px;
            padding-top: 10px;
            padding-bottom: 10px;
        }
        .body0 #body-4 #body4-1c #body-1d
        {
            height: 20px;
            background-color: #F2F2F2;
            -webkit-box-shadow: px px;
            box-shadow: px px;
            text-align: center;
            margin-right: 10px;
            padding-top: 8px;
        }
        .body0 #body-3 #body3-1a
        {
            height: 210px;
            padding-top: 10px;
            padding-right: 10px;
            padding-bottom: 10px;
            padding-left: 10px;
        }
        .body0 #body-3 #body3-2a
        {
            height: 200px;
            padding-top: 8px;
            background-color: #FFFFFF;
        }
        .body0 #body-3 #body3-3a
        {
            height: 250px;
            padding-top: 8px;
        }
        .body0 #body-3 #body3-2a #body3-2ax1
        {
            margin-left: 10px;
            margin-right: 10px;
            height: 25px;
            padding-top: 8px;
            background-color: #F2F2F2;
            border-radius: 10px;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
        }
        .body0 #body-3 #body3-3a #body3-3ax1
        {
            margin-left: 10px;
            margin-right: 10px;
            height: 25px;
            padding-top: 8px;
            background-color: #F2F2F2;
            border-radius: 10px;
            -webkit-box-shadow: 5px 5px 5px #CCCCCC;
            box-shadow: 5px 5px 5px #CCCCCC;
            margin-bottom: 10px;
        }
        body, table, p, div, span
        {
            font-size:small;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="body0">
        <div id="body1">
            歡迎來到 InnoThink
        </div>
        <div id="body-2">
            <img src="/pic/bb-0.jpg" width="500" height="300" alt="" /></div>
        <div id="body-3">
            <div id="body3-2a">
                <div id="body3-2ax1">
                    創新思維知識庫：</div>
                <table width="85%" border="0" align="center">
                    <tr>
                        <td>
                            1. 創新思維的原理
                            <img src="/pic/hot-1.png" width="37" height="14" alt="" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            2. 商業分析導論
                            <img src="/pic/hot-1.png" width="37" height="14" alt="" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            3. 產品設計基本概念
                            <img src="/pic/hot-1.png" width="37" height="14" alt="" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            4. 家具設計
                            <img src="/pic/hot-1.png" width="37" height="14" alt="" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            5. 財務分析導論
                        </td>
                    </tr>
                    <tr>
                        <td>
                            6. 市場分析教學
                        </td>
                    </tr>
                    <tr>
                        <td>
                            7. 我的第一步
                        </td>
                    </tr>
                    <tr>
                        <td>
                            8. 數位學習的方法與種類
                        </td>
                    </tr>
                </table>
            </div>
            <div id="body3-1a">
                <img src="/pic/bb-4-2teach.jpg" width="220" height="110" alt="" /><br>
                <img src="/pic/bb-4-3book.png" width="220" height="110" alt="" /></div>
            <div id="body3-3a">
                <div id="body3-3ax1">
                    會員專區：</div>
                <table width="100%" border="0">
                    <tr>
                        <td width="50%" align="center">
                            <img src="/pic/face-1.jpg" width="87" height="100" alt="" />
                        </td>
                        <td width="50%" align="center">
                            <img src="/pic/face-2.jpg" width="87" height="100" alt="" />
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" align="center">
                            <img src="/pic/face-4.jpg" width="87" height="100" alt="" />
                        </td>
                        <td width="50%" align="center">
                            <img src="/pic/face-5.jpg" width="87" height="100" alt="" />
                        </td>
                    </tr>
                </table>
            </div>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
        </div>
        <div id="body-4">
            <div id="body4-1a">
                議題專區</div>
            <div id="body4-1b">
                <img src="/pic/bb-1.jpg" width="150" height="150" alt="" /></div>
            <div id="body4-1b">
                <img src="/pic/bb-2.jpg" width="150" height="150" alt="" /></div>
            <div id="body4-1b">
                <img src="/pic/bb-3.jpg" width="150" height="150" alt="" /></div>
            <div id="body4-1c">
                <div id="body-1d">
                    目前進行中議題：</div>
                <table width="95%" border="0" align="center">
                    <tr>
                        <td>
                            1. 未來教室規劃
                        </td>
                    </tr>
                    <tr>
                        <td>
                            2. 鼎泰豐未來發展
                        </td>
                    </tr>
                    <tr>
                        <td>
                            3. 7-11未來發展
                        </td>
                    </tr>
                    <tr>
                        <td>
                            4. 三峽藍染規劃
                        </td>
                    </tr>
                    <tr>
                        <td>
                            5. 物聯網規劃
                        </td>
                    </tr>
                    <tr>
                        <td>
                            6. 服飾店開發
                        </td>
                    </tr>
                    <tr>
                        <td>
                            7. 未來書店規劃
                        </td>
                    </tr>
                </table>
            </div>
            <div id="body4-1c">
                <div id="body-1d">
                    已完成議題：</div>
                <table width="95%" border="0" align="center">
                    <tr>
                        <td>
                            1. 未來教室規劃
                        </td>
                    </tr>
                    <tr>
                        <td>
                            2. 鼎泰豐未來發展
                        </td>
                    </tr>
                    <tr>
                        <td>
                            3. 7-11未來發展
                        </td>
                    </tr>
                    <tr>
                        <td>
                            4. 三峽藍染規劃
                        </td>
                    </tr>
                    <tr>
                        <td>
                            5. 物聯網規劃
                        </td>
                    </tr>
                    <tr>
                        <td>
                            6. 服飾店開發
                        </td>
                    </tr>
                    <tr>
                        <td>
                            7. 未來書店規劃
                        </td>
                    </tr>
                </table>
            </div>
            <div id="body4-1c">
                <div id="body-1d">
                    最新發起議題：</div>
                <table width="95%" border="0" align="center">
                    <tr>
                        <td>
                            1. 未來教室規劃
                        </td>
                    </tr>
                    <tr>
                        <td>
                            2. 鼎泰豐未來發展
                        </td>
                    </tr>
                    <tr>
                        <td>
                            3. 7-11未來發展
                        </td>
                    </tr>
                    <tr>
                        <td>
                            4. 三峽藍染規劃
                        </td>
                    </tr>
                    <tr>
                        <td>
                            5. 物聯網規劃
                        </td>
                    </tr>
                    <tr>
                        <td>
                            6. 服飾店開發
                        </td>
                    </tr>
                    <tr>
                        <td>
                            7. 未來書店規劃
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
</asp:Content>
