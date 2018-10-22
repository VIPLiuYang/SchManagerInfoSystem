
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSoure.aspx.cs" Inherits="SchWebMaster.Web.UserFuncSoure.UserSoure" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>用户修改</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!-- basic styles -->

    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />

    <!--[if IE 7]>
		  <link rel="stylesheet" href="../../assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

    <!-- page specific plugin styles --> 

    <link rel="stylesheet" href="../../assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="../../assets/css/chosen.css" />

    <!-- fonts --> 

    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300" />

    <!-- ace styles -->

    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/bootstrap-tagsinput.css">
    <link rel="stylesheet" href="../../assets/css/metro.css" />


    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="../../assets/css/ace-ie.min.css" />
		<![endif]-->

    <!-- inline styles related to this page -->

    <!-- ace settings handler -->

    <script src="../../assets/js/ace-extra.min.js"></script>

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

    <!--[if lt IE 9]>
		<script src="../../assets/js/html5shiv.js"></script>
		<script src="../../assets/js/respond.min.js"></script>
		<![endif]-->
    <style>
        .label-info {
            background-color: white!important;
        }

         .label {
            font-size: 14px;
            color: black;
        }

         /*.bootstrap-tagsinput .tag {
            color: black;
        }*/
        
        i {
            font-family: FontAwesome !important;
        }
       /*输入框的字体颜色*/
        .form-group input {
            color: #999999!important;
           
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
            /*color: #333333;*/
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
            font-size:13px !important;
            color:#666666 !important;
        }
        /*返回按钮的样式*/
        .nav-search {
            line-height:20px !important;
            font-size:12px !important;
        }
        /*学校名称等左边标签的样式*/
        .text_style {
            line-height: 30px !important;
            color: #000000 !important;
        }

        .text_style label {
            font-family:微软雅黑  !important;
            font-size: 14px !important;
         }
        /*按钮中字的大小*/
        .btn_size{
            font-size:12px;
        }
         /*去掉上边多余的横线*/
        .page_box {
            border-bottom: none;
            padding-top: 0;
            padding-bottom: 0;
            margin-bottom: 0;
        }
        /*内容区域的字体大小颜色*/
        .lbl {
            font-size: 12px !important;
            color: #999999;
        }
        /*部门字段的上边距*/
        .department {
            padding-top: 0px !important;
        }
        /*密码输入框右边距*/
        .password {
            padding-right: 0px;
        }
        /*部门权限的左边距*/
        .tbox {
            padding-left: 6px !important;
            }
         /*部门的颜色*/
        .bootstrap-tagsinput .tag {
            color: #999999 !important;
            font-size:12px;
        }
        /*当屏幕小于800px时样式调整（1月9号添加的）*/
        @media screen and (max-width: 768px) {
            .text-title {
                text-align: initial;
            }

            .tbox {
                padding-left: 12px;
                padding-right: 12px;
            }

            .table_box {
                float: none !important;
            }

            .table2 {
                padding-left: 0px;
                padding-right: 0px;
                margin-top: 16px;
            }

            .btn {
                margin-top: 10px;
            }
        }
         /*表格标题栏字体大小，颜色*/
        .widget-header h4{
            font-family:微软雅黑;
            color:#444444 !important;
            font-weight:bold !important;
            font-size:13px !important;
            letter-spacing:1px !important;
        }
        
        /*表格中的zree中的字体*/
       .widget-body ul li a span:nth-child(2) {
            font-family:微软雅黑;
            color:#666666 !important;
            font-size:12px !important;
        }
        #SpecialAuthorityShow{display:none;}
        #SpecialAuthorityShow:hover{cursor:pointer;}
        #rolextdiv{display:none;}
        /*下拉选框 输入框的大小*/
         select, input {
            font-size:12px;
            color:#999999;
        }
        input[type="text"] {
            color:#999999 !important;
            font-size:12px !important;
        }
         /*input中placeholder的颜色*/
       input::-webkit-input-placeholder, textarea::-webkit-input-placeholder { /* WebKit*/  
            color:#999999;
            font-size:12px;
            font-family:微软雅黑;  
        }  
        input:-moz-placeholder, textarea:-moz-placeholder { /* Mozilla Firefox 4 to 18 */  
            color:#999999; 
            font-size:12px;
            font-family:微软雅黑; 
        }  
        input::-moz-placeholder, textarea::-moz-placeholder { /* Mozilla Firefox 19+ */  
            color:#999999; 
            font-size:12px;
            font-family:微软雅黑;  
        }  
        input:-ms-input-placeholder, textarea:-ms-input-placeholder { /* IE 10+ */  
            color:#999999; 
            font-size:12px;
            font-family:微软雅黑;  
        }
        /*输入框的内边距*/
        .input_box {
            padding:4px 10px;
        }
        .breadcrumb > li + li:before {
            content:"";
        }
        /*ztree父节点关联半勾选状态*/
        /*
        #treedept li span.button.chk.checkbox_false_part {
            background-position: -26px -47px;
            
        }
        */
        /*ztree父节点不关联勾选*/
        #treedept li span.button.chk.checkbox_false_part{
            background-position: -5px -25px;
        }
         /*每个标题字体样式*/
         label { 
            color:#333333;
            font-size:13px !important;
            font-family:微软雅黑 !important;
        }
          /*树状结构点击后的状态*/
         .ztree li a.curSelectedNode {
    padding-top: 0px;
    background-color: #ffffff;
    color: black;
    height: 21px;
    opacity: 0.8;
    font-weight:bold;
    }
            .ztree li a.curSelectedNode span:nth-child(2) { 
                color: #428bca !important;
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
                <div class="page-content">
                    <div class="space-10"></div>
                    <div class="row">
                        <div class="col-xs-12">
                            <!-- PAGE CONTENT BEGINS -->
                            <form class="form-horizontal" role="form">
                                <div class="form-inline">
                                    <div class="row">
                                        <div class="col-xs-1 no-padding text-right titleheight ">
                                            <label>系统编号:</label>
                                        </div>
                                        <div class="col-xs-3 no-padding-right">
                                            <input type="text" id="SysId"  data-toggle="tooltip" readonly="readonly" disabled="disabled" maxlength="10" />
                                        </div>
                                        <div class="col-xs-1 no-padding text-right titleheight ">
                                            <label style="color: red;">姓名(*):</label>
                                        </div>
                                        <div class="col-xs-3 no-padding-right">
                                            <input type="text" id="usertname" readonly="readonly" disabled="disabled" data-toggle="tooltip" title="1-10个汉字长度,必填" onblur="checkTxt(this,'^.{1,10}$')" maxlength="10" />
                                        </div>
                                        <div class="col-xs-1 no-padding-right text-right titleheight ">
                                            <label>性 别:</label>
                                        </div>
                                        <div class="col-xs-3 no-padding-right">
                                            <label>
                                                    <input name="usersex" type="radio" value="1" class="ace" style="margin-right: 6px; vertical-align: middle;"  readonly="readonly" >
                                                    <span class="lbl">男</span>
                                                </label>
                                                &nbsp &nbsp &nbsp
                                                <label>
                                                    <input name="usersex" type="radio" value="0" class="ace" readonly="readonly">
                                                    <span class="lbl">女</span>
                                                </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-4"></div>
                                <div class="form-inline">
                                    <div class="row">
                                        <div class="col-xs-1 no-padding-right text-right">
                                            <label class="department">部 门:</label>
                                        </div>
                                        <div id="depdisplay" class="col-xs-3 no-padding-right text-left">
                                            <select id="tags-depts" readonly="readonly" disabled="disabled" multiple></select>
                                        </div>
                                        <div class="col-xs-1 no-padding-right text-right">
                                            <label>账 号:</label>
                                        </div>
                                        <div class="col-xs-3 no-padding-right text-left">
                                            <input type="text" id="username" data-toggle="tooltip" title="字母和数字的长度6-18位组合" onblur="checkTxt(this,'(^$)|^([a-zA-Z0-9]{6,18})$')" maxlength="18" readonly="readonly" disabled="disabled" />
                                        </div>
                                        <div class="col-xs-1 no-padding text-right">
                                            <label>账号状态:</label>
                                        </div>
                                        <div class="col-xs-2 no-padding-right text-left">
                                            <label>
                                                    <input name="userstat" type="radio" value="1" class="ace" readonly="readonly" />
                                                    <span class="lbl">正常</span>
                                                </label>
                                                &nbsp;&nbsp;
                                                <label>
                                                    <input name="userstat" type="radio" value="0" class="ace" readonly="readonly" />
                                                    <span class="lbl">停用</span>
                                                </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-4"></div>
                                <div class="form-inline">
                                    <div class="row">
                                        <div class="col-xs-1 no-padding-right text-right">
                                            <label class="department">权 限:</label>
                                        </div>
                                        <div class="col-xs-11 no-padding-right text-left">
                                            <select id="tags-select" multiple></select>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-4"></div>



                                
                                <div class="form-inline" >
                                    <div class="row">
                                    <div class="col-xs-6  no-padding-right no-padding-left">
                                        <div class="widget-box" style="margin: 0px;">
                                            <div class="widget-header widget-header-flat">
                                                <h4>权限名称</h4>
                                                <a class="btn btn-link pull-right" href="javascript:RoleAdd()"><i class="icon-plus bigger-125" title="添加权限组" style="line-height: 28px"></i></a>
                                            </div>

                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <div class="row">
                                                        <ul id="treeroles" class="ztree"></ul>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xs-6 table2">
                                        <div class="widget-box" style="margin: 0px;">
                                            <div class="widget-header widget-header-flat">
                                                <h4>权限说明</h4>
                                            </div>
                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <div class="row">
                                                        <div class="col-xs-2 no-padding-right">
                                                            <label style="font-family:微软雅黑;font-size:12px !important;color:#444444">权限名称:</label>
                                                        </div>
                                                        <div class="col-xs-6">
                                                            <%--<input type="text" id="rolename" placeholder="权限名称" data-toggle="tooltip" title="必填,长度1-25汉字" onblur="checkTxt(this,'^.{1,10}$')"  />--%><input type="text" id="rolename" placeholder="权限名称"  maxlength="10"   />
                                                        </div>
                                                        <div class="col-xs-4">
                                                            <button id="savebtn" class="btn btn-sm btn-info btn_size" type="button">
                                                                <%--<i class="icon-ok"></i>--%>
                                                                保存
                                                            </button>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-xs-2">
                                                        </div>
                                                        <div class="col-xs-5">
                                                            <ul id="rolestree" class="ztree"></ul>
                                                        </div>
                                                        
                                                        <div class="col-xs-5" style="display:none;">
                                                            <p id="SpecialAuthorityShow">单击显示扩展权限&gt;&gt;</p>
                                                            <div id="rolextdiv">请勾选您要屏蔽的模块
                                                            <ul id="rolestreeext" class="ztree"></ul>
                                                                </div>
                                                        </div>
                                                        
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    </div>
                                </div>

                                <div class="space-4"></div>



                                <div class="clearfix form-actions" style="background-color:#ffffff;border-top:none;">
                                    <div class="col-xs-12 text-right">
                                        <button class="btn btn-info btn-sm btn_size" id="btndo" type="button" onclick="saveuser()">
                                            <%=btnname %>
                                        </button>
                                        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
										<button class="btn btn-sm btn_size" id="CancelBtn" type="reset">
                                                取消
                                        </button>
                                    </div>
                                </div>
                            </form>
                            <!-- PAGE CONTENT ENDS -->
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.page-content -->
            </div>
            <!-- /.main-content -->
        </div>
        <!-- /.main-container-inner -->
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
    <!-- Latest compiled and minified JavaScript -->
    <script src="../../assets/js/bootstrap-tagsinput.js"></script>
    <script src="../../assets/js/jquery.ztree.all-3.5.min.js"></script>
    <!-- (Optional) Latest compiled and minified JavaScript translation files -->
    <script type="text/javascript">

    </script>
    <script src="../../assets/js/jsencrypt.min.js"></script>
    <script type="text/javascript">
        
        //下拉部门框点击屏蔽
        $('.dropdown-menu').click(function(e) {
            e.stopPropagation();
        });
        /*
        function getdrps() {
            //获得权限ID值串
            alert($("#tags-select").val());
            //获得ITEMEJSON
            $("#tags-select").tagsinput('items')
        }*/
        //初始化权限选择
        $("#tags-select").tagsinput({
            itemValue: 'id',
            itemText: 'text',
        });
        
        //权限删除触发
        $('#tags-select').on('itemRemoved', function (event) {
            var node = treeObj.getNodeByParam("id", event.item.id, null);
            treeObj.checkNode(node, false, false);
            // event.item: contains the item
        });
        
        //角色树
        var setting = {
            check: {
                enable: true,
                //autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  


                chkboxType: { "Y": "ps", "N": "ps" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  


                chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
            },
            view: {
                addHoverDom: addHoverDom,
                removeHoverDom: removeHoverDom,
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
                    rootPId: "0"
                }
            },
            callback: {
                beforeClick: RoleEdit,
                onCheck: zTreeOnCheck
            }
        };
        var treeNodes =<%=roles%>;        
        var treeObj;
        var treeroleObj;//普通权限
        var treeroleextObj;//特殊权限
        
        var schid='<%=schid%>';
        var systype='<%=systype%>';
        var dotype='<%=dotype%>';
        //将添加改成保存
        $('#btndo').html("保存");
        var publicKey = "<%=publicKey%>";
        //publicKey = publicKey.replace(",","\r\n");
        var regv = new RegExp(",", "g"); //创建正则RegExp对象
        publicKey = publicKey.replace(regv, "\r\n");
        $(function () {
            if(treeNodes)
            {
                for (var x in treeNodes) {
                    if(treeNodes[x].checked=='true')
                    {
                        $('#tags-select').tagsinput('add', { id: treeNodes[x].id, text: treeNodes[x].name });
                    }
    
                }
            }
            treeObj = $.fn.zTree.init($("#treeroles"), setting, treeNodes);
            
            treeObj.expandAll(true);
            var enode=treeObj.getNodeByParam("id", 0, null);
            if(enode)
            {
                treeObj.setChkDisabled(enode,true);
            }
            //获取默认的第一个角色,调取相应的树
            if(treeNodes)
            {
                for (var x in treeNodes) {
                    if(treeNodes[x].checked=='true')
                    {
                        var enodes=treeObj.getNodeByParam("id", treeNodes[x].id, null);
                        //enodes.check_Focus='true';
                        treeObj.setting.callback.beforeClick(treeObj.setting.treeId, enodes);
                        treeObj.selectNode(enodes);
                        break;
                    }
    
                }
            }
        });
        var isadd = '<%=isadd%>';
        var isedit = '<%=isedit%>';
        var isdel = '<%=isdel%>';
        var islook = '<%=islook%>';
        function addHoverDom(treeId, treeNode) {
            var sObj = $("#" + treeNode.tId + "_span");
            if (treeNode.editNameFlag || $("#removeBtn_" + treeNode.tId).length > 0|| $("#editBtn_" + treeNode.tId).length > 0) return;
            var addStr="";
            if(isdel=="True")
            {
                addStr += "<span class='button remove' id='removeBtn_" + treeNode.tId
                        + "' title='移除' onfocus='this.blur();'></span>";
            }
            if(isedit=="True")
            {
                addStr += "<span class='button edit'   id='editBtn_" + treeNode.tId + "' title='修改' onfocus='this.blur();'></span>";
            }
            //if(isadd=="True")
            //{
            //    addStr += "<span class='button add' id='addBtn_" + treeNode.tId + "' title='添加' onfocus='this.blur();'></span>";
            //}
            //addStr += "<span class='button edit'   id='editBtn_" + treeNode.tId + "'></span>";
            sObj.after(addStr);
            //if(isadd=="True")
            //{
            //    var btn = $("#addBtn_" + treeNode.tId);
            //    if (btn) btn.bind("click", function () {
            //        RoleAdd(treeId, treeNode);
            //    });
            //}
            if(isedit=="True")
            {
                var btnedit = $("#editBtn_" + treeNode.tId);
                if (btnedit) btnedit.bind("click", function () {
                    RoleEdit(treeId, treeNode);
                });
            }
            if(isdel=="True")
            {
                var btnremove = $("#removeBtn_" + treeNode.tId);
                if (btnremove) btnremove.bind("click", function () {
                    RoleDel(treeId, treeNode);
                });
            }
        };
        function removeHoverDom(treeId, treeNode) {
            // $("#addBtn_" + treeNode.tId).unbind().remove();
            $("#removeBtn_" + treeNode.tId).unbind().remove();
            $("#editBtn_" + treeNode.tId).unbind().remove();
        };
        //与选中联动
        function zTreeOnCheck(event, treeId, treeNode) {
            if (treeNode.checked) {
                $('#tags-select').tagsinput('add', { id: treeNode.id, text: treeNode.name });
            } else {
                $('#tags-select').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
            }
        };
        //删除权限
        function RoleDel(treeId, treeNode)
        {
            var params = '{"schid":"' + schid + '","roleid":"' + treeNode.id + '"}';
            var msg = "您真的确定要删除吗？\n\n请确认！"; 
            if (confirm(msg)==true){ 
                $.ajax({
                    type: "POST",  //请求方式
                    url: "UserSoure.aspx/roledel",  //请求路径：页面/方法名字
                    data: params,     //参数
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if(data.d)
                        {
                            if(data.d=='success')
                            { 
                            
                                //再更新关联的
                                if(treeNode.checked)
                                {
                                    $('#tags-select').tagsinput('remove', { id: enode.id, text: enode.name });
                                }
                                //删除节点
                                treeObj.removeNode(treeNode);
                            }else if(data.d=="success01"){
                                alert("此权限正在使用，不允许删除");
                            }else if(data.d == "expire"){
                                window.location.href="../../LoginExc.aspx";
                            }else
                            {
                                alert(data.d);
                            }
                        }
                    },
                    error: function (obj, msg, e) {
                    }
                });
            }
        }
        //以下是编辑权限
        function RoleEdit(treeId, treeNode)
        {
            //$("#SpecialAuthorityShow").css("display","block");
            var params = '{"schid":"' + schid + '","roleid":"' + treeNode.id + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "UserSoure.aspx/getrole",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d)
                    {
                        var dt=eval("(" + data.d + ")");
                        $('#rolename').val(dt[0].name);
                        $('#savebtn').val(dt[0].id);
                        $('#savebtn').text("保存");
                        $('#savebtn').attr('onclick','saverole();'); 
                        var rolstr=dt[0].rolestr;
                        var rolextstr=dt[0].roleextstr;
                        //普通权限目录树
                        var settingrole = {
                            check: {
                                enable: true,
                                autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                                chkboxType: { "Y": "ps", "N": "ps" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                                chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
                            },
                            view: {
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
                                    rootPId: "",
                                    funcode:"funcode"//自定义字段,存功能码
                                }
                            },
                            callback: {
                                beforeClick: function (treeId, treeNode) {
                                },
                                onCheck: function (treeId, treeNode)
                                {
                                }
                            }
                        };
                        //特殊权限目录树
                        var settingroleext = {
                            check: {
                                enable: true,
                                autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                                chkboxType: { "Y": "s", "N": "s" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                                chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
                            },
                            view: {
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
                                    rootPId: "",
                                    funcode:"funcode"//自定义字段,存功能码
                                }
                            },
                            callback: {
                                beforeClick: function (treeId, treeNode) {
                                },
                                onCheck: function (treeId, treeNode)
                                {
                                }
                            }
                        };
                        //普通权限数据
                        var treeroleNodes =<%=funcstr%>;
                        //特殊权限数据
                        var treeroleextNodes =<%=MenuInfoExt%>;
                        //普通权限生成节点
                        if(treeroleNodes.length>0)
                        {
                            for (x in treeroleNodes)
                            {
                                var i=treeroleNodes[x].funcode;
                                //根据权限树生成对应节点
                                if(rolstr.substr(i-1,1)=='1')
                                {
                                    treeroleNodes[x].checked='true';
                                }
                            }
                                
                        }
                        ////特殊权限生成节点
                        //if(treeroleextNodes.length>0)
                        //{
                        //    for (x in treeroleextNodes)
                        //    {
                        //        var i=treeroleextNodes[x].funcode;
                        //        //根据权限树生成对应节点
                        //        if(rolextstr.substr(i-1,1)=='1')
                        //        {
                        //            treeroleextNodes[x].checked='true';
                        //        }
                        //    } 
                            
                        //}
                        //普通权限编辑初始化
                        treeroleObj= $.fn.zTree.init($("#rolestree"), settingrole, treeroleNodes);
                        //特殊权限编辑初始化
                        treeroleextObj = $.fn.zTree.init($("#rolestreeext"), settingroleext, treeroleextNodes);
                        //普通权限
                        var nodes = treeroleObj.getNodes();
                        if (nodes.length>0) {
                            treeroleObj.expandNode(nodes[0], true, false, true);
                        };
                        
                        //设置角色名称为焦点
                        $('#rolename').focus();
                    }else if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        };
        //以上是编辑权限

        //以下是保存权限树和角色名,并更新角色树节点的名称
        function saverole()
        {
            //获取角色名称
            var rolename=$('#rolename').val();
            if(rolename.length<1)
            {
                alert("请填写权限名!");
                return;
            }
            //获取对应ID
            var roleid=$('#savebtn').val();
            //获取普通权限所有选中节点的集合
            var sNodes = treeroleObj.getCheckedNodes(true);
            var rolstr="";
            for (var i = 0; i < 4000; i++) {
                rolstr+="0";
            }
            if(sNodes.length>0)
            {
                for (var x in sNodes) {
                    var star=rolstr.substr(0,sNodes[x].funcode-1);
                    var end=rolstr.substr(sNodes[x].funcode);
                    rolstr=star+'1'+end;
                }
            }
            //获取所有特殊权限选中节点的集合
            var sNodesext = treeroleextObj.getCheckedNodes(true);
            var rolextstr="";
            for (var i = 0; i < 50; i++) {
                rolextstr+="0";
            }
            if(sNodesext.length>0)
            {
                for (var x in sNodesext) {
                    var dd=sNodesext[x];
                    var half=dd.getCheckStatus();
                    if(half.half==true)
                        continue;
                    var starext=rolextstr.substr(0,sNodesext[x].funcode-1);
                    var endext=rolextstr.substr(sNodesext[x].funcode);
                    rolextstr=starext+'1'+endext;
                }
            }

            var params = '{"schid":"' + schid + '","roleid":"' + roleid + '","rolename":"' + rolename + '","rolestr":"' + rolstr + '","rolextstr":"' + rolextstr + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "UserSoure.aspx/uprole",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d=='success')
                    { 
                        //更新关联节点角色名称
                        var enode=treeObj.getNodeByParam("id", roleid, null);
                        if(enode!=null)
                        {
                            enode.name=rolename;
                            //再更新关联的
                            if(enode.checked)
                            {
                                $('#tags-select').tagsinput('remove', { id: enode.id, text: enode.name });
                                $('#tags-select').tagsinput('add', { id: enode.id, text: enode.name });  
                                enode.checked='true';
                            }
                            treeObj.updateNode(enode);                          
                            
                        }

                        alert("修改成功");
                    }else if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }
                    else
                    {
                        alert(data.d);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        };
        //以上是保存权限树和角色名,并更新角色树节点的名称

        //以下是添加角色功能函数（初始化）
        function RoleAdd(treeId, treeNode)
        {
            $('#rolename').val('');
            $('#savebtn').text("保存");
            $('#savebtn').attr('onclick','addrole();');   
            // $("#SpecialAuthorityShow").css("display","block");
            
            
            //添加角色时，普通权限目录树----配置项
            var settingrole = {
                check: {
                    enable: true,
                    autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                    chkboxType: { "Y": "ps", "N": "ps" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                    chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
                },
                view: {
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
                        rootPId: "",
                        funcode:"funcode"//自定义字段,存功能码
                    }
                },
                callback: {
                    beforeClick: function (treeId, treeNode) {
                    },
                    onCheck: function (treeId, treeNode)
                    {
                    }
                }
            };
            //添加角色时，特殊权限目录树----配置项
            var settingroleext = {
                check: {
                    enable: true,
                    autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                    chkboxType: { "Y": "ps", "N": "ps" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                    chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
                },
                view: {
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
                        rootPId: "",
                        funcode:"funcode"//自定义字段,存功能码
                    }
                },
                callback: {
                    beforeClick: function (treeId, treeNode) {
                    },
                    onCheck: function (treeId, treeNode)
                    {
                    }
                }
            };
            //添加角色时，普通权限树数据
            var treeroleNodes =<%=funcstr%>;
            //添加角色时，特殊权限树数据
            var treeroleextNodes = <%=MenuInfoExt%>;
            //添加角色时，初始化普通权限树
            treeroleObj= $.fn.zTree.init($("#rolestree"), settingrole, treeroleNodes);
            //添加角色时，初始化特殊权限树
            treeroleextObj= $.fn.zTree.init($("#rolestreeext"), settingroleext, treeroleextNodes);
            //普通权限
            var nodes = treeroleObj.getNodes();
            if (nodes.length>0) {
                treeroleObj.expandNode(nodes[0], true, false, true);
            };
            //特殊权限

            //设置角色文本焦点
            $('#rolename').focus();
        };
        //以上是添加角色功能函数

        //以下是显示被屏蔽的权限按钮
        /*$(document).on("click","#SpecialAuthorityShow",function(){
            if($("#rolextdiv").css("display")=="none"){
                $("#rolextdiv").css("display","block");
                $("#SpecialAuthorityShow").html("单击隐藏扩展权限&gt;&gt;");
            }else{
                $("#rolextdiv").css("display","none");
                $("#SpecialAuthorityShow").html("单击显示扩展权限&gt;&gt;");
            }
        });*/
        //以上是显示被屏蔽的权限按钮

        //以下是保存权限树和角色名,并更新角色树节点的名称
        function addrole()
        {
            //获取角色名称
            var rolename=$('#rolename').val();
            //判断角色名称是否为空
            if(rolename==null||rolename=="")
            {
                alert("请填写名称");
                return false;
            }
            if(rolename!="" ||rolename!=null){
                //检查权限名称，只能使用字母、数字和汉字
                var regrolename = /^[0-9a-zA-Z\u0391-\uFFE5]{1,25}$/;
                var resulrolename = checkTxt("#rolename",regrolename);
                if(resulrolename==false){
                    return false;
                }
            }
            //获取所有普通权限选中节点的集合
            var sNodes = treeroleObj.getCheckedNodes(true);
            var rolstr="";
            for (var i = 0; i < 4000; i++) {
                rolstr+="0";
            }
            if(sNodes.length>0)
            {
                for (var x in sNodes) {
                    var star=rolstr.substr(0,sNodes[x].funcode-1);
                    var end=rolstr.substr(sNodes[x].funcode);
                    rolstr=star+'1'+end;
                }
            }else{
                alert("请添加权限");
                return false;
            }
            //获取所有特殊权限选中节点的集合
            var sNodesext = treeroleextObj.getCheckedNodes(true);
            var rolextstr="";
            for (var i = 0; i < 50; i++) {
                rolextstr+="0";
            }
            if(sNodesext.length>0)
            {
                for (var x in sNodesext) {
                    var dd=sNodesext[x];
                    var half=dd.getCheckStatus();
                    if(half.half==true)
                        continue;
                    var starext=rolextstr.substr(0,sNodesext[x].funcode-1);
                    var endext=rolextstr.substr(sNodesext[x].funcode);
                    rolextstr=starext+'1'+endext;
                }
            }
            //打包传输数据，json
            var params = '{"schid":"' + schid + '","systype":"' + systype + '","rolename":"' + rolename + '","rolestr":"' + rolstr + '","roleextstr":"' + rolextstr + '"}';
            //向服务器发送请求
            $.ajax({
                type: "POST",  //请求方式
                url: "UserSoure.aspx/addrole",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(!isNaN(data.d))
                    { 
                        var newNodes = [{name:rolename,id:data.d}];
                        treeObj.addNodes(null, newNodes);
                        alert("添加成功");
                        RoleAdd();
                        $("#rolename").val("");
                        $("#rolename").blur();
                    }else if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }
                    else
                    {
                        alert(data.d);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
            
        };
        //以上是保存权限树和角色名,并更新角色树节点的名称

        //部门树及部门选择
        //初始化部门选择
        $("#tags-depts").tagsinput({
            itemValue: 'id',
            itemText: 'text',
        });
        //部门删除触发
        $('#tags-depts').on('itemRemoved', function (event) {
            var node = treedeptObj.getNodeByParam("id", event.item.id, null);
            treedeptObj.checkNode(node, false, false);
            // event.item: contains the item
        });
        var treedeptObj;
        var treeNodesdept =<%=depts%>;
        var settingdept = {
            check: {
                enable: true,
                //autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  


                chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  


                chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
            },
            view: {
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
                },
                onCheck: DeptzTreeOnCheck
            }
        };
        $(function () {
            if(treeNodesdept)
            {
                for (var x in treeNodesdept) {
                    if(treeNodesdept[x].checked=='true')
                    {
                        $('#tags-depts').tagsinput('add', { id: treeNodesdept[x].id, text: treeNodesdept[x].name });
                    }
    
                }
            }
            treedeptObj = $.fn.zTree.init($("#treedept"), settingdept, treeNodesdept);
            treedeptObj.expandAll(true);

            $("#treeroles .checkbox_false_full").css("display","none");

        });
        //与选中联动
        function DeptzTreeOnCheck(event, treeId, treeNode) {
            if (treeNode.checked) {
                $('#tags-depts').tagsinput('add', { id: treeNode.id, text: treeNode.name });
            } else {
                $('#tags-depts').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
            }
        };
        //num代表传入的数字，n代表要保留的字符的长度  
        function PreFixInterge(num, n) {
            return (Array(n).join(0) + num).slice(-n);
        }
        //用户赋值
        var umodel=<%=umodelstr%>;
        var userid=0;
        if(umodel!="1")
        {
            $("#SysId").val(PreFixInterge(umodel.UserId, 8));
            //$('#usercode').val(umodel.UserNo);
            $('#usertname').val(umodel.UserTname);
            //$('#usertel').val(umodel.Telno);
            $('#userpst').val(umodel.Postion);
            $('#usertitle').val(umodel.Title);
            $('#usermobile').val(umodel.Mobile);
            $('#username').val(umodel.UserName);
            if(umodel.UserName==""){
                $("#lblpwd").text("初始密码");
                $("#userpw").attr("disabled","disabled");
                $("#resetPwd").css("display","none");
                $("input[name='userstat']").attr("disabled","disabled");
                $("input[name='userstat'][value='1']").attr("checked",false);
            }else{
                if(umodel.PassWord=="******"){//初始密码
                    $("#lblpwd").text("初始密码");
                    $('#userpw').val("123456");
                    $('#userpw').attr("type","text");
                }else if(umodel.PassWord=="●●●●●●"){//非初始密码
                    $('#userpw').attr("type","password");
                    $("#resetPwd").css("display","block");
                    $('#userpw').val("●●●●●●");
                }
                $("#username").attr("disabled","disabled");
                
            }
            //$('#userpw').val(umodel.PassWord);
            $("input[name='usersex'][value="+umodel.Sex+"]").attr("checked",true);  
            $("input[name='userstat'][value="+umodel.AccStat+"]").attr("checked",true);
            $('#usersub').val(umodel.SubCode);
            userid=umodel.UserId;
            //usersub SubId  $("input[name='radioName'][checked]").val(); 
            if(umodel.PassWord!=""){
                $("#userpw").attr("disabled","disabled");
            }
        }else{
            $("#userpw").attr("disabled","disabled");
            $("#resetPwd").css("display","none");
            $("input[name='userstat']").attr("disabled","disabled");
            $("#lblpwd").text("初始密码");
            $("#userpw").val("");
        }
        function saveuser()
        {
            var encrypt = new JSEncrypt();
            encrypt.setPublicKey(publicKey);
            var usercode='00000';// $('#usercode').val();
            var usertname= $('#usertname').val();
            if($.trim(usertname)=="")//usercode==""||
            {
                alert('姓名不允许为空!');
                return false;
            }
            var username= $('#username').val();            
            var usertel= $('#usertel').val();
            if(typeof(usertel)=="undefined"){usertel=" ";}
            var userpst= $('#userpst').val();
            var usertitle= $('#usertitle').val();
            var usermobile= $('#usermobile').val();  
            var userpw="";
            //if($('#userpw').val()!=""){
            //    userpw= encrypt.encrypt($('#userpw').val());
            //}
            var usersex=$("input[name='usersex']:checked").val();
            var userstat=$("input[name='userstat']:checked").val();
            if(typeof(userstat) =="undefined"){userstat="";}
            var usersub= $('#usersub').val();
            var userdpts=$("#tags-depts").val();
            var userroles=$("#tags-select").val();
            if(userdpts==null){
                alert("请选择部门");
                return false;
            }
            //检查固话：固话号码
            /*
            var regusertel = /^\d{3}-\d{8}|\d{4}-\d{7,8}$/;
            var resulusertel = checkTxt("#usertel",regusertel);
            if(resulusertel==false){
                return false;
            }
            */
            
            var params = '{"dotype":"' + dotype + '","schid":"' + schid + '","systype":"' + systype + '","userid":"' + userid + '","usercode":"' + usercode + '","usertname":"' + usertname + '","usertel":"' + usertel + '","userpst":"' + userpst + '","usertitle":"' + usertitle + '","usermobile":"' + usermobile + '","username":"' + username + '","userpw":"' + userpw + '","usersex":"' + usersex + '","userstat":"' + userstat + '","usersub":"' + usersub + '","userdpts":"' + userdpts + '","userroles":"' + userroles + '"}';
            
            $.ajax({
                type: "POST",  //请求方式
                url: "UserSoure.aspx/usersave",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d=='success')
                    {
                        alert("操作成功");
                        window.parent.createuserclose();
                        //window.history.go(-1);
                        //window.location.href="UserInfo.aspx";
                    }else if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }
                    else
                    {
                        /*var tagstitval = $.trim($("#tags-depts").val());
                        var tagstitarr = tagstitval.split(',');
                        var tagstitlen = tagstitarr.length;
                        var tagstit="";
                        for(var i=0;i<tagstitlen;i++){
                            tagstit += $("#tags-depts option[value=" + tagstitarr[i] + "]").text()+"、";
                        }
                        tagstit = tagstit.substring(0,tagstit.length-1);*/
                        var extstr = data.d;
                        extstr = extstr.split(',');
                        alert("账号："+username+"以前是"+extstr[1]+"["+extstr[0]+"]占用，不能再使用！");
                        //alert(data.d);
                        if(data.d == "账号重复!"){
                            $("#username").focus();
                        }
                    }
                },
                error: function (obj, msg, e) {
                }
            });
            
        }
        function checkTxt(o,reg){
            var re = new RegExp(reg);
            if (re.test($(o).val())) {
                //判断账号是否为空
                var unameid = $(o).attr("id");
                if(unameid =="username"){
                    if($("#"+unameid).val()!="undefined"||$("#"+unameid).val()!=""){
                        $("input[name=\"userstat\"][value=\"1\"]").prop("checked","checked");
                        $("input[name=\"userstat\"]").removeAttr("disabled");
                        $("#lblpwd").text("初始密码");
                        $("#userpw").attr("type","text");
                        $("#userpw").val("123456");
                        $("#treeroles .checkbox_false_full").css("display","inline-block");
                    }
                    if($("#"+unameid).val()==""){
                        $("#userpw").val("");
                        $("input[name=\"userstat\"]").attr("disabled","disabled");
                        $("input[name=\"userstat\"][value=\"1\"]").removeAttr("checked");
                        $("#treeroles .checkbox_false_full").css("display","none");
                    }
                }
                return true;
            }else{
                $(o).tooltip('show');
                $(o).focus();
                return false;
            }
            
        }
        function ResetPwdClick(){
            $("#userpw").val("123456");
            $("#userpw").attr("type","text");
            $("#resetPwd").attr("style","background-color:none;");
            $("#resetPwd").addClass("nobg");
            $("#resetPwd a").attr("onclick","#");
            $("#resetPwd a").css("cursor","default");
            $("#resetPwd a:hover").css("text-decoration","none");
        }
        
        $(document).on("click","#CancelBtn",function(){
            //window.history.go(-1);
            window.parent.createuserclose();
        });
        $("#rolename").blur();
        $(document).ready(function(){
            
            if(umodel.UserName!=""){
                $("#treeroles .checkbox_false_full").css("display","inline-block");
            }
            //$(".bootstrap-tagsinput").css("margin","0px");
            $("#depdisplay .bootstrap-tagsinput input").attr("readOnly","readOnly"); //不可编辑，可以传值
            $("#depdisplay .bootstrap-tagsinput input").attr("disabled","disabled");//不可编辑，不可以传值
            RoleAdd();
        });
    </script>
    <style type="text/css">
        .nobg {
            height: 28px;line-height:28px;
            background-color: #abbac3!important;
        }
        #depdisplay .bootstrap-tagsinput{
                background-color: #F5F5F5!important;
        }
        #depdisplay .bootstrap-tagsinput span{
                background-color: #F5F5F5!important;
        }
        #depdisplay .bootstrap-tagsinput .tag [data-role="remove"]::after {
            content: none;
        }
    </style>
</body>
</html>