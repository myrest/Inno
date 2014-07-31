<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/TopicStep.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="EShopManager.Core.MVC.Extensions" %>
<%@ Import Namespace="EShopManager.Website.Models" %>
<%@ Import Namespace="EShopManager.Core.DB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    情境分析法-1
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
        #bottom0
        {
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
        #talk0 #talk1
        {
            margin-top: 10px;
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
        
        table.body0 .Div1
        {
            padding-top: 9px;
        }
        
        .body0 #body-3
        {
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
        .body0 #body-5
        {
            height: 15pt;
            padding-top: 10px;
        }
        .body0 #body-3 #body-4a
        {
            width: 95%;
            border-radius: 10px;
            background-color: #F2F2F2;
            height: 20px;
            padding-top: 8px;
            margin-bottom: 10px;
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
        ResultViewModel Model = (ResultViewModel)ViewData["Model"];
    %>
    <table class="body0 StepBody">
        <tr>
            <td>
                <div id="body1">
                    <%
                        QuickControllBarViewModel QCBAR = new QuickControllBarViewModel() { ControlMainTitle = "第3單元情境", ControlSubTitle = "情境分析法-1" };
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
                    1. 親身體驗現有服務：</div>
                <div id="body2" style="<%=HideStyle%>">
                    <table width="95%" border="0" align="center">
                        <tr>
                            <td width="13%" valign="top">
                                類別：
                            </td>
                            <td width="87%">
                                <input name="column1" type="text" id="column1" size="40" extmaxlength="15">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                說明：
                            </td>
                            <td>
                                <textarea name="column2" cols="56" rows="3" id="column2" extmaxlength="500"></textarea>
                            </td>
                        </tr>
                        <!--
                        <tr>
                            <td valign="top">
                                參考資料：
                            </td>
                            <td>
                                <input name="column3" type="text" id="column3" size="40">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                備註：
                            </td>
                            <td>
                                <input name="column4" type="text" id="column4" size="40">
                            </td>
                        </tr>
                        -->
                        <tr>
                            <td valign="top">
                                相關檔案：
                            </td>
                            <td align="left">
                                <form id="file_upload" runat="server">
                                <div id="filediv">
                                    <input type="file" name="Uploadfile" multiple="" />
                                    <button>
                                        上傳</button>
                                    <div>
                                        檔案上傳</div>
                                </div>
                                <table id="files">
                                </table>
                                </form>
                                <span id="deluploadfile"></span>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                &nbsp;
                            </td>
                            <td align="right">
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
                    2. 團隊資料展示：<span id="notice" style="background-color: rgb(255, 195, 195);" class="hidden">資料已更新</span>
                </div>
                <div id="body-3">
                    <div id="body-4a">
                        議題 ：<% =ViewData["Subject"]%></div>
                    <table width="95%" border="0" id="tbitems">
                        <!-- Data template start -->
                        <tr class="hidden" id="itemTemplate">
                            <td width="3%" valign="top">
                                <span class="itemsn"></span>.
                            </td>
                            <td width="auto" valign="top">
                                <img src="/pic/pen-1.png" width="11" height="11" alt="" class="edit clickable <%=HideEditClass%>" />
                                <span class="column1"></span>：
                            </td>
                            <td>
                                <span class="resultImage"></span>
                                <div class="column2">
                                </div>
                                <div class="column3">
                                </div>
                                <div class="column4">
                                </div>
                                <span class="resultdoc"></span>
                            </td>
                        </tr>
                        <!-- Data template end -->
                        <% 
                            int i = 0;
                            foreach (var item in Model.Listing)
                            {
                                i++;
                                string image = string.Empty;
                                string doc = string.Empty;
                                if (!string.IsNullOrEmpty(item.ServerFileName))
                                {
                                    if (item.IsImage > 0)
                                    {
                                        image = string.Format("<img src=\"{0}\" />", item.ServerFileName);
                                    }
                                    else
                                    {
                                        doc = string.Format("<a href=\"{0}\" target=\"_blank\">{1}</a>", item.ServerFileName, item.UserFileName);
                                    }
                                }
                        %>
                        <tr class="data">
                            <td width="3%" valign="top">
                                <span class="itemsn">
                                    <%=i %></span>.
                            </td>
                            <td width="20%" valign="top">
                                <img src="/pic/pen-1.png" width="11" height="11" alt="" class="edit clickable <%=HideEditClass%>"
                                    sn="<% =item.SN %>" />
                                <span class="column1">
                                    <% =item.Column1 %></span>：
                            </td>
                            <td width="auto" valign="top">
                                <span class="resultImage"><a href="<% =item.ServerFileName %>" target="_blank">
                                    <% =image %></a></span>
                                <div class="column2">
                                    <% =item.Column2 %></div>
                                <div class="column3">
                                    <% =item.Column3 %></div>
                                <div class="column4">
                                    <% =item.Column4 %></div>
                                <span class="resultdoc">
                                    <% =doc %></span>
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
        ResultViewModel Model = (ResultViewModel)ViewData["Model"];
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
            $('#tbitems .edit').on('click', Step.GetDataForEdit);
            $('#cancle').on('click', Step.CancleUpdate);
            $('#updatebtn').on('click', Step.UpdateData);

            Step.$Template = $('#itemTemplate').clone().removeClass('hidden').removeAttr('id');

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
                        $('#deluploadfile').html('');
                        return $('<tr><td>' + file.fn + '(' + file.fs + ')<\/td><\/tr>');
                    } else {
                        utility.showPopUp(file.msg, 1);
                    }
                }
            });
        });

        var Step = {
            $Column1: $('#column1'),
            $Column2: $('#column2'),
            $Column3: $('#column3'),
            $Column4: $('#column4'),
            $Template: '',
            SN: 0,
            ClearForm: function () {
                $('#body2 input, #body2 textarea').val('');
                $('#teamlogo').html('');
                $('#files').html('');
            }
            , CancleUpdate: function () {
                Step.ClearForm();
                $('#btnofupdate').hide();
                $('#savebtn').show();
                Step.SN = 0;
                $('#deluploadfile').html('');
            }
            , GetDataForEdit: function () {
                Step.SN = $(this).attr('sn');
                var para = {
                    'SN': Step.SN
                };
                var cb = function (result) {
                    var data = result.Listing[0];
                    Step.$Column1.val(data.Column1);
                    Step.$Column2.val(data.Column2);
                    Step.$Column3.val(data.Column3);
                    Step.$Column4.val(data.Column4);
                    $('#deluploadfile').html(data.UserFileName + ' <button id="deleteimage" class="ui-state-default ui-corner-all ui-icon ui-icon-cancel clickable" title="刪除" />');
                    $('#deleteimage').on('click', Step.DeleteImage);
                    document.location = "#";
                };
                utility.ajaxQuiet('TopicService/GetResultInfo', para, cb);
                $('#btnofupdate').show();
                $('#savebtn').hide();
                $('#files').html('');
            }
            , UpdateData: function () {
                var para = {
                    'Column1': Step.$Column1.val()
                    , 'Column2': Step.$Column2.val()
                    , 'Column3': Step.$Column3.val()
                    , 'Column4': Step.$Column4.val()
                    , 'SN': Step.SN
                };
                utility.ajaxQuiet('TopicService/UpdateResult', para);
                Step.CancleUpdate();
            }
            , DeleteImage: function () {
                var para = {
                    'SN': Step.SN
                };
                utility.ajaxQuiet('FileUploadService/TempDeleteBestImage', para);
                $('#deluploadfile').html('');
            }
            , SaveData: function () {
                var para = {
                    'Column1': Step.$Column1.val()
                    , 'Column2': Step.$Column2.val()
                    , 'Column3': Step.$Column3.val()
                    , 'Column4': Step.$Column4.val()
                    , 'TopicSN': TopicSN
                };
                utility.ajaxQuiet('ScenarioService/Scenario1', para, null, utility.ecb);
                Step.ClearForm();
            }
            , syncScenario1: function (data) {
                //check sn is existing.
                var $html = Step.$Template.clone();
                $html = $html.find('.itemsn').html($('#tbitems tr').length).end()
                        .find('.edit').attr('sn', data.SN).end()
                        .find('.column1').html(data.Column1).end()
                        .find('.column2').html(data.Column2).end()
                        .find('.column3').html(data.Column3).end()
                        .find('.column4').html(data.Column4).end();
                if (data.ServerFileName.length > 0) {
                    //has attached document.
                    if (data.IsImage) {
                        var img = '<a href="' + data.ServerFileName + '" target="_blank"><img src="' + data.ServerFileName + '" /></a>';
                        $html.find('.resultImage').html(img);
                    } else {
                        $html.find('.resultdoc').html('<a href="' + data.ServerFileName + '" target="_blank">' + data.UserFileName + '</a>');
                    }
                }

                var $obj = $('#tbitems .edit[sn=' + data.SN + ']');
                if ($obj.length > 0) {
                    $obj.parent().parent().html($html.html());
                } else {
                    $('#tbitems').append($html);
                }
                $('#tbitems .edit').unbind().on('click', Step.GetDataForEdit);
                $('#notice').show(500);
                setTimeout(function () {
                    $('#notice').hide(500);
                }, 3000);

            }
        }


    </script>
    <script type="text/javascript" src="<%= Url.CdnContent("/js/SyncInno.js") %>"></script>
</asp:Content>
