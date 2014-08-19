<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="InnoThink.Core.MVC.Extensions" %>
<%@ Import Namespace="InnoThink.Website.Models" %>
<%@ Import Namespace="InnoThink.Domain" %>
<%@ Import Namespace="InnoThink.Core.Constancy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    情境分析法-7
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
            /*text-align: center;*/
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
        var Model = (ScenarioCharViewModel)ViewData["Model"];
        var AllMember = (List<TopicMember_Info>)ViewData["AllMember"];
        var CharModel = Model.Data;
        int UserSN = (int)ViewData["_UserSN"];
    %>
    <table class="body0 StepBody">
        <tr>
            <td>
                <div id="body1">
                    <%
                        QuickControllBarViewModel QCBAR = new QuickControllBarViewModel() { ControlMainTitle = "第3單元情境", ControlSubTitle = "情境分析法-7" };
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
                    1. 第二次情境分析法結果整理：
                </div>
                <div id="body2" style="background-color: #FFCCFF; <%=HideStyle%>">
                    <table width="95%" border="0" align="center">
                        <tr>
                            <td colspan="3" valign="top" bgcolor="#FFB7FF">1. 我的身份：
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" valign="top">
                                <span id="CurrentChar"></span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" valign="top" bgcolor="#FFB7FF">2. 我的新情境故事：
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">&nbsp;
                            </td>
                            <td valign="top">事件描述：
                            </td>
                            <td valign="top">
                                <textarea name="column2" cols="50" rows="3" id="column2" extmaxlength="4000"></textarea>
                                <input type="hidden" id="resultsn" value="0" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">&nbsp;
                            </td>
                            <td valign="top">事件圖畫：
                            </td>
                            <td valign="top">
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
                                <span id="deluploadfile"></span>
                            </td>
                        </tr>
                        <tr>
                            <td width="3%" valign="top">&nbsp;
                            </td>
                            <td width="12%" align="right" valign="top">&nbsp;
                            </td>
                            <td width="85%" align="right" valign="top">
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
                    </table>
                </div>
                <div class="Div1">
                    2. 情境分鏡描述：<span id="notice" style="background-color: rgb(255, 195, 195);" class="hidden">資料已更新</span>
                </div>
                <div id="body-3">
                    <div id="body-4a">
                        成員：
                        <%
                            //At the fist time login will using the current user for UI display.
                            foreach (var item in AllMember)
                            {
                                string strCHK = (UserSN == item.UserSN) ? "Scenario3Checked" : "";
                                Response.Write(string.Format("<span class=\"clickable Scenario3MemTab {0}\" sn=\"{1}\" />{2}</span>", strCHK, item.UserSN, item.UserName));
                            }
                        %>
                    </div>
                    <div id="body-5a">
                        <span id="CharBlock"></span>
                    </div>
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
            $('.Scenario3MemTab').on('click', Step.GetDataByUserSN);
            $('#cancle').on('click', Step.CancleUpdate);
            $('#updatebtn').on('click', Step.UpdateData);

            //$('#deleteimage').on('click', Step.DeleteImage);
            //Step.$Template = $('#itemTemplate').clone().removeClass('hidden').removeAttr('id');

            $('#file_upload').fileUploadUI({
                url: '/FileUploadService/UploadResult',
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
            Step.GetAllData3(0);
        });

        var Step = {
            $Column1: $('#column1'),
            $Column2: $('#column2'),
            $Column3: $('#column3'),
            $Column4: $('#column4'),
            SN: 0
            , ClearForm: function () {
                $('#body2 input, #body2 textarea').val('');
                $('#files').html('');
            }
            , GetDataByUserSN: function () {
                var $this = $(this);
                $('.Scenario3MemTab').removeClass('Scenario3Checked');
                $this.addClass('Scenario3Checked');
                var UserSN = $this.attr('sn');
                Step.GetAllData3(UserSN);
                Step.CancleUpdate();
            }
            , CancleUpdate: function () {
                Step.ClearForm();
                $('#btnofupdate').hide();
                $('#savebtn').show();
                $('#resultsn').val('');
                $('#deluploadfile').html('');
            }
            , UpdateData: function () {
                var para = {
                    'Column1': Step.$Column1.val()
                    , 'Column2': Step.$Column2.val()
                    , 'Column3': Step.$Column3.val()
                    , 'Column4': Step.$Column4.val()
                    , 'SN': $('#resultsn').val()
                };
                utility.ajaxQuiet('TopicService/UpdateResult', para);
                Step.CancleUpdate();
            }
            , DeleteImage: function () {
                var para = {
                    'SN': TopicSN
                };
                utility.ajaxQuiet('FileUploadService/TempDeleteBestImage', para);
                $('#deluploadfile').html('');
                $('#files').html('');
            }
            , SaveData: function () {
                var curUserSN = $('.Scenario3MemTab.Scenario3Checked').attr('sn');
                var para = {
                    'Column1': Step.$Column1.val()
                    , 'Column2': Step.$Column2.val()
                    , 'Column3': Step.$Column3.val()
                    , 'Column4': Step.$Column4.val()
                    , 'TopicSN': TopicSN
                    , 'UserSN': curUserSN
                };
                utility.ajaxQuiet('ScenarioService/Scenario7', para, null, utility.ecb);
                Step.ClearForm();
            }
            , GetDataForEdit: function () {
                var ResultSN = $(this).parent().parent().attr('sn')
                $('#resultsn').val(ResultSN);
                var para = {
                    'SN': ResultSN
                };
                var cb = function (result) {
                    var data = result.Listing[0];
                    Step.$Column2.val(data.Column2);
                    if (data.UserFileName.length > 0) {
                        $('#deluploadfile').html(data.UserFileName + ' <button id="deleteimage" class="ui-state-default ui-corner-all ui-icon ui-icon-cancel clickable" title="刪除" />');
                        $('#deleteimage').on('click', Step.DeleteImage);
                    }
                    document.location = "#";
                };
                utility.ajaxQuiet('TopicService/GetResultInfo', para, cb);
                $('#btnofupdate').show();
                $('#savebtn').hide();
                $('#files').html('');
            }
            , GetAllData3: function (UserSN) {
                var para = {
                    'TopicSN': TopicSN,
                    'UserSN': UserSN
                };
                utility.service('ScenarioService/GetAllItemList7', para, 'POST', function (data) {
                    if (data.code > 0) {
                        if (data.d != null) {
                            var objData = Array();
                            objData.push(data.info);
                            var templatepara = { 'data': objData };
                            //build member inform
                            utility.template("Scenario/Scenario2.html", function (template) {
                                $('#CharBlock').html(template.process(templatepara));
                                $('#CurrentChar').html(template.process(templatepara));
                                var templatepara3 = { 'data': data.d };
                                //build descriptions
                                utility.template("Scenario/Scenario3.html", function (template) {
                                    $('#CharBlock').append(template.process(templatepara3));
                                    //bind edit event.
                                    $('#CharBlock .edit').unbind().on('click', Step.GetDataForEdit);
                                }, "Scenario3Listing");
                            }, "ScenarioListing");
                        }
                    } else {
                        utility.showPopUp(data.msg, 1);
                    }
                });
            }
            , syncUIScenario7: function (data) {
                //check is the data is come from the same UserSN.
                var curUserSN = $('.Scenario3MemTab.Scenario3Checked').attr('sn');
                if (parseInt(data[0].usn, 10) == parseInt(curUserSN, 10)) {
                    //check sn is existing.
                    var $obj = $('#CharBlock tr[sn=' + data[0].sn + ']');
                    var templatepara = { 'data': data };
                    utility.template("Scenario/Scenario3.html", function (template) {
                        var html = template.process(templatepara);
                        //need to get the tr block for signal data
                        var $trHtml = $(html).find('tr[sn=' + data[0].sn + ']');

                        if ($obj.length > 0) {
                            $obj.html($trHtml.html());
                        } else {
                            $('#CharBlock .Scenario3List').append($trHtml);
                        }
                        $('#CharBlock .edit').unbind().on('click', Step.GetDataForEdit);
                    }, "Scenario3Listing");
                    $('#notice').show(500);
                    setTimeout(function () {
                        $('#notice').hide(500);
                    }, 3000);
                }
            }
        }
    </script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/SyncInno.js") %>"></script>
</asp:Content>