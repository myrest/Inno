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
    DDLMenu: [{
        '第1單元介紹': [
                { '認識朋友-1': 'Topic,Step0' },
                { '認識朋友-2': 'Topic,Step1' }
            ]
    },
    {
        '第2單元BEST': [
                { 'BEST分析-1': 'Topic,Best1' },
                { 'BEST分析-2': 'Topic,Best2' },
                { 'BEST分析-3': 'Topic,Best3' },
                { 'BEST分析-4': 'Topic,Best4' },
                { 'BEST分析-5': 'Topic,Best5' },
                { 'BEST分析-6': 'Topic,Best6' }
            ]
    },
    {
        '第3單元情境': [
                { '情境分析法-1': 'Scenario,Scenario1' },
                { '情境分析法-2': 'Scenario,Scenario2' },
                { '情境分析法-3': 'Scenario,Scenario3' },
                { '情境分析法-4': 'Scenario,Scenario4' },
                { '情境分析法-5': 'Scenario,Scenario5' },
                { '情境分析法-6': 'Scenario,Scenario6' },
                { '情境分析法-7': 'Scenario,Scenario7' }
            ]
    },
    {
        '第4單元作品': [
                { '設計專案成果': 'Topic,Result3' },
                { '草稿': 'Topic,Result1' },
                { '表板': 'Topic,Result2' }
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