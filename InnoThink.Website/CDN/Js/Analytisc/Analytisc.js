///<reference path="./../lib/jquery-1.9.1-vsdoc.js" />
///<reference path="./../common.js" />

var Analytisc = {
    TopicSN: $('#TopicSN').val(),
    GetBestData: function () {
        utility.CancleUpdate();
        //Get information from UI.
        var $this = $(this).parent().parent().parent();
        var sn = $(this).attr('sn');
        var idea = $this.find('.idea').val();
        var description = $this.find('.description').val();

        //Set to the Form
        var $type = $this.parent().parent().parent();
        var typename = $type.attr('id').substr(5, 5);
        var $form = $('#' + typename);
        $form.find('[name="idea"]').val(idea);
        $form.find('[name="description"]').val(description);

        $('[name="savebtn"]').show();
        $('[name="updatebtn"]').hide();
        $('[name="cancle"]').hide();

        $form.find('[name="savebtn"]').hide();
        $form.find('[name="updatebtn"]').show();
        $form.find('[name="cancle"]').show();
    },
    SaveData: function () {
        var $block = $($(this).attr('belong'));
        var TopicSN = $('#TopicSN').val();
        var $type = $block.find('[name="anstype"]');
        var $idea = $block.find('[name="idea"]');
        var $description = $block.find('[name="description"]');
        if ($idea.isDefaultValue() || $description.isDefaultValue()) {
            utility.showPopUp('請輸入您想要的內容。', 1);
            return;
        }
        var para = {
            'TopicSN': parseInt(TopicSN, 10)
            , 'Type': parseInt($type.val(), 10)
            , 'Idea': $idea.val()
            , 'Description': $description.val()
        };

        utility.ajaxQuiet('AnalysisService/NewAnalysis', para);
        utility.SetAsDefault($block);
    },
    UpdateData: function () {
        var $table = $(this).first().parent().parent().parent().parent();
        var idea = $table.find('[name="idea"]').val();
        var description = $table.find('[name="description"]').val();
        if (idea == '想法' || description == '說明') {
            utility.showPopUp('請輸入您想要的內容。', 1);
            return;
        }
        var para = {
            'SN': Step.SN
                    , 'Idea': idea
                    , 'Description': description
        };
        utility.ajaxQuiet('TopicService/UpdateBestIdea', para);
        utility.CancleUpdate;
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
    $('[name="savebtn"]').on('click', Analytisc.SaveData);
    $('[name="updatebtn"]').on('click', Analytisc.UpdateData);
    $('.edit').on('click', Analytisc.GetBestData);
    //JSON.stringify(possessList)
});
