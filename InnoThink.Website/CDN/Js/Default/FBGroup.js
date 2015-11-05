$(function () {
    InnoFB.RandFBGroup();
});

var InnoFB = {
    fbGroupUrl: 'https://graph.facebook.com/v2.1/' + fbGroupId + '/feed?limit=100&access_token=' + token
    , fbGroupMsgUrl: 'https://graph.facebook.com/v2.1/' + fbGroupId + '/feed?&access_token=' + token + '&message='
    , fbGraphUrl: 'https://graph.facebook.com/v2.1/'
    , RandFBGroup: function () {
        if (token.length > 1) {
            utility.service(InnoFB.fbGroupUrl, null, 'Get', InnoFB.ParsFB, InnoFB.ParsFailed);
        }
    }
    , ParsFB: function (fbobj) {
        var param = { FbData: fbobj, token: token };
        utility.template("Default/FBGroupDataList.html", function (template) {
            $('#FBgroup').html(template.process(param));
            $('#FBgroup .NewFBMessage').click(InnoFB.ShowNewPostBtn);
            Utils.textBoxsOnEnter(InnoFB.AutoGrow, $('#FBgroup .NewFBMessage'));
            $('#FBgroup .NewFBMessage').on('focus', InnoFB.ShowNewPostBtn);
            $('#FBgroup .NewFBComment').on('focus', InnoFB.ShowNewPostBtn);
            $('#FBgroup .fbSendmessage').on('click', InnoFB.PostNewMessage);
            $('#FBgroup .fbSendComment').on('click', InnoFB.PostNewComment);
        }, "FBgroup");
    }
    , AutoGrow: function (obj) {
        var $this = $(obj);
        $this.css('height', $this[0].scrollHeight + 15 + 'px');
        var innerTxt = $this.val() + '\n';
        $this.val(innerTxt);
    }
    , ShowNewPostBtn: function () {
        $this = $(this);
        var $objbtn = $this.parent().find('[type=button]').first();
        $objbtn.show();
    }
    , HideNewPostBtn: function () {
        $('#FBgroup .fbSendmessage').hide();
    }
    , PostNewMessage: function () {
        var message = $('#FBgroup .NewFBMessage').val().trim();
        if (message.length > 0) {
            utility.service(InnoFB.fbGroupMsgUrl + message, null, 'Post', function () { setTimeout(InnoFB.RandFBGroup, 2000) });
        }
    }
    , PostNewComment: function () {
        $this = $(this);
        var message = $this.parent().find('textarea').val().trim();
        var id = $this.attr('id');
        if (message.length > 0) {
            var url = InnoFB.fbGraphUrl + id + '/comments?message=' + message + '&access_token=' + token;
            utility.service(url, null, 'Post', function () { setTimeout(InnoFB.RandFBGroup, 2000) });
        }
    }
}