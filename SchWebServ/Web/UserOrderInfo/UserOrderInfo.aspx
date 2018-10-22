<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserOrderInfo.aspx.cs" Inherits="SchWebServ.Web.UserOrderInfo.UserOrderInfo" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>用户订购信息列表</title>
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
    <style type="text/css">
        #searchbar input, #searchbar select {
            margin:10px auto 10px auto;
        }
        #schaddDom a.btn {
            height: 96px;
            vertical-align: bottom;
            display: table-cell;
        }
        #data_table tbody tr td {
            padding:0px;margin:0px;line-height:60px;
        }
        #data_table tbody tr td .action-buttons {
            text-align: center;
        } 
        
         /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }

        i {
            font-family: FontAwesome !important;
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
         .input-group-addon {
            height: 25px;
            padding: 0px 3px;
        }
    </style>
</head>
<body ontouchstart>
    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>

        <div class="main-container-inner">
            <div class="breadcrumbs breadcrumb_box" id="breadcrumbs">
                    <script type="text/javascript">
                        try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
                    </script>

                  

                     <ul class="breadcrumb breadcrumb_border">
                        <li>
                            目前位置：
                        </li>
                        <li class="active">用户订购信息</li>
                    </ul>
                </div>
            <div class="main-content" style="margin-left: 0px">
                <div class="page-content content_box ">
                    <div class="row" id="searchbar">
                            <div class="col-sm-12">
                                <div class="col-sm-10">


                                    账号&#160; <input type="text" style="width:140px" id="txtAccount" placeholder="请输入账号" />&#8195;&#8195;
                                    姓名&#160; <input type="text" style="width:140px"  id="txtUserTname" placeholder="请输入姓名" />&#8195;&#8195;
                                    归属(省)&#160; 
                                        <select id="txtProvince">
                                            <%=province %>
                                        </select>&#8195;&nbsp;&nbsp;
                                    归属(市)&#160; 
                                        <select id="txtCity">
                                            <%=city %>
                                        </select>&#8195;&nbsp;&nbsp;
                                    <!--用户类型&#160; <input type="text" id="txtUserType" />&#8195;-->
                                    用户来源&#160; <input style="width:140px"  type="text" id="txtSource" />&#8195;
                                    <!--
                                    来源附加&#160; 
                                        <select id="txtAdditional">
                                            <option>dsfsd</option><option>dsfsd</option><option>dsfsd</option><option>dsfsd</option>
                                        </select>&#8195;
                                    -->
                                    套餐名&#160; 
                                        <select id="txtPackage">
                                            <option>dsfsd</option><option>dsfsd</option><option>dsfsd</option><option>dsfsd</option>
                                        </select>&#8195;
                                    <span style="display:inline-block" >
                                    状态&#160; 
                                        <select id="txtStat">
                                            <option value="">状态</option><option value="1">正常</option><option value="0">禁用</option>
                                        </select>&#8195;&nbsp;&nbsp; </span>
                                 <span style="display:inline-block" >
                                    订购时间
                                     
                                    <input class="date-picker" id="txtStartTime01" style="cursor:pointer" type="text" data-date-format="yyyy-mm-dd" />
                                     
                                     </span>

                                    &#8195;至&#8195;
                                    <input class="date-picker" id="txtStartTime02" style="cursor:pointer" type="text" data-date-format="yyyy-mm-dd" />
                                    &#8195;
                                    结束时间&#160; 
                                    <input class="date-picker" id="txtEndTime01" style="cursor:pointer" type="text" data-date-format="yyyy-mm-dd" />
                                    &#8195;至&#8195;
                                    <input class="date-picker" id="txtEndTime02" style="cursor:pointer" type="text" data-date-format="yyyy-mm-dd" />
                                    &#8195;
                                        <button class="btn btn-sm btn-info text_size" type="button" onclick="search();">查询</button>
                                </div>
                                <div class="col-sm-2" id="schaddDom" style="text-align:right;">
                                    <div class="input-group pull-right">
                                        <a class="btn btn-link" href="javascript:void();" onclick="EditCfmInfo('','a','')">
                                            <i class="icon-plus align-top bigger-125"></i>添加
                                        </a>
                                        <a class="btn btn-link" href="OperationRecord.aspx">
                                            <i class="icon-plus align-top bigger-125"></i>操作记录
                                        </a>
                                    </div>
                                </div>
                            </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12">
                            <div class="space-10"></div>
                            <div class="table-responsive" id="list"></div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6"></div>
                        <div class="col-sm-6">
                            <div class="dataTables_paginate paging_bootstrap">
                                <ul id="example" class="pagination pull-right no-margin"></ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- 模态框：--模态框 -->
    <div class="modal fade" id="EditCfmInfoDom">
        <div class="modal-dialog" id="EditCfmInfoE" style="width: 70%; height: 65%;">
            <div class="modal-content message_align" style="width: 100%; height: 100%;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title title-style"></h4>
                </div>
                <div class="modal-body no-padding-top " style="width: 100%; height: 87%;">

                    <iframe id="IfrSrcInfo" src="" style="width: 100%; height: 100%; border: none"></iframe>

                </div>
            </div>
        </div>
    </div>
    <!-- //模态框：--模态框 -->

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
    <script src="../../assets/js/i18n/defaults-zh_CN.min.js"></script>
    <script src="../../assets/js/date-time/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="../../assets/css/datepicker.css" />


    <script type="text/javascript">
        //公共变量声明区域
        var schid = "";
        var PageIndex = 1;
        var PageSize = 10;
        var pageCount = 1;

        //下列是定义检索条件之使用变量
        var txtAccount = "";//账号
        var txtUserTname = "";//姓名
        var txtProvince = "";//省部
        var txtCity = "";//城市
        var txtUserType = "";//用户类型
        var txtAdditional = "";//来源附加
        var txtPackage = "";//套餐名称
        var txtStat = "";//状态
        var txtSource = "";//来源
        var txtStartTime01 = "";
        var txtStartTime02 = "";
        var txtEndTime01 = "";
        var txtEndTime02 = "";
        var ServBusJson = <%=ServBusJson%>;

        //业务平台信息模态框
        function EditCfmInfo(obj, dotype,recid) {

            var modeltitle = "";
            var ifrurl = "";
            if (dotype == "a") {
                modeltitle = "新建订购信息";
                $("#EditCfmInfoE").attr("style", "width: 70%; height: 65%;"); ;
                ifrurl = "UserOrderAdd.aspx?dotype=" + dotype + "&schid=" + schid;
            } else if (dotype == "e") {
                modeltitle = "修改订购信息";
                $("#EditCfmInfoE").attr("style", "width: 30%; height: 45%;"); ;
                ifrurl = "UserOrderEdit.aspx?dotype=" + dotype + "&id=" + recid + "&schid=" + schid;
            } else if (dotype == "details") {
                modeltitle = "查看订购详情";
                $("#EditCfmInfoE").attr("style", "width: 70%; height: 55%;"); ;
                ifrurl = "UserOrderDetails.aspx?dotype=" + dotype + "&id=" + recid + "&schid=" + schid;
            } else if (dotype == "renewals") {
                modeltitle = "续费";
                $("#EditCfmInfoE").attr("style", "width: 70%; height: 55%;"); ;
                ifrurl = "UserOrderRenewals.aspx?dotype=" + dotype + "&id=" + recid + "&schid=" + schid;
            }

            $("#EditCfmInfoDom .title-style").html(modeltitle);
            $("#IfrSrcInfo").attr("src", ifrurl);
            $("#EditCfmInfoDom").modal({
                backdrop: 'static',
                keyboard: false
            });
        }
        $(function () {
            $('#EditCfmInfoDom').on('hide.bs.modal',
            function () {
                getdata();
            })
        });
        //关闭模态框
        function closeEditCfmmodel() {
            $("#EditCfmInfoDom").modal("hide");
            getdata();
        }

        //单击文本框，显示下拉日期控件
        $('.date-picker').datepicker({
            language: 'cn',
            format: "yyyy-mm-dd hh:ii:ss",
            autoclose: true,
            todayHighlight: true
            //startDate: new Date()
        });
        //$('.date-picker').next().on(ace.click_event, function () {
        //    $(this).prev().focus();
        //});
        var servbusOption = "<option value=\"\">套餐名</option>";
        $.each(ServBusJson, function (index, item) { 
            servbusOption +="<option value=\""+item.ServiceId+"\">"+item.CnName+"</option>";
        })
        $("#txtPackage").html(servbusOption);
    </script>
    <script type="text/javascript">
        function search() {
            txtAccount = $("#txtAccount").val();//账号
            txtUserTname = $("#txtUserTname").val();//姓名
            txtProvince = $("#txtProvince").val();//省部
            txtCity = $("#txtCity").val();//城市
            txtSource = $("#txtSource").val();//来源
            txtUserType = $("#txtUserType").val();//用户类型
            txtAdditional = $("#txtAdditional").val();//来源附加
            txtPackage = $("#txtPackage").val();//套餐名称
            txtStat = $("#txtStat").val();//状态
            txtStartTime01 = $("#txtStartTime01").val();
            txtStartTime02 = $("#txtStartTime02").val();
            txtEndTime01 = $("#txtEndTime01").val();
            txtEndTime02 = $("#txtEndTime02").val();

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
        getdata();
        //获取数据
        function getdata() {
            //var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '"}';
            var datasave = [];
            datasave.push("PageIndex#" + PageIndex);
            datasave.push("PageSize#" + PageSize);
            datasave.push("txtAccount#" + txtAccount);
            datasave.push("txtUserTname#" + txtUserTname);
            datasave.push("txtProvince#" + txtProvince);
            datasave.push("txtCity#" + txtCity);
            datasave.push("txtUserType#" + txtUserType);
            datasave.push("txtAdditional#" + txtAdditional);
            datasave.push("txtPackage#" + txtPackage);
            datasave.push("txtSource#" + txtSource);
            datasave.push("txtStat#" + txtStat);
            datasave.push("txtStartTime01#" + txtStartTime01);
            datasave.push("txtStartTime02#" + txtStartTime02);
            datasave.push("txtEndTime01#" + txtEndTime01);
            datasave.push("txtEndTime02#" + txtEndTime02);

            $.ajax({
                type: "POST",  //请求方式
                url: "UserOrderInfo.aspx/page",  //请求路径：页面/方法名字
                data: JSON.stringify({ arr: datasave }),     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
                        alert(data.d.msg);
                        window.location.href = "../../LoginExc.aspx";
                    }else if(data.d.code == "excepError"){
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
                str += '<th class="center">账号</th>';
                str += '<th class="center">姓名</th>';
                str += '<th class="center hidden-480">归属（省)</th>';
                str += '<th class="center hidden-480">归属（市)</th>';
                str += '<th class="center hidden-480">用户来源</th>';
                str += '<th class="center hidden-480">来源附加</th>';
                str += '<th class="center hidden-480">订购套餐</th>';
                str += '<th class="center hidden-480">订购金额</th>';
                str += '<th class="center hidden-480">订购时长</th>';
                str += '<th class="center hidden-480">订购时间</th>';
                str += '<th class="center hidden-480">结束时间</th>';
                str += '<th class="center hidden-480">状态</th>';
                str += '<th class="center hidden-480">修改时间</th>';
                str += '<th class="center hidden-480">变动记录</th>';
                str += '<th class="center hidden-480">备注</th>';
                str += '<th class="center">操作</th>';
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
                        str += '<td class="center">' + item.UTname + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.Province) {
                        str += '<td class="center hidden-480">' + item.Province + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.City) {
                        str += '<td class="center hidden-480">' + item.City + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.FromType) {
                        str += '<td class="center hidden-480">' + item.FromType + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.RecUser) {
                        str += '<td class="center hidden-480">' + item.RecUser + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.CnName) {
                        str += '<td class="center hidden-480">' + item.CnName + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.FeeM) {
                        str += '<td class="center hidden-480">' + item.FeeM + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.ServMonth) {
                        str += '<td class="center hidden-480">' + item.ServMonth + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.RecTime) {
                        str += '<td class="center hidden-480">' + item.RecTime.substring(0, 10) + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.EndTime) {
                        str += '<td class="center hidden-480">' + item.EndTime.substring(0,10) + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    if (item.ServStat==1) {
                        str += '<td class="center hidden-480">正常</td>';
                    } else {
                        str += '<td class="center hidden-480">禁用</td>';
                    }
                    if (item.EditTime) {
                        str += '<td class="center hidden-480">' + item.EditTime.substring(0, 10) + '</td>';
                    } else {
                        str += '<td class="hidden-480"></td>';
                    }
                    str += '<td></td>';
                    str += '<td class="hidden-480" title="' + item.DoNote + '">' + (item.DoNote == null ? '' : (item.DoNote.length > 4 ? item.DoNote.substr(0, 4) + '...' : item.DoNote)) + '</td>';
                    
                    str += '<td>';
                    str += '<div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">';
                    str += '    <a class="blue" href="javascript:void();" onclick="EditCfmInfo(\'\',\'e\',\'' + item.AutoId + '\')">';
                    str += '        修改';
                    str += '    </a>';
                    str += '    <a class="green" href="javascript:void();" onclick="EditCfmInfo(\'\',\'details\',\'' + item.AutoId + '\')">';
                    str += '        详情';
                    str += '    </a>';
                    str += '    <a class="red" href="javascript:void();" onclick="EditCfmInfo(\'\',\'renewals\',\'' + item.AutoId + '\')">';
                    str += '        续费';
                    str += '    </a>';
                    str += '</div>';
                    str += '<div class="visible-xs visible-sm hidden-md hidden-lg">';
                    str += '    <div class="inline position-relative">';
                    str += '        <button class="btn btn-minier btn-yellow dropdown-toggle" data-toggle="dropdown">';
                    str += '            <i class="icon-caret-down icon-only bigger-120"></i>';
                    str += '        </button>';
                    str += '        <ul class="dropdown-menu dropdown-only-icon dropdown-yellow pull-right dropdown-caret dropdown-close">';
                    str += '            <li>';
                    str += '                <a href="javascript:void();" onclick="EditCfmInfo(\'\',\'e\',\'' + item.AutoId + '\')" class="tooltip-info" data-rel="tooltip" title="修改">';
                    str += '                    <span class="blue">';
                    str += '                        修改';
                    str += '                    </span>';
                    str += '                </a>';
                    str += '            </li>';
                    str += '            <li>';
                    str += '                <a href="javascript:void();" onclick="EditCfmInfo(\'\',\'details\',\'' + item.AutoId + '\')" class="tooltip-success" data-rel="tooltip" title="详情">';
                    str += '                    <span class="green">';
                    str += '                        详情';
                    str += '                    </span>';
                    str += '                </a>';
                    str += '            </li>';
                    str += '            <li>';
                    str += '                <a href="javascript:void();" onclick="EditCfmInfo(\'\',\'renewals\',\'' + item.AutoId + '\')" class="tooltip-error" data-rel="tooltip" title="续费">';
                    str += '                    <span class="red">';
                    str += '                        续费';
                    str += '                    </span>';
                    str += '                </a>';
                    str += '            </li>';
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
            }
            else {
                $('#list').empty();
                $('#list').append("暂无数据!");
                $('#example').empty();
            }
        };
        //获取市
        $('#txtProvince').change(function () {
            var selv = $('#txtProvince').val();
            var uareano="";
            if (selv != "") {
                var params = '{"typecode":"1","pcode":"' + selv + '","uareano":"' + uareano + '","addall":true}';
                $.ajax({
                    type: "POST",  //请求方式
                    url: "../../PlcData.aspx/getarea",  //请求路径：页面/方法名字
                    data: params,     //参数
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d.code == "expire") {                            
                            window.location.href = "../../LoginExc.aspx";
                        } else if (data.d.code == "ExcepError") {
                            alert(edata.d.msg);
                        } else {
                            $("#txtProvince option").each(function () {
                                if ($(this).val() == selv) {
                                    $(this).attr("selected", true);
                                }
                                else {
                                    $(this).removeAttr("selected");
                                }
                            });
                            $('#txtCity').html(data.d.RspData);
                            $('#txtCity').change();
                        }
                    },
                    error: function (obj, msg, e) {
                    }
                });
            }
        });
    </script>
</body>
</html>