<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ Import Namespace="InnoThink.Website.Models" %>
<%@ Import Namespace="InnoThink.Domain" %>
<%@ Import Namespace="InnoThink.Core.Constancy" %>
<%@ Import Namespace="InnoThink.Domain.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    角色扮演設定
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

        .body-5a {
            -webkit-box-shadow: 0px 1px #CCCCCC;
            box-shadow: 0px 1px #CCCCCC;
            width: 95%;
            margin-top: 10px;
            margin-bottom: 5px;
        }
    </style>
    <link href="<%= Url.CdnContent("/CSS/jquery.fileupload-ui.css") %>" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        ScenarioCharViewModel Model = (ScenarioCharViewModel)ViewData["Model"];
    %>
    <table class="body0 StepBody">
        <tr>
            <td>
                <div id="body1">
                    <%
                        QuickControllBarViewModel QCBAR = new QuickControllBarViewModel() { ControlMainTitle = "角色扮演設定", ControlSubTitle = "角色扮演設定" };
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
                    1. 角色扮演設定：
                </div>
                <div id="body2" style="<%=HideStyle%>">
                    <table width="95%" border="0" align="center" id="charForm">
                        <tr>
                            <td valign="top">1. 性別：
                            <input type="hidden" name="TopicSN" value="<%=Model.TopicSN %>" />
                            </td>
                            <td valign="top">
                                <input type="radio" name="Gender" value="0" <% =(Model.Data.Gender == GenderType.Male)?"checked":"" %> />
                                男性
                                <input type="radio" name="Gender" value="1" <% =(Model.Data.Gender == GenderType.Female)?"checked":"" %> />
                                女性
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" bgcolor="#FFFF99">2. 年齡：
                            </td>
                            <td valign="top" bgcolor="#FFFF99">
                                <input type="radio" name="AgeRang" value="0" <% =((int)Model.Data.AgeRang == 0)?"checked":"" %> />
                                10歲以下
                                <input type="radio" name="AgeRang" value="8" <% =((int)Model.Data.AgeRang == 8)?"checked":"" %> />
                                11~20歲
                                <input type="radio" name="AgeRang" value="9" <% =((int)Model.Data.AgeRang == 9)?"checked":"" %> />
                                21~30歲
                                <input type="radio" name="AgeRang" value="4" <% =((int)Model.Data.AgeRang == 4)?"checked":"" %> />
                                31~40 歲
                                <input type="radio" name="AgeRang" value="5" <% =((int)Model.Data.AgeRang == 5)?"checked":"" %> />
                                41~50 歲
                                <input type="radio" name="AgeRang" value="6" <% =((int)Model.Data.AgeRang == 6)?"checked":"" %> />
                                51~60 歲
                                <input type="radio" name="AgeRang" value="7" <% =((int)Model.Data.AgeRang == 7)?"checked":"" %> />
                                61 歲以上
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" bgcolor="#FFFF99" style="white-space:nowrap;">3. 教育程度：
                            </td>
                            <td valign="top" bgcolor="#FFFF99">
                                <input type="radio" name="Edu" value="0" <% =((int)Model.Data.Edu == 0)?"checked":"" %> />
                                幼稚園
                                <input type="radio" name="Edu" value="1" <% =((int)Model.Data.Edu == 1)?"checked":"" %> />
                                國小
                                <input type="radio" name="Edu" value="2" <% =((int)Model.Data.Edu == 2)?"checked":"" %> />
                                國中
                                <input type="radio" name="Edu" value="3" <% =((int)Model.Data.Edu == 3)?"checked":"" %> />
                                高中/職
                                <input type="radio" name="Edu" value="4" <% =((int)Model.Data.Edu == 4)?"checked":"" %> />
                                大專/大學
                                <input type="radio" name="Edu" value="5" <% =((int)Model.Data.Edu == 5)?"checked":"" %> />
                                研究所
                                <input type="radio" name="Edu" value="6" <% =((int)Model.Data.Edu == 6)?"checked":"" %> />
                                博士
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">4. 職業：
                            </td>
                            <td valign="top">
                                <%
                                    //The empty element must at the last one.
                                    string[] CareerArr = { "學生", "老師", "上班族", "設計師", "勞工", "公務員", "" };
                                    int CareerIndex = Array.IndexOf<string>(CareerArr, Model.Data.Career);
                                    string CareerOther = string.Empty;
                                    if (CareerIndex > -1)
                                    {
                                        CareerArr = new string[CareerArr.Length];
                                        CareerArr[CareerIndex] = "checked";
                                    }
                                    else
                                    {
                                        //Make the last element status is checked.
                                        CareerArr[CareerArr.Length - 1] = "checked";
                                        CareerOther = Model.Data.Career;
                                    }
                                %>
                                <input type="radio" name="Career" value="學生" <% =CareerArr[0]%> />
                                學生
                                <input type="radio" name="Career" value="老師" <% =CareerArr[1]%> />
                                老師
                                <input type="radio" name="Career" value="上班族" <% =CareerArr[2]%> />
                                上班族
                                <input type="radio" name="Career" value="設計師" <% =CareerArr[3]%> />
                                設計師
                                <input type="radio" name="Career" value="勞工" <% =CareerArr[4]%> />
                                勞工
                                <input type="radio" name="Career" value="公務員" <% =CareerArr[5]%> />
                                公務員
                                <input type="radio" name="Career" id="CareerOtherOption" value="" <% =CareerArr[6]%> />
                                其他：
                                <input name="CareerOther" type="text" id="CareerOther" style="width:130px;" value="<% =CareerOther%>" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">&nbsp;
                            </td>
                            <td align="right" valign="top">
                                <button id="savebtn">寫完送出</button>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="Div1">
                    2. 扮演角色資料：<span id="notice" style="background-color: rgb(255, 195, 195);" class="hidden">資料已更新</span>
                </div>
                <div id="body-3">
                    <div id="body-4a">
                        團隊成員角色扮演
                    </div>
                    <span id="CharBlock"></span>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="JSContent" runat="server">
    <%
        ScenarioCharViewModel Model = (ScenarioCharViewModel)ViewData["Model"];
    %>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload.js") %>"></script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/lib/jquery.fileupload-ui.js") %>"></script>
    <script type="text/javascript">
        var TopicSN = '<% =Model.TopicSN %>';
        TopicSN = parseInt(TopicSN, 10);
        /*global $ */
        $(function () {
            //bind event for save data.
            $('.syncInput').on('change', Step.SyncInfo);

            $('#savebtn').on('click', Step.SaveData);
            $('#CareerOther').on('focus', function () { $('#CareerOtherOption').prop('checked', true); });
            $('#PersonalityOther').on('focus', function () { $('#PersonalityOtherOption').prop('checked', true); });
            $('#deleteimage').on('click', Step.DeleteImage);

            //Step.$Template = $('#itemTemplate').clone().removeClass('hidden').removeAttr('id');

            $('#file_upload').fileUploadUI({
                url: '/FileUploadService/UploadScenario',
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
                        $('#deluploadfile').html('<button id="deleteimage" class="ui-state-default ui-corner-all ui-icon ui-icon-cancel clickable" title="刪除" />');
                        $('#deleteimage').on('click', Step.DeleteImage);
                        return $('<tr><td>' + file.fn + '(' + file.fs + ')<\/td><\/tr>');
                    } else {
                        utility.showPopUp(file.msg, 1);
                    }
                }
            });
            Step.GetAllData2();
        });

        var Step = {
            $Template: '',
            SN: 0
            , DeleteImage: function () {
                var para = {
                    'SN': TopicSN
                };
                utility.ajaxQuiet('FileUploadService/TempDeleteBestImage', para);
                $('#deluploadfile').html('');
                $('#files').html('');
            }
            , SaveData: function () {
                var para = $('#charForm input').serializeObject();
                utility.ajaxQuiet('ScenarioService/Scenario2Save', para, null, utility.ecb);
            }
            , GetAllData2: function () {
                var para = {
                    'TopicSN': TopicSN
                };
                utility.service('ScenarioService/GetAllItemList2', para, 'POST', function (data) {
                    if (data.code > 0) {
                        if (data.d != null && data.d.length > 0) {
                            var templatepara = { 'data': data.d, 'UserName': data.UserName };
                            utility.template("Scenario/Scenario2_1.html", function (template) {
                                $('#CharBlock').html(template.process(templatepara));
                            }, "ScenarioListing");
                        }
                    } else {
                        utility.showPopUp(data.msg, 1);
                    }
                });
            }
            , syncUIScenario2: function (data) {
                //check sn is existing.
                var $obj = $('#CharBlock div[sn=' + data.sn + ']');
                var test = Array();
                test.push(data);
                var templatepara = { 'data': test };
                utility.template("Scenario/Scenario2.html", function (template) {
                    var html = template.process(templatepara);
                    if ($obj.length > 0) {
                        $obj.html($(html).html());
                    } else {
                        $('#CharBlock').append(html);
                    }

                }, "ScenarioListing");
                $('#notice').show(500);
                setTimeout(function () {
                    $('#notice').hide(500);
                }, 3000);
            }
        }
    </script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/SyncInno.js") %>"></script>
</asp:Content>