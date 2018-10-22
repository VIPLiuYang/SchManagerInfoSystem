<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Schinfo.aspx.cs" Inherits="SchWebAdmin.Web.SchXXTSearch.Schinfo" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>学校操作</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!-- basic styles -->

    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />

    <!--[if IE 7]>
		  <link rel="stylesheet" href="../../assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

    <!-- page specific plugin styles -->

    <link rel="stylesheet" href="../../assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="../../assets/css/chosen.css" />

    <!-- fonts -->


    <!-- ace styles -->

    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/bootstrap-tagsinput.css">
    <link rel="stylesheet" href="../../assets/css/metro.css" />
    <style>
        .bootstrap-tagsinput {
            border: 0px;
            box-shadow: none;
        }

        .label-info {
            background-color: white!important;
        }

        .input_box > label {
            color: #999999;
            font-size: 13px;
        }

        .form-group > span {
            color: #999999;
            font-size: 13px;
        }

        #selsubs {
            color: #999999;
            font-size: 13px;
            margin-top: 5px;
        }

        #sonsys {
            color: #999999;
            font-size: 13px;
            margin-top: 5px;
        }

        #SonsysStat {
            color: #999999;
            font-size: 13px;
            /*margin-top: 5px;*/
        }

        .label {
            font-size: 14px !important;
            color: black;
        }

        .bootstrap-tagsinput .tag {
            color: black;
        }

        .form-group input[disabled], .form-group input:disabled, .form-group select:disabled, input:disabled {
            color: #999999!important;
            background-color: #fff!important;
            border-style: none;
            font-size: 12px;
        }
        /**/
        control[disabled], .form-control[readonly], fieldset[disabled] .form-control {
            cursor: not-allowed;
            background-color: #fffefe;
            border-style: none;
        }
        /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }

        i {
            font-family: FontAwesome !important;
        }
        /*所在位置的提示高度*/
        .breadcrumbs {
            min-height: 32px;
            line-height: 30px;
        }
        /*所在位置的背景边框*/
        .breadcrumb_box {
            background: white;
            border-bottom: 1px solid #e4e4e4;
        }
        /*坐在位置的坐边竖线*/
        .breadcrumb_border {
            border-left: 2px solid #63bbff;
            margin-left: 0px;
            padding-left: 12px;
        }
        /*内容上边距*/
        .content_box {
            padding-top: 24px;
        }

        /*学校名称等左边标签的样式*/
        /*
        .text_style {
            
            line-height: 30px !important;
            color: #000000 !important;
        }
       */

        /*内容区域的字体大小颜色*/
        .lbl {
            font-size: 12px !important;
            color: #999999;
        }
        /*学段，年级字体的大小颜色*/
        .color {
            font-size: 13px !important;
            color: #666666 !important;
        }
        /*备注区域的最小高度*/
        .note {
            min-height: 100px;
        }
        /*年级右内边距*/
        .nianji {
            padding-right: 0;
        }
        /*位置提示字体大小*/
        .breadcrumb > li {
            font-size: 13px !important;
            color: #666666 !important;
        }
        /*科目的颜色*/
        .bootstrap-tagsinput .tag {
            color: #999999 !important;
            font-size: 12px !important;
        }
        /*下拉选框 输入框的大小*/
        select, input {
            font-size: 12px;
            color: #999999;
        }

            input[type="text"] {
                color: #999999 !important;
                font-size: 12px !important;
            }
        /*按钮中的字体大小*/
        .text_size {
            font-size: 12px;
        }
        /*每一行的间距*/
        .form-group {
            margin-bottom: 2px;
        }
        /*当屏幕大于768时联系方式和地址的最大宽度*/
        @media (min-width:768px) {
            .phone {
                max-width: 150px;
            }

            .address {
                max-width: 400px;
            }
        }

        .button_bg {
            margin-top: 10px !important;
            margin-bottom: 10px !important;
        }
        /*当屏幕小于768时取消学段的浮动*/
        @media (max-width:768px) {
            .bianju {
                text-align: initial !important;
            }
        }
        /*input中placeholder的颜色*/
        input::-webkit-input-placeholder, textarea::-webkit-input-placeholder { /* WebKit*/
            color: #999999;
            font-size: 12px;
        }

        input:-moz-placeholder, textarea:-moz-placeholder { /* Mozilla Firefox 4 to 18 */
            color: #999999;
            font-size: 12px;
        }

        input::-moz-placeholder, textarea::-moz-placeholder { /* Mozilla Firefox 19+ */
            color: #999999;
            font-size: 12px;
        }

        input:-ms-input-placeholder, textarea:-ms-input-placeholder { /* IE 10+ */
            color: #999999;
            font-size: 12px;
        }
        /*科目下来框的颜色大小*/
        .ztree li a span {
            color: #666666;
            font-size: 12px !important;
        }
        /*输入框所在的盒子上下边距*/
        .input_box {
            padding: 3px 10px;
        }

        #schname {
            /*margin-left: 10px;*/
            margin-right: 10px;
        }

        body {
            background-color: transparent;
            overflow: -Scroll;
            overflow-x: hidden;
        }

        #aprov, #acity, #acoty {
            margin: 4px 10px;
        }

        select {
            height: 26px;
        }
        /*input {
            height: 30px;
        }*/
        label {
            height: 30px;
            line-height: 30px;
        }

        .input_box {
            height: 30px;
        }

        #SchoolSection .row .col-sm-11 .col-sm-1 {
            width: 9.3%;
        }
        /*行高*/
         .lineheight {
            line-height:30px;
        }
    </style>

    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="../../assets/css/ace-ie.min.css" />
		<![endif]-->

    <!-- inline styles related to this page -->

    <!-- ace settings handler -->

    <script src="../../assets/js/ace-extra.min.js"></script>

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

    <!--[if lt IE 9]>
		<script src="../../assets/js/html5shiv.js"></script>
		<script src="../../assets/js/respond.min.js"></script>
		<![endif]-->
    <script src="../../assets/CustomFunction/DataVerification.js"></script>
    <style type="text/css">
        #SonsysStat .Enable {
            /*display: inline-block;*/
            width: 100px;
            /*height: 30px;
            line-height: 30px;*/
            text-align: center;
            cursor: pointer;
        }

        .biaoti {
            color: #000000;
            font-size: 14px;
            font-weight: bold;
            letter-spacing: 1px;
        }
    </style>
</head>

<body ontouchstart>

    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>
        <style type="text/css">
            .breadcrumb > li + li:before {
                content: none;
            }

            input[type=checkbox].ace:disabled + .lbl::before, input[type=radio].ace:disabled + .lbl::before, input[type=checkbox].ace[disabled] + .lbl::before, input[type=radio].ace[disabled] + .lbl::before, input[type=checkbox].ace.disabled + .lbl::before, input[type=radio].ace.disabled + .lbl::before {
                color: #32A3CF;
            }
        </style>
        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
                <div class="col-sm-1 biaoti">基础信息</div>
                <div class="row">
                    <%--减小栅格栏--%>
                    <div class="col-xs-12  col-sm-10 col-sm-offset-1">
                        <!-- PAGE CONTENT BEGINS -->
                        <form class="form-horizontal  " role="form">
                            <div class="space-8"></div>
                            <div class="row">
                                <div class="form-group form-inline">
                                    <div class="col-sm-1 no-padding text-right">
                                            <label class="">学校代码:</label>
                                        </div>
                                        <div class="col-sm-2 input_box"> 
                                             <input type="text" id="SchIdstr" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    <div class="col-sm-1 no-padding text-right">
                                        <label>学校全称:</label>
                                    </div>
                                  <div class="col-sm-2 input_box">
                                            <input type="text" id="schname" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    <div class="col-sm-1 no-padding  text-right">
                                        <label>所在区域:</label>
                                    </div>
                                    <div class="col-sm-2 input_box"> 
                                        <input type="text" id="Text1" readonly="readonly" disabled="disabled" value=" <%=areastr %>" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                    </div>
                                    <div class="col-sm-1 no-padding-right text-right">
                                        <label class="">是否为城区:</label>
                                    </div>
                                    <div class="col-sm-1">
                                        <div class="control-group col-xs-12 col-sm-12 no-padding">
                                            <label>
                                                <input name="iscity" type="radio" value="1" disabled="disabled" class="ace" checked="checked">
                                                <span class="lbl ">是</span>
                                            </label>
                                            &nbsp &nbsp 
                                                <label>
                                                    <input name="iscity" type="radio" disabled="disabled" value="0" class="ace">
                                                    <span class="lbl ">否</span>
                                                </label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group form-inline">
                                    <div class="col-sm-1 no-padding  text-right ">
                                        <label class="">学校地址:</label>
                                    </div>
                                    <div class="col-sm-2 input_box">
                                            <input type="text" id="schaddr" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    <div class="col-sm-1 no-padding text-right">
                                        <label class="">系统管理员:</label>
                                    </div>
                                    <div class="col-sm-2 input_box">
                                            <input type="text" id="schmaster" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    <div class="col-sm-1 no-padding text-right text_style ">
                                        <label class="">职务:</label>
                                    </div>
                                 <div class="col-sm-2 input_box">
                                            <input type="text" id="schmasterpst" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    <div class="col-sm-1 no-padding  text-right ">
                                        <label>联系电话:</label>
                                    </div>
                                   <div class="col-sm-2 input_box">
                                            <input type="text" id="schmastertel" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                </div>
                            </div>
                            <div class="space-2"></div>
                            <div class="row">
                                <div class="form-group form-inline">
                                    <div class="col-sm-1 no-padding text-right">
                                        <label class="">管理员账号:</label>
                                    </div>
                                     <div class="col-sm-2 input_box">
                                            <input type="text" id="ManagerAcount" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    <div class="col-sm-1 no-padding text-right text_style ">
                                        <label class="">初始密码:</label>
                                    </div>
                                 <div class="col-sm-2 input_box">
                                            <input type="text" id="InitialPwd" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    <div class="col-sm-1 no-padding  text-right ">
                                        <label>一线技术人员:</label>
                                    </div>
                                    <div class="col-sm-1 input_box">
                                            <input type="text" id="FrontlineTechni" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    <div class="col-sm-1 no-padding text-right">
                                        <label class="">创建者:</label>
                                    </div>
                                       <div class="col-sm-3 input_box">
                                            <input type="text" id="Creator" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                </div>
                            </div>
                            <div class="space-2"></div>
                            <div class="row">
                                <div class="form-group form-inline">
                                    <div class="col-sm-1 no-padding text-right">
                                        <label class="">校长姓名:</label>
                                    </div>
                                   <div class="col-sm-2 input_box">
                                            <input type="text" id="PrincipalName" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    <div class="col-sm-1 no-padding text-right text_style ">
                                        <label class="">校长手机:</label>
                                    </div>
                                     <div class="col-sm-2 input_box">
                                            <input type="text" id="PrincipalTel" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    <div class="col-sm-1 no-padding  text-right ">
                                        <label>客服人员姓名:</label>
                                    </div>
                                   <div class="col-sm-1 input_box">
                                            <input type="text" id="CustomerServiceStaffName" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    <div class="col-sm-1 no-padding text-right">
                                        <label class="">客服人员电话:</label>
                                    </div>
                                  <div class="col-sm-3 input_box">
                                            <input type="text" id="CustomerServiceStaffNameTel" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                </div>
                            </div>
                            <div class="space-2"></div>
                            <div class="row">
                                <div class="form-group form-inline">

                                    <div class="col-sm-1 no-padding text-right">
                                        <label>学段及年级:</label>
                                    </div>
                                    <div class="col-sm-11" id="SchoolSection">
                                    </div>
                                </div>
                            </div>
                            <div class="space-2"></div>
                            <div class="row">
                                <div class="form-group form-inline">
                                    <div class="col-sm-1 no-padding-right text-right ">
                                        <label>开设科目:</label>
                                    </div>
                                    <div class="col-sm-11" id="selsubs">
                                    </div>
                                </div>
                            </div>
                            <div class="space-2"></div>
                                 <div class="row">
                                     <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding-right text-right ">
                                            <label for="schnote" class="text_style">毕业年级:</label>
                                        </div>
                                        <div class="col-sm-10" id="graduationdom">
                                            <div id="kindergartendom"></div>
                                            <div id="primaryschooldom"></div>
                                            <div id="juniorschooldom"></div>
                                            <div id="highschooldom"></div>
                                        </div>
                                    </div>
                                 </div>
                        </form>
                        <!-- PAGE CONTENT ENDS -->
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
                <div class="row">
                   <div class="col-sm-12 biaoti">1、管理平台信息</div>
                </div>
                <div class="space-4"></div>
                <div class="row">
                    <div class="col-xs-12  col-sm-10 col-sm-offset-1">
                        <!-- PAGE CONTENT BEGINS -->
                        <form class="form-horizontal  " role="form">
                            <div class="space-2"></div>
                            <div class="row">
                                <div class="form-group form-inline">
                                    <div class="col-sm-1 no-padding text-right">
                                        <label class="">平台名称:</label>
                                    </div>
                                    <div class="col-sm-2 input_box">
                                            <input type="text" id="PlatformName" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    <div class="col-sm-1 no-padding text-right text_style ">
                                        <label class="">平台图标:</label>
                                    </div>
                                    <div class="col-sm-2 input_box no-padding ">
                                        <img id="PlatformIco" style="width:32px;display:none;float:left;" src="" />
                                    </div>
                                    <div class="col-sm-1 no-padding  text-right ">
                                        <label>平台域名:</label>
                                    </div>
                                   <div class="col-sm-1 input_box">
                                            <input type="text" id="PlatformUrl" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    <div class="col-sm-1 no-padding text-right">
                                        <label class="">IP地址:</label>
                                    </div>
                                    <div class="col-sm-1 input_box">
                                            <input type="text" id="IPAddress" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                </div>
                            </div>
                            
                            <div class="space-2"></div>
                            <div class="row">
                                <div class="form-group form-inline">
                                    <div class="col-sm-1 no-padding-right text-right ">
                                        <label for="schnote" class="text_style">子系统:</label>
                                    </div>
                                    <div class="col-sm-11" id="sonsys">
                                    </div>
                                </div>
                            </div>
                            <div class="space-2"></div>
                            <div class="row">
                                <div class="form-group form-inline lineheight">
                                    <div class="col-sm-1 no-padding-right text-right ">
                                        <label for="schnote" class="text_style">服务状态:</label>
                                    </div>
                                    <div class="col-sm-10" id="SonsysStat">
                                        <span class="Enable" rel="0">启用</span>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <div class="row">
                  <div class="col-sm-12 biaoti">2、资源平台信息</div>
                </div>
                <div class="row">
                    <div class="col-xs-12  col-sm-10 col-sm-offset-1">
                        <!-- PAGE CONTENT BEGINS -->
                        <form class="form-horizontal  " role="form">
                            <div class="space-2"></div>
                            <div class="row">
                                <div class="form-group form-inline">
                                    <div class="col-sm-1 no-padding text-right">
                                        <label class="">平台名称:</label>
                                    </div>
                                    <div class="col-sm-2 input_box">
                                            <input type="text" id="ResourcePlatformName" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    <div class="col-sm-1 no-padding text-right text_style ">
                                        <label class="">平台图标:</label>
                                    </div>
                                   <div class="col-sm-2 input_box no-padding ">
                                        <img id="ResourcePlatformIco" style="width:32px;display:none;float:left;" src="" />
                                    </div>
                                    <div class="col-sm-1 no-padding  text-right ">
                                        <label>平台域名:</label>
                                    </div>
                                 <div class="col-sm-1 input_box">
                                            <input type="text" id="ResourcePlatformUrl" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    <div class="col-sm-1 no-padding text-right">
                                        <label class="">IP地址:</label>
                                    </div>
                                    <div class="col-sm-1 input_box">
                                            <input type="text" id="ResourcePlatformIP" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                </div>
                            </div>

                            <div class="space-10"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">资料科目及教版:</label>
                                        </div>
                                        <div class="col-sm-11 no-padding text-right">
                                            <div class="row" style="margin-right:0px;margin-left:0px;padding-left:5px;">
                                                <div class="col-sm-1 text-left no-padding">
                                                    <label>
                                                        学段：
														<input id="Per1" name="kindergartenPer" disabled="disabled" class="ace" type="checkbox" value="1">
														<span class="lbl">幼儿园</span>
													</label>
                                                </div>
                                                <div class="col-sm-1 text-left"><label>科目：</label></div>
                                                <div class="col-sm-10 text-left">
                                                    <select id="Tags1" disabled="disabled" multiple></select>
                                                    <div class="btn-group">
                                                      <%--  <button data-toggle="dropdown" id="submatbtn1" class="btn btn-info btn-sm btn_size submatbtn" relid="1">
                                                            添加科目及教版
													            <span class="icon-caret-down icon-on-right"></span>
                                                        </button>--%>
                                                        <div id="downdom1"  class="row" style="margin-left:0px;margin-right:0px;">
                                                          <%--  <div class="col-sm-6 no-padding">
                                                                <div class="EduVerTitle">教版科目</div>
                                                                <ul id="TreeSub1" class="ztree"></ul></div>
                                                            <div class="col-sm-6 no-padding">
                                                                <input type="hidden" id="treesubhidden" class="treesubhidden" />
                                                                <div class="SelectEduTitle" relid="1">选择教版</div>
                                                                <ul id="TreeEduVer1" class="ztree"></ul>
                                                            </div>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="margin-right:0px;margin-left:0px;padding-left:5px;">
                                                <div class="col-sm-1 text-left no-padding">
                                                    <label>
                                                        学段：
														<input id="Per2" name="primaryPer" disabled="disabled" class="ace" type="checkbox" value="2">
														<span class="lbl">小学</span>
													</label>
                                                </div>
                                                <div class="col-sm-1 text-left"><label>科目：</label></div>
                                                <div class="col-sm-10 text-left">
                                                    <select id="Tags2" disabled="disabled" multiple></select>
                                                    <div class="btn-group">
                                                      <%--  <button data-toggle="dropdown" id="submatbtn2" class="btn btn-info btn-sm btn_size submatbtn" relid="2">
                                                            添加科目及教版
													            <span class="icon-caret-down icon-on-right"></span>
                                                        </button--%>
                                                        <div id="downdom2" class="row" style="margin-left:0px;margin-right:0px;clear:both;">
                                                            <%--<div class="col-sm-6 no-padding">
                                                                <div class="EduVerTitle">教版科目</div>
                                                                <ul id="TreeSub2" class="ztree"></ul>
                                                            </div>
                                                            <div class="col-sm-6 no-padding">
                                                                <input type="hidden" id="treesubprimaryhidden" class="treesubhidden" />
                                                                <div class="SelectEduTitle">选择教版</div>
                                                                <ul id="TreeEduVer2" class="ztree"></ul>
                                                            </div>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="margin-right:0px;margin-left:0px;padding-left:5px;">
                                                <div class="col-sm-1 text-left no-padding">
                                                    <label>
                                                        学段：
														<input id="Per3" name="juniorPer" disabled="disabled" class="ace" type="checkbox" value="3">
														<span class="lbl">初中</span>
													</label>
                                                </div>
                                                <div class="col-sm-1 text-left"><label>科目：</label></div>
                                                <div class="col-sm-10 text-left">
                                                    <select id="Tags3" disabled="disabled" multiple></select>
                                                    <div class="btn-group">
                                                     <%--   <button data-toggle="dropdown" id="submatbtn3" class="btn btn-info btn-sm btn_size submatbtn" relid="3">
                                                            添加科目及教版
													            <span class="icon-caret-down icon-on-right"></span>
                                                        </button>--%>
                                                        <div id="downdom3" class="row" style="margin-left:0px;margin-right:0px;clear:both;">
                                                            <%--<div class="col-sm-6 no-padding">
                                                                <div class="EduVerTitle">教版科目</div>
                                                                <ul id="TreeSub3" class="ztree"></ul>
                                                            </div>
                                                            <div class="col-sm-6 no-padding">
                                                                <input type="hidden" id="treeJuniorhidden" class="treesubhidden" />
                                                                <div class="SelectEduTitle">选择教版</div>
                                                                <ul id="TreeEduVer3" class="ztree"></ul>
                                                            </div>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="margin-right:0px;margin-left:0px;padding-left:5px;">
                                                <div class="col-sm-1 text-left no-padding">
                                                    <label>
                                                        学段：
														<input id="Per4" name="HighPer" disabled="disabled" class="ace" type="checkbox" value="4">
														<span class="lbl">高中</span>
													</label>
                                                </div>
                                                <div class="col-sm-1 text-left"><label>科目：</label></div>
                                                <div class="col-sm-10 text-left">
                                                    <select id="Tags4" disabled="disabled" multiple></select>
                                                    <div class="btn-group">
                                                       <%-- <button data-toggle="dropdown" id="submatbtn4" class="btn btn-info btn-sm btn_size submatbtn" relid="4">
                                                            添加科目及教版
													            <span class="icon-caret-down icon-on-right"></span>
                                                        </button>--%>
                                                        <div id="downdom4" class="row" style="margin-left:0px;margin-right:0px;clear:both;">
                                                            <%--    <div class="col-sm-6 no-padding">
                                                                    <div class="EduVerTitle">教版科目</div>
                                                                    <ul id="TreeSub4" class="ztree dropdown-menu"></ul>
                                                                </div>
                                                                <div class="col-sm-6 no-padding">
                                                                    <input type="hidden" id="treeHighHidden" class="treesubhidden" />
                                                                    <div class="SelectEduTitle">选择教版</div>
                                                                    <ul id="TreeEduVer4" class="ztree dropdown-menu"></ul>
                                                                </div>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-10"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">资源模块:</label>
                                        </div>
                                        <div class="col-sm-11 no-padding text-left">
                                            <select id="tags-soures" disabled="disabled" multiple></select>
                                            <div class="btn-group">
                                               <%-- <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle btn_size">
                                                    添加资源模块
													    <span class="icon-caret-down icon-on-right"></span>
                                                </button>--%>
                                                <ul id="treesoure" class="dropdown-menu ztree">
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-10"></div>
                               <div class="row">
                                    <div class="form-group form-inline lineheight">
                                        <div class="col-sm-1 no-padding-right text-right ">
                                            <label for="schnote" class="text_style">服务状态:</label>
                                        </div>
                                        <div class="col-sm-10" id="SourceServerStat">
                                            <span class="Enable" rel="0" style="color:red;">待启用</span>
                                        </div>
                                    </div>
                               </div>

                        </form>




                    </div>
                </div>



                        <div class="row">
                        <div class="col-sm-12 biaoti">3、家校互通平台</div>
                        <div class="col-sm-11"></div>
                    </div>
                    <div class="space-4"></div>
                    <div class="row">
                        <div class="col-xs-12  col-sm-10 col-sm-offset-1">
                            <!-- PAGE CONTENT BEGINS -->
                            <form class="form-horizontal  " role="form">
                                <div class="space-2"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">平台名称:</label>
                                        </div>
                                      <div class="col-sm-2 input_box">
                                            <input type="text" id="HomeSchoolingName" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                        <div class="col-sm-1 no-padding text-right text_style ">
                                            <label class="">平台图标:</label>
                                        </div>
                                       <div class="col-sm-3 input_box no-padding ">
                                              <img id="HomeSchoolingImg" style="width:32px;display:none;float:left;" src="" />
                                           <%-- <input type="hidden" id="HomeSchoolingIco" placeholder="平台图标" data-toggle="tooltip" maxlength="20"  class="col-xs-9 col-sm-9"  readonly="readonly" disabled="disabled"/>
                                            <img id="HomeSchoolingImg" style="width:32px;display:none;float:left;" src="" />
                                            <a class="HomeSchoolingfile"><input id="HomeSchoolingBtnFile" name="HomeSchoolingBtnFile" onchange="fileChange(this);"  accept="image/gif, image/jpeg, image/jpg" type="file"/>上传图标</a>--%>
                                        </div>
                                        <div class="col-sm-1 no-padding  text-right ">
                                            <label >平台域名:</label>
                                        </div>
                                     <div class="col-sm-1 input_box">
                                            <input type="text" id="HomeSchoolingUrl" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">IP地址:</label>
                                        </div>
                                       <div class="col-sm-1 input_box">
                                            <input type="text" id="HomeSchoolingIP" readonly="readonly" disabled="disabled" class="col-xs-12 col-sm-12 neirong1 input_style" />
                                        </div>
                                    </div>
                                </div>
                                <div class="space-10"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">科目及教版:</label>
                                        </div>
                                        <div class="col-sm-11 no-padding text-left">
                                            <div class="row" style="margin-right:0px;margin-left:0px;padding-left:5px;">
                                                <div class="col-sm-1 text-left no-padding">
                                                    <label>
                                                        学段：
														<input id="HomSchPer1" name="kindergartenPer" class="ace" disabled="disabled" type="checkbox" value="1">
														<span class="lbl">幼儿园</span>
													</label>
                                                </div>
                                                <div class="col-sm-1 text-left"><label>科目：</label></div>
                                                <div class="col-sm-10 text-left">
                                                    <select id="TagsHomSch1" disabled="disabled" multiple></select>
                                                    <div class="btn-group">
                                                       <%-- <button data-toggle="dropdown" id="homsubmatbtn1" class="btn btn-info btn-sm btn_size submatbtn" relid="1">
                                                            添加科目及教版
													            <span class="icon-caret-down icon-on-right"></span>
                                                        </button>--%>
                                                        <div id="downhomsch1"  class="dropdown-menu">
                                                          <%--  <div class="col-sm-6 no-padding">
                                                                <div class="EduVerTitle">教版科目</div>
                                                                <ul id="TreeHomSchSub1" class="ztree"></ul></div>
                                                            <div class="col-sm-6 no-padding">
                                                                <input type="hidden" id="Hidden1" class="treesubhidden" />
                                                                <div class="SelectEduTitle" relid="1">选择教版</div>
                                                                <ul id="TreeHomSchMat1" class="ztree"></ul>
                                                            </div>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="margin-right:0px;margin-left:0px;padding-left:5px;">
                                                <div class="col-sm-1 text-left no-padding">
                                                    <label>
                                                        学段：
														<input id="HomSchPer2" name="primaryPer" class="ace" disabled="disabled" type="checkbox" value="2">
														<span class="lbl">小学</span>
													</label>
                                                </div>
                                                <div class="col-sm-1 text-left"><label>科目：</label></div>
                                                <div class="col-sm-10 text-left">
                                                    <select id="TagsHomSch2" disabled="disabled" multiple></select>
                                                    <div class="btn-group">
                                                     <%--   <button data-toggle="dropdown" id="homsubmatbtn2" class="btn btn-info btn-sm btn_size submatbtn" relid="2">
                                                            添加科目及教版
													            <span class="icon-caret-down icon-on-right"></span>
                                                        </button>--%>
                                                        <div id="downhomsch2" class="dropdown-menu" style="clear:both;">
                                                            <%--<div class="col-sm-6 no-padding">
                                                                <div class="EduVerTitle">教版科目</div>
                                                                <ul id="TreeHomSchSub2" class="ztree"></ul>
                                                            </div>
                                                            <div class="col-sm-6 no-padding">
                                                                <input type="hidden" id="Hidden2" class="treesubhidden" />
                                                                <div class="SelectEduTitle">选择教版</div>
                                                                <ul id="TreeHomSchMat2" class="ztree"></ul>
                                                            </div>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="margin-right:0px;margin-left:0px;padding-left:5px;">
                                                <div class="col-sm-1 text-left no-padding">
                                                    <label>
                                                        学段：
														<input id="HomSchPer3" name="juniorPer" class="ace" disabled="disabled" type="checkbox" value="3">
														<span class="lbl">初中</span>
													</label>
                                                </div>
                                                <div class="col-sm-1 text-left"><label>科目：</label></div>
                                                <div class="col-sm-10 text-left">
                                                    <select id="TagsHomSch3" disabled="disabled" multiple></select>
                                                    <div class="btn-group">
                                                     <%--   <button data-toggle="dropdown" id="homsubmatbtn3" class="btn btn-info btn-sm btn_size submatbtn" relid="3">
                                                            添加科目及教版
													            <span class="icon-caret-down icon-on-right"></span>
                                                        </button>--%>
                                                        <div id="downhomsch3"" class="dropdown-menu" style="margin-left:0px;margin-right:0px;clear:both;">
                                                            <%--<div class="col-sm-6 no-padding">
                                                                <div class="EduVerTitle">教版科目</div>
                                                                <ul id="TreeHomSchSub3" class="ztree"></ul>
                                                            </div>
                                                            <div class="col-sm-6 no-padding">
                                                                <input type="hidden" id="Hidden3" class="treesubhidden" />
                                                                <div class="SelectEduTitle">选择教版</div>
                                                                <ul id="TreeHomSchMat3" class="ztree"></ul>
                                                            </div>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="margin-right:0px;margin-left:0px;padding-left:5px;">
                                                <div class="col-sm-1 text-left no-padding">
                                                    <label>
                                                        学段：
														<input id="HomSchPer4" name="HighPer" class="ace" disabled="disabled" type="checkbox" value="4">
														<span class="lbl">高中</span>
													</label>
                                                </div>
                                                <div class="col-sm-1 text-left"><label>科目：</label></div>
                                                <div class="col-sm-10 text-left">
                                                    <select id="TagsHomSch4" disabled="disabled" multiple></select>
                                                    <div class="btn-group">
                                                       <%-- <button data-toggle="dropdown" id="homsubmatbtn4" class="btn btn-info btn-sm btn_size submatbtn" relid="4">
                                                            添加科目及教版
													            <span class="icon-caret-down icon-on-right"></span>
                                                        </button>--%>
                                                        <div id="downhomsch4"" class="dropdown-menu" style="clear:both;">
                                                          <%--  <div class="col-sm-6 no-padding">
                                                                <div class="EduVerTitle">教版科目</div>
                                                                <ul id="TreeHomSchSub4" class="ztree"></ul>
                                                            </div>
                                                            <div class="col-sm-6 no-padding">
                                                                <input type="hidden" id="Hidden4" class="treesubhidden" />
                                                                <div class="SelectEduTitle">选择教版</div>
                                                                <ul id="TreeHomSchMat4" class="ztree"></ul>
                                                            </div>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-10"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">子模块:</label>
                                        </div>
                                        <div class="col-sm-11 no-padding text-left">
                                            <select id="tags-homeSching" disabled="disabled" multiple></select>
                                            <div class="btn-group">
                                         <%--       <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle btn_size">
                                                    添加子模块
													    <span class="icon-caret-down icon-on-right"></span>
                                                </button>--%>
                                                <ul id="treehomesch" class="dropdown-menu ztree">
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-10"></div>
                                <div class="row">
                                    <div class="form-group form-inline lineheight">
                                        <div class="col-sm-1 no-padding-right text-right ">
                                            <label for="schnote" class="text_style">基础数据维护:</label>
                                        </div>
                                        <div class="col-sm-10" id="HomeSchoolBaxicStat">
                                            <span class="Enable" rel="0" style="color:red;">客服维护</span>
                                        </div>
                                    </div>
                               </div>
                                <div class="space-10"></div>
                               <div class="row">
                                    <div class="form-group form-inline lineheight">
                                        <div class="col-sm-1 no-padding-right text-right ">
                                            <label for="schnote" class="text_style">服务状态:</label>
                                        </div>
                                        <div class="col-sm-10" id="HomeSchoolServStat">
                                            <span class="Enable" rel="0" style="color:red;">待启用</span>
                                        </div>
                                    </div>
                               </div>
                            </form>
                        </div>
                    </div>

            </div>
            <!-- /.page-content -->


            <!-- /#ace-settings-container -->
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
        <!-- Latest compiled and minified JavaScript -->
        <script src="../../assets/js/bootstrap-tagsinput.js"></script>
        <script src="../../assets/js/jquery.ztree.all-3.5.min.js"></script>
        <script type="text/javascript" src="../../assets/js/jquery.cookie.js"></script>
        <!-- (Optional) Latest compiled and minified JavaScript translation files -->
        <script type="text/javascript">
            var schid='<%=schid%>';
            var treeSonsysObj;//子系统树对象
            var treesubsObj;//科目树对象
            var treegradesNodes =<%=grades%>; 
            var treesubsNodes =<%=subs%>;
            var treesonsysNodes =<%=sonsys%>;
            var umodel=<%=umodelstr%>;
            var  usermanager = <%=usermanagerstr%>;
            
            var treeNodessoure =<%=souretree%>;
            var treeNodeMater =<%=sysmatertree%>; 
            var treeNodesSubss = <%=subsmat%>;
            var showmatertreeNodes = <%=showmatertree%>; 
            var sarxxttreeNode = <%=sarxxttree%>;
            var showmaterxxttree=<%=showmaterxxttree%>;
            var updateGradeDataObj = <%=updateGrade%>;//獲取畢業年級名稱與入學年份
            //毕业年级
            //給畢業年級初始化
            if (updateGradeDataObj) {
                var kindergarten = ""; var primaryschool = ""; var juniorschool = ""; var highschool = "";
                $.each(updateGradeDataObj, function (name, item) {
                    if (item.GradeYear == null) {
                        item.GradeYear = "1999";
                    }
                    if (item.GradeCode.substring(0, 1) == "1") {
                        kindergarten += item.GradeName + "[" + item.GradeYear + "级]";
                    } else if (item.GradeCode.substring(0, 1) == "2") {
                        primaryschool += item.GradeName + "[" + item.GradeYear + "级]";
                    } else if (item.GradeCode.substring(0, 1) == "3") {
                        juniorschool += item.GradeName + "[" + item.GradeYear + "级]";
                    } else if (item.GradeCode.substring(0, 1) == "4") {
                        highschool += item.GradeName + "[" + item.GradeYear + "级]";
                    }
                });
                if (kindergarten != "") {
                    $("#kindergartendom").html("幼儿园：" + kindergarten);
                }
                if (primaryschool != "") {
                    $("#primaryschooldom").html("小学：" + primaryschool);
                }
                if (juniorschool != "") {
                    $("#juniorschooldom").html("初中：" + juniorschool);
                }
                if (highschool != "") {
                    $("#highschooldom").html("高中：" + highschool);
                }
            }
            //num代表传入的数字，n代表要保留的字符的长度  
            function PreFixInterge(num, n) {
                return (Array(n).join(0) + num).slice(-n);
            }
            //用户赋值 
            if(umodel!="1")
            { 
                $('#SchIdstr').val(PreFixInterge(umodel.SchId, 8));
                $('#schname').val(umodel.SchName);
                $('#schaddr').val(umodel.SchAddr); 
                $('#schmaster').val(umodel.SchMaster);
                $('#schmasterpst').val(umodel.MasterPostion);
                $('#schmastertel').val(umodel.SchTel);
                $('#schnote').text(umodel.SchNote);
                $("input[name='iscity'][value="+umodel.IsCity+"]").attr("checked",true);  
                $("input[name='schstat'][value="+umodel.Stat+"]").attr("checked",true);
                //usersub SubId  $("input[name='radioName'][checked]").val(); 
                $("#FrontlineTechni").val(umodel.Artisan);
                $("#PrincipalName").val(umodel.PrincipalName);
                $("#PrincipalTel").val(umodel.PrincipalTel);
                $("#CustomerServiceStaffName").val(umodel.ServiceName);
                $("#CustomerServiceStaffNameTel").val(umodel.ServiceTel);
                //$("#FrontlineTechni").val(umodel.Artisan);
                $("#PlatformName").val(umodel.PlatformName);
                //$("#PlatformIco").text(umodel.PlatformIco);
                $("#PlatformIco").attr("src", "../.."+umodel.PlatformIco);
                if(umodel.PlatformIco!=""){
                    $("#PlatformIco").css("display", "block");
                }
                $("#PlatformUrl").val(umodel.PlatformUrl);
                $("#IPAddress").val(umodel.PlatformIP);

                $("#ResourcePlatformName").val(umodel.ResourcePlatformName);
                //$("#ResourcePlatformIco").text(umodel.ResourcePlatformIco);
                $("#ResourcePlatformIco").attr("src", "../.."+umodel.ResourcePlatformIco);
                if(umodel.ResourcePlatformIco!=""){
                    $("#ResourcePlatformIco").css("display", "block");
                }
                $("#ResourcePlatformUrl").val(umodel.ResourcePlatformUrl);
                $("#ResourcePlatformIP").val(umodel.ResourcePlatformIP);
                $("#Creator").val(umodel.SchCreator);
                //管理平台
                if(umodel.SonSysStat==0){
                    $("#SonsysStat").html("<span class=\"Enable\" rel=\"1\">停用</span>");
                    $("#SonsysStat .Enable").css("color", "red");
                }else{
                    $("#SonsysStat").html("<span class=\"Enable\" rel=\"0\">已启用</span>");
                    $("#SonsysStat .Enable").css("color", "green");
                }
                //资源平台
                if(umodel.SourceSerStat==0){
                    $("#SourceServerStat").html("<span class=\"Enable\" rel=\"0\">停用</span>");
                    $("#SourceServerStat .Enable").css("color", "red");
                }else{
                    $("#SourceServerStat").html("<span class=\"Enable\" rel=\"1\">已启用</span>");
                    $("#SourceServerStat .Enable").css("color", "green");
                }
                //家校互通平台
                $("#HomeSchoolingName").val(umodel.HomeSchPlatName);
                $("#HomeSchoolingIco").text(umodel.HomeSchPlatIco);
                $("#HomeSchoolingImg").attr("src", "../.." + umodel.HomeSchPlatIco);
               
                if(umodel.HomeSchPlatIco!=""){
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
                    if (umodel.HomeSchBasicStat == 0) {
                        $("#HomeSchoolBaxicStat .Enable").html("客服维护");
                        $("#HomeSchoolBaxicStat .Enable").attr("rel", "0");
                        $("#HomeSchoolBaxicStat .Enable").css("color", "green");
                    } else {
                        $("#HomeSchoolBaxicStat .Enable").html("学校维护");
                        $("#HomeSchoolBaxicStat .Enable").attr("rel", "1");
                        $("#HomeSchoolBaxicStat .Enable").css("color", "green");
                    }
                }
                //停用值为0；已启用值为1。
                if (umodel.HomeschServStat == 1) {
                    $("#HomeSchoolServStat .Enable").html("已启用");
                    $("#HomeSchoolServStat .Enable").val("rel", "1");
                    $("#HomeSchoolServStat .Enable").css("color", "green");
                } else {
                    $("#HomeSchoolServStat .Enable").html("停用");
                    $("#HomeSchoolServStat .Enable").val("rel", "0");
                }
            }
             
            //---------------------------------------------------------------------

            //遍历学段、年级的DOM
            var SchoolSection="";
            var mydate = new Date();
            var sysyearcurrent = mydate.getFullYear();
            var sysmonth = mydate.getMonth();
            var StartYear="";
            if(sysmonth<8){StartYear=sysyearcurrent-1;}else{StartYear=sysyearcurrent;}
            $.each(treegradesNodes,function(index,item){
                if(item.pId=="0"){
                    //alert(item.GradeYear);
                    SchoolSection+="<div class=\"row\">";
                    SchoolSection+="    <div class=\"col-sm-1 no-padding-right\">";
                    SchoolSection+="        <label><span class=\"color\">学段:</span></label>";
                    SchoolSection+="        <label>";
                    SchoolSection+="            <input name=\"gradechkl\" type=\"checkbox\" disabled=\"disabled\"  class=\"ace\" value=\""+item.id+"\" />";
                    SchoolSection+="            <span class=\"lbl\">"+item.name+"</span>";
                    SchoolSection+="        </label>";
                    SchoolSection+="    </div>";
                    SchoolSection+="    <div class=\"col-sm-11 no-padding\">";
                    SchoolSection+="    <div class=\"col-sm-1 no-padding text-right nianji\"><label><span class=\"color\">年级：</span></label></div>";
                    $.each(treegradesNodes,function(indexs,items){
                        if(item.id==items.pId&&items.IsFinish=="0"){
                            SchoolSection+="<div class=\"col-sm-1 no-padding\">";
                            SchoolSection+="    <label>";
                            SchoolSection+="        <input name=\"gradechk\" type=\"checkbox\" disabled=\"disabled\" class=\"ace\" StartYear=\""+StartYear+"\" GradeName=\""+items.name+"\" GradeId=\""+items.GradeId+"\" value=\""+items.id+"\">";
                            SchoolSection+="        <span class=\"lbl\">"+items.name+"【"+StartYear+"】</span>";
                            SchoolSection+="    </label>";
                            SchoolSection+="</div>";
                            StartYear--;
                        }
                    })
                    SchoolSection+="    </div>";
                    SchoolSection+="</div>";
                }
            
                if(item.id=="1"||item.id=="2"||item.id=="3"||item.id=="4"){
                    if(sysmonth<8){
                        StartYear=sysyearcurrent-1;
                    }else{
                        StartYear=sysyearcurrent;
                    }
                }

            });
            $("#SchoolSection").html(SchoolSection);

            //下拉部门框点击屏蔽
            $('.dropdown-menu').click(function(e) {
                e.stopPropagation();
            });
            //遍历开设科目json
            var PritreesubsNodes="";
            for(var p in treesubsNodes){
                if (treesubsNodes[p].checked=="true") {
                    PritreesubsNodes+="<span>"+treesubsNodes[p].name+"</span>,&nbsp; ";
                } 
            }
            $("#selsubs").html(PritreesubsNodes);
            //遍历子系统json
            var PritreesonsysNodes="";
            for(var p in treesonsysNodes){//遍历json数组时，这么写p为索引，0,1
                if (treesonsysNodes[p].checked=="true") {
                    PritreesonsysNodes+="<span>"+treesonsysNodes[p].name+"</span>,&nbsp; ";
                } 
            }
            $("#sonsys").html(PritreesonsysNodes);
            //------------------------------------------------------------------------------------------------------------------
            /*下面是学段与年级代码*/
            /*下面是学段与年级代码*/
            $("input[name='gradechkl']").change(function () {
                var tf = $(this).is(':checked')
                var vl = $(this).attr("value");
                var grade = $("input[name='gradechk']");
                //if(dotype=="e"){
                var gradearr = $("input[name='gradechk']");
                var chknull = 0;//默认相应学段对应的年级都没有选中
                for (var i = 0; i < gradearr.length; i++) {
                    var gradeval = $(gradearr[i]).attr("value");
                    var gradesubval = gradeval.substring(0, 1);
                    if (gradesubval == vl) {
                        var chkbool = $("input[name='gradechk'][value=" + gradeval + "]").is(':checked');
                        if (chkbool == true) {
                            chknull += 1;
                        }
                    }
                }
                if (chknull != 0) {//判断相应学段对应的年级是否都没有选中
                    alert("请先取消年级勾选状态");
                    $("input[name='gradechkl'][value=\"" + vl + "\"]").prop("checked", "checked");
                    return;
                }
                //}else{
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
                // }
            });
            //----------------------------------------------------------------家校互通-------------------------------
            
            //初始化子模块选择
            $("#tags-homeSching").tagsinput({
                itemValue: 'id',
                itemText: 'text',
            });
            //资源模块删除触发
            $('#tags-homeSching').on('itemRemoved', function (event) {
                var node = treehomeschObj.getNodeByParam("id", event.item.id, null);
                treehomeschObj.checkNode(node, false, false);
            });
            var treehomeschObj;
            var settinghomsch = {
                check: {
                    enable: true,
                    //autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                    chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                    chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
                },
                view: {
                    dblClickExpand: false,
                    showLine: true,
                    selectedMulti: true
                },
                data: {
                    simpleData: {
                        enable: true,
                        idKey: "id",
                        pIdKey: "pId",
                        checked: "checked",
                        rootPId: ""
                    }
                },
                callback: {
                    beforeClick: function (treeId, treeNode) {
                    },
                    onCheck: HomeSchTreeOnCheck
                }
            };
            $(function () {
                if (sarxxttreeNode) {
                    for (var x in sarxxttreeNode) {
                        if (sarxxttreeNode[x].checked == 'true') {
                            $('#tags-homeSching').tagsinput('add', { id: sarxxttreeNode[x].id, text: sarxxttreeNode[x].name });
                        }

                    }
                }
                treehomeschObj = $.fn.zTree.init($("#treehomesch"), settinghomsch, sarxxttreeNode);
                treehomeschObj.expandAll(true);

            });
            //与选中联动
            function HomeSchTreeOnCheck(event, treeId, treeNode) {
                if (treeNode.checked) {
                    $('#tags-homeSching').tagsinput('add', { id: treeNode.id, text: treeNode.name });
                } else {
                    $('#tags-homeSching').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
                }
            };
            //声明变量区
            var treeHomeSubsObj1 = ""; var treeHomeSubsObj2 = ""; var treeHomeSubsObj3 = ""; var treeHomeSubsObj4 = "";
            var treeHomeMaterObj1 = ""; treeHomeMaterObj2 = ""; treeHomeMaterObj3 = ""; treeHomeMaterObj4 = "";
            ///单击科目的CheckBox或radio时触发的回调函数
            function TreeHomSchSubsOnCheck(event, treeId, treeNode) {
                var subeduvernum = treeId.substring(treeId.length - 1, treeId.length);
                var curentsubcode = treeNode.id;
                var tagsval = $("#TagsHomSch" + subeduvernum).val();
                var treeObjs = $.fn.zTree.getZTreeObj("TreeHomSchMat" + subeduvernum);
                treeObjs.checkAllNodes();
                var nodess = treeObjs.getNodes();
                if (nodess.length > 0) {
                    for (var j = 0; j < nodess.length; j++) {
                        if (nodess[j].SubCode == curentsubcode && nodess[j].PerCode == subeduvernum) {
                            nodess[j].checked = true;

                        }
                        nodess[j].subcodechk = treeNode.id;//SubCode
                        nodess[j].SubName = treeNode.name;//SubName
                        treeObjs.updateNode(nodess[j]);
                    }
                }
                if (treeNode.checked == false) {
                    for (var i = 0; i < tagsval.length; i++) {
                        if (tagsval[i].split('|')[0] == treeNode.id) {
                            $("#TagsHomSch" + subeduvernum).tagsinput('remove', { id: tagsval[i], text: null });
                        }
                    }
                }
            }
            ///单击教版的CheckBox或radio时触发的回调函数
            function TreeHomSchMaterOnCheck(event, treeId, treeNode) {
                var treeIdnum = treeId.substring(treeId.length - 1, treeId.length);
                if (treeNode.subcodechk != "") {
                    var submatid = treeNode.subcodechk + "|" + treeNode.MaterCode;
                    var submattext = treeNode.SubName + "(" + treeNode.name + ")";

                    var treeObjSubsstr = $.fn.zTree.getZTreeObj("TreeHomSchSub" + treeIdnum);//科目树
                    var treeObjsubsenode = treeObjSubsstr.getNodeByParam("id", treeNode.subcodechk, null);//对应科目节点

                    var treeMatObjs = $.fn.zTree.getZTreeObj(treeId);//教版树
                    if (treeNode.checked) {
                        $("#TagsHomSch" + treeIdnum).tagsinput('add', { id: submatid, text: submattext });
                        treeObjsubsenode.checked = true;
                        treeObjSubsstr.updateNode(treeObjsubsenode);
                    } else {
                        $("#TagsHomSch" + treeIdnum).tagsinput('remove', { id: submatid, text: submattext });
                        var nodess = treeMatObjs.getCheckedNodes(true);
                        if (nodess.length == 0) {
                            treeObjsubsenode.checked = false;
                            treeObjSubsstr.updateNode(treeObjsubsenode);
                        }
                    }
                    $("#HomSchPer" + treeIdnum).prop("checked", "checked");
                } else {
                    alert("请选择科目");
                }
            }
            //声明多选select变量
            $("#TagsHomSch1").tagsinput({
                itemValue: 'id',
                itemText: 'text',
            });
            $("#TagsHomSch2").tagsinput({
                itemValue: 'id',
                itemText: 'text',
            });
            $("#TagsHomSch3").tagsinput({
                itemValue: 'id',
                itemText: 'text',
            });
            $("#TagsHomSch4").tagsinput({
                itemValue: 'id',
                itemText: 'text',
            });
            //以下是学科科目---Start
            var settingSub = {
                check: {
                    enable: true,
                    //autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                    chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                    chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
                    chkDisabledInherit: true
                },
                view: {
                    dblClickExpand: false,
                    showLine: true,
                    selectedMulti: true
                },
                data: {
                    simpleData: {
                        enable: true,
                        idKey: "id",
                        pIdKey: "pId",
                        checked: "checked",
                        datacode: "datacode",
                        rootPId: "",
                        chkDisabled: true,
                    }
                },
                callback: {
                    beforeClick: function (treeId, treeNode) {
                        var subeduvernum = treeId.substring(treeId.length - 1, treeId.length);//科目树节点ID
                        var curentsubcode = treeNode.id;//当前科目CODE
                        var tagsval = $("#TagsHomSch" + subeduvernum).val();//科目选择
                        var treeObjs = $.fn.zTree.getZTreeObj("TreeHomSchMat" + subeduvernum);//教版树
                        var treeObjSubs = $.fn.zTree.getZTreeObj("TreeHomSchSub" + subeduvernum);//科目树
                        treeObjs.checkAllNodes(false);
                        var nodess = treeObjs.getNodes();//教版树节点
                        if (nodess.length > 0) {
                            if (tagsval != null && tagsval.length > 0)//有选择的科目
                            {
                                for (var i = 0; i < tagsval.length; i++) {
                                    var submaterstr = tagsval[i];
                                    var submater = submaterstr.split('|');
                                    if (submater[0] == curentsubcode) {
                                        var enode = treeObjs.getNodeByParam("id", submater[1], null);
                                        enode.checked = true;
                                        treeObjs.updateNode(enode);
                                    }
                                }
                            }
                            for (var j = 0; j < nodess.length; j++) {
                                if (nodess[j].SubCode == curentsubcode) {// && nodess[j].PerCode == subeduvernum
                                    nodess[j].checked = true;
                                }
                                nodess[j].subcodechk = treeNode.id;//SubCode
                                nodess[j].SubName = treeNode.name;//SubName
                                treeObjs.updateNode(nodess[j]);
                            }

                        }
                    },
                    onCheck: TreeHomSchSubsOnCheck//单击复选框或者单选框时执行
                }
            };
            //以上是学科科目---End
            //初始化科目树
            treeHomeSubsObj1 = $.fn.zTree.init($("#TreeHomSchSub1"), settingSub, treeNodesSubss);//初始化幼儿园科目树
            treeHomeSubsObj2 = $.fn.zTree.init($("#TreeHomSchSub2"), settingSub, treeNodesSubss);//初始化小学科目树
            treeHomeSubsObj3 = $.fn.zTree.init($("#TreeHomSchSub3"), settingSub, treeNodesSubss);//初始化初中科目树
            treeHomeSubsObj4 = $.fn.zTree.init($("#TreeHomSchSub4"), settingSub, treeNodesSubss);//初始化高中科目树
            //以下是教版---Start
            var settingmater = {
                check: {
                    enable: true,
                    //autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                    chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                    chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
                },
                view: {
                    dblClickExpand: false,
                    showLine: true,
                    selectedMulti: true
                },
                data: {
                    simpleData: {
                        enable: true,
                        idKey: "id",
                        pIdKey: "pId",
                        checked: "checked",
                        rootPId: "",
                        subcodechk: "subcodechk"
                    }
                },
                callback: {
                    beforeClick: function (treeId, treeNode) {
                        //alert(treeNode.subcodechk);
                        var treeObjMats = $.fn.zTree.getZTreeObj("TreeHomSchMat" + treeIdnum);//教版树
                        var treeusernode = treeObjMats.getNodeByParam("id", treeNode.id, null);
                        treeObjMats.selectNode(treeusernode, false);
                    },
                    onCheck: TreeHomSchMaterOnCheck
                }
            };
            //以上是教版---End
            //初始化教版树
            treeHomeMaterObj1 = $.fn.zTree.init($("#TreeHomSchMat1"), settingmater, treeNodeMater);//初始化幼儿园教版树
            treeHomeMaterObj2 = $.fn.zTree.init($("#TreeHomSchMat2"), settingmater, treeNodeMater);//初始化小学教版树
            treeHomeMaterObj3 = $.fn.zTree.init($("#TreeHomSchMat3"), settingmater, treeNodeMater);//初始化初中教版树
            treeHomeMaterObj4 = $.fn.zTree.init($("#TreeHomSchMat4"), settingmater, treeNodeMater);//初始化高中教版树

            $(function () {
                //当触发多选select删除按钮时
                $("#TagsHomSch1").on('itemRemoved', function (event) {
                    var eidstr = event.item.id;//当前删除教版id值
                    var eidsubid = eidstr.split('|')[0];//科目code
                    var eidmatid = eidstr.split('|')[1];//教版code
                    //
                    var node = treeHomeMaterObj1.getNodeByParam("id", eidmatid, null);
                    treeHomeMaterObj1.checkNode(node, false, false);//取消当前教版code复选框的勾选状态
                    //查询科目教版多选（select)下拉框中是否还有当前科目code
                    var issubtags1 = 0
                    var tags1val = $("#TagsHomSch1").val();
                    for (var i in tags1val) {
                        if (tags1val[i].split('|')[0] == eidsubid) {
                            issubtags1++;
                        }
                    }
                    if (issubtags1 == 0) {//如果没有科目code
                        var nodesub = treeHomeSubsObj1.getNodeByParam("id", eidsubid, null);
                        nodesub.checked = false;
                        treeHomeSubsObj1.updateNode(nodesub);//取消当前科目code复选框的勾选状态
                    }
                    if (Number($("#TagsHomSch1").val()) == 0) {
                        $("#HomSchPer1").prop("checked", false);
                    }
                });
                $("#TagsHomSch2").on('itemRemoved', function (event) {
                    var eidstr = event.item.id;//当前删除教版id值
                    var eidsubid = eidstr.split('|')[0];//科目code
                    var eidmatid = eidstr.split('|')[1];//教版code
                    //
                    var node = treeHomeMaterObj2.getNodeByParam("id", eidmatid, null);
                    treeHomeMaterObj2.checkNode(node, false, false);//取消当前教版code复选框的勾选状态
                    //查询科目教版多选（select)下拉框中是否还有当前科目code
                    var issubtags2 = 0
                    var tags1val = $("#TagsHomSch2").val();
                    for (var i in tags1val) {
                        if (tags1val[i].split('|')[0] == eidsubid) {
                            issubtags2++;
                        }
                    }
                    if (issubtags2 == 0) {//如果没有科目code
                        var nodesub = treeHomeSubsObj2.getNodeByParam("id", eidsubid, null);
                        nodesub.checked = false;
                        treeHomeSubsObj2.updateNode(nodesub);//取消当前科目code复选框的勾选状态
                    }
                    if (Number($("#TagsHomSch2").val()) == 0) {
                        $("#HomSchPer2").prop("checked", false);
                    }
                });
                $("#TagsHomSch3").on('itemRemoved', function (event) {
                    var eidstr = event.item.id;//当前删除教版id值
                    var eidsubid = eidstr.split('|')[0];//科目code
                    var eidmatid = eidstr.split('|')[1];//教版code
                    //
                    var node = treeHomeMaterObj3.getNodeByParam("id", eidmatid, null);
                    treeHomeMaterObj3.checkNode(node, false, false);//取消当前教版code复选框的勾选状态
                    //查询科目教版多选（select)下拉框中是否还有当前科目code
                    var issubtags3 = 0
                    var tags1val = $("#TagsHomSch3").val();
                    for (var i in tags1val) {
                        if (tags1val[i].split('|')[0] == eidsubid) {
                            issubtags3++;
                        }
                    }
                    if (issubtags3 == 0) {//如果没有科目code
                        var nodesub = treeHomeSubsObj3.getNodeByParam("id", eidsubid, null);
                        nodesub.checked = false;
                        treeHomeSubsObj3.updateNode(nodesub);//取消当前科目code复选框的勾选状态
                    }
                    if (Number($("#TagsHomSch3").val()) == 0) {
                        $("#HomSchPer3").prop("checked", false);
                    }
                });
                $("#TagsHomSch4").on('itemRemoved', function (event) {
                    var eidstr = event.item.id;//当前删除教版id值
                    var eidsubid = eidstr.split('|')[0];//科目code
                    var eidmatid = eidstr.split('|')[1];//教版code
                    //
                    var node = treeHomeMaterObj4.getNodeByParam("id", eidmatid, null);
                    treeHomeMaterObj4.checkNode(node, false, false);//取消当前教版code复选框的勾选状态
                    //查询科目教版多选（select)下拉框中是否还有当前科目code
                    var issubtags4 = 0
                    var tags1val = $("#TagsHomSch4").val();
                    for (var i in tags1val) {
                        if (tags1val[i].split('|')[0] == eidsubid) {
                            issubtags4++;
                        }
                    }
                    if (issubtags4 == 0) {//如果没有科目code
                        var nodesub = treeHomeSubsObj4.getNodeByParam("id", eidsubid, null);
                        nodesub.checked = false;
                        treeHomeSubsObj4.updateNode(nodesub);//取消当前科目code复选框的勾选状态
                    }
                    if (Number($("#TagsHomSch4").val()) == 0) {
                        $("#HomSchPer4").prop("checked", false);
                    }
                });

                //单击科目教版按钮时触发
                $(document).on("click", ".submatbtn", function () {
                    var relid = $(this).attr("relid");
                    var treeObj = $.fn.zTree.getZTreeObj("TreeHomSchSub" + relid);
                    treeObj.checkAllNodes(false);
                    var tagsval = $("#TagsHomSch" + relid).val();
                    var nodes = treeObj.getNodes();
                    for (var i in nodes) {
                        nodes[i].chkDisabled = true;
                        treeObj.updateNode(nodes[i]);
                    }
                    if (tagsval) {
                        for (var i = 0; i < tagsval.length; i++) {
                            var tagsval1 = tagsval[i].split('|')[0];
                            var enodeext = treeObj.getNodeByParam("id", tagsval1, null);
                            enodeext.checked = true;
                            treeObj.updateNode(enodeext);
                        }
                        //默认显示第一个选中科目的教版
                        for (var i = 0; i < tagsval.length; i++) {
                            var tagsval1 = tagsval[i].split('|')[0];
                            var enodeext = treeObj.getNodeByParam("id", tagsval1, null);
                            treeObj.setting.callback.beforeClick(treeObj.setting.treeId, enodeext);
                            treeObj.selectNode(enodeext);
                            break;

                        }
                    } else {
                        //var treeObjSubs = $.fn.zTree.getZTreeObj("TreeSub" + relid);
                        treeObj.checkAllNodes();
                        //科目树默认第一个触发单击事件
                        var enodeext = treeObj.getNodeByParam("id", "01", null);
                        treeObj.setting.callback.beforeClick(treeObj.setting.treeId, enodeext);
                        treeObj.selectNode(enodeext);
                    }
                });

                if (showmaterxxttree) {
                    for (var x in showmaterxxttree) {
                        if (showmaterxxttree[x].PerCode == "1") {
                            //if (showmatertreeNodes[x].checked ==true) {
                            var submatsid = showmaterxxttree[x].SubCode + "|" + showmaterxxttree[x].MaterCode;
                            var submattext = showmaterxxttree[x].SubName + "(" + showmaterxxttree[x].MaterName + ")";
                            $("#TagsHomSch1").tagsinput('add', { id: submatsid, text: submattext });
                            //}
                        }
                    }
                }
                if ($("#TagsHomSch1").val() != null) {
                    $("#HomSchPer1").prop("checked", true);
                }

                if (showmaterxxttree) {
                    for (var x in showmaterxxttree) {
                        if (showmaterxxttree[x].PerCode == "2") {
                            //if (showmatertreeNodes[x].checked ==true) {
                            var submatsid = showmaterxxttree[x].SubCode + "|" + showmaterxxttree[x].MaterCode;
                            var submattext = showmaterxxttree[x].SubName + "(" + showmaterxxttree[x].MaterName + ")";
                            $("#TagsHomSch2").tagsinput('add', { id: submatsid, text: submattext });
                            //}
                        }
                    }
                }
                if ($("#TagsHomSch2").val() != null) {
                    $("#HomSchPer2").prop("checked", true);
                }

                if (showmaterxxttree) {
                    for (var x in showmaterxxttree) {
                        if (showmaterxxttree[x].PerCode == "3") {
                            //if (showmatertreeNodes[x].checked ==true) {
                            var submatsid = showmaterxxttree[x].SubCode + "|" + showmaterxxttree[x].MaterCode;
                            var submattext = showmaterxxttree[x].SubName + "(" + showmaterxxttree[x].MaterName + ")";
                            $("#TagsHomSch3").tagsinput('add', { id: submatsid, text: submattext });
                            //}
                        }
                    }
                }
                if ($("#TagsHomSch3").val() != null) {
                    $("#HomSchPer3").prop("checked", true);
                }

                if (showmaterxxttree) {
                    for (var x in showmaterxxttree) {
                        if (showmaterxxttree[x].PerCode == "4") {
                            //if (showmatertreeNodes[x].checked ==true) {
                            var submatsid = showmaterxxttree[x].SubCode + "|" + showmaterxxttree[x].MaterCode;
                            var submattext = showmaterxxttree[x].SubName + "(" + showmaterxxttree[x].MaterName + ")";
                            $("#TagsHomSch4").tagsinput('add', { id: submatsid, text: submattext });
                            //}
                        }
                    }
                }
                if ($("#TagsHomSch4").val() != null) {
                    $("#HomSchPer4").prop("checked", true);
                }

            })
//-----------------------------------------------------------------------------------------------------------------------------------------------
            
            //子系统树配置
            var settingsonsys = {
                check: {
                    enable: true,
                    //autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]   
                    chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]   
                    chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
                },
                view: {
                    dblClickExpand: false,
                    showLine: true,
                    selectedMulti: true
                },
                data: {
                    simpleData: {
                        enable: true,
                        idKey: "id",
                        pIdKey: "pId",
                        checked: "checked",
                        rootPId: "0"
                    }
                },
                callback: {
                    beforeClick: function (treeId, treeNode) {
                    },
                    onCheck: SonsysTreeOnCheck
                }
            };
            //与选中联动(子系统选择）
            function SonsysTreeOnCheck(event, treeId, treeNode) {
                if (treeNode.checked) {
                    $('#sonsys').tagsinput('add', { id: treeNode.id, text: treeNode.name });
                } else {
                    $('#sonsys').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
                }
            };
            //初始化
            $(function () {
                //treesubsObj = $.fn.zTree.init($("#substree"), settingsubs, treesubsNodes);//选择科目初始化
                // treeSonsysObj = $.fn.zTree.init($("#sonsystree"), settingsonsys, treesonsysNodes);//选择子系统初始化
                //年级树
                if(treegradesNodes)
                {
                    for (var x in treegradesNodes) {
                        if(treegradesNodes[x].checked=='true')
                        {
                            var arry = [ "1", "2", "3", "4" ]; 
                            var result= $.inArray(treegradesNodes[x].id, arry);
                            if(result==-1)
                            {
                                $("input[name='gradechk'][value="+treegradesNodes[x].id+"]").attr("checked",true); 
                                $("input[name='gradechkl'][value="+treegradesNodes[x].pId+"]").attr("checked",true); 
                            }
                        
                        }
    
                    }
                } 
            });
         
            ///单击科目的CheckBox或radio时触发的回调函数
            function TreeSubsOnCheck(event, treeId, treeNode) {
                var subeduvernum = treeId.substring(treeId.length - 1, treeId.length);
                var curentsubcode = treeNode.id;
                var tagsval = $("#Tags" + subeduvernum).val();
                var treeObjs = $.fn.zTree.getZTreeObj("TreeEduVer" + subeduvernum);
                treeObjs.checkAllNodes();
                var nodess = treeObjs.getNodes();
                if (nodess.length > 0) {
                    for (var j = 0; j < nodess.length; j++) {
                        if (nodess[j].SubCode == curentsubcode && nodess[j].PerCode == subeduvernum) {
                            nodess[j].checked =true;

                        }
                        nodess[j].subcodechk = treeNode.id;//SubCode
                        nodess[j].SubName = treeNode.name;//SubName
                        treeObjs.updateNode(nodess[j]);
                    }
                }
                if (treeNode.checked == false) {
                    for (var i = 0; i < tagsval.length; i++) {
                        if (tagsval[i].split('|')[0] == treeNode.id) {
                            $("#Tags" + subeduvernum).tagsinput('remove', { id: tagsval[i], text: null });
                        }
                    }
                }
                //$("#TreeEduVer" + subeduvernum).css("display", "block");
            }

            ///单击教版的CheckBox或radio时触发的回调函数
            function TreeMaterOnCheck(event, treeId, treeNode) {
                var treeIdnum = treeId.substring(treeId.length - 1, treeId.length);
                if (treeNode.subcodechk!="") {
                    var submatid = treeNode.subcodechk + "|" + treeNode.MaterCode;
                    var submattext = treeNode.SubName + "(" + treeNode.name + ")";

                    var treeObjSubsstr = $.fn.zTree.getZTreeObj("TreeSub" + treeIdnum);//科目树
                    var treeObjsubsenode = treeObjSubsstr.getNodeByParam("id", treeNode.subcodechk, null);//对应科目节点
        
                    var treeMatObjs = $.fn.zTree.getZTreeObj(treeId);//教版树
                    if (treeNode.checked) {
                        $("#Tags" + treeIdnum).tagsinput('add', { id: submatid, text: submattext });
                        treeObjsubsenode.checked = true;
                        treeObjSubsstr.updateNode(treeObjsubsenode);
                    } else {
                        $("#Tags" + treeIdnum).tagsinput('remove', { id: submatid, text: submattext });
                        var nodess = treeMatObjs.getCheckedNodes(true);
                        if (nodess.length == 0)
                        {
                            treeObjsubsenode.checked = false;
                            treeObjSubsstr.updateNode(treeObjsubsenode);
                        }            
                    }
                    $("#Per" + treeIdnum).prop("checked", "checked");
                } else {
                    alert("请选择科目");
                }
                //alert(treeNode.tId + ", " + treeNode.name + "," + treeNode.checked + "," + treeNode.SubCode);
            }
            //声明多选select变量
            $("#Tags1").tagsinput({
                itemValue: 'id',
                itemText: 'text',
            });
            $("#Tags2").tagsinput({
                itemValue: 'id',
                itemText: 'text',
            });
            $("#Tags3").tagsinput({
                itemValue: 'id',
                itemText: 'text',
            });
            $("#Tags4").tagsinput({
                itemValue: 'id',
                itemText: 'text',
            });
            //当触发多选select删除按钮时
            $("#Tags1").on('itemRemoved', function (event) {
                $("#downdom1").css("display", "none");
            });
            $("#Tags2").on('itemRemoved', function (event) {
                $("#downdom2").css("display", "none");
            });
            $("#Tags3").on('itemRemoved', function (event) {
                $("#downdom3").css("display", "none");
            });
            $("#Tags4").on('itemRemoved', function (event) {
                $("#downdom4").css("display", "none");
            });
          
            for (var i = 1; i <= 4; i++) {
                //以下是学科科目---Start
                var treeSubObj = "TreeSubObj" + i;
                var settingSub = "settingSub" + i;
                settingSub = {
                    check: {
                        enable: true,
                        //autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                        chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                        chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
                        chkDisabledInherit: true
                    },
                    view: {
                        dblClickExpand: false,
                        showLine: true,
                        selectedMulti: true
                    },
                    data: {
                        simpleData: {
                            enable: true,
                            idKey: "id",
                            pIdKey: "pId",
                            checked: "checked",
                            datacode: "datacode",
                            rootPId: "",
                            chkDisabled:true,
                        }
                    },
                    callback: {
                        beforeClick: function (treeId, treeNode) {
                            var subeduvernum = treeId.substring(treeId.length - 1, treeId.length);//科目树节点ID
                            var curentsubcode = treeNode.id;//当前科目CODE
                            var tagsval = $("#Tags" + subeduvernum).val();//科目选择
                            var treeObjs = $.fn.zTree.getZTreeObj("TreeEduVer" + subeduvernum);//教版树
                            var treeObjSubs = $.fn.zTree.getZTreeObj("TreeSub" + subeduvernum);//科目树
                            treeObjs.checkAllNodes(false);
                            var nodess = treeObjs.getNodes();//教版树节点
                            if (nodess.length > 0) {
                                if (tagsval!=null&&tagsval.length > 0)//有选择的科目
                                {
                                    for (var i = 0; i < tagsval.length; i++) {
                                        var submaterstr = tagsval[i];
                                        var submater = submaterstr.split('|');
                                        if (submater[0] == curentsubcode)
                                        {
                                            var enode = treeObjs.getNodeByParam("id", submater[1], null);
                                            enode.checked =true;
                                            treeObjs.updateNode(enode);
                                        }
                                    }
                                }
                                for (var j = 0; j < nodess.length; j++) {
                                    if (nodess[j].SubCode == curentsubcode) {// && nodess[j].PerCode == subeduvernum
                                        nodess[j].checked =true;
                                    }
                                    nodess[j].subcodechk = treeNode.id;//SubCode
                                    nodess[j].SubName = treeNode.name;//SubName
                                    treeObjs.updateNode(nodess[j]);
                                }
                    
                            }
                            //var enodes = treeObjSubs.getNodeByParam("id", treeNode.id, null);
                            //enodes.checked =true;
                            //treeObjSubs.updateNode(enodes);

                            $("#TreeEduVer" + subeduvernum).css("display", "block");
                        },
                        onCheck: TreeSubsOnCheck//单击复选框或者单选框时执行
                    }
                };
                treeSubObj = $.fn.zTree.init($("#TreeSub" + i), settingSub, treeNodesSubss);


                //以上是学科科目---End
                //以下是教版---Start
                var treeMaterObj="TreeEduVer"+i;
                var settingMater = "settingMater" + i;
                settingmater = {
                    check: {
                        enable: true,
                        //autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                        chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                        chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
                    },
                    view: {
                        dblClickExpand: false,
                        showLine: true,
                        selectedMulti: true
                    },
                    data: {
                        simpleData: {
                            enable: true,
                            idKey: "id",
                            pIdKey: "pId",
                            checked: "checked",
                            rootPId: "",
                            subcodechk:"subcodechk"
                        }
                    },
                    callback: {
                        beforeClick: function (treeId, treeNode) {
                            //alert(treeNode.subcodechk);
                            var treeIdnum = treeId.substring(treeId.length - 1, treeId.length);
                            if (treeNode.subcodechk != "") {
                                var submatid = treeNode.subcodechk + "|" + treeNode.MaterCode;
                                var submattext = treeNode.SubName + "(" + treeNode.name + ")";
                                $("#Tags" + treeIdnum).tagsinput('add', { id: submatid, text: submattext });
                                $("#" + treeId).parent().parent().parent().parent().parent().find("#Per" + treeIdnum).prop("checked", "checked");

                                var treeObjMats = $.fn.zTree.getZTreeObj("TreeEduVer" + treeIdnum);//教版树
                                var enodemats = treeObjMats.getNodeByParam("id", treeNode.id, null);
                                enodemats.checked =true;
                                treeObjMats.updateNode(enodemats);

                            } else {
                                alert("请选择科目");
                            }
                            //alert(treeNode.tId + ", " + treeNode.name + "," + treeNode.checked);
                        },
                        onCheck: TreeMaterOnCheck
                    }
                };
                treeMaterObj = $.fn.zTree.init($("#TreeEduVer" + i), settingmater, treeNodeMater);
                //以上是教版---End
            }

            $(function () {
                if (showmatertreeNodes) {
                    for (var x in showmatertreeNodes) {
                        if (showmatertreeNodes[x].PerCode == "1") {
                            //if (showmatertreeNodes[x].checked ==true) {
                            var submatsid = showmatertreeNodes[x].SubCode + "|" + showmatertreeNodes[x].MaterCode;
                            var submattext = showmatertreeNodes[x].SubName + "(" + showmatertreeNodes[x].MaterName + ")";
                            $("#Tags1").tagsinput('add', { id: submatsid, text: submattext });
                            //}
                        }
                    }
                }
                if ($("#Tags1").val() != null) {
                    $("#Per1").prop("checked", true);
                }

                if (showmatertreeNodes) {
                    for (var x in showmatertreeNodes) {
                        if (showmatertreeNodes[x].PerCode == "2") {
                            //if (showmatertreeNodes[x].checked ==true) {
                            var submatsid = showmatertreeNodes[x].SubCode + "|" + showmatertreeNodes[x].MaterCode;
                            var submattext = showmatertreeNodes[x].SubName + "(" + showmatertreeNodes[x].MaterName + ")";
                            $("#Tags2").tagsinput('add', { id: submatsid, text: submattext });
                            //}
                        }
                    }
                }
                if ($("#Tags2").val() != null) {
                    $("#Per2").prop("checked", true);
                }

                if (showmatertreeNodes) {
                    for (var x in showmatertreeNodes) {
                        if (showmatertreeNodes[x].PerCode == "3") {
                            //if (showmatertreeNodes[x].checked ==true) {
                            var submatsid = showmatertreeNodes[x].SubCode + "|" + showmatertreeNodes[x].MaterCode;
                            var submattext = showmatertreeNodes[x].SubName + "(" + showmatertreeNodes[x].MaterName + ")";
                            $("#Tags3").tagsinput('add', { id: submatsid, text: submattext });
                            //}
                        }
                    }
                }
                if ($("#Tags3").val() != null) {
                    $("#Per3").prop("checked", true);
                }

                if (showmatertreeNodes) {
                    for (var x in showmatertreeNodes) {
                        if (showmatertreeNodes[x].PerCode == "4") {
                            //if (showmatertreeNodes[x].checked ==true) {
                            var submatsid = showmatertreeNodes[x].SubCode + "|" + showmatertreeNodes[x].MaterCode;
                            var submattext = showmatertreeNodes[x].SubName + "(" + showmatertreeNodes[x].MaterName + ")";
                            $("#Tags4").tagsinput('add', { id: submatsid, text: submattext });
                            //}
                        }
                    }
                }
                if ($("#Tags4").val() != null) {
                    $("#Per4").prop("checked", true);
                }
                
                //单击科目教版按钮时触发
                $(document).on("click", ".submatbtn", function () {
                    var relid = $(this).attr("relid");
                    if ($("#downdom" + relid).is(':visible')) {
                        $("#downdom" + relid).css("display", "none");
                    } else {
                        $("#downdom" + relid).css("display", "block");
                        $("#TreeSub" + relid).css("display", "block");
                        $("#TreeEduVer" + relid).css("display", "none");
                        var treeObj = $.fn.zTree.getZTreeObj("TreeSub" + relid);
                        treeObj.checkAllNodes(false);
                        var tagsval = $("#Tags" + relid).val();
                        var nodes = treeObj.getNodes();
                        for (var i in nodes)
                        {
                            nodes[i].chkDisabled = true;
                            treeObj.updateNode(nodes[i]);
                        }
                        if (tagsval) {
                            for (var i = 0; i < tagsval.length; i++) {
                                var tagsval1 = tagsval[i].split('|')[0];                    
                                var enodeext = treeObj.getNodeByParam("id", tagsval1, null);
                                enodeext.checked =true;
                                treeObj.updateNode(enodeext);
                            }
                            //默认显示第一个选中科目的教版
                            for (var i = 0; i < tagsval.length; i++) {
                                var tagsval1 = tagsval[i].split('|')[0];
                                var enodeext = treeObj.getNodeByParam("id", tagsval1, null);
                                treeObj.setting.callback.beforeClick(treeObj.setting.treeId, enodeext);
                                treeObj.selectNode(enodeext);
                                break;

                            }
                        } else {
                            var treeObjSubs = $.fn.zTree.getZTreeObj("TreeSub" + relid);
                            treeObjSubs.checkAllNodes();
                        }
                    }
                    //鼠标离开事件
                    //$("#downdom" + relid).mouseleave(function () {
                    //    $("#downdom" + relid).css("display", "none");
                    //});
                });
            })













            //资源模块树级资源模块选择--Start
            //初始化资源模块选择
            $("#tags-soures").tagsinput({
                itemValue: 'id',
                itemText: 'text',
            });
            //资源模块删除触发
            $('#tags-soures').on('itemRemoved', function (event) {
                var node = treesouresObj.getNodeByParam("id", event.item.id, null);
                treesouresObj.checkNode(node, false, false);
            });
            var treesouresObj;

            var settingsoures = {
                check: {
                    enable: true,
                    //autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                    chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                    chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
                },
                view: {
                    dblClickExpand: false,
                    showLine: true,
                    selectedMulti: true
                },
                data: {
                    simpleData: {
                        enable: true,
                        idKey: "id",
                        pIdKey: "pId",
                        checked: "checked",
                        rootPId: ""
                    }
                },
                callback: {
                    beforeClick: function (treeId, treeNode) {
                    },
                    onCheck: SoureszTreeOnCheck
                }
            };
            $(function () {
                if(treeNodessoure)
                {
                    for (var x in treeNodessoure) {
                        if(treeNodessoure[x].checked=='true')
                        {
                            //var idval = "";
                            //var ss = treeNodessoure[x].isShar;
                            //if (treeNodessoure[x].isShar == 'true') {
                            //    idval = treeNodessoure[x].id+',1';
                            //}else{
                            //    idval = treeNodessoure[x].id + ',0';
                            //}
                            $('#tags-soures').tagsinput('add', { id: treeNodessoure[x].id, text: treeNodessoure[x].name });
                        }
    
                    }
                }
                treesouresObj = $.fn.zTree.init($("#treesoure"), settingsoures, treeNodessoure);
                treesouresObj.expandAll(true);

            });
            //与选中联动
            function SoureszTreeOnCheck(event, treeId, treeNode) {
                if (treeNode.checked) {
                    $('#tags-soures').tagsinput('add', { id: treeNode.id, text: treeNode.name });
                } else {
                    $('#tags-soures').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
                }
            };
            //资源模块树级资源模块选择--End







            //获取市
            $('#aprov').change(function () {
                var selv = $('#aprov').val();
                var params = '{"typecode":"1","pcode":"' + selv + '","isall":"1"}';
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
                var params = '{"typecode":"2","pcode":"' + selv + '","isall":"1"}';
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
            function checkTxt(o,reg){
                var regu =reg;
                var re = new RegExp(regu);
                if (re.test($(o).val())||re.test($(o).text())) {
                    return true;
                }else{
                    $(o).tooltip('show');
                    $(o).focus();
                    return false;
                }
            }
            $(document).ready(function(){
                //用户赋值 
                if (usermanager != "1" && usermanager != null) {
                    $("#ManagerAcount").val(usermanager.UserName);
                    
                    if (usermanager.PassWord == "1") {
                        $("#InitialPwd").val("***");
                        $(".initpwd").html("初始密码:");
                    } else {
                        $(".initpwd").html("密码:");
                        $("#InitialPwd").val("***");
                    }
                }
            })
        </script>
</body>
</html>