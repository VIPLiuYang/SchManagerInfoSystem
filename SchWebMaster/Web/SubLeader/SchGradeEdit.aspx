﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchGradeEdit.aspx.cs" Inherits="SchWebMaster.Web.SubLeader.SchGradeEdit" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>年级班级操作</title>
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
    <link href="../../Content/css/family.css" rel="stylesheet" />

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
    <script type="text/javascript">
        //检查文本框的值：必填,字母和数字的长度6-18位组合
        function checkTxt(o, reg,targetid) {
            var regu = reg;
            var re = new RegExp(regu);
            if (re.test($(o).val())) {
                $("#"+targetid).html("<span style=\"color:green;\">√</span>");
                //document.getElementById(targetid).innerHTML="<span style=\"color:green;\">√</span>";
                return true;
            } else {
                $("#"+targetid).html("<span style=\"color:red;\">×</span>");
                //document.getElementById(targetid).innerHTML="<span style=\"color:red;\">×</span>";
                $(o).tooltip('show');
                $(o).focus();
                return false;
            }
        }
    </script>

    <style>
        i {
            font-family: FontAwesome !important;
        }

        .spanziti {
            font-family: FontAwesome !important;
        }
        /*表格中的zree中的一级字体*/
        .dropdown-menu li a span:nth-child(2) {
            font-family: 微软雅黑;
            color: #666666 !important;
            font-size: 12px !important;
        }
        /*表格中的zree中的二级字体*/
        .dropdown-menu li ul a span:nth-child(2) {
            font-family: 微软雅黑;
            color: #999999 !important;
            font-size: 12px !important;
        }
        /*左边标题字体样式*/
        .ziti {
            font-family: 微软雅黑;
            font-size: 13px;
            color: #000000;
        }
        /*左边标题字体样式*/
        .ziti1 {
            font-family:微软雅黑;
            font-size:13px;
            color:#999999;
            margin-left:10px;
        }
        /*固定输入框字体样式*/
        input[disabled] {
            font-family: 微软雅黑;
            border: none;
            background: #ffffff !important;
            font-size: 12px;
            color: #999999 !important;
        }
        /*组长标签的背景色*/
        .label-info {
            background-color: white!important;
        }
        /*组长名称的颜色*/
        .bootstrap-tagsinput .tag {
            font-family: 微软雅黑;
            color: #999999 !important;
            font-size: 12px;
        }
        /*按钮中的字体样式*/
        .btn-style {
            font-family: 微软雅黑;
            font-size: 12px;
        }
        /*弹出框二级树状结构的字体颜色*/
        .form-inline ul li ul a span:nth-child(2) {
            color: #666666 !important;
        }

        .form-inline ul li a span:nth-child(2) {
            color: #666666;
        }
        /*弹出框树状结构的字体类型*/
        .ztree * {
            font-family: 微软雅黑 !important;
            font-size: 13px !important;
        }
        /*树状图中的字体颜色*/
        .ztree li a {
            color:#666;
        }
        /*树状结构点击后的状态*/
        .ztree li a.curSelectedNode {
            padding-top: 0px;
            background-color: #ffffff;
            color: black;
            height: 21px;
            opacity: 0.8;
            font-weight: bold;
        }

            .ztree li a.curSelectedNode span:nth-child(2) {
                color: #428bca !important;
            }
        /*选择的科目组长显示的输入框的内边距*/
        .bootstrap-tagsinput {
            padding:2px 4px  !important;
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
                    <!-- PAGE CONTENT BEGINS -->
                    <form class="form-horizontal" role="form">
                        <div class="row">

                            <div class="col-xs-12 no-padding-right">
                                <label class="ziti">年级名称:</label>
                                <input type="hidden" id="schgradeid" name="schgradeid" />
                                <label class="ziti1" id="schgradename"></label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 no-padding-right">
                                <label style="line-height: 30px" class="ziti">年级领导:</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 no-padding-right">
                                <select id="selusers" multiple></select>
                            </div>
                        </div>
                        <div class="space-4"></div>
                        <div class="row">
                            <div class="col-xs-6" style="font-family: 微软雅黑 !important; color: #f96161;">单击下列部门选择部门人员：</div>
                            <div class="col-xs-6" style="font-family: 微软雅黑 !important; color: #f96161;">点击选择年级领导：</div>
                        </div>
                        <div class="space-4"></div>
                        <div class="row">
                            <div class="col-xs-12 no-padding-right">
                                <div class="col-xs-6 no-padding-right" style="height: 300px; overflow: auto; border: 1px solid #999; border-radius: 5px;">
                                    <ul id="Treedpt" class="ztree" style="display: block;"></ul>
                                </div>
                                <div class="col-xs-6" style="height: 300px; overflow: auto; border: 1px solid #999; border-radius: 5px;">
                                    <ul id="TreeUser" class="ztree"></ul>
                                </div>
                            </div>
                        </div>
                        <div class="space-2"></div>
                        <div class="row">
                            <div class="col-xs-12 no-padding-right">
                                <button class="btn btn-info btn-sm btn-style" id="btndo" type="button" onclick="saveuser()" style="float: right;">
                                    <%=btnname %>
                                </button>
                            </div>
                        </div>
                    </form>
                    <!-- PAGE CONTENT ENDS -->
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
    <link rel="stylesheet" href="../../assets/css/bootstrap-tagsinput.css" />
    <script src="../../assets/js/bootstrap-tagsinput.js"></script>
    <script src="../../assets/js/jquery.ztree.all-3.5.min.js"></script>

    <!-- (Optional) Latest compiled and minified JavaScript translation files -->

    <script type="text/javascript">
        var schid='<%=schid%>';
        var dotype='<%=dotype%>';
        //赋值
        var umodel = <%=umodelstr%>;

        var schuser = <%=schuser%>;
        
        if(umodel!="1")
        {
            $("#schgradename").html(umodel.GradeName);
            $('#schgradeid').val(umodel.GradeId);
            
            //$("input[name='iscity'][value="+umodel.IsCity+"]").attr("checked",true);  
            //$("input[name='schstat'][value="+umodel.Stat+"]").attr("checked",true);
            //usersub SubId  $("input[name='radioName'][checked]").val(); 
        }
    </script>
    <script type="text/javascript">
        //数据收集存储
        function saveuser()
        {
            var schgradename=$("#schgradename").html().trim();//年级名称
            var schgradeid= $("#schgradeid").val();
            var tagsusers = $("#selusers").val();
            /*
            if(tagsusers==""||tagsusers==null){
                alert("请选择领导");
                return false;
            }*/
            //var iscity=$("input[name='iscity']:checked").val();
            //var schstat=$("input[name='schstat']:checked").val();    
            var params = "{\"dotype\":\"" + dotype + "\",\"schid\":\"" + schid + "\",\"gradename\":\"" + schgradename +"\",\"gradeid\":\"" + schgradeid +"\",\"tagsusers\":\"" + tagsusers +"\"}";
            $.ajax({
                type: "POST",  //请求方式
                url: "SchGradeEdit.aspx/gradesave",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d=='success')
                    {
                        alert("操作成功");
                        window.parent.closeEditCfmmodel("grader");
                    }else if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }
                    else
                    {
                        alert(data.d);
                    }
                },
                error: function (obj, msg, e) {
                    alert(obj);alert(msg);alert(e);
                }
            });
            //$("#EditCfmGrade",window.parent.document).modal('hide');
        }
    </script>
    <!--下拉列表框使用的js和css文件-开始-->
    <!--<link rel="stylesheet" href="/Content/css/bootstrapStyle.css" type="text/css" />
    <link rel="stylesheet" href="../../assets/css/metro.css" />-->

    <!--<script type="text/javascript" src="/Content/js/jquery.ztree.core.js"></script>
    <script type="text/javascript" src="/Content/js/jquery.ztree.excheck.js"></script>
    <script type="text/javascript" src="/Content/js/jquery.ztree.exedit.js"></script>-->

    <script type="text/javascript"> 
        //当点击下拉列表数据项（item）时，下拉列表框不被隐藏
        $('.dropdown-menu').click(function(e) {
            e.stopPropagation();
        });
        //初始化人员选择
        $("#selusers").tagsinput({
            itemValue: "id",
            itemText: "text",
        });
        
        var treedpt;
        var treedptuser;
        var settingdptUsers = 
        {
            view: 
            {
                //addHoverDom: addHoverDom,//用于当鼠标移动到节点上时，显示用户自定义控件，显示隐藏状态同 zTree 内部的编辑、删除按钮
                //removeHoverDom: removeHoverDom,//用于当鼠标移出节点时，隐藏用户自定义控件，显示隐藏状态同 zTree 内部的编辑。删除按钮.请务必与 addHoverDom 同时使用；
                selectedMulti: true,//设置是否允许同时选中多个节点。
                dblClickExpand: false,
                showLine: true,
                selectedMulti: true
            },
            check: 
            {
                enable: true,//设置 zTree 的节点上是否显示 checkbox / radio。参数说明：true / false 分别表示 显示 / 不显示 复选框或单选框
                chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
            },
            data: 
            {
                simpleData: 
                {
                    enable: true,//配置数据是否父子数据分级。如果enable值为true，则以树形结构输出；否则，依次按顺序平级的形式输出。
                    idKey: "id",
                    pIdKey: "pId",
                    checked: "checked",
                    rootPId: "0"
                }
            },
            edit: 
            {
                enable: false//配置添加、删除、编辑是否可以操作。如果enable值为true，则可以操作；否则，不可以操作。
            },
            callback: //回调函数
            {
                beforeClick: function (treeId, treeNode) {
                },
                onCheck: dptTreeOnCheck
            }
        }
        //zNodesGradeManager：年级领导下拉列表框数据填充
        var zNodesDpt =<%=depart%>;
        //settingGradeManager：配置年级领导下拉列表框属性
        var settingdpt = 
        {
            view: 
            {
                //addHoverDom: addHoverDom,//用于当鼠标移动到节点上时，显示用户自定义控件，显示隐藏状态同 zTree 内部的编辑、删除按钮
                //removeHoverDom: removeHoverDom,//用于当鼠标移出节点时，隐藏用户自定义控件，显示隐藏状态同 zTree 内部的编辑。删除按钮.请务必与 addHoverDom 同时使用；
                //selectedMulti: true,//设置是否允许同时选中多个节点。
                dblClickExpand: false,
                showLine: true,
                selectedMulti: true
            },
            check: 
            {
                enable: true,//设置 zTree 的节点上是否显示 checkbox / radio。参数说明：true / false 分别表示 显示 / 不显示 复选框或单选框
                chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
            },
            data: 
            {
                simpleData: 
                {
                    enable: true,//配置数据是否父子数据分级。如果enable值为true，则以树形结构输出；否则，依次按顺序平级的形式输出。
                    idKey: "id",
                    pIdKey: "pId",
                    checked: "checked",
                    rootPId: "0"
                }
            },
            edit: 
            {
                enable: false//配置添加、删除、编辑是否可以操作。如果enable值为true，则可以操作；否则，不可以操作。
            },
            callback: //回调函数
            {
                /*
                beforeClick参数说明：
                treeId--String--对应 zTree 的 treeId，便于用户操控
                treeNode--JSON--被单击的节点 JSON 数据对象
                clickFlag--Number--节点被点击后的选中操作类型
                */
                beforeClick: function (treeId, treeNode) {//alert($("#selusers").find("option:selected").text());
                    
                    
                    var menu_node1 = schuser.filter(function (e) { return e.DeptId == treeNode.id; }); 
                    
                    $("#TreeUser").css("display","block");
                    treedptuser = $.fn.zTree.init($("#TreeUser"), settingdptUsers, menu_node1);
                    treedptuser.checkAllNodes();
                    var sid = treeNode.id;
                    var selusersval = $("#selusers").val(); 
                    if(selusersval){
                        var selusersvallen = selusersval.length;
                        treedptuser.expandAll(true);
                        for(var i=0;i<selusersvallen;i++){
                            var enode=treedptuser.getNodeByParam("id", selusersval[i], null);
                            if(enode)
                            {
                                enode.checked=true;
                                //SelectNodeUser(selusersval[i]);//给选中的文本值添加背景
                                treedptuser.setChkDisabled(enode,false);//选中的不可选
                            }
                        }
                    }else{
                        treedptuser.checked=false;
                    }
                    
                }//,
                //onCheck: dptTreeOnCheck//onCheck：用于捕获 checkbox / radio 被勾选 或 取消勾选的事件回调函数。如果设置了 setting.callback.beforeCheck 方法，且返回 false，将无法触发 onCheck 事件回调函数。
            }
        };
        function SelectNodeUser(id) {
            var treeUserObj = $.fn.zTree.getZTreeObj("TreeUser");
            
            var treeusernode = treeUserObj.getNodeByParam("id", id, null);
            treeUserObj.expandNode(treeusernode, true, true, true);
            treeUserObj.selectNode(treeusernode,true);
        }
        function SelectNode(id) {
            var treeObj = $.fn.zTree.getZTreeObj("Treedpt");
            
            var treenode = treeObj.getNodeByParam("id", id, null);
            treeObj.expandNode(treenode, true, true, true);//展开 / 折叠 指定的节点
            treeObj.selectNode(treenode);
        }
        //Main入口文件
        $(document).ready(function(){
            treedpt = $.fn.zTree.init($("#Treedpt"), settingdpt, zNodesDpt);//年级下拉列表框数据加载初始化
            if(schuser)
            {
                for (var x in schuser) {
                    if(schuser[x].checked=='true')
                    {
                        $('#selusers').tagsinput('add', { id: schuser[x].id, text: schuser[x].name });

                        $("#TreeUser").css("display","block");
                        var menu_node1 = schuser.filter(function (e) { return e.DeptId == schuser[x].DeptId; }); 
                        treedptuser = $.fn.zTree.init($("#TreeUser"), settingdptUsers, menu_node1);
                        SelectNode(schuser[x].DeptId);

                    }
    
                }
            }
            
            //treedpt.expandAll(true);
            //var enode=treedpt.getNodeByParam("id", 0, null);
            //if(enode)
            //{
            //    treedpt.setChkDisabled(enode,true);
            //}
            /*
            var selusersval = $("#selusers").val(); var selusersvallen = selusersval.length;
            if(selusersval!=""){
                for(var i=0;i<selusersvallen;i++){
                    SelectNodeUser(selusersval[i]);
                }
            }*/
        });
        //人员删除触发树节点取消
        $("#selusers").on("itemRemoved", function (event) {
            //删除单条
            //var node = treedpt.getNodeByParam("id",event.item.id , null);
            //treedpt.checkNode(node, false, false);
            //删除多条
            //var nodes = treedpt.getNodesByParam("name",event.item.text,null);
            /*
            for (var i=0, l=nodes.length; i < l; i++) {
                treedpt.checkNode(nodes[i], false, false);
            }
            */
            var node = treedptuser.getNodeByParam("id",event.item.id , null);
            treedptuser.setChkDisabled(node,false);
            treedptuser.checkNode(node, false, false);
            // event.item: contains the item
        });
        
        
        /*
        GradeManagerTreeOnCheck：参数说明
        event--js event 对象--标准的 js event 对象
        treeId--String--对应 zTree 的 treeId，便于用户操控
        treeNode--JSON--被勾选 或 取消勾选的节点 JSON 数据对象
        */
        function dptTreeOnCheck(event, treeId, treeNode)
        {
            if (treeNode.checked) {
                $("#selusers").tagsinput("add", { id: treeNode.id, text: treeNode.name });
            } else {
                $("#selusers").tagsinput("remove", { id: treeNode.id, text: treeNode.name });
            }
        }
        var newCount = 1;
        /*
        addHoverDom参数说明：
        treeId--String--对应 zTree 的 treeId，便于用户操控
        treeNode--JSON--需要显示自定义控件的节点 JSON 数据对象
        */
        function addHoverDom(treeId, treeNode) {
            var sObj = $("#" + treeNode.tId + "_span");
            if (treeNode.editNameFlag || $("#addBtn_"+treeNode.tId).length>0) return;
            var addStr = "<span class='button add' id='addBtn_" + treeNode.tId
                + "' title='add node' onfocus='this.blur();'></span>";
            sObj.after(addStr);
            var btn = $("#addBtn_"+treeNode.tId);
            if (btn) btn.bind("click", function(){
                var zTree = $.fn.zTree.getZTreeObj("treeDemo");
                zTree.addNodes(treeNode, {id:(100 + newCount), pId:treeNode.id, name:"new node" + (newCount++)});
                return false;
            });
        };
        /*
        removeHoverDom：参数说明：
        treeId--String--对应 zTree 的 treeId，便于用户操控
        treeNode--JSON--需要隐藏自定义控件的节点 JSON 数据对象
        */
        function removeHoverDom(treeId, treeNode) {
            $("#addBtn_"+treeNode.tId).unbind().remove();
        };
        
       
    </script>
    <!--下拉列表框使用的js和css文件-结束-->


</body>
</html>
