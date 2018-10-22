<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchInfo.aspx.cs" Inherits="SchWebAdmin.Web.SchInfo.SchInfo" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>学校信息维护</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />

    <!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

    <!-- page specific plugin styles -->


    <!-- fonts -->


    <!-- ace styles -->

    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>
    <style>
        /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }

        i {
            font-family: FontAwesome !important;
        }

        .table thead > tr > th, .table tbody > tr > td {
            text-align: center;
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

<body ontouchstart>
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
                            <%--<i class="icon-home home-icon"></i>--%>
                            目前位置：
                        </li>
                        <li class="active">新建/修改学校基本信息</li>
                    </ul>
                    <div class="input-group pull-right">
                        <a class="btn btn-link" href="SchAdd.aspx?dotype=a" onclick="go();">
                            <i class="icon-plus align-top bigger-125"></i>新建学校
                        </a>
                    </div>
                </div>
                <div class="main-content" style="margin-left: 0px">
                    <div class="page-content">
                        <div style="background-color: rgb(239, 243, 248);text-align: right; padding: 6px 4px;">
                            <%=areastr %>
                                        学校名称:<input type="text" id="txtname" placeholder="学校名称">
                            学校代码:<input type="text" id="txtschid" placeholder="学校代码">
                            服务状态：
                                        <select id="ustat">
                                            <option value="">全部</option>
                                            <option value="1">正常</option>
                                            <option value="0">停用</option>
                                        </select>
                            <button class="btn btn-sm btn-info text_size" type="button" onclick="search();">查询</button>
                        </div>


                        <div class="table-responsive" id="list"></div>


                        <div class="dataTables_paginate paging_bootstrap" style="background-color: rgb(239, 243, 248); border-bottom: 1px solid #ddd;">
                            <ul id="example">
                            </ul>
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
    <link href="../../assets/css/bootstrap-dialog.css" rel="stylesheet" />
    <script src="../../assets/js/bootstrap-dialog.js"></script>
    <!-- ace scripts -->

    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>
    <script src="../../assets/js/bootstrap-paginator.js"></script>

    <!-- inline scripts related to this page -->
    <%--<script src="../../assets/js/i18n/defaults-zh_CN.min.js"></script>
    <script src="../../assets/js/date-time/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="../../assets/css/datepicker.css" />--%>

    <!-- inline scripts related to this page -->

    <script type="text/javascript">
        //人员分页列表
        var PageIndex = 1;
        var PageSize = 10;
        var pageCount = 1;
        var txtname = '';
        //var schid = '0';
        var cotycode = '';
        var ustat = '';
        var aprovserch = "";
        var acityserch = "";
        var txtschid = "";

        var isedit = '<%=isedit%>';
        var isdel = '<%=isdel%>';
        var islook = '<%=islook%>';
        function go() {

            sessionStorage.setItem("schinfoindex", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("schinfoindex_pageindex", PageIndex);
            sessionStorage.setItem("schinfoindex_txtname", txtname);
            sessionStorage.setItem("schinfoindex_cotycode", cotycode);
            sessionStorage.setItem("schinfoindex_ustat", ustat);
            sessionStorage.setItem("schinfoindex_txtschid", txtschid);
            sessionStorage.setItem("schinfoindex_aprovserch", aprovserch);
            sessionStorage.setItem("schinfoindex_acityserch", acityserch);
            return false;
        };

        //页面缓存,页面是返回的
        var l = sessionStorage.getItem("schinfoindex");
        if (l != null) {
            $("#main-container").html(l);            //删除缓存
            sessionStorage.removeItem("schinfoindex");
            //取回缓存中的查询条件
            PageIndex = sessionStorage.getItem("schinfoindex_pageindex");
            txtname = sessionStorage.getItem("schinfoindex_txtname");
            cotycode = sessionStorage.getItem("schinfoindex_cotycode");
            ustat = sessionStorage.getItem("schinfoindex_ustat");
            txtschid = sessionStorage.getItem("schinfoindex_txtschid");
            aprovserch = sessionStorage.getItem("schinfoindex_aprovserch");
            acityserch = sessionStorage.getItem("schinfoindex_acityserch");
            sessionStorage.removeItem("schinfoindex_pageindex");
            sessionStorage.removeItem("schinfoindex_txtname");
            sessionStorage.removeItem("schinfoindex_cotycode");
            sessionStorage.removeItem("schinfoindex_ustat");
            sessionStorage.removeItem("schinfoindex_txtschid");
            sessionStorage.removeItem("schinfoindex_aprovserch");
            sessionStorage.removeItem("schinfoindex_acityserch");
        }
        else {
            txtschid = '<%=schid%>';//第一次赋给ID
            cotycode = '<%=cotycode%>';
            //if (cotycode == '') {
            //    $('#searchbar').hide()
            //}
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
            //,
            //onPageChanged: function (event, oldPage, newPage) {
            //    PageIndex = newPage;
            //    getdata();
            //}
        };
        //获取数据
        function getdata() {

            var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","txtname":"' + txtname + '","ustat":"' + ustat + '","cotycode":"' + cotycode + '","schid":"' + txtschid + '","aprovserch":"' + aprovserch + '","acityserch":"' + acityserch + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SchInfo.aspx/page",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
                        alert(data.d.msg);
                        window.location.href = "../../LoginExc.aspx";
                    }
                    else if (data.d.code == "error") {
                        alert(data.d.msg);
                    }
                    else {
                        dodata(eval('(' + data.d.data + ')'));
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        };
        //num代表传入的数字，n代表要保留的字符的长度  
        function PreFixInterge(num, n) {
            return (Array(n).join(0) + num).slice(-n);
        }
        //表格生成处理
        function dodata(data) {
            if (data.list != null) {
                var str = '';
                str += '<table id="data_table" class="table table-striped table-bordered table-hover dataTable">';
                str += '<thead>';
                str += '<tr>';
                str += '<th class="center">序号</th>';
                str += '<th class="center hidden-480">学校代码</th>';
                str += '<th class="center hidden-480">省</th>';
                str += '<th class="center hidden-480">市</th>';
                str += '<th class="center hidden-480">区县</th>';
                str += '<th class="center">学校名称</th>';
                str += '<th class="center">学校类型</th>';
                str += '<th class="center hidden-480">平台名称</th>';
                str += '<th class="center hidden-480">平台域名</th>';
                str += '<th class="center hidden-480">平台图标</th>';
                str += '<th class="center hidden-480">IP地址</th>';
                str += '<th class="center hidden-480">管理员</th>';
                str += '<th class="center hidden-480">学段</th>';
                str += '<th class="center hidden-480">最近毕业年级</th>';
                str += '<th class="center hidden-480">科目</th>';
                str += '<th class="center hidden-480">应用子系统</th>';
                str += '<th class="center hidden-480">服务状态</th>';
                str += '<th class="center hidden-480">客服</th>';
                str += '<th class="center hidden-480">一线技术</th>';
                str += '<th class="center hidden-480">创建者</th>';
                str += '<th class="center hidden-480">创建日期</th>';
                str += '<th>操作</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                var i = 1;
                $.each(data.list, function (index, item) { //遍历返回的json
                    var SchoolSectionstr = "";
                    if (item.SchoolSection != null) {
                        var sss = item.SchoolSection;
                        var SchoolSectionarr = sss.toString().split(',');
                        for (var j = 0; j < SchoolSectionarr.length; j++) {
                            if (SchoolSectionarr[j] == "1") { SchoolSectionstr += "幼儿园，"; }
                            if (SchoolSectionarr[j] == "2") { SchoolSectionstr += "小学，"; }
                            if (SchoolSectionarr[j] == "3") { SchoolSectionstr += "初中，"; }
                            if (SchoolSectionarr[j] == "4") { SchoolSectionstr += "高中，"; }
                        }
                    }
                    SchoolSectionstr = SchoolSectionstr.substring(0, SchoolSectionstr.length - 1);
                    str += '<tr>';
                    str += '<td class="center">' + i + '</td>';
                    str += '<td class="hidden-480">' + PreFixInterge(item.SchId, 8) + '</td>';
                    str += '<td class="hidden-480">' + item.SHENG + '</td>';
                    str += '<td class="hidden-480">' + item.SHI + '</td>';
                    str += '<td class="hidden-480">' + item.QU + '</td>';

                    str += '<td title="' + item.SchName + '">' + (item.SchName == null ? '' : (item.SchName.length > 10 ? item.SchName.substr(0, 10) + '...' : item.SchName)) + '</td>';//

                    str += '<td class="hidden-480">' + item.SchTypeName + '</td>';

                    str += '<td class="hidden-480" title="' + item.PlatformName + '">' + (item.PlatformName == null ? '' : (item.PlatformName.length > 10 ? item.PlatformName.substr(0, 10) + '...' : item.PlatformName)) + '</td>';

                    str += '<td class="hidden-480" title="' + item.PlatformUrl + '">' + (item.PlatformUrl == null ? '' : (item.PlatformUrl.length > 10 ? item.PlatformUrl.substr(0, 10) + '...' : item.PlatformUrl)) + '</td>';

                    if (item.PlatformIco != "") {
                        str += '<td class="hidden-480">有</td>';
                    } else {
                        str += '<td class="hidden-480">无</td>';
                    }

                    str += '<td class="hidden-480" title="' + item.PlatformIP + '">' + (item.PlatformIP == null ? '' : (item.PlatformIP.length > 10 ? item.PlatformIP.substr(0, 10) + '...' : item.PlatformIP)) + '</td>';

                    str += '<td class="hidden-480" title="' + item.SchMaster + '">' + (item.SchMaster == null ? '' : (item.SchMaster.length > 4 ? item.SchMaster.substr(0, 4) + '...' : item.SchMaster)) + '</td>';

                    str += '<td class="hidden-480" title="' + SchoolSectionstr + '">' + (SchoolSectionstr == null ? '' : (SchoolSectionstr.length > 4 ? SchoolSectionstr.substr(0, 4) + '...' : SchoolSectionstr)) + '</td>';

                    if (item.graduated != "") {
                        str += '<td class="hidden-480">' + item.graduated + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }

                    str += '<td class="hidden-480" title="' + item.SchSubNames + '">' + (item.SchSubNames == null ? '' : (item.SchSubNames.length > 4 ? item.SchSubNames.substr(0, 4) + '...' : item.SchSubNames)) + '</td>';

                    str += '<td class="hidden-480" title="' + item.AppSonSys + '">' + (item.AppSonSys == null ? '' : (item.AppSonSys.length > 4 ? item.AppSonSys.substr(0, 4) + '...' : item.AppSonSys)) + '</td>';

                    if (item.SonSysStat == "1") {
                        str += '<td class="hidden-480">正常</td>';
                    } else {
                        str += '<td class="hidden-480">停用</td>';
                    }
                    str += '<td class="hidden-480" title="' + item.ServiceName + '">' + (item.ServiceName == null ? '' : (item.ServiceName.length > 4 ? item.ServiceName.substr(0, 4) + '...' : item.ServiceName)) + '</td>';

                    if (item.Artisan == "null" || item.Artisan == "undefined") {
                        str += '<td class="hidden-480"></td>';
                    } else {
                        str += '<td class="hidden-480">' + item.Artisan + '</td>';
                    }
                    str += '<td class="hidden-480">' + item.SchCreator + '</td>';
                    str += '<td class="hidden-480">' + item.RecTime.substring(0, 10) + '</td>';
                    str += '<td>';
                    str += '<div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">';
                    str += '<a class="green" href="SchEdit.aspx?dotype=e&schid=' + item.SchId + '" onclick="go();">';
                    str += '<i class="icon-pencil bigger-130"></i>';
                    str += '    </a>';
                    str += '</div>';
                    str += '<div class="visible-xs visible-sm hidden-md hidden-lg">';
                    str += '    <div class="inline position-relative">';
                    str += '        <button class="btn btn-minier btn-yellow dropdown-toggle" data-toggle="dropdown">';
                    str += '            <i class="icon-caret-down icon-only bigger-120"></i>';
                    str += '        </button>';
                    str += '        <ul class="dropdown-menu dropdown-only-icon dropdown-yellow pull-right dropdown-caret dropdown-close">';
                    str += '            <li>';
                    str += '                <a href="SchEdit.aspx?dotype=e&schid=' + item.SchId + '" class="tooltip-success" data-rel="tooltip" title="编辑" onclick="go();">';
                    str += '                    <span class="blue">';
                    str += '                        <i class="icon-edit bigger-120"></i>';
                    str += '                    </span>';
                    str += '                </a>';
                    str += '            </li>';
                    str += '        </ul>';
                    str += '    </div>';
                    str += '</div>';
                    //str += '<div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">';
                    //str += '<a class="green" href="SchEdit.aspx?dotype=e&schid=' + item.SchId + '" onclick="go();">';
                    //str += '<i class="icon-pencil bigger-130"></i>';
                    //str += '</a>';
                    //str += '</div>';
                    //str += '<div class="visible-xs visible-sm hidden-md hidden-lg">';
                    //str += '<div class="inline position-relative">';
                    //str += '<button class="btn btn-minier btn-yellow dropdown-toggle" data-toggle="dropdown">';
                    //str += '<i class="icon-caret-down icon-only bigger-120"></i>';
                    //str += '</button>';
                    //str += '<li>';
                    //str += '<a href="SchEdit.aspx?dotype=e&schid=' + item.SchId + '" class="tooltip-success" data-rel="tooltip" title="编辑" onclick="go();">';
                    //str += '<span class="green">';
                    //str += '<i class="icon-edit bigger-120"></i>';
                    //str += '</span>';
                    //str += '</a>';
                    //str += '</li>';
                    //str += '</ul>';
                    //str += '</div>';
                    //str += '</div>';
                    str += '</td>';
                    str += '</tr>';
                    i++;
                });
                str += '</tbody>';
                str += '</table>';
                $('#list').empty();
                $('#list').append(str);
                pageCount = data.PageCount; //取到pageCount的值(把返回数据转成object类型)
                PageIndex = data.PageIndex; //得到urrentPage
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
                $('#list').empty();
                $('#list').append("暂无数据!");
                $('#example').empty();
            }
        };
        function search() {
            PageIndex = 1;
            PageSize = 10;
            pageCount = 1;
            txtname = $('#txtname').val();
            aprovserch = $('#aprov').val();
            acityserch = $('#acity').val();
            if ($('#acoty').val() != "") {
                cotycode = $('#acoty').val();
            } else {
                cotycode = "";
            }
            ustat = $('#ustat').val();
            txtschid = $("#txtschid").val();
            getdata();
        }
        $(document).ready(function () { getdata(); });
        //执行删除函数
        function DelRun(id) {
            var params = '{"id":"' + id + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SchInfo.aspx/udel",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
                        alert(data.d.msg);
                        window.location.href = "../../LoginExc.aspx";
                    }
                    else if (data.d.code == "error") {
                        alert(data.d.msg);
                        getdata();
                    }
                    else {
                        alert(data.d.msg);
                        getdata();
                    }
                },
                error: function (obj, msg, e) {
                }
            });

        }
        //删除模态框
        function delu(id) {
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
                        DelRun(id);// 执行方法
                    }
                }
            });
            //};
        }
        //获取市
        $('#aprov').change(function () {
            var selv = $('#aprov').val();
            if (selv != "") {
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
                            $("#aprov option").each(function () {
                                if ($(this).val() == selv) {
                                    $(this).attr("selected", true);
                                }
                                else {
                                    $(this).removeAttr("selected");
                                }

                            });
                            $('#acity').html(data.d.data);
                            $('#acity').change();
                        }
                    },
                    error: function (obj, msg, e) {
                    }
                });
            } else {
                $('#acity').empty();
                $('#acity').append("<option value=\"\">全部</option>");
                //$("#acity option:first").prop("selected", 'selected');
                $('#acoty').empty();
                $('#acoty').append("<option value=\"\">全部</option>");
                //$("#acoty option:first").prop("selected", 'selected');
            }
        });
        //获取区
        $('#acity').change(function () {
            var selv = $('#acity').val();
            if (selv != "") {
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
                            $("#acity option").each(function () {
                                if ($(this).val() == selv) {
                                    $(this).attr("selected", true);
                                }
                                else {
                                    $(this).removeAttr("selected");
                                }

                            });
                            $('#acoty').html(data.d.data);
                            $('#acoty').change();
                        }
                    },
                    error: function (obj, msg, e) {
                    }
                });
            } else {
                $('#acoty').empty();
                $('#acoty').append("<option value=\"\">全部</option>");
                //$("#acoty option:first").prop("selected", 'selected');
            }
        });
        //获取学校
        $('#acoty').change(function () {
            var selv = $('#acoty').val();
            if (selv != "") {
                $("#acoty option").each(function () {
                    if ($(this).val() == selv) {
                        $(this).attr("selected", true);
                    }
                    else {
                        $(this).removeAttr("selected");
                    }

                });
            }
        });
        $('#ustat').change(function () {
            var selv = $('#ustat').val();
            $("#ustat option").each(function () {
                if ($(this).val() == selv) {
                    $(this).attr("selected", true);
                }
                else {
                    $(this).removeAttr("selected");
                }

            });
        });
    </script>
</body>
</html>
