///
///重置密码
///

$(document).on("click", "#resetPwd", function () {
    $("#InitialPwd").attr("type", "text");
    $("#InitialPwd").val("123456");
    $(".initpwd").html("初始密码");
    $("#resetPwd").css("display", "none");
    $("#InitialPwd").attr("class", "col-xs-12 col-sm-12");
    /*
    var useridhidden = $("#useridhidden").val();
    var params = '{"userid":"' + useridhidden + '"}';
    $.ajax({
        type: "POST",  //请求方式
        url: "SchEdit.aspx/ResetPwd",  //请求路径：页面/方法名字
        data: params,     //参数
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if(data.d=="1"){
                //alert("重置密码成功");
                $("#InitialPwd").attr("type","text");
                $("#InitialPwd").val("123456");
                $(".initpwd").html("初始密码");
                $("#resetPwd").css("display","none");
                $("#InitialPwd").attr("class","col-xs-12 col-sm-12");
                //window.location.href="SchInfo.aspx";
            }else if(data.d=="0"){
                alert("重置密码失败");
            }
        },
        error: function (obj, msg, e) {
        }
    });*/
});