<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserFunAuthInfo.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.UserFunAuth.UserFunAuthInfo" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>人员信息维护</title>
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
            color: #333333;
        }
        /*坐在位置的坐边竖线*/
        .breadcrumb_border {
            border-left: 2px solid #63bbff;
            margin-left: 0px;
            padding-left: 12px;
            /*padding-top: 4px;
            padding-bottom: 4px;*/
        }
         /*位置提示字体大小*/
        .breadcrumb > li {
            font-size:13px !important;
            color:#666666 !important;
        }
        /*上边距*/
        .page-content {
            padding-top:20px;
        }
        /*表格标题栏字体大小，颜色*/
        .table thead tr th{
            color:#444444 !important;
            font-weight:bold !important;
            font-size:13px !important;
            letter-spacing:1px !important;
        }
        /*表格的内容区字体大小颜色*/
        .table tbody tr td {
            color:#666666 !important;
            font-size:13px !important;
        }
        .search {
            /*margin-right:10px;
            margin-left:10px;*/
            font-size:13px;
            color:#000000;
        }
        /*输入框  下拉选框中的字体样式*/
        input, select, textarea {
            font-size:12px;
            color:#999999;
            margin-left:10px;
            margin-right:10px;

        }
        /*输入框中的字体样式*/
       input[type="text"] {
             font-size:12px;
             color:#999999
       }
       /*查询按钮的字体大小*/
        .text_size {
            font-size:12px;
        }
        /*表格的行距*/
        .table thead > tr > th, .table tbody > tr > td {
            line-height:1.5;
            text-align:center;
        }
        .breadcrumb > li + li:before {
            content:"";
        }
        /*添加班级弹出框的顶端距离*/
        @media screen and (min-width: 768px){
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
            color: #f96161 !important ;
        }
        /*确定按钮的颜色*/
        .btn-warning{
            background-color: #428bca !important;
            border-color: #428bca;
        }
        /*确定按钮鼠标移动到上边时的颜色*/
        .btn-warning:hover {
            background-color: #1b6aaa!important;
            border-color: #428bca;
        }
        .icon-edit::before {
            content:none;
        }
          h4 { 
            font-size:14px !important;
            font-weight:bold !important;
            letter-spacing:1px !important;
        }
        .ztree li a.curSelectedNode { 
            padding-top: 0px;
            background-color: #ffffff;
            color: #000000;
            font-weight: bold;
            height: 21px;
            opacity: 0.8;
        }
        .ztree li a.curSelectedNode span:nth-child(2){
            color: #428bca;
            font-weight: bold;
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
                            目前所在位置：
                        </li>
                        
                        <li class="active">教师及账号信息 </li>
                    </ul>
                     <!-- .breadcrumb -->
                </div>

                <div class="page-content">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="col-sm-12">
                                <div class="col-sm-9">
                                    <div class="input-group pull-right search">
                                        <%=areastr %>
                                       <span> 部门:</span>
                                    <select id="depsel">
                                        <%=dptdrp %>
                                    </select> 
                                      <span>姓名:</span>
                                        <input type="text" id="txtname" placeholder="姓名"> 
                                        <span style="display:none;"> 任教科目:</span>
                                    <select id="schsubs" style="display:none;">
                                        <%=schsubs %>
                                    </select> 
                                       <span> 账号状态:</span>
                                    <select id="ustat">
                                        <option value="">全部</option>
                                        <option value="1">正常</option>
                                        <option value="0">停用</option>
                                        <option value="3">无账号</option>
                                    </select>
                                        <button class="btn btn-sm btn-info text_size" type="button" onclick="search();" style="margin-left:10px">查询</button>
                                    </div>
                                </div>
                                

                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12">
                           <%-- <hr />--%>
                            <div class="space-10"></div>
                            <div class="table-responsive " id="list"></div>

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



<!-- 模态框   打开新建班级模态框 -->
<div class="modal fade" id="EditCfmCreateUser">
    <div class="modal-dialog" style="width:70%;height:100%;">
        <div class="modal-content message_align" style="width:100%;height:90%;">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">×</span>
                </button>
                <h4 class="modal-title">添加人员</h4>
            </div>
            <div class="modal-body no-padding-top no-padding-bottom" style="width:100%;height:90%;" >
                
                <iframe id="modelCreateUser" src="" style="width:100%;height:95%;border:none"></iframe>
                
            </div>
        </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
</div>
<!-- //模态框   打开新建班级模态框 -->

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
        var isedit = '<%=isedit%>';
        var isdel = '<%=isdel%>';
        var islook = '<%=islook%>';
        var isadd = '<%=isadd%>';

        //人员分页列表,需要存储的查询条件
        var uschid = '<%=uschid%>';
        var PageIndex = 1;
        var PageSize = 10;
        var pageCount = 1;
        var txtname = '';
        var dptid = '0';
        var ustat = '';
        var schsubs = "";
        var childrenids = "";

        function go() {

            sessionStorage.setItem("userfunauthinfo", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("userfunauthinfo_pageindex", PageIndex);
            sessionStorage.setItem("userfunauthinfo_txtname", txtname);
            sessionStorage.setItem("userfunauthinfo_dptid", dptid);
            sessionStorage.setItem("userfunauthinfo_ustat", ustat);
            sessionStorage.setItem("userfunauthinfo_uschid", uschid);
            return false;
        };

        //页面缓存,页面是返回的
        var l = sessionStorage.getItem("userfunauthinfo");
        if (l != null) {
            $("#main-container").html(l);            //删除缓存
            sessionStorage.removeItem("userfunauthinfo");
            //取回缓存中的查询条件
            PageIndex = sessionStorage.getItem("userfunauthinfo_pageindex");
            txtname = sessionStorage.getItem("userfunauthinfo_txtname");
            dptid = sessionStorage.getItem("userfunauthinfo_dptid");
            ustat = sessionStorage.getItem("userfunauthinfo_ustat");
            uschid = sessionStorage.getItem("userfunauthinfo_uschid");
            sessionStorage.removeItem("userfunauthinfo_pageindex");
            sessionStorage.removeItem("userfunauthinfo_txtname");
            sessionStorage.removeItem("userfunauthinfo_dptid");
            sessionStorage.removeItem("userfunauthinfo_ustat");
            sessionStorage.removeItem("userfunauthinfo_uschid");
        }
        else {
            uschid = '<%=uschid%>';//第一次赋给ID
            var systype = '<%=systype%>';
            if (systype != '2') {
                $('#adminbtn').hide();
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
        //num代表传入的数字，n代表要保留的字符的长度  
        function PreFixInterge(num, n) {
            return (Array(n).join(0) + num).slice(-n);
        }
        //获取数据
        function getdata() {
            var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","txtname":"' + txtname + '","dptid":"' + dptid + '","ustat":"' + ustat + '","schid":"' + uschid + '","schsubs":"' + schsubs + '","childrenids":"' + childrenids + '"}';

            $.ajax({
                type: "POST",  //请求方式
                url: "UserFunAuthInfo.aspx/page",  //请求路径：页面/方法名字
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
        //num代表传入的数字，n代表要保留的字符的长度  
        function PreFixInterge(num, n) {
            return (Array(n).join(0) + num).slice(-n);
        }
        //表格生成处理
        function dodata(data) {
            var regtelphone = /^(\d{3})\d{4}(\d{4})$/;//显示前三位和后四位
            var regtelphone2 = /^(\d{1})\d{9}(\d{1})$/;//显示第一位和最后一位
            var regtelphone3 = /^(\d{1})\d{10}$/;//显示第一位
            var i = 1;
            if (eval("(" + data + ")").list != null) {
                var str = '';
                str += '<table id="data_table" class="table table-striped table-bordered table-hover">';
                str += '<thead>';
                str += '<tr>';
                str += '<th>序号</th>';
                str += '<th>系统编号</th>';
                str += '<th>姓名</th>';
                str += '<th>性别</th>';
                str += '<th class="hidden-480">部门</th>';
                str += '<th>账号</th>';
                str += '<th class="hidden-480">密码</th>';
                str += '<th class="hidden-480">权限</th>';
                str += '<th class="hidden-480">账号状态</th>';
                str += '<th>操作</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                $.each(eval("(" + data + ")").list, function (index, item) { //遍历返回的json
                    item.Mobile = item.Mobile.replace(regtelphone3, "$1***");
                    str += '<tr>';
                    str += '<td>' + i + '</td>';
                    str += '<td>' + PreFixInterge(item.UserId, 8) + '</td>';
                    str += '<td>' + item.UserTname + '</td>';
                    str += '<td>' + item.Sexn + '</td>';
                    str += '<td class="hidden-480">' + item.Dpts + '</td>';
                    if (item.UserName != null && item.UserName.length > 0)
                        str += '<td>' + item.UserName.substring(0, 1) + '***</td>';
                    else
                        str += '<td></td>';
                    if (item.UserName == "") {
                        str += '<td class="hidden-480"></td>';
                    } else {
                        str += '<td class="hidden-480">******</td>';
                    }
                    str += '<td class="hidden-480">' + item.Roles + '</td>';
                    if (item.UserName != null && item.UserName.length > 0) {
                        str += '<td class="hidden-480">' + item.Ustat + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    str += '<td>';
                    if (isedit == "True") {
                        if (item.UserName == "" && item.UserName.length <= 0) {
                            str += '<a class="glyphicon" href="javascript:void();" onclick="go();">';
                            str += '<i class="icon-pencil bigger-130" style="color:gray;"></i>';
                            str += '</a>';
                        } else {
                            str += '<a class="green" href="javascript:updateuser(' + item.UserId + ')" onclick="go();">';
                            str += '<i class="icon-pencil bigger-130"></i>';
                            str += '</a>';
                        }
                    }
                    str += '<div class="visible-xs visible-sm hidden-md hidden-lg">';
                    str += '<div class="inline position-relative">';
                    if (isedit == "True") {
                        str += '<li style="list-style-type:none;">';
                        if (item.UserName == "" && item.UserName.length <= 0) {
                            str += '<a href="javascript:javascript:void();" class="tooltip-success" data-rel="tooltip" onclick="go();" title="编辑">';
                            str += '<span class="green"></span>';
                            str += '</a>';
                        } else {
                            str += '<a href="javascript:updateuser(' + item.UserId + ')" class="tooltip-success" data-rel="tooltip" onclick="go();" title="编辑">';
                            str += '<span class="green">';
                            str += '<i class="icon-edit bigger-120"></i>';
                            str += '</span>';
                            str += '</a>';
                        }
                        str += '</li>';
                    }
                    str += '</ul>';
                    str += '</div>';
                    str += '</div>';
                    str += '</td>';
                    str += '</tr>';
                    i += 1;
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
            //uschid = $('#asch').val();
            var vsch = $('#asch').val();
            if (vsch != null && vsch.length > 0) {
                uschid = vsch;
            }
            var vschsubs = $('#schsubs').val();
            if (vschsubs != null && vschsubs.length > 0) {
                schsubs = vschsubs;
            }
            PageIndex = 1;
            PageSize = 10;
            pageCount = 1;
            txtname = $("#txtname").val();
            dptid = $("#depsel").val();
            childrenids = $("#depsel option:selected").attr("childrenids");
            ustat = $("#ustat").val();
            getdata();
        }

        $(document).ready(function () {

            getdata();
        });

        function DelRun(schid, userid) {
            var params = '{"schid":"' + schid + '","id":"' + userid + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "UserFunAuthInfo.aspx/udel",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == 'success') {
                        alert("操作成功");
                        getdata();
                    } else if (data.d == "success01") {
                        alert("以在学科组长中设置，请先删除学科组长中的相关信息！");
                    } else if (data.d == "success02") {
                        alert("以在年级领导中设置，请先删除年级领导中的相关信息！");
                    } else if (data.d == "success03") {
                        alert("以在班级信息中设置，请先删除班级信息中的相关信息！");
                    } else if (data.d == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    } else {
                        alert(data.d);
                    }
                },
                error: function (obj, msg, e) {
                }
            });

        }
        function delu(schid, userid) {
            var msg = "如果删除此信息，所有有关该账号的资料将丢失，确定要删除吗？";
            //$.showConfirm = function (str, funcok, funcclose) {
            BootstrapDialog.confirm({
                title: "提示框",
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
                        DelRun(schid, userid);// 执行方法
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
                url: "UserFunAuthInfo.aspx/getarea",  //请求路径：页面/方法名字
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
                url: "UserFunAuthInfo.aspx/getarea",  //请求路径：页面/方法名字
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
            var params = '{"typecode":"3","pcode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "UserFunAuthInfo.aspx/getarea",  //请求路径：页面/方法名字
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
        //获取部门
        $('#asch').change(function () {
            var selv = $('#asch').val();
            var params = '{"typecode":"4","pcode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "UserFunAuthInfo.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $("#asch option").each(function () {
                        if ($(this).val() == selv) {
                            $(this).attr("selected", true);
                        }
                        else {
                            $(this).removeAttr("selected");
                        }

                    });
                    var oo = eval('(' + data.d + ')');
                    $('#depsel').html(oo.dpt);
                    $('#depsel').change();
                    $('#schsubs').html(oo.sub);
                    $('#schsubs').change();
                },
                error: function (obj, msg, e) {
                }
            });
        });
        $('#depsel').change(function () {
            var selv = $('#depsel').val();
            $("#depsel option").each(function () {
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
        $('#schsubs').change(function () {
            var selv = $('#schsubs').val();
            $("#schsubs option").each(function () {
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
        // 打开新建班级模态框，函数名：showGradeEditeModal
        var rel_id = ""; var rel_gradecode = "";
        function CreatUserModal(schid, systype, ostype) {
            if (ostype == "a") {
                $("#EditCfmCreateUser .modal-title").html("添加人员");
                var url = "UserAuth.aspx?dotype=a&schid=" + schid + "&systype=" + systype;
            } else if (ostype == "e") {
                $("#EditCfmCreateUser .modal-title").html("修改人员权限");
                var url = "UserAuth.aspx?dotype=e&uid=" + schid + "&systype=" + systype;
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
