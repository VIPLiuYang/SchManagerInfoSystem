<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="SchWebMaster.Web.SchNews.NewsList" %>

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
           font-size:13px;
           color:#000000;
        }
        /*输入框字体的颜色*/
        input[type="text"] {
            color:#999999;
            font-size:12px;
        }
        /*表格标题栏颜色*/
        .table.table-bordered thead tr th {
            font-size:13px !important;
            color:#444444;
            text-align:center;
            line-height: 1.5
        }
        /*表格内容区颜色*/
        .table.table-bordered tbody tr td {
            font-size:13px !important;
            color:#666666;
            text-align:center;
            line-height: 1.5
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
                        <li class="active">电子班牌/新闻列表</li>
                    </ul>
                </div>

                <div class="page-content content_box ">
                    <div class="row" id="searchbar">
                        <div class="col-xs-12">
                            <div class="col-sm-12">
                                <div class="col-sm-9">
                                    <div class="input-group pull-right">
                                        栏目名称:<input type="text" id="txtname" placeholder="栏目名称">
                                        栏目代码:<input type="text" id="txtcode" placeholder="栏目代码">
                                        状态:
                                    <select id="ustat">
                                        <option value="">全部</option>
                                        <option value="1">正常</option>
                                        <option value="0">停用</option>
                                    </select>
                                        <button class="btn btn-sm btn-info text_size" type="button" onclick="search();">查询</button>
                                    </div>
                                </div>
                                <div class="col-sm-3" id="schaddDom" style="text-align:right;"><a href="NewsAdd.aspx">添加</a></div>
                                
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
    <!-- 模态框   打开新建修改查看人员模态框 -->
<div class="modal fade" id="EditCfm">
    <div class="modal-dialog" style="width:45%;height:50%;">
        <div class="modal-content message_align" style="width:100%;height:100%;">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">×</span>
                </button>
                <h4 class="modal-title">添加栏目</h4>
            </div>
            <div class="modal-body no-padding-top no-padding-bottom" style="width:100%;height:85%;" >
                
                <iframe id="modelEdit" src="" style="width:100%;height:95%;border:none"></iframe>
                
            </div>
        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
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
        var txtcode = '';
        var ustat = '';
        function go() {

            sessionStorage.setItem("schchnindex", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("schchnindex_pageindex", PageIndex);
            sessionStorage.setItem("schchnindex_txtname", txtname);
            sessionStorage.setItem("schchnindex_ustat", ustat);
            sessionStorage.setItem("schchnindex_txtcode", txtcode);
            return false;
        };

        //页面缓存,页面是返回的
        var l = sessionStorage.getItem("schchnindex");
        if (l != null) {
            $("#main-container").html(l);            //删除缓存
            sessionStorage.removeItem("schchnindex");
            //取回缓存中的查询条件
            PageIndex = sessionStorage.getItem("schchnindex_pageindex");
            txtname = sessionStorage.getItem("schchnindex_txtname");
            ustat = sessionStorage.getItem("schchnindex_ustat");
            txtcode = sessionStorage.getItem("schchnindex_txtcode");
            sessionStorage.removeItem("schchnindex_pageindex");
            sessionStorage.removeItem("schchnindex_txtname");
            sessionStorage.removeItem("schchnindex_ustat");
            sessionStorage.removeItem("schchnindex_txtcode");
        }
        else {
            txtcode = '';//第一次赋给ID
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

            var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","txtname":"' + txtname + '","ustat":"' + ustat + '","txtcode":"' + txtcode + '"}';
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
                str += '<table id="data_table" class="table table-striped table-bordered table-hover">';
                str += '<thead>';
                str += '<tr>';
                str += '<th class="center">序号</th>';
                str += '<th class="hidden-480">栏目</th>';
                str += '<th>标题</th>';
                str += '<th class="hidden-480">时间</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                var i = 1;
                $.each(data.list, function (index, item) { //遍历返回的json

                    str += '<tr>';
                    str += '<td class="center">' + i + '</td>';
                    str += '<td class="hidden-480">' + item.ChnId + '</td>';
                    str += '<td title="' + item.Topic + '">' + (item.Topic == null ? '' : (item.Topic.length > 10 ? item.Topic.substr(0, 10) + '...' : item.Topic)) + '</td>';
                    str += '<td class="hidden-480">' + item.RecTime + '</td>';
                    
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
            aprovserch = $('#aprov').val();
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
        function DelRun(id) {
            var params = '{"id":"' + id + '"}';
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
        function updateuser(userid) {
            //UserEdit.aspx?dotype=e&uid=' + item.UserId + '
            CreatUserModal(userid, "", "e");
        }
        // 打开新建修改查看人员模态框，函数名：showGradeEditeModal
        var rel_id = ""; var rel_gradecode = "";
        function CreatUserModal(id, systype, ostype) {
            if (ostype == "a") {
                $("#EditCfm .modal-title").html("启用停用子系统");
                var url = "SchSubEdit.aspx?dotype=a&id=" + id + "&systype=" + systype;
            } else if (ostype == "e") {
                $("#EditCfm .modal-title").html("启用停用子系统");
                var url = "SchSubEdit.aspx?dotype=e&id=" + id + "&systype=" + systype;
            }
            else if (ostype == "s") {
                $("#EditCfm .modal-title").html("查看人员");
                var url = "ShowUser.aspx?dotype=e&id=" + id + "&systype=" + systype;
            }
            $("#modelEdit").attr("src", url);
            $("#EditCfm").modal({
                backdrop: 'static',
                keyboard: false
            });
        }
        $(function () {
            $('#EditCfm').on('hide.bs.modal',
            function () {
                getdata();
            })
        });
        function createuserclose() {
            $("#EditCfm").modal("hide");
        }
    </script>
</body>
</html>
