<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartInfo.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.Department.DepartInfo" %>

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

     

    <!-- ace styles -->

    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/metrodpt.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>
    <style>
       /*输入框中字体的颜色*/ 
       .form input {
            color: #999999!important;
              
        }
        .form-control, select ,input{
            font-family: "微软雅黑" !important;
            color: #999999!important;
            font-size:12px !important;
            margin-left:10px;
            margin-right:10px;
        }
         /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }

        i {
            font-family: FontAwesome !important;
        }
        /*所在位置的提示高度*/
        .breadcrumbs {
            min-height:32px;
            line-height:30px;
        }
        /*所在位置的背景边框*/
        .breadcrumb_box {
            background:white;
            border-bottom:1px solid #e4e4e4;
            margin-bottom:20px;
        }
        /*坐在位置的坐边竖线*/
        .breadcrumb_border {
            border-left:2px solid #63bbff;
            margin-left:0px;
            padding-left:12px;
           
        }
       
       
        /*框中的部门名称等标题大小大小的字体大小*/
        .biaoti { 
            font-size:13px;
            color:#000000;

        }
         /*部门名称边距*/
        .bumenbianju { 
            margin-top:20px;
            margin-bottom:10px;
        }
        /*保存按钮边距*/
        .baocunbianju {
            margin-top:10px;
                      
        }
        /*位置提示字体大小*/
        .breadcrumb > li {
            font-size:13px !important;
            color:#666666 !important;
        }
         /*学校名称等左边标签的样式*/
        .text_style {
            /*font-size: 15px !important;*/
            line-height: 30px !important;
            color: #333333 !important;
        }
         /*搜索栏的字体颜色*/
        .input-group {
           font-size:14px;
           color:#000000;
        }
        /*输入框字体的颜色*/
        input[type="text"] {
            color:#999999;
            font-size:12px;
            
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
        /*部门结构、部门信息标题样式*/
        .title1 {
            font-size:13px ;
            font-weight:bold;
            letter-spacing:1px;
            color:#444444;
        }
        /*部门结构中的树的行高*/
        .ztree li {
            line-height:6px;
        }
        .ztree li a {
            color:#666666;
        }
        /*部门结构中二级部门的颜色*/
        .widget-main li ul a span:nth-child(2) {
            color:#999999;
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
                <div class="breadcrumbs breadcrumb_box " id="breadcrumbs">
                    <script type="text/javascript">
                        try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
                    </script> 
                    <ul class="breadcrumb breadcrumb_border ">
                        <li> 
                            目前所在位置：部门设置  
                        </li>  
                    </ul>
                    <!-- .breadcrumb -->
                </div>

                <div class="page-content">
                    <div class="row" id="searchbar">
                        <div class="col-xs-12">
                            <div class="col-sm-12">
                                <div class="col-sm-9">
                                    <div class="input-group pull-right">
                                        <%=areastr %>
                                   <%--     状态:
                                    <select id="ustat">
                                        <option value="">全部</option>
                                        <option value="1">正常</option>
                                        <option value="0">停用</option>
                                    </select>
                                        部门名称:<input type="text" id="txtname" placeholder="部门名称">--%>
                                        <button class="btn btn-sm btn-info text_size" type="button" onclick="search();">查询</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="space-10"></div>
                    <div class="row">
                        <div class="col-xs-12">
                          
                            <div class="col-sm-4">
                                <div class="widget-box" style="margin: 0px;">
                                    <div class="widget-header widget-header-flat">
                                        <h4 class="title1" >部门结构</h4>
                                        <a class="btn btn-link pull-right" href="javascript:RoleAdd(1,1,'2')"><i class="icon-plus bigger-125" title="添加部门" style="line-height:28px"></i></a>
                                    </div>
                                    <div class="widget-body">
                                        <div class="widget-main">
                                            <div class="row">
                                                <ul id="treedept" class="ztree"></ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-8">
                                <div class="widget-box" style="margin: 0px;display:none;" id="widget-box-right">
                                    <div class="widget-header widget-header-flat">
                                        <h4 class="title1" id="titlestr">部门信息</h4>
                                    </div>

                                    <div class="widget-body">
                                        <div class="widget-main">
                                            <div class="row bumenbianju text_style">
                                                <div class="col-sm-2 no-padding-right text-right ">
                                                    <label class=" biaoti">部门名称:</label>
                                                </div>
                                                <div class="col-sm-6 form no-padding-left">
                                                    <input  type="text" maxlength="10" id="dptname" placeholder="部门名称" />
                                                </div>

                                            </div>
                                            <div class="row text_style">
                                                <div class="col-sm-2 no-padding-right text-right ">
                                                    <label class=" biaoti">上级部门:</label>
                                                </div>
                                                <div class="col-sm-6 no-padding-left">
                                                    <select id="dptp">
                                                        <option value="0">顶级部门</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="row" id="dptstatdiv">
                                                <div class="col-sm-2 no-padding-right">
                                                    <label>状态:</label>
                                                </div>
                                                <div class="col-sm-6">
                                                    <select id="dptstat">
                                                        <option value="1">正常</option>
                                                        <option value="0">停用</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="row" id="orderidbtn" style="display:none;">
                                                <div class="col-sm-2 no-padding-right text-right">排序：</div>
                                                <div class="col-sm-6">
                                                    <input type="button" name="MoveUp" class="MoveUp" rel_id="up" value="上移"/>
                                                    <input type="button" name="MoveDown" class="MoveDown" rel_id="down" value="下移"/>
                                                </div>
                                            </div>
                                            <div class="space-10"></div>
                                            <div class="row" >
                                                <div class="col-sm-4 col-sm-offset-2">
                                                    <button id="savebtn" class="btn btn-sm btn-info baocunbianju" type="button">
                                                        保存
                                                    </button>
                                                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
										            <button id="cancelbtn" class="btn btn-sm baocunbianju" onclick="RoleAdd(1,1,'2')" >
                                                            取消
                                                    </button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
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
    <script src="../../assets/js/bootstrap-dialog.js"></script>
    <!-- ace scripts -->

    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>
     <script src="../../assets/js/bootstrap-paginator.js"></script>

    <script src="../../assets/js/jquery.ztree.all-3.5.min.js"></script>
    <!-- inline scripts related to this page -->

    <script type="text/javascript">
        $("#titlestr").html("添加部门信息");
        $("#savebtn").text("保存");
        $("#orderidbtn").css("display", "none");
        //人员分页列表
        $('.ztree li a').css('display', '');
        var txtname = '';
        var schid = '<%=uschid%>';
        var ustat = '';
        cotycode = '<%=cotycode%>';
        if (cotycode == '') {
            $('#searchbar').hide()
        }
        $('#dptstatdiv').hide();
        function search() {
            //清除树以及添加
            $('#treedept').html('');
            $('#dptname').val('');
            $('#dptp').html('<option value="0">顶级部门</option>');
            //$('#savebtn').text("请选择节点");
            $('#savebtn').attr('onclick', '');
            schid = $('#asch').val();
            if (schid == "0" || schid == "" || schid == null) {
                alert("请选择学校");
                return false;
            }
            txtname = $('#txtname').val();
            if ($('#acoty').val()) {
                cotycode = $('#acoty').val();
            }
            ustat = $('#ustat').val();
            $('#dptp').html('<option value="0">顶级部门</option>');
            RoleAdd(1, 1, '2');//初始化右边的默认设置
            getdata();
        }
        $(document).ready(function () { getdata(); });
        //获取市
        $('#aprov').change(function () {
            var selv = $('#aprov').val();
            var params = '{"typecode":"1","pcode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "../Users/UserInfo.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $('#acity').html(data.d);
                    $('#acity').change();
                },
                error: function (obj, msg, e) {
                }
            });
        });
        //获取区
        $('#acity').change(function () {
            var selv = $('#acity').val();
            var params = '{"typecode":"2","pcode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "../Users/UserInfo.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $('#acoty').html(data.d);
                    $('#acoty').change();
                },
                error: function (obj, msg, e) {
                }
            });
        });
        //获取学校
        $('#acoty').change(function () {
            var selv = $('#acoty').val();
            var params = '{"typecode":"3","pcode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "../Users/UserInfo.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) { 
                    $('#asch').html(data.d);
                },
                error: function (obj, msg, e) {
                }
            });
        });
        function getdata() {
            var params = '{"schid":"' + schid + '","stat":"' + ustat + '","selfid":"","selid":""}';
            $.ajax({
                type: "POST",  //请求方式
                url: "DepartInfo.aspx/getdpt",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    dotree(eval("(" + data.d + ")"));
                },
                error: function (obj, msg, e) {
                }
            });
        }
        var treedeptObj;
        function dotree(d) { 
            var treeNodesdept = d;
            var settingdept = {
                check: {
                    //enable: true,
                    //autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]   
                    chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]   
                    chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
                },
                view: {
                    //addHoverDom: addHoverDom,
                    //removeHoverDom: removeHoverDom,
                    dblClickExpand: false,
                    showLine: true,
                    selectedMulti: true
                },
                data: {
                    simpleData: {
                        enable: true,
                        idKey: "id",
                        pIdKey: "pId",
                        checked: "checked",
                        rootPId: ""
                    }
                },
                callback: {
                    beforeClick: function (treeId, treeNode) {
                       // RoleEdit(treeId, treeNode);
                    }
                } 
            };
            $(function () {
                treedeptObj = $.fn.zTree.init($("#treedept"), settingdept, treeNodesdept);
                treedeptObj.expandAll(true);
                var nodes = treedeptObj.getNodesByFilter(filter);
                if (nodes.length > 0) {
                    for (var item in nodes) {
                        addHoverDom('treedept', nodes[item]);
                    }
                }
            });
        };
        function filter(node) {
            return true;
        }
        function addHoverDom(treeId, treeNode) {
            var sObj = $("#" + treeNode.tId + "_span");
            if (treeNode.editNameFlag || $("#addBtn_" + treeNode.tId).length > 0) return;
            var addStr = " ";
            addStr += "<span class='button remove'  id='removeBtn_" + treeNode.tId
                    + "' title='移除' onfocus='this.blur();'></span>";
            addStr += "<span class='button edit'   id='editBtn_" + treeNode.tId + "' title='修改' onfocus='this.blur();'></span>";
            addStr += "<span class='button add'  id='addBtn_" + treeNode.tId + "' title='添加' onfocus='this.blur();'></span>";
            addStr += " ";
            sObj.after(addStr);
            var btn = $("#addBtn_" + treeNode.tId);
            if (btn) btn.bind("click", function () { 
                RoleAdd(treeId, treeNode,"1");
                $("#titlestr").html("添加部门信息");
            });
            var btnedit = $("#editBtn_" + treeNode.tId);
            if (btnedit) btnedit.bind("click", function () {
                RoleEdit(treeId, treeNode);
                $("#titlestr").html("修改部门信息");
            });
            var btnremove = $("#removeBtn_" + treeNode.tId);
            if (btnremove) btnremove.bind("click", function () {
                RoleDel(treeId, treeNode);
            });
        };
         
        function removeHoverDom(treeId, treeNode) {
            $("#addBtn_" + treeNode.tId).unbind().remove();
            $("#removeBtn_" + treeNode.tId).unbind().remove();
            $("#editBtn_" + treeNode.tId).unbind().remove();
        };
        //删除权限
        function RoleDel(treeId, treeNode) { 
                var msg = "确认删除这条信息吗？";
                //$.showConfirm = function (str, funcok, funcclose) {
                BootstrapDialog.confirm({
                    title: "确认提示框",
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
                            var params = '{"schid":"' + schid + '","id":"' + treeNode.id + '"}';
                            $.ajax({
                                type: "POST",  //请求方式
                                url: "DepartInfo.aspx/deldpt",  //请求路径：页面/方法名字
                                data: params,     //参数
                                dataType: "json",
                                contentType: "application/json; charset=utf-8",
                                success: function (data) {
                                    if (data.d) {
                                        if (data.d == 'success') {
                                            //删除节点
                                            treedeptObj.removeNode(treeNode);
                                            dptadd(0);
                                        } else if (data.d == "expire") {
                                            window.location.href = "../../LoginExc.aspx";
                                        }
                                        else {
                                            alert(data.d);
                                        }
                                    }
                                },
                                error: function (obj, msg, e) {
                                }
                            });
                        }
                    }
                }); 
        }
        //编辑权限
        function RoleEdit(treeId, treeNode) {
            $("#orderidbtn .MoveUp").attr("orderid",treeNode.OrderId);
            $("#orderidbtn .MoveDown").attr("orderid", treeNode.OrderId);
            $('#dptname').val(treeNode.name);
            $('#dptstat').val(treeNode.stat);
            $('#savebtn').text("保存");
            $('#savebtn').attr('onclick', 'savedpt();');
            $('#savebtn').val(treeNode.id);
            $("#titlestr").html("修改部门信息");
            $("#orderidbtn").css("display", "block");
            $("#widget-box-right").css("display", "block");
            var params = '{"schid":"' + schid + '","stat":"1","selfid":"' + treeNode.id + '","selid":"' + treeNode.pId + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "DepartInfo.aspx/getdpt",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    } else {
                        $('#dptp').html(data.d);
                    }
                },
                error: function (obj, msg, e) { 
                }
            });
            $('#dptname').focus();
        };
        //保存,并更新树节点
        function savedpt() {
            var dptname = $('#dptname').val();
            var stat = $('#dptstat').val();
            var pid = $('#dptp').val();
            var id = $('#savebtn').val();
            if (dptname.length < 1) {
                alert("请填写名称!");
                return;
            }
            var params = '{"schid":"' + schid + '","id":"' + id + '","dptname":"' + dptname + '","stat":"1","pid":"' + pid + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "DepartInfo.aspx/updpt",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == 'success') {
                        //重新加载树
                        getdata();
                    } else if (data.d == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    }
                    else {
                        alert(data.d);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        };
        $('#savebtn').attr('onclick', 'adddpt();');//初始化
        function RoleAdd(treeId, treeNode, sl) {
            $("#orderidbtn").css("display", "none");
            $("#widget-box-right").css("display", "block");
            if (sl == "2") {
                $('#savebtn').attr('onclick', 'adddpt();');
                $('#savebtn').text("保存");
                $("#titlestr").html("添加部门信息");
                $("#dptname").val("");
                $("#dptp option:first").prop("selected", "selected");
                dptadd(treeNode.id);
            } else {
                dptadd(treeNode.id);
            }
         
        };
        function dptadd(id) {
            if (schid == "0" || schid == "" || schid == null) {
                alert("请选择学校");
                return false;
            }
            $('#dptname').val('');
            $('#savebtn').text("保存");
            $('#savebtn').attr('onclick', 'adddpt();');
            var params = '{"schid":"' + schid + '","stat":"1","selfid":"0","selid":"' + id + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "DepartInfo.aspx/getdpt",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    } else {
                        $('#dptp').html(data.d);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
            $('#dptname').focus();
        }
        //保存记录,并添加树节点
        function adddpt() {
            //获取名称
            var dptname = $('#dptname').val();
            if (dptname == "") {
                alert("部门名称不能为空");
                return false;
            }
            if (schid == "0" || schid == "" || schid == null) {
                alert("请选择学校");
                return false;
            }
            var pid = $('#dptp').val();
            var stat = $('#dptstat').val();

            var params = '{"schid":"' + schid + '","dptname":"' + dptname + '","pid":"' + pid + '","stat":"1"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "DepartInfo.aspx/adddpt",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (!isNaN(data.d)) {
                        var newNodes = [{ name: dptname, id: data.d, pId: pid }];
                        var node = treedeptObj.getNodeByParam("id", pid, null);
                        treedeptObj.addNodes(node, newNodes);
                        var nodesnew = treedeptObj.getNodeByParam("id", data.d, null);
                        addHoverDom('treedept', nodesnew);
                        alert("添加成功");
                        $("#dptname").val("");
                        $("#dptp option:first").prop("selected", "selected");
                        dptadd(pid);
                    }
                    else {
                        alert(data.d);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        };
        $(document).on("click", "#cancelbtn", function () {
            $("#dptname").val("");
            $("#dptp option:first").prop("selected","selected");
        });
        //部门排序上移
        $("#orderidbtn .MoveUp").click(function () {
            var CurrentDtpId = $("#savebtn").val();//当前部门的ID
            var SuperiorDtpPid = $("#dptp").val();//上级部门ID
            //var CuerentDtpOrderId = $("#orderidbtn .MoveUp").attr("orderid");//当前排序ID
            var moveType = $("#orderidbtn .MoveUp").attr("rel_id");
            var params = '{"dptid":"' + CurrentDtpId + '","moveType":"' + moveType + '"}';//将参数拼接为json对象字符串
            $.ajax({
                type: "POST",  //请求方式
                url: "DepartInfo.aspx/MoveUpDown",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "success") {
                        alert("上移成功");
                        //RoleAdd(1, 1, '2');
                        getdata();
                    }
                    else if (data.d == "success01") {
                        alert("已经到了第一个");
                    }
                    else {
                        alert(data.d);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        });
        //部门排序下移
        $("#orderidbtn .MoveDown").click(function () {
            var CurrentDtpId = $("#savebtn").val();//当前部门的ID
            var SuperiorDtpPid = $("#dptp").val();//上级部门ID
            //var CuerentDtpOrderId = $("#orderidbtn .MoveDown").attr("orderid");//当前排序ID
            var moveType = $("#orderidbtn .MoveDown").attr("rel_id");
            var params = '{"dptid":"' + CurrentDtpId + '","moveType":"' + moveType + '"}';//将参数拼接为json对象字符串
            $.ajax({
                type: "POST",  //请求方式
                url: "DepartInfo.aspx/MoveUpDown",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "success") {
                        alert("下移成功");
                        //RoleAdd(1, 1, '2');
                        getdata();
                    }
                    else if (data.d == "success01") {
                        alert("已经到了最后一个");
                    }
                    else {
                        alert(data.d);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        });
    </script>
</body>
</html>
