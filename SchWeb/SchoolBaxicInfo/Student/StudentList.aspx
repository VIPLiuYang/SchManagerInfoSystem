<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.Student.StudentList" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>学生信息列表</title>
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="../../assets/css/chosen.css" />
    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/bootstrap-select.css" />
    <link rel="stylesheet" href="../../assets/css/metro.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>
    <style>
       

        #rolestreeext {
            display: none;
        }
        .table thead > tr > th, .table tbody > tr > td {
            text-align: center;
        }

        /*弹出框标题背景样式*/
        .bootstrap-dialog.type-warning .modal-header {
            background-color: #ffffff !important;
        }
        /*弹出框标题样式*/
        .bootstrap-dialog .bootstrap-dialog-title {
            font-size: 18px !important;
            color: #f96161 !important;
        }
        /*弹出框确定按钮指针指上去样式*/
        .btn-warning:hover {
            background-color: #1b6aaa !important;
            border-color: #428bca !important;
        }
        /*弹出框确定按钮样式*/
        .btn-warning {
            background-color: #428bca !important;
            border-color: #428bca;
        }

        .pagination {
            border-top: 1px solid #DDD;
            padding-top: 12px;
            padding-bottom: 12px;
            background-color: #eff3f8;
        }

        .page-content {
            padding: 0px;
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
                        <li class="active">学生/家长及账号信息 </li>
                    </ul>
                    <div class="nav-search" id="nav-search">
                        <span id="addbtns"></span>
                    </div>
                </div>
                <div class="page-content">
                    <div style="background-color: rgb(239, 243, 248); padding: 6px 4px; ">
                        <%=areastr %>
                        <span style="float: right; margin-right: 50px;">学生姓名:&nbsp;<input type="text" id="Stuname" style="width: 150px; height: 30px; right: 50px;" placeholder="请输入学生姓名" />
                            <button class="btn btn-sm btn-info" type="button" onclick="search();">查询</button></span>
                    </div>
                            <div class="table-responsive" id="StuList">
                            
                    </div>
                    <div class="dataTables_paginate paging_bootstrap" style="background-color: rgb(239, 243, 248);  border-bottom: 1px solid #ddd;">
                        <ul id="example" class="pagination">
                        </ul>
                    </div>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.page-content -->
        </div>
    </div>
    <script type="text/javascript">
        window.jQuery || document.write("<script src='../../assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
    </script>
    <script src="../../assets/js/bootstrap.min.js"></script>
    <script src="../../assets/js/typeahead-bs2.min.js"></script>
    <script src="../../assets/js/jquery-ui-1.10.3.custom.min.js"></script>
    <script src="../../assets/js/jquery.ui.touch-punch.min.js"></script>
    <link href="../../assets/css/bootstrap-dialog.css" rel="stylesheet" />
    <script src="../../assets/js/bootstrap-dialog.js?v=1.1"></script>
    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>
    <script src="../../assets/js/bootstrap-paginator.js"></script>
    <script>
        var PageIndex = 1;
        var PageSize = 10;
        var pageCount = 1;
        var bjid = ""
        var njid = "";
        var xxid = "";
        var stuname = "";
        var stustat = "";
        var isadd = '<%=isadd%>';
        var stuid = '0';
        var schid = '<%=schid%>';
        var gradecode = "";
        var classid = "";
        var isaddlist = '<%=isaddlist%>'
            var usertname = "<%=usertname%>";
        if (isadd == 'False') {
            $('#addbtns').hide();
        }
        function go() {
            sessionStorage.setItem("schstuindex", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("schstuindex_pageindex", PageIndex);
            sessionStorage.setItem("schstuindex_njid", njid);
            sessionStorage.setItem("schstuindex_bjid", bjid);
            sessionStorage.setItem("schstuindex_schid", schid);
            sessionStorage.setItem("schstuindex_stustat", stustat);
            sessionStorage.setItem("schstuindex_stuname", stuname);
            sessionStorage.setItem("schstuindex_stuid", stuid);
            sessionStorage.setItem("schstuindex_gradecode", gradecode);
            sessionStorage.setItem("schstuindex_classid", classid);

            return false;
        };
        //页面缓存,页面是返回的
        var l = sessionStorage.getItem("schstuindex");
        if (l != null) {
            $("#main-container").html(l);            //删除缓存
            sessionStorage.removeItem("schstuindex");
            //取回缓存中的查询条件
            PageIndex = sessionStorage.getItem("schstuindex_pageindex");
            stuname = sessionStorage.getItem("schstuindex_stuname");
            schid = sessionStorage.getItem("schstuindex_schid");
            bjid = sessionStorage.getItem("schstuindex_bjid");
            njid = sessionStorage.getItem("schstuindex_njid");
            stustat = sessionStorage.getItem("schstuindex_stustat");
            stuid = sessionStorage.getItem("schstuindex_stuid");
            gradecode = sessionStorage.getItem("schstuindex_gradecode");
            classid = sessionStorage.getItem("schstuindex_classid");

            sessionStorage.removeItem("schstuindex_pageindex");
            sessionStorage.removeItem("schstuindex_stuname");
            sessionStorage.removeItem("schstuindex_schid");
            sessionStorage.removeItem("schstuindex_bjid");
            sessionStorage.removeItem("schstuindex_njid");
            sessionStorage.removeItem("schstuindex_stustat");
            sessionStorage.removeItem("schstuindex_stuid");
            sessionStorage.removeItem("schstuindex_gradecode");
            sessionStorage.removeItem("schstuindex_classid");
        }

        //进入添加页面
        $("#add").click(function () {
            self.location.href = "StudentEdit.aspx";
        })
        //人员分页列表
        //jQuery(function ($) {
        //    //var schid = $('#asch').val();
        //    //alert(schid);
        //    if (isadd == "True" && isaddlist == "True") {
        //        if (gradecode == "") { gradecode = 0; }
        //        if (classid == "") { classid = 0; }
        //        var addstr = '<div class="input-group pull-right">' +
        //                     ' <a class="btn btn-link" href="StudentEdit.aspx?dotype=a&gradecode=' + gradecode + '&classid=' + classid + ' "onclick="go();">' +
        //                    ' <i class="icon-plus align-top bigger-125"></i>' +
        //                         ' 新建学生和家长' +
        //                     '</a></div>';
        //        $('#addbtns').html(addstr);
        //    }

        //})


        function getPar(par) {
            //获取当前URL
            var local_url = document.location.href;
            //获取要取得的get参数位置
            var get = local_url.indexOf(par + "=");
            if (get == -1) {
                return false;
            }
            //截取字符串
            var get_par = local_url.slice(par.length + get + 1);
            //判断截取后的字符串是否还有其他get参数
            var nextPar = get_par.indexOf("&");
            if (nextPar != -1) {
                get_par = get_par.slice(0, nextPar);
            }
            return get_par;
        }
        var pageI = getPar("page");
        if (pageI == "") {
            pageI = 1;
        }
        //分页控件配置
        var options = {
            bootstrapMajorVersion: 3, //版本
            currentPage: PageIndex, //当前页数
            totalPages: pageCount, //总页数
            itemTexts: function (type, page, current) {
                switch (type) {
                    case "first":
                        return "首页";
                    case "prev":
                        return "上一页";
                    case "next":
                        return "下一页";
                    case "last":
                        return "末页";
                    case "page":
                        return page;
                }
            },//点击事件，用于通过Ajax来刷新整个list列表
            onPageClicked: function (event, originalEvent, type, page) {
                PageIndex = page;
                getdata();
            },
            bootstrapTooltipOptions: {
                animation: true,
                html: true,
                placement: 'top',
                selector: false,
                title: "",
                container: false
            },
            pageUrl: function (type, page, current) {
                return '#';
            }
        };
        $(document).ready(function () {

            getdata();
        });
    </script>
</body>
</html>
<script type="text/javascript">
    function search() {
        gradecode = $("#nj").val();
        if (gradecode == "-1") gradecode = "";
        classid = $("#bj").val();
        if (classid == "-1") classid = "";
        PageIndex = 1;
        PageSize = 10;
        pageCount = 1;
        bjid = $("#bj").val();
        var bzrtext = $("#bzr").html();
        if (bzrtext.indexOf(usertname) > 0) {
            gradecode = $("#nj").val();
            classid = $("#bj").val();
        }
        if (bjid == null) {
            bjid = "";
        }
        njid = $("#nj").val();
        xxid = '';
        stuname = $("#Stuname").val();

        if ($('#asch').val()) {
            xxid = $("#asch").val();
        }
        getdata();
    }
    //获取数据
    function getdata() {
        var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","ClassId":"' + bjid + '","SchId":"' + xxid + '","Stuname":"' + stuname + '","GradeId":"' + njid + '"}';
        $.ajax({
            type: "POST",  //请求方式
            url: "StudentList.aspx/page",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d == "expire") {
                    window.location.href = "../../LoginExc.aspx";
                } else {
                    dodata(data.d);
                }
                //
                isadd = eval("(" + data.d + ")").isadd;
                if (isadd == true && isaddlist == "True") {
                    //if (gradecode == "") { gradecode = 0; }
                    //if (classid == "") { classid = 0; }
                    var addstr = '<div class="input-group pull-right">' +
                                 ' <a class="btn btn-link" href="StuE.aspx?dotype=a&gradecode=' + gradecode + '&classid=' + classid + ' "onclick="go();">' +
                                ' <i class="icon-plus align-top bigger-125"></i>' +
                                     ' 新建学生和家长' +
                                 '</a></div>';
                    $('#addbtns').html(addstr);
                    $('#addbtns').show();
                }
                //
            },
            error: function (obj, msg, e) {
            }
        });
    };
    function dodata(data) {
        if (eval("(" + data + ")").list != null) {
            var text = ""; var i = 1;
            text += '  <table id="sample-table-2" class="table table-striped table-bordered table-hover dataTable">';
            text += ' <thead>';
            text += ' <tr>';
            text += ' <th class="center">';
            text += '<label>';
            text += '<input type="checkbox" class="ace" />';
            text += '<span class="lbl"></span>';
            text += '</label>';
            text += '</th>';
            text += ' <th>序号</th>';
            text += ' <th>年级</th>';
            text += ' <th>班级</th>';
            text += ' <th>系统编号</th>';
            text += ' <th>学(考号)</th>';
            text += '<th>学生姓名</th>';
            text += '<th>学生性别</th>';
            text += '<th class="hidden-480">学生卡号</th>';
            text += '<th class="hidden-480">电话</th>';
            text += '<th class="hidden-480">是否走读</th>';
            text += '<th class="hidden-480">家长姓名(一)</th>';
            text += ' <th class="hidden-480">家长电话</th>';
            text += '<th class="hidden-480">家长姓名(二)</th>';
            text += ' <th class="hidden-480">家长电话</th>';
            text += '<th>操作</th>';
            text += '</tr>';
            text += ' </thead> ';
            text += '<tbody>';
            var regtelphone = /^(\d{3})\d{4}(\d{4})$/;//显示前三位和后四位
            var regtelphone2 = /^(\d{1})\d{9}(\d{1})$/;//显示第一位和最后一位
            var regtelphone3 = /^(\d{1})\d{10}$/;//显示第一位
            $.each(eval("(" + data + ")").list, function (index, item) { //遍历返回的json
                var sex = item.Sex;
                if (sex == 1)
                    sex = "男"; else sex = "女";
                /*
                var Stat = item.Stat; 
                if (Stat == 1)  
                    Stat = "正常"; else Stat = "停用";
                */
                var StudyType = item.StudyType;
                if (StudyType == 0) {
                    StudyType = "住校";
                } else {
                    StudyType = "走读";
                }
                if (item.GenTelT != "") {
                    item.GenTelT = item.GenTelT.substr(0, 1) + '***';
                } else {
                    item.GenTelT = "";
                }
                if (item.GenNameT == null) {
                    item.GenNameT = "";
                }
                if (item.GenLoginNameT != "") {
                    item.GenLoginNameT = "****";
                }
                item.CardNo = item.CardNo != "" ? "****" : "";
                // item.TelNo = item.TelNo.replace(regtelphone3, "$1***");
                item.LoginName = item.LoginName != "" ? "****" : "";
                if (item.GenTelO) {
                    item.GenTelO = item.GenTelO.substr(0, 1) + '***';
                } else {
                    item.GenTelO = "";
                }
                item.GenLoginNameO = item.GenLoginNameO != "" ? "****" : "";
                var Stubh = "";
                if (JSON.stringify(item.StuId).length != 8) {
                    for (var i = 0; i < 8 - JSON.stringify(item.StuId).length; i++) {
                        Stubh += "0";
                    }
                }
                Stubh = Stubh + JSON.stringify(item.StuId);
                text += '<tr>';
                text += '   <td class="center">';
                text += '       <label>';
                text += '           <input type="checkbox" class="ace"  />';
                text += '           <span class="lbl"></span>';
                text += '       </label>';
                text += '   </td>';
                text += '   <td>' + (index + 1) + '</td>';
                text += '   <td>' + item.GradeName + '</td>';
                text += '   <td>' + item.ClassName + '</td>';
                text += '   <td>' + Stubh + '</td>';
                if (item.TestNo.length > 0) {
                    text += '   <td>' + item.TestNo.substr(0, 1) + '***</td>';
                }
                else {
                    text += '   <td>' + item.TestNo + '</td>';
                }
                text += '   <td>' + item.StuName + '</td>';
                text += '   <td>' + sex + '</td>';
                text += '   <td class="hidden-480">' + item.CardNo + '</td>';
                if (item.TelNo.length > 0) {
                    text += '   <td>' + item.TelNo.substr(0, 1) + '***</td>';
                }
                else {
                    text += '   <td>' + item.TelNo + '</td>';
                }
                text += '   <td class="hidden-480">' + StudyType + '</td>';
                //text +='   <td>' + item.LoginName + '</td>';
                if (item.GenNameO) {
                    text += '   <td class="hidden-480">' + item.GenNameO + '</td>';
                } else {
                    text += '   <td class="hidden-480"></td>';
                }
                text += '   <td class="hidden-480">' + item.GenTelO + '</td>';
                //text +='   <td class="hidden-480">' + item.GenLoginNameO + '</td>';
                if (item.GenNameT) {
                    text += '   <td class="hidden-480">' + item.GenNameT + '</td>';
                } else {
                    text += '   <td class="hidden-480"></td>';
                }
                text += '   <td class="hidden-480">' + item.GenTelT + '</td>';
                //text +='   <td class="hidden-480">' + item.GenLoginNameT + '</td>';
                //text +='   <td>' + Stat + '</td>';
                text += '   <td>';
                text += '       <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">';
                if (item.islook == '1') {
                    text += '	        <a class="green" href="StuShow2.aspx?id=' + item.StuId + '&dotype=c&gradecode=' + gradecode + '&classid=' + classid + '&Stubh=' + Stubh + '" onclick="go();">';
                    text += '	<span class="blue">';
                    text += '		        <i class="icon-zoom-in bigger-120"></i>';
                    text += '	        </span>';
                    text += '	        </a>';
                }
                if (item.isedit == '1') {
                    text += '	        <a class="green" href="StuE.aspx?id=' + item.StuId + '&dotype=e&gradecode=' + gradecode + '&classid=' + classid + '&Stubh=' + Stubh + '" onclick="go();">';
                    text += '		        <i class="icon-pencil bigger-130"></i>';
                    text += '	        </a>';
                }
                if (item.isdel == '1') {
                    text += '	        <a class="red" href="#">';
                    text += '		        <i class="icon-trash bigger-130" onclick="StudentDelete(' + item.StuId + ')" ></i>';
                    text += '	        </a>';
                }
                text += '       </div>';

                text += '<div class="visible-xs visible-sm hidden-md hidden-lg">';
                text += '<div class="inline position-relative">';
                text += '<button class="btn btn-minier btn-yellow dropdown-toggle" data-toggle="dropdown">';
                text += '<i class="icon-caret-down icon-only bigger-120"></i>';
                text += '</button>';
                text += '<ul class="dropdown-menu dropdown-only-icon dropdown-yellow pull-right dropdown-caret dropdown-close">';
                if (item.islook == '1') {

                    text += '<li>';
                    text += '<a href="StuShow2.aspx?id=' + item.StuId + '&dotype=c&gradecode=' + gradecode + '&classid=' + classid + '&Stubh=' + Stubh + '" class="tooltip-info" data-rel="tooltip" title="查看">';
                    text += '<span class="blue">';
                    text += '<i class="icon-zoom-in bigger-120"></i>';
                    text += '</span>';
                    text += '</a>';
                    text += '</li>';
                }

                if (item.isedit == '1') {
                    text += '<li>';
                    text += '<a  href="StuE.aspx?id=' + item.StuId + '&dotype=e&gradecode=' + gradecode + '&classid=' + classid + '" onclick="go();" class="tooltip-success" data-rel="tooltip" title="编辑">';
                    text += '<span class="green">';
                    text += '<i class="icon-edit bigger-120"></i>';
                    text += '</span>';
                    text += '</a>';
                    text += '</li>';
                }
                if (item.isdel == '1') {
                    text += '<li>';
                    text += '<a href="#" class="tooltip-error" onclick="StudentDelete(' + item.StuId + ')"  data-rel="tooltip" title="删除">';
                    text += '<span class="red">';
                    text += '<i class="icon-trash bigger-120"></i>';
                    text += '</span>';
                    text += '</a>';
                    text += '</li>';
                }
                text += '</ul>';
                text += '</div>';
                text += '</div>';
                text += '   </td>';
                text += '</tr>';
                i += 1;
            });
            text += '</tbody>';
            text += '</table>';
            $('#StuList').empty();
            $('#StuList').append(text);
            pageCount = eval("(" + data + ")").PageCount; //取到pageCount的值(把返回数据转成object类型)
            PageIndex = eval("(" + data + ")").PageIndex; //得到urrentPage
            options.currentPage = PageIndex;
            options.totalPages = pageCount;
            $('#example').bootstrapPaginator(options);

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
            $('#StuList').empty();
            $('#StuList').append("暂无数据!");
            $('#example').empty();
        }
    }

    //软删除数据
    function StudentDelete(id) {
        go();
        var msg = "如果删除此信息，所有有关该学生资料将丢失，确定要删除吗？";
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
                    $.ajax({
                        type: "POST",  //请求方式
                        url: "StudentList.aspx/studel",  //请求路径：页面/方法名字
                        data: '{ id: ' + id + ' }',     //参数
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            if (data.d == "Success") {
                                alert("删除成功");
                                getdata();
                            } else if (data.d == "expire") {
                                window.location.href = "../../LoginExc.aspx";
                            }
                        },
                        error: function (obj, msg, e) {
                        }
                    });

                }
            }
        });


    }



    //获取班级
    $('#nj').change(function () {
        $('#njld').html("年级领导：");
        var selv = $('#nj').val();
        schid = $('#asch').val();
        var params = '{"tp":"1","id":"' + selv + '"}';
        $.ajax({
            type: "POST",  //请求方式
            url: "StudentList.aspx/getusers",  //请求路径：页面/方法名字
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
            url: "StudentList.aspx/getarea",  //请求路径：页面/方法名字
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
        var params = '{"tp":"2","id":"' + selv + '"}';
        $.ajax({
            type: "POST",  //请求方式
            url: "StudentList.aspx/getusers",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var dd = eval("(" + data.d + ")");
                $('#bjjs').html("任课老师：" + dd.classtec);
                $('#bzr').html("班主任：" + dd.classms);
                $("#bj option").each(function () {
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
    $('#stustat').change(function () {
        var selv = $('#stustat').val();
        $("#stustat option").each(function () {
            if ($(this).val() == selv) {
                $(this).attr("selected", true);
            }
            else {
                $(this).removeAttr("selected");
            }

        });
    });

</script>
