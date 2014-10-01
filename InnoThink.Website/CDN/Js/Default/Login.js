var HomeControl = 'Home';
var HomeAction = 'Index';

$(function () {
    if (top.location != self.location) {
        top.location = self.location;
    } else {
        login.init();
        Utils.textBoxsOnEnter(login._login, $('#headeridpass input'));
        Utils.textBoxsOnEnter(login._Reg, $('#body9 input'));
    }
    $.ajaxSetup({ cache: true });

    $.getScript('//connect.facebook.net/zh_TW/all.js', function () {
        FB.init({
            appId: '1465486540390678',
            xfbml: true,  // parse XFBML
            version: 'v2.0'
        });
        $('#loginbutton,#feedbutton').removeAttr('disabled');
    });

});

var login =
{
    $RegNewOne: $('#btnRegNewOne'),
    $ToLoginPanel: $('#ToLoginPanel'),
    init: function () {
        $("#btnLogin").click(this._login);
        login.$RegNewOne.click(this._Reg);

        $("#username").focus();
        var _u = $.query.get('u').toString();
        if (_u.length > 0) {
            $("#username").val(_u);
            $("#password").focus();
        }

        $("#dialog-message").dialog({
            autoOpen: true,
            modal: true,
            buttons: {
                Ok: function () {
                    $(this).dialog("close");
                }
            }
        });
    },
    _login: function () {
        var id = $("#username").val();
        var pwd = $("#password").val();
        var vy = $("#verify").val();

        if (id.length === 0) {
            utility.showPopUp('請輸入帳號', 1, function () { $("#username").focus(); });
        }
        else if (pwd.length === 0) {
            utility.showPopUp('請輸入密碼', 1, function () { $("#password").focus(); });
        }
        else {
            var param = { username: id, password: pwd, verify: vy };
            utility.service("LoginService/Login", param, "POST", function (data) {
                if (data.code > 0) {
                    var redirto = utility.getRedirUrl(HomeControl, HomeAction) + '?' + (new Date()).getMilliseconds();
                    window.location.href = redirto;
                } else {
                    utility.showPopUp(data.msg, 1, function () { window.location.href = window.location.pathname + '?u=' + id; });
                }
            });
        }
    },
    _Reg: function () {
        var id = $("#NewId").val();
        var pwd = $("#NewPwd").val();
        var conpwd = $("#NewConfPwd").val();

        if (id.length === 0) {
            utility.showPopUp('請輸入帳號', 1, function () { $("#NewId").focus(); });
        }
        else if (pwd.length === 0) {
            utility.showPopUp('請輸入密碼', 1, function () { $("#NewPwd").focus(); });
        }
        else if (pwd != conpwd) {
            utility.showPopUp('兩次輸入的密碼不同', 1, function () { $("#NewPwd").focus(); });
        }
        else {
            var param = { username: id, password: pwd, TeamGroupID: $("#TopicGroupId").val() };
            utility.service("LoginService/Registry", param, "POST", function (data) {
                if (data.code > 0) {
                    var redirto = utility.getRedirUrl(HomeControl, HomeAction) + '?' + (new Date()).getMilliseconds();
                    var cb = function () {
                        window.location.href = redirto;
                    }
                    utility.showPopUp(data.msg, 1, cb);
                } else {
                    utility.showPopUp(data.msg, 1);
                }
            });
        }
    },
    FBLogin: function () {
        FB.getLoginStatus(function (response) {
            if (response.status === 'connected') {
                var uid = response.authResponse.userID;
                var accessToken = response.authResponse.accessToken;
                var param = { token: accessToken };
                utility.service("LoginService/FBLogin", param, "POST", function (data) {
                    if (data.code > 0) {
                        var redirto = utility.getRedirUrl(HomeControl, HomeAction) + '?' + (new Date()).getMilliseconds();
                        window.location.href = redirto;
                    } else {
                        utility.showPopUp(data.msg, 1, function () { window.location.href = window.location.pathname + '?u=' + id; });
                    }
                });

            }
            else {
                //initiateFBLogin();
            }
        });
    }
};