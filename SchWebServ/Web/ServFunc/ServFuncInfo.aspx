<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServFuncInfo.aspx.cs" Inherits="SchWebServ.Web.ServFunc.ServFuncInfo" %>

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
        .input_box > label { 
            color:#999999;
            font-size:13px;
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
                            目前位置：
                        </li>
                        <li class="active">业务功能管理</li>
                    </ul>
                </div>

                <div class="page-content content_box ">
                    <div class="row" id="searchbar">
                        <div class="col-xs-12">
                            <div class="col-sm-12">
                                <div class="col-sm-11">
                                    <div class="input-group pull-right">
                                        业务类型:
                                        <select id="BusinessType"></select>
                                        功能代码:<input type="text" id="txtcode" style="width:120px" placeholder="功能代码" />
                                        功能名称:<input type="text" id="txtname" style="width:120px" placeholder="功能名称" />
                                        使用范围:<input type="text" id="txtrange" style="width:120px" placeholder="使用范围" />
                                        所属业务平台:<input type="text" id="txtbusplat" style="width:120px" placeholder="所属业务平台" />
                                        <button class="btn btn-sm btn-info text_size" type="button" onclick="search();">查询</button>
                                    </div>
                                </div>
                                <div class="col-sm-1" id="schaddDom" style="text-align:right;"></div>
                                <div class="input-group pull-right">
                                    <a class="btn btn-link"  href="javascript:void();" onclick="EditCfmServSysInfo('','a')">
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
        <div class="modal-dialog" style="width: 55%; height: 70%;">
            <div class="modal-content message_align" style="width: 100%; height: 100%;">
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
        var PageIndex = 1;
        var PageSize = 10;
        var pageCount = 1;
        var txtcode = "";
        var txtname = "";
        var txtrange = "";
        var txtbusplat = "";
        var BusinessType = ""
        var schid = "";
        var businessTypeNode = <%=businessType%>;

        function go() {

            sessionStorage.setItem("servfuncinfoindex", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("servfuncinfoindex_pageindex", PageIndex);
            sessionStorage.setItem("servfuncinfoindex_pagesize", PageSize);
            sessionStorage.setItem("servfuncinfoindex_pagecount", pageCount);
            sessionStorage.setItem("servfuncinfoindex_txtcode", txtcode);
            sessionStorage.setItem("servfuncinfoindex_txtname", txtname);
            sessionStorage.setItem("servfuncinfoindex_txtrange", txtrange);
            sessionStorage.setItem("servfuncinfoindex_txtbusplat", txtbusplat);
            sessionStorage.setItem("servfuncinfoindex_businesstype", BusinessType);
            return false;
        };

        //页面缓存,页面是返回的
        var l = sessionStorage.getItem("schinfoindex");
        if (l != null) {
            $("#main-container").html(l);            //删除缓存
            sessionStorage.removeItem("servfuncinfoindex");
            //取回缓存中的查询条件
            PageIndex = sessionStorage.getItem("servfuncinfoindex_pageindex");
            PageSize = sessionStorage.getItem("servfuncinfoindex_pagesize");
            pageCount = sessionStorage.getItem("servfuncinfoindex_pagecount");
            txtcode = sessionStorage.getItem("servfuncinfoindex_txtcode");
            txtname = sessionStorage.getItem("servfuncinfoindex_txtname");
            txtrange = sessionStorage.getItem("servfuncinfoindex_txtrange");
            txtbusplat = sessionStorage.getItem("servfuncinfoindex_txtbusplat");
            BusinessType = sessionStorage.getItem("servfuncinfoindex_businesstype");
            sessionStorage.removeItem("servfuncinfoindex_pageindex");
            sessionStorage.removeItem("servfuncinfoindex_pagesize");
            sessionStorage.removeItem("servfuncinfoindex_pagecount");
            sessionStorage.removeItem("servfuncinfoindex_txtcode");
            sessionStorage.removeItem("servfuncinfoindex_txtname");
            sessionStorage.removeItem("servfuncinfoindex_txtrange");
            sessionStorage.removeItem("servfuncinfoindex_txtbusplat");
            sessionStorage.removeItem("servfuncinfoindex_businesstype");
        }
        else {
            txtschid = '<%=schid%>';//第一次赋给ID
        }
        //业务类型下拉框赋值
        var busTypeOption="<option value=\"\">请选择业务类型</option>";
        $.each(businessTypeNode, function (index, item) {
            busTypeOption +="<option value=\""+item.TypeCode+"\">"+item.TypeName+"</option>";
        })
        $("#BusinessType").html(busTypeOption);
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

            var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","txtname":"' + txtname + '","BusinessType":"' + BusinessType + '","txtcode":"' + txtcode + '","txtrange":"' + txtrange + '","txtbusplat":"' + txtbusplat + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "ServFuncInfo.aspx/page",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
                        alert(data.d.msg);
                        window.location.href = "../../LoginExc.aspx";
                    }else if(data.d.code=="excepError"){
                        alert(data.d.msg);
                    }else {
                        dodata(eval("("+data.d.RspData+")"));
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
                str += '<table id="data_table" class="table table-striped table-bordered table-hover">';
                str += '<thead>';
                str += '<tr>';
                str += '<th class="center">业务类型</th>';
                str += '<th class="hidden-480">功能代码</th>';
                str += '<th class="hidden-480">功能名称</th>';
                str += '<th class="hidden-480">使用范围</th>';
                str += '<th class="hidden-480">附加设置信息（说明）</th>';
                str += '<th class="hidden-480">业务功能描述</th>';
                str += '<th class="hidden-480">所属业务平台</th>';
                str += '<th class="hidden-480">备注</th>';
                str += '<th>操作</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                var i = 1;
                $.each(data.list, function (index, item) { //遍历返回的json
                    str += '<tr>';
                    if(item.TypeName){
                        str += '<td class="center">' + item.TypeName + '</td>';
                    }else{
                        str += '<td class="center"></td>';
                    }
                    if(item.FuncCode){
                        str += '<td class="hidden-480">' + item.FuncCode + '</td>';
                    }else{
                        str += '<td class="hidden-480"></td>';
                    }
                    if(item.FuncName){
                        str += '<td class="hidden-480">' + item.FuncName + '</td>';
                    }else{
                        str += '<td class="hidden-480"></td>';
                    }
                    if(item.FuncRange){
                        str += '<td class="hidden-480">' + item.FuncRange + '</td>';
                    }else{
                        str += '<td class="hidden-480"></td>';
                    }
                    if(item.FuncSet){
                        str += '<td class="hidden-480" title="' + item.FuncSet + '">' + (item.FuncSet == null ? '' : (item.FuncSet.length > 10 ? item.FuncSet.substr(0, 10) + '...' : item.FuncSet)) + '</td>';
                    }else{
                        str += '<td class="hidden-480"></td>';
                    }

                    str += '<td title="' + item.FuncDes + '">' + (item.FuncDes == null ? '' : (item.FuncDes.length > 10 ? item.FuncDes.substr(0, 10) + '...' : item.FuncDes)) + '</td>';

                    str += '<td class="hidden-480">' + item.FuncSyssName + '</td>';

                    str += '<td class="hidden-480" title="' + item.FuncNote + '">' + (item.FuncNote == null ? '' : (item.FuncNote.length > 10 ? item.FuncNote.substr(0, 10) + '...' : item.FuncNote)) + '</td>';

                    str += '<td>';

                    str += '<div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">';
                    
                    str += '<a class="green" href="javascript:void();" onclick="EditCfmServSysInfo(\''+item.AutoId+'\',\'\e\')">';
                    str += '编辑';
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
                    str += '                <a title="编辑" href="javascript:void();" onclick="EditCfmServSysInfo(\'' + item.AutoId + '\',\'\e\')" class="tooltip-success" data-rel="tooltip">';
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
            txtcode = $('#txtcode').val();
            txtrange = $('#txtrange').val();
            txtbusplat = $('#txtbusplat').val();
            BusinessType = $("#BusinessType").val();
            
            ustat = $('#ustat').val();
            
            getdata();
        }
        $(document).ready(function () { getdata(); });
        

        //业务平台信息模态框
        function EditCfmServSysInfo(obj, dotype) {

            var modeltitle = "";
            var ifrurl = "";
            if (dotype == "a") {
                modeltitle = "新建业务功能";
                ifrurl = "ServFuncAdd.aspx?dotype=" + dotype + "&schid=" + schid;
            } else if (dotype == "e") {
                modeltitle = "修改业务功能";
                ifrurl = "ServFuncEdit.aspx?dotype=" + dotype + "&id=" + obj + "&schid=" + schid;
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