<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserOrderSearch.aspx.cs" Inherits="SchWebServ.Web.UserOrderInfo.UserOrderSearch" %> 


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
            min-height: 32px;
            line-height: 30px;
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
            font-size: 13px !important;
            color: #666666 !important;
        }
        /*内容上边距*/
        .content_box {
            padding-top: 24px;
        }
        /*输入框和下拉选框的间距*/
        select, input {
            font-size: 12px;
            margin-left: 10px;
            margin-right: 10px;
            color: #999999;
        }
        /*搜索栏的字体颜色*/
        .input-group {
            font-size: 13px;
            color: #000000;
        }
        /*输入框字体的颜色*/
        input[type="text"] {
            color: #999999;
            font-size: 12px;
        }
        /*表格标题栏颜色*/
        .table.table-bordered thead tr th {
            font-size: 13px !important;
            color: #444444;
            text-align: center;
            line-height: 1.5;
        }
        /*表格内容区颜色*/
        .table.table-bordered tbody tr td {
            font-size: 13px !important;
            color: #666666;
            text-align: center;
            line-height: 1.5;
        }

        /*input中placeholder的颜色*/
        input::-webkit-input-placeholder, textarea::-webkit-input-placeholder { /* WebKit*/
            color: #999999;
            font-size: 12px;
        }

        input:-moz-placeholder, textarea:-moz-placeholder { /* Mozilla Firefox 4 to 18 */
            color: #999999;
            font-size: 12px;
        }

        input::-moz-placeholder, textarea::-moz-placeholder { /* Mozilla Firefox 19+ */
            color: #999999;
            font-size: 12px;
        }

        input:-ms-input-placeholder, textarea:-ms-input-placeholder { /* IE 10+ */
            color: #999999;
            font-size: 12px;
        }
        /*按钮的字体大小*/
        .text_size {
            font-size: 12px;
        }

        .breadcrumb > li + li:before {
            content: "";
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
                        <li class="active">用户订购信息>用户订购信息明细</li>
                    </ul>
                </div>

                <div class="page-content content_box ">
                    <div class="row" id="searchbar">
                        <div class="col-xs-12">
                            <div class="col-sm-12">
                                <div class="col-sm-9">
                                    <div class="input-group pull-right">
                                        账号:<input type="text" id="UserName" placeholder="请输入账号">
                                      
                              
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
    <div class="modal fade" id="EditCfmServBus">
        <div class="modal-dialog" style="width: 50%; height: 90%;">
            <div class="modal-content message_align" style="width: 100%; height: 60%;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title">新建资费套 </h4>
                </div>
                <div class="modal-body no-padding-top no-padding-bottom" style="width: 100%; height: 85%;">

                    <iframe id="modelServBus" src="" style="width: 100%; height: 95%; border: none"></iframe>

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
        var UserName = ''; 
      
        //function go() {

        //    sessionStorage.setItem("ServPackage", $("#main-container").html()); //存储列表数据
        //    //缓存查询条件
        //    sessionStorage.setItem("ServPackage_pageindex", PageIndex);
        //    sessionStorage.setItem("ServPackage_ServiceId", ServiceId);
        //    sessionStorage.setItem("ServPackage_CnName", CnName);
        //    sessionStorage.setItem("ServPackage_FeeCode", FeeCode);
        //    sessionStorage.setItem("ServPackage_BusMonth", BusMonth);
        //    return false;
        //};

        //页面缓存,页面是返回的
        //var l = sessionStorage.getItem("ServPackage");
        //if (l != null) {
        //    $("#main-container").html(l);            //删除缓存
        //    sessionStorage.removeItem("ServPackage");
        //    //取回缓存中的查询条件
        //    PageIndex = sessionStorage.getItem("ServPackage_pageindex");
        //    ServiceId = sessionStorage.getItem("ServPackage_ServiceId");
        //    CnName = sessionStorage.getItem("ServPackage_CnName");
        //    FeeCode = sessionStorage.getItem("ServPackage_FeeCode");
        //    BusMonth = sessionStorage.getItem("ServPackage_BusMonth");
        //    sessionStorage.removeItem("ServPackage_pageindex");
        //    sessionStorage.removeItem("ServPackage_ServiceId");
        //    sessionStorage.removeItem("ServPackage_CnName");
        //    sessionStorage.removeItem("ServPackage_FeeCode");
        //    sessionStorage.removeItem("ServPackage_BusMonth");
        //}
        //else {
           
        //    //if (cotycode == '') {
        //    //    $('#searchbar').hide()
        //    //}
        //}

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
        function search() {
            PageIndex = 1;
            PageSize = 10;
            pageCount = 1;
            UserName = $('#UserName').val();
            getdata();
        }
        //获取数据
        function getdata() {

            var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","UserName":"' + UserName + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "UserOrderSearch.aspx/page",  //请求路径：页面/方法名字
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
                var ii = "e";
                var str = '';
                str += '<table id="data_table" class="table table-striped table-bordered table-hover">';
                str += '<thead>';
                str += '<tr>';
                str += '<th class="center">账号</th>';
                //str += '<th class="center">账号类型</th>';
                str += '<th class="center">姓名</th>';
                str += '<th class="center">归属(省)</th>';
                str += '<th class="center">归属(市)</th>';
                str += '<th class="center">用户来源</th>';
                //str += '<th class="center">来源附加</th>';
                str += '<th class="center">订购套餐</th>';
                //str += '<th class="center">套餐资费</th>';
                str += '<th class="center">缴费金额</th>';
                str += '<th class="center">订购时长</th>';
                //str += '<th class="center">行为</th>'; 
                str += '<th class="center">操作时间</th>';
                str += '<th>备注</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                $.each(eval("(" + data + ")").list, function (index, item) { //遍历返回的json 
                    str += '<tr>';
                    str += '<td class="center">' + item.UserName + '</td>';
                    //str += '<td class="center">' + item.FromType + '</td>';
                    str += '<td class="center">' + item.RecUser + '</td>';
                    str += '<td class="center">' + item.SHENG + '</td>';
                    str += '<td class="center">' + item.SHI + '</td>';
                    str += '<td class="center">' + item.FromType + '</td>';
                    str += '<td class="center">' + item.CnName + '</td>';
                    str += '<td class="center">' + item.FeeM + '</td>';
                    str += '<td class="center">' + item.TServMonth + '</td>';
                    str += '<td class="center">' + item.EditTime + '</td>';
                    str += '<td class="center">' + item.DoNote + '</td>'; 
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

        $(document).ready(function () { getdata(); });

        ////业务平台信息模态框
        //function EditCfmServBus(obj, dotype) {
        //    go();
        //    var modeltitle = "";
        //    var ifrurl = "";
        //    if (dotype == "a") {
        //        modeltitle = "新建资费套餐";
        //        ifrurl = "ServBusAdd.aspx?dotype=" + dotype;
        //    }
        //    if (dotype == undefined) {
        //        modeltitle = "编辑资费套餐";
        //        ifrurl = "ServBusEdit.aspx?dotype=" + dotype + "&BusId=" + obj;
        //    }
        //    $("#EditCfmServBus .modal-title").html(modeltitle);
        //    $("#modelServBus").attr("src", ifrurl);
        //    $("#EditCfmServBus").modal({
        //        backdrop: 'static',
        //        keyboard: false
        //    });
        //}
        $(function () {
            $('#EditCfmServBus').on('hide.bs.modal',
            function () {
                getdata();
            })
        });
        function createuserclose() {
            $("#EditCfmServBus").modal("hide");
        }


    </script>
</body>
</html>
