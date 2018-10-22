<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeClassInfo.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.GradeClassSet.GradeClassInfo" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>UI组件金视野系统模板</title>
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
    <link rel="stylesheet" href="../../assets/css/jquery.gritter.css" />

    <!-- fonts -->

    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300" />

    <!-- ace styles -->

    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />

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
        .main-container {
            min-height: 900px;
        }
         /*所在位置的背景边框*/
        .breadcrumb_box {
            background:white;
            border-bottom:1px solid #e4e4e4;
            color:#333333;
            margin-bottom:20px;
        }
         /*坐在位置的坐边竖线*/
        .breadcrumb_border {
            border-left:2px solid #63bbff;
            margin-left:0px;
            padding-left:12px;
            padding-top:4px;
            padding-bottom:4px;
        }
        /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }

        i {
            font-family: FontAwesome !important;
        }
        /*表格标题栏字体大小，颜色*/
        .table thead tr {
            color:#333333 !important;
            font-weight:400 !important;
        }
        /*表格的内容区字体大小颜色*/
        .table tbody tr td {
            color:#666666 !important;
            font-size:14px !important;
        }
        .search {
            margin-right:10px;
            margin-left:10px;
            font-size:14px;
            color:#333333;
        }
        .breadcrumb > li + li:before {
            content:"";
        }
    </style>
</head>
<body>
    <!---->
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
                            目前所在位置：
                        </li>
                        <%--<li>
                            <a href="#">学校管理</a>
                        </li>--%>
                        <%--将学校信息改为学校及科目信息--%>
                        <li class="active">年级/班级列表</li>
                    </ul>
                    <!-- .breadcrumb -->
                </div>

                <div class="page-content">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="col-sm-12">
                                <div class="col-sm-9" id="searchbar">
                                    <div class="input-group pull-right">
                                        <%=areastr %>是否已毕业:
                                    <select id="ustat">
                                        <option value="">全部</option>
                                        <option value="1">已毕业</option>
                                        <option value="0">正常</option>
                                    </select>年级名称:<input type="text" id="txtname" placeholder="年级名称">
                                        <button class="btn btn-sm btn-info" type="button" onclick="search();">查询</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--选项卡DOM-->
                    <div class="row">
                        <div class="col-xs-12">
                       
                            <div class="col-sm-12">
                                <div class="tabbable">
                                    <ul class="nav nav-tabs padding-12 tab-color-blue background-blue" id="GradeTabs">
                                        <li></li>
                                    </ul>
                                    <div class="tab-content" id="ClassTab"></div>
                                </div>
                            </div>
                            <!-- /span -->
                        </div>
                    </div>
                    <!-- /row -->
                    <!--//选项卡DOM-->
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="col-sm-12">
                                <div class="table-responsive" id="list"></div>
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

    <!-- ace scripts -->

    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>
    <script src="../../assets/js/bootstrap-paginator.js"></script>
    <link href="../../assets/css/bootstrap-dialog.css" rel="stylesheet" />
    <script src="../../assets/js/bootstrap-dialog.js"></script>
    <!-- inline scripts related to this page -->

    <script type="text/javascript">

        var txtname = '';
        var schid = '0';
        var cotycode = '0';
        var ustat = '';
        var gradecode = '';
        var isAdd = "<%=isAdd%>";
        var isUpdate = "<%=isUpdate%>";
        var isDelete = "<%=isDelete%>";
        var isGradeAdd = "<%=isGradeAdd%>";
        var isGradeUpdate = "<%=isGradeUpdate%>";
        var isGradeDelete = "<%=isGradeDelete%>";


        function go() {

            sessionStorage.setItem("gradeclassindex", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("gradeclassindex_txtname", txtname);
            sessionStorage.setItem("gradeclassindex_cotycode", cotycode);
            sessionStorage.setItem("gradeclassindex_ustat", ustat);
            sessionStorage.setItem("gradeclassindex_uschid", schid);
            sessionStorage.setItem("gradeclassindex_gradecode", gradecode);
            return false;
        };

        //页面缓存,页面是返回的
        var l = sessionStorage.getItem("gradeclassindex");
        if (l != null) {
            $("#main-container").html(l);            //删除缓存
            sessionStorage.removeItem("gradeclassindex");
            //取回缓存中的查询条件
            txtname = sessionStorage.getItem("gradeclassindex_txtname");
            cotycode = sessionStorage.getItem("gradeclassindex_cotycode");
            ustat = sessionStorage.getItem("gradeclassindex_ustat");
            schid = sessionStorage.getItem("gradeclassindex_uschid");
            gradecode = sessionStorage.getItem("gradeclassindex_gradecode");
            sessionStorage.removeItem("gradeclassindex_txtname");
            sessionStorage.removeItem("gradeclassindex_cotycode");
            sessionStorage.removeItem("gradeclassindex_ustat");
            sessionStorage.removeItem("gradeclassindex_uschid");
            sessionStorage.removeItem("gradeclassindex_gradecode");
        }
        else {
            schid = '<%=schid%>';//第一次赋给ID
            var systype = '<%=systype%>';
            cotycode = '<%=cotycode%>';
            if (cotycode == '') {
                $('#searchbar').hide()
            }
        }
        //获取数据
        function getdata() {
            var params = '{"txtname":"' + txtname + '","ustat":"' + ustat + '","cotycode":"' + cotycode + '","schid":"' + schid + '","gradeCode":"' + gradecode + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "GradeClassInfo.aspx/page",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    dodata(data.d);
                },
                error: function (obj, msg, e) {
                }
            });
        };
        //表格生成处理
        function dodata(data) {
            if (eval("(" + data + ")") != null && data != "") {
                var str = '';
                str += '<table id="data_table" class="table table-striped table-bordered table-hover">';
                str += '<thead>';
                str += '<tr>';
                str += '<th class="center"><input type="checkbox" class="ace" /><span class="lbl"></span></th>';
                str += '<th>班级名称</th>';
                str += '<th>班主任</th>';
                str += '<th class="hidden-480">任课老师</th>';
                str += '<th>操作</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                $.each(eval("(" + data + ")"), function (index, item) { //遍历返回的json

                    str += '<tr>';
                    str += '<td class="center"><label><input type="checkbox" class="ace" /><span class="lbl"></span></label></td>';
                    str += '<td>' + item.ClassName + '</td>';
                    str += '<td class="hidden-480">' + item.TeacherClass + '</td>';
                    str += '<td class="hidden-480">' + item.TeacherSub + '</td>';

                    str += '<td>';

                    str += '<div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">';
                    //str += '<a class="blue" href="#" onclick="showClassShowModal(this,' + item.GradeCode + ',' + item.ClassId + ',\'e\')" title="查看">';
                    //str += '<i class="icon-zoom-in bigger-130"></i>';
                    //str += '</a>';
                    if (isUpdate == "True") {
                        //str += '<a title=\"标准页面\" class="green" href="SchClassEdit.aspx?dotype=e&schid=' + item.SchId + '&classid=' + item.ClassId + '&gradecode=' + item.GradeCode + '" onclick="go();">';
                        //str += '<i class="icon-pencil bigger-130"></i>';
                        //str += '</a>';
                        str += '<a href="#" class="green" data-rel="tooltip"  onclick="showGradeEditeModal(this,' + item.GradeCode + ',' + item.ClassId + ',\'e\')" title="编辑">';
                        str += '<i class="icon-pencil bigger-130"></i>';
                        str += '</a>';
                    }
                    
                    if (isDelete == "True") {
                        str += '<a class="red" href="#" onclick="delu(0,' + schid + ',' + item.GradeCode + ',' + item.ClassId + ')" >';
                        str += '<i class="icon-trash bigger-130"></i>';
                        str += '</a>';
                    }
                    str += '</div>';

                    str += '<div class="visible-xs visible-sm hidden-md hidden-lg">';
                    str += '<div class="inline position-relative">';
                    str += '<button class="btn btn-minier btn-yellow dropdown-toggle" data-toggle="dropdown">';
                    str += '<i class="icon-caret-down icon-only bigger-120"></i>';
                    str += '</button>';

                    str += '<ul class="dropdown-menu dropdown-only-icon dropdown-yellow pull-right dropdown-caret dropdown-close">';
                    //str += '<li>';
                    //str += '<a href="#"  class="tooltip-info" data-rel="tooltip" title="查看">';
                    //str += '<span class="blue">';
                    //str += '<i class="icon-zoom-in bigger-120"></i>';
                    //str += '</span>';
                    //str += '</a>';
                    //str += '</li>';
                    if (isUpdate == "True") {
                        str += '<li>';
                        str += '<a href="#" class="tooltip-success" data-rel="tooltip"  onclick="showGradeEditeModal(this,' + item.GradeCode + ',' + item.ClassId + ',\'e\')" title="编辑">';
                        str += '<span class="green">';
                        str += '<i class="icon-edit bigger-120"></i>';
                        str += '</span>';
                        str += '</a>';
                        str += '</li>';
                    }
                    if (isDelete == "True") {
                        str += '<li>';
                        str += '<a href="#" class="tooltip-error" onclick="delu(0,' + schid + ',' + item.GradeCode + ',' + item.ClassId + ')" data-rel="tooltip" title="删除">';
                        str += '<span class="red">';
                        str += '<i class="icon-trash bigger-120"></i>';
                        str += '</span>';
                        str += '</a>';
                        str += '</li>';
                    }
                    str += '</ul>';
                    str += '</div>';
                    str += '</div>';

                    str += '</td>';
                    str += '</tr>';

                });
                str += '</tbody>';
                str += '</table>';
                $('#list').empty();
                $('#list').append(str);

                $('table th input:checkbox').on('click', function () {
                    var that = this;
                    $(this).closest('table').find('tr > td:first-child input:checkbox')
                    .each(function () {
                        this.checked = that.checked;
                        $(this).closest('tr').toggleClass('selected');
                    });

                });
            }
            else {
                $('#list').empty();
                $('#list').append("暂无数据!");
            }
        };


        //选项卡事件
        function GradeTab(obj) {
            gradecode = $(obj).attr("rel_id");
            $("#GradeTabs li").removeClass("active");
            $(obj).addClass("active");
            $(".tab-pane").css("display", "none");
            $("#" + gradecode).css("display", "block");
            getdata();
        }
        //执行删除方法
        function DelRun(type, schid, gradeid, classid) {
            var params ="{}";
            if (type == "1")//代表年级
            {
                params = "{\"type\":\"1\",\"schid\":\"" + schid + "\",\"gradeid\":\"" + gradeid + "\",\"classid\":\"\"}";
            } else if (type == "0")//代表班级
            {
                params = "{\"type\":\"0\",\"schid\":\"" + schid + "\",\"gradeid\":\"" + gradeid + "\",\"classid\":\"" + classid + "\"}";
            }
            $.ajax({
                type: "POST",  //请求方式
                url: "GradeClassInfo.aspx/udel",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == 'success') {
                        alert("操作成功");
                        searchdo();
                    }
                    else {
                        alert(data.d);
                    }
                },
                error: function (obj, msg, e) {
                    alert(e);
                }
            });

        }
        
        function delu(type, schid, gradeid, classid) {
            var msg = "确认删除这条信息吗？";
            //$.showConfirm = function (str, funcok, funcclose) {
                BootstrapDialog.confirm({
                    title: "确认提示框",
                    message: msg,
                    type: BootstrapDialog.TYPE_WARNING, // <-- Default value is // BootstrapDialog.TYPE_PRIMARY
                    closable: true, // <-- Default value is false，点击对话框以外的页面内容可关闭
                    draggable: true, // <-- Default value is false，可拖拽
                    btnCancelLabel: "取消", // <-- Default value is 'Cancel',
                    btnOKLabel: "确定", // <-- Default value is 'OK',
                    btnOKClass: "btn-warning", // <-- If you didn't specify it, dialog type
                    size: BootstrapDialog.SIZE_SMALL,
                    // 对话框关闭的时候执行方法
                    //onhide: funcclose,
                    callback: function (result) {
                        if (result) {// 点击确定按钮时，result为true
                            DelRun(type, schid, gradeid, classid);// 执行方法
                        }
                    }
                });
            //};
        }
        
        //获取市
        $('#aprov').change(function () {
            var selv = $('#aprov').val();
            var params = '{"typecode":"1","pcode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "GradeClassInfo.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $("#aprov option").each(function () {
                        if ($(this).val() == selv) {
                            $(this).attr("selected", true);
                        }
                        else {
                            $(this).removeAttr("selected");
                        }

                    });
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
                url: "GradeClassInfo.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $("#acity option").each(function () {
                        if ($(this).val() == selv) {
                            $(this).attr("selected", true);
                        }
                        else {
                            $(this).removeAttr("selected");
                        }

                    });
                    $('#acoty').html(data.d);
                    $('#acoty').change();
                },
                error: function (obj, msg, e) {
                    alert(msg); alert(e);
                }
            });
        });
        //获取学校
        //获取学校
        $('#acoty').change(function () {
            var selv = $('#acoty').val();
            var params = '{"typecode":"3","pcode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "../Users/UserInfo.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $("#acoty option").each(function () {
                        if ($(this).val() == selv) {
                            $(this).attr("selected", true);
                        }
                        else {
                            $(this).removeAttr("selected");
                        }

                    });
                    $('#asch').html(data.d);
                    $('#asch').change();
                },
                error: function (obj, msg, e) {
                }
            });
        });
        $('#asch').change(function () {
            var selv = $('#asch').val();
            $("#asch option").each(function () {
                if ($(this).val() == selv) {
                    $(this).attr("selected", true);
                }
                else {
                    $(this).removeAttr("selected");
                }

            });
        });
    </script>
    <!--//-->

    <script type="text/javascript">

        function searchdo() {
            var GradeLi = "";
            var ClassDiv = "";
            $.ajax({
                url: "ashx/GradeClassSet.ashx",
                type: "POST",//或GET
                async: true,//或false,是否异步
                data: { Action: "GradeClassInfo", SchId: schid },
                dataType: "json",//返回的数据格式：json/xml/html/script/jsonp/text
                //timeout: 5000,    //超时时间
                success: function (data, textStatus) {
                    //$("#GradeTabs").empty();
                    //$("#ClassTab").empty();
                    //循环年级信息
                    $.each(data, function (index, item) {
                        if ((index == 0 && gradecode == "") || item["GradeCode"] == gradecode) {
                            GradeLi += "<li class=\"active\" rel_id=\"" + item["GradeCode"] + "\" onclick=\"GradeTab(this)\"><a data-toggle=\"tab\" href=\"javascript:void();\">" + item["GradeName"] + "</a></li>";
                            ClassDiv += "<div id=\"" + item["GradeCode"] + "\" class=\"tab-pane active\">";
                        }
                        else {
                            GradeLi += "<li rel_id=\"" + item["GradeCode"] + "\" onclick=\"GradeTab(this)\"><a data-toggle=\"tab\" href=\"javascript:void();\">" + item["GradeName"] + "</a></li>";
                            ClassDiv += "<div id=\"" + item["GradeCode"] + "\" class=\"tab-pane\">";
                        }
                        //循环年级领导
                        ClassDiv += "<div class=\"item\" style=\"width:50%;float:left;\">";
                        ClassDiv += "<span>年级领导：</span>";
                        ClassDiv += "<span>" + item["GradeBoss"] + "</span>";
                        ClassDiv += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                        //ClassDiv += "<a class=\"blue\" href=\"#\">";
                        //ClassDiv += "<i class=\"icon-zoom-in bigger-130\"></i>";
                        //ClassDiv += "</a>";
                        if (isGradeUpdate=="True") {
                            ClassDiv += "<a class=\"green\" href=\"javascript:void();\"style=\"margin-right:10px\" onclick=\"GradeEditeModal(this," + item["GradeId"] + ",'e')\">";
                            ClassDiv += "<i class=\"icon-pencil bigger-130\"></i>";
                            ClassDiv += "</a>";
                        }
                        /*
                        if (isGradeDelete=="True") {
                            ClassDiv += "<a class=\"red\" href=\"#\" onclick=\"delu('1'," + schid + "," + item["GradeId"] + ",'')\" >";
                            ClassDiv += "<i class=\"icon-trash bigger-130\"></i>";
                            ClassDiv += "</a>";
                        }
                        */
                        ClassDiv += "</div>";
                        if (isAdd=="True") {
                            ClassDiv += "<div style=\"float:right;width:80px;\">";
                            ClassDiv += "    <a href=\"javascript:void();\" rel_id=\"0\" rel_gradecode=\"" + item["GradeCode"] + "\" onclick=\"showGradeEditeModal(this," + item["GradeCode"] + ",0,'a')\">新建班级</a>";
                            ClassDiv += "</div>";
                        }
                        ClassDiv += "<div style=\"clear:both;\"></div>";
                        ClassDiv += "</div>"
                    });

                    //$("#GradeTabs").empty();
                    //$("#ClassTab").empty();
                    $("#GradeTabs").html(GradeLi);
                    $("#ClassTab").html(ClassDiv);
                    if (gradecode == "") {
                        gradecode = $("#GradeTabs li.active").attr("rel_id");
                    }
                    getdata();
                },
                error: function (obj, msg, e) {
                    alert(msg); alert(e);
                }
            });
        }
        //  });
        //搜索事件
        function search() {

            txtname = $('#txtname').val();
            schid = $('#asch').val();
            cotycode = $('#acoty').val();
            ustat = $('#ustat').val();

            gradecode = '';
            //获取标签
            searchdo();

            //获取第一标签下的数据

        }
    </script>
    <!-- basic scripts -->

    <!--[if !IE]> -->

    <!-- <![endif]-->

    <!--[if IE]>

<![endif]-->

    <!-- 模态框   打开新建班级模态框 -->
<div class="modal fade" id="EditCfmGradeClass">
    <div class="modal-dialog" style="width:45%;height:90%;">
        <div class="modal-content message_align" style="width:100%;height:90%;">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">×</span>
                </button>
                <h4 class="modal-title">班级信息</h4>
            </div>
            <div class="modal-body no-padding-top no-padding-bottom" style="width:100%;height:90%;" >
                
                <iframe id="modelClassAdd" src="" style="width:100%;height:100%;border:none"></iframe>
                
            </div>
        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div>
<!-- //模态框   打开新建班级模态框 -->
<!-- 模态框   打开查看班级模态框 -->
<div class="modal fade" id="ShowCfmClass">
    <div class="modal-dialog" style="width:45%;height:90%;">
        <div class="modal-content message_align" style="width:100%;height:90%;">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">×</span>
                </button>
                <h4 class="modal-title">班级信息</h4>
            </div>
            <div class="modal-body no-padding-top no-padding-bottom" style="width:100%;height:90%;" >
                
                <iframe id="modelShowClass" src="" style="width:100%;height:100%;border:none"></iframe>
                
            </div>
        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div>
<!-- //模态框   打开查看班级模态框 -->
    <!-- 模态框   打开新建年级模态框 -->
<div class="modal fade" id="EditCfmGrade">
    <div class="modal-dialog" style="width:45%;height:90%;">
        <div class="modal-content message_align" style="width:100%;height:90%;">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">×</span>
                </button>
                <h4 class="modal-title">年级信息</h4>
            </div>
            <div class="modal-body no-padding-top no-padding-bottom" style="width:100%;height:90%;">
                
                <iframe id="modelGradeAdd" src="" style="width:100%;height:100%;border:none"></iframe>
                
            </div>
        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div>
<!-- //模态框   打开新建年级模态框 -->
    <script type="text/javascript">
        $(document).ready(function () {
            //获取标签
            searchdo();

        });

        // 打开新建班级模态框，函数名：showGradeEditeModal
        var rel_id = "";var rel_gradecode="";
        function showGradeEditeModal(obj,gradecode,classid,dotype) {
            var url = "SchClassE.aspx?dotype=" + dotype + "&schid=" + schid + "&gradecode=" + gradecode + "&classid=" + classid;
            $("#modelClassAdd").attr("src", url);
            $("#EditCfmGradeClass").modal({
                backdrop: 'static',
                keyboard: false
            });//ClassDiv += "    <a href=\"SchClassEdit.aspx?dotype=a&schid=" + schid + "&gradecode=" + item["GradeCode"] + "\" onclick=\"go();\"></a>";
        }
        $(function () {
            $('#EditCfmGradeClass').on('hide.bs.modal',
            function () {
                searchdo();
            })
        });

        // 打开查看班级模态框，函数名：showGradeEditeModal
        var rel_id = "";var rel_gradecode="";
        function showClassShowModal(obj, gradecode, classid, dotype) {
            var url = "SchClassShow.aspx?dotype=" + dotype + "&schid=" + schid + "&gradecode=" + gradecode + "&classid=" + classid;
            $("#modelShowClass").attr("src", url);
            $("#ShowCfmClass").modal({
                backdrop: 'static',
                keyboard: false
            });
        }
        $(function () {
            $('#ShowCfmClass').on('hide.bs.modal',
            function () {
                searchdo();
            })
        });

        // 打开修改年级模态框，函数名：GradeEditeModal
        var rel_id = "";var rel_gradecode="";
        function GradeEditeModal(obj,gradecode,dotype) {
            //var url = "SchClassEdit2.aspx?dotype=a&schid=100005&classid=2&gradecode=1001";
            var url = "SchGradeEdit.aspx?dotype=" + dotype + "&schid=" + schid + "&gradeid=" + gradecode;
            $("#modelGradeAdd").attr("src", url);
            $("#EditCfmGrade").modal({
                backdrop: 'static',
                keyboard: false
            });//ClassDiv += "    <a href=\"SchClassEdit.aspx?dotype=a&schid=" + schid + "&gradecode=" + item["GradeCode"] + "\" onclick=\"go();\"></a>";
        }
        $(function () {
            $('#EditCfmGrade').on('hide.bs.modal',
            function () {
                searchdo();
            })
        });

        //关闭年级模态框
        function closegroademodel() {
            $("#EditCfmGrade").modal("hide")
        }
        //关闭班级模态框
        function closeclassmodel() {
            $("#EditCfmGradeClass").modal("hide")
        }
    </script>


</body>
</html>
