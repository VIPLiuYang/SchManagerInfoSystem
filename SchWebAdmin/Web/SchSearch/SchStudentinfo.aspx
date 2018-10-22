 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchStudentinfo.aspx.cs" Inherits="SchWebAdmin.Web.SchSearch.SchStudentinfo" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>学生信息列表</title>
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="../../assets/css/chosen.css" />
    <%-- --%>
    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/bootstrap-select.css" />
    <link rel="stylesheet" href="../../assets/css/metro.css" />
    <script src="../../assets/js/ace-extra.min.js"></script> 
    <style>
        /*所在位置的背景边框*/
         .breadcrumb_box {
            background: white;
            border-bottom: 1px solid #e4e4e4;
            /*color: #333333;*/
        }
         /*所在位置的提示高度*/
        .breadcrumbs {
            min-height: 32px;
            line-height: 30px;
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
        /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }
         
        i {
            font-family: FontAwesome !important;
        }
        /*表格标题栏字体大小，颜色*/
      
        .table thead > tr > th {
            font-size: 13px;
            color: #444444 !important;
            font-weight: bold !important;
            letter-spacing: 1px !important;
            text-align: center !important;
            line-height: 1.5 !important;
        }
        /*表格的内容区字体大小颜色*/
        .table tbody tr td {
            color: #666666 !important;
            font-size: 13px !important;
            text-align: center !important;
            line-height: 1.5 !important;
        }
        
        .search {
            margin-right: 10px;
            margin-left: 10px;
            font-size: 14px;
            color: #333333;
        }
        
         /*定义标题大小*/
        .biaoti { 
            font-size: 13px;
            color: #000000;
        }
        /*年级班级中的下拉选框中的颜色大小*/
         .biaoti select {
                font-size: 12px;
                color: #666666;
                margin-left: 10px !important;
                margin-right: 10px !important;
        }

         .select1 {
            font-size: 12px;
            color: #666666 !important;
            
            margin-left: 10px !important;
            margin-right: 10px !important;
        }
         /*年级班级中的下拉选框后边的提示语的颜色大小*/
         .biaoti span {
            font-size: 12px;
            color: #999999 !important;
        }

        #rolestreeext {
            display: none;
        }
        /*下拉选框 输入框的大小*/
         select, input {
            font-size: 12px;
            color: #999999;
        }

        input[type="text"] {
                color: #666666 !important;
                font-size: 12px !important;
                margin-left: 6px;
        }
         /*input中placeholder的颜色*/
       input::-webkit-input-placeholder, textarea::-webkit-input-placeholder { /* WebKit*/  
                color: #666666;
                font-size: 12px;
        }  

        input:-moz-placeholder, textarea:-moz-placeholder { /* Mozilla Firefox 4 to 18 */  
                color: #666666;
                font-size: 12px;
        }  

        input::-moz-placeholder, textarea::-moz-placeholder { /* Mozilla Firefox 19+ */  
                color: #666666;
                font-size: 12px;
        }  

        input:-ms-input-placeholder, textarea:-ms-input-placeholder { /* IE 10+ */  
                color: #666666;
                font-size: 12px;
        } 
        .breadcrumb > li + li:before {
            content:"";
        }
         /*弹出框的标题样式*/
        .title-style {
            font-size: 14px;
            font-weight: bold;
            letter-spacing: 1px;
        }
        
       
        /*弹出框标题背景样式*/
        .bootstrap-dialog.type-warning .modal-header {
              background-color: #ffffff !important;
       }
        /*弹出框标题样式*/
        .bootstrap-dialog .bootstrap-dialog-title {
               font-size: 18px !important;
               color: #f96161 !important;
       }
        /*弹出框确定按钮指针指上去样式*/
        .btn-warning:hover {
              background-color: #1b6aaa !important;
              border-color: #428bca !important;
       }
        /*弹出框确定按钮样式*/
        .btn-warning{
            background-color: #428bca !important;
            border-color: #428bca;
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
                            <div class="col-sm-12">
                                <div class="col-sm-10">
                                    <div class="input-group biaoti "> 
                                         <%=areastr %>
                                       <%-- 姓名:&nbsp;<input type="text" id="Stuname" style="width: 150px; height: 30px" placeholder="请输入关键字" />
                                       状态:
                                    <select id="stustat" style="width: 100px" class="select1">
                                        <option class="select1" value="1">正常</option>
                                        <option class="select1" value="">全部</option>

                                        <option class="select1" value="0">停用</option>
                                    </select>
                                        &nbsp;
                                        <button class="btn btn-sm btn-info" type="button" onclick="search();">查询</button>--%>
                                    </div>
                                    <div class="input-group biaoti col-sm-10 text-center">
                                       
                                        
                                        姓名:&nbsp;<input type="text" id="Stuname" style="width: 150px; height: 30px" placeholder="请输入关键字" />
                                   
                                        &nbsp;
                                        <button class="btn btn-sm btn-info" type="button" onclick="search();">查询</button>
                                    </div>
                                </div>
                                <div class="col-sm-2" id="addbtns">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="space-10" ></div>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="table-responsive" id="StuList">
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
            <!-- /.row -->
        </div>
        <!-- /.page-content -->
    </div>  
    <script type="text/javascript">
        window.jQuery || document.write("<script src='../../assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
    </script>
    <script src="../../assets/js/bootstrap.min.js"></script>
    <script src="../../assets/js/typeahead-bs2.min.js"></script>
    <script src="../../assets/js/jquery-ui-1.10.3.custom.min.js"></script>
    <script src="../../assets/js/jquery.ui.touch-punch.min.js"></script>
    <link href="../../assets/css/bootstrap-dialog.css" rel="stylesheet" />
    <script src="../../assets/js/bootstrap-dialog.js"></script>
    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script> 
    <script src="../../assets/js/bootstrap-paginator.js"></script>   
    <script>
        var PageIndex = 1;
        var PageSize = 10;
        var pageCount = 1;
        var bjid = ""
        var njid = "";
        var xxid = "";
        var stuname = "";
        var stustat = ""; 
        var stuid = '0';
        var schid = '<%=schid%>';
        var gradecode = "";
        var classid = "";

        function go() {
            sessionStorage.setItem("schstuindex", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("schstuindex_pageindex", PageIndex);
            sessionStorage.setItem("schstuindex_njid", njid);
            sessionStorage.setItem("schstuindex_bjid", bjid);
            sessionStorage.setItem("schstuindex_schid", schid);
            sessionStorage.setItem("schstuindex_stustat", stustat);
            sessionStorage.setItem("schstuindex_stuname", stuname);
            sessionStorage.setItem("schstuindex_stuid", stuid);

            return false;
        };
        //页面缓存,页面是返回的
        var l = sessionStorage.getItem("schstuindex");
        if (l != null) {
            $("#main-container").html(l);            //删除缓存
            sessionStorage.removeItem("schstuindex");
            //取回缓存中的查询条件
            PageIndex = sessionStorage.getItem("schstuindex_pageindex");
            stuname = sessionStorage.getItem("schstuindex_stuname");
            schid = sessionStorage.getItem("schstuindex_schid");
            bjid = sessionStorage.getItem("schstuindex_bjid");
            njid = sessionStorage.getItem("schstuindex_njid");
            stustat = sessionStorage.getItem("schstuindex_stustat");
            stuid = sessionStorage.getItem("schstuindex_stuid");

            sessionStorage.removeItem("schstuindex_pageindex");
            sessionStorage.removeItem("schstuindex_stuname");
            sessionStorage.removeItem("schstuindex_schid");
            sessionStorage.removeItem("schstuindex_bjid");
            sessionStorage.removeItem("schstuindex_njid");
            sessionStorage.removeItem("schstuindex_stustat");
            sessionStorage.removeItem("schstuindex_stuid");
        }

    


        function getPar(par) {
            //获取当前URL
            var local_url = document.location.href;
            //获取要取得的get参数位置
            var get = local_url.indexOf(par + "=");
            if (get == -1) {
                return false;
            }
            //截取字符串
            var get_par = local_url.slice(par.length + get + 1);
            //判断截取后的字符串是否还有其他get参数
            var nextPar = get_par.indexOf("&");
            if (nextPar != -1) {
                get_par = get_par.slice(0, nextPar);
            }
            return get_par;
        }
        var pageI = getPar("page");
        if (pageI == "") {
            pageI = 1;
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
        $(document).ready(function () {

            getdata();
        });
    </script>
</body>
</html>
<script type="text/javascript">
    function search() {
        PageIndex = 1;
        PageSize = 20;
        pageCount = 1;
        bjid = $("#bj").val();
        gradecode = $("#nj").val();
        classid = $("#bj").val();
        if (bjid == null) {
            bjid = "";
        }
        njid = $("#nj").val();
        xxid = '';
        stuname = $("#Stuname").val();

        //if ($('#asch').val()) {
        //    xxid = $("#asch").val();
        //}
        getdata();
    }
    //获取数据
    function getdata() {
        var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","ClassId":"' + bjid + '","SchId":"' + schid + '","Stuname":"' + stuname + '","GradeId":"' + njid + '"}';
        $.ajax({
            type: "POST",  //请求方式
            url: "SchStudentinfo.aspx/page",  //请求路径：页面/方法名字
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
    function dodata(data) {
        if (eval("(" + data + ")").list != null) {
            var text = ""; var i = 1;
            text += '  <table id="sample-table-2" class="table table-striped table-bordered table-hover">';
            text += ' <thead>';
            text += ' <tr>';
            text += ' <th class="center">';
            text += '<label>';
            text += '<input type="checkbox" class="ace" />';
            text += '<span class="lbl"></span>';
            text += '</label>';
            text += '</th>';
            text += ' <th>序号</th>';
            text += ' <th>系统编号</th>';
            text += ' <th>学(考号)</th>';
            text += '<th>学生姓名</th>';
            text += '<th>学生性别</th>';
            text += '<th class="hidden-480">学生卡号</th>';
            text += '<th class="hidden-480">电话</th>';
            text += '<th class="hidden-480">是否走读</th>';
            //text += ' <th>账号</th>';
            text += '<th class="hidden-480">家长姓名(一)</th>';
            text += ' <th class="hidden-480">家长电话</th>';
            //text += ' <th class="hidden-480">家长账号</th>';
            text += '<th class="hidden-480">家长姓名(二)</th>';
            text += ' <th class="hidden-480">家长电话</th>';
            //text += ' <th class="hidden-480">家长账号</th>';
            //text += ' <th>学生账号状态</th>';
            text += '<th>操作</th>';
            text += '</tr>';
            text += ' </thead> ';
            text += '<tbody>';
            var regtelphone = /^(\d{3})\d{4}(\d{4})$/;//显示前三位和后四位
            var regtelphone2 = /^(\d{1})\d{9}(\d{1})$/;//显示第一位和最后一位
            var regtelphone3 = /^(\d{1})\d{10}$/;//显示第一位
            $.each(eval("(" + data + ")").list, function (index, item) { //遍历返回的json
                
                var sex = item.Sex;
                if (sex == 1)
                    sex = "男"; else sex = "女";
                /*
                var Stat = item.Stat; 
                if (Stat == 1)  
                    Stat = "正常"; else Stat = "停用";
                */
                var StudyType = item.StudyType;
                if (StudyType == 0) {
                    StudyType = "住校";
                } else {
                    StudyType = "走读";
                }
                if (item.GenTelT != null) {
                    item.GenTelT = item.GenTelT.replace(regtelphone3, "$1***");
                } else {
                    item.GenTelT = "";
                }
                if (item.GenNameT == null) {
                    item.GenNameT = "";
                }
                if (item.GenLoginNameT != "") {
                    item.GenLoginNameT = "****";
                }
                item.CardNo = item.CardNo != "" ? "****" : "";
                // item.TelNo = item.TelNo.replace(regtelphone3, "$1***");
                item.LoginName = item.LoginName != "" ? "****" : "";
                if (item.GenTelO) {
                    item.GenTelO = item.GenTelO.replace(regtelphone3, "$1***");
                } else {
                    item.GenTelO = "";
                }
                item.GenLoginNameO = item.GenLoginNameO != "" ? "****" : "";
                var Stubh = "";
                if (JSON.stringify(item.StuId).length != 8) {
                    for (var i = 0; i < 8 - JSON.stringify(item.StuId).length; i++) {
                        Stubh += "0";
                    }
                }
                Stubh = Stubh + JSON.stringify(item.StuId);
                text += '<tr>';
                text += '   <td class="center">';
                text += '       <label>';
                text += '           <input type="checkbox" class="ace"  />';
                text += '           <span class="lbl"></span>';
                text += '       </label>';
                text += '   </td>';
                text += '   <td>' + (index + 1) + '</td>';
                text += '   <td>' + Stubh + '</td>';
                text += '   <td>1***</td>';
                text += '   <td>' + item.StuName + '</td>';
                text += '   <td>' + sex + '</td>';
                text += '   <td class="hidden-480">' + item.CardNo + '</td>';
                text += '   <td>1***</td>';
                text += '   <td class="hidden-480">' + StudyType + '</td>';
                //text +='   <td>' + item.LoginName + '</td>';
                if (item.GenNameO) {
                    text += '   <td class="hidden-480">' + item.GenNameO + '</td>';
                } else {
                    text += '   <td class="hidden-480"></td>';
                }
                text += '   <td class="hidden-480">' + item.GenTelO + '</td>';
                //text +='   <td class="hidden-480">' + item.GenLoginNameO + '</td>';
                if (item.GenNameT) {
                    text += '   <td class="hidden-480">' + item.GenNameT + '</td>';
                } else {
                    text += '   <td class="hidden-480"></td>';
                }
                text += '   <td class="hidden-480">' + item.GenTelT + '</td>';
                //text +='   <td class="hidden-480">' + item.GenLoginNameT + '</td>';
                //text +='   <td>' + Stat + '</td>';
                text += '   <td>';
                text += '       <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">';
              
                text += '       </div>';

                text += '<div class="visible-xs visible-sm hidden-md hidden-lg">';
                text += '<div class="inline position-relative">';
                text += '<button class="btn btn-minier btn-yellow dropdown-toggle" data-toggle="dropdown">';
                text += '<i class="icon-caret-down icon-only bigger-120"></i>';
                text += '</button>';
                
  
                text += '</ul>';
                text += '</div>';
                text += '</div>';
                text += '   </td>';
                text += '</tr>';
                i += 1;
            });
            text += '</tbody>';
            text += '</table>';
            $('#StuList').empty();
            $('#StuList').append(text);
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
            $('#StuList').empty();
            $('#StuList').append("暂无数据!");
            $('#example').empty();
           
          
        }
    }
    //获取班级
    $('#nj').change(function () {
        $('#njld').html("年级领导：");
        var selv = $('#nj').val();
        var params = '{"typecode":"1","pcode":"' + selv + '","schid":"' + schid + '","classid":""}';
        $.ajax({
            type: "POST",  //请求方式
            url: "SchStudentinfo.aspx/getnj",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var dd = eval("(" + data.d + ")");
                $('#njld').html("年级领导：" + dd.gradeboss);
            },
            error: function (obj, msg, e) {
            }
        });


        var params = '{"typecode":"5","pcode":"' + selv + '","isall":"1"}';
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
                    $('#bj').html(data.d.data);
                    $('#bj').change();
                    $("#nj option").each(function () {
                        if ($(this).val() == selv) {
                            $(this).attr("selected", true);
                        }
                        else {
                            $(this).removeAttr("selected");
                        }

                    });
                }
            },
            error: function (obj, msg, e) {
            }
        });
    });



    //获取班级
    $('#bj').change(function () {
        $('#bjjs').html("任课老师：");
        $('#bzr').html("班主任：");
        var selv = $('#bj').val();
        var params = '{"typecode":"2","pcode":"' + selv + '","schid":"' + schid + '","classid":""}';
        $.ajax({
            type: "POST",  //请求方式
            url: "SchStudentinfo.aspx/getnj",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var dd = eval("(" + data.d + ")");
                $('#bjjs').html("任课老师：" + dd.classtec);
                $('#bzr').html("班主任：" + dd.classms);
                $("#bj option").each(function () {
                    if ($(this).val() == selv) {
                        $(this).attr("selected", true);
                    }
                    else {
                        $(this).removeAttr("selected");
                    }

                });
            },
            error: function (obj, msg, e) {
            }
        });

    });
    //获取班级
    $('#stustat').change(function () {
        var selv = $('#stustat').val();
        $("#stustat option").each(function () {
            if ($(this).val() == selv) {
                $(this).attr("selected", true);
            }
            else {
                $(this).removeAttr("selected");
            }

        });
    });

</script>
