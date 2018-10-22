<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServInfoTabs.aspx.cs" Inherits="SchWebServ.Web.ServInfo.ServInfoTabs" %>

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
          <style>
        
         /*定义字体*/
            body {
            font-family:微软雅黑;
        }
        .input_box > label { 
            color:#999999;
            font-size:13px;
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
         /*位置提示字体大小*/
        .breadcrumb > li {
            font-size:13px !important;
            color:#666666 !important;
        }
         /*内容上边距*/
        .content_box {
            padding-top: 24px;
        }
        /*输入框和下拉选框的间距*/
        select, input {
            font-size:12px;
            margin-left:10px;
            margin-right:10px;
            color:#999999;
        }
        /*搜索栏的字体颜色*/
        .input-group {
           font-size:13px;
           color:#000000;
        }
        /*输入框字体的颜色*/
        input[type="text"] {
            color:#999999;
            font-size:12px;
        }
        /*表格标题栏颜色*/
        .table.table-bordered thead tr th {
            font-size:13px !important;
            color:#444444;
            text-align:center;
            line-height: 1.5
        }
        /*表格内容区颜色*/
        .table.table-bordered tbody tr td {
            font-size:13px !important;
            color:#666666;
            text-align:center;
            line-height: 1.5
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
        /*按钮的字体大小*/
        .text_size {
            font-size:12px;
        }
        .breadcrumb > li + li:before {
            content:"";
        }
    </style>
    </style>
</head>
<body>
    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>

        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
                 

                  <div class="breadcrumbs breadcrumb_box" id="breadcrumbs">
                    <script type="text/javascript">
                        try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
                    </script>

                    <ul class="breadcrumb breadcrumb_border">
                        <li>
                            目前位置：
                        </li>
                        <li class="active">系统基本信息</li>
                    </ul>
                </div>
 
                <div class="page-content">
                <%--    <div class="nav-search" id="nav-search">
                        <a class=" pull-right " href="javascript:window.history.go(-1);">
                            <i class="icon-reply icon-only"></i>
                            返回
                        </a>
                    </div>--%>
                    <ul class="nav nav-tabs" id="myTab">
                        <li><a href="#ServSysInfo" data-toggle="tab"   onclick="clickiframe('ServSysInfo','../ServSys/ServSysInfo.aspx')">业务平台信息</a></li>
                        <li><a href="#ServType" data-toggle="tab"   onclick="clickiframe('ServType','../ServSys/ServTypeInfo.aspx')">业务类型信息</a></li>
                         <%--<li><a href="#ServBusThd" data-toggle="tab"   onclick="clickiframe('ServBusThd','../ServSys/ServBusThdInfo.aspx')">第三方平台套餐</a></li>--%>
                    </ul>
                    <div class="tab-content">
                        <!------------------------------------------------------------业务平台信息----------------------------------------------------------------------------------------------->
                        <div class="tab-pane active"  id="ServSysInfo" style="min-height:500px;"></div>
                        <!------------------------------------------------------------业务类型信息----------------------------------------------------------------------------------------------->
                        <div id="ServType" class="tab-pane"></div>
                         <!------------------------------------------------------------第三方平台套餐----------------------------------------------------------------------------------------------->
                       <%--  <div id="ServBusThd" class="tab-pane"></div>--%>
                        <script type="text/javascript">
                            function reinitIframe() {
                                var iframe = document.getElementById("ifrServInfo");
                                try {
                                    var bHeight = iframe.contentWindow.document.body.scrollHeight;
                                    //var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
                                    //var dHeight = iframe.contentWindow.document.getElementsByClassName('main-container')[0].scrollHeight;
                                    var dHeight = document.getElementsByClassName('main-container')[0].height();
                                    //var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
                                    var height = Math.max(bHeight, dHeight);
                                    iframe.height = height;
                                    //console.log(height);
                                } catch (ex) { }
                            }
                            window.setInterval("reinitIframe()", 200);
                            window.onresize = function () {
                                reinitIframe();
                            }
                            </script>
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
                //变量声明区域
                var schid = "<%=schid%>";

                //第一个Tab选项卡活动状态
                $('#myTab li:eq(0) a').tab('show');// 选取第1个标签页（从 0 开始索引）。 

                //默认加载第一个选项卡
                window.onload = function () {
                    clickiframe('ServSysInfo', '../ServSys/ServSysInfo.aspx');//缺省显示业务平台信息
                }
                //选项卡单击事件
                function clickiframe(id, dz) {
                    document.getElementById(id).innerHTML = "<iframe class=\"content\" name=\"ifrServInfo\" id=\"ifrServInfo\" style=\"width: 100%;height:100%;min-height:700px;\" frameborder=\"no\" border=\"0\" marginwidth=\"0\" marginheight=\"0\" src=\"" + dz + "?schid=" + schid + "\"  frameborder=\"0\"></iframe>";
                }
            </script>
</body>
</html>
