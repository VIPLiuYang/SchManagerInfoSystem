///
///省市区联动
///



//获取市
$('#aprov').change(function () {
    var selv = $('#aprov').val();
    var params = '{"typecode":"1","pcode":"' + selv + '","isall":"0"}';
    $.ajax({
        type: "POST",  //请求方式
        url: "../../PlcData.aspx/getarea",  //请求路径：页面/方法名字
        data: params,     //参数
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d.code == "expire") {                            
                window.location.href = "../../LoginExc.aspx";
            } else if (data.d.code == "ExcepError") {
                alert(edata.d.msg);
            } else {
                $('#acity').html(data.d.data);
                $('#acity').change();
            }
        },
        error: function (obj, msg, e) {
        }
    });
});
//获取区
$('#acity').change(function () {
    var selv = $('#acity').val();
    var params = '{"typecode":"2","pcode":"' + selv + '","isall":"0"}';
    $.ajax({
        type: "POST",  //请求方式
        url: "../../PlcData.aspx/getarea",  //请求路径：页面/方法名字
        data: params,     //参数
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d.code == "expire") {                            
                window.location.href = "../../LoginExc.aspx";
            } else if (data.d.code == "ExcepError") {
                alert(edata.d.msg);
            } else {
                $('#acoty').html(data.d.data);
                $('#acoty').change();
            }
        },
        error: function (obj, msg, e) {
        }
    });
});