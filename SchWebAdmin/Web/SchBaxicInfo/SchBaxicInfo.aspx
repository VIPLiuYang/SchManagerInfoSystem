<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchBaxicInfo.aspx.cs" Inherits="SchWebAdmin.Web.SchBaxicInfo.SchBaxicInfo" %>

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
            border:0px;
            box-shadow:none;
        }
        .label-info {
            background-color:white!important;            
        }
        .label {
            font-size:14px !important;
            color:black;
        }
        .bootstrap-tagsinput .tag {
            color:black;
        }
        .form-group input[disabled], .form-group input:disabled,.form-group select:disabled,input:disabled {
            color: #999999!important;
            background-color: #fff!important;
            border-style: none;
            font-size:12px;
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
            min-height:32px;
            line-height:30px;
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
            padding-right:0;
        }
        /*位置提示字体大小*/
        .breadcrumb > li {
            font-size:13px !important;
            color:#666666 !important;
        }
        /*科目的颜色*/
        .bootstrap-tagsinput .tag {
            color:#999999 !important;
            font-size:12px !important;
        }
        /*下拉选框 输入框的大小*/
         select, input {
            font-size:12px;
            color:#999999;
        }
        input[type="text"] {
            color:#999999 !important;
            font-size:12px !important;
        }
        /*按钮中的字体大小*/
        .text_size {
            font-size:12px;
        }
        /*每一行的间距*/
        .form-group {
            margin-bottom:2px;
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
                text-align:initial !important;
            }
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
        /*科目下来框的颜色大小*/
        .ztree li a span {
            color:#666666; 
            font-size:12px !important;
        }
        /*输入框所在的盒子上下边距*/
        .input_box {
            padding:3px 10px;
        }
        #schname {
            /*margin-left: 10px;*/
            margin-right: 10px;
        }
        #aprov, #acity, #acoty {
            margin:4px 10px;
        }
        select {
            height: 26px;
        }
        /*input {
            height: 30px;
        }*/
        label {
            height:30px;
            line-height:30px;
        }
        .input_box {
            height: 30px;
        }
        #SchoolSection .row .col-sm-11 .col-sm-1 {
            width: 9.3%;
        }
        .bootstrap-tagsinput .label-info {
            padding: 0px;
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
    <style type="text/css">
        .page-content .content_box {
            background-color:#F3F3F3;
            width:80%;
            margin:0px auto;
            padding-bottom: 30px;
        }
        .SchBaxicInfotab {
            width: 60%;
            margin: 0px auto;
            background-color:#fff;
        }
        .SchBaxicInfotab .nav-tabs > li.active > a, .nav-tabs > li.active > a:hover {
            background-color: #3C9BFF;
            color:#fff;
        }
        .SchBaxicInfotab .nav-tabs > li > a, .nav-tabs > li > a:focus {
            background-color:#fff;
            color:#000;
        }
        #SchSectionn .SchSectionnAdd {
            text-align: right;
        }
        #SchSubSection .SchSectionnAdd {
            text-align: right;
        }
        #TeachingEditionSection .SchSectionnAdd {
            text-align: right;
        }
        #TextbookSection .SchSectionnAdd {
            text-align: right;
        }
    </style>
</head>

<body ontouchstart>
    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>
        <style type="text/css">
    .breadcrumb>li+li:before{content:none;}
    input[type=checkbox].ace:disabled+.lbl::before, input[type=radio].ace:disabled+.lbl::before, input[type=checkbox].ace[disabled]+.lbl::before, input[type=radio].ace[disabled]+.lbl::before, input[type=checkbox].ace.disabled+.lbl::before, input[type=radio].ace.disabled+.lbl::before{color:#32A3CF;}
        </style>
        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
                <div class="breadcrumbs breadcrumb_box " id="breadcrumbs">
                    <script type="text/javascript">
                        try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
                    </script>
                    <ul class="breadcrumb breadcrumb_border">
                        <li>
                            目前位置：
                        </li>
                        <li class="active">学校基础信息 </li>
                    </ul>
                </div><!-- .breadcrumb -->

                <div class="page-content content_box">
                    <div class="content_box">
                        <div class="SchBaxicInfotab" role="tabpanel">
		                        <!-- Nav tabs -->
		                        <ul class="nav nav-tabs" role="tablist">
		                            <li role="presentation" class="active"><a href="#SchSectionn" aria-controls="home" role="tab" data-toggle="tab">学段表</a></li>
		                            <li role="presentation"><a href="#SchSubSection" aria-controls="profile" role="tab" data-toggle="tab">科目表</a></li>
		                            <li role="presentation"><a href="#TeachingEditionSection" aria-controls="messages" role="tab" data-toggle="tab">教版表</a></li>
		                            <li role="presentation"><a href="#TextbookSection" aria-controls="messages" role="tab" data-toggle="tab">教材分册表</a></li>
		                        </ul>
		                        <!-- Tab panes -->
		                        <div class="tab-content tabs">
		                            <div role="tabpanel" class="tab-pane fade in active" id="SchSectionn">
                                        <div class="row">
                                            <div class="col-sm-12 SchSectionnAdd"><a href="#">添加</a></div>
                                        </div>
		                                学段表列表
		                            </div>
		                            <div role="tabpanel" class="tab-pane fade" id="SchSubSection">
                                        <div class="row">
                                            <div class="col-sm-12 SchSectionnAdd"><a href="#">添加</a></div>
                                        </div>
		                                科目表列表
		                            </div>
		                            <div role="tabpanel" class="tab-pane fade" id="TeachingEditionSection">
                                        <div class="row">
                                            <div class="col-sm-12 SchSectionnAdd"><a href="#">添加</a></div>
                                        </div>
		                                教版表列表
		                            </div>
		                            <div role="tabpanel" class="tab-pane fade" id="TextbookSection">
                                        <div class="row">
                                            <div class="col-sm-12 SchSectionnAdd"><a href="#">添加</a></div>
                                        </div>
		                                教材分册表
		                            </div>
		                        </div>
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
    <!-- Latest compiled and minified JavaScript -->
    <script src="../../assets/js/bootstrap-tagsinput.js"></script>
    <script src="../../assets/js/jquery.ztree.all-3.5.min.js"></script>
    <script type="text/javascript" src="../../assets/js/jquery.cookie.js"></script>
    <!-- (Optional) Latest compiled and minified JavaScript translation files -->
    <script type="text/javascript">
        
    </script>

</body>
</html>
