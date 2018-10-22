///
///学校编辑页面初始化赋值
///


if (usermanager == null) {
    //$("#ManagerAcount").removeAttr("readonly");
    $("#resetPwd").css("display", "none");
    $("#InitialPwd").attr("class", "col-sm-12");
    $(".initpwd").html("初始密码:");
}
//用户赋值 
if (usermanager != "1" && usermanager != null) {
    $("#ManagerAcount").val(usermanager.UserName);
    //if (usermanager.UserName == "") {
    //    $("#ManagerAcount").removeAttr("readonly");
    //}
    $("#useridhidden").val(usermanager.UserId);
    if (usermanager.PassWord == "1") {
        $("#InitialPwd").attr("type", "text");
        $("#InitialPwd").val("123456");
        $(".initpwd").html("初始密码");
        $("#resetPwd").css("display", "none");
        $("#InitialPwd").attr("class", "col-xs-12 col-sm-12");
    } else {
        $(".initpwd").html("密码");
        $("#InitialPwd").val(usermanager.PassWord);
    }
}
if (umodel != "1") {
    $('#SchIdstr').val(PreFixInterge(umodel.SchId, 8));
    $('#schname').val(umodel.SchName);
    $('#schaddr').val(umodel.SchAddr);
    $('#schmaster').val(umodel.SchMaster);
    $('#schmasterpst').val(umodel.MasterPostion);
    $('#schmastertel').val(umodel.SchTel);
    $('#schnote').val(umodel.SchNote);
    $('#Per').val(umodel.SchType);
    $('#DrpM').val(umodel.OpenMonth);
    $("input[name='iscity'][value=" + umodel.IsCity + "]").attr("checked", true);
    $("input[name='schstat'][value=" + umodel.Stat + "]").attr("checked", true);
    //usersub SubId  $("input[name='radioName'][checked]").val(); 
    //$("#tags-depts").val(umodel.Artisan);
    $("#PrincipalName").val(umodel.PrincipalName);
    $("#PrincipalTel").val(umodel.PrincipalTel);
    $("#CustomerServiceStaffName").val(umodel.ServiceName);
    $("#CustomerServiceStaffNameTel").val(umodel.ServiceTel);
    $("#FrontlineTechni").val(umodel.Artisan);
    $("#PlatformName").val(umodel.PlatformName);
    $("#PlatformIco").val(umodel.PlatformIco);
    $("#PlatformIcoimg").attr("src", "../.." + umodel.PlatformIco);
    if (umodel.PlatformIco) {
        $("#PlatformIcoimg").css("display", "block");
    }
    $("#PlatformUrl").val(umodel.PlatformUrl);
    $("#IPAddress").val(umodel.PlatformIP);

    $("#ResourcePlatformName").val(umodel.ResourcePlatformName);
    $("#ResourcePlatformIco").val(umodel.ResourcePlatformIco);
    $("#ResourcePlatformIcoimg").attr("src", "../.." + umodel.ResourcePlatformIco);
    if (umodel.ResourcePlatformIco) {
        $("#ResourcePlatformIcoimg").css("display", "block");
    }
    $("#ResourcePlatformUrl").val(umodel.ResourcePlatformUrl);
    $("#ResourcePlatformIP").val(umodel.ResourcePlatformIP);
    $("#Creator").val(umodel.SchCreator);
    $("#SchSonSysEnableTime").val(umodel.SchSonSysEnableTime);
    if (umodel.SonSysStat == "1") {
        $("#SonsysStat").html("<span class=\"Enable\" style=\"color:green;\" rel=\1\">正常使用</span>");
    } else {
        $("#SonsysStat").html("<span class=\"Enable\" style=\"color:#000;\"  rel=\"0\">停用</span>");
    }
    if (umodel.SourceSerStat == "1") {
        $("#SourceServerStat").html("<span class=\"Enable\" style=\"color:green;\" rel=\"1\">正常使用</span>");
    } else {
        $("#SourceServerStat").html("<span class=\"Enable\" style=\"color:#000;\"  rel=\"0\">停用</span>");
    }
    $("#Creator").val(umodel.SchCreator);
    //家校互通平台
    $("#HomeSchoolingName").val(umodel.HomeSchPlatName);
    $("#HomeSchoolingIco").val(umodel.HomeSchPlatIco);
    $("#HomeSchoolingImg").attr("src", "../.." + umodel.HomeSchPlatIco);
    if (umodel.HomeSchPlatIco) {
        $("#HomeSchoolingImg").css("display", "block");
    }
    $("#HomeSchoolingUrl").val(umodel.HomeSchPlatUrl);
    $("#HomeSchoolingIP").val(umodel.HomeSchPlatIP);
    $("#HomeSchoolBaxicStat .Enable").attr("rel", umodel.HomeSchBasicStat);
    //客服维护值为0；学校维护值为1 ... ...
    if (umodel.SonSysStat == "1" || umodel.SourceSerStat == "1") {
        $("#HomeSchoolBaxicStat .Enable").html("学校维护");
        $("#HomeSchoolBaxicStat .Enable").attr("rel", "1");
        $("#HomeSchoolBaxicStat .Enable").css("color", "green");
    } else {
        //if (umodel.Homeschbasicuser == 0) {
            $("#HomeSchoolBaxicStat .Enable").html("客服维护");
            $("#HomeSchoolBaxicStat .Enable").attr("rel", "0");
            $("#HomeSchoolBaxicStat .Enable").css("color", "green");
        //} else {
        //    $("#HomeSchoolBaxicStat .Enable").html("学校维护");
        //    $("#HomeSchoolBaxicStat .Enable").attr("rel", "1");
        //    $("#HomeSchoolBaxicStat .Enable").css("color", "green");
        //}
    }
    //停用值为0；已启用值为1。
    if (umodel.HomeschServStat == 1) {
        $("#HomeSchoolServStat .Enable").html("正常使用");
        $("#HomeSchoolServStat .Enable").val("rel", "1");
        $("#HomeSchoolServStat .Enable").css("color", "green");
    } else {
        $("#HomeSchoolServStat .Enable").html("停用");
        $("#HomeSchoolServStat .Enable").val("rel", "0");
    }
}

//給畢業年級初始化
if (updateGradeDataObj) {
    var kindergarten = ""; var primaryschool = ""; var juniorschool = ""; var highschool = "";
    $.each(updateGradeDataObj, function (name, item) {
        if (item.GradeYear == null) {
            item.GradeYear = "1999";
        }
        var sear01 = new RegExp('班');
        var sear02 = new RegExp('年级');
        var sear03 = new RegExp('初');
        var sear04 = new RegExp('高');
        if (sear01.test(item.GradeName)) {
            kindergarten += item.GradeName + "[" + item.GradeYear + "级]、";
        } else if (sear02.test(item.GradeName)) {
            primaryschool += item.GradeName + "[" + item.GradeYear + "级]、";
        } else if (sear03.test(item.GradeName)) {
            juniorschool += item.GradeName + "[" + item.GradeYear + "级]、";
        } else if (sear04.test(item.GradeName)) {
            highschool += item.GradeName + "[" + item.GradeYear + "级]、";
        }
    });
    if (kindergarten != "") {
        $("#kindergartendom").html("幼儿园：" + kindergarten.substring(0,kindergarten.length-1));
    }
    if (primaryschool != "") {
        $("#primaryschooldom").html("小学：" + primaryschool.substring(0, primaryschool.length - 1));
    }
    if (juniorschool != "") {
        $("#juniorschooldom").html("初中：" + juniorschool.substring(0, juniorschool.length - 1));
    }
    if (highschool != "") {
        $("#highschooldom").html("高中：" + highschool.substring(0, highschool.length - 1));
    }
}
//遍历学段、年级的DOM
var SchoolSection = "";
var mydate = new Date();
var sysyearcurrent = mydate.getFullYear();
var sysmonth = mydate.getMonth();
var StartYear = "";
if (sysmonth < 8) { StartYear = sysyearcurrent - 1; } else { StartYear = sysyearcurrent; }
$.each(treegradesNodes, function (index, item) {
    if (item.pId == "0") {
        //alert(item.GradeYear);
        SchoolSection += "<div class=\"row\">";
        SchoolSection += "    <div class=\"col-sm-1 no-padding\">";
        SchoolSection += "        <label>&nbsp;&nbsp;<span class=\"color\">学段：</span></label>";
        SchoolSection += "        <label>";
        SchoolSection += "            <input name=\"gradechkl\" type=\"checkbox\" class=\"ace\" value=\"" + item.id + "\" />";
        SchoolSection += "            <span class=\"lbl\">" + item.name + "</span>";
        SchoolSection += "        </label>";
        SchoolSection += "    </div>";
        //SchoolSection+="    <div class=\"col-sm-11 no-padding\">";
        SchoolSection += "    <div class=\"col-sm-1 no-padding text-center nianji\"><label><span class=\"color\">年级：</span></label></div>";
        SchoolSection += "    <div class=\"col-sm-10 no-padding\">";
        SchoolSection += "    <div class=\"row\">";
        $.each(treegradesNodes, function (indexs, items) {
            if (item.id == items.pId && items.IsFinish == "0") {
                SchoolSection += "<div class=\"col-sm-2 no-padding\">";
                SchoolSection += "    <label>";
                SchoolSection += "        <input name=\"gradechk\" type=\"checkbox\" class=\"ace\" StartYear=\"" + StartYear + "\" GradeName=\"" + items.name + "\" GradeId=\"" + items.GradeId + "\" value=\"" + items.id + "\" disabled=\"disabled\">";
                SchoolSection += "        <span class=\"lbl\">" + items.name + "【" + StartYear + "级】</span>";
                SchoolSection += "    </label>";
                SchoolSection += "</div>";
                StartYear--;
            }
        })
        SchoolSection += "    </div>";
        SchoolSection += "    </div>";
        SchoolSection += "    </div>";
        //SchoolSection+="</div>";
    }

    if (item.id == "1" || item.id == "2" || item.id == "3" || item.id == "4") {
        if (sysmonth < 8) {
            StartYear = sysyearcurrent - 1;
        } else {
            StartYear = sysyearcurrent;
        }
    }

});
$("#SchoolSection").html(SchoolSection);