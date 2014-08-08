///<reference path="./lib/jquery-1.9.1-vsdoc.js" />
///<reference path="common.js" />

var inno198 = {
    conn: $.connection.innoComm,
    init: function () {
        $("#send").click(function () {
            inno198.conn.server.cmd($('#command').val());
        });

        Utils.textBoxsOnEnter(Board.SendPrivateMsg, $('#PirvateMessage'));

        Utils.textBoxsOnEnter(Board.SendPublicMsg, $('#PublicMessage'));

        // received
        $.connection.hub.received(function (data) {
        });

        // error
        $.connection.hub.error(function (error) {
        });

        // reconnected
        $.connection.hub.reconnected(function () {
        });

        // disconnected
        $.connection.hub.disconnected(function () {
        });

        // connectionSlow
        $.connection.hub.connectionSlow(function () {
        });

        // Add client-side hub methods that the server will call
        $.extend(inno198.conn.client, {
            ServerInitCache: function (msg) {
                var para = {
                    'ConnectionId': msg
                };
                utility.ajaxQuiet('LoginService/SignalrLogin', para);
            },
            BoardA: function (msg) {
                //update board at top of right side.
                alert(msg);
            },
            KickOut: function (msg) {
                inno198.Disconnect();
            },
            JumpToStep: function (url) {
                var cb = function () {
                    location.href = url;
                }
                utility.showPopUp("隊長進行議題進度調整", 1, cb);
            },
            SyncUIInfo: function (ElementName, ElementValue, AttName, AttValue) {
                var $ele;
                //check has that element by id.
                $ele = $('#' + ElementName);
                if ($ele.length < 1) {
                    //make att finder
                    var att = '[' + AttName + '="' + AttValue + '"]';
                    //check element is exist by name.
                    $ele = $("[name='" + ElementName + "']");
                    if ($ele.length > 0) {
                        if ($ele.length > 1) {
                            $ele = $("[name='" + ElementName + "']" + att);
                        }
                    } else {
                        //check element is exist by class name.
                        $ele = $("." + ElementName);
                        if ($ele.length > 0) {
                            if ($ele.length > 1) {
                                $ele = $("." + ElementName + att);
                            }
                        }
                    }
                }
                //After filter out about attribute, will change the value for display
                if ($ele.length > 0) {
                    //check the type.
                    if ($ele[0].type != undefined) {
                        //the element should be input text
                        $ele.val(ElementValue);
                    } else {
                        //the element is SPAN
                        $ele.html(ElementValue);
                    }
                }
            },
            syncUIPrivateMessage: function (data) {
                SyncBoardUI(data, true);
            },
            syncUIPublicMessage: function (data) {
                SyncBoardUI(data, false);
            },
            syncUIStep1: function (topic, users) {
                //below code is under Step1.aspx
                Step1.syncUI(topic, users);
            },
            syncBest1: function (data) {
                Step.syncUI(data);
            },
            syncBestIdea: function (data) {
                Step.syncUI(data);
            },
            syncBestIdeaGroup: function (data) {
                Step.syncUI(data);
            },
            syncBestGAP: function (data) {
                Step.syncUI(data);
            },
            syncResultDraft: function (data) {
                if (typeof (Step.syncResultDraft) == "function") {
                    Step.syncResultDraft(data);
                }
            },
            syncResultDashboard: function (data) {
                if (typeof (Step.syncResultDashboard) == "function") {
                    Step.syncResultDashboard(data);
                }
            },
            syncResultPresentation: function (data) {
                if (typeof (Step.syncResultPresentation) == "function") {
                    Step.syncResultPresentation(data);
                }
            },
            syncRSDraft: function (data) {
                if (typeof (Step.syncRSDraft) == "function") {
                    Step.syncRSDraft(data);
                }
            },
            syncRSDashboard: function (data) {
                if (typeof (Step.syncRSDashboard) == "function") {
                    Step.syncRSDashboard(data);
                }
            },
            syncRSPresentation: function (data) {
                if (typeof (Step.syncRSPresentation) == "function") {
                    Step.syncRSPresentation(data);
                }
            },
            syncScenario1: function (data) {
                if (typeof (Step.syncScenario1) == "function") {
                    Step.syncScenario1(data);
                }
            },
            syncUIScenario2: function (data) {
                if (typeof (Step.syncUIScenario2) == "function") {
                    Step.syncUIScenario2(data);
                }
            },
            syncScenario3: function (data) {
                if (typeof (Step.syncUIScenario3) == "function") {
                    Step.syncUIScenario3(data);
                }
            },
            syncScenario4: function (data) {
                if (typeof (Step.syncUIScenario4) == "function") {
                    Step.syncUIScenario4(data);
                }
            },
            syncScenario7: function (data) {
                if (typeof (Step.syncUIScenario7) == "function") {
                    Step.syncUIScenario7(data);
                }
            },
            Unit1: function (data) {
                var type = data.t;
                var obj = data.d;
                switch (type) {
                    case 0:
                        UpdateUnit0(obj);
                        break;
                    case 1:
                        UpdateUnit1(obj);
                        break;
                    default:
                        break;
                }
            },
            syncOnlineUser: function (data) {
                //Get the old data is exist or not.
                var $existing = $('#UOid' + data.SN);
                if ($existing.length > 0) {
                    var $clone = $existing.clone();
                    $existing.remove();
                    $('#topicOnline').append($clone);
                } else {
                    var picobj = '<img src="' + data.Picture + '" width="30" height="30" alt="' + data.UserName + '" title="' + data.UserName + '" class="onlinemember" id="UOid' + data.SN + '" />&nbsp;';
                    $('#topicOnline').append(picobj);
                }
            },
            syncOfflineUser: function (UserSN) {
                //Get the old data is exist or not.
                var $existing = $('#UOid' + UserSN);
                if ($existing.length > 0) {
                    var $clone = $existing.clone();
                    $existing.remove();
                    $('#topicOffline').append($clone);
                }
            }
        });
    },
    Disconnect: function () {
        $.connection.hub.stop();
        inno198.Reconnect();
    },
    Reconnect: function () {
        setTimeout("inno198.Reconnect();", 1000);
    },
    ConnectStart: function () {
        $.connection.hub.start({ jsonp: true })
        .pipe()
        .done(function (state) {
            if (TopicSN == undefined || TopicSN == '') {
                TopicSN = 0;
            }
            inno198.conn.server.initUnit1(TopicSN);
        })
        .fail(function () {
            $("#content").prepend("<li class='hubStartFail'> Could not Connect!</li>");
        });
    }
};

$(function () {
    inno198.init();
    inno198.ConnectStart();
    //JSON.stringify(possessList)
});

var UpdateUnit0 = function (data) {
    var $mydata = $('#allmember .' + gv.UserSN);
    var $newdata = $('#allmember .' + data.sn);
    if ($newdata.length == 0) {
        var $html = $mydata.clone().removeClass(gv.UserSN.toString()).addClass(data.sn.toString());
        $html.find('.picimg').attr('src', data.pic);
        $html.find('.username').html(data.n);
        $html.find('.Profess').html(data.pro);
        $html.find('.descript').html(data.des);
        $('#allmember').prepend($html);
    } else {
        $newdata.find('.picimg').attr('src', data.pic);
        $newdata.find('.username').html(data.n);
        $newdata.find('.Profess').html(data.pro);
        $newdata.find('.descript').html(data.des);
    }
    //Deal with leaders
    $.each(data.ls, function (index, value) {
        $('#voteNums_' + index).html(value);
    });
    $('#LeaderName').html(data.ln);
    if (data.ln.toLowerCase() == LoginId.toLowerCase()) {
        $('#QuickNavBar').find('.clickable').removeClass('hidden');
    }
};

var SyncBoardUI = function (data, isPrivate) {
    var $boardTemp = $($('#BoardTemplate').html().trim());
    $boardTemp.find('.img').attr('src', data.icon);
    $boardTemp.find('.loginid').attr('title', data.uid).html(data.un);
    $boardTemp.find('.msg').html(data.msg + '(' + data.dt + ')');
    if (isPrivate) {
        $('#PrivateBlock').append($boardTemp);
    } else {
        $('#PublicBlock').append($boardTemp);
    }
};

var Board = {
    SendPrivateMsg: function (ele) {
        var $obj = $('#PirvateMessage');
        if ($obj.val().length > 0) {
            var para = {
                'TopicSN': TopicSN
                        , 'Message': $obj.val()
            };
            utility.ajaxQuiet('BoardService/SendPrivateMessage', para);
        }
        $obj.val('');
    }
    , SendPublicMsg: function () {
        var $obj = $('#PublicMessage');
        if ($obj.val().length > 0) {
            var para = {
                'TopicSN': TopicSN
                        , 'Message': $obj.val()
            };
            utility.ajaxQuiet('BoardService/SendPublicMessage', para);
        }
        $obj.val('');
    }
}

UpdateUnit1 = function (data) {
    utility.showPopUp("Step1", 1);
}