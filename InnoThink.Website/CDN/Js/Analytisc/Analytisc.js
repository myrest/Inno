///<reference path="./../lib/jquery-1.9.1-vsdoc.js" />
///<reference path="./../common.js" />

var Analysis = {
    TopicSN: $('#TopicSN').val(),
    InitData: function () {
        Analysis._InitData(TypeLeft);
        utility.stopRequest = false;
        Analysis._InitData(TypeRight);
    },
    _InitData: function (type) {
        var param = {
            TopicSN: Analysis.TopicSN,
            AnalysisType: type
        };
        utility.service('AnalysisService/GetItemList', param, 'POST', function (data) {
            if (data.code > 0) {
                if (data.d != null && (data.d.length > 0)) {
                    var templatepara = { 'List': data.d };
                    utility.template("Analysis/ItemListing.html", function (template) {
                        $('#Analysis' + type).html(template.process(templatepara));
                        Analysis.AfterTrimPath(type);
                    }, "AnalysisItemListing");
                }
            } else {
                utility.showPopUp(data.msg, 1);
            }
        });
    },
    GetByFormData: function () {
        var $this = $(this);
        var $table = $this.closest('table');

        //Get from form
        var idea = $table.find('.idea').html();
        var description = $table.find('.description').html().replace(/<br\s*[\/]?>/gi, "\n");
        var anssn = $this.attr('sn');
        var anntype = $this.attr('anntype');

        //Set to form
        $block = $('#Block' + anntype);
        $block.find('[name="idea"]').val(idea);
        $block.find('[name="description"]').val(description);
        $block.find('[name="anssn"]').val(anssn);

        //Show and hidden button
        $block.find('[name="savebtn"]').hide();
        $block.find('[name="updatebtn"]').show();
        $block.find('[name="cancle"]').show();
    },
    _PushData: function ($this, isNew) {
        var $block = $this.closest('table');
        var TopicSN = $('#TopicSN').val();
        var $type = $block.find('[name="anstype"]');
        var $idea = $block.find('[name="idea"]');
        var $description = $block.find('[name="description"]');
        var sn = (isNew) ? 0 : $block.find('[name="anssn"]').val();
        if ($idea.isDefaultValue() || $description.isDefaultValue()) {
            utility.showPopUp('請輸入您想要的內容。', 1);
            return;
        }
        var para = {
            'TopicSN': parseInt(TopicSN, 10)
            , 'Type': parseInt($type.val(), 10)
            , 'Idea': $idea.val()
            , 'Description': $description.val()
            , 'AnalysisSN': parseInt(sn, 10)
        };

        utility.ajaxQuiet('AnalysisService/SaveAnalysis', para);
        utility.SetAsDefault($block);
        //Show and hidden button
        $block.find('[name="savebtn"]').show();
        $block.find('[name="updatebtn"]').hide();
        $block.find('[name="cancle"]').hide();
    },
    SaveData: function () {
        var $this = $(this);
        Analysis._PushData($this, true);
    },
    UpdateData: function () {
        var $this = $(this);
        Analysis._PushData($this, false);
    },
    Delete: function () {
        var $this = $(this);
        var sn = $this.attr('sn');
        utility.showPopUp('真的要刪除它嗎？', 3, function () { Analysis._Delete(sn); });
    },
    _Delete: function (sn) {
        var para = {
            'AnalysisSN': parseInt(sn, 10)
        };
        utility.ajaxQuiet('AnalysisService/DeleteAnalysis', para);
    },
    SyncUI: function (data) {
        var templatepara = { 'List': [data] };
        utility.template("Analysis/ItemListing.html", function (template) {
            var $newHTML = $(template.process(templatepara));

            var $oldobj = $('#Analysis' + data.AnalysisType).find('.edit.clickable[sn=' + data.AnalysisSN + ']');
            if ($oldobj.length > 0) {
                var $oldTable = $oldobj.closest('table');
                var olditemsn = $oldTable.find('.itemsn').html();
                $newHTML.find('.itemsn').html(olditemsn);
                $oldTable.html($newHTML.html());
            } else {
                //Append to the buttom
                $('#Analysis' + data.AnalysisType).append($newHTML[0]);
            }
            Analysis.AfterTrimPath(data.AnalysisType);
        }, "AnalysisItemListing");
    },
    SyncRemoveUI: function (data) {
        var type = data.Key;
        var sn = data.Value;
        $('#Analysis' + type).find('.edit.clickable[sn=' + sn + ']').closest('table').remove();
        $.each($('#Analysis' + type).find('.itemsn'), function (index, obj) {
            $(obj).html(index + 1);
        });
    },
    AfterTrimPath: function (type) {
        //make each cell can be click for edit number.
        $('.edit.clickable').unbind().on('click', Analysis.GetByFormData);
        $('.delete.clickable').unbind().on('click', Analysis.Delete);
        $.each($('#Analysis' + type).find('.itemsn'), function (index, obj) {
            $(obj).html(index + 1);
        });
    }
};

$(function () {
    $('[name="cancle"]').on('click', utility.CancleUpdate);
    $('[name="savebtn"]').on('click', Analysis.SaveData);
    $('[name="updatebtn"]').on('click', Analysis.UpdateData);
    Analysis.InitData();
    //JSON.stringify(possessList)
});
