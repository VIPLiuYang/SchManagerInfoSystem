<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetUserInfo.aspx.cs" Inherits="SchWebServ.Web.UserOrderInfo.GetUserInfo" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>Bootstrap表单组件金视野系统模板</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="../../assets/css/chosen.css" />
    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/bootstrap-select.css">
    <link rel="stylesheet" href="../../assets/css/metro.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>
    <style type="text/css">
        #SelectBtn {
            background-color: #33CCFF;
            color: #fff;
            font-size: 14px;
            padding: 4px;
            margin:0px auto;
            text-align: center;
            width: 68px;
            cursor: pointer;
        }
         /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }

        i {
            font-family: FontAwesome !important;
        }
        #txttel {
            padding: 5px;
            margin: 0px;
            float: left;
        }
        .btn-info, .btn-info:focus {
            background-color: #33ccff!important;
            border-color: #33ccff;
            padding: 1px;
            margin-left: 5px;
            float: left;
        }
        .pagination > li.active > a, .pagination > li.active > a:hover {
            background-color: #33ccff;
            border-color: #33ccff;
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
                    <div class="row">
                        <div class="col-xs-12">
                            <input type="text" id="txttel" placeholder="手机号码" />
                            <button class="btn btn-sm btn-info text_size" type="button" onclick="search()">查询</button>
                            <div class="clearfix"></div>
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
                        <div class="col-sm-6"></div>
                        <div class="col-sm-6">
                            <div class="dataTables_paginate paging_bootstrap">
                                <ul id="example"></ul>
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
            <script src="../../assets/js/jquery-ui-1.10.3.custom.min.js"></script>
            <script src="../../assets/js/jquery.ui.touch-punch.min.js"></script>
            <script src="../../assets/js/ace-elements.min.js"></script>
            <script src="../../assets/js/ace.min.js"></script>
            <script src="../../assets/js/bootstrap-select.js"></script>
            <script src="../../assets/js/bootstrap-tagsinput.js"></script>
            <script src="../../assets/js/jquery.ztree.all-3.5.min.js"></script>
            <script src="../../assets/js/i18n/defaults-zh_CN.min.js"></script>
            <script src="../../assets/js/learunui-validator.js"></script>
            <script src="../../assets/js/bootbox.min.js"></script>
            <script src="../../assets/js/bootstrap-paginator.js"></script>

            <script type="text/javascript">
                //變量聲明區域
                var PageIndex = 1;
                var PageSize = 10;
                var pageCount = 1;
                var ustat = "";
                var txttel = "";

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
                    var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","ustat":"' + ustat + '","txttel":"' + txttel + '"}';
                    $.ajax({
                        type: "POST",  //请求方式
                        url: "GetUserInfo.aspx/page",  //请求路径：页面/方法名字
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
                function search() {
                    PageIndex = 1;
                    PageSize = 10;
                    pageCount = 1;
                    txttel = $("#txttel").val();
                    
                    getdata();
                }
                //表格生成处理
                function dodata(data) {
                    if (data.list != null) {
                        var str = '';
                        str += '<table id="data_table" class="table table-striped table-bordered table-hover">';
                        str += '<thead>';
                        str += '<tr>';
                        str += '<th class="center">手机号码</th>';
                        str += '<th class="center hidden-480">姓名</th>';
                        str += '<th class="center hidden-480">操作</th>';
                        str += '</tr>';
                        str += '</thead>';
                        str += '<tbody>';
                        $.each(data.list, function (index, item) { //遍历返回的json
                            str += '<tr>';
                            if (item.UserName) {
                                str += '<td class="center">' + item.UserName + '</td>';
                            } else {
                                str += '<td></td>';
                            }
                            if (item.UTname) {
                                str += '<td class="center hidden-480">' + item.UTname + '</td>';
                            } else {
                                str += '<td class="hidden-480"></td>';
                            }
                            str += '<td class="hidden-480"><div class="SelectBtn" id="SelectBtn" uname="' + item.UserName + '" utname="' + item.UTname + '" uareano="' + item.Uareano + '">选择</div></td>';
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
                    }
                    else {
                        $('#list').empty();
                        $('#list').append("暂无数据!");
                        $('#example').empty();
                    }
                };
                //選擇按鈕觸發事件
                $(document).on("click","#SelectBtn",function(){
                    window.parent.selectuserinfo($(this).attr("uname"), $(this).attr("utname"), $(this).attr("uareano"));
                })
            </script>
       </div>
    </div>
</body>
</html>
