///<reference path="./../lib/jquery-1.9.1-vsdoc.js" />
///<reference path="./../common.js" />

var Analysis = {
    TopicSN: $('#TopicSN').val(),
    InitData: function () {
        Analysis._InitData(0);
        utility.stopRequest = false;
        Analysis._InitData(1);
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
                        //make each cell can be click for edit number.
                        $('.edit.clickable').on('click', Analysis.GetByFormData);
                        $('.delete.clickable').on('click', Analysis.Delete);
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
        var description = $table.find('.description').html();
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
        var anntype = $this.attr('anntype');
        var para = {
            'AnalysisSN': parseInt(sn, 10)
        };
        utility.ajaxQuiet('AnalysisService/DeleteAnalysis', para, function () {
            Analysis._InitData(anntype);
        });
    },
    syncUI: function (data) {
        //check sn is existing.
        //var ItemNums =
        var $objtype = $('#BlockType' + data.TypeUI);
        var objLength = $objtype.find('table').length + 1;
        var $html = Step.$Template.clone();
        $html = $html.find('.itemsn').html(objLength).end()
                        .find('.edit').attr('sn', data.SN).end()
                        .find('.idea').html(data.Idea).end()
                        .find('.description').html(data.Description).end();
        var $obj = $objtype.find('.edit[sn=' + data.SN + ']');
        if ($obj.length > 0) {
            var _sn = $obj.parent().parent().parent().parent().find('.itemsn').first().html();
            $html.find('.itemsn').html(_sn);
            $obj.parent().parent().parent().parent().html($html.html());
        } else {
            $objtype.append($html);
        }
        $objtype.find('.edit').unbind().on('click', Step.GetBestData);
        utility.ShowNotice($('#notice'));
    }

};

$(function () {
    $('[name="cancle"]').on('click', utility.CancleUpdate);
    $('[name="savebtn"]').on('click', Analysis.SaveData);
    $('[name="updatebtn"]').on('click', Analysis.UpdateData);
    $('.edit').on('click', Analysis.GetBestData);
    Analysis.InitData();
    //JSON.stringify(possessList)
});
