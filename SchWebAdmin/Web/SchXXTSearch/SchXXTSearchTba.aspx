<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchXXTSearchTba.aspx.cs" Inherits="SchWebAdmin.Web.SchXXTSearch.SchXXTSearchTba" %> 
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
        /*所在位置的背景边框*/
        .breadcrumb_box {
            background: white;
            border-bottom: 1px solid #e4e4e4;
            /*color: #333333;*/
        }
        /*所在位置的提示高度*/
        .breadcrumbs {
            min-height: 32px;
            line-height: 30px;
        }
          .input_box > label { 
            color:#999999;
            font-size:13px;
        }
        .form-group > span { 
             color:#999999;
            font-size:13px;
        }
         #selsubs { 
            color:#999999;
            font-size:13px;
            margin-top: 5px;
        }
         #sonsys{ 
            color:#999999;
            font-size:13px;
            margin-top: 5px;
        }
          #SonsysStat{ 
            color:#999999;
            font-size:13px;
            margin-top: 5px;
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
            font-size: 13px !important;
            color: #666666 !important;
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
            font-size: 13px;
            color: #000000;
        }
            /*年级班级中的下拉选框中的颜色大小*/
            .biaoti select {
                font-size: 12px;
                color: #666666 !important;
            }
            /*年级班级中的下拉选框后边的提示语的颜色大小*/
            .biaoti span {
                font-size: 12px;
                color: #999999 !important;
            }
        /*定义内容大小*/
        .neirong {
            color: #999999 !important;
            font-size: 13px !important;
        }

        .neirong1 {
            color: #999999 !important;
            font-size: 12px !important;
        }
        /*学段，年级字体的大小颜色*/
        .color {
            font-size: 13px !important;
            color: #666666 !important;
        }
        /*内容区域的字体大小颜色*/
        .lbl {
            font-size: 12px !important;
            color: #999999;
            width: 82px;
        }
        /*表格中的每个单元格的内边距*/
        .table_box tr th {
            padding-left: 20px;
            padding-right: 20px;
        }
        /*去掉表格中输入框的边框*/
        .input_style {
            border: none !important;
        }
        /*每行的行高*/
        .lheight {
            line-height: 30px !important;
        }
        /*是否走读单选框的间距*/
        .jianju {
            padding-left: 24px;
        }
        /*每一行的间距*/
        .form-group {
            margin-bottom: 2px;
        }
        /*本页表格标题栏字体大小，颜色*/

        .liebiaobiaoti {
            font-size: 13px !important;
            color: #444444 !important;
            font-weight: bold !important;
            letter-spacing: 1px !important;
            text-align: center !important;
            line-height: 1.5 !important;
        }
        /*表格的内容区字体大小颜色*/
        .table tbody tr td {
            color: #666666 !important;
            font-size: 13px !important;
            text-align: center !important;
            line-height: 1.5 !important;
        }
        /*年级右内边距*/
        .nianji {
            padding-right: 1px;
        }
        /*科目下来框的颜色大小*/
        .ztree li a span {
            color: #666666;
            font-size: 12px !important;
        }
        /*输入框所在的盒子上下边距*/
        .input_box {
            padding: 4px 10px;
        }
        /*内容区域的最小高度和去掉边框*/
        .content {
            border: none;
            /*min-height: 980px;*/
            min-height: 600px;
        }

        .search {
            margin-right: 10px;
            margin-left: 10px;
            font-size: 14px;
            color: #333333;
        }

        input[type="text"] {
            color: #999999;
            font-size: 12px;
            margin-left: 6px;
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

        input:disabled {
            color: #999999 !important;
        }

        .breadcrumb > li + li:before {
            content: "";
        }

        .col-sm-8 {
            color: #666666;
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
                        <li>目前位置：
                        </li>
                        <li class="active">家校互通平台信息查询详细 </li>
                    </ul>
                </div>
                <style>
                    .thth {
                        text-align: right;
                        width: 110px;
                    }
                </style>
                <div class="page-content">
                    <div class="nav-search" id="nav-search">
                        <a class=" pull-right " href="javascript:window.history.go(-1);">
                            <i class="icon-reply icon-only"></i>
                            返回
                        </a>
                    </div>
                    <div class="row" id="searchbar">
                        <div class="col-xs-12">
                            <div class="col-sm-12">
                                <div class="col-sm-9">
                                    <div class="input-group pull-right">
                                        <%=areastr %>  &nbsp;
                                        <input type="text" id="txtname" placeholder="00001" style="display:none;">&nbsp;
                                        <button class="btn btn-sm btn-info text_size" type="button" onclick="search();">查询</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <ul class="nav nav-tabs" id="myTab">
                        <li id="mr"><a href="#jcxx" data-toggle="tab"   onclick="clickiframe('jcxx','Schinfo.aspx')">基础信息</a></li>
                        <li><a href="#zxtjcd" data-toggle="tab">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></li>
                        <li><a href="#jgxx" data-toggle="tab">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></li>
                        <li><a href="#jsjzhqx" data-toggle="tab" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></li> 
                        
                    </ul>
                    <div class="tab-content">
                        <!------------------------------------------------------------学校基本信息----------------------------------------------------------------------------------------------->
                        <!--默认选择home active-->
                        <div class="tab-pane active"  id="jcxx">
                        </div>
                        <!------------------------------------------------------------子系统及菜单----------------------------------------------------------------------------------------------->
                        <div id="zxtjcd" class="tab-pane">
                        </div>
                        <!------------------------------------------------------------架构信息----------------------------------------------------------------------------------------------->
                        <div id="jgxx" class="tab-pane"> 
                        </div>
                        <!------------------------------------------------------------教师及账号权限----------------------------------------------------------------------------------------------->
                        <div id="jsjzhqx" class="tab-pane">
                        </div>
                      
                     
                          
                        <script type="text/javascript">
                            function reinitIframe() {
                                var iframe = document.getElementById("iframe1");
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
</body>
</html>

<script type="text/javascript">
    $('#myTab li:eq(0) a').tab('show');// 选取第1个标签页（从 0 开始索引）。 
    var PageIndex = 1;
    var PageSize = 20;
    var pageCount = 1;
    /*启用选项卡*/
    $("#myTab a").click(function (e) {
        e.preventDefault();/*不要执行与事件有关的默认动作*/
        $(this).tab('show');
    })
    var schid = '';
    var schid = '<%=schid%>';
    window.onload = function () {
        clickiframe('jcxx', 'Schinfo.aspx')
    }
    //查询方法
    function search() {
        if ($('#asch').val()) {
            schid = $("#asch").val();

        }
        $('#myTab li:eq(0) a').tab('show');// 选取第1个标签页（从 0 开始索引）。 
        clickiframe('jcxx', 'Schinfo.aspx')
    }
    function clickiframe(id, dz) {
        document.getElementById(id).innerHTML = "<iframe class=\"content\" name=\"iframe1\" id=\"iframe1\" style=\"width: 100%;height:100%;\" frameborder=\"no\" border=\"0\" marginwidth=\"0\" marginheight=\"0\" src=\"" + dz + "?schid=" + schid + "\"  frameborder=\"0\"></iframe>";
    }

    
    //获取市
    $('#aprov').change(function () {
        var selv = $('#aprov').val();
        var params = '{"typecode":"1","pcode":"' + selv + '","isall":"0"}';
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
                    $("#aprov option").each(function () {
                        if ($(this).val() == selv) {
                            $(this).attr("selected", true);
                        }
                        else {
                            $(this).removeAttr("selected");
                        }

                    });
                }
            },
            error: function (obj, msg, e) {
            }
        });
    });
    //获取区
    $('#acity').change(function () {
        var selv = $('#acity').val();
        var params = '{"typecode":"2","pcode":"' + selv + '","isall":"0"}';
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
                    $("#acity option").each(function () {
                        if ($(this).val() == selv) {
                            $(this).attr("selected", true);
                        }
                        else {
                            $(this).removeAttr("selected");
                        }
                    });
                }
            },
            error: function (obj, msg, e) {
            }
        });
    });
    //获取学校
    $('#acoty').change(function () {
        var selv = $('#acoty').val();
        var params = '{"typecode":"3","pcode":"' + selv + '","isall":"0"}';
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
                    $('#asch').html(data.d.data);
                    $('#asch').change();
                    $("#acoty option").each(function () {
                        if ($(this).val() == selv) {
                            $(this).attr("selected", true);
                        }
                        else {
                            $(this).removeAttr("selected");
                        }

                    });
                }
            },
            error: function (obj, msg, e) {
            }
        });
    });
</script>
