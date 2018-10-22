/*下面是学段与年级代码*/
$("input[name='gradechkl']").change(function () {
    var tf = $(this).is(':checked')
    var vl = $(this).attr("value");
    var grade = $("input[name='gradechk']");
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
});
$("input[name='gradechk']").change(function () {
    var tf = $(this).is(':checked')
    var vl = $(this).attr("value");
    if (tf) {
        var od = $("input[name='gradechkl'][value=" + vl.substring(0, 1) + "]");
        $("input[name='gradechkl'][value=" + vl.substring(0, 1) + "]").prop("checked", true);
        $(this).attr("checked", "checked");
    }
    else {
        var grade = $("input[name='gradechk']");
        $(this).removeAttr("checked");
        var ii = 0;
        for (var i = 0; i < grade.length; i++) {
            var gradeval = $(grade[i]).attr("value");
            if (gradeval.substring(0, 1) == vl.substring(0, 1)) {
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

});