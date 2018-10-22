<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchXXTSearchList.aspx.cs" Inherits="SchWebAdmin.Web.SchXXTSearch.SchXXTSearchList" %>

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
                        <li class="active">家校互通平台信息查询 </li>
                    </ul>
                </div>
                <div class="page-content">
                                    <div style="background-color: rgb(239, 243, 248);text-align: right; padding: 6px 4px;">
                                        <%=areastr %>  &nbsp;
                                         学校：<input type="text" id="schname" placeholder="学校名称">&nbsp;
                                        学校代码：<input type="text" id="txtschid" placeholder="00001">&nbsp;&nbsp;
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
        var txtschid = "";
        var cotycode = '';
        var schname = "";
        var ustat = "";
        var aprovserch = "";
        var acityserch = "";

        
        function go() {
            sessionStorage.setItem("schxxtsearchlistindex", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("schxxtsearchlistindex_pageindex", PageIndex);
            sessionStorage.setItem("schxxtsearchlistindex_pagesize", PageSize);
            sessionStorage.setItem("schxxtsearchlistindex_pagecount", pageCount);
            sessionStorage.setItem("schxxtsearchlistindex_txtschid", txtschid);
            sessionStorage.setItem("schxxtsearchlistindex_cotycode", cotycode);
            sessionStorage.setItem("schxxtsearchlistindex_schname", schname);
            sessionStorage.setItem("schxxtsearchlistindex_ustat", ustat);;
            sessionStorage.setItem("schxxtsearchlistindex_aprovserch", aprovserch);
            sessionStorage.setItem("schxxtsearchlistindex_acitysearch", acityserch);

            return false;
        };
        //页面缓存,页面是返回的
        var l = sessionStorage.getItem("schxxtsearchlistindex");
        if (l != null) {
            $("#main-container").html(l);            //删除缓存
            sessionStorage.removeItem("schxxtsearchlistindex");
            //取回缓存中的查询条件
            PageIndex = sessionStorage.getItem("schxxtsearchlistindex_pageindex");
            PageSize = sessionStorage.getItem("schxxtsearchlistindex_pagesize");
            pageCount = sessionStorage.getItem("schxxtsearchlistindex_pagecount");
            txtschid = sessionStorage.getItem("schxxtsearchlistindex_txtschid");
            cotycode = sessionStorage.getItem("schxxtsearchlistindex_cotycode");
            schname = sessionStorage.getItem("schxxtsearchlistindex_schname");
            ustat = sessionStorage.getItem("schxxtsearchlistindex_ustat");
            aprovserch = sessionStorage.getItem("schxxtsearchlistindex_aprovserch");
            acityserch = sessionStorage.getItem("schxxtsearchlistindex_acitysearch");

            sessionStorage.removeItem("schxxtsearchlistindex_pageindex");
            sessionStorage.removeItem("schxxtsearchlistindex_pagesize");
            sessionStorage.removeItem("schxxtsearchlistindex_pagecount");
            sessionStorage.removeItem("schxxtsearchlistindex_txtschid");
            sessionStorage.removeItem("schxxtsearchlistindex_cotycode");
            sessionStorage.removeItem("schxxtsearchlistindex_schname");
            sessionStorage.removeItem("schxxtsearchlistindex_aprovserch");
            sessionStorage.removeItem("schxxtsearchlistindex_acitysearch");
            sessionStorage.removeItem("schxxtsearchlistindex_aprovserch");
            sessionStorage.removeItem("schxxtsearchlistindex_acitysearch");
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
        function search() {
            PageIndex = 1;
            PageSize = 10;
            pageCount = 1;
            txtschid = $('#txtschid').val();
            aprovserch = $('#aprov').val();
            acityserch = $('#acity').val();
            if ($('#acoty').val() != "") {
                cotycode = $('#acoty').val();
            } else {
                cotycode = "";
            }
            schname = $('#schname').val();
            ustat = $('#ustat').val();
            getdata();
        }
        window.onload = function () {
            getdata();
        }
        //获取数据
        function getdata() {

            var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","txtname":"' + txtschid + '","ustat":"' + ustat + '","cotycode":"' + cotycode + '","aprovserch":"' + aprovserch + '","acityserch":"' + acityserch + '","schname":"' + schname + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SchXXTSearchList.aspx/page",  //请求路径：页面/方法名字
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
                str += '<th class="hidden-480">科目</th>';
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
                    str += '<td title="' + item.SchName + '">' + (item.SchName.length > 10 ? item.SchName.substr(0, 10) + '...' : item.SchName) + '</td>';
                    
                    str += '<td title="' + item.HomeSchPlatName + '">' + (item.HomeSchPlatName == null ? '' : (item.HomeSchPlatName.length > 10 ? item.HomeSchPlatName.substr(0, 10) + '...' : item.HomeSchPlatName)) + '</td>';
                    
                    str += '<td title="' + item.HomeSchPlatUrl + '">' + (item.HomeSchPlatUrl == null ? '' : (item.HomeSchPlatUrl.length > 10 ? item.HomeSchPlatUrl.substr(0, 10) + '...' : item.HomeSchPlatUrl)) + '</td>';
                    if (item.HomeSchPlatIco != "") {
                        str += '<td>有</td>';
                    } else {
                        str += '<td>无</td>';
                    }
                    str += '<td title="' + item.HomeSchPlatIP + '">' + (item.HomeSchPlatIP == null ? '' : (item.HomeSchPlatIP.length > 10 ? item.HomeSchPlatIP.substr(0, 10) + '...' : item.HomeSchPlatIP)) + '</td>';
                    
                    str += '<td title="' + item.SchMaster + '">' + (item.SchMaster == null ? '' : (item.SchMaster.length > 4 ? item.SchMaster.substr(0, 4) + '...' : item.SchMaster)) + '</td>';
                    
                    str += '<td class="hidden-480" title="' + SchoolSectionstr + '">' + (SchoolSectionstr == null ? '' : (SchoolSectionstr.length > 4 ? SchoolSectionstr.substr(0, 4) + '...' : SchoolSectionstr)) + '</td>';
                    
                    str += '<td class="hidden-480" title="' + item.SchSubNames + '">' + (item.SchSubNames == null ? '' : (item.SchSubNames.length > 4 ? item.SchSubNames.substr(0, 4) + '...' : item.SchSubNames)) + '</td>';
                    if (item.HomeschServStat == 1) {
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
                    str += '<a class="blue" href="SchXXTSearchTba.aspx?schid=' + item.SchId + '" onclick="go()">';
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
                    str += '<a href="#" class="tooltip-info" data-rel="tooltip" title="查看">';
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
