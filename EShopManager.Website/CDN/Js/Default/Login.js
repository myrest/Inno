var HomeControl = 'Home';
var HomeAction = 'Index';
var isFirstTimeFBLogin = true;


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
            appId: '758259224185187',
            status: false, // check login status
            cookie: true, // enable cookies to allow the server to access the session
            xfbml: true,  // parse XFBML
            scope: 'email',
            oauth: true
        });
        $('#loginbutton,#feedbutton').removeAttr('disabled');

        //FB.getLoginStatus(updateStatusCallback);

        FB.Event.subscribe('auth.login', function (response) {
            updateStatusCallback(response);
            //login.FBLogin(response.authResponse.accessToken);
        });

        FB.Event.subscribe('auth.statusChange', function (response) {
            updateStatusCallback(response);
            //login.FBLogin(response.authResponse.accessToken);
        });
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
            var param = { username: id, password: pwd };
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
    FBLogin: function (token) {
        if (isFirstTimeFBLogin) {
            isFirstTimeFBLogin = false;
            var param = { token: token };
            utility.service("LoginService/FBLogin", param, "POST", function (data) {
                if (data.code > 0) {
                    var redirto = utility.getRedirUrl(HomeControl, HomeAction) + '?' + (new Date()).getMilliseconds();
                    window.location.href = redirto;
                } else {
                    utility.showPopUp(data.msg, 1, function () { window.location.href = window.location.pathname + '?u=' + id; });
                }
            });
        }
    }
};
var updateStatusCallback = function (response) {
    // Here we specify what we do with the response anytime this event occurs. 
    if (response.status === 'connected') {
        // The response object is returned with a status field that lets the app know the current
        // login status of the person. In this case, we're handling the situation where they 
        // have logged in to the app.
        var uid = response.authResponse.userID;
        var accessToken = response.authResponse.accessToken;
//        FB.api('/me?fields=id,name,picture,email', function (response) {
//            var img = '<img src="' + response.picture.data.url + '">';
//            $('#fbpic').html(img);
//            $('#fbname').html(response.name);
//        });
        login.FBLogin(accessToken);


    } else if (response.status === 'not_authorized') {
        // In this case, the person is logged into Facebook, but not into the app, so we call
        // FB.login() to prompt them to do so. 
        // In real-life usage, you wouldn't want to immediately prompt someone to login 
        // like this, for two reasons:
        // (1) JavaScript created popup windows are blocked by most browsers unless they 
        // result from direct interaction from people using the app (such as a mouse click)
        // (2) it is a bad experience to be continually prompted to login upon page load.
        //FB.login();
        //        FB.api('/me?fields=id,name,picture', function (response) {
        //            var img = '<img src="' + response.picture.data.url + '">';
        //            $('#fbpic').html(img);
        //            $('#fbname').html(response.name);
        //        });

    } else {
        // In this case, the person is not logged into Facebook, so we call the login() 
        // function to prompt them to do so. Note that at this stage there is no indication
        // of whether they are logged into the app. If they aren't then they'll see the Login
        // dialog right after they log in to Facebook. 
        // The same caveats as above apply to the FB.login() call here.
        FB.login();
    }

};

