///<reference path="./lib/jquery-1.9.1-vsdoc.js" />
///<reference path="common.js" />

var Main = {
    init: function () {
        $('#JoinedTopic').on('click', Main.FirstTopic);
        $('#QuickJump').on('change', Main.ChangeWorkFlow);
        $('#headerlogo').on('click', function () { location.href = '/Home/Index'; });
        $('#otherteam-up1, #tableft').on('click', function () { $('#otherteam, #tableft').toggle('slide'); event.preventDefault(); });
        $('#talk1, #tabright').on('click', function () { $('#talk0, #tabright').toggle('slideRight'); event.preventDefault(); });
        $('#otherteam-up1').trigger('click');
        $('#talk1').trigger('click');
    },
    DDLMenu: [
    {
        '分組與初探': [
                { '自我介紹及選隊長': 'Topic,Step0' },
                { '設定隊名、議題、目的及工作分配': 'Topic,Step1' },
                { '現有市場描述及親身體驗服務': 'Analysis,Analysis1' },
                { '現有功能分析及現有需求分析': 'Analysis,Analysis2' }
            ]
    },
    {
        '宏觀情境分析': [
        //{ 'BEST分析-1': 'Topic,Best1' },由Analysis1取代
                {'BEST便條紙': 'Topic,Best2' },
                { 'BEST重要性分析': 'Topic,Best3' },
                { '第一次KJ法': 'Topic,Best4' },
                { 'BEST第2次重要性分析': 'Topic,Best5' },
                { '尋找產品機會缺口': 'Topic,Best6' }
            ]
    },
    {
        '微觀情境分析': [
        //{ '情境分析法-1': 'Scenario,Scenario1' },由Analysis2取代
                {'第一次角色扮演': 'Scenario,Scenario2' },
                { '我的情境故事': 'Scenario,Scenario3' },
                { '有價值點分析': 'Scenario,Scenario4' },
                { '情境故事重要性分析': 'Scenario,Scenario5' },
                { '第二次角色扮演': 'Scenario,Scenario6' },
                { '第二次我的情境故事': 'Scenario,Scenario7' }
            ]
    },
    {
        '功能需求分析': [
                { '新功能分析及新需求分析': 'Analysis,Analysis3' },
                { '功能需求重要性分析': 'LikerScale,LikerScale1' },
                { '?功能需求結果': 'xxx,xxxx' }
            ]
    },
    {
        '作品設計': [
                { '設計專案成果': 'Topic,Result3' },
                { '草稿設計': 'Topic,Result1' },
                { '裱版設計': 'Topic,Result2' }
            ]
    }
    ]
    , MakeDDLMenu: function () {
        var subMenuFound = false;
        $.each(Main.DDLMenu, function (index, ele) {
            var dllName = Object.keys(ele)[0];
            var checked = (CurrentPage[0] == dllName);
            $('#MainMenuDDL').append(new Option(dllName, dllName, checked, checked));
            //got the main menu setting, need to draw sub ment.
            if (checked) {
                Main.MakeSubDDLMenu(ele[dllName], CurrentPage[1]);
            }
        });
        $('#MainMenuDDL').on('change', Main.ChangeSubDDLMenu)
    }
    , MakeSubDDLMenu: function (subMenuObj, subMenuItem) {
        var subMenuFound = false;
        $.each(subMenuObj, function (index, ele) {
            var subDDLName = Object.keys(ele)[0];
            var subChk = (subMenuItem == subDDLName);
            if (subChk) { subMenuFound = true; }
            $('#QuickJump').append(new Option(subDDLName, ele[subDDLName], subChk, subChk));
        });
        if (!subMenuFound) {
            $('#QuickJump').prepend(new Option("請選擇...", "", true, true));
        }
    }
    , ChangeSubDDLMenu: function () {
        var Menu1 = $(this).val();
        var Menu2 = '';
        if (Menu1 == CurrentPage[0]) {
            Menu2 = CurrentPage[1];
        }
        $.each(Main.DDLMenu, function (index, ele) {
            var dllName = Object.keys(ele)[0];
            var checked = (Menu1 == dllName);
            if (checked) {
                $('#QuickJump').html('');
                Main.MakeSubDDLMenu(ele[dllName], Menu2);
            }
        });
    }
    , FirstTopic: function () {
        var cb = function (data) {
            location.href = data.msg;
        };
        var ecb = function (data) {
            utility.showPopUp(data.msg, 1);
        }
        utility.ajaxQuiet('TopicService/GetFirstTopic', null, cb, ecb);
    },
    ChangeWorkFlow: function () {
        var $this = $(this);
        var _topic = 0;
        if (TopicSN == undefined) {
            utility.showPopUp('您尚未進入任何一個議題', 1);
        } else {
            var arrValue = $this.val().split(',');
            if (arrValue.length != 2) {
                utility.showPopUp('[' + $this.val() + '] Format incorrect, should be controll/action', 1);
                return false;
            }
            var controll = arrValue[0];
            var action = arrValue[1];
            if ($('#AllJump:checked').length > 0) {
                var para = { 'TopicSN': TopicSN };
                var ecb = function (result) {
                    utility.showPopUp(result.msg, 1, function () { location.reload(); });
                }
                utility.ajaxQuiet(controll + 'Service/Goto' + action, para, null, ecb);
            } else {
                var url = utility.getRedirUrl(controll, action, '?TopicSN=' + TopicSN);
                location.href = url;
            }
        }
    }
};

$(function () {
    Main.init();
    if (typeof (CurrentPage) != 'undefined') {
        Main.MakeDDLMenu();
    }
    //JSON.stringify(possessList)
});