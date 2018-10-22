//数据收集并存库函数
function saveuser() {
    var datasave = [];
    datasave.push("schid#" + schid);
    var schname = $("#schname").val(); datasave.push("schname#" + schname);
    if (schname == "") {
        alert("学校名称不允许为空");
        return false;
    }
    var areano = $("#acoty").val(); datasave.push("acoty#" + areano);
    var iscity = $("input[name=\"iscity\"]:checked").val(); datasave.push("iscity#" + iscity);
    var schaddr = $("#schaddr").val(); datasave.push("schaddr#" + schaddr);
    var schmaster = $("#schmaster").val(); datasave.push("schmaster#" + schmaster);
    if (schmaster == "") { alert("请输入系统管理员"); return false; }
    var schmasterpst = $("#schmasterpst").val(); datasave.push("schmasterpst#" + schmasterpst);
    var schmastertel = $("#schmastertel").val(); datasave.push("schmastertel#" + schmastertel);
    if (!checkTxt("#schmastertel", '^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$')) {
        alert("请正确输入管理员手机");
        return false;
    }
    var manageracount = $("#ManagerAcount").val(); datasave.push("manageracount#" + manageracount);
    if ($("#InitialPwd").val() == "123456") {
        if (!checkTxt("#InitialPwd", '(^$)|^([a-zA-Z0-9]{6,18})$')) {
            alert("密码为字母或数字的长度6-18位组合");
            return false;
        }
    }
    var initialpwd = $("#InitialPwd").val(); datasave.push("initialpwd#" + initialpwd);
    var frontlinetechni = $("#FrontlineTechni").val(); datasave.push("frontlinetechni#" + frontlinetechni);
    var creator = $("#Creator").val(); datasave.push("creator#" + creator);
    var principalname = $("#PrincipalName").val(); datasave.push("principalname#" + principalname);
    var principaltel = $("#PrincipalTel").val(); datasave.push("principaltel#" + principaltel);
    if (!checkTxt("#PrincipalTel", '^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$')) {
        alert("请正确输入校长手机");
        return false;
    }
    var customerservicestaffname = $("#CustomerServiceStaffName").val(); datasave.push("customerservicestaffname#" + customerservicestaffname);
    var customerservicestaffnameTel = $("#CustomerServiceStaffNameTel").val(); datasave.push("customerservicestaffnametel#" + customerservicestaffnameTel);
    if (!checkTxt("#CustomerServiceStaffNameTel", '^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$')) {
        alert("请正确输入客服人员手机");
        return false;
    }
    var platformname = $("#PlatformName").val(); datasave.push("platformname#" + platformname);
    var platformico = $("#PlatformIco").val(); datasave.push("platformico#" + platformico);
    var platformurl = $("#PlatformUrl").val(); datasave.push("platformurl#" + platformurl);
    var ipaddress = $("#IPAddress").val(); datasave.push("ipaddress#" + ipaddress);
    //var schsonsysenabletime = $("#SchSonSysEnableTime").val();datasave.push("schsonsysenabletime#"+schsonsysenabletime);
    var useridhidden = $("#useridhidden").val(); datasave.push("useridhidden#" + useridhidden);
    //var useridhidden = $("#useridhidden").val();datasave.push("useridhidden#"+useridhidden);

    var Perval = $("#Per").val(); datasave.push("per#" + Perval);
    if (Perval == null) {
        alert("学校类型不允许为空");
        return false;
    }
    var DrpMval = $("#DrpM").val(); datasave.push("drpm#" + DrpMval);
    if (DrpMval == null) {
        alert("入学月份不允许为空");
        return false;
    }
    //获取年级并合并年级信息
    var gradechkval = gradechk = $("input[name=\"gradechk\"]");
    var gradechklen = gradechk = $("input[name=\"gradechk\"]").length;
    var boolitemnull1 = 0; var boolitemnull2 = 0; var boolitemnull3 = 0; var boolitemnull4 = 0;
    var gradechk = "";
    var schoolsection = "";
    for (var i = 0; i < gradechklen; i++) {
        var s = $(gradechkval[i]).val();
        if (s.substring(0, 1) == "1") {
            if ($(gradechkval[i]).is(":checked")) {
                boolitemnull1++;
            }
        }
        if (s.substring(0, 1) == "2") {
            if ($(gradechkval[i]).is(":checked")) {
                boolitemnull2++;
            }
        }
        if (s.substring(0, 1) == "3") {
            if ($(gradechkval[i]).is(":checked")) {
                boolitemnull3++;
            }
        }
        if (s.substring(0, 1) == "4") {
            if ($(gradechkval[i]).is(":checked")) {
                boolitemnull4++;
            }
        }
    }
    if (boolitemnull1 != 0) {
        schoolsection += "1,";
    }
    if (boolitemnull2 != 0) {
        schoolsection += "2,";
    }
    if (boolitemnull3 != 0) {
        schoolsection += "3,";
    }
    if (boolitemnull4 != 0) {
        schoolsection += "4,";
    }
    schoolsection = schoolsection.substring(0, schoolsection.length - 1);
    var kindergarten = ""; var primarySchool = ""; var juniorHighSchool = ""; var highSchool = "";
    for (var i = 0; i < gradechklen; i++) {
        var gradecodestr = $(gradechkval[i]).val();
        var gradenamestr = $(gradechkval[i]).attr("GradeName");
        var startyearstr = $(gradechkval[i]).attr("startyear");
        var gradeid = $(gradechkval[i]).attr("GradeId");
        //if(boolitemnull1!=0){
        if (gradecodestr.substring(0, 1) == "1") {
            if ($(gradechkval[i]).is(":checked")) {
                kindergarten += gradecodestr + "|" + startyearstr + "|" + gradenamestr + "|" + gradeid + "|0,";
            } else {
                kindergarten += gradecodestr + "|" + startyearstr + "|" + gradenamestr + "|" + gradeid + "|2,";
            }
        }
        // }
        //if(boolitemnull2!=0){
        if (gradecodestr.substring(0, 1) == "2") {
            if ($(gradechkval[i]).is(":checked")) {
                primarySchool += gradecodestr + "|" + startyearstr + "|" + gradenamestr + "|" + gradeid + "|0,";
            } else {
                primarySchool += gradecodestr + "|" + startyearstr + "|" + gradenamestr + "|" + gradeid + "|2,";
            }
        }
        // }
        //if(boolitemnull3!=0){
        if (gradecodestr.substring(0, 1) == "3") {
            if ($(gradechkval[i]).is(":checked")) {
                juniorHighSchool += gradecodestr + "|" + startyearstr + "|" + gradenamestr + "|" + gradeid + "|0,";
            } else {
                juniorHighSchool += gradecodestr + "|" + startyearstr + "|" + gradenamestr + "|" + gradeid + "|2,";
            }
        }
        // }
        //if(boolitemnull4!=0){
        if (gradecodestr.substring(0, 1) == "4") {
            if ($(gradechkval[i]).is(":checked")) {
                highSchool += gradecodestr + "|" + startyearstr + "|" + gradenamestr + "|" + gradeid + "|0,";
            } else {
                highSchool += gradecodestr + "|" + startyearstr + "|" + gradenamestr + "|" + gradeid + "|2,";
            }
        }
        // }
    }
    //var selgrades = gradechk.substring(0,gradechk.length-1);//alert(selgrades);
    var kindergartenvalstr = kindergarten.substring(0, kindergarten.length - 1);
    var primarySchoolvalstr = primarySchool.substring(0, primarySchool.length - 1);
    var juniorHighSchoolvalstr = juniorHighSchool.substring(0, juniorHighSchool.length - 1);
    var highSchoolvalstr = highSchool.substring(0, highSchool.length - 1);
    //datasave.push("selgrades:"+selgrades);
    if (kindergartenvalstr == "" && primarySchoolvalstr == "" && juniorHighSchoolvalstr == "" && highSchoolvalstr == "") { alert("请选择学段"); return false; }
    datasave.push("kindergarten#" + kindergartenvalstr);
    datasave.push("primarySchool#" + primarySchoolvalstr);
    datasave.push("juniorHighSchool#" + juniorHighSchoolvalstr);
    datasave.push("highSchool#" + highSchoolvalstr);

    datasave.push("schoolsection#" + schoolsection);

    //获取科目数据
    var selsubs = $("#selsubs").val(); datasave.push("selsubs#" + selsubs);
    //获取子系统数据
    var sonsys = $("#sonsys").val();
    if (sonsys != null) {
        datasave.push("sonsys#1,2," + sonsys);
    } else {
        datasave.push("sonsys#1,2");
    }
    //子系统状态
    //var sonsystat = $("#SonsysStat .Enable").attr("rel");datasave.push("sonsystat#"+sonsystat);
    //var creator = $("#Creator").val();datasave.push("creator:"+creator);
    var resourceplatformname = $("#ResourcePlatformName").val(); datasave.push("resourceplatformname#" + resourceplatformname);
    var resourceplatformico = $("#ResourcePlatformIco").val(); datasave.push("resourceplatformico#" + resourceplatformico);
    var resourceplatformurl = $("#ResourcePlatformUrl").val(); datasave.push("resourceplatformurl#" + resourceplatformurl);
    var resourceplatformip = $("#ResourcePlatformIP").val(); datasave.push("resourceplatformip#" + resourceplatformip);

    //资料科目及教版
    var kinderstr = "";
    var kindergartenPer = $("#Per1").val();//幼儿园
    if ($("#Per1").is(":checked")) {
        var tagskindergarten = $("#Tags1").val();
        for (var i = 0; i < tagskindergarten.length; i++) {
            var kinderstrarr = tagskindergarten[i].split('|');
            kinderstr += kindergartenPer + "," + kinderstrarr[0] + "," + kinderstrarr[1] + "|";//格式：学段code，科目code，教版code
        }
    }
    datasave.push("kinderstr#" + kinderstr.substring(0, kinderstr.length - 1));
    var primarystr = "";
    var primaryPer = $("#Per2").val();//小学
    if ($("#Per2").is(":checked")) {
        var tagsprimary = $("#Tags2").val();
        for (var i = 0; i < tagsprimary.length; i++) {
            var primaryarr = tagsprimary[i].split('|');
            primarystr += primaryPer + "," + primaryarr[0] + "," + primaryarr[1] + "|";//格式：学段code，科目code，教版code
        }
    }
    datasave.push("primarystr#" + primarystr.substring(0, primarystr.length - 1));
    var juniorstr = "";
    var juniorPer = $("#Per3").val();//初中
    if ($("#Per3").is(":checked")) {
        var tagsjunior = $("#Tags3").val();
        for (var i = 0; i < tagsjunior.length; i++) {
            var juniorarr = tagsjunior[i].split('|');
            juniorstr += juniorPer + "," + juniorarr[0] + "," + juniorarr[1] + "|";//格式：学段code，科目code，教版code
        }
    }
    datasave.push("juniorstr#" + juniorstr.substring(0, juniorstr.length - 1));
    var highstr = "";
    var HighPer = $("#Per4").val();//高中
    if ($("#Per4").is(":checked")) {
        var tagshigh = $("#Tags4").val();
        for (var i = 0; i < tagshigh.length; i++) {
            var higharr = tagshigh[i].split('|');
            highstr += HighPer + "," + higharr[0] + "," + higharr[1] + "|";//格式：学段code，科目code，教版code
        }
    }
    datasave.push("highstr#" + highstr.substring(0, highstr.length - 1));

    //资源模块
    //var resourcearr = $("#tags-soures").val();
    var resourceitems = $("#tags-soures").tagsinput('items');
    var resourceModules = "";
    if (resourceitems) {
        for (var i = 0; i < resourceitems.length; i++) {
            var sv = '0';
            if (resourceitems[i].text.indexOf('【共享】') > -1)
                sv = '1';
            resourceModules += resourceitems[i].id + ',' +sv+ "|";
        }
        var resourceModules = resourceModules.substring(0, resourceModules.length - 1);
    }
    datasave.push("resourcemodules#" + resourceModules);
    var SourceServerStat = $("#SourceServerStat .Enable").attr("rel"); datasave.push("sourceserverstat#" + SourceServerStat);

    //var params = '{"schname":"' + schname + '","areano":"' + areano + '","iscity":"' + iscity + '","schaddr":"' + schaddr + '","schmaster":"' + schmaster + '","schmasterpst":"' + schmasterpst + '","schmastertel":"' + schmastertel + '","manageracount":"' + manageracount + '","initialpwd":"' + initialpwd + '","frontlinetechni":"' + frontlinetechni + '","creator":"'+creator+',"principalname":"' + principalname + '","principaltel":"' + principaltel + '","customerservicestaffname":"' + customerservicestaffname + '","customerservicestaffnameTel":"' + customerservicestaffnameTel + '","platformname":"' + platformname + '","platformico":"' + platformico + '","platformurl":"' + platformurl + '","ipaddress":"' + ipaddress + ',"selgrades":"' + selgrades + '","selsubs":"' + selsubs + '","sonsys":"' + sonsys + '"}';
    //家校互通基础数据收集
    var HomeSchoolingName = $("#HomeSchoolingName").val(); datasave.push("homeschoolingname#" + HomeSchoolingName);
    var HomeSchoolingIco = $("#HomeSchoolingIco").val(); datasave.push("homeschoolingico#" + HomeSchoolingIco);
    var HomeSchoolingUrl = $("#HomeSchoolingUrl").val(); datasave.push("homeschoolingurl#" + HomeSchoolingUrl);
    var HomeSchoolingIP = $("#HomeSchoolingIP").val(); datasave.push("homeschoolingip#" + HomeSchoolingIP);
    var HomeSchoolBaxicStat = $("#HomeSchoolBaxicStat .Enable").attr("rel"); datasave.push("homeschoolbaxicstat#" + HomeSchoolBaxicStat);
    var HomeSchoolServStat = $("#HomeSchoolServStat .Enable").attr("rel"); datasave.push("homeschoolservstat#" + HomeSchoolServStat);
    //家校互通科目及教版收集
    var homschkinderstr = "";
    var homschkinderPer = $("#HomSchPer1").val();//幼儿园
    if ($("#HomSchPer1").is(":checked")) {
        var tagskindergarten = $("#TagsHomSch1").val();
        for (var i = 0; i < tagskindergarten.length; i++) {
            var kinderstrarr = tagskindergarten[i].split('|');
            homschkinderstr += homschkinderPer + "," + kinderstrarr[0] + "," + kinderstrarr[1] + "|";//格式：学段code，科目code，教版code
        }
    }
    datasave.push("homschkinderstr#" + homschkinderstr.substring(0, homschkinderstr.length - 1));
    var homschprimarystr = "";
    var homschpriPer = $("#HomSchPer2").val();//小学
    if ($("#HomSchPer2").is(":checked")) {
        var tagsprimary = $("#TagsHomSch2").val();
        for (var i = 0; i < tagsprimary.length; i++) {
            var primaryarr = tagsprimary[i].split('|');
            homschprimarystr += homschpriPer + "," + primaryarr[0] + "," + primaryarr[1] + "|";//格式：学段code，科目code，教版code
        }
    }
    datasave.push("homschprimarystr#" + homschprimarystr.substring(0, homschprimarystr.length - 1));
    var homschjuniorstr = "";
    var homschjuniorPer = $("#HomSchPer3").val();//初中
    if ($("#HomSchPer3").is(":checked")) {
        var tagsjunior = $("#TagsHomSch3").val();
        for (var i = 0; i < tagsjunior.length; i++) {
            var juniorarr = tagsjunior[i].split('|');
            homschjuniorstr += juniorPer + "," + juniorarr[0] + "," + juniorarr[1] + "|";//格式：学段code，科目code，教版code
        }
    }
    datasave.push("homschjuniorstr#" + homschjuniorstr.substring(0, homschjuniorstr.length - 1));
    var homschhighstr = "";
    var homschHighPer = $("#HomSchPer4").val();//高中
    if ($("#HomSchPer4").is(":checked")) {
        var tagshigh = $("#TagsHomSch4").val();
        for (var i = 0; i < tagshigh.length; i++) {
            var higharr = tagshigh[i].split('|');
            homschhighstr += homschHighPer + "," + higharr[0] + "," + higharr[1] + "|";//格式：学段code，科目code，教版code
        }
    }
    datasave.push("homschhighstr#" + homschhighstr.substring(0, homschhighstr.length - 1));
    //家校互通子模块收集
    var homscharr = $("#tags-homeSching").val(); datasave.push("homschmodules#" + homscharr);
    //var params='{"datastr":'+datasave+'}';
    
    $.ajax({
        type: "POST",  //请求方式
        url: "SchEdit.aspx/schsave",  //请求路径：页面/方法名字
        data: JSON.stringify({ arr: datasave }),     //参数
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d.code == "expire") {
                alert(data.d.msg);
                window.location.href = "../../LoginExc.aspx";
            } else if (data.d.code == "Success") {
                alert(data.d.msg);
                window.history.go(-1);
            }else {
                alert(data.d.msg);
            }
            /*
            if (data.d == 'success') {
                alert("操作成功");
                window.location.href = "SchInfo.aspx";

            } else if (data.d == "success01") {
                alert("年级下面有班级数据，请先删除班级数据！");
            } else if (data.d == "success02") {
                alert("账号不允许为空！");
            } else if (data.d == "expire") {
                window.location.href = "../../LoginExc.aspx";
            } else if (data.d == "success03") {
                alert("请正确输入管理平台IP地址");
            } else if (data.d == "success04") {
                alert("请正确输入资源平台IP地址");
            } else if (data.d == "success05") {
                alert("请正确输入家校互通平台IP地址");
            } else {
                alert(data.d);
            }*/
        },
        error: function (obj, msg, e) {
        }
    });
    
}