<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserShow.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.UserFuncSoure.UserShow" %>
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
    <style >
        /*输入框的颜色样式*/
         .form-group input[disabled], .form-group input:disabled,.form-group select:disabled,input:disabled {
            font-size:12px;
            color: #999999!important;
            background-color: #fff!important;
            border-style: none;
        }
         .label-info {
            background-color:white!important;            
        }
         .label {
            font-size:14px;
            color:black;
        }
         .bootstrap-tagsinput .tag {
            color:black;
        }
          /*部门的颜色*/
        .bootstrap-tagsinput .tag {
            color:#999999 !important;
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
            line-height:30px !important;
            font-size:12px !important;
        }
        /*内容上边距*/
        .content_box {
            padding-top: 24px;
        }
        /*学校名称等左边标签的样式*/
        .text_style {
            /*font-size: 15px !important;*/
            line-height: 30px !important;
            color: #000000 !important;
        }
        .text_style label {
            font-size: 14px !important;
         }
        /*去点上边多余的横线*/
        .page_box {
            border-bottom:none;
        }
        /*内容区域的字体大小颜色*/
        .lbl {
            font-size: 12px !important;
            color: #999999;
        }
        /*部门字段的上边距*/
        .department {
            padding-top:0px !important;
        }
         /*部门权限的左边距*/
        .tbox {
                padding-left:6px !important;
               
            }
        .bootstrap-tagsinput .tag [data-role='remove']::after {
            display:none;
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
       /*输入框的上下边距*/
        .input_box {
            padding:4px 10px;
        }
        /*当屏幕小于800px时样式调整（1月9号添加的）*/
        @media screen and (max-width: 768px) {
            .text-title {
                text-align:initial;
            }
            .tbox {
                padding-left:12px;
                padding-right:12px;
            }
            .table_box {
               float:none !important;
            }
            .table2 {
                padding-left:0px;
                padding-right:0px;
                margin-top:16px;
            }
            
        }
        .breadcrumb > li + li:before {
            content: none;
        }
        .bootstrap-tagsinput {
            border:none;
            box-shadow:none;
        }
    </style>
</head>

<body ontouchstart>

    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>
        <style type="text/css">
             /*单选框选中的颜色为#32A3CF*/
            input[type=checkbox].ace:disabled+.lbl::before, input[type=radio].ace:disabled+.lbl::before, input[type=checkbox].ace[disabled]+.lbl::before, input[type=radio].ace[disabled]+.lbl::before, input[type=checkbox].ace.disabled+.lbl::before, input[type=radio].ace.disabled+.lbl::before{color:#32A3CF;}
        </style>
        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
                <div class="breadcrumbs breadcrumb_box" id="breadcrumbs">
                    <script type="text/javascript">
                        try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
                    </script>

                     <ul class="breadcrumb breadcrumb_border">
                        <li>
                            <%--<i class="icon-home home-icon"></i>--%>
                            目前位置：
                        </li>
                        
                        <li class="active">教师及账号信息 </li>
                    </ul>
                     <!-- .breadcrumb -->
                </div>

                <div class="page-content">
                    <div class="page-header page_box" >
                       <%-- <h1>用户管理
								<small>
                                    <i class="icon-double-angle-right"></i>
                                    用户操作(学校:<%=schname %>)
                                </small>
                        </h1>--%>
                        <%--<div class="nav-search" id="nav-search">
                            <a class="btn btn-danger btn-sm pull-right" href="javascript:window.history.go(-1);">
                                <i class="icon-reply icon-only"></i>
                            </a>
                        </div>--%>
                        <div class="nav-search" id="nav-search">
                            <a class=" pull-right " href="javascript:window.history.go(-1);">
                                <i class="icon-reply icon-only"></i>
                                返回
                            </a>
                        </div>

                    </div>
                    <!-- /.page-header -->

                    <div class="row">
                        <div class="col-xs-12 col-sm-8 col-sm-offset-3">
                            <!-- PAGE CONTENT BEGINS -->

                            <form class="form-horizontal" role="form">
                                <div class="form-group form-inline no-margin-bottom">
<%--                                    <div class="col-sm-3">
                                        <div class="col-sm-2 no-padding-right">
                                            <label>编号:</label>
                                        </div>
                                        <div class="col-sm-10">
                                            <input type="text" id="usercode" placeholder="编号" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>--%>
                                    <div class="col-sm-3 text_style " >
                                        <div class="col-sm-4 no-padding-right text-right text-title">
                                            <label>姓 名:</label>
                                        </div>
                                        <div class="col-sm-8 input_box">
                                            <input type="text" id="usertname" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3 text_style">
                                        <div class="col-sm-4 no-padding-right text-right text-title">
                                            <label >性 别:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <div class="control-group col-xs-12 col-sm-12">
                                                <label>
                                                    <input name="usersex" type="radio" value="1" class="ace">
                                                    <span class="lbl">男</span>
                                                </label>&nbsp &nbsp &nbsp
                                                <label>
                                                    <input name="usersex" type="radio" value="0" class="ace">
                                                    <span class="lbl">女</span>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                  <%--  隐藏固话--%>
                                    <%--<div class="col-sm-3 text_style">
                                        <div class="col-sm-4 no-padding-right text-right text-title">
                                            <label>固话:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <input type="text" id="usertel" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>--%>
                                    <div class="col-sm-3 text_style">
                                        <div class="col-sm-4 no-padding-right text-right text-title">
                                            <label >联系方式:</label>
                                        </div>
                                        <div class="col-sm-8 input_box">
                                            <input type="text" id="usermobile" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group form-inline text_style no-margin-bottom">
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right text-title">
                                            <label>职 务:</label>
                                        </div>
                                        <div class="col-sm-8 input_box">
                                            <input type="text" id="userpst" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right text-title">
                                            <label>职 称:</label>
                                        </div>
                                        <div class="col-sm-8 input_box">
                                            <input type="text" id="usertitle" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3 text_style" style="display:none;">
                                        <div class="col-sm-4 no-padding-right text-right text-title">
                                            <label>任教科目:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <select id="usersub">
                                                <option value="">&nbsp;</option>
                                                <%=subs %>
                                            </select>
                                        </div>
                                    </div>
                                    
                                </div>
                               
                                <%--<div class="space-4"></div>--%>
                                <div class="form-group form-inline text_style no-margin-bottom">
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right text-title">
                                            <label >账 号:</label>
                                        </div>
                                        <div class="col-sm-8 input_box">
                                            <input type="text" id="username" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right text-title">
                                            <label>密 码:</label>
                                        </div>
                                        <div class="col-sm-8 no-padding-right input_box ">
                                            <input type="password" id="userpw" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right text-title">
                                            <label>账号状态:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <div class="control-group col-xs-12 col-sm-12 no-padding">
                                                <label>
                                                    <input name="userstat" type="radio" value="1" class="ace" />
                                                    <span class="lbl">正常</span>
                                                </label>&nbsp;&nbsp;
                                                <label>
                                                    <input name="userstat" type="radio" value="0" class="ace" />
                                                    <span class="lbl">停用</span>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                               <%-- <div class="space-4"></div>--%>
                                <div class="row tbox text_style no-margin-bottom">
                                    <label class="col-sm-1 control-label no-padding-right department">部 门:</label>
                                    <div class="col-sm-11" >
                                        <select id="tags-depts" multiple>
                                        </select>
                                        <!--
                                        <div class="btn-group">
                                            <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle">
                                                选择部门
													<span class="icon-caret-down icon-on-right"></span>
                                            </button>
                                            <ul id="treedept" class="dropdown-menu ztree">
                                            </ul>
                                        </div>-->
                                    </div>
                                </div>
                               <%-- <div class="space-8"></div>--%>
                                <div class="row tbox text_style">
                                    <label class="col-sm-1 control-label no-padding-right department" >权 限:</label>
                                    <div class="col-sm-11">
                                        <select id="tags-select" multiple>
                                        </select>

                                    </div>
                                </div>
                                <div class="space-2"></div>
                                <div class="row tbox">
                                    <div class="col-sm-11  pull-right no-padding-right  no-margin-right no-margin-left table_box">
                                    <div class="col-sm-3 no-padding-right no-padding-left">
                                        <div class="widget-box" style="margin: 0px;">
                                            <div class="widget-header widget-header-flat">
                                                <h4>权限名称</h4>
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
                                   
                                    <div class="col-sm-6  table2">
                                        <div class="widget-box" style="margin: 0px;">
                                            <div class="widget-header widget-header-flat">
                                                <h4>权限说明</h4>
                                            </div>

                                            <div class="widget-body">
                                                <div class="widget-main">
                                                    <div class="row">
                                                        <div class="col-sm-2 no-padding-right">
                                                            <label style="font-family:微软雅黑;font-size:12px !important;color:#444444">权限名称:</label>
                                                        </div>
                                                        <div class="col-sm-6">
                                                            <input type="text" id="rolename" placeholder="权限名称" />
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-4">
                                                        </div>
                                                        <div class="col-sm-8">
                                                            <ul id="rolestree" class="ztree"></ul>
                                                        </div>

                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
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

            <!-- /#ace-settings-container -->
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

    <script type="text/javascript">
        
        //下拉部门框点击屏蔽
        $('.dropdown-menu').click(function(e) {
            e.stopPropagation();
        });
        function getdrps() {
            //获得权限ID值串
            alert($("#tags-select").val());
            //获得ITEMEJSON
            $("#tags-select").tagsinput('items')
        }
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
                autoCheckTrigger: false,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  


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
                beforeClick: function (treeId, treeNode) {
                },
                //onCheck: zTreeOnCheck
            }
        };
        var treeNodes =<%=roles%>;        
        var treeObj;
        var treeroleObj;
        
        var schid=<%=schid%>;
        var systype=<%=systype%>;
        var dotype='<%=dotype%>';
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
        });       

        function addHoverDom(treeId, treeNode) {
            var sObj = $("#" + treeNode.tId + "_span");
            if (treeNode.editNameFlag || $("#editBtn_" + treeNode.tId).length > 0) return;
            addStr = "<span class='button edit'   id='editBtn_" + treeNode.tId + "' title='修改' onfocus='this.blur();'></span>";
            //addStr += "<span class='button edit'   id='editBtn_" + treeNode.tId + "'></span>";
            sObj.after(addStr);
            var btnedit = $("#editBtn_" + treeNode.tId);
            if (btnedit) btnedit.bind("click", function () {
                RoleEdit(treeId, treeNode);
            });
        };
        function removeHoverDom(treeId, treeNode) {
            $("#addBtn_" + treeNode.tId).unbind().remove();
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
        //编辑权限
        function RoleEdit(treeId, treeNode)
        {
            var params = '{"roleid":"' + treeNode.id + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "UserEdit.aspx/getrole",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d)
                    {
                        var dt=eval("(" + data.d + ")");
                        $('#rolename').val(dt[0].name);
                        var rolstr=dt[0].rolestr;
                        //权限目录树
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
                        var treeroleNodes =<%=funcstr%>;
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

                        treeroleObj= $.fn.zTree.init($("#rolestree"), settingrole, treeroleNodes);
                        var nodes = treeroleObj.getNodes();
                        if (nodes.length>0) {
                            treeroleObj.expandNode(nodes[0], true, false, true);
                        }                        
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        };
        

        

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
            $('input,select,textarea',$('.form-horizontal')).attr('readonly',true);
            $('input,select,textarea',$('.form-horizontal')).attr("disabled", "disabled");
        });
        //与选中联动
        function DeptzTreeOnCheck(event, treeId, treeNode) {
            if (treeNode.checked) {
                $('#tags-depts').tagsinput('add', { id: treeNode.id, text: treeNode.name });
            } else {
                $('#tags-depts').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
            }
        };

        //用户赋值
        var umodel=<%=umodelstr%>;
        var userid=0;
        if(umodel!="1")
        {
            //$('#usercode').val(umodel.UserNo);
            $('#usertname').val(umodel.UserTname);
            $('#usertel').val(umodel.Telno);
            $('#userpst').val(umodel.Postion);
            $('#usertitle').val(umodel.Title);
            $('#usermobile').val(umodel.Mobile);
            $('#username').val(umodel.UserName);
            $('#userpw').val(umodel.PassWord);
            $("input[name='usersex'][value="+umodel.Sex+"]").attr("checked",true);  
            $("input[name='userstat'][value="+umodel.AccStat+"]").attr("checked",true);
            if(umodel.SubCode==""){
                $("#usersub").css("display","none");
            }else{
                $('#usersub').val(umodel.SubCode);
            }
            userid=umodel.UserId;
            //usersub SubId  $("input[name='radioName'][checked]").val(); 
        }
    </script>
</body>
</html>
