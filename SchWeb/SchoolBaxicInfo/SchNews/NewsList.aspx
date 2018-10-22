<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.SchNews.NewsList" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>新闻列表</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,栏目,2018" />
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
                        <li class="active">电子班牌/新闻列表</li>
                    </ul>
                    <div class="nav-search" id="nav-search">
                        <span id="addbtns"></span>
                    </div>
                </div>

                <div class="page-content">
                        <div style="background-color: rgb(239, 243, 248); text-align: right; padding: 6px 4px;">
                            文章标题:<input type="text" id="txtname" placeholder="标题">
                            类别:
                                    <select id="drptype">
                                        <option value="">全部</option>
                                        <option value="0">班级</option>
                                        <option value="1">年级</option>
                                        <option value="2">学校</option>
                                    </select>
                            栏目:
                                    <select id="txtcode"><%=chndrp %></select>
                            状态:
                                    <select id="ustat">
                                        <option value="">全部</option>
                                        <option value="1">正常</option>
                                        <option value="0">屏蔽</option>
                                    </select>
                            <button class="btn btn-sm btn-info" type="button" onclick="search();">查询</button>
                        </div>


                        <div class="table-responsive" id="list"></div>


                        <div class="dataTables_paginate paging_bootstrap" style="background-color: rgb(239, 243, 248); border-bottom: 1px solid #ddd;">
                            <ul id="example" class="pagination">
                            </ul>
                        </div>
                </div>
            </div>
        </div>
    </div>
    <!-- 模态框   打开新建修改查看人员模态框 -->
    <div class="modal fade" id="EditCfm">
        <div class="modal-dialog" style="width: 45%; height: 50%;">
            <div class="modal-content message_align" style="width: 100%; height: 100%;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title">添加栏目</h4>
                </div>
                <div class="modal-body no-padding-top no-padding-bottom" style="width: 100%; height: 85%;">

                    <iframe id="modelEdit" src="" style="width: 100%; height: 95%; border: none"></iframe>

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
    <script src="../../assets/js/bootstrap-dialog.js?v=1.1"></script>
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
        var drptype = $('#drptype').val();
        var txtcode = $('#txtcode').val();
        var ustat = '';
        var iisadd = '<%=isadd%>';
        if (iisadd == "True") {
            var addstr = '<div class="input-group pull-right">' +
                                     ' <a class="btn btn-link" href="NewsAdd.aspx"  onclick="go();">' +
                                    ' <i class="icon-plus align-top bigger-125"></i>' +
                                         ' 添加' +
                                     '</a></div>';
            $('#addbtns').html(addstr);
            $('#addbtns').show();
        }

        function go() {

            sessionStorage.setItem("schnewsindex", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("schnewsindex_pageindex", PageIndex);
            sessionStorage.setItem("schnewsindex_txtname", txtname);
            sessionStorage.setItem("schnewsindex_ustat", ustat);
            sessionStorage.setItem("schnewsindex_txtcode", txtcode);
            sessionStorage.setItem("schnewsindex_drptype", drptype);
            return false;
        };

        //页面缓存,页面是返回的
        var l = sessionStorage.getItem("schnewsindex");
        if (l != null) {
            $("#main-container").html(l);            //删除缓存
            sessionStorage.removeItem("schnewsindex");
            //取回缓存中的查询条件
            PageIndex = sessionStorage.getItem("schnewsindex_pageindex");
            txtname = sessionStorage.getItem("schnewsindex_txtname");
            ustat = sessionStorage.getItem("schnewsindex_ustat");
            txtcode = sessionStorage.getItem("schnewsindex_txtcode");
            drptype = sessionStorage.getItem("schnewsindex_drptype");
            sessionStorage.removeItem("schnewsindex_pageindex");
            sessionStorage.removeItem("schnewsindex_txtname");
            sessionStorage.removeItem("schnewsindex_ustat");
            sessionStorage.removeItem("schnewsindex_txtcode");
            sessionStorage.removeItem("schnewsindex_drptype");
        }
        else {
            txtcode = $('#txtcode').val();//第一次赋给ID
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

            var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","txtname":"' + txtname + '","ustat":"' + ustat + '","txtcode":"' + txtcode + '","drptype":"' + drptype + '"}';//drptype
            $.ajax({
                type: "POST",  //请求方式
                url: "NewsList.aspx/page",  //请求路径：页面/方法名字
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
                        dodata(eval('(' + data.d.RspData + ')'));
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
                str += '<th class="hidden-480">栏目</th>';
                str += '<th class="hidden-480">类别</th>';
                str += '<th class="hidden-480">年级</th>';
                str += '<th class="hidden-480">班级</th>';
                str += '<th style="text-align:left;">标题</th>';
                str += '<th class="hidden-480">时间</th>';
                str += '<th>操作</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                var i = 1;
                $.each(data.list, function (index, item) { //遍历返回的json
                    var datetimes = "";
                    var times = "";
                    if (item.RecTime) {
                        datetimes = item.RecTime.split('T')[0];
                        times = item.RecTime.split('T')[1].split('.')[0];
                    }
                    str += '<tr>';
                    str += '<td class="center">' + i + '</td>';
                    str += '<td class="hidden-480">' + item.ChnName + '</td>';
                    str += '<td class="hidden-480">' + item.LvName + '</td>';
                    str += '<td class="hidden-480">' + item.GradeName + '</td>';
                    str += '<td class="hidden-480">' + item.ClassName + '</td>';
                    str += '<td style="text-align:left;" title="' + item.Topic + '">' + (item.Topic == null ? '' : (item.Topic.length > 10 ? item.Topic.substr(0, 10) + '...' : item.Topic)) + '</td>';
                    str += '<td class="hidden-480">' + datetimes + '&nbsp;&nbsp;' + times + '</td>';
                    str += '<td>';
                    str += '<div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">';

                    str += '<a class="blue" title="查看" href="NewsShow.aspx?dotype=e&newsid=' + item.NewsId + '"  onclick="go();">';
                    str += '    <i class="icon-zoom-in bigger-130"></i>';
                    str += '</a>';

                    if (item.isedit == '1') {
                        str += '<a class="green" title="编辑" href="NewsEdit.aspx?dotype=e&newsid=' + item.NewsId + '" onclick="go();">';
                        str += '    <i class="icon-pencil bigger-130"></i>';
                        str += '</a>';
                    }

                    if (item.isdel == '1') {
                        
                        if (item.Stat == "1")
                        {
                            str += '<a class="red" href="#" title="取消显示" onclick="delu(' + item.NewsId + ',0)" >';
                            str += '    <i class="icon-eye-close bigger-130"></i>';
                            str += '</a>';
                        }
                        else{
                            str += '<a class="red green" href="#" title="开启显示" onclick="delu(' + item.NewsId + ',1)" >';
                            str += '    <i class="icon-eye-open bigger-130"></i>';
                            str += '</a>';
                        }
                        if (item.IsTop == "1") {
                            str += '<a class="red" href="#" title="取消置顶" onclick="delu(' + item.NewsId + ',6)" >';
                            str += '    <i class="icon-arrow-down bigger-130"></i>';
                            str += '</a>';
                        }
                        else {
                            str += '<a class="red green" href="#" title="置顶" onclick="delu(' + item.NewsId + ',5)" >';
                            str += '    <i class="icon-arrow-up bigger-130"></i>';
                            str += '</a>';
                        }
                        str += '<a class="red" href="#" title="删除" onclick="delu(' + item.NewsId + ',2)" >';
                        str += '    <i class="icon-trash bigger-130"></i>';
                        str += '</a>';
                    }
                    str += '</div>';

                    str += '<div class="visible-xs visible-sm hidden-md hidden-lg">';
                    str += '    <div class="inline position-relative">';
                    str += '        <button class="btn btn-minier btn-yellow dropdown-toggle" data-toggle="dropdown">';
                    str += '            <i class="icon-caret-down icon-only bigger-120"></i>';
                    str += '        </button>';

                    str += '    <ul class="dropdown-menu dropdown-only-icon dropdown-yellow pull-right dropdown-caret dropdown-close">';
                    str += '<li>';
                    str += '<a href="NewsShow.aspx?dotype=e&newsid=' + item.NewsId + '"  class="tooltip-info" data-rel="tooltip" title="查看" onclick="go();">';
                    str += '<span class="blue">';
                    str += '<i class="icon-zoom-in bigger-120"></i>';
                    str += '</span>';
                    str += '</a>';
                    str += '</li>';


                    if (item.isedit == '1') {
                        str += '<li>';
                        str += '<a href="NewsEdit.aspx?dotype=e&newsid=' + item.NewsId + '" class="tooltip-success" data-rel="tooltip" title="编辑" onclick="go();">';
                        str += '<span class="green">';
                        str += '<i class="icon-edit bigger-120"></i>';
                        str += '</span>';
                        str += '</a>';
                        str += '</li>';
                    }
                    if (item.isdel == '1') {
                        
                        if (item.Stat == "1") {
                            str += '<li>';
                            str += '<a href="#" class="tooltip-error" onclick="delu(' + item.NewsId + ',0)" data-rel="tooltip" title="取消显示">';
                            str += '<span class="red">';
                            str += '<i class="icon-eye-close bigger-120"></i>';
                            str += '</span>';
                            str += '</a>';
                            str += '</li>';
                        }
                        else {
                            str += '<li>';
                            str += '<a href="#" class="tooltip-error" onclick="delu(' + item.NewsId + ',1)" data-rel="tooltip" title="开启显示">';
                            str += '<span class="green">';
                            str += '<i class="icon-eye-open bigger-120"></i>';
                            str += '</span>';
                            str += '</a>';
                            str += '</li>';
                        }
                        if (item.IsTop == "1") {
                            str += '<li>';
                            str += '<a href="#" class="tooltip-error" onclick="delu(' + item.NewsId + ',6)" data-rel="tooltip" title="取消置顶">';
                            str += '<span class="red">';
                            str += '<i class="icon-arrow-down bigger-120"></i>';
                            str += '</span>';
                            str += '</a>';
                            str += '</li>';
                        }
                        else {
                            str += '<li>';
                            str += '<a href="#" class="tooltip-error" onclick="delu(' + item.NewsId + ',5)" data-rel="tooltip" title="置顶">';
                            str += '<span class="green">';
                            str += '<i class="icon-arrow-up bigger-120"></i>';
                            str += '</span>';
                            str += '</a>';
                            str += '</li>';
                        }
                        str += '<li>';
                        str += '<a href="#" class="tooltip-error" onclick="delu(' + item.NewsId + ',2)" data-rel="tooltip" title="删除">';
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
            txtschid = $("#txtschid").val();
            txtcode = $('#txtcode').val();
            drptype = $('#drptype').val();
            acityserch = $('#acity').val();
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
        function DelRun(id,stat) {
            var params = '{"id":"' + id + '","stat":"' + stat + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "NewsList.aspx/udel",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == 'success') {
                        alert(data.d.msg);
                        getdata();
                    }
                    else if (data.d.code == "error") {
                        alert(data.d.msg);
                        getdata();
                    }
                    else if (data.d.code == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    }
                },
                error: function (obj, msg, e) {
                }
            });

        }
        //删除模态框
        function delu(id,stat) {
            var msg = "确认删除这条信息吗？";
            if (stat == 0)
            {
                msg = "确认要屏蔽这条信息吗？";
            }
            if (stat == 1) {
                msg = "确认要显示这条信息吗？";
            }
            else if (stat == 5) {
                msg = "确认要置顶这条信息吗？";
            }
            else if (stat == 6) {
                msg = "确认要取消置顶这条信息吗？";
            }
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
                        DelRun(id,stat);// 执行方法
                    }
                }
            });
            //};
        }
        $('#drptype').change(function () {
            var selv = $('#drptype').val();
            $("#drptype option").each(function () {
                if ($(this).val() == selv) {
                    $(this).attr("selected", true);
                }
                else {
                    $(this).removeAttr("selected");
                }
            });
        });
        $('#txtcode').change(function () {
            var selv = $('#txtcode').val();
            $("#txtcode option").each(function () {
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
    </script>
</body>
</html>
