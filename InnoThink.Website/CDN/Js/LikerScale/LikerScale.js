///<reference path="./../lib/jquery-1.9.1-vsdoc.js" />
///<reference path="./../common.js" />
var LikerScale = {
    TopicSN: $('#TopicSN').val(),
    SaveData: function() {
        var $selected = $('.LSSetting').find('[type="radio"]:checked');
        var Ranks = $.map($selected,function(data){return $(data).val()});
        Ranks = JSON.stringify(Ranks);
        var para = {
            'Ranks': Ranks
        };
        utility.ajaxQuiet('LikerScaleService/UpdateLikerScaleRank', para);
    },
    SyncUI: function(data) {
        var templatepara = {
            'List': [data]
        };
        utility.template("Analysis/ItemListing.html", function(template) {
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
            LikerScale.AfterTrimPath(data.AnalysisType);
        }, "AnalysisItemListing");
    }
};

$(function() {
    $('[name="savebtn"]').on('click', LikerScale.SaveData);
    //JSON.stringify(possessList)
});