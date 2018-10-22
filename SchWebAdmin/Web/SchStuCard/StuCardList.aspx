<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuCardList.aspx.cs" Inherits="SchWebAdmin.Web.SchStuCard.StuCardList" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>人员信息维护</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <%--<meta name="viewport" content="width=device-width, initial-scale=1.0" />--%>

    <meta name="viewport" content="width=device-width">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>
    <style>
        
        /*添加班级弹出框的顶端距离*/
        @media screen and (min-width: 768px) {
            .modal-dialog {
                padding-top: 130px;
            }
        }
        /*弹出框表头的颜色*/
        .bootstrap-dialog.type-warning .modal-header {
            background-color: #ffffff !important;
        }
        /*弹出框表头标题的颜色大小*/
        .bootstrap-dialog .bootstrap-dialog-title {
            font-size: 18px !important;
            color: #f96161 !important;
        }
        /*确定按钮的颜色*/
        .btn-warning {
            background-color: #428bca !important;
            border-color: #428bca;
        }
            /*确定按钮鼠标移动到上边时的颜色*/
            .btn-warning:hover {
                background-color: #1b6aaa!important;
                border-color: #428bca;
            }

        h4 {
            font-size: 14px !important;
            font-weight: bold !important;
            letter-spacing: 1px !important;
        }

        .pagination {
            border-top: 1px solid #DDD;
            padding-top: 12px;
            padding-bottom: 12px;
            background-color: #eff3f8;
        }
        .page-content {
            padding:0px;
        }
        .table thead > tr > th, .table tbody > tr > td {
            text-align: center;
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
                            目前所在位置：
                        </li>
                        <li class="active">教师及账号信息 </li>
                    </ul>
                    <!-- .breadcrumb -->
                    <div class="nav-search" id="nav-search">
                        <span id="addbtns"></span>
                    </div>
                </div>

                <div class="page-content">
                    <div style="background-color: rgb(239, 243, 248); text-align: right; padding: 6px 4px; ">
                        <%=areastr %>
                        <span>学生姓名:</span>
                        <input type="text" id="txtname" placeholder="姓名">
                        <span>卡地址:</span>
                        <input type="text" id="txtcard" placeholder="卡地址">
                        <span>是否有卡:</span>
                        <select id="iscard">
                            <option value="">全部</option>
                            <option value="1">有</option>
                            <option value="0">无</option>
                        </select>
                        <button class="btn btn-sm btn-info text_size" type="button" onclick="search();" style="margin-left: 10px">查询</button><button class="btn btn-sm btn-info text_size" type="button" onclick="batupdatestu();" style="margin-left: 10px">批量修改</button>




                    </div>
                    <div class="table-responsive " id="list"></div>


                    <div class="dataTables_paginate paging_bootstrap" style="background-color: rgb(239, 243, 248);  border-bottom: 1px solid #ddd;">
                        <ul id="example">
                        </ul>
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
    <link href="../../assets/css/bootstrap-dialog.css" rel="stylesheet" />
    <script src="../../assets/js/bootstrap-dialog.js?v=1.2"></script>
    <!-- ace scripts -->
    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>
    <script src="../../assets/js/bootstrap-paginator.js"></script>

    <!-- inline scripts related to this page -->

    <script type="text/javascript">        
                
        var PageIndex = 1;
        var PageSize = 70;
        var pageCount = 1;
        var txtname = '';
        var txtcard = '';
        var clssid = '';
        var gradeid = '';
        var schid = '';        
        var cotyid = '';
        var cityid = '';
        var provid = '';
        var iscard = '';  

        function go() {

            sessionStorage.setItem("schstucardindex", $("#main-container").html()); //存储列表数据
            //缓存查询条件
            sessionStorage.setItem("schstucardindex_pageindex", PageIndex);
            sessionStorage.setItem("schstucardindex_txtname", txtname);
            sessionStorage.setItem("schstucardindex_txtcard", txtcard);
            sessionStorage.setItem("schstucardindex_clssid", clssid);
            sessionStorage.setItem("schstucardindex_gradeid", gradeid);
            sessionStorage.setItem("schstucardindex_schid", schid);
            sessionStorage.setItem("schstucardindex_cotyid", cotyid);
            sessionStorage.setItem("schstucardindex_cityid", cityid);
            sessionStorage.setItem("schstucardindex_provid", provid);
            sessionStorage.setItem("schstucardindex_iscard", iscard);
            return false;
        };

        //页面缓存,页面是返回的
        var l = sessionStorage.getItem("schstucardindex");
        if (l != null) {
            $("#main-container").html(l);            //删除缓存
            sessionStorage.removeItem("schstucardindex");
            //取回缓存中的查询条件
            PageIndex = sessionStorage.getItem("schstucardindex_pageindex");
            txtname = sessionStorage.getItem("schstucardindex_txtname");
            txtcard = sessionStorage.getItem("schstucardindex_txtcard");
            clssid = sessionStorage.getItem("schstucardindex_clssid");
            gradeid = sessionStorage.getItem("schstucardindex_gradeid");
            schid = sessionStorage.getItem("schstucardindex_schid");
            cotyid = sessionStorage.getItem("schstucardindex_cotyid");
            cityid = sessionStorage.getItem("schstucardindex_cityid");
            provid = sessionStorage.getItem("schstucardindex_provid");
            iscard = sessionStorage.getItem("schstucardindex_iscard");

            sessionStorage.removeItem("schstucardindex_pageindex");
            sessionStorage.removeItem("schstucardindex_txtname");
            sessionStorage.removeItem("schstucardindex_txtcard");
            sessionStorage.removeItem("schstucardindex_clssid");
            sessionStorage.removeItem("schstucardindex_gradeid");
            sessionStorage.removeItem("schstucardindex_schid");
            sessionStorage.removeItem("schstucardindex_cotyid");
            sessionStorage.removeItem("schstucardindex_cityid");
            sessionStorage.removeItem("schstucardindex_provid");
            sessionStorage.removeItem("schstucardindex_iscard");
        }
        else {

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
            //}                                                                               string txtname, string txtcard, string clssid, string gradeid, string schid, string iscard, string isall
        };
        //获取数据
        function getdata() {
            var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","txtname":"' + txtname + '","txtcard":"' + txtcard + '","clssid":"' + clssid + '","gradeid":"' + gradeid + '","schid":"' + schid + '","cotyid":"' + cotyid + '","cityid":"' + cityid + '","provid":"' + provid + '","iscard":"' + iscard + '"}';

            $.ajax({
                type: "POST",  //请求方式
                url: "StuCardList.aspx/page",  //请求路径：页面/方法名字
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
            var i = 1;
            if (data.list != null) {
                var str = '';
                str += '<table id="data_table" class="table table-striped table-bordered table-hover dataTable">';
                str += '<thead>';
                str += '<tr>';
                str += '<th>序号</th>';
                str += '<th class="hidden-480">省</th>';
                str += '<th class="hidden-480">市</th>';
                str += '<th class="hidden-480">区</th>';
                str += '<th class="hidden-480">学校名称</th>';
                str += '<th class="hidden-480">年级名称</th>';
                str += '<th class="hidden-480">班级名称</th>';
                str += '<th>学生名称</th>';
                str += '<th>卡地址</th>';                
                str += '<th>操作</th>';
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                $.each(data.list, function (index, item) { //遍历返回的json                    
                    str += '<tr>';
                    str += '<td>' + i + '</td>';
                    str += '<td class="hidden-480">' + item.SHENG + '</td>';
                    str += '<td class="hidden-480">' + item.SHI + '</td>';
                    str += '<td class="hidden-480">' + item.QU + '</td>';
                    str += '<td class="hidden-480">' + item.SchName + '</td>';
                    str += '<td class="hidden-480">' + item.GradeName + '</td>';
                    str += '<td class="hidden-480">' + item.ClassName + '</td>';
                    str += '<td>' + item.StuName + '</td>';
                    str += '<td><input type="text" id="cardno' + item.StuId + '" onchange="cardotip(' + item.StuId + ',\'' + item.StuName + '\');" value="' + item.CardNo + '"/></td>';
                    str += '<td>';
                    str += '<div class="visible-md visible-lg hidden-sm hidden-xs action-buttons" id="cardo' + item.StuId + '">';
                    str += '</div>';
                    str += '<div class="visible-xs visible-sm hidden-md hidden-lg">';
                    str += '<div class="inline position-relative">';
                    str += '<button class="btn btn-minier btn-yellow dropdown-toggle" data-toggle="dropdown">';
                    str += '<i class="icon-caret-down icon-only bigger-120"></i>';
                    str += '</button>';
                    str += '<ul class="dropdown-menu dropdown-only-icon dropdown-yellow pull-right dropdown-caret dropdown-close" id="cardosm' + item.StuId + '">';
                    
                        
                    
                    str += '</ul>';
                    str += '</div>';
                    str += '</div>';
                    str += '</td>';
                    str += '</tr>';
                    i += 1;
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
                var txts = $("#data_table input");
                for (var i = 0; i < txts.length; i++) {
                    var t = txts[i];
                    t.index = i;
                }
                $("input").keydown(function (e) {
                    var keyCode = e.keyCode ? e.keyCode : e.which ? e.which : e.charCode;
                    if (keyCode == 13) {
                        var next = this.index + 1;
                        if (next > txts.length - 1) return;
                        txts[next].focus();
                        return false;
                    }
                    else
                        return true;
                });
            }
            else {
                $('#list').empty();
                $('#list').append("暂无数据!");
                $('#example').empty();
            }
        };
        function search() {
            
            var vsch = $('#asch').val();            
            PageIndex = 1;
            PageSize = 70;
            pageCount = 1;
            txtname = $("#txtname").val();
            txtcard = $("#txtcard").val();
            clssid = $("#bj").val();
            gradeid = $("#nj").val();
            schid = $("#asch").val();
            cotyid = $("#acoty").val();
            cityid = $("#acity").val();
            provid = $("#aprov").val();
            iscard = $("#iscard").val();
            getdata();
        }

        $(document).ready(function () {

            getdata();
            
        });
        //添加修改确认按钮
        function cardotip(stuid,stuname)
        {
            var vl = $('#cardno' + stuid).val();
            if (vl.length > 0 && vl.length < 8) {
                $('#cardno' + stuid).val("");
                alert("卡地址不能少于8位");
                return false;

            }
            var reg1 = new RegExp(/^[0-9A-Za-z]+$/);
            if (vl.length > 0&&!reg1.test(vl)) {
                $('#cardno' + stuid).val("");
                alert("卡地址必须为英文或字母组合");
                return false;
            }
            var cardostr = "";
            cardostr += '<a class="green" href="javascript:updateuser(' + stuid + ',\'' + stuname + '\')" onclick="go();">';
            cardostr += '<i class="icon-ok bigger-130"></i>';
            cardostr += '</a>';
            $('#cardo' + stuid).html(cardostr);
            var cardosmstr = "";
            cardosmstr += '<li>';
            cardosmstr += '<a href="javascript:updateuser(' + stuid + ',\'' + stuname + '\')" onclick="go();" title="编辑">';
            cardosmstr += '<span class="green">';
            cardosmstr += '<i class="icon-ok bigger-120"></i>';
            cardosmstr += '</span>';
            cardosmstr += '</a>';
            cardosmstr += '</li>';
            $('#cardosm' + stuid).html(cardosmstr);
            $('#cardno' + stuid).attr("name","batdo");
        }
        function updateuser(stuid, stuname) {
            var msg = "将更改学生:" + stuname + "的卡地址,确认要更改吗？";
            //$.showConfirm = function (str, funcok, funcclose) {
            BootstrapDialog.confirm({
                title: "提示框",
                message: msg,
                type: BootstrapDialog.TYPE_WARNING, // <-- Default value is // BootstrapDialog.TYPE_PRIMARY
                closable: true, // <-- Default value is false，点击对话框以外的页面内容可关闭
                draggable: true, // <-- Default value is false，可拖拽
                btnCancelLabel: "取消", // <-- Default value is 'Cancel',
                btnOKLabel: "确定", // <-- Default value is 'OK',
                btnOKClass: "btn-warning", // <-- If you didn't specify it, dialog type
                size: BootstrapDialog.SIZE_SMALL,
                // 对话框关闭的时候执行方法
                //onhide: funcclose,
                callback: function (result) {
                    if (result) {// 点击确定按钮时，result为true
                        updatestu(stuid);
                    }
                }
            });
        }
        function updatestu(stuid) {
            var cardno = $('#cardno' + stuid).val();
            if (cardno!=""&&cardno.length < 8)
            {
                alert("卡地址不能少于8位");
                return false;
            }
            var params = '{"stuid":"' + stuid + '","cardno":"' + cardno + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "StuCardList.aspx/stup",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == 'success') {
                        alert("修改成功");
                        $('#cardosm' + stuid).html('');
                        $('#cardo' + stuid).html('');
                    }
                    else if (data.d.code == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    } else {
                        alert(data.d.msg);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        }
        function batupdatestu() {
            //获取要更新的所有元素
            var batdoelmes = $("input[name$='batdo']");
            if (batdoelmes.length > 0)
            {
                for (var i = 0; i < batdoelmes.length; i++) {
                    //获取ID和卡地址
                    var stucardno = $(batdoelmes[i]).attr("id");
                    var cardno = $(batdoelmes[i]).val();
                    var stuid = stucardno.substr(6);
                    var params = '{"stuid":"' + stuid + '","cardno":"' + cardno + '"}';
                    $.ajax({
                        type: "POST",  //请求方式
                        url: "StuCardList.aspx/stup",  //请求路径：页面/方法名字
                        data: params,     //参数
                        dataType: "json",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            if (data.d.code == 'success') {
                                $(batdoelmes[i]).attr("name", "");
                                $('#cardosm' + stuid).html('');
                                $('#cardo' + stuid).html('');
                            }
                            else if (data.d.code == "expire") {
                                window.location.href = "../../LoginExc.aspx";
                            } else {

                            }
                        },
                        error: function (obj, msg, e) {
                        }
                    });
                }
                var batdoelmesnotdo = $("input[name$='batdo']");
                if (batdoelmesnotdo.length > 0) {
                    alert("剩下打勾的，请检查卡地址长度是否正确及是否被占用");
                }
                else
                {
                    alert("操作完毕");
                }
            }
        }
        //获取市
        $('#aprov').change(function () {
            var selv = $('#aprov').val();
            var params = '{"typecode":"1","pcode":"' + selv + '","isall":"1"}';
            if (selv != "") {
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
                            $('#acity').html(data.d.data);
                            $('#acity').change();
                            $("#aprov option").each(function () {
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
            } else {
                $('#acity').empty();
                $('#acity').append("<option value=\"\">全部</option>");
                //$("#acity option:first").prop("selected", 'selected');
                $('#acoty').empty();
                $('#acoty').append("<option value=\"\">全部</option>");
                //$("#acoty option:first").prop("selected", 'selected');
            }
        });
        //获取区
        $('#acity').change(function () {
            var selv = $('#acity').val();
            var params = '{"typecode":"2","pcode":"' + selv + '","isall":"1"}';
            if (selv != "") {
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
                            $('#acoty').html(data.d.data);
                            $('#acoty').change();
                            $("#acity option").each(function () {
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
            } else {
                $('#acoty').empty();
                $('#acoty').append("<option value=\"\">全部</option>");
                //$("#acoty option:first").prop("selected", 'selected');
            }
        });
        //获取学校
        $('#acoty').change(function () {
            var selv = $('#acoty').val();
            var params = '{"typecode":"3","pcode":"' + selv + '","isall":"1"}';
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
                        $('#asch').html(data.d.data);
                        $('#asch').change();
                        $("#acoty option").each(function () {
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
        //获取年级
        $('#asch').change(function () {
            var selv = $('#asch').val();
            var params = '{"typecode":"4","pcode":"' + selv + '","isall":"1"}';
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
                        $('#nj').html(data.d.data);
                        $('#nj').change();
                        $("#asch option").each(function () {
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
        $('#nj').change(function () {
            var selv = $('#nj').val();
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
        $('#iscard').change(function () {
            var selv = $('#iscard').val();
            $("#iscard option").each(function () {
                if ($(this).val() == selv) {
                    $(this).attr("selected", true);
                }
                else {
                    $(this).removeAttr("selected");
                }
            });
        });
    </script>
</body>
</html>
