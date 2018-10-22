<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuE.aspx.cs" Inherits="SchWebMaster.Web.Student.StuE" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>Bootstrap表单组件金视野系统模板</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="../../assets/css/chosen.css" />
    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/bootstrap-select.css">
    <link rel="stylesheet" href="../../assets/css/metro.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>
    <style>
       .page-content {
            padding:0px;
        }
        .row {
            border-bottom: 1px dotted #e4e4e4;
            margin: 0px;
            font-size: 14px;
            color: #999999;
        }
        .widget-box {
            margin:0px;
            border:0px;
        }

        strong {
            margin-right: 15px;
            font-size: 14px;
            color: #393939;
        }
        .widget-body {
            border:0px;
        }
        .page-content {
            padding:0px;
        }
    </style>
</head>
<body>
    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>

        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
                <div class="breadcrumbs breadcrumb_box " id="breadcrumbs">
                    <script type="text/javascript">
                        try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
                    </script>

                    <ul class="breadcrumb breadcrumb_border ziti">
                        <li>
                            <%--<i class="icon-home home-icon"></i>--%>
                            目前位置：
                        </li>
                        <%--<li>
                            <a href="#">学校管理</a>
                        </li>--%>
                        <%--将学校信息改为学校及科目信息--%>
                        <li class="active">学生/家长及账号信息 </li>
                    </ul>
                    <!-- .breadcrumb -->
                    <div class="nav-search" id="nav-search">
                        <a class=" pull-right " href="javascript:window.history.go(-1);">
                            <i class="icon-reply icon-only"></i>
                            返回
                        </a>
                    </div>
                </div>
                <div class="page-content">
                    <input type="text" hidden="hidden" id="Stuid" value="<%=stuid %>" />
                    <input type="hidden" id="oldclassid" value="<%=stuclassid %>" />
                    <input type="hidden" id="oldclassname" value="<%=stuclass %>" />
                    <input type="hidden" id="oldgradeid" value="<%=stugradeid %>" />
                    <input type="hidden" id="oldgradename" value="<%=stugrade %>" />
                    <input type="hidden" id="CurrentTestNo" value="<%=stucode %>" />
                    <input type="hidden" id="schidhidden" value="<%=schid %>" />

                    <div class="widget-box">
                        <div class="widget-body">
                            <div class="widget-main">
                                <h4 class="header smaller lighter blue">年级班级</h4>
                                <div class="row">
                                    <div class="col-sm-3"><strong>学生年级:</strong><select id="nj" style="width: 100px"><%=drpgrade %></select></div>
                                    <div class="col-sm-9"><strong>年级领导:</strong><span id="njld" style="color: #808080"><%=stugradeboss %></span></div>

                                </div>
                                <div class="space-4"></div>
                                <div class="row">
                                    <div class="col-sm-3"><strong>学生班级:</strong><select id="bj" style="width: 100px"><%=drpclass %></select></div>
                                    <div class="col-sm-3"><strong>班&nbsp;&nbsp;主&nbsp; 任:</strong><span id="bzr" style="color: #808080;"><%=stuclassms %></span></div>
                                    <div class="col-sm-6"><strong>任课老师:</strong><span id="bjjs" style="color: #808080;"><%=stuclasstec %></span></div>
                                </div>
                                <div class="space-8"></div>
                                <h4 class="header smaller lighter blue">个人信息</h4>
                                <div class="row">
                                    <div class="col-sm-3"><strong>学生姓名:</strong><input type="text" id="StuName" data-toggle="tooltip" value="<%=stuname %>" placeholder="请输入中文姓名(必填)" maxlength="7" title="1-7个汉字长度,必填" onblur="checkTxt(this,'^.{1,7}$')" /></div>
                                    <div class="col-sm-3"><strong>系统编号:</strong><%=stuno %></div>
                                    <div class="col-sm-3"><strong>学/考&nbsp;&nbsp;号:</strong><input type="text" id="TestNo" placeholder="请输入考号(必填)" value="<%=stucode %>" onkeyup="isInteger(this)" data-toggle="tooltip" title="6-15位数字,必填" maxlength="15" onblur="checkTxt(this,'^[a-zA-Z0-9]{1,15}$')" /></div>
                                    <div class="col-sm-3">
                                        <strong>性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 别:</strong>
                                        <label>
                                            <input name="Sex" type="radio" checked="checked" value="1" class="ace">
                                            <span class="lbl neirong1">男</span>
                                        </label>
                                        &nbsp;&nbsp;    
                                        <label>
                                            <input name="Sex" type="radio" value="0" class="ace">
                                            <span class="lbl neirong1">女</span>
                                        </label>
                                    </div>
                                </div>
                                <div class="space-4"></div>
                                <div class="row">
                                    <div class="col-sm-3"><strong>手机号码:</strong><input type="text" id="TelNo" value="<%=stutel %>" data-toggle="tooltip" maxlength="11" placeholder="请正确输入11位手机号码" title="请输入正确的11位手机号" onblur="checkTxt(this,'^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$')" /></div>
                                    <div class="col-sm-3">
                                        <strong>是否走读:</strong><label>
                                            <input name="StudyType" type="radio" checked="checked" value="1" class="ace">
                                            <span class="lbl neirong1">是</span>
                                        </label>
                                        &nbsp;&nbsp;    
                                        <label>
                                            <input name="StudyType" type="radio" value="0" class="ace">
                                            <span class="lbl neirong1">否</span>
                                        </label>
                                    </div>
                                    <div class="col-sm-3"><strong>学生卡号:</strong><input type="text" id="CardNo" value="<%=stucard %>" readonly="readonly" placeholder="只能读取" /></div>
                                    <div class="col-sm-3 oldclass"><strong>原班级:</strong><%=stuocls %></div>
                                </div>
                                <div class="space-4"></div>
                                <div class="row">
                                    <div class="col-sm-12"><strong>学生住址:</strong><input type="text" id="Addr" value="<%=stuaddr %>" placeholder="请输入地址" data-toggle="tooltip" onblur="checkTxt(this,'^.{0,50}$')" maxlength="50" title="50个汉字" /></div>
                                </div>
                                <div class="space-8"></div>
                                <h4 class="header smaller lighter blue">家长信息</h4>
                                <div class="row">
                                    <div class="col-sm-3"><strong>姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名:</strong><input type="text" value="<%=stug1name %>" id="jzGenName1" placeholder="请输入家长姓名" maxlength="7" data-toggle="tooltip" /></div>
                                    <div class="col-sm-3"><strong>关&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;系:</strong><input type="text" value="<%=stug1rl %>" id="jzRelation1" maxlength="4" placeholder="请输入学生与家长关系" data-toggle="tooltip" /></div>
                                    <div class="col-sm-3"><strong>电&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;话:</strong><input type="text" value="<%=stug1rt %>" id="jzTelNo1" data-toggle="tooltip" onkeyup="isInteger(this)" maxlength="11" placeholder="请正确输入11位手机号" title="请输入正确的11位手机号" onblur="checkTxt(this,'^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$')" /></div>
                                    <div class="col-sm-3"><strong></strong></div>
                                </div>
                                <div class="space-4"></div>
                                <div class="row">
                                    <div class="col-sm-3"><strong>姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名:</strong><input type="text" value="<%=stug2name %>" id="jzGenName2" placeholder="请输入家长姓名" maxlength="7" /></div>
                                    <div class="col-sm-3"><strong>关&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;系:</strong><input type="text" value="<%=stug2rl %>" id="jzRelation2" maxlength="4" placeholder="请输入学生与家长关系 " data-toggle="tooltip" /></div>
                                    <div class="col-sm-3"><strong>电&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;话:</strong><input type="text" value="<%=stug2rt %>" maxlength="11" id="jzTelNo2" data-toggle="tooltip" onkeyup="isInteger(this)" placeholder="请正确输入11位手机号" title="请输入正确的11位手机号" onblur="checkTxt(this,'^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$')" /></div>
                                    <div class="col-sm-3"><strong></strong></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 text-right">
                            <button class="btn btn-info btn-sm" id="btndo" type="button" onclick="SaveData()">
                                <!--<i class="icon-ok bigger-110"></i>-->
                                保存
                            </button>
                            <button class="btn btn-sm" id="btndoreset" type="button" onclick="notdo()">
                                <%--<i class="icon-undo bigger-110"></i>--%>
                                                取消
                            </button>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        window.jQuery || document.write("<script src='../../assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
    </script>
    <script src="../../assets/js/bootstrap.min.js"></script>
    <script src="../../assets/js/typeahead-bs2.min.js"></script>
    <script src="../../assets/js/jquery-ui-1.10.3.custom.min.js"></script>
    <script src="../../assets/js/jquery.ui.touch-punch.min.js"></script>
    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>
    <script src="../../assets/js/bootstrap-select.js"></script>
    <script src="../../assets/js/bootstrap-tagsinput.js"></script>
    <script src="../../assets/js/jquery.ztree.all-3.5.min.js"></script>
    <script src="../../assets/js/i18n/defaults-zh_CN.min.js"></script>
    <script src="../../assets/js/learunui-validator.js"></script>
    <script src="../../assets/js/bootbox.min.js"></script>
    <script type="text/javascript">
        var type; 
        var schid=<%=schid%>;
        var dotype='<%=dotype%>';
        var stuid = '<%=stuid%>';
        
        if (dotype == "e") {   
            $("#nj").attr("disabled","disabled");
            $("#bj").attr("disabled","disabled");
            $("#title").text("保存");

            $("input[name='Sex'][value=" + <%=stusex%> + "]").attr("checked", true);
            $("input[name='StudyType'][value=" + <%=stustp%> + "]").attr("checked", true);            
            $("#btndo").html("保存");
            $(".oldclass").css("display","block");
        }
        else { 
            //type = 'A';//添加A
            $("#title").text("添加");//更新标题
            $("#btndo").html("保存");
            $(".oldclass").css("display","none");
        }
        function SaveData() {  //保存方法
            //学生信息  
            var selv=$("#schidhidden").val();
            var ClassId = $('#bj').val();
            var oldclassidstr = $("#oldclassid").val();
            var oldclassnamestr = $("#oldclassname").val();
            var oldgradeidstr = $("#oldgradeid").val();
            var oldgradenamestr = $("#oldgradename").val();
            var gradeid = $("#nj").val();
            var TestNo = $("#TestNo").val();
            var CurrentTestNo = $("#CurrentTestNo").val();
            if (TestNo.length<6 || TestNo.length>15) {
                Pridialog("学(考号)为6-15位数字！");
                return false;
            }
            var StuName = $("#StuName").val();
            if (isNotNull(StuName)==true) {
                Pridialog("学生姓名不能为空！");
                return false;
            }
            var Sex = $("input[name='Sex']:checked").val();
            var CardNo = $("#CardNo").val();
            var StudyType = $("input[name='StudyType']:checked").val();
            var TelNo = $("#TelNo").val();            
            var Addr = $("#Addr").val();
            //家长信息
            var Relation1 = $("#jzRelation1").val();
            var jzGenName1 = $("#jzGenName1").val();
            var jzTelNo1 = $("#jzTelNo1").val();

            var jzGenName2 = $("#jzGenName2").val();
            var jzTelNo2 = $("#jzTelNo2").val();
            var Relation2 = $("#jzRelation2").val();

            if(Relation1!=""&&(jzGenName1==""||jzTelNo1==""))
            {
                alert("请填写完善家长1信息");
                $("#jzGenName1").focus();
                return false;   
            }
            if((jzGenName1!=""&&jzTelNo1=="")||(jzGenName1==""&&jzTelNo1!=""))
            {
                alert("请填写完善家长1信息");
                $("#jzGenName1").focus();
                return false;   
            }
            
            if(Relation2!=""&&(jzGenName2==""||jzTelNo2==""))
            {
                alert("请填写完善家长2信息");
                $("#jzGenName2").focus();
                return false;   
            }
            if((jzGenName2!=""&&jzTelNo2=="")||(jzGenName2==""&&jzTelNo2!=""))
            {
                alert("请填写完善家长2信息");
                $("#jzGenName2").focus();
                return false;   
            }

            if (TelNo!="") {
                var length = TelNo.length;  
                if(length == 11 && /^(((13[0-9]{1})|(15[0-9]{1})|(17[0-9]{1})|(18[0-9]{1})|(14[0-9]{1})|)+\d{8})$/.test(TelNo) )   
                {   
                
                }else{   
                    alert("请输入正确的手机号码");
                    $("#TestNo").focus();
                    return false;   
                }   
            }
            if (jzTelNo1!="") {
                var length = jzTelNo1.length;  
                if(length == 11 && /^(((13[0-9]{1})|(15[0-9]{1})|(17[0-9]{1})|(18[0-9]{1})|(14[0-9]{1})|)+\d{8})$/.test(jzTelNo1) )   
                {   
                
                }else{   
                    alert("请正确输入第一位家长的手机号码");
                    $("#jzTelNo1").focus();
                    return false;   
                }   
            }
            if (jzTelNo2!="") {
                var length = jzTelNo2.length;  
                if(length == 11 && /^(((13[0-9]{1})|(15[0-9]{1})|(17[0-9]{1})|(18[0-9]{1})|(14[0-9]{1})|)+\d{8})$/.test(jzTelNo2) )   
                {   
                
                }else{   
                    alert("请输入正确第二位的手机号码");
                    $("#jzTelNo2").focus();
                    return false;   
                }   
            }
            if (ClassId==null) {
                Pridialog("请选择班级！");
                return false;
            }
            
            var params = '{"Stuid":"'+stuid+'","dotype":"'+dotype+'","schid":"' + selv + '","ClassId":"' + ClassId + '","TestNo":"' + TestNo + '","StuName":"' + StuName + '","Sex":"' + Sex + '", "CardNo":" ","StudyType":"' + StudyType + '","TelNo":"' + TelNo + '","Addr":"' + Addr + '","jzGenName1":"' + jzGenName1 + '","jzTelNo1":"' + jzTelNo1 + '","jzGenName2":"' + jzGenName2 + '","jzTelNo2":"' + jzTelNo2 + '","Relation1":"' + Relation1 + '","Relation2":"' + Relation2 + '","OldClassName":"' + oldclassnamestr + '","OldGradeId":"' + oldgradeidstr + '","OldGradeName":"' + oldgradenamestr + '","GradeId":"' + gradeid + '","OldClassId":"' + oldclassidstr + '","CurrentTestNo":"' + CurrentTestNo + '"}';//
            
            $.ajax({
                type: "POST",
                url: "StuE.aspx/schsave",
                dataType: "json",
                data:params, 
                contentType: "application/json; charset=utf-8",
                success: function (data) { 
                    if(data.d.code == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }
                    else if (data.d.code == "error") {
                        alert(data.d.msg);
                    }
                    else{
                        if(dotype=="a")
                        {
                            document.location.reload();
                        }
                        alert(data.d.msg);
                    }
                }
            });
            
        }

        
        //获取班级
        $('#nj').change(function () { 
            var selv = $('#nj').val();   
            schid = $('#asch').val();  
            var params = '{"tp":"1","id":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "StuE.aspx/getusers",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dd = eval("(" + data.d + ")");
                    $('#njld').html(dd.gradeboss);
                },
                error: function (obj, msg, e) {
                }
            });  
            var params = '{"typecode":"5","pcode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "StudentEdit.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) { 
                    $('#bj').html(data.d);
                    $('#bj').change();
                    $("#nj option").each(function () {
                        if ($(this).val() == selv) {
                            $(this).attr("selected", true);
                        }
                        else {
                            $(this).removeAttr("selected");
                        }

                    });
                },
                error: function (obj, msg, e) {
                }
            });
 

        });
        //获取班级
        $('#bj').change(function () {
            
            var selv = $('#bj').val();  
            var params = '{"tp":"2","id":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "StuE.aspx/getusers",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dd = eval("(" + data.d + ")");
                    $('#bjjs').html(dd.classtec);
                    $('#bzr').html(dd.classms);
                },
                error: function (obj, msg, e) {
                }
            });

        });
        function checkTxt(o,reg){
            var regu =reg;
            var re = new RegExp(regu);
            if (re.test($(o).val())) {
            }else{
                $(o).tooltip('show');
                $(o).focus();
            }
        }
        function checkTxtResult(o,reg){
            var regu =reg;
            var re = new RegExp(regu);
            if (re.test($(o).val())) {
                return true;
            }else{
                return false;
            }
        }
        function notdo(){
            window.history.go(-1);
        }
    </script>
</body>
</html>
