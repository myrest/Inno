$(function () {
    Product.init();
    Item.init();
    Item.SwitchToProduct();
});

var Item = {
    $NewSize: $('#sizename'),
    $NewColor: $('#colorname'),
    $ItemNumBox: $('#itemnumbox'),
    $SwtichFrom: $('#SwitchFromSpan'),
    $SwitchTo: $('#SwitchToSpan'),
    TargetItemId: '',
    SwitchFromId: '',
    SwitchToId: '',
    CurrentIdInCell: '',
    init: function () {
        $('#NewSize').click(function () { Item.$NewSize.show().focus(); });
        Item.$NewSize.blur(function () { Item.$NewSize.hide(); });
        Item.$NewSize.hide();
        Utils.textBoxsOnEnter(Item.AddNewSize, Item.$NewSize);

        $('#NewColor').click(function () { Item.$NewColor.show().focus(); });
        Item.$NewColor.blur(function () { Item.$NewColor.hide(); });
        Item.$NewColor.hide();
        Utils.textBoxsOnEnter(Item.AddNewColor, Item.$NewColor);

        Item.$ItemNumBox.on('blur', function () { Item.$ItemNumBox.hide(); });
        Utils.textBoxsOnEnter(Item.UpdateItenNum, Item.$ItemNumBox);

        $('#itemBackToProd').on('click', Item.SwitchToProduct);
        Utils.textBoxOnESC(function () { Item.HideOthers($(document)) });
        Item.$SwtichFrom.on('click', Item.SetSwitch);
        Item.$SwitchTo.on('click', Item.SetSwitch);
    },
    UpdateItenNum: function () {
        var orgValue = $('#' + Item.TargetItemId).text();
        var newValue = Item.$ItemNumBox.val().trim();
        newValue = parseInt(newValue, 10);
        orgValue = parseInt(orgValue, 10);
        if (isNaN(orgValue)) orgValue = 0;
        if (isNaN(newValue)) {
            utility.showPopUp('請輸入數字。', 1, function () { Item.$ItemNumBox.show().focus(); });
        } else if (orgValue == newValue) {
            Item.$ItemNumBox.hide();
        } else {
            $('#' + Item.TargetItemId).html(newValue);
            var param = { id: Item.TargetItemId, num: newValue, sn: $('#Products_sn').val() };
            utility.ajaxQuiet("ProductService/UpdateItemNum", param, function () { Item.$ItemNumBox.hide() });
            Item.UpdateVCount(Item.TargetItemId, newValue - parseInt(orgValue));
        }
    },
    ShowNumberInputBox: function (e) {
        var $obj = $(this);
        var orgnum = $(this).text().trim();
        Item.TargetItemId = $obj.attr('id');
        var Offset = $obj.offset();
        Item.HideOthers($obj);
        Item.$ItemNumBox.show().css('top', Offset.top + 3).css('left', Offset.left + 3).val(orgnum).focus();
    },
    SwitchToProduct: function () {
        $('#itemmanagement').hide('Drop');
        $('#productmanagement').show('Slide');
        Product.GetAllProduct();
    },
    AddNewSize: function () {
        var newname = Item.$NewSize.val();
        if (newname.length === 0) {
            utility.showPopUp('請輸入要新建的尺寸名稱', 1, function () { Item.$NewSize.focus(); });
        } else {
            var param = { SizeName: newname, sn: $('#Products_sn').val() };
            Item.$NewSize.hide();
            Item.$NewSize.val('');
            utility.ajaxQuiet("ProductService/NewSize", param, function () { Item.GetAllItem($('#Products_sn').val()); });
        }
    },
    AddNewColor: function () {
        var newname = Item.$NewColor.val();
        if (newname.length === 0) {
            utility.showPopUp('請輸入要新建的顏色名稱', 1, function () { Item.$NewColor.focus(); });
        } else {
            var param = { ColorName: newname, sn: $('#Products_sn').val() };
            Item.$NewColor.hide();
            Item.$NewColor.val('');
            utility.ajaxQuiet("ProductService/NewColor", param, function () { Item.GetAllItem($('#Products_sn').val()); });
        }
    },
    UpdateVCount: function (key, value) {
        var ark = key.split('-');
        var $vTotal = $('#' + ark[0] + '-vtotal');
        var $cTotal = $('#' + ark[1] + '-ctotal');
        var $Total = $('#itemtotal');
        var v_total = parseInt($vTotal.text(), 10);
        var c_total = parseInt($cTotal.text(), 10);
        var total = parseInt($Total.text(), 10);
        if (isNaN(v_total)) v_total = 0;
        if (isNaN(c_total)) c_total = 0;
        if (isNaN(total)) total = 0;
        var newValue = parseInt(value, 10);
        if (isNaN(newValue)) newValue = 0;
        v_total += newValue;
        c_total += newValue;
        total += newValue;
        $vTotal.html(v_total);
        $cTotal.html(c_total);
        $Total.html(total);
    }
    , HideOthers: function ($obj) {
        Item.$ItemNumBox.hide();
        Item.$SwtichFrom.hide();
        Item.$SwitchTo.hide();
        $obj.show();
    }
    , ShowSwitchIcon: function () {
        var $obj = $(this);
        var Offset = $obj.offset();
        if (Item.SwitchFromId == '' || Item.SwitchToId == '') {
            Item.CurrentIdInCell = $obj.attr('id');
            if (Item.SwitchFromId == '') {
                Item.$SwtichFrom.show().css('top', Offset.top + 3).css('left', Offset.left + 3);
                Item.$SwitchTo.hide();
            } else {
                Item.$SwitchTo.show().css('top', Offset.top + 3).css('left', Offset.left + 3);
            }
        }
    }
    , GetCellValue: function (strNum) {
        if (strNum.length == 0) {
            return 0;
        } else {
            var newnum = parseInt(strNum, 10);
            if (isNaN(newnum)) newnum = 0;
            return newnum;
        }
    }
    , SetSwitch: function () {
        var $obj = $(this);
        if (Item.SwitchFromId == '') {
            //Check is empty or number is empty or 0.
            var newnum = Item.GetCellValue($('#' + Item.CurrentIdInCell).text().trim());
            if (newnum < 1) {
                utility.showPopUp("換貨的來源數量[" + newnum + "]不足以更換成新貨品", 2);
            } else {
                //Set switch from
                Item.SwitchFromId = Item.CurrentIdInCell;
                Item.$SwtichFrom.addClass('SwitchSpanFull');
            }
        } else {
            if (Item.CurrentIdInCell == Item.SwitchFromId) {
                //cancle the from id.
                Item.SwitchFromId = '';
                Item.$SwtichFrom.removeClass('SwitchSpanFull');
            } else {
                //Set Swtich to
                Item.SwitchToId = Item.CurrentIdInCell;
                Item.$SwitchTo.addClass('SwitchSpanFull');
                //Need process switch 2 object nums, one increase, theother is decrease.
                utility.showPopUp("要換貨了嗎?", 3, Item.doSwitch, Item.SwitchReset);
            }
        }
    }
    , SwitchReset: function () {
        Item.$SwitchTo.hide().removeClass('SwitchSpanFull');
        Item.$SwtichFrom.hide().removeClass('SwitchSpanFull');
        Item.SwitchFromId = '';
        Item.SwitchToId = '';
    }
    , doSwitch: function () {
        //Deal with from
        var newValue = Item.GetCellValue($('#' + Item.SwitchFromId).text()) - 1;
        $('#' + Item.SwitchFromId).html(newValue);
        var param = { id: Item.SwitchFromId, num: newValue, sn: $('#Products_sn').val() };
        utility.ajaxQuiet("ProductService/UpdateItemNum", param, null);
        Item.UpdateVCount(Item.SwitchFromId, -1);

        //Deal with to
        utility.stopRequest = false;
        newValue = Item.GetCellValue($('#' + Item.SwitchToId).text()) + 1;
        $('#' + Item.SwitchToId).html(newValue);
        param = { id: Item.SwitchToId, num: newValue, sn: $('#Products_sn').val() };
        utility.ajaxQuiet("ProductService/UpdateItemNum", param, null);
        Item.UpdateVCount(Item.SwitchToId, 1);

        Item.SwitchReset();
    }
    , GetAllItem: function (sn) {
        $('#Products_sn').val(sn);
        var param = { sn: sn };
        utility.service('ProductService/GetAllItemList', param, 'POST', function (data) {
            if (data.code > 0) {
                if (data.d != null && (data.d.length > 0 || data.c.length > 0 || data.r.length > 0)) {
                    var templatepara = { 'cList': data.c, 'rList': data.r };
                    utility.template("Products/ItemListing.html", function (template) {
                        $('#itemList').html(template.process(templatepara));
                        $.each(data.d, function (index, value) {
                            Item.UpdateVCount(value.k, value.v);
                            $('#' + value.k).html(value.v);
                        });
                        //need bind value to each cell.

                        //make each cell can be click for edit number.
                        $('.itemnums').on('click', Item.ShowNumberInputBox);
                        $('.itemnums').on('mouseover', Item.ShowSwitchIcon);
                    }, "ItemListing");
                } else {
                    utility.template("Products/NoItem.html", function (template) {
                        $('#itemList').html(template.process(templatepara));
                    }, "NoItemData");
                }
            } else {
                utility.showPopUp(data.msg, 1);
            }
        });
    }
};

var Product =
{
    $NewProduct: $('#productname'),
    init: function () {
        //region
        $('#NewProduct').click(function () { Product.$NewProduct.show().focus(); });
        Product.$NewProduct.blur(function () { Product.$NewProduct.hide(); });
        Product.$NewProduct.hide();
        Utils.textBoxsOnEnter(Product._AddNew, Product.$NewProduct);
        $(document).on('click', '#prodList a.delete', function () {
            Product.delConfirm($(this).parent().parent().parent().parent().data('sn'));
        });
        $(document).on('click', '#prodList a.rename', function () {
            Product.ShowRename($(this).parent().parent().parent().parent().data('sn'));
        });
        $(document).on('blur', '#newname', function () {
            $(this).parent().html('');
        });
        $(document).on('click', 'a.toItem', function () {
            var product_sn = $(this).parent().parent().data('sn');
            Product.SwitchToItem(product_sn);
        });
        //endregion
    },
    //region for product listing
    ShowRename: function (sn) {
        var $inp = $('.p' + sn).first();
        var v = $inp.parent().text();
        $inp.html('<input type="text" id="newname" class="inputproduct coverInput" value="' + v + '">');
        $('#newname').focus();
        Utils.textBoxsOnEnter(function () { Product.doRename(sn) }, '#newname');
    },
    delConfirm: function (sn) {
        var objfun = function () {
            Product.doDel(sn);
        }
        utility.showPopUp("你確定要刪除？", 3, objfun);
    }
    , doDel: function (x) {
        var param = { sn: x };
        utility.ajaxQuiet("ProductService/DeleteProduct", param, Product.GetAllProduct);
    }
    , doRename: function (x) {
        var param = { sn: x, ProductName: $('#newname').val() };
        var $inp = $('.p' + x).html('');
        utility.ajaxQuiet("ProductService/RenameProduct", param, Product.GetAllProduct);
    }
    , GetAllProduct: function () {
        utility.service('ProductService/GetAllProductList', '', 'POST', function (data) {
            if (data.code > 0) {
                if (data.d != null && data.d.length > 0) {
                    var templatepara = { 'pList': data.d };
                    utility.template("Products/ProdListing.html", function (template) {
                        $('#prodList').html(template.process(templatepara));
                    }, "DataListing");
                } else {
                    utility.template("Products/NoProduct.html", function (template) {
                        $('#prodList').html(template.process(templatepara));
                    }, "NoProductData");
                }
            } else {
                utility.showPopUp(data.msg, 1);
            }
        });
    },
    _AddNew: function () {
        var prdname = Product.$NewProduct.val();

        if (prdname.length === 0) {
            utility.showPopUp('請輸入要新建的產品名稱', 1, function () { Product.$NewProduct.focus(); });
        } else {
            var param = { ProductName: prdname };
            Product.$NewProduct.hide();
            Product.$NewProduct.val('');
            utility.ajaxQuiet("ProductService/NewProduct", param, Product.GetAllProduct);
        }
    }
    , SwitchToItem: function (sn) {
        $('#productmanagement').hide('Drop');
        $('#itemmanagement').show('Slide');
        Item.GetAllItem(sn);
    }
    //endregion
};