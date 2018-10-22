<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServSysInfo.aspx.cs" Inherits="SchWebServ.Web.ServSys.ServSysInfo" %>

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
                                    <a class="btn btn-link" href="javascript:void();" onclick="EditCfmServSysInfo('','a')">
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
    <div class="modal fade" id="EditCfmServSysInfo">
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

            sessionStorage.setItem("servsysinfoindex", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("servsysinfoindex_pageindex", PageIndex);
            sessionStorage.setItem("servsysinfoindex_pagesize", PageSize);
            sessionStorage.setItem("servsysinfoindex_pagecount", pageCount);
            sessionStorage.setItem("servsysinfoindex_txtname", txtname);
            sessionStorage.setItem("servsysinfoindex_ustat", ustat);
            sessionStorage.setItem("servsysinfoindex_txtschid", txtschid);
            return false;
        };

        //页面缓存,页面是返回的
        var l = sessionStorage.getItem("servsysinfoindex");
        if (l != null) {
            $("#main-container").html(l);            //删除缓存
            sessionStorage.removeItem("servsysinfoindex");
            //取回缓存中的查询条件
            PageIndex = sessionStorage.getItem("servsysinfoindex_pageindex");
            PageSize = sessionStorage.getItem("servsysinfoindex_pagesize");
            pageCount = sessionStorage.getItem("servsysinfoindex_pagecount");
            txtname = sessionStorage.getItem("servsysinfoindex_txtname");
            ustat = sessionStorage.getItem("servsysinfoindex_ustat");
            txtschid = sessionStorage.getItem("servsysinfoindex_txtschid");
            sessionStorage.removeItem("servsysinfoindex_pageindex");
            sessionStorage.removeItem("servsysinfoindex_txtname");
            sessionStorage.removeItem("servsysinfoindex_ustat");
            sessionStorage.removeItem("servsysinfoindex_txtschid");
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
                url: "ServSysInfo.aspx/page",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
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
                str += '<th class="center">平台代码</th>';
                str += '<th class="center hidden-480">平台类型</th>';
                str += '<th class="center hidden-480" >平台域名</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                $.each(data.list, function (index, item) { //遍历返回的json
                    str += '<tr>';
                    if (item.SysCode) {
                        str += '<td class="center">' + item.SysCode + '</td>';
                    } else {
                        str += '<td></td>';
                    }
                    if (item.SysName) {
                        str += '<td class="center hidden-400">' + item.SysName + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.SysUrl) { 
                        item.SysUrl = item.SysUrl.replace(/[^\x00-\xff]/g, "$&\x01").replace(/.{150}\x01?/g, "$&\n").replace(/\x01/g, ""); 
                        str += '<td   class="hidden-480" " title="' + item.SysUrl + '">' + item.SysUrl + '</td>'; 
                    }else{
                        str += '<td class="hidden-480"></td>';
                    }
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

                //$('table th input:checkbox').on('click', function () {
                //    var that = this;
                //    $(this).closest('table').find('tr > td:first-child input:checkbox')
                //    .each(function () {
                //        this.checked = that.checked;
                //        $(this).closest('tr').toggleClass('selected');
                //    });

                //});
            }
            else {
                $('#list').empty();
                $('#list').append("暂无数据!");
                $('#example').empty();
            }
        };
        

        //业务平台信息模态框
        function EditCfmServSysInfo(obj, dotype) {
            
            var modeltitle = "";
            var ifrurl = "";
            if (dotype == "a") {
                modeltitle = "新建平台类型";
                ifrurl = "ServSysAdd.aspx?dotype=" + dotype + "&schid=" + schid;
            }
            
            $("#EditCfmServSysInfo .title-style").html(modeltitle);
            $("#IfrServSysInfo").attr("src", ifrurl);
            $("#EditCfmServSysInfo").modal({
                backdrop: 'static',
                keyboard: false
            });
        }
        $(function () {
            $('#EditCfmServSysInfo').on('hide.bs.modal',
            function () {
                getdata();
            })
        });
        //关闭模态框
        function closeEditCfmmodel() {
            $("#EditCfmServSysInfo").modal("hide");
        }
    </script>
</body>
</html>
