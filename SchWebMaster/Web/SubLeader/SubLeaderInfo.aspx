﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubLeaderInfo.aspx.cs" Inherits="SchWebMaster.Web.SubLeader.SubLeaderInfo" %>


<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>年级科目班级设置</title>
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
       
        /*表格标题栏字体大小，颜色*/
        
        /*学科组长等大标题的样式*/
        .subleadertitle {
            color: #000000;
            font-size: 14px;
            font-weight: bold;
            letter-spacing: 1px;
        }
        /*学科组长中的人名样式*/
        #SubLearder .row .row span {
            display: inline-block;
            width: 25%;
            border: 1px solid #E5E5E5;
            text-align: center;
            margin: 3px;
            font-size: 12px;
            color: #999999;
        }
        /*学科组长中的科目样式*/
        #SubLearder .subtitle {
            font-size: 13px;
            color: #666666;
            text-align: center;
        }

        #SubLearder .tr {
            width: 95%;
            margin-bottom: 10px;
        }
        /*年级领导中的人名样式*/
        #GradeManager .row .row span {
            display: inline-block;
            width: 80px;
            border: 1px solid #E5E5E5;
            text-align: center;
            margin-left: 5px;
            margin-right: 5px;
            font-size: 12px;
            color: #999999;
        }
        /*年级领导中的年级标题*/
        #GradeManager .gradetitle {
            text-align: center;
            font-size: 13px;
            color: #666666;
        }

        #GradeManager .tr {
            width: 95%;
            margin-bottom: 10px;
        }

        #searchbar select {
            margin-left: 10px;
            margin-right: 10px;
        }

        
        
        /*添加班级弹出框的顶端距离*/
        @media screen and (min-width: 768px) {
            .modal-dialog {
                padding-top: 130px;
            }
        }
        /*弹出框表头的颜色*/
        .bootstrap-dialog.type-warning .modal-header {
            background-color: #ffffff !important;
        }
        /*弹出框表头标题的颜色大小*/
        .bootstrap-dialog .bootstrap-dialog-title {
            font-size: 18px !important;
            color: #f96161 !important;
        }
        /*确定按钮的颜色*/
        .btn-warning {
            background-color: #428bca !important;
            border-color: #428bca;
        }
            /*确定按钮鼠标移动到上边时的颜色*/
            .btn-warning:hover {
                background-color: #1b6aaa!important;
                border-color: #428bca;
            }

        #modelSubLeader .ztree li a span {
            color: #999999 !important;
        }
        .page-content {
            padding: 0px;
        }
         #SubLearder {
            margin-top:10px;
        }
        #GradeManager {
            margin-top:10px;
        }
        .tab-content {
            padding:0px;
        }
        .table thead > tr > th, .table tbody > tr > td {
            text-align: center;
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
                        <li class="active">学科/年级/班级设置</li>
                    </ul>
                    <!-- .breadcrumb -->
                </div>
                <div class="page-content">
                    <!--搜索-->
                        <div class="col-sm-12">
                            <div class="col-sm-8" id="searchbar">
                                <div class="input-group pull-right search">
                                    <br />
                                    <%=areastr %>
                                    <br />
                                    <br />

                                </div>
                            </div>
                        </div>
                    <!--//搜索-->
                    <!--学科组长-->
                    <div class="tabbable">
                        <ul class="nav nav-tabs" id="myTabsub">
                            <li class="active">
                                <a data-toggle="tab" href="#sublist">
                                    学科组长
                                </a>
                            </li>
                            <li class="">
                                <a data-toggle="tab" href="#gradebosslist">年级领导
                                </a>
                            </li>
                            <li class="">
                                <a data-toggle="tab" href="#tecsublist">任课老师
                                </a>
                            </li>
                        </ul>

                        <div class="tab-content">
                            <div id="sublist" class="tab-pane active">
                                <div id="SubLearder">
                                    <!--<div class="row" id="SubLearder"></div>-->
                                </div>
                            </div>
                            <div id="gradebosslist" class="tab-pane">
                                <div id="GradeManager">
                                    <!--<div class="row" id="GradeManager"></div>-->
                                </div>
                            </div>
                            <div id="tecsublist" class="tab-pane">
                            
                                <div style="background-color: rgb(239, 243, 248);text-align: right;padding:6px 4px;">
                                是否已毕业:
                                <select id="ustat">
                                    <option value="">全部</option>
                                    <option value="1">已毕业</option>
                                    <option value="0">正常</option>
                                </select>
                                教师姓名:<input type="text" id="txtname" placeholder="教师姓名">
                                <span class="text-style">年级:</span>
                                <select id="schgradeSearch">
                                    <option value="">全部</option>
                                </select>
                                <span class="text-style">班级:</span>
                                <select id="schclassSearch">
                                    <option value="">全部</option>
                                </select>
                                <span class="text-style">任教科目:</span>
                                <select id="schsubsSearch">
                                    <option value="">全部</option>
                                </select>
                                <button class="btn btn-sm btn-info text-right text-size" type="button" onclick="search();">查询</button></div>
                                <div class="" style="margin: 0px auto;" id="list"></div>
                            
                        </div>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- 模态框：班级组长、年级领导以及班级(班主任、任课教师）--模态框 -->
    <div class="modal fade" id="EditCfmSuberGraderClasser">
        <div class="modal-dialog" style="width: 45%; height: 90%;">
            <div class="modal-content message_align" style="width: 100%; height: 90%;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title title-style"></h4>
                </div>
                <div class="modal-body no-padding-top " style="width: 100%; height: 87%;">

                    <iframe id="IfrSuberGraderClasser" src="" style="width: 100%; height: 100%; border: none"></iframe>

                </div>
            </div>
        </div>
    </div>
    <!-- //模态框：班级组长、年级领导以及班级(班主任、任课教师）--模态框 -->
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
        var isedit = '<%=isedit%>';
        var isdel = '<%=isdel%>';
        var islook = '<%=islook%>';
        var isadd = '<%=isadd%>';
        var txtname = '';
        var schid = '0';
        var cotycode = '0';
        var ustat = '';
        var gradecode = '';
        var classid="";
        var subcode="";
        
        var grades = <%=grades%>;
        var subs = <%=subs%>;
        var subUser = <%=subUser%>;
        var selv="";
        function go() {

            sessionStorage.setItem("subleaderinfoindex", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("gradeclassindex_txtname", txtname);
            sessionStorage.setItem("gradeclassindex_cotycode", cotycode);
            sessionStorage.setItem("gradeclassindex_ustat", ustat);
            sessionStorage.setItem("gradeclassindex_uschid", schid);
            sessionStorage.setItem("gradeclassindex_gradecode", gradecode);
            sessionStorage.setItem("gradeclassindex_classid", classid);
            sessionStorage.setItem("gradeclassindex_subcode", subcode);

            sessionStorage.setItem("gradeclassindex_grades", grades);
            sessionStorage.setItem("gradeclassindex_subs", subs);
            sessionStorage.setItem("gradeclassindex_subuser", subUser);
            return false;
        };

        //页面缓存,页面是返回的
        var l = sessionStorage.getItem("subleaderinfoindex");
        if (l != null) {
            $("#main-container").html(l);            //删除缓存
            sessionStorage.removeItem("subleaderinfoindex");
            //取回缓存中的查询条件
            txtname = sessionStorage.getItem("subleaderinfoindex_txtname");
            cotycode = sessionStorage.getItem("subleaderinfoindex_cotycode");
            ustat = sessionStorage.getItem("subleaderinfoindex_ustat");
            schid = sessionStorage.getItem("subleaderinfoindex_uschid");
            gradecode = sessionStorage.getItem("subleaderinfoindex_gradecode");
            classid = sessionStorage.getItem("gradeclassindex_classid");
            subcode = sessionStorage.getItem("gradeclassindex_subcode");

            sessionStorage.removeItem("subleaderinfoindex_txtname");
            sessionStorage.removeItem("subleaderinfoindex_cotycode");
            sessionStorage.removeItem("subleaderinfoindex_ustat");
            sessionStorage.removeItem("subleaderinfoindex_uschid");
            sessionStorage.removeItem("subleaderinfoindex_gradecode");
            sessionStorage.removeItem("gradeclassindex_classid");
            sessionStorage.removeItem("gradeclassindex_subcode");

            sessionStorage.removeItem("gradeclassindex_grades");
            sessionStorage.removeItem("gradeclassindex_subs");
            sessionStorage.removeItem("gradeclassindex_subuser");
        }
        else {
            schid = '<%=schid%>';//第一次赋给ID
            var systype = '<%=systype%>';
            cotycode = '<%=cotycode%>';
            if (cotycode == '') {
                $('#searchbar').hide()
            }
        }
        //搜索框当前学校的科目
        var schsubsoption="<option value=\"\">全部</option>";
        $.each(subs.ds, function (index, item) {
            schsubsoption += "<option value=\""+item.SubCode+"\">"+item.SubName+"</option>";
        });
        //搜索框当前学校的年级
        var schgradeoption="<option value=\"\">全部</option>";
        $.each(grades, function (index, item) {
            schgradeoption += "<option value=\""+item.GradeId+"\">"+item.GradeName+"</option>";
        });
        $("#schgradeSearch").html(schgradeoption);
        $("#schsubsSearch").html(schsubsoption);
        //搜索框当前学校的班级
        function schclassoption(data){
            var schclassoption="<option value=\"\">全部</option>";
            $.each(eval("(" + data + ")"), function (index, item) {
                schclassoption += "<option value=\""+item.ClassId+"\">"+item.ClassName+"</option>";
            });
            $("#schclassSearch").html(schclassoption);
        }
        //获取数据
        function getdata() {
            var params = '{"txtname":"' + txtname + '","ustat":"' + ustat + '","cotycode":"' + cotycode + '","schid":"' + selv + '","gradeCode":"' + gradecode + '","classid":"' + classid + '","subcode":"' + subcode + '"}';
            SubLearderSearch(subs,subUser);//科目组长初始化
            GradeManagerSearch(grades,gradecode);//年级领导初始化
            $.ajax({
                type: "POST",  //请求方式
                url: "SubLeaderInfo.aspx/page",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }else{
                        dodata(data.d);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        };
        //表格生成处理
        function dodata(data) {
            if (eval("(" + data + ")") != null && data != "") {
                var str = '';
                str += '<table id="data_table" class="table table-striped table-bordered table-hover" style="width:100%;margin:0px auto;">';
                str += '<thead>';
                str += '<tr>';
                str += '<th>年级名称</th>';
                str += '<th>班级名称</th>';
                str += '<th class="hidden-480" style="text-align:left;">班主任</th>';
                str += '<th class="hidden-480" style="text-align:left;">任课老师</th>';
                str += '<th>操作</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                $.each(eval("(" + data + ")"), function (index, item) { //遍历返回的json
                    
                    str += '<tr>';
                    str += '<td>' + item.GradeName + '</td>';
                    str += '<td>' + item.ClassName + '</td>';
                    str += '<td class="hidden-480" style="text-align:left;">' + item.TeacherClass + '</td>';
                    str += '<td class="hidden-480" style="text-align:left;">' + item.TeacherSub + '</td>';
                    str += '<td>';
                    str += '<div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">';
                    if (isedit == "True") {
                        str += '<a href="#" class="green" data-rel="tooltip"  onclick="EditCfmSuberGraderClasser(this,' + item.GradeId + ',' + item.ClassId + ',\'e\',\'classer\')" title="编辑">';
                        str += '<i class="icon-pencil bigger-130"></i>';
                        str += '</a>';
                    }
                    str += '</div>';
                    str += '<div class="visible-xs visible-sm hidden-md hidden-lg">';
                    str += '    <div class="inline position-relative">';
                    str += '        <button class="btn btn-minier btn-yellow dropdown-toggle" data-toggle="dropdown">';
                    str += '            <i class="icon-caret-down icon-only bigger-120"></i>';
                    str += '        </button>';
                    str += '        <ul class="dropdown-menu dropdown-only-icon dropdown-yellow pull-right dropdown-caret dropdown-close">';
                    if (isedit == "True") {
                        str += '        <li>';
                        str += '            <a href="#" class="tooltip-success" data-rel="tooltip"  onclick="EditCfmSuberGraderClasser(this,' + item.GradeCode + ',' + item.ClassId + ',\'e\',\'classer\')" title="编辑">';
                        str += '            <span class="green">';
                        str += '            <i class="icon-edit bigger-120"></i>';
                        str += '            </span>';
                        str += '            </a>';
                        str += '        </li>';
                    }
                    str += '        </ul>';
                    str += '    </div>';
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
        //获取市
        $('#aprov').change(function () {
            selv = $('#aprov').val();
            var ustat = $("#ustat").val();
            if(ustat==""){ustat="0";}
            var gradecode = $("#schgradeSearch").val();
            var params = '{"typecode":"1","pcode":"' + selv + '","ustat":"' + ustat + '","gradecode":"' + gradecode + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SubLeaderInfo.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }else{
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
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        });
        //获取区
        $('#acity').change(function () {
            selv = $('#acity').val();
            var ustat = $("#ustat").val();
            if(ustat==""){ustat="0";}
            var gradecode = $("#schgradeSearch").val();
            var params = '{"typecode":"2","pcode":"' + selv + '","ustat":"' + ustat + '","gradecode":"' + gradecode + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SubLeaderInfo.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }else{
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
                    }
                },
                error: function (obj, msg, e) {
                    alert(msg); alert(e);
                }
            });
        });
        //获取学校
        $('#acoty').change(function () {
            selv = $('#acoty').val();
            var ustat = $("#ustat").val();
            if(ustat==""){ustat="0";}
            var gradecode = $("#schgradeSearch").val();
            var params = '{"typecode":"3","pcode":"' + selv + '","ustat":"' + ustat + '","gradecode":"' + gradecode + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "../Users/UserInfo.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }else{
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
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        });
        $('#asch').change(function () {
            selv = $('#asch').val();
            var ustat = $("#ustat").val();
            if(ustat==""){ustat="0";}
            var gradecode = $("#schgradeSearch").val();
            getdata();
            var params = '{"typecode":"4","pcode":"' + selv + '","ustat":"' + ustat + '","gradecode":"' + gradecode + '"}';
            
            $.ajax({
                type: "POST",  //请求方式
                url: "SubLeaderInfo.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }else{
                        $("#asch option").each(function () {
                            if ($(this).val() == selv) {
                                $(this).attr("selected", true);
                            }
                            else {
                                $(this).removeAttr("selected");
                            }
                        });
                        var obj = eval('('+data.d+')');
                    
                        $("#schgradeSearch").html(obj.grade);
                        $("#schgradeSearch").change();
                        $("#schsubsSearch").html(obj.subs);
                        $("#schsubsSearch").change();
                        var classoption = "<option value=\"\">全部</option>";
                        $.each(obj.schclass, function (index, item){
                            classoption +="<option value=\""+item.ClassId+"\">"+item.ClassName+"</option>";
                        });
                        $("#schclassSearch").html(classoption);
                        $("#schclassSearch").change();
                    }
                },
                error: function (obj, msg, e) {
                    alert(msg);
                }
            });
        });
        //获取班级
        $('#schgradeSearch').change(function () {
            selv = $('#asch').val();
            if(typeof(selv)=="undefined"){selv=schid;}
            var ustat = $("#ustat").val();
            if(ustat==""){ustat="0";}
            var gradecode = $("#schgradeSearch").val();
            if(gradecode=="0"){gradecode="";}
            var params = '{"typecode":"4","pcode":"' + selv + '","ustat":"' + ustat + '","gradecode":"' + gradecode + '"}';
            //alert(params);
            $.ajax({
                type: "POST",  //请求方式
                url: "SubLeaderInfo.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }else{
                        var obj = eval('('+data.d+')');
                        var classoption = "<option value=\"\">全部</option>";
                        if(obj.schclass!=""){
                            $.each(obj.schclass, function (index, item){
                                classoption +="<option value=\""+item.ClassId+"\">"+item.ClassName+"</option>";
                            });
                        }
                        $("#schclassSearch").html(classoption);
                        $("#schclassSearch").change();
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        });
    </script>
    <!--//-->
    <script type="text/javascript">
        //搜索事件
        var subsearch={};
        var gradesearch={};
        var subtecsearch={};
        var subtext="";
        function search() {
            txtname = $('#txtname').val();//获取教师姓名
            selv = $('#asch').val();//获取学校编号
            if(typeof(selv)=="undefined"){selv = schid;}
            cotycode = $('#acoty').val();//获取县区编号
            ustat = $('#ustat').val();//获取状态：是否毕业
            if(ustat==""){ustat="0";}
            gradecode = $("#schgradeSearch").val();//获取年级编号
            if(gradecode=="0")gradecode="";
            classid = $("#schclassSearch").val();//获取班级编号
            if(classid=="0")classid="";
            subcode = $("#schsubsSearch").val();//获取科目编号
            if(subcode=="0")subcode="";
            subtext = $("#schsubsSearch option:selected").text();
            
            getdata();

        }
        //
        function getSearchData(){
            var params = '{"schid":"'+selv+'","gradecode":"'+gradecode+'","subcode":"' + subcode + '","ustat":"' + ustat + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SubLeaderInfo.aspx/getSearch",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }else{
                        var obj = eval('('+data.d+')');
                        SubLearderSearch(obj.subs,obj.subtec);//科目组长初始化
                        GradeManagerSearch(obj.grade,gradecode);//年级领导初始化
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        }
    </script>
    <!-- basic scripts -->
    <!--[if !IE]> -->
    <!-- <![endif]-->
    <!--[if IE]>
    <![endif]-->
    <style type="text/css">
        .ban_body {
            height: 100%;
            overflow: hidden;
        }
    </style>
    <!-- //模态框   打开学科组长模态框 -->
    <script type="text/javascript">
        $(document).ready(function () {
            if(selv==""){selv=schid;}
            getdata();//初始化班级数据
        });
        //科目组长、年级领导以及班级（班主任、任课教师)
        function EditCfmSuberGraderClasser(obj,gradecode,classid,dotype,urltype){
            $("html,body").addClass("ban_body")
            $("#EditCfmSuberGraderClasser").show(100);

            var selv = $("#asch").val();
            if(typeof(selv)=="undefined"){selv=schid;}
            var modeltitle = "";
            var ifrurl="";

            if(urltype=="suber"){//科目组长
                modeltitle="年级组长设置";
                ifrurl = "SchSubLeadEdit.aspx?dotype=" + dotype + "&schid=" + selv + "&subid=" + gradecode;
            }else if(urltype=="grader"){//年级领导
                modeltitle="年级组长设置";
                ifrurl = "SchGradeEdit.aspx?dotype=" + dotype + "&schid=" + selv + "&gradeid=" + gradecode;
            }else if(urltype=="classer"){//班级（班主任及任课教师）
                modeltitle="班级任课设置";
                if(gradecode==""){//添加班级
                    //gradecode = $("#schgradeSearch").val();
                    //var url = "SubLeaderEdit.aspx?dotype=" + dotype + "&schid=" + selv + "&gradecode=" + gradecode + "&classid=" + classid;
                }else{//编辑班级
                    ifrurl = "../GradeClassSet/SchClassE.aspx?dotype=" + dotype + "&schid=" + schid + "&gradecode=" + gradecode + "&classid=" + classid;
                }
            }
            $("#EditCfmSuberGraderClasser .title-style").html(modeltitle);
            $("#IfrSuberGraderClasser").attr("src", ifrurl);
            $("#EditCfmSuberGraderClasser").modal({
                backdrop: 'static',
                keyboard: false
            });
        }
        //从子页面返回的页面类型。suber:科目组长；grader：年级领导；classer：班主任及任课教师
        var ostypestr = "";
        //关闭模态框
        function closeEditCfmmodel(ostype) {
            ostypestr=ostype;
            $("#EditCfmSuberGraderClasser").modal("hide");
        }
        //关闭模态框时实时更新
        $(function () {
            $('#EditCfmSuberGraderClasser').on('hide.bs.modal',
            function () {
                $("html,body").removeClass("ban_body");
                if(ostypestr=="suber"){//科目组长
                    getSearchData();
                }else if(ostypestr=="grader"){//年级领导
                    getSearchData();
                }else if(ostypestr=="classer"){//班级（班主任及任课教师）
                    getdata();
                }
            })
        });
        //学科组长#SubLearder（访问初始化）
        function SubLearderSearch(subs,subUser){
            var SubLearderDom = "";
            SubLearderDom += "<div class=\"row tr\">";
            $.each(subs.ds, function (index, item) {
                
                SubLearderDom += "<div class=\"col-sm-3\">";
                SubLearderDom += "<div class=\"row\">";
                SubLearderDom += "  <div class=\"col-sm-3 no-padding subtitle\" >"+item["SubName"]+":</div>";
                SubLearderDom += "  <div class=\"col-sm-9 no-padding\">";
                $.each(subUser.ds, function (indexUser, itemUser) {
                    if(itemUser.SubCode==item.SubCode){
                        SubLearderDom += "<span title=\"" + itemUser["UserTname"] + "\">"+(itemUser["UserTname"] == null ? '' : (itemUser["UserTname"].length > 4 ? itemUser["UserTname"].substr(0, 4) + '...' : itemUser["UserTname"]))+"</span>";
                    }
                });
                if (isedit == "True") {
                    SubLearderDom += "      <a href=\"#\" class=\"green\" data-rel=\"tooltip\"  onclick=\"EditCfmSuberGraderClasser(this,'" + item.SubCode + "','','e','suber')\" title=\"编辑\">";
                    SubLearderDom += "      <i class=\"icon-pencil bigger-130\"></i>";
                    SubLearderDom += "      </a>";
                }
                SubLearderDom += "  </div>";
                SubLearderDom += "</div>";
                SubLearderDom += "</div>";
                if((index+1)%4==0){
                    SubLearderDom += "</div>";
                    SubLearderDom += "<div class=\"row tr\">";
                }
                
            });
            SubLearderDom += "</div>";
            $("#SubLearder").html(SubLearderDom);
        }
        //年级领导#GradeManager（访问初始化）
        function GradeManagerSearch(grades,gradecode){
            var GradeManagerDom = "";
            GradeManagerDom += "<div class=\"row tr\">";
            $.each(grades, function (index, item) {
                var gradebossarr = item["GradeBoss"].split(',');
                var gradebosslen = gradebossarr.length;
                
                GradeManagerDom += "<div class=\"col-sm-6\">";
                GradeManagerDom += "<div class=\"row\">";
                GradeManagerDom += "    <div class=\"col-sm-2 gradetitle\">"+item["GradeName"]+":</div>";
                GradeManagerDom += "    <div class=\"col-sm-10\">";
                for(var i=0;i<gradebosslen;i++){
                    if(gradebossarr[i]!=""){
                        GradeManagerDom += "<span title=\"" + gradebossarr[i] + "\">"+(gradebossarr[i] == null ? '' : (gradebossarr[i].length > 4 ? gradebossarr[i].substr(0, 4) + '...' : gradebossarr[i]))+"</span>";
                    }
                }
                if (isedit == "True") {
                    GradeManagerDom += "        <a href=\"#\" class=\"green\" data-rel=\"tooltip\"  onclick=\"EditCfmSuberGraderClasser(this,'" + item["GradeId"] + "','','e','grader')\" title=\"编辑\">";
                    GradeManagerDom += "        <i class=\"icon-pencil bigger-130\"></i>";
                    GradeManagerDom += "        </a>";
                }
                GradeManagerDom += "    </div>";
                GradeManagerDom += "</div>";
                GradeManagerDom += "</div>";
                if((index+1)%2==0){
                    GradeManagerDom += "</div>";
                    GradeManagerDom += "<div class=\"row tr\">";
                }
                
            });
            GradeManagerDom += "</div>";
            $("#GradeManager").html(GradeManagerDom);
        }
    </script>
</body>
</html>
