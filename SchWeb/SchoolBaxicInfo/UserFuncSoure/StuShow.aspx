<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuShow.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.UserFuncSoure.StuShow" %>

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
         /*学校名称等左边标签的样式*/
        .text_style {
            /*font-size: 15px !important;*/
            line-height: 30px !important;
            color: #000000 !important;
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
            font-size:12px;
            color:#666666 !important;
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
             text-align:center !important;
             line-height:1.5 !important;
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
        /*输入框的上下边距*/
        .input_box {
            padding:4px 10px;
        }
       .form-group input[disabled], .form-group input:disabled, .form-group select:disabled, input:disabled {
            color: #666666!important;
            background-color: #fff!important;
            border-style: none;
        }
       /*每行的行高*/
        .lheight {
            line-height:30px !important;
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
        .form-group input[disabled] { 
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
                     <style type="text/css">
                       /*单选框选中的颜色为#444444*/
                        input[type=checkbox].ace:disabled+.lbl::before, input[type=radio].ace:disabled+.lbl::before, input[type=checkbox].ace[disabled]+.lbl::before, input[type=radio].ace[disabled]+.lbl::before, input[type=checkbox].ace.disabled+.lbl::before, input[type=radio].ace.disabled+.lbl::before{color:#32A3CF;}
                      </style>
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
                    <div class="row col-sm-9 col-sm-offset-1">
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="col-sm-12">
                                    <div class="col-sm-10">
                                        <div class="input-group " style="text-align: center; float: right; width: 100%">
                                           
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <br />
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12">
                            <form class="form-horizontal" role="form">
                                <div class=" form-inline lheight">
                                    <div class="col-sm-3 text_style">
                                       <div class="col-sm-4 no-padding-right  text-right">
                                            <label class="biaoti">系统编号:</label>
                                        </div>
                                        <div class="col-sm-8 input_box">

                                            <input type="text" id="bh"   readonly="readonly" disabled="disabled"  class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3 text_style">
                                       <div class="col-sm-4 no-padding-right  text-right">
                                            <label class="biaoti">学(考号):</label>
                                        </div>
                                        <div class="col-sm-8 input_box">

                                            <input type="text" id="TestNo"   readonly="readonly" disabled="disabled"  class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3 text_style">
                                       <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">姓名:</label>
                                        </div>
                                        <div class="col-sm-8 input_box">
                                            <input type="text" id="StuName"  readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3 text_style">
                                         <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">性别:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <div class="control-group col-xs-12 col-sm-12 no-padding-left">
                                                <label>
                                                    <input name="Sex" type="radio"  readonly="readonly" disabled="disabled" checked="checked" value="1" class="ace">
                                                    <span class="lbl neirong1">男</span>
                                                </label>
                                                &nbsp;&nbsp;    
                                        <label>
                                            <input name="Sex" type="radio" value="0"  readonly="readonly" disabled="disabled" class="ace">
                                            <span class="lbl neirong1">女</span>
                                        </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class=" form-inline lheight">
                                    <div class="col-sm-3 text_style">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">学生卡地址:</label>
                                        </div>
                                        <div class="col-sm-8 input_box">
                                            <input type="text"   id="CardNo" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style"  />
                                        </div>
                                    </div>
                                    <div class="col-sm-3 text_style">
                                         <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">手机号 :</label>
                                        </div>
                                        <div class="col-sm-8 input_box">
                                            <input type="text" id="TelNo"  readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3 text_style">
                                         <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">地址:</label>
                                        </div>
                                        <div class="col-sm-8 input_box">
                                            <input type="text" id="Addr"   readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3 text_style oldgrade" style="display:none;">
                                     <div class="col-sm-4 no-padding-right text-right biaoti">
                                             原班级:
                                        </div>
                                        <div class="col-sm-8 neirong1" id="oldClassName">
                                           1061(高一)
                                        </div>
                                 
                                    </div>
                                </div>

<%--                                <div class="col-sm-3 text_style oldgrade" style="display:none;">
                                      <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">是否走读:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <label>
                                                <input name="StudyType" type="radio"  readonly="readonly" disabled="disabled" checked="checked" value="1" class="ace">
                                                <span class="lbl neirong1">是</span>
                                            </label>
                                            &nbsp;&nbsp;    
                                        <label>
                                            <input name="StudyType" type="radio" value="0"  readonly="readonly" disabled="disabled" class="ace">
                                            <span class="lbl neirong1">否</span>
                                        </label>
                                        </div>
                                </div>--%>

                                <div class="space-4"></div>



                                      

                                <!--暂时注释掉账号密码
                                <div class="form-group form-inline">
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right"  >
                                            <label>账号:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <span class="input-icon input-icon-right ">
                                                <input type="text" id="LoginName"   readonly="readonly" />
                                                <i class="icon-white badge badge-info" style="color: white; font-size: 10px; width: 65px; height: 28px"><a style="color: white;" onclick="Make(1)" href="#">自动生成</a></i>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label>密码:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <input type="password" id="Pwd"   readonly="readonly" class="col-xs-12 col-sm-12" />
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

                                <div class="form-group form-inline">
                                    <div class="col-sm-12">
                                        <div class="col-sm-1 no-padding-right text-right biaoti">
                                            家长信息：
                                        </div>
                                          <div class="col-sm-11 form-group form-inline">
                                    <div>
                                        <div>
                                            <table  class="table_box" width="100%" border="1" bordercolor="#E4E4E4">
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
                                                    <%--隐藏到账号密码--%>
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
                                                        <input class="input_style col-sm-12 neirong text-center" type="text" id="jzGenName1"   disabled="disabled" readonly="readonly" />
                                                    </th>
                                                    <th style="text-align: center;">
                                                        <input class="input_style col-sm-12 neirong text-center" type="text" id="jzRelation1"  disabled="disabled" readonly="readonly" />

                                                    </th>
                                                    <th style="text-align: center;">
                                                        <input class="input_style col-sm-12 neirong text-center" type="text" id="jzTelNo1"  disabled="disabled" readonly="readonly" />
                                                    </th>
                                                    <%--<th style="text-align: center;">
                                                        <span class="input-icon input-icon-right ">
                                                            <input type="text" id="jzLoginName1"  readonly="readonly" />
                                                            <i class="icon-white badge badge-info" style="color: white; font-size: 10px; width: 65px; height: 28px"><a style="color: white;" onclick="Make(2)" href="#">自动生成</a></i>
                                                        </span>
                                                    </th>
                                                    <th style="text-align: center;">
                                                        <input type="password" id="jzPwd1"  readonly="readonly" />
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
                                                        <input class="input_style col-sm-12 neirong text-center" type="text" id="jzGenName2" disabled="disabled" readonly="readonly" /></th>
                                                    <th style="text-align: center;">
                                                        <input class="input_style col-sm-12 neirong text-center" type="text" id="jzRelation2" disabled="disabled"  readonly="readonly" />

                                                    </th>
                                                    <th style="text-align: center;">
                                                        <input class="input_style col-sm-12 neirong text-center" type="text"   id="jzTelNo2" disabled="disabled"  readonly="readonly" />
                                                    </th>
                                                    <%--<th style="text-align: center;">
                                                        <span class="input-icon input-icon-right ">
                                                            <input type="text" id="jzLoginName2" readonly="readonly" />
                                                            <i class="icon-white badge badge-info" style="color: white; font-size: 10px; width: 65px; height: 28px"><a style="color: white;" onclick="Make(3)" href="#">自动生成</a></i>
                                                        </span>
                                                    </th>
                                                    <th style="text-align: center;">
                                                        <input type="password" id="jzPwd2"  readonly="readonly" />
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
                                                </tr>
                                            </table>



                                        </div>
                                    </div>
                                </div>
                                    </div>
                                </div>
                              
                            </form>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />

                 
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
        
        //用户赋值
        var umodel=<%=umodelstr%>;
        var oldClassName="<%=oldClassName%>";
        var Stubh="<%=Stubh%>";
        
        
           
        if (umodel != "1") {  
            $("#bh").val(Stubh);
            $("#Stuid").val(umodel[0].StuId);
            if(oldClassName!=""){
                $(".oldgrade").css("display","block");
                $("#oldClassName").html(oldClassName);
            }else{
                $(".oldgrade").css("display","none");
            }
            $('#StuName').val(umodel[0].StuName);
            $("#PriClass option:selected").val(umodel[0].ClassId);
            $("#TestNo").val(umodel[0].TestNo); $("#StuName").val(umodel[0].StuName);
            $("input[name='Sex'][value=" + umodel[0].Sex + "]").attr("checked", true);
            $("#Dutie").val(umodel[0].Dutie); $("#CardNo").val(umodel[0].CardNo);
            $("input[name='StudyType'][value=" + umodel[0].StudyType + "]").attr("checked", true);
            $("#TelNo").val(umodel[0].TelNo); $("#LoginName").val(umodel[0].LoginName);
            $("#Pwd").val(umodel[0].Pwd); $("#Addr").val(umodel[0].Addr);
            $("input[name='Stat'][value=" + umodel[0].Stat + "]").attr("checked", true);
            //返回家长信息
            $("#jzGenName1").val(umodel[0].jzGenName1); $("#jzTelNo1").val(umodel[0].jzTelNo1);
            $("#jzLoginName1").val(umodel[0].jzLoginName1); $("#jzPwd1").val(umodel[0].jzPwd1);
            $("input[name='jzStat1'][value=" + umodel[0].jzStat1 + "]").attr("checked", true);
            $("#jzGenName2").val(umodel[0].jzGenName2); $("#jzTelNo2").val(umodel[0].jzTelNo2);
            $("#jzLoginName2").val(umodel[0].jzLoginName2); $("#jzPwd2").val(umodel[0].jzPwd2);
            $("input[name='jzStat2'][value=" + umodel[0].jzStat2 + "]").attr("checked", true);
            //$(".ss2").find("option[value='" + umodel[0].Relation + "']").attr("selected", true);
            //$(".ss3").find("option[value='" + umodel[1].Relation + "']").attr("selected", true);
            $("#jzRelation1").val(umodel[0].jzRelation1); $("#jzRelation2").val(umodel[0].jzRelation2);
            $("#Unid1").val(umodel[0].jzUnId1); $("#Unid2").val(umodel[0].jzUnId2);
            $("#Genid1").val(umodel[0].jzGenId1); $("#Genid2").val(umodel[0].jzGenId2);
            //if(oldClassName!=""){
            //    $(".oldgrade").css("display","block");
            //    $("#oldClassName").html(oldClassName);
            //}else{
            //    $(".oldgrade").css("display","none");
            //}
        }  
        
    </script>
</body>
</html>

