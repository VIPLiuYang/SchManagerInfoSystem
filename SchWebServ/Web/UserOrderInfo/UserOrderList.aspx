<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserOrderList.aspx.cs" Inherits="SchWebServ.Web.UserOrderInfo.UserOrderList" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>用户订购信息列表</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
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

    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../assets/css/bootstrap-table.min.css" rel="stylesheet" />
    
    <style type="text/css">
         /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }

        i {
            font-family: FontAwesome !important;
        }
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

        .btn-group > .btn > .caret {
            margin-top: 0px;
        }
        .btn, .btn-default, .btn:focus, .btn-default:focus {
            background-color: #f2f2f2!important;
            color: #000000!important;
        }
        .dropup .btn-default .caret {
            border-bottom-color: #333;
            border-top-color: #333;
        }
        .modal-backdrop{z-index:0;}
        .breadcrumb {
            margin-bottom: 0px;
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
                                    账号&#160; <input type="text" id="txtAccount" placeholder="请输入账号" />&#8195;
                                    姓名&#160; <input type="text" id="txtUserTname" placeholder="请输入姓名" />&#8195;
                                    归属(省)&#160; 
                                        <select id="txtProvince">
                                            <%=province %>
                                        </select>&#8195;
                                    归属(市)&#160; 
                                        <select id="txtCity">
                                            <%=city %>
                                        </select>&#8195;
                                    <!--用户类型&#160; <input type="text" id="txtUserType" />&#8195;-->
                                    用户来源&#160; <input type="text" id="txtSource" />&#8195;
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
                                    <br />
                                    状态&#160; 
                                        <select id="txtStat">
                                            <option value="">状态</option><option value="1">正常</option><option value="0">禁用</option>
                                        </select>&#8195;
                                    
                                    订购时间&#160; 
                                    <input class="date-picker" id="txtStartTime01" style="cursor:pointer" type="text" data-date-format="yyyy-mm-dd" />
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
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-12">
                            <table id="table" class="table table-striped table-bordered table-hover"></table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- 模态框：--模态框 -->
    <div class="modal fade" id="EditCfmInfoDom">
        <div class="modal-dialog" style="width: 70%; height: 90%;">
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
     <script src="js/bootstrap.min.js"></script>
    <script src="../../assets/js/typeahead-bs2.min.js"></script>
    <!-- ace scripts -->

    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>

    <!-- inline scripts related to this page -->
    <script src="../../assets/js/date-time/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="../../assets/css/datepicker.css" />
    
    <script src="../../assets/js/bootstrap-table.min.js"></script>
    <script src="../../assets/js/bootstrap-table-zh-CN.min.js"></script>
   
    
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
        var txtOrderCols="AutoId";
        var txtOrderBy="ASC";
        var ServBusJson = <%=ServBusJson%>;

        //业务平台信息模态框
        function EditCfmInfo(obj, dotype,recid) {

            var modeltitle = "";
            var ifrurl = "";
            if (dotype == "a") {
                modeltitle = "新建订购信息";
                ifrurl = "UserOrderAdd.aspx?dotype=" + dotype + "&schid=" + schid;
            } else if (dotype == "e") {
                modeltitle = "修改订购信息";
                ifrurl = "UserOrderEdit.aspx?dotype=" + dotype + "&id=" + recid + "&schid=" + schid;
            } else if (dotype == "details") {
                modeltitle = "查看订购详情";
                ifrurl = "UserOrderDetails.aspx?dotype=" + dotype + "&id=" + recid + "&schid=" + schid;
            } else if (dotype == "renewals") {
                modeltitle = "续费";
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
                //getdata();
            })
        });
        //关闭模态框
        function closeEditCfmmodel() {
            $("#EditCfmInfoDom").modal("hide");
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


        //获取市
        $('#txtProvince').change(function () {
            var selv = $('#txtProvince').val();
            if (selv != "") {
                var params = '{"typecode":"1","pcode":"' + selv + '"}';
                $.ajax({
                    type: "POST",  //请求方式
                    url: "UserOrderList.aspx/getarea",  //请求路径：页面/方法名字
                    data: params,     //参数
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        $("#txtProvince option").each(function () {
                            if ($(this).val() == selv) {
                                $(this).attr("selected", true);
                            }
                            else {
                                $(this).removeAttr("selected");
                            }

                        });
                        $('#txtCity').html(data.d);
                        $('#txtCity').change();
                    },
                    error: function (obj, msg, e) {
                    }
                });
            }
        });

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

            $('#table').bootstrapTable('refresh', {url: './UserOrderList.aspx/page'});
        }




        //列配置项
        var columnsobj = [
            {
                field: 'UserName',
                title: '账号',
                sortable: false
            }, {
                field: 'UTname',
                title: '姓名',
                sortable: true
            }, {
                field: 'Province',
                title: '归属(省)',
                sortable: false,
                class:'hidden-480'
            }, {
                field: 'City',
                title: '归属（市）',
                sortable: false,
                class:'hidden-480'
            },
            {
                field: 'FromType',
                title: '用户来源',
                sortable: true,
                class:'hidden-480'
            },
            {
                field: 'RecUser',
                title: '来源附加',
                sortable: true,
                class:'hidden-480'
            },
            {
                field: 'CnName',
                title: '订购套餐',
                sortable: true
            }, 
            {
                field: 'FeeM',
                title: '订购金额',
                sortable: true
            },
            {
                field: 'ServMonth',
                title: '订购时长',
                sortable: true
            }, {
                field: 'RecTime',
                title: '订购时间',
                sortable: true,
                formatter: function (value, row, index) {
                    if (row['RecTime']) {
                        return row['RecTime'].substring(0, 10);
                    } else {
                        return '';
                    }
                    return value;
                },
                class:'hidden-480'
            }, {
                field: 'EndTime',
                title: '结束时间',
                sortable: true,
                formatter: function (value, row, index) {
                    if (row['EndTime']) {
                        return row['EndTime'].substring(0,10);
                    }else{
                        return '';
                    }
                    return value;
                },
                class:'hidden-480'
            }, {
                field: 'ServStat',
                title: '状态',
                sortable: false,
                formatter: function (value, row, index) {
                    if (row['ServStat'] === 1) {
                        return '正常';
                    }
                    if (row['ServStat'] === 0) {
                        return '禁用';
                    }
                    return value;
                },
                class:'hidden-480'
            },
            {
                field: 'EditTime',
                title: '修改时间',
                sortable: true,
                formatter: function (value, row, index) {
                    if (row['EditTime']) {
                        return row['EditTime'].substring(0, 10);
                    } else {
                        return '';
                    }
                    return value;
                },
                class:'hidden-480'
            },
            {
                field: '',
                title: '变动记录',
                sortable: false,
                class:'hidden-480'
            },
            {
                field: 'DoNote',
                title: '备注',
                sortable: false,
                formatter: function (value, row, index) {
                    if (row['DoNote']) {
                        return row['DoNote'].substring(0, 10);
                    } else {
                        return '';
                    }
                    return value;
                },
                class:'hidden-480'
            },
            {
                field: 'operation',
                title: '操作',
                formatter: function (cell, row, index) {
                    btnEdit = '<a class="blue"   href="javascript:void();" onclick="EditCfmInfo(\'\',\'e\',\'' + row.AutoId + '\')">修改</a>&#8195;';
                    btnDetail = '<a class="green"   href="javascript:void();" onclick="EditCfmInfo(\'\',\'details\',\'' + row.AutoId + '\')">详情</a>&#8195;';
                    btnRenewal = '<a class="red"   href="javascript:void();" onclick="EditCfmInfo(\'\',\'renewals\',\'' + row.AutoId + '\')">续费</a>';
                    cell = btnEdit + btnDetail + btnRenewal;
                    return cell;
                },
            }
        ];
        $('#table').bootstrapTable({
            url: './UserOrderList.aspx/page',        //URL请求地址
            method: 'post',                      //请求方式（*）
            dataType: "json",                   //返回数据类型
            dataField: "total",                 //这是返回的json数组的key.默认好像是"rows".这里只有前后端约定好就行
            //toolbar: '#toolbar',                //工具按钮用哪个容器
            dataField: "data",                  //这是返回的json数组的key.默认好像是"rows".这里只有前后端约定好就行
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: true,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                      //初始化加载第一页，默认第一页,并记录
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10, 25, 50, 100],        //可供选择的每页的行数（*）
            search: false,                      //是否显示表格搜索
            //searchOnEnterKey: true,             //设置为 true时，按回车触发搜索方法，否则自动触发搜索方法。
            //strictSearch: true,                 //设置为 true启用全匹配搜索，否则为模糊搜索。
            showColumns: false,                  //是否显示所有的列（选择显示的列）
            showRefresh: false,                  //是否显示刷新按钮
            showToggle: false,                   //是否显示详细视图和列表视图的切换按钮
            minimumCountColumns: 2,             //最少允许的列数
            clickToSelect: true,                //是否启用点击选中行
            //height: 500,                      //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            uniqueId: "AutoId",                     //每一行的唯一标识，一般为主键列
            cardView: false,                    //是否显示详细视图
            detailView: false,                  //是否显示父子表
            queryParams: queryParams,           //得到查询的参数
            responseHandler: responseHandler,   //请求数据成功后，渲染表格前的方法
            columns: columnsobj,                 //列配置项
            onSort: onSortFun
        });
        //得到查询的参数,并传递到后台（作为条件参数使用）
        function queryParams(params) {
            var datasave = [];
            datasave.push("PageIndex#" + this.pageNumber);
            datasave.push("PageSize#" + this.pageSize);
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
            datasave.push("ordercols#" + txtOrderCols);
            datasave.push("orderby#" + txtOrderBy);
            var temp = {
                arr:datasave
            };
            return temp;
        };
        //请求成功方法，渲染表格前的方法
        function responseHandler(result) {
            var errcode = eval("(" + result.d + ")").errcode;//在此做了错误代码的判断
            if (errcode != "") {
                alert("错误代码" + errcode);
                return;
            }
            //如果没有错误则返回数据，渲染表格
            return {
                total: eval("(" + result.d + ")").total, //总页数,前面的key必须为"total"
                data: eval("(" + result.d + ")").rows //行数据，前面的key要与之前设置的dataField的值一致.
            };
        };
        //当用户对某列进行排序时触发
        function onSortFun(name,order){
            txtOrderCols=name;
            txtOrderBy = order;
            $('#table').bootstrapTable('refresh', {url: './UserOrderList.aspx/page'});
        }
    </script>
</body>
</html>
