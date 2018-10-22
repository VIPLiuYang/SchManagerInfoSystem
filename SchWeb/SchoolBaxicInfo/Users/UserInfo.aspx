<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.Users.UserInfo" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>人员信息维护</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <%--<meta name="viewport" content="width=device-width, initial-scale=1.0" />--%>

    <meta name="viewport" content="width=device-width">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>
    <style>
        
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

        h4 {
            font-size: 14px !important;
            font-weight: bold !important;
            letter-spacing: 1px !important;
        }

        .pagination {
            border-top: 1px solid #DDD;
            padding-top: 12px;
            padding-bottom: 12px;
            background-color: #eff3f8;
        }
        .page-content {
            padding:0px;
        }
        .table thead > tr > th, .table tbody > tr > td {
            text-align: center;
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
                    <div class="nav-search" id="nav-search">
                        <span id="addbtns"></span>
                    </div>
                </div>

                <div class="page-content">
                    <div style="background-color: rgb(239, 243, 248); text-align: right; padding: 6px 4px; ">

                        <span>部门:</span>
                        <select id="depsel">
                            <%=dptdrp %>
                        </select>
                        <span>姓名:</span>
                        <input type="text" id="txtname" placeholder="姓名">
                        <span style="display: none;">任教科目:</span>
                        <select id="schsubs" style="display: none;">
                            <%=schsubs %>
                        </select>
                        <span>账号状态:</span>
                        <select id="ustat">
                            <option value="">全部</option>
                            <option value="1">正常</option>
                            <option value="0">停用</option>
                            <option value="3">无账号</option>
                        </select>
                        <button class="btn btn-sm btn-info text_size" type="button" onclick="search();" style="margin-left: 10px">查询</button>




                    </div>
                    <div class="table-responsive " id="list"></div>


                    <div class="dataTables_paginate paging_bootstrap" style="background-color: rgb(239, 243, 248);  border-bottom: 1px solid #ddd;">
                        <ul id="example">
                        </ul>
                    </div>

                </div>
            </div>
        </div>
    </div>



    <!-- 模态框   打开新建修改查看人员模态框 -->
    <div class="modal fade" id="EditCfmCreateUser">
        <div class="modal-dialog" style="width: 67%; height: 90%;">
            <div class="modal-content message_align" style="width: 100%; height: 90%;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title">添加人员</h4>
                </div>
                <div class="modal-body no-padding-top no-padding-bottom" style="width: 100%; height: 90%;">

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
    <script src="../../assets/js/bootstrap-dialog.js?v=1.2"></script>
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

        if (isadd == "True") {
            var addstr = '<div class="input-group pull-right">' +
                '<div id="adminbtn" class="col-sm-8">' +
                '<a class="btn btn-link" href="javascript:adduser(2)" onclick="go();">' +
                    '<i class="icon-plus align-top bigger-125"></i>' +
                    '系统管理员' +
                '</a>' +
                '<a class="btn btn-link" href="javascript:adduser(1)" onclick="go();">' +
                    '<i class="icon-plus align-top bigger-125"></i>' +
                    '学校管理员' +
                '</a></div>' +
                '<div class="col-sm-4">' +
                '<a class="btn btn-link" href="javascript:adduser(0)" onclick="go();">' +
                    '<i class="icon-plus align-top bigger-125"></i>' +
                    '添加人员' +
                '</a></div>' +
            '</div>';
            $('#addbtns').html(addstr);
        }

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

            sessionStorage.setItem("userinfoindex", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("userinfoindex_pageindex", PageIndex);
            sessionStorage.setItem("userinfoindex_txtname", txtname);
            sessionStorage.setItem("userinfoindex_dptid", dptid);
            sessionStorage.setItem("userinfoindex_ustat", ustat);
            sessionStorage.setItem("userinfoindex_uschid", uschid);
            return false;
        };

        //页面缓存,页面是返回的
        var l = sessionStorage.getItem("userinfoindex");
        if (l != null) {
            $("#main-container").html(l);            //删除缓存
            sessionStorage.removeItem("userinfoindex");
            //取回缓存中的查询条件
            PageIndex = sessionStorage.getItem("userinfoindex_pageindex");
            txtname = sessionStorage.getItem("userinfoindex_txtname");
            dptid = sessionStorage.getItem("userinfoindex_dptid");
            ustat = sessionStorage.getItem("userinfoindex_ustat");
            uschid = sessionStorage.getItem("userinfoindex_uschid");
            sessionStorage.removeItem("userinfoindex_pageindex");
            sessionStorage.removeItem("userinfoindex_txtname");
            sessionStorage.removeItem("userinfoindex_dptid");
            sessionStorage.removeItem("userinfoindex_ustat");
            sessionStorage.removeItem("userinfoindex_uschid");
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
                url: "UserInfo.aspx/page",  //请求路径：页面/方法名字
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
            var regtelphone = /^(\d{3})\d{4}(\d{4})$/;//显示前三位和后四位
            var regtelphone2 = /^(\d{1})\d{9}(\d{1})$/;//显示第一位和最后一位
            var regtelphone3 = /^(\d{1})\d{10}$/;//显示第一位
            var i = 1;
            if (eval("(" + data + ")").list != null) {
                var str = '';
                str += '<table id="data_table" class="table table-striped table-bordered table-hover dataTable">';
                str += '<thead>';
                str += '<tr>';
                str += '<th>序号</th>';
                str += '<th>系统编号</th>';
                str += '<th>姓名</th>';
                str += '<th>性别</th>';
                str += '<th class="hidden-480">部门</th>';
                str += '<th class="hidden-480">职务</th>';
                str += '<th class="hidden-480">职称</th>';
                //str += '<th class="hidden-480">任教科目</th>';
                str += '<th class="hidden-480">电话</th>';
                str += '<th>账号</th>';
                str += '<th class="hidden-480">密码</th>';
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
                    str += '<td class="hidden-480">' + item.Postion + '</td>';
                    str += '<td class="hidden-480">' + item.Title + '</td>';
                    str += '<td class="hidden-480">' + item.Mobile + '</td>';
                    if (item.UserName != null && item.UserName.length > 0) {
                        str += '<td>' + item.UserName.substring(0, 1) + '***</td>';
                    }
                    else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.UserName != null && item.UserName.length > 0) {
                        str += '<td class="hidden-480">******</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.UserName != null && item.UserName.length > 0) {
                        str += '<td class="hidden-480">' + item.Ustat + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    str += '<td>';
                    str += '<div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">';
                    if (islook == "True") {
                        
                        str += '<a class="blue" href="javascript:showuser(' + item.UserId + ')" onclick="go();">';
                        str += '<i class="icon-zoom-in bigger-130"></i>';
                        str += '</a>';
                    }
                    if (isedit == "True") {
                        str += '<a class="green" href="javascript:updateuser(' + item.UserId + ')" onclick="go();">';
                        str += '<i class="icon-pencil bigger-130"></i>';
                        str += '</a>';
                    }
                    if (isdel == "True") {
                        str += '<a class="red" href="javascript:void()" onclick="delu(' + uschid + ',' + item.UserId + ')" >';
                        str += '<i class="icon-trash bigger-130"></i>';
                        str += '</a>';

                    }
                    str += '</div>';
                    str += '<div class="visible-xs visible-sm hidden-md hidden-lg">';
                    str += '<div class="inline position-relative">';
                    str += '<button class="btn btn-minier btn-yellow dropdown-toggle" data-toggle="dropdown">';
                    str += '<i class="icon-caret-down icon-only bigger-120"></i>';
                    str += '</button>';
                    str += '<ul class="dropdown-menu dropdown-only-icon dropdown-yellow pull-right dropdown-caret dropdown-close">';
                    if (islook == "True") {                        
                        str += '<li>';
                        str += '<a href="javascript:showuser(' + item.UserId + ')"  class="tooltip-info" data-rel="tooltip" title="查看">';
                        str += '<span class="blue">';
                        str += '<i class="icon-zoom-in bigger-120"></i>';
                        str += '</span>';
                        str += '</a>';
                        str += '</li>';
                    }
                    if (isedit == "True") {
                        str += '<li>';
                        str += '<a href="javascript:updateuser(' + item.UserId + ')" class="tooltip-success" data-rel="tooltip" onclick="go();" title="编辑">';
                        str += '<span class="green">';
                        str += '<i class="icon-edit bigger-120"></i>';
                        str += '</span>';
                        str += '</a>';
                        str += '</li>';
                    }
                    if (isdel == "True") {
                        str += '<li>';
                        str += '<a href="javascript:void();" class="tooltip-error" onclick="delu(' + uschid + ',' + item.UserId + ')" data-rel="tooltip" title="删除">';
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
                url: "UserInfo.aspx/udel",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == 'success') {
                        alert("操作成功");
                        getdata();
                    } else if (data.d == "success01") {
                        alert("已在学科组长中设置！");
                    } else if (data.d == "success02") {
                        alert("已在年级领导中设置！");
                    } else if (data.d == "success03") {
                        alert("已在班级中设置了班级教师！");
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

        function adduser(systype) {
            var vsch = $('#asch').val();
            if (vsch != null && vsch.length > 0) {
                uschid = vsch;
            }
            if (uschid == null || uschid.length < 1) {
                alert("无相应学校!");
                return;
            }
            if (systype == "0") {
                CreatUserModal(uschid, systype, "a")
            } else {
                window.location.href = "UserEdit.aspx?schid=" + uschid + "&dotype=a&systype=" + systype;
            }
        }
        function updateuser(userid) {
            //UserEdit.aspx?dotype=e&uid=' + item.UserId + '
            CreatUserModal(userid, "", "e");
        }
        function showuser(userid) {
            CreatUserModal(userid, "", "s");
        }
        // 打开新建修改查看人员模态框，函数名：showGradeEditeModal
        var rel_id = ""; var rel_gradecode = "";
        function CreatUserModal(schid, systype, ostype) {
            if (ostype == "a") {
                $("#EditCfmCreateUser .modal-title").html("添加人员");
                var url = "CreateUser.aspx?dotype=a&schid=" + schid + "&systype=" + systype;
            } else if (ostype == "e") {
                $("#EditCfmCreateUser .modal-title").html("修改人员");
                var url = "CreateUser.aspx?dotype=e&uid=" + schid + "&systype=" + systype;
            }
            else if (ostype == "s") {
                $("#EditCfmCreateUser .modal-title").html("查看人员");
                var url = "ShowUser.aspx?dotype=e&uid=" + schid + "&systype=" + systype;
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
        function showuserclose() {
            $("#ShowCfmUserModel").modal("hide");
        }
    </script>
</body>
</html>
