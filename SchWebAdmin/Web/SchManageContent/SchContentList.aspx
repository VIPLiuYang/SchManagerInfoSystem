<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchContentList.aspx.cs" Inherits="SchWebAdmin.Web.SchManageContent.SchContentList" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>新建/修改学校基本信息</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>
    <style>
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
                        <li>目前位置：
                        </li>
                        <li class="active">学校内容维护 </li>
                    </ul>
                </div>
                <div class="page-content">
                    <div style="background-color: rgb(239, 243, 248);text-align: right; padding: 6px 4px;">
                        <%=areastr %> 
                                         学校名称：<input type="text" id="schname" placeholder="学校名称">&nbsp;
                                        学校代码：<input type="text" id="txtschid" placeholder="学校代码">&nbsp;
                                        服务状态：
                                        <select id="ustat">
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
    <script type="text/javascript">

        //人员分页列表
        var PageIndex = 1;
        var PageSize = 10;
        var pageCount = 1;
        var cotycode = '';
        var schname = "";
        var ustat = "";
        var txtschid = '';
        var aprovserch = "";
        var acityserch = "";

        function go() {
            sessionStorage.setItem("schcontentlist", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("schcontentlist_pageindex", PageIndex);
            sessionStorage.setItem("schcontentlist_pagesize", PageSize);
            sessionStorage.setItem("schcontentlist_pagecount", pageCount);
            sessionStorage.setItem("schcontentlist_txtschid", txtschid);
            sessionStorage.setItem("schcontentlist_cotycode", cotycode);
            sessionStorage.setItem("schcontentlist_schname", schname);
            sessionStorage.setItem("schcontentlist_aprovserch", aprovserch);
            sessionStorage.setItem("schcontentlist_acityserch", acityserch);
            sessionStorage.setItem("schcontentlist_ustat", ustat);
            return false;
        };
        //页面缓存,页面是返回的
        var l = sessionStorage.getItem("schcontentlist");
        if (l != null) {
            $("#main-container").html(l);            //删除缓存
            sessionStorage.removeItem("schcontentlist");
            //取回缓存中的查询条件
            PageIndex = sessionStorage.getItem("schcontentlist_pageindex");
            PageSize = sessionStorage.getItem("schcontentlist_pagesize");
            pageCount = sessionStorage.getItem("schcontentlist_pagecount");
            txtschid = sessionStorage.getItem("schcontentlist_txtschid");
            cotycode = sessionStorage.getItem("schcontentlist_cotycode");
            schname = sessionStorage.getItem("schcontentlist_schname");
            aprovserch = sessionStorage.getItem("schcontentlist_aprovserch");
            acityserch = sessionStorage.getItem("schcontentlist_acityserch");
            ustat = sessionStorage.getItem("schcontentlist_ustat");
            sessionStorage.removeItem("schcontentlist_pageindex");
            sessionStorage.removeItem("schcontentlist_pagesize");
            sessionStorage.removeItem("schcontentlist_pagecount");
            sessionStorage.removeItem("schcontentlist_txtschid");
            sessionStorage.removeItem("schcontentlist_cotycode");
            sessionStorage.removeItem("schcontentlist_ustat");
            sessionStorage.removeItem("schcontentlist_schname");
            sessionStorage.removeItem("schcontentlist_aprovserch");
            sessionStorage.removeItem("schcontentlist_acityserch");
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
        window.onload = function () {
            getdata();
        }
        function search() {
            PageIndex = 1;
            PageSize = 10;
            pageCount = 1;
            ustat = $("#ustat").val();
            txtschid = $("#txtschid").val();
            aprovserch = $('#aprov').val();
            acityserch = $('#acity').val();
            if ($('#acoty').val() != "") {
                cotycode = $('#acoty').val();
            } else {
                cotycode = "";
            }
            schname = $('#schname').val();
            getdata();
        }
        //获取数据
        function getdata() {

            var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","txtserstat":"' + ustat + '","cotycode":"' + cotycode + '","schname":"' + schname + '","aprovserch":"' + aprovserch + '","acityserch":"' + acityserch + '","txtschid":"' + txtschid + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SchContentList.aspx/page",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
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
                str += ' <th class="center">序号</th>';
                str += ' <th>学校代码</th>';
                str += '<th class="hidden-480">省</th>';
                str += '<th class="hidden-480">市</th>';
                str += '<th class="hidden-480">区县</th>';
                str += ' <th>学校名称</th>';
                str += ' <th>平台名称</th>';
                str += ' <th>平台域名</th>';
                str += ' <th>平台图标</th>';
                str += ' <th>IP地址</th>';
                str += ' <th>管理员</th>';
                str += '<th class="hidden-480">学段</th>';
                str += '<th class="hidden-480">最近毕业年级</th>';
                str += '<th class="hidden-480">科目</th>';
                str += '<th class="hidden-480">应用子系统</th>';
                str += '<th class="hidden-480">服务状态</th>';
                str += ' <th>客服</th>';
                str += ' <th>一线技术</th>';
                str += ' <th>创建者</th>';
                str += ' <th>创建时间</th>';
                str += ' <th>操作</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                $.each(data.list, function (index, item) { //遍历返回的json 
                    if (item.RecTime != null) {
                        item.RecTime = item.RecTime.substring(0, 10);
                    }
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
                    str += '<td class="center">' + (index + 1) + '</td>';
                    str += '<td>' + PreFixInterge(item.SchId, 8) + '</td>';
                    str += '<td>' + item.SHENG + '</td>';
                    str += '<td>' + item.SHI + '</td>';
                    str += '<td>' + item.QU + '</td>';
                    str += '<td title="' + item.SchName + '">' + (item.SchName == null ? '' : (item.SchName.length > 10 ? item.SchName.substr(0, 10) + '...' : item.SchName)) + '</td>';
                    str += '<td title="' + item.PlatformName + '">' + (item.PlatformName == null ? '' : (item.PlatformName.length > 4 ? item.PlatformName.substr(0, 4) + '...' : item.PlatformName)) + '</td>';
                    str += '<td title="' + item.PlatformUrl + '">' + (item.PlatformUrl == null ? '' : (item.PlatformUrl.length > 10 ? item.PlatformUrl.substr(0, 10) + '...' : item.PlatformUrl)) + '</td>';
                    if (item.PlatformIco != "") {
                        str += '<td>有</td>';
                    } else {
                        str += '<td>无</td>';
                    }
                    str += '<td title="' + item.PlatformIP + '">' + (item.PlatformIP == null ? '' : (item.PlatformIP.length > 10 ? item.PlatformIP.substr(0, 10) + '...' : item.PlatformIP)) + '</td>';
                    str += '<td title="' + item.SchMaster + '">' + (item.SchMaster == null ? '' : (item.SchMaster.length > 4 ? item.SchMaster.substr(0, 4) + '...' : item.SchMaster)) + '</td>';
                    str += '<td title="' + SchoolSectionstr + '">' + (SchoolSectionstr == null ? '' : (SchoolSectionstr.length > 4 ? SchoolSectionstr.substr(0, 4) + '...' : SchoolSectionstr)) + '</td>';
                    if (item.graduated != "") {
                        str += '<td class="hidden-480">' + item.graduated + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    str += '<td title="' + item.SchSubNames + '">' + (item.SchSubNames == null ? '' : (item.SchSubNames.length > 4 ? item.SchSubNames.substr(0, 4) + '...' : item.SchSubNames)) + '</td>';

                    str += '<td title="' + item.AppSonSys + '">' + (item.AppSonSys == null ? '' : (item.AppSonSys.length > 4 ? item.AppSonSys.substr(0, 4) + '...' : item.AppSonSys)) + '</td>';
                    if (item.SonSysStat == "1") {
                        str += '<td class="hidden-480">正常</td>';
                    } else {
                        str += '<td class="hidden-480">停用</td>';
                    }
                    str += '<td title="' + item.ServiceName + '">' + (item.ServiceName == null ? '' : (item.ServiceName.length > 4 ? item.ServiceName.substr(0, 4) + '...' : item.ServiceName)) + '</td>';
                    if (item.Artisan != "null") {
                        str += '<td>' + item.Artisan + '</td>';
                    } else {
                        str += '<td></td>';
                    }
                    str += '<td>' + item.SchCreator + '</td>';
                    str += '<td>' + item.RecTime + '</td>';
                    str += '<td>';
                    str += '<div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">';
                    str += '<a class="blue" href="SchContentTabs.aspx?schid=' + item.SchId + '" onclick="go()">';
                    str += '<i class="icon-zoom-in bigger-130"></i>';
                    str += '</a>';
                    str += '</div>';
                    str += '<div class="visible-xs visible-sm hidden-md hidden-lg">';
                    str += '<div class="inline position-relative">';
                    str += '<button class="btn btn-minier btn-yellow dropdown-toggle" data-toggle="dropdown">';
                    str += '<i class="icon-caret-down icon-only bigger-120"></i>';
                    str += '</button>';
                    str += '<ul class="dropdown-menu dropdown-only-icon dropdown-yellow pull-right dropdown-caret dropdown-close">';
                    str += '<li>';
                    str += '<a href="SchContentTabs.aspx?schid=' + item.SchId + '" class="tooltip-info" data-rel="tooltip" onclick="go()" title="查看">';
                    str += '<span class="blue">';
                    str += '<i class="icon-zoom-in bigger-120"></i>';
                    str += '</span>';
                    str += '</a>';
                    str += '</li>';
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
            } else {
                $('#acoty').empty();
                $('#acoty').append("<option value=\"\">全部</option>");
                //$("#acoty option:first").prop("selected", 'selected');
            }
        });
        //获取学校
        $('#acoty').change(function () {
            var selv = $('#acoty').val();
            var params = '{"typecode":"3","pcode":"' + selv + '","isall":"1"}';
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
