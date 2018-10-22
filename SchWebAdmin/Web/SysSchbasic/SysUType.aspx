<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysUType.aspx.cs" Inherits="SchWebAdmin.Web.SysSchbasic.SysUType" %>
 
 
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
                .modal-body {
        padding:0px;
        }
    </style>
</head>

<body>
    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>
        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
              
                <div class="page-content">
                    <div style="background-color: rgb(239, 243, 248);text-align: right; padding: 6px 4px;">
                        <a class="btn btn-link" href="javascript:update('0','a')">
                            <i class="icon-plus align-top bigger-125"></i>添加
                        </a>
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
       <!-- 模态框   打开新建修改查看人员模态框 -->
    <div class="modal fade" id="EditCfmCreate">
        <div class="modal-dialog" style="width: 50%; height: 100%;">
            <div class="modal-content message_align" style="width: 70%; height: 90%;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title"></h4>
                </div>
                <div class="modal-body no-padding-top no-padding-bottom" style="width: 100%; height: 90%;">

                    <iframe id="modelCreate" src="" style="width: 100%; height: 90%; overflow: auto; border: none"></iframe>

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
    <script type="text/javascript">

        //人员分页列表
        var PageIndex = 1;
        var PageSize = 10;
        var pageCount = 1;
        window.onload = function () {
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
        };


        function update(autoid, dotype) {
            if (dotype == 1) {
                dotype = 'e';
            }
            if (dotype == 'a') {
                autoid = 0;
            }
            CreatModal(autoid, dotype);
        }
        // 打开新建修改查看人员模态框，函数名：showGradeEditeModal
        var rel_id = ""; var rel_gradecode = "";
        function CreatModal(autoid, systype) {
            $("#EditCfmCreate .modal-title").html("添加/修改");
            var url = "SysUTypeDialog.aspx?autoid=" + autoid + "&systype=" + systype;
            $("#modelCreate").attr("src", url);
            $("#EditCfmCreate").modal({
                backdrop: 'static',
                keyboard: false
            });
        }
        function createuserclose() {
            $("#EditCfmCreate").modal("hide");
            getdata();
        }
        //获取数据
        function getdata() {

            var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SysUType.aspx/page",  //请求路径：页面/方法名字
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

        //表格生成处理
        function dodata(data) {
            if (data.list != null) {

                var str = '';
                str += '<table id="data_table" class="table table-striped table-bordered table-hover dataTable">';
                str += '<thead>';
                str += '<tr>';
                str += ' <th class="center">序号</th>';
                str += ' <th class="center">编码</th>';
                str += ' <th>名称</th>';
                str += ' <th class="hidden-480">状态</th>'
                str += ' <th>操作</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                var i = 0;
                $.each(data.list, function (index, item) { //遍历返回的json 
                    i++;

                    str += '<tr>';
                    str += '<td class="center">' + i + '</td>';
                    str += '<td class="center">' + item.UTypeCode + '</td>';
                    str += '<td>' + item.UTypeName + '</td>';
                    if (item.Stat == "1") {
                        str += '<td class="hidden-480">正常</td>';
                    } else if (item.Stat == "0") {
                        str += '<td class="hidden-480">停用</td>';
                    }
                    str += '<td>';
                    str += "<a   href ='javascript:update(" + item.AutoId + ",1)' title='编辑'>";
                    str += "<span class='blue'><i class='icon-edit bigger-120'></i></span></a> &nbsp;";
                    //str += "<a href='javascript:delSysFasc(" + item.AutoId + "," + item.SubCode + ")' class='tooltip-error' data-rel='tooltip' title='删除'>";
                    //str += "<span class='red'> <i class='icon-trash bigger-120'></i></span> </a>";
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
    </script>
</body>
</html>
