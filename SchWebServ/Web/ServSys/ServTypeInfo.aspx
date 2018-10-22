<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServTypeInfo.aspx.cs" Inherits="SchWebServ.Web.ServSys.ServTypeInfo" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title> </title>
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
           body {
            font-family:微软雅黑;
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
                <div class="page-content content_box ">
                    <div class="row" id="searchbar">
                        <div class="col-xs-12">
                            <div class="col-sm-12">
                                <div class="col-sm-11">
                                    
                                </div>
                                <div class="col-sm-1" id="schaddDom" style="text-align:right;"></div>
                                <div class="input-group pull-right">
                                    <a class="btn btn-link" href="javascript:void();" onclick="EditCfmServType('','a')">
                                        <i class="icon-plus align-top bigger-125"></i>添加
                                    </a>
                                </div>
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

    <!-- 模态框：业务平台--模态框 -->
    <div class="modal fade" id="EditCfmServType">
        <div class="modal-dialog" style="width: 30%; height: 60%;">
            <div class="modal-content message_align" style="width: 100%; height: 90%;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title title-style"></h4>
                </div>
                <div class="modal-body no-padding-top " style="width: 100%; height: 87%;">

                    <iframe id="IfrServSysInfo" src="" style="width: 100%; height: 100%; border: none"></iframe>

                </div>
            </div>
        </div>
    </div>
    <!-- //模态框：业务平台--模态框 -->

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
        var schid = '';
        var ustat = '';
        var txtschid = "";

        function go() {

            sessionStorage.setItem("schinfoindex", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("schinfoindex_pageindex", PageIndex);
            sessionStorage.setItem("schinfoindex_txtname", txtname);
            sessionStorage.setItem("schinfoindex_ustat", ustat);
            sessionStorage.setItem("schinfoindex_txtschid", txtschid);
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
            ustat = sessionStorage.getItem("schinfoindex_ustat");
            txtschid = sessionStorage.getItem("schinfoindex_txtschid");
            sessionStorage.removeItem("schinfoindex_pageindex");
            sessionStorage.removeItem("schinfoindex_txtname");
            sessionStorage.removeItem("schinfoindex_ustat");
            sessionStorage.removeItem("schinfoindex_txtschid");
        }
        else {
            txtschid = '<%=schid%>';//第一次赋给ID
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
        getdata();
        //获取数据
        function getdata() {
            var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","txtname":"' + txtname + '","ustat":"' + ustat + '","schid":"' + txtschid + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "ServTypeInfo.aspx/page",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
                        alert(data.d.msg);
                        window.location.href = "../../LoginExc.aspx";
                    } else {
                        dodata(eval("("+data.d.RspData+")"));
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
                str += '<th class="center">类型代码</th>';
                str += '<th class="center">业务类型名称</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                var i = 1;
                $.each(data.list, function (index, item) { //遍历返回的json
                    str += '<tr>';
                    str += '<td class="center">' + item.TypeCode + '</td>';
                    str += '<td class="center">' + item.TypeName + '</td>';
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


        //业务平台信息模态框
        function EditCfmServType(obj, dotype) {
            //$("html,body").addClass("ban_body")
            //$("#EditCfmSuberGraderClasser").show(100);

            //var selv = $("#asch").val();
            //if (typeof (selv) == "undefined") { selv = schid; }
            var modeltitle = "";
            var ifrurl = "";
            if (dotype == "a") {
                modeltitle = "新建业务类型";
                ifrurl = "ServTypeAdd.aspx?dotype=" + dotype + "&schid=" + schid;
            }
            //if (urltype == "suber") {//科目组长
            //    modeltitle = "年级组长设置";
            //    ifrurl = "SchSubLeadEdit.aspx?dotype=" + dotype + "&schid=" + selv + "&subid=" + gradecode;
            //} else if (urltype == "grader") {//年级领导
            //    modeltitle = "年级组长设置";
            //    ifrurl = "SchGradeEdit.aspx?dotype=" + dotype + "&schid=" + selv + "&gradeid=" + gradecode;
            //} else if (urltype == "classer") {//班级（班主任及任课教师）
            //    modeltitle = "班级任课设置";
            //    if (gradecode == "") {//添加班级
            //        //gradecode = $("#schgradeSearch").val();
            //        //var url = "SubLeaderEdit.aspx?dotype=" + dotype + "&schid=" + selv + "&gradecode=" + gradecode + "&classid=" + classid;
            //    } else {//编辑班级
            //        ifrurl = "../GradeClassSet/SchClassE.aspx?dotype=" + dotype + "&schid=" + schid + "&gradecode=" + gradecode + "&classid=" + classid;
            //    }
            //}
            $("#EditCfmServType .title-style").html(modeltitle);
            $("#IfrServSysInfo").attr("src", ifrurl);
            $("#EditCfmServType").modal({
                backdrop: 'static',
                keyboard: false
            });
        }
        $(function () {
            $('#EditCfmServType').on('hide.bs.modal',
            function () {
                getdata();
            })
        });
        //关闭模态框
        function closeEditCfmmodel() {
            $("#EditCfmServType").modal("hide");
        }
    </script>
</body>
</html>
