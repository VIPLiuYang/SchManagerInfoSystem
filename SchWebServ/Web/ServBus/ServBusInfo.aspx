<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServBusInfo.aspx.cs" Inherits="SchWebServ.Web.ServBus.ServBusInfo" %>


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
           body {
            font-family:微软雅黑;
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
                            目前位置：
                        </li>
                        <li class="active">资费套餐管理</li>
                    </ul>
                   
               
                </div>

                <div class="page-content content_box ">
                    <div class="row" id="searchbar">
                        <div class="col-xs-12">
                            <div class="col-sm-12">
                                <div class="col-sm-9">
                                    <div class="input-group pull-right">
                                        套餐代码:<input type="text" id="ServiceId" placeholder="请输入套餐代码">
                                        套餐名:
                                        <select id="CnName">
                                            
                                        </select>
                                        资费:
                                    <select id="FeeCode">
                                        
                                    </select>
                                        资费时长:
                                    <select id="BusMonth">
                                        <option value="">全部</option>
                                        <option value="1">一个月</option>
                                        <option value="2">二个月</option>
                                        <option value="3">三个月</option>
                                        <option value="4">四个月</option>
                                        <option value="5">五个月</option>
                                        <option value="6">半年</option>
                                        <option value="7">七个月</option>
                                        <option value="8">八个月</option>
                                        <option value="9">九个月</option>
                                        <option value="10">十个月</option>
                                        <option value="11">十一个月</option>
                                        <option value="12">一年</option>
                                    </select>
                                        <button class="btn btn-sm btn-info text_size" type="button" onclick="search();">查询</button>
                                    </div>
                                </div>
                                <div class="col-sm-3" id="schaddDom" style="text-align: right;"></div>
                                <div class="input-group pull-right">
                                    <a class="btn btn-link" href="javascript:void();" onclick="EditCfmServBus('','a')">
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
        var ServiceId = '';//套餐代码
        var schid = '0';//学校id
        var CnName = '';//套餐名称
        var FeeCode = '';//资费
        var BusMonth = ""; //资费时长 
        var Pricnnamefeecode = <%=cnnamefeecode%>;
        //业务类型下拉框赋值
        var CnNameOption="<option value=\"\">请选择套餐名称</option>";
        $.each(Pricnnamefeecode, function (index, item) {
            CnNameOption +="<option value=\""+item.CnName+"\">"+item.CnName+"</option>";
        })
        $("#CnName").html(CnNameOption);
        var FeeCodeOption="<option value=\"\">请选择资费金额</option>";
        $.each(Pricnnamefeecode, function (index, item) {
            FeeCodeOption +="<option value=\""+item.FeeCode+"\">"+item.FeeCode+"</option>";
        })
        $("#FeeCode").html(FeeCodeOption);
        function go() {

            sessionStorage.setItem("ServPackage", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("ServPackage_pageindex", PageIndex);
            sessionStorage.setItem("ServPackage_ServiceId", ServiceId);
            sessionStorage.setItem("ServPackage_CnName", CnName);
            sessionStorage.setItem("ServPackage_FeeCode", FeeCode);
            sessionStorage.setItem("ServPackage_BusMonth", BusMonth);
            return false;
        };

        //页面缓存,页面是返回的
        var l = sessionStorage.getItem("ServPackage");
        if (l != null) {
            $("#main-container").html(l);            //删除缓存
            sessionStorage.removeItem("ServPackage");
            //取回缓存中的查询条件
            PageIndex = sessionStorage.getItem("ServPackage_pageindex");
            ServiceId = sessionStorage.getItem("ServPackage_ServiceId");
            CnName = sessionStorage.getItem("ServPackage_CnName");
            FeeCode = sessionStorage.getItem("ServPackage_FeeCode");
            BusMonth = sessionStorage.getItem("ServPackage_BusMonth");
            sessionStorage.removeItem("ServPackage_pageindex");
            sessionStorage.removeItem("ServPackage_ServiceId");
            sessionStorage.removeItem("ServPackage_CnName");
            sessionStorage.removeItem("ServPackage_FeeCode");
            sessionStorage.removeItem("ServPackage_BusMonth");
        }
        else {
            schid = '<%=schid%>';//第一次赋给ID 
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
        function search() {
            PageIndex = 1;
            PageSize = 10;
            pageCount = 1;
            ServiceId = $('#ServiceId').val();
            CnName = $("#CnName").val();
            FeeCode = $('#FeeCode').val();
            var TBusMonth = document.getElementById("BusMonth");//资费时长
            BusMonth = TBusMonth.value;
            getdata();
        }
        //获取数据
        function getdata() {

            var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","ServiceId":"' + ServiceId + '","CnName":"' + CnName + '","FeeCode":"' + FeeCode + '","BusMonth":"' + BusMonth + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "ServBusInfo.aspx/page",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
                        alert(data.d.msg);
                        window.location.href = "../../LoginExc.aspx";
                    } else {
                        dodata(eval('(' + data.d.RspData + ')'));
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        };

        //表格生成处理
        function dodata(data) {
            if (data.list != null) {
                var ii = "e";
                var str = '';
                str += '<table id="data_table" class="table table-striped table-bordered table-hover">';
                str += '<thead>';
                str += '<tr>';
                str += '<th class="center">套餐代码</th>';
                str += '<th class="center">套餐图片</th>';
                str += '<th class="center">套餐名称</th>';
                str += '<th class="center">业务类型</th>';
                str += '<th class="center">资费(元)</th>';
                str += '<th class="center">资费时长</th>';
                str += '<th class="center">提供业务功能</th>';
                str += '<th class="center">功能描述</th>';
                str += '<th class="center">备注</th>';
                str += '<th class="center">所在省</th>';
                str += '<th class="center">所在市</th>';
                str += '<th class="center">系统显示名称</th>';
                str += '<th class="center">套餐类型</th>';
                str += '<th>操作</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                $.each(data.list, function (index, item) { //遍历返回的json 
                    if(item.FrmType=="0"){
                        item.Province="";item.City="";
                    }
                    str += '<tr>';
                    str += '<td class="center">' + item.ServiceId + '</td>';
                    if (item.BusUrl != "") {
                        str += '<td class="hidden-480">有</td>';
                    } else {
                        str += '<td class="hidden-480">无</td>';
                    }

                    str += '<td class="center">' + item.CnName + '</td>';
                    str += '<td class="center">' + item.TBusType + '</td>';
                    str += '<td class="center">' + item.FeeCode + '</td>';
                    str += '<td class="center">' + item.TBusMonth + '</td>';
                    str += '<td class="center">' + item.TServFuncName + '</td>';
                    str += '<td class="hidden-480" title="' + item.BusNote + '">' + (item.BusNote == null ? '' : (item.BusNote.length > 4 ? item.BusNote.substr(0, 4) + '...' : item.BusNote)) + '</td>';
                    str += '<td class="hidden-480" title="' + item.Note + '">' + (item.Note == null ? '' : (item.Note.length > 4 ? item.Note.substr(0, 4) + '...' : item.Note)) + '</td>';
                    str += '<td class="center">' + item.Province + '</td>';
                    str += '<td class="center">' + item.City + '</td>';
                    if(item.CapName){
                        str += '<td class="center">' + item.CapName + '</td>';
                    }else{
                        str += '<td class="center"></td>';
                    }
                    if(item.FrmType=="0"){
                        str += '<td class="center">本系统套餐类型</td>';
                    }else{
                        str += '<td class="center">第三方套餐类型</td>';
                    }
                    str += '<td>';
                    str += '<div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">';
                    str += '<a class="green" href="javascript:EditCfmServBus(' + item.BusId + ')" onclick="go();">';
                    str += '<i class="icon-pencil bigger-130"></i>';
                    str += '</a>';
                    str += '</div>';

                    str += '<div class="visible-xs visible-sm hidden-md hidden-lg">';
                    str += '    <div class="inline position-relative">';
                    str += '        <button class="btn btn-minier btn-yellow dropdown-toggle" data-toggle="dropdown">';
                    str += '            <i class="icon-caret-down icon-only bigger-120"></i>';
                    str += '        </button>';
                    str += '        <ul class="dropdown-menu dropdown-only-icon dropdown-yellow pull-right dropdown-caret dropdown-close">';
                    //str += '          <li>';
                    //str += '              <a title="查看" href="#" class="tooltip-info" data-rel="tooltip">';
                    //str += '                  <span class="blue">';
                    //str += '                      <i class="icon-zoom-in bigger-120"></i>';
                    //str += '                  </span>';
                    //str += '              </a>';
                    //str += '          </li>';
                    str += '            <li>';
                    str += '                <a title="编辑" href="javascript:EditCfmServBus(' + item.BusId + ')" class="tooltip-success" data-rel="tooltip" onclick="go();>';
                    str += '                    <span class="green">';
                    str += '                        编辑';
                    str += '                    </span>';
                    str += '                </a>';
                    str += '            </li>';
                    //str += '          <li>';
                    //str += '              <a title="删除" href="#" class="tooltip-error" data-rel="tooltip">';
                    //str += '                  <span class="red">';
                    //str += '                      <i class="icon-trash bigger-120"></i>';
                    //str += '                  </span>';
                    //str += '              </a>';
                    //str += '          </li>';
                    str += '        </ul>';
                    str += '    </div>';
                    str += '</div>';
                    
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
      
        $(document).ready(function () { getdata(); });

        //业务平台信息模态框
        function EditCfmServBus(obj, dotype) {
            go();
            var modeltitle = "";
            var ifrurl = "";
            if (dotype == "a") {
                modeltitle = "新建资费套餐";
                ifrurl = "ServBusAdd.aspx?dotype=" + dotype;
            }
            if (dotype == undefined) {
                modeltitle = "编辑资费套餐";
                ifrurl = "ServBusEdit.aspx?dotype=" + dotype + "&BusId=" + obj;
            }
            $("#EditCfmServBus .modal-title").html(modeltitle);
            $("#modelServBus").attr("src", ifrurl);
            $("#EditCfmServBus").modal({
                backdrop: 'static',
                keyboard: false
            });
        }
        $(function () {
            $('#EditCfmServBus').on('hide.bs.modal',
            function () {
                getdata();
            })
        });
        function createuserclose() {
            $("#EditCfmServBus").modal("hide");
            getdata();
        }


    </script>
</body>
</html>
