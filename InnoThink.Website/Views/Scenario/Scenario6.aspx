<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ Import Namespace="InnoThink.Website.Models" %>
<%@ Import Namespace="InnoThink.Domain" %>
<%@ Import Namespace="InnoThink.Core.Constancy" %>
<%@ Import Namespace="InnoThink.Domain.Constancy" %>
<%@ Import Namespace="InnoThink.Core.DB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    第二次角色扮演
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
                        QuickControllBarViewModel QCBAR = new QuickControllBarViewModel() { ControlMainTitle = "微觀情境分析", ControlSubTitle = "第二次角色扮演" };
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
                    1. 我的情境故事分析：
                </div>
                <div id="body2" style="<%=HideStyle%>">
                    <table width="95%" border="0" align="center" id="charForm">
                        <tr>
                            <td colspan="2" valign="top" bgcolor="#FFFF99">
                                <%
                                    List<ScenarioRankModel> RankAvg = (List<ScenarioRankModel>)ViewData["Rank"];
                                    var CharAvgRank = RankAvg.Where(x => string.IsNullOrEmpty(x.Title)).FirstOrDefault();
                                    string Avg = string.Empty;
                                    if (CharAvgRank != null)
                                    {
                                        if (CharAvgRank.Data.Count > 0)
                                        {
                                            Avg = string.Join("，", CharAvgRank.Data.Select(x => string.Format("{0}&nbsp;({1}分)", x.Key, x.Value)).ToArray());
                                        }
                                    }

                                %>
                                1. 最有價值故事：
                                <%=Avg %>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">2. 情境重要性分析結果：
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <%
                                    RankAvg.Where(x => !string.IsNullOrEmpty(x.Title)).ToList().ForEach(y =>
                                    {
                                %>
                                <div class="valuerankdiv">
                                    <table width="100%">
                                        <tr bgcolor="#FFFF99">
                                            <td>
                                                <% =y.Title %>的情境
                                            </td>
                                        </tr>
                                        <%
                                    y.Data.ForEach(z =>
                                    {
                                        %>
                                        <tr>
                                            <td>
                                                <% =string.Format("{0}&nbsp;({1}分)", z.Key, z.Value) %>
                                            </td>
                                        </tr>
                                        <%
                                    });
                                        %>
                                    </table>
                                </div>
                                <%
                                });

                                %>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">3. 選擇我的新身份：
                            </td>
                        </tr>
                        <tr>
                            <td width="13%" valign="top" bgcolor="#FFFF99">
                                <input type="hidden" name="TopicSN" value="<%=Model.TopicSN %>" />
                                1. 暱稱：
                            </td>
                            <td width="87%" valign="top" bgcolor="#FFFF99">
                                <input name="NickName" type="text" id="NickName" size="16" value="<%=Model.Data.NickName %>" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">2. 性別：
                            </td>
                            <td valign="top">
                                <input type="radio" name="Gender" value="0" <% =(Model.Data.Gender == GenderType.Male)?"checked":"" %> />
                                男性
                                <input type="radio" name="Gender" value="1" <% =(Model.Data.Gender == GenderType.Female)?"checked":"" %> />
                                女性
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" bgcolor="#FFFF99">3. 年齡：
                            </td>
                            <td valign="top" bgcolor="#FFFF99">
                                <input type="radio" name="AgeRang" value="0" <% =((int)Model.Data.AgeRang == 0)?"checked":"" %> />
                                10歲以下
                                <input type="radio" name="AgeRang" value="1" <% =((int)Model.Data.AgeRang == 1)?"checked":"" %> />
                                11~17歲
                                <input type="radio" name="AgeRang" value="2" <% =((int)Model.Data.AgeRang == 2)?"checked":"" %> />
                                18~25歲
                                <input type="radio" name="AgeRang" value="3" <% =((int)Model.Data.AgeRang == 3)?"checked":"" %> />
                                26~30 歲
                            </td>
                        </tr>
                        <tr>
                            <td valign="top"></td>
                            <td valign="top">
                                <input type="radio" name="AgeRang" value="4" <% =((int)Model.Data.AgeRang == 4)?"checked":"" %> />
                                31~40歲
                                <input type="radio" name="AgeRang" value="5" <% =((int)Model.Data.AgeRang == 5)?"checked":"" %> />
                                41~50歲
                                <input type="radio" name="AgeRang" value="6" <% =((int)Model.Data.AgeRang == 6)?"checked":"" %> />
                                51~60歲
                                <input type="radio" name="AgeRang" value="7" <% =((int)Model.Data.AgeRang == 7)?"checked":"" %> />
                                61歲以上
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" bgcolor="#FFFF99">4. 教育程度：
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
                            <td valign="top">5. 職業：
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
                                <input name="CareerOther" type="text" id="CareerOther" size="16" value="<% =CareerOther%>" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" bgcolor="#FFFF99">6. 月收入：
                                <%
                                    string[] SalaryArr = new string[8];
                                    SalaryArr[(int)Model.Data.Salary] = "checked";
                                %>
                            </td>
                            <td valign="top" bgcolor="#FFFF99">
                                <input type="radio" name="Salary" value="0" <%=SalaryArr[0] %> />
                                10,000 以下
                                <input type="radio" name="Salary" value="1" <%=SalaryArr[1] %> />
                                10,001 ~ 20,000
                                <input type="radio" name="Salary" value="2" <%=SalaryArr[2] %> />
                                20,001 ~ 30,000
                                <input type="radio" name="Salary" value="3" <%=SalaryArr[3] %> />
                                30,001 ~ 40,000
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">&nbsp;
                            </td>
                            <td valign="top">
                                <input type="radio" name="Salary" value="4" <%=SalaryArr[4] %> />
                                40,001 ~ 50,000
                                <input type="radio" name="Salary" value="5" <%=SalaryArr[5] %> />
                                50,001 ~ 60,000
                                <input type="radio" name="Salary" value="6" <%=SalaryArr[6] %> />
                                60,001 ~ 70,000
                                <input type="radio" name="Salary" value="7" <%=SalaryArr[7] %> />
                                70,001 以上
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" bgcolor="#FFFF99">7. 人格：
                                <%
                                    string[] PersonArr = { "衝動", "溫和", "穩重", "暴躁", "柔弱", "" };
                                    int PersonIndex = Array.IndexOf<string>(PersonArr, Model.Data.Personality);
                                    string PersonOther = string.Empty;
                                    if (PersonIndex > -1)
                                    {
                                        PersonArr = new string[PersonArr.Length];
                                        PersonArr[PersonIndex] = "checked";
                                    }
                                    else
                                    {
                                        PersonArr[PersonArr.Length - 1] = "checked";
                                        PersonOther = Model.Data.Personality;
                                    }
                                %>
                            </td>
                            <td valign="top" bgcolor="#FFFF99">
                                <input type="radio" name="Personality" value="衝動" <%=PersonArr[0] %> />
                                衝動
                                <input type="radio" name="Personality" value="溫和" <%=PersonArr[1] %> />
                                溫和
                                <input type="radio" name="Personality" value="穩重" <%=PersonArr[2] %> />
                                穩重
                                <input type="radio" name="Personality" value="暴躁" <%=PersonArr[3] %> />
                                暴躁
                                <input type="radio" name="Personality" value="柔弱" <%=PersonArr[4] %> />
                                柔弱
                                <input type="radio" name="Personality" id="PersonalityOtherOption" value="" <%=PersonArr[5] %> />
                                其他：
                                <input name="PersonalityOther" type="text" id="PersonalityOther" size="16" <%=PersonOther %> />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">8. 長相：
                            </td>
                            <td align="left" valign="top">
                                <form id="file_upload" runat="server">
                                    <div id="filediv">
                                        <input type="file" name="Uploadfile" multiple="" />
                                        <button>
                                            上傳</button>
                                        <div>
                                            檔案上傳
                                        </div>
                                    </div>
                                    <table id="files" style="display: inline;">
                                    </table>
                                </form>
                                <span id="deluploadfile">
                                    <%
                                        if (!string.IsNullOrEmpty(Model.Data.UserFileName))
                                        {
                                            Response.Write(string.Format("{0}<button id=\"deleteimage\" class=\"ui-state-default ui-corner-all ui-icon ui-icon-cancel clickable\" title=\"刪除\" />", Model.Data.UserFileName));
                                        }
                                    %>
                                </span>(請畫出來)
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" bgcolor="#FFFF99">&nbsp;
                            </td>
                            <td align="left" valign="top" bgcolor="#FFFF99">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">9. 我的議題：
                            </td>
                            <td align="left" valign="top">
                                <input name="Subject" type="text" id="Subject" size="40" value="<%=Model.Data.Subject %>" />
                                (該角色主要探討之情境故事議題)
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">&nbsp;
                            </td>
                            <td align="right" valign="top">
                                <button id="savebtn">
                                    寫完送出</button>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="Div1">
                    2. 扮演角色資料：<span id="notice" style="background-color: rgb(255, 195, 195);" class="hidden">資料已更新</span>
                </div>
                <div id="body-3">
                    <div id="body-4a">
                        扮演角色資料
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
                utility.ajaxQuiet('ScenarioService/Scenario6Save', para, null, utility.ecb);
            }
            , GetAllData2: function () {
                var para = {
                    'TopicSN': TopicSN
                };
                utility.service('ScenarioService/GetAllItemList6', para, 'POST', function (data) {
                    if (data.code > 0) {
                        if (data.d != null && data.d.length > 0) {
                            var templatepara = { 'data': data.d };
                            utility.template("Scenario/Scenario2.html", function (template) {
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