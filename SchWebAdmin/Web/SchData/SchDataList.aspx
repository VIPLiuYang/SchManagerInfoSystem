<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchDataList.aspx.cs" Inherits="SchWebAdmin.Web.SchData.SchDataList" %>

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
                        <li class="active">学校年级升级处理</li>
                    </ul>
                </div>

                <div class="page-content">
                    <div style="background-color: rgb(239, 243, 248); text-align: right; padding: 6px 4px;">
                        <%=areastr %>
                                        学校名称:<input type="text" id="txtname" placeholder="学校名称">
                        学校代码:<input type="text" id="txtschid" placeholder="学校代码">
                        学段:
                                        <select id="gradelv">
                                            <option value="">全部</option>
                                            <option value="1">幼儿园</option>
                                            <option value="2">小学</option>
                                            <option value="3">初中</option>
                                            <option value="4">高中</option>
                                        </select>
                        有无毕业班:
                                        <select id="isfinish">
                                            <option value="">全部</option>
                                            <option value="1">有</option>
                                            <option value="0">无</option>
                                        </select>
                        服务状态:
                                        <select id="ustat">
                                            <option value="">全部</option>
                                            <option value="1">正常</option>
                                            <option value="0">停用</option>
                                        </select>
                        <button class="btn btn-sm btn-info text_size" type="button" onclick="search();">查询</button>
                    </div>
                    <div class="table-responsive" id="list">
                    </div>
                    <div class="dataTables_paginate paging_bootstrap" style="background-color: rgb(239, 243, 248); border-bottom: 1px solid #ddd;">
                        <ul id="example">
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- 模态框   打开新建修改查看人员模态框 -->
    <div class="modal fade" id="EditCfmCreateUser">
        <div class="modal-dialog" style="width: 35%; height: 90%;">
            <div class="modal-content message_align" style="width: 90%; height: 56%;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title">添加人员</h4>
                </div>
                <div class="modal-body no-padding-top no-padding-bottom" style="width: 100%; height: 85%;">

                    <iframe id="modelCreateUser" src="" style="width: 100%; height: 95%; border: none"></iframe>

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- //模态框   打开新建修改查看人员模态框 -->
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

    <script type="text/javascript">
        //人员分页列表
        var PageIndex = 1;
        var PageSize = 10;
        var pageCount = 1;
        var txtname = '';
        var schid = '0';
        var cotycode = '';
        var ustat = '';
        var aprovserch = "";
        var acityserch = "";
        var txtschid = '';
        var gradelv = '';
        var isfinish = '';
        var isedit = '<%=isedit%>';
        var isdel = '<%=isdel%>';
        var islook = '<%=islook%>';
        function go() {

            sessionStorage.setItem("schdataindex", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("schdataindex_pageindex", PageIndex);
            sessionStorage.setItem("schdataindex_txtname", txtname);
            sessionStorage.setItem("schdataindex_cotycode", cotycode);
            sessionStorage.setItem("schdataindex_ustat", ustat);
            sessionStorage.setItem("schdataindex_uschid", schid);
            return false;
        };

        //页面缓存,页面是返回的
        var l = sessionStorage.getItem("schdataindex");
        if (l != null) {
            $("#main-container").html(l);            //删除缓存
            sessionStorage.removeItem("schdataindex");
            //取回缓存中的查询条件
            PageIndex = sessionStorage.getItem("schdataindex_pageindex");
            txtname = sessionStorage.getItem("schdataindex_txtname");
            cotycode = sessionStorage.getItem("schdataindex_cotycode");
            ustat = sessionStorage.getItem("schdataindex_ustat");
            schid = sessionStorage.getItem("schdataindex_uschid");
            sessionStorage.removeItem("schdataindex_pageindex");
            sessionStorage.removeItem("schdataindex_txtname");
            sessionStorage.removeItem("schdataindex_cotycode");
            sessionStorage.removeItem("schdataindex_ustat");
            sessionStorage.removeItem("schdataindex_uschid");
        }
        else {
            schid = '<%=schid%>';//第一次赋给ID
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

            var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","txtname":"' + txtname + '","ustat":"' + ustat + '","cotycode":"' + cotycode + '","schid":"' + schid + '","aprovserch":"' + aprovserch + '","acityserch":"' + acityserch + '","txtschid":"' + txtschid + '","gradelv":"' + gradelv + '","isfinish":"' + isfinish + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SchDataList.aspx/page",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    }
                    else if (data.d.code == "ExcepError") {
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
                str += '<th class="hidden-480">学校代码</th>';
                str += '<th>省</th>';
                str += '<th>市</th>';
                str += '<th>区县</th>';
                str += '<th>学校名称</th>';
                str += '<th class="hidden-480">平台域名</th>';
                str += '<th class="hidden-480">IP</th>';
                str += '<th class="hidden-480">学段</th>';
                str += '<th class="hidden-480">最近毕业年级</th>';
                str += '<th class="hidden-480">应用子系统</th>';
                str += '<th class="hidden-480">服务状态</th>';
                str += '<th class="hidden-480">创建时间</th>';
                str += '<th class="hidden-480">启用时间</th>';
                str += '<th class="hidden-480">到期时间</th>';
                str += '<th>操作</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                var i = 1;
                $.each(data.list, function (index, item) { //遍历返回的json

                    str += '<tr>';
                    str += '<td class="center">' + i + '</td>';
                    str += '<td>' + PreFixInterge(item.SchId, 8) + '</td>';
                    str += '<td>' + item.SHENG + '</td>';
                    str += '<td>' + item.SHI + '</td>';
                    str += '<td>' + item.QU + '</td>';

                    str += '<td title="' + item.SchName + '">' + (item.SchName == null ? '' : (item.SchName.length > 10 ? item.SchName.substr(0, 10) + '...' : item.SchName)) + '</td>';

                    str += '<td class="hidden-480" title="' + item.PlatformUrl + '">' + (item.PlatformUrl == null ? '' : (item.PlatformUrl.length > 10 ? item.PlatformUrl.substr(0, 10) + '...' : item.PlatformUrl)) + '</td>';

                    str += '<td class="hidden-480" title="' + item.PlatformIP + '">' + (item.PlatformIP == null ? '' : (item.PlatformIP.length > 10 ? item.PlatformIP.substr(0, 10) + '...' : item.PlatformIP)) + '</td>';

                    str += '<td class="hidden-480" title="' + item.SchoolSections + '">' + (item.SchoolSections == null ? '' : (item.SchoolSections.length > 4 ? item.SchoolSections.substr(0, 4) + '...' : item.SchoolSections)) + '</td>';

                    if (item.graduated != "") {
                        str += '<td class="hidden-480">' + item.graduated + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }

                    str += '<td class="hidden-480" title="' + item.AppSonSys + '">' + (item.AppSonSys == null ? '' : (item.AppSonSys.length > 4 ? item.AppSonSys.substr(0, 4) + '...' : item.AppSonSys)) + '</td>';

                    if (item.SonSysStat == "1") {
                        str += '<td class="hidden-480">正常</td>';
                    } else if (item.SonSysStat == "0") {
                        str += '<td class="hidden-480">停用</td>';
                    }

                    str += '<td class="hidden-480">' + item.RecTime.substring(0, 10) + '</td>';
                    if (item.SchSonSysEnableTime) {
                        str += '<td class="hidden-480">' + item.SchSonSysEnableTime.substring(0, 10) + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.SchSonSysEndDateTime) {
                        str += '<td class="hidden-480">' + item.SchSonSysEndDateTime.substring(0, 10) + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    str += '<td>';
                    str += '<div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">';
                    if (item.IsUpgrade == "1") {
                        str += '<a class="green" href=\'javascript:updateuser(' + item.SchId + ',"' + item.SchName + '")\' onclick="go();">';
                        str += '升级';
                        str += '</a>';
                    } else {
                        //str += '<a class="gray" style="color:gray;" href="javascript:void();" onclick="go();">';
                        //str += '升级';
                        //str += '</a>';
                    }
                    str += '</div>';
                    str += '<div class="visible-xs visible-sm hidden-md hidden-lg">';
                    str += '    <div class="inline position-relative">';
                    str += '        <button class="btn btn-minier btn-yellow dropdown-toggle" data-toggle="dropdown">';
                    str += '            <i class="icon-caret-down icon-only bigger-120"></i>';
                    str += '        </button>';
                    str += '        <ul class="dropdown-menu dropdown-only-icon dropdown-yellow pull-right dropdown-caret dropdown-close">';
                    str += '            <li>';
                    if (item.IsUpgrade == "1") {
                        str += '<a href=\'javascript:updateuser(' + item.SchId + ',' + item.SchName + '")\' class="tooltip-success" data-rel="tooltip" title="编辑" onclick="go();">';
                        str += '<span class="green">';
                        str += '升级';
                        str += '</span>';
                        str += '</a>';
                    };
                    str += '            </li>';
                    str += '        </ul>';
                    str += '    </div>';
                    str += '</div>';
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
            txtschid = $("#txtschid").val();
            gradelv = $("#gradelv").val();
            isfinish = $("#isfinish").val();
            if ($('#acoty').val() != "") {
                cotycode = $('#acoty').val();
            } else {
                cotycode = "";
            }
            ustat = $('#ustat').val();
            getdata();
        }
        $(document).ready(function () { getdata(); });
        //执行删除函数
        function DelRun(id) {
            var params = '{"id":"' + id + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SchDataList.aspx/udel",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
                        alert(data.d.msg);
                        window.location.href = "../../LoginExc.aspx";
                    } else if (data.d.code == "Success") {
                        alert(data.d.msg);
                        getdata();
                    } else {
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
            var params = '{"typecode":"1","pcode":"' + selv + '","isall":"1"}';
            if (selv != "") {
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
                        }
                        else {
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
            var params = '{"typecode":"2","pcode":"' + selv + '","isall":"1"}';
            if (selv != "") {
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
            $("#acoty option").each(function () {
                if ($(this).val() == selv) {
                    $(this).attr("selected", true);
                }
                else {
                    $(this).removeAttr("selected");
                }

            });
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
        function updateuser(schid, schname) {
            CreatUserModal(schid, schname, "", "e");
        }
        // 打开新建修改查看人员模态框，函数名：showGradeEditeModal
        var rel_id = ""; var rel_gradecode = "";
        function CreatUserModal(schid, schname, systype, ostype) {
            if (ostype == "e") {
                $("#EditCfmCreateUser .modal-title").html("学校年级升级处理");
                var url = "SchDataEdit.aspx?dotype=e&schid=" + schid + "&schname=" + schname + "&systype=" + systype;
            }

            $("#modelCreateUser").attr("src", url);
            $("#EditCfmCreateUser").modal({
                backdrop: 'static',
                keyboard: false
            });
        }
        $(function () {
            $('#EditCfmCreateUser').on('hide.bs.modal',
            function () {
                getdata();
            })
        });
        function createuserclose() {
            $("#EditCfmCreateUser").modal("hide");
        }
    </script>
</body>
</html>
