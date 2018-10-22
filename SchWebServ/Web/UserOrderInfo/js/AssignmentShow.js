$(document).ready(function () {
    var CustDateTime = new Date();
    var currfullyear = CustDateTime.getFullYear();
    var currmonth = CustDateTime.getMonth() + 1;
    var currtoday = CustDateTime.getDate();
    //$("#OrderStartTime").val(currfullyear+"-"+currmonth+"-"+currtoday);

    //當鼠標離開文本框時觸發事件。功能：判斷賬號是否存在，如果已存在，不允許添加
    $("#Account").mouseleave(function () {
        var Account = $('#Account').val();
        var params = '{"account":"' + Account + '"}';
        if (Account != "") {
            $.ajax({
                type: "POST",
                url: "UserOrderAdd.aspx/AccountIsExist",
                data: params,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    alert(data.d.msg);
                },
                error: function (obj, msg, e) {
                }
            });
        }
    });
    //當省交換時，獲取當前的地級市
    $('#aprov').change(function () {
        var selv = $('#aprov').val();
        var params = '{"typecode":"1","pcode":"' + selv + '","uareano":"' + uareano + '","addall":false}';
        if (selv != "") {
            $.ajax({
                type: "POST",
                url: "../../PlcData.aspx/getarea",
                data: params,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
                        alert(data.d.msg);
                        window.location.href = "../../LoginExc.aspx";
                    } else if (data.d.code == "ExcepError") {
                        alert(data.d.msg);
                    } else {
                        $('#acity').html(data.d.RspData);
                        $('#acity').change();
                        $("#aprov option").each(function () {
                            if ($(this).val() == selv) {
                                $(this).attr("selected", true);
                            }
                            else {
                                $(this).removeAttr("selected");
                            }
                        });
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        }
    });
    //訂購套餐改變時觸發
    $("#TagsOrderPackage").change(function () {
        var orderpackageval = $(this).val();
        if (orderpackageval) {
            //計算訂購時長并生成option
            var ordertimelength = "<option value=\"\">请选择时长</option>";
            if (orderpackageval != null) {
                for (var i in ServBusTreeNode) {
                    if (ServBusTreeNode[i].id == orderpackageval) {//選擇當前訂購套餐
                        fristTimeLength = ServBusTreeNode[i].BusMonth;//獲取默認訂購時長，即初始化的訂購時長
                        fristFeeCode = ServBusTreeNode[i].FeeCode;
                        ordertimelength += "<option value=\"" + fristTimeLength + "\">" + fristTimeLength + "个月</option>";
                        var tempval = fristTimeLength;
                        for (var ii = 1; ii < 6; ii++) {
                            tempval = tempval * 2;
                            ordertimelength += "<option value=\"" + tempval + "\">" + tempval + "个月</option>";
                        }
                    }
                }
                $("#OrderLength").html(ordertimelength);
            }
            //查詢附加功能
            var params = '{"ordpack":"' + orderpackageval + '"}';
            if (orderpackageval != "") {
                $.ajax({
                    type: "POST",
                    url: "UserOrderEdit.aspx/getServFunc",
                    data: params,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        servfuncdom(data.d);
                    },
                    error: function (obj, msg, e) {
                    }
                });
            }
        } else {
            $(document).find("#AdditionalFunc .UOrdAddField").remove();
            $(document).find("#OrderLength").html("<option value=\"\">请先选择订购套餐</option>");
            $("#PayAmount").val("");
            $("#OrderEndTime").val("");
        }
    });
    //訂購套餐改變時觸發，計算繳費金額
    $("#OrderLength").change(function () {
        var orderlengthval = $(this).val();
        if (orderlengthval) {
            //計算繳費金額
            if (fristTimeLength != 0 && fristFeeCode != 0) {
                if (orderlengthval != fristTimeLength) {//如果選擇的訂購時長不等於默認訂購時長
                    currentFeeCode = orderlengthval / fristTimeLength * fristFeeCode;
                } else {
                    currentFeeCode = fristFeeCode;
                }
            }
            $("#PayAmount").val(currentFeeCode);
            //計算結束日期/結束時間
            var lastMonth = 12 - currmonth;//當前年份剩餘月份
            var month = orderlengthval - lastMonth
            if (month > 0) {
                var remainder = (orderlengthval - lastMonth) % 12;//取餘數
                var Rounding = Math.ceil((orderlengthval - lastMonth) / 12);//向上取整
                $("#OrderEndTime").val((parseInt(currfullyear) + parseInt(Rounding)) + "-" + remainder + "-" + (parseInt(currtoday) - 1));
            } else {
                if (orderlengthval < lastMonth) {
                    $("#OrderEndTime").val(currfullyear + "-" + (parseInt(currmonth) + parseInt(orderlengthval)) + "-" + (parseInt(currtoday) - 1));
                } else {
                    $("#OrderEndTime").val(currfullyear + "-" + (parseInt(currmonth) + parseInt(lastMonth)) + "-" + (parseInt(currtoday) - 1));
                }
            }
        } else {
            $("#PayAmount").val("");
            $("#OrderEndTime").val("");
        }
    });
});