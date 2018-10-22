<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchInfo.aspx.cs" Inherits="SchWebMaster.Web.School.SchInfo" %>

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
           font-size:14px;
           color:#000000;
        }
        /*输入框字体的颜色*/
        input[type="text"] {
            color:#999999;
            font-size:12px;
        }
        /*表格标题栏颜色*/
        .table.table-bordered thead tr th {
            font-size:14px !important;
            color:#444444;
            text-align:center;
        }
        /*表格内容区颜色*/
        .table.table-bordered tbody tr td {
            font-size:13px !important;
            color:#888888;
            text-align:center;
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
                        <li class="active">学校列表</li>
                    </ul>
                </div>

                <div class="page-content content_box ">
                    <div class="row" id="searchbar">
                        <div class="col-xs-12">
                            <div class="col-sm-12">
                                <div class="col-sm-9">
                                    <div class="input-group pull-right">
                                        <%=areastr %>状态:
                                    <select id="ustat">
                                        <option value="">全部</option>
                                        <option value="1">正常</option>
                                        <option value="0">停用</option>
                                    </select>学校名称:<input type="text" id="txtname" placeholder="学校名称">
                                        <button class="btn btn-sm btn-info text_size" type="button" onclick="search();">查询</button>
                                    </div>
                                </div>
                                <div class="col-sm-3" id="schaddDom" style="text-align:right;"></div>
                                <script>
                                    var isadd = '<%=isadd%>';
                                    var schadd = "";
                                    if (isadd) {
                                        //schadd += '<div class="col-sm-3">' +
                                        schadd += '<div class="input-group pull-right">' +
                                                                                '<a class="btn btn-link" href="SchEdit.aspx?dotype=a" onclick="go();">' +
                                                                                    '<i class="icon-plus align-top bigger-125"></i>' +
                                                                                    '新建学校' +
                                                                                '</a>' +
                                                                            '</div>';
                                        //                               ' </div>';
                                        document.getElementById("schaddDom").innerHTML = schadd;
                                    }
                                </script>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                           <%-- <hr />--%>
                            <div class="space-10"></div>
                            <div class="table-responsive" id="list"></div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                        </div>
                        <div class="col-sm-6">
                            <div class="dataTables_paginate paging_bootstrap">
                                <ul id="example">
                                </ul>
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
        var cotycode = '0';
        var ustat = '';
        
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
            sessionStorage.setItem("schinfoindex_uschid", schid);
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
            schid = sessionStorage.getItem("schinfoindex_uschid");
            sessionStorage.removeItem("schinfoindex_pageindex");
            sessionStorage.removeItem("schinfoindex_txtname");
            sessionStorage.removeItem("schinfoindex_cotycode");
            sessionStorage.removeItem("schinfoindex_ustat");
            sessionStorage.removeItem("schinfoindex_uschid");
        }
        else {
            schid = '<%=schid%>';//第一次赋给ID
            cotycode = '<%=cotycode%>';
            if (cotycode == '') {
                $('#searchbar').hide()
            }
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

            var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","txtname":"' + txtname + '","ustat":"' + ustat + '","cotycode":"' + cotycode + '","schid":"' + schid + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SchInfo.aspx/page",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    } else {
                        dodata(data.d);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        };
        //表格生成处理
        function dodata(data) {
            if (eval("(" + data + ")").list != null) {
                var str = '';
                str += '<table id="data_table" class="table table-striped table-bordered table-hover">';
                str += '<thead>';
                str += '<tr>';
                str += '<th class="center"><input type="checkbox" class="ace" /><span class="lbl"></span></th>';
                str += '<th>学校名称</th>';
                str += '<th>学校电话</th>';
                str += '<th class="hidden-480">学校地址</th>';
                str += '<th class="hidden-480">是否城区</th>';
                str += '<th class="hidden-480">状态</th>';
                str += '<th>操作</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                $.each(eval("(" + data + ")").list, function (index, item) { //遍历返回的json

                    str += '<tr>';
                    str += '<td class="center"><label><input type="checkbox" class="ace" /><span class="lbl"></span></label></td>';
                    str += '<td>' + item.SchName + '</td>';
                    str += '<td>' + item.SchTel + '</td>';
                    str += '<td class="hidden-480">' + item.SchAddr + '</td>';
                    str += '<td class="hidden-480">' + item.Ucity + '</td>';
                    str += '<td class="hidden-480">' + item.Ustat + '</td>';

                    str += '<td>';

                    str += '<div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">';
                    if (islook == 'True') {
                        str += '<a class="blue" href="SchShow.aspx?dotype=e&schid=' + item.SchId + '">';
                        str += '<i class="icon-zoom-in bigger-130"></i>';
                        str += '</a>';
                    }
                    if (isedit == 'True') {
                        str += '<a class="green" href="SchEdit.aspx?dotype=e&schid=' + item.SchId + '" onclick="go();">';
                        str += '<i class="icon-pencil bigger-130"></i>';
                        str += '</a>';
                    }
                    if (isdel == 'True') {
                        str += '<a class="red" href="#" onclick="delu(' + item.SchId + ')" >';
                        str += '<i class="icon-trash bigger-130"></i>';
                        str += '</a>';
                    }
                    str += '</div>';

                    str += '<div class="visible-xs visible-sm hidden-md hidden-lg">';
                    str += '<div class="inline position-relative">';
                    str += '<button class="btn btn-minier btn-yellow dropdown-toggle" data-toggle="dropdown">';
                    str += '<i class="icon-caret-down icon-only bigger-120"></i>';
                    str += '</button>';
                    if (islook == 'True') {
                        str += '<ul class="dropdown-menu dropdown-only-icon dropdown-yellow pull-right dropdown-caret dropdown-close">';
                        str += '<li>';
                        str += '<a href="#" class="tooltip-info" data-rel="tooltip" title="查看">';
                        str += '<span class="blue">';
                        str += '<i class="icon-zoom-in bigger-120"></i>';
                        str += '</span>';
                        str += '</a>';
                        str += '</li>';
                    }

                    if (isedit == 'True') {
                        str += '<li>';
                        str += '<a href="SchEdit.aspx?dotype=e&schid=' + item.SchId + '" class="tooltip-success" data-rel="tooltip" title="编辑" onclick="go();">';
                        str += '<span class="green">';
                        str += '<i class="icon-edit bigger-120"></i>';
                        str += '</span>';
                        str += '</a>';
                        str += '</li>';
                    }
                    if (isdel == 'True') {
                        str += '<li>';
                        str += '<a href="#" class="tooltip-error" onclick="delu(' + item.SchId + ')" data-rel="tooltip" title="删除">';
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
            if ($('#acoty').val()) {
                cotycode = $('#acoty').val();
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
                url: "SchInfo.aspx/udel",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == 'success') {
                        alert("操作成功");
                        getdata();
                    } else if (data.d == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    }
                    else {
                        alert(data.d);
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
            var params = '{"typecode":"1","pcode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "../Users/UserInfo.aspx/getarea",  //请求路径：页面/方法名字
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
                url: "../Users/UserInfo.aspx/getarea",  //请求路径：页面/方法名字
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
                }
            });
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
    </script>
</body>
</html>
