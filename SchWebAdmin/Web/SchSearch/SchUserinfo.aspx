<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchUserinfo.aspx.cs" Inherits="SchWebAdmin.Web.SchSearch.SchUserinfo" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title></title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />

    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/metrodpt.css" />
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
            min-height: 32px;
            line-height: 30px;
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
            font-size: 13px !important;
            color: #666666 !important;
        }
        /*上边距*/
        .page-content {
            padding-top: 20px;
        }
        /*表格标题栏字体大小，颜色*/
        .table thead tr th {
            color: #444444 !important;
            font-weight: bold !important;
            font-size: 13px !important;
            letter-spacing: 1px !important;
        }
        /*表格的内容区字体大小颜色*/
        .table tbody tr td {
            color: #666666 !important;
            font-size: 13px !important;
        }

        body {
            background-color: transparent;
            overflow: -Scroll;
            overflow-x: hidden;
        }

        .search {
            margin-right: 10px;
            margin-left: 10px;
            font-size: 13px;
            color: #000000;
        }
        /*输入框  下拉选框中的字体样式*/
        input, select, textarea {
            font-size: 12px;
            color: #999999;
        }
            /*输入框中的字体样式*/
            input[type="text"] {
                font-size: 12px;
                color: #999999;
            }
        /*查询按钮的字体大小*/
        .text_size {
            font-size: 12px;
        }
        /*表格的行距*/
        .table thead > tr > th, .table tbody > tr > td {
            line-height: 1.5;
            text-align: center;
        }

        .breadcrumb > li + li:before {
            content: "";
        }

        .search span {
            margin-left: 10px;
            margin-right: 10px;
        }
    </style>
</head>
<body>
    <div class="main-container" id="main-container">
        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="col-sm-12">
                            <div class="col-sm-9">
                                <div class="input-group pull-right search">
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
                            </div>
                            <div class="col-sm-3" id="addbtns"></div>

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <%-- <hr />--%>
                        <div class="space-10"></div>
                        <div class="table-responsive " id="Userlist"></div>

                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                    </div>
                    <div class="col-sm-6">
                        <div class="dataTables_paginate paging_bootstrap">
                            <ul id="Userexample">
                            </ul>
                        </div>
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
    <script type="text/javascript">
        window.jQuery || document.write("<script src='../../assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
    </script>
    <script src="../../assets/js/bootstrap.min.js"></script>
    <script src="../../assets/js/typeahead-bs2.min.js"></script>
    <link href="../../assets/css/bootstrap-dialog.css" rel="stylesheet" />
    <script src="../../assets/js/bootstrap-dialog.js"></script>
    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>
    <script src="../../assets/js/bootstrap-paginator.js"></script>
    <script src="../../assets/js/jquery.ztree.all-3.5.min.js"></script>
    <script type="text/javascript">
        var PageIndex = 1;
        var PageSize = 20;
        var pageCount = 1;
        var schid = '<%=schid%>';
        var txtname = '';
        var dptid = '0';
        var ustat = '';
        var schsubs = "";
        var childrenids = "";
        window.onload = function () {
            getdata();
        }
        function search() {
            //uschid = $('#asch').val();
            //var vsch = $('#asch').val();
            //if (vsch != null && vsch.length > 0) {
            //    uschid = vsch;
            //}
            //var vschsubs = $('#schsubs').val();
            //if (vschsubs != null && vschsubs.length > 0) {
            //    schsubs = vschsubs;
            //}
            PageIndex = 1;
            PageSize = 20;
            pageCount = 1;
            txtname = $("#txtname").val();
            dptid = $("#depsel").val();
            childrenids = $("#depsel option:selected").attr("childrenids");
            ustat = $("#ustat").val();
            getdata();
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

            var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","SchId":"' + schid + '","txtname":"' + txtname + '","dptid":"' + dptid + '","ustat":"' + ustat + '","schsubs":"' + schsubs + '","childrenids":"' + childrenids + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SchUserinfo.aspx/pageuser",  //请求路径：页面/方法名字
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
        //获取教师账号及权限信息
        function dodata(data) {
            var regtelphone = /^(\d{3})\d{4}(\d{4})$/;//显示前三位和后四位
            var regtelphone2 = /^(\d{1})\d{9}(\d{1})$/;//显示第一位和最后一位
            var regtelphone3 = /^(\d{1})\d{10}$/;//显示第一位
            var i = 1;
            if (data.list != null) {
                var str = '';
                str += '<table id="data_table" class="table table-striped table-bordered table-hover">';
                str += '<thead>';
                str += '<tr>';
                str += '<th>序号</th>';
                str += '<th>系统编号</th>';
                str += '<th>姓名</th>';
                str += '<th>性别</th>';
                str += '<th class="hidden-480">部门</th>';
                str += '<th class="hidden-480">职务</th>';
                str += '<th class="hidden-480">职称</th>';
                str += '<th class="hidden-480">电话</th>';
                str += '<th>账号</th>';
                str += '<th class="hidden-480">权限</th>';
                str += '<th class="hidden-480">账号状态</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                $.each(data.list, function (index, item) { //遍历返回的json
                    str += '<tr>';
                    str += '<td>' + i + '</td>';
                    str += '<td>' + PreFixInterge(item.UserId, 8) + '</td>';
                    str += '<td>' + item.UserTname + '</td>';
                    str += '<td>' + item.Sexn + '</td>';
                    str += '<td class="hidden-480">' + item.Dpts + '</td>';
                    if (item.Postion) {
                        str += '<td class="hidden-480">' + item.Postion + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.Title) {
                        str += '<td class="hidden-480">' + item.Title + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.Mobile) {
                        str += '<td class="hidden-480">' + item.Mobile + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.UserName != null && item.UserName.length > 0)
                        str += '<td>' + item.UserName.substring(0, 1) + '***</td>';
                    else
                        str += '<td></td>';
                    if (item.Roles) {
                        str += '<td class="hidden-480">' + item.Roles + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.UserName != null && item.UserName.length > 0) {
                        str += '<td class="hidden-480">' + item.Ustat + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    str += '</tr>';
                    i += 1;
                });
                str += '</tbody>';
                str += '</table>';
                $('#Userlist').empty();
                $('#Userlist').append(str);
                pageCount = data.PageCount; //取到pageCount的值(把返回数据转成object类型)
                PageIndex = data.PageIndex; //得到urrentPage
                options.currentPage = PageIndex;
                options.totalPages = pageCount;
                $('#Userexample').bootstrapPaginator(options);

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
                $('#Userlist').empty();
                $('#Userlist').append("暂无数据!");
                $('#Userexample').empty();
            }


        }
    </script>
</body>
</html>
