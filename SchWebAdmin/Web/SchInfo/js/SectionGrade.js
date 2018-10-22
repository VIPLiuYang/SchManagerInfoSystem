/*下面是学段与年级代码*/
//$("input[name='gradechkl']").change(function () {
    //var tf = $(this).is(':checked')
    //var vl = $(this).attr("value");
    //var grade = $("input[name='gradechk']");
    //if(dotype=="e"){
    //var gradearr = $("input[name='gradechk']");
    //var chknull = 0;//默认相应学段对应的年级都没有选中
    //for (var i = 0; i < gradearr.length; i++) {
    //    var gradeval = $(gradearr[i]).attr("value");
    //    var gradesubval = gradeval.substring(0, 1);
    //    if (gradesubval == vl) {
            //var chkbool = $("input[name='gradechk'][value=" + gradeval + "]").is(':checked');
            //if (chkbool == true) {
            //    chknull += 1;
            //}
    //    }
    //}
    //if (chknull != 0) {//判断相应学段对应的年级是否都没有选中
    //    alert("请先取消年级勾选状态");
    //    $("input[name='gradechkl'][value=\"" + vl + "\"]").prop("checked", "checked");
    //    return;
    //}
    //}else{
    //for (var i in grade) {
    //    var ival = $(grade[i]).attr("value");
    //    if (ival.substring(0, 1) == vl) {
    //        $(grade[i]).prop("checked", tf);
    //        if (!tf) {
    //            $(grade[i]).removeAttr("checked");
    //        }
    //        else {
    //            $(grade[i]).attr("checked", "checked");
    //        }
    //    }
    //}
    // }
//});
$("input[name='gradechkl']").change(function () {
    var tf = $(this).is(':checked')
    var vl = $(this).attr("value");
    var grade = $("input[name='gradechk']");
    //var gradearr = $("input[name='gradechk']");

    var params = "{\"schid\":\"" + schid + "\",\"percode\":\"" + vl + "\"}";
    $.ajax({
        type: "POST",  //请求方式
        url: "SchEdit.aspx/ExistsClassData",  //请求路径：页面/方法名字
        data: params,     //参数
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d.code == "01") {
                //var checkedstr2 = $(this).is(':checked');
                alert(data.d.msg);
                $("input[name='gradechkl'][value=\"" + vl + "\"]").prop("checked", "checked");
                //$("input[name='gradechk'][value='" + vl + "']").prop("checked", "checked");
                //checkedstr2 = $("input[name='gradechk'][value='"+gradecodestr+"']").prop("checked");
            } else {
                for (var i in grade) {
                    var ival = $(grade[i]).attr("value");
                    if (ival.substring(0, 1) == vl) {
                        $(grade[i]).prop("checked", tf);
                        if (!tf) {
                            $(grade[i]).removeAttr("checked");
                        }
                        else {
                            $(grade[i]).attr("checked", "checked");
                        }
                    }
                }
            }
        }
    });
})

//取消年级时先判断是否已存在班级信息。否则，不允许取消年级
/*
$("input[name='gradechk']").change(function () {
    var tf = $(this).is(':checked')
    if (tf) return true;
    var vl = $(this).attr("value");
    //ExistsClassData(vl);
    var params = "{\"schid\":\"" + schid + "\",\"gradecode\":\"" + vl + "\"}";
    var ExistsResult = "";
    $.ajax({
        type: "POST",  //请求方式
        url: "SchEdit.aspx/ExistsClassData",  //请求路径：页面/方法名字
        data: params,     //参数
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d == "1") {
                var checkedstr2 = $(this).is(':checked');
                alert("年级下面有班级数据，请先删除班级数据！");
                $("input[name='gradechk'][value='" + vl + "']").prop("checked", "checked");
                //checkedstr2 = $("input[name='gradechk'][value='"+gradecodestr+"']").prop("checked");
            } else {
                if (tf) {
                    var od = $("input[name='gradechkl'][value=" + vl.substring(0, 1) + "]");
                    $("input[name='gradechkl'][value=" + vl.substring(0, 1) + "]").prop("checked", true);
                    $("input[name='gradechk'][value=\"" + vl + "\"]").attr("checked", "checked");
                }
                else {
                    var grade = $("input[name='gradechk']");
                    $("input[name='gradechk'][value=\"" + vl + "\"]").removeAttr("checked");
                    var ii = 0;
                    for (var i = 0; i < grade.length; i++) {
                        var gradeval = $(grade[i]).attr("value");
                        var ss = gradeval.substring(0, 1);
                        var sss = vl.substring(0, 1);
                        if (gradeval.substring(0, 1) == vl.substring(0, 1)) {
                            var sssss = $(grade[i]).attr('checked');
                            if ($(grade[i]).attr('checked') == "checked") {
                                ii++;
                                break;
                            }
                        }
                    }
                    if (ii == 0) {
                        $("input[name='gradechkl'][value=" + vl.substring(0, 1) + "]").prop("checked", false);
                    }
                }
            }
        }
    });
});
*/