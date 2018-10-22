<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentEdit.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.UserFuncSoure.StudentEdit" %>

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
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300" />
    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/bootstrap-select.css">
    <link rel="stylesheet" href="../../assets/css/metro.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>
    <style>
        /*所在位置的背景边框*/
         .breadcrumb_box {
            background: white;
            border-bottom: 1px solid #e4e4e4;
            /*color: #333333;*/
        }
        /*所在位置的提示高度*/
        .breadcrumbs {
            min-height:32px;
            line-height:30px;
        }
         /*坐在位置的坐边竖线*/
        .breadcrumb_border {
            border-left: 2px solid #63bbff;
            margin-left: 0px;
            padding-left: 12px;
            /*padding-top: 4px;
            padding-bottom: 4px;*/
        }
        /*位置提示字体大小*/
        .breadcrumb > li {
            font-size:13px !important;
            color:#666666 !important;
        }
        /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }

        i {
            font-family: FontAwesome !important;
        }
         /*定义标题大小*/
        .biaoti { 
            font-size:13px;
            color:#000000;
        }
        /*年级班级中的下拉选框中的颜色大小*/
         .biaoti select {
             margin-left:10px;
             margin-right:10px;
            font-size:12px;
            color:#999999 !important;
        }
         /*年级班级中的下拉选框后边的提示语的颜色大小*/
         .biaoti span {
            font-size:12px;
            color:#999999 !important;
        }
        /*定义内容大小*/
        .neirong { 
           color:#999999 !important;
            font-size:13px !important;
            
        }
        .neirong1 { 
           color:#999999 !important;
            font-size:12px !important;
            
        }
        /*表格中的每个单元格的内边距*/
        .table_box tr th {
            padding-left:20px;
            padding-right:20px; 
        }
        /*去掉表格中输入框的边框*/
        .input_style {
            border:none !important;
        }
        /*每行的行高*/
        .lheight {
            line-height:30px !important;
        }
        /*是否走读单选框的间距*/
        .jianju {
            padding-left:24px;
        }
         /*本页表格标题栏字体大小，颜色*/
      
        .liebiaobiaoti
        {
            font-size:13px !important;
            color:#444444 !important;
            font-weight:bold !important;
            letter-spacing:1px !important;
            text-align:center !important;
            line-height:1.5 !important;
        }
        /*表格的内容区字体大小颜色*/
        .table tbody tr td {
            color:#666666 !important;
            font-size:13px !important;
             text-align:center !important;
             line-height:1.5 !important;
        }
        
        .search {
            margin-right:10px;
            margin-left:10px;
            font-size:14px;
            color:#333333;
        }
         input[type="text"] {
            color:#999999;
            font-size:12px;
            margin-left:6px;
        }
         /*input中placeholder的颜色*/
       input::-webkit-input-placeholder, textarea::-webkit-input-placeholder { /* WebKit*/  
            color:#999999;
            font-size:12px;
              
        }  
        input:-moz-placeholder, textarea:-moz-placeholder { /* Mozilla Firefox 4 to 18 */  
            color:#999999; 
            font-size:12px;  
        }  
        input::-moz-placeholder, textarea::-moz-placeholder { /* Mozilla Firefox 19+ */  
            color:#999999; 
            font-size:12px;  
        }  
        input:-ms-input-placeholder, textarea:-ms-input-placeholder { /* IE 10+ */  
            color:#999999; 
            font-size:12px;  
        } 
        input:disabled { 
            color:#999999 !important;
        }
       .breadcrumb > li + li:before {
            content:"";
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
                    
                
                </div>
                <style>
                    .thth {
                        text-align: right;
                        width: 110px;
                    }
                </style>
                <div class="page-content">
                    
                        <%--<h1>用户管理
								<small>
                                    <i class="icon-double-angle-right"></i>
                                    用户操作(学校:<%=schname %>)
                                </small>
                        </h1>--%>
                        <div class="nav-search" id="nav-search">
                            <a class=" pull-right " href="javascript:window.history.go(-1);">
                                <i class="icon-reply icon-only"></i>
                                返回
                            </a>
                        </div>
                    <div class="row row col-sm-9 col-sm-offset-1">
                        <div class="row">
                                    <div class="col-sm-12 ">
                                        <div class="col-sm-12 text-right">
                                            <button class="btn btn-info btn-sm" id="btndo" type="button" onclick="SaveData()">
                                                <!--<i class="icon-ok bigger-110"></i>-->
                                                保存
                                            </button>

                                            &nbsp; &nbsp; &nbsp;
											<button class="btn btn-sm" id="btndoreset" type="button" onclick="notdo()">
                                                <%--<i class="icon-undo bigger-110"></i>--%>
                                                取消
                                            </button>

                                        </div>
                                    </div>
                                </div>
                        <div class="row">
                            <div class="col-xs-12 no-padding-left">
                                <div class="col-sm-12 no-padding-left">
                                    <div class="col-sm-10 no-padding-left">
                                        <div class="input-group biaoti" >
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <%=areastr %>
                                        </div>
                                    </div> 
                                </div>
                            </div>
                        </div>
                        <div class="row">
                        <div class="col-xs-12 no-padding-left">
                            <input type="text" hidden="hidden" id="Stuid" />
                            <input type="text" hidden="hidden" id="Unid1" />
                            <input type="text" hidden="hidden" id="Unid2" />
                            <input type="text" hidden="hidden" id="Genid1" />
                            <input type="text" hidden="hidden" id="Genid2" />
                            <input type="hidden" id="oldclassid" />
                            <input type="hidden" id="oldclassname" />
                            <input type="hidden" id="oldgradeid" />
                            <input type="hidden" id="oldgradename" />
                            <input type="hidden" id="CurrentTestNo" />
                            <form class="form-horizontal" role="form">
                                <div class=" form-inline lheight">
                                     <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">系统编号:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <input type="text"  id="bh" readonly="readonly" placeholder="" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right  text-right">
                                            <label class="biaoti">学(考号):</label>
                                        </div>
                                        <div class="col-sm-8">

                                            <input type="text" id="TestNo" placeholder="请输入考号(必填)" onkeyup="isInteger(this)" data-toggle="tooltip" title="6-15位数字,必填" maxlength="15" onblur="checkTxt(this,'^[a-zA-Z0-9]{1,15}$')" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">姓名:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <input type="text" id="StuName" data-toggle="tooltip" placeholder="请输入中文姓名(必填)" maxlength="7"  title="1-7个汉字长度,必填" onblur="checkTxt(this,'^.{1,7}$')" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">性别:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <div class="control-group col-xs-12 col-sm-12">
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
                                    </div>
                                    
                                </div>
                                <div class=" form-inline  lheight">
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">手机号:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <input type="text" id="TelNo" data-toggle="tooltip" maxlength="11" placeholder="请正确输入11位手机号码" title="请输入正确的11位手机号" onblur="checkTxt(this,'^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$')" class="col-xs-12 col-sm-12 " />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">地址:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <input type="text" id="Addr" placeholder="请输入地址" data-toggle="tooltip" onblur="checkTxt(this,'^.{0,50}$')" title="50个汉字" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">是否走读:</label>
                                        </div>
                                        <div class="col-sm-8 jianju">
                                            <label>
                                                <input name="StudyType" type="radio" checked="checked" value="1" class="ace">
                                                <span class="lbl neirong1">是</span>
                                            </label>
                                            &nbsp;&nbsp;    
                                        <label>
                                            <input name="StudyType" type="radio" value="0" class="ace">
                                            <span class="lbl neirong1">否</span>
                                        </label>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">学生卡地址:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <input type="text"  id="CardNo" readonly="readonly" placeholder="只能读取" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                  
                                </div>

                                 <div class=" form-inline  lheight">
                                   <div class="col-sm-3 oldgrade" style="display:none;">
                                      <%--   <div class="col-sm-4 no-padding-right text-right biaoti">
                                             原班级:
                                        </div>
                                        <div class="col-sm-8 neirong1" id="oldClassName">
                                            1061(高一)
                                        </div>--%>
                                    </div>
                                     </div>
                                <!-- 暂时注释掉账号密码
                                <div class="form-group form-inline">
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right" >
                                            <label>账号:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <span class="input-icon input-icon-right ">
                                                <input type="text" id="LoginName" placeholder="请输入账号"  />

                                                <i class="icon-white badge badge-info" style="color: white; font-size: 10px; width: 65px; height: 28px"><a style="color: white;" onclick="Make(1)" href="#">自动生成</a></i>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label>密码:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <input type="password" id="Pwd" placeholder="请输入密码" class="col-xs-12 col-sm-12" />
                                            <%--data-toggle="tooltip" title="必填,字母和数字的长度6-18位组合" onblur="checkTxt(this,'^[a-zA-Z0-9]{6,18}$')"--%> 
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label>账号状态:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <div class="control-group col-xs-12 col-sm-12">
                                                <label>
                                                    <input name="Stat" type="radio" checked="checked" value="1" class="ace">
                                                    <span class="lbl">正常</span>
                                                </label>
                                                &nbsp;&nbsp;
                                        <label>
                                            <input name="Stat" type="radio" value="0" class="ace">
                                            <span class="lbl">停用</span>
                                        </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                       
                                    </div> 
                                </div>
                                    -->
                                <div class="col-sm-12" style="margin-bottom:10px">
                                    <div class="col-sm-1  no-padding-right text-right" style="display:none;">
                                       <span style="color: red">备注：</span>
                                        </div> 
                                    <div class="col-sm-11" style="display:none;">
                                        <span style="color: red">点击自动生成后获取电话号码为账号，电话后六位为密码</span>
                                        </div>
                                    </div>
                               <div class="form-group form-inline  ">
                                    <div class="col-sm-12">
                                        <div class="col-sm-1 no-padding-right text-right biaoti"> 
                                            家长信息：
                                        </div>
                                         <div class="col-sm-11">
                                    <div>
                                        <div>
                                            <table class="table_box" width="100%" border="1" bordercolor="#E4E4E4">
                                                <tr style="height: 40px; background-color: #EAF9FF">
                                                    <th style="text-align: center; width: 170px">
                                                        <label class="liebiaobiaoti">姓名</label>
                                                    </th>
                                                    <th style="text-align: center; width: 160px">
                                                        <label class="liebiaobiaoti">关系</label>
                                                    </th>
                                                    <th style="text-align: center; width: 170px">
                                                        <label class="liebiaobiaoti">电话</label>
                                                    </th>
                                                    <%--隐藏账号等信息--%>
                                                    <%--<th style="text-align: center; width: 180px">
                                                        <label>账号</label>
                                                    </th>
                                                    <th style="text-align: center; width: 170px">
                                                        <label>密码</label>
                                                    </th>
                                                    <th style="text-align: center; width: 170px">
                                                        <label>账号状态</label>
                                                    </th>--%>
                                                </tr>
                                                <tr style="height: 50px">
                                                    <th style="text-align: center;">
                                                        <input class="neirong col-sm-12 input_style text-center " type="text" id="jzGenName1" placeholder="请输入家长姓名" maxlength="7" data-toggle="tooltip"  />
                                                    </th>
                                                    <th style="text-align: center;">
                                                        <input class="neirong col-sm-12 input_style text-center " type="text" id="jzRelation1" maxlength="4" placeholder="请输入学生与家长关系" data-toggle="tooltip"  />

                                                    </th>
                                                    <th style="text-align: center;">
                                                        <input class="neirong col-sm-12 input_style text-center" type="text" id="jzTelNo1" data-toggle="tooltip" onkeyup="isInteger(this)" maxlength="11" placeholder="请正确输入11位手机号" title="请输入正确的11位手机号" onblur="checkTxt(this,'^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$')" />
                                                    </th>
                                                    <%--隐藏账号等信息--%>
                                                   <%-- <th style="text-align: center;">
                                                        <span class="input-icon input-icon-right ">
                                                            <input type="text" id="jzLoginName1" placeholder="请输入账号"  />
                                                            <i class="icon-white badge badge-info" style="color: white; font-size: 10px; width: 65px; height: 28px"><a style="color: white;" onclick="Make(2)" href="#">自动生成</a></i>
                                                        </span>
                                                    </th>
                                                    <th style="text-align: center;">
                                                        <input type="password" id="jzPwd1" placeholder="请输入密码"  maxlength="6"/>
                                                    </th>
                                                    <th style="text-align: center;">
                                                        <label>
                                                            <input name="jzStat1" type="radio" checked="checked" value="1" class="ace">
                                                            <span class="lbl">正常</span>
                                                        </label>
                                                        <label>
                                                            <input name="jzStat1" type="radio" value="0" class="ace">
                                                            <span class="lbl">停用</span>
                                                        </label>
                                                    </th>--%>
                                                </tr>
                                                <tr style="height: 50px">
                                                    <th style="text-align: center;">
                                                        <input class="neirong col-sm-12 input_style text-center" type="text" id="jzGenName2" placeholder="请输入家长姓名" maxlength="7"   /></th>
                                                    <th style="text-align: center;">
                                                        <input class="neirong col-sm-12 input_style text-center" type="text" id="jzRelation2" maxlength="4" placeholder="请输入学生与家长关系 " data-toggle="tooltip"   />

                                                    </th>
                                                    <th style="text-align: center;">
                                                        <input class="neirong col-sm-12 input_style text-center" type="text" maxlength="11" id="jzTelNo2" data-toggle="tooltip" onkeyup="isInteger(this)"   placeholder="请正确输入11位手机号" title="请输入正确的11位手机号" onblur="checkTxt(this,'^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$')" />
                                                    </th>
                                                    <%--隐藏账号等信息--%>
                                                   <%-- <th style="text-align: center;">
                                                        <span class="input-icon input-icon-right ">
                                                            <input type="text" id="jzLoginName2" placeholder="请输入账号"   />
                                                            <i class="icon-white badge badge-info" style="color: white; font-size: 10px; width: 65px; height: 28px"><a style="color: white;" onclick="Make(3)" href="#">自动生成</a></i>
                                                        </span>
                                                    </th>
                                                    <th style="text-align: center;">
                                                        <input type="password" id="jzPwd2" placeholder="请输入密码"   />
                                                    </th>
                                                    <th style="text-align: center;">
                                                        <label>
                                                            <input name="jzStat2" type="radio" value="1" checked="checked" class="ace">
                                                            <span class="lbl">正常</span>
                                                        </label>

                                                        <label>
                                                            <input name="jzStat2" type="radio" value="0" class="ace">
                                                            <span class="lbl">停用</span>
                                                        </label>
                                                    </th>--%>
                                                    <input type="hidden" id="schidhidden" value="<%=schid %>" />
                                                </tr>
                                            </table> 
                                        </div>
                                    </div>
                                </div>
                                    </div>
                                </div>
                               
                            </form>
                            <!-- PAGE CONTENT ENDS --> 
                        </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />

                    <!--<div>
                        <div class="col-md-offset-3"style="text-align:center">
                            <button class="btn btn-info" type="button" onclick="Save()">
                                <i class="icon-ok bigger-110"></i>
                                <span id="title"></span>
                            </button>

                            &nbsp; &nbsp; &nbsp;
											<button class="btn" type="reset">
                                                <i class="icon-undo bigger-110"></i>
                                                Reset
                                            </button>
                        </div>
                    </div>-->
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
        //用户赋值
        var umodel=<%=umodelstr%>;
        var classinfo=<%=classinfo%>;
        var oldClassName="<%=oldClassName%>";
        var gradecodestr="<%=gradecodestr%>";
        var classidstr="<%=classidstr%>";
        var Stubh="<%=Stubh%>";
        
        if (umodel != "1") {   
            //type = 'E';//编辑E
            $("#bh").val(Stubh);
            $("#Stuid").val(umodel[0].StuId);
            $("#title").text("保存");
            $('#StuName').val(umodel[0].StuName);
            //$("#PriClass option:selected").val(umodel[0].ClassId);
            $("#oldclassid").val(classinfo[0].ClassId);
            //$("#oldclassname").val(classinfo[0].ClassName);
            $("#oldgradeid").val(classinfo[0].GradeCode);
            $("#oldgradename").val(classinfo[0].GradeName);
            $("#TestNo").val(umodel[0].TestNo);
            $("#CurrentTestNo").val(umodel[0].TestNo);
            $("input[name='Sex'][value=" + umodel[0].Sex + "]").attr("checked", true);
            //$("#Dutie").val(umodel[0].Dutie);
            $("#CardNo").val(umodel[0].CardNo);
            $("input[name='StudyType'][value=" + umodel[0].StudyType + "]").attr("checked", true);
            $("#TelNo").val(umodel[0].TelNo); 
            $("#LoginName").val(umodel[0].LoginName);
            $("#Pwd").val(umodel[0].Pwd); 
            $("#Addr").val(umodel[0].Addr);
            $("input[name='Stat'][value=" + umodel[0].Stat + "]").attr("checked", true);
            //返回家长信息
            $("#jzGenName1").val(umodel[0].jzGenName1);
            $("#jzTelNo1").val(umodel[0].jzTelNo1);
            $("#jzLoginName1").val(umodel[0].jzLoginName1);
            $("#jzPwd1").val(umodel[0].jzPwd1);
            $("input[name='jzStat1'][value=" + umodel[0].jzStat1 + "]").attr("checked", true);
            var ss = umodel[0].jzGenName2;
            $("#jzGenName2").val(umodel[0].jzGenName2);
            $("#jzTelNo2").val(umodel[0].jzTelNo2);
            $("#jzLoginName2").val(umodel[0].jzLoginName2);
            $("#jzPwd2").val(umodel[0].jzPwd2);
            $("input[name='jzStat2'][value=" + umodel[0].jzStat2 + "]").attr("checked", true);
            //$(".ss2").find("option[value='" + umodel[0].Relation + "']").attr("selected", true);
            //$(".ss3").find("option[value='" + umodel[1].Relation + "']").attr("selected", true);
            $("#jzRelation1").val(umodel[0].jzRelation1); $("#jzRelation2").val(umodel[0].jzRelation2);
            $("#Unid1").val(umodel[0].jzUnId1); 
            $("#Unid2").val(umodel[0].jzUnId2);
            $("#Genid1").val(umodel[0].jzGenId1); 
            $("#Genid2").val(umodel[0].jzGenId2);
            $("#btndo").html("保存");
            //$(".oldgrade").css("display","block");
            if(oldClassName!=""){
                $(".oldgrade").css("display","block");
                $("#oldClassName").html(oldClassName);
            }else{
                $(".oldgrade").css("display","none");
            }
        }
        else { 
            //type = 'A';//添加A
            $("#title").text("添加");//更新标题
            $("#btndo").html("保存");
        }
        
        //点击自动生成获取账号密码 type=1为学生账号生成，type=2家长账号生成，type=3家长账号生成
        function Make(type) {
            if (type == 1) {
                var TelNo = $("#TelNo").val();
                $("#LoginName").val(TelNo);
                var Pwd = TelNo.substring(5);
                $("#Pwd").val(Pwd);
            } else if (type == 2) {
                var jzTelNo1 = $("#jzTelNo1").val();
                $("#jzLoginName1").val(jzTelNo1);
                var jzPwd1 = jzTelNo1.substring(5);
                $("#jzPwd1").val(jzPwd1);
            } else {
                var jzTelNo2 = $("#jzTelNo2").val();
                var jzPwd2 = jzTelNo2.substring(5);
                $("#jzLoginName2").val(jzTelNo2);
                $("#jzPwd2").val(jzPwd2);
            }
        }
        function qk() { //清空家长账号密码
            $("#LoginName").val("")
            $("#Pwd").val("")
        }
        function SaveData() {  //保存方法
            //学生信息  
            var selv = $("#asch").val();
            if(typeof(selv)=="undefined"){
                selv=$("#schidhidden").val();
            }
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
            //var Dutie = $("#Dutie").val(); 
            var CardNo = $("#CardNo").val();
            var StudyType = $("input[name='StudyType']:checked").val();
            var TelNo = $("#TelNo").val();
            //if (isNotNull(TelNo)==true) {
            //    Pridialog("学生电话号码不能为空！");
            //    return false;
            //}
            var LoginName = $("#LoginName").val();
            if(LoginName=="" || typeof(LoginName)=="undefined"){LoginName="";}
            var Pwd = $("#Pwd").val();
            if(Pwd=="" || typeof(Pwd)=="undefined"){Pwd="";}
            var Addr = $("#Addr").val();
            var Stat = $("input[name='Stat']:checked").val();
            if(Stat=="" || typeof(Stat)=="undefined"){Stat="1";}
            //家长信息
            var jzGenName1 = $("#jzGenName1").val();
            var jzTelNo1 = $("#jzTelNo1").val();
            var jzLoginName1 = $("#jzLoginName1").val();
            var jzPwd1 = $("#jzPwd1").val();
            var jzStat1 = $("input[name='jzStat1']:checked").val();
            if(jzStat1=="" || typeof(jzStat1)=="undefined"){jzStat1="1";}
            var jzGenName2 = $("#jzGenName2").val();
            var jzTelNo2 = $("#jzTelNo2").val();
            var jzLoginName2 = $("#jzLoginName2").val();
            var jzPwd2 = $("#jzPwd2").val();
            var jzStat2 = $("input[name='jzStat2']:checked").val();
            if(jzStat2=="" || typeof(jzStat2)=="undefined"){jzStat2="1";}
            var Relation1 = $("#jzRelation1").val();
            var Relation2 = $("#jzRelation2").val();
            if (jzGenName1==""&&Relation1==""&&jzTelNo1==""&&jzGenName2==""&&Relation2==""&&jzTelNo2=="") {
                alert("请输入至少一个家长信息");
                $("#jzGenName1").focus();
                return false;
            }
          
            if (jzTelNo1!="") {
                if (jzGenName1=="") {
                    alert("请输入家长姓名");
                    $("#jzGenName1").focus();
                    return false;
                }
            }
            if (jzTelNo2!="") {
                if (jzGenName2=="") {
                    alert("请输入家长姓名");
                    $("#jzGenName2").focus();
                    return false;
                }
            }
            //if (jzGenName1!="") {
            //    if (Relation1=="") {
            //        alert("请输入完整的家长信息");
            //        $("#Relation1").focus();
            //        return false;
            //    }   
            //}
            //if (jzGenName2!="") {
            //    if (Relation2=="") {
            //        alert("请输入完整的家长信息");
            //        $("#Relation2").focus();
            //        return false;
            //    }   
            //}
            //if (jzGenName2!=""&&Relation2!="") {
            //    if (jzTelNo2=="") {
            //        alert("请输入家长手机号");
            //        $("#jzTelNo2").focus();
            //        return false;
            //    }
            //}
          
            //if(!checkTxtResult("#jzTelNo2",'^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$')){
            //    if(jzGenName2!=""&&Relation2!=""){
            //        alert("请输入第二个家长的手机号码");
            //        $("#jzTelNo2").focus();
            //        return false;
            //    }
            //}
            //if (isMobile(TelNo) == false || isMobile(jzTelNo1) == false) {
            //    Pridialog("电话格式错误！");
            //    return false;
            //} 
            //alert(checkTxt("#jzTelNo1","^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$"));
            //if(jzTelNo1.length!="11"){
            //    Pridialog("请正确输入家长的手机号码！");
            //    return false;
            //}
            if (ClassId==null) {
                Pridialog("请选择班级！");
                return false;
            }
            //if (jzGenName1=="" && jzGenName2=="") {
            //    Pridialog("请输入至少一个家长信息！");
            //    return false;
            //}
            //if (jzTelNo1=="" && jzTelNo2=="") {
            //    Pridialog("请输入对应的家长手机号！");
            //    return false;
            //}
            //if (jzGenName1!="" && jzTelNo1=="") {
            //    Pridialog("请输入家长对应的手机号！");
            //    return false;
            //}
            //if (jzGenName2!="" && jzTelNo2=="") {
            //    Pridialog("请输入家长对应的手机号！");
            //    return false;
            //}
            //if (jzTelNo1!="" && jzGenName1=="") {
            //    Pridialog("请输入对应的家长姓名！");
            //    return false;
            //}
            //if (jzTelNo2!="" && jzGenName2=="") {
            //    Pridialog("请输入对应的家长姓名！");
            //    return false;
            //}
            //if(jzTelNo2==jzTelNo1){
            //    Pridialog("父母的手机号不允许重复！");
            //    return false;
            //}
            var Genid1= $("#Genid1").val(); 
            var Genid2= $("#Genid2").val(); 
            var Unid1= $("#Unid1").val(); 
            var Unid2= $("#Unid2").val();  
            
            var params = '{"Genid1":"'+Genid1+'","Genid2":"'+Genid2+'","Unid1":"'+Unid1+'","Unid2":"'+Unid2+'","Stuid":"'+stuid+'","dotype":"'+dotype+'","schid":"' + selv + '","ClassId":"' + ClassId + '","TestNo":"' + TestNo + '","StuName":"' + StuName + '","Sex":"' + Sex + '", "CardNo":" ","StudyType":"' + StudyType + '","TelNo":"' + TelNo + '","LoginName":"' + LoginName + '","Pwd":"' + Pwd + '","Addr":"' + Addr + '","Stat":"1","jzGenName1":"' + jzGenName1 + '","jzTelNo1":"' + jzTelNo1 + '","jzLoginName1":"' + jzLoginName1 + '","jzPwd1":"' + jzPwd1 + '","jzStat1":"' + jzStat1 + '","jzGenName2":"' + jzGenName2 + '","jzTelNo2":"' + jzTelNo2 + '","jzLoginName2":"' + jzLoginName2 + '","jzPwd2":"' + jzPwd2 + '","jzStat2":"' + jzStat2 + '","Relation1":"' + Relation1 + '","Relation2":"' + Relation2 + '","OldClassName":"' + oldclassnamestr + '","OldGradeId":"' + oldgradeidstr + '","OldGradeName":"' + oldgradenamestr + '","GradeId":"' + gradeid + '","OldClassId":"' + oldclassidstr + '","CurrentTestNo":"' + CurrentTestNo + '"}';//
            
            $.ajax({
                type: "POST",
                url: "StudentEdit.aspx/schsave",
                dataType: "json",
                data:params, 
                contentType: "application/json; charset=utf-8",
                success: function (data) { 
                    if (data.d == "Success") { //返回成功 
                        if(dotype=="a"){alert("添加成功！");window.history.go(-1); }
                        if(dotype=="e"){alert("修改成功！");window.history.go(-1); }
                    //} else if (data.d == "KHCF") {
                    //    Pridialog("学（考号）："+TestNo+"以前是"+StuName+"在用，强烈建议不要再使用");
                        //Pridialog("已存在学(考)号,不允许重复添加！");
                    }else if (data.d == "ZHCF") {
                        Pridialog("已存在账号,不允许重复添加！");
                    }else if(data.d=="NoAdd") {
                        Pridialog("无添加权限！");
                    }else if(data.d=="BBBZR"){
                        Pridialog("你不是本班的班主任，不能添加学生！");
                    }
                    else if(data.d=="BNJZR"){
                        Pridialog("你不是本年级领导，不能添加学生！");
                    }
                    else if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }else{
                        alert("学（考号）："+TestNo+"以前是"+data.d+"在用，强烈建议不要再使用");
                        //window.history.go(-1);
                    }
                }
            });
            
        }

        //获取市
        $('#aprov').change(function () {
            var selv = $('#aprov').val(); 
            var params = '{"typecode":"1","pcode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "StudentList.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $('#acity').html(data.d);
                    $('#acity').change();
                },
                error: function (obj, msg, e) {
                }
            });
        });
        //获取区
        $('#acity').change(function () {
            var selv = $('#acity').val();
            var params = '{"typecode":"2","pcode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "StudentList.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $('#acoty').html(data.d);
                    $('#acoty').change();
                },
                error: function (obj, msg, e) {
                }
            });
        });
        //获取学校
        $('#acoty').change(function () {
            var selv = $('#acoty').val();
            var params = '{"typecode":"3","pcode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "StudentList.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $('#asch').html(data.d);
                    $('#asch').change();
                },
                error: function (obj, msg, e) {
                }
            });
        });
        //获取年级
        $('#asch').change(function () {
            var selv = $('#asch').val();  
            var params = '{"typecode":"4","pcode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "StudentList.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $('#nj').html(data.d);
                    $('#nj').change();
                },
                error: function (obj, msg, e) {
                }
            });
        });
        //获取班级
        $('#nj').change(function () { 
            $('#njld').html("年级领导：");
            var selv = $('#nj').val();   
            schid = $('#asch').val();  
            var params = '{"typecode":"1","pcode":"' + selv + '","schid":"' + schid + '","classid":""}';
            $.ajax({
                type: "POST",  //请求方式
                url: "StudentList.aspx/getnj",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dd = eval("(" + data.d + ")");
                    $('#njld').html("年级领导：" + dd.gradeboss);
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
            $('#bjjs').html("任课老师：");
            $('#bzr').html("班主任："); 
            var selv = $('#bj').val();  
            var params = '{"typecode":"2","pcode":"' + selv + '","schid":"' + schid + '","classid":""}';
            $.ajax({
                type: "POST",  //请求方式
                url: "StudentList.aspx/getnj",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var dd = eval("(" + data.d + ")");
                    $('#bjjs').html("任课老师：" + dd.classtec);
                    $('#bzr').html("班主任：" + dd.classms);
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

<script type="text/javascript">
    /*$(document).ready(function(){
        if(gradecode!=""){
            $("#nj").val(gradecode);
            $
        }
        if(classid!=""){
            $("#bj").val(classid);
                
        }
        if(gradecode!=""&&classid!=""){
            ("#nj").attr("disabled","disabled");
            $("#bj").attr("disabled","disabled");
        }
    })*/
</script>