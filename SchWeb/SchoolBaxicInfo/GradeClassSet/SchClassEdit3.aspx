<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchClassEdit3.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.GradeClassSet.SchClassEdit3" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>班级操作</title>
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
    <style type="text/css">
        .bootstrap-tagsinput {
            margin: 0px;
        }
    </style>
    <!-- ace settings handler -->

    <script src="../../assets/js/ace-extra.min.js"></script>

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

    <!--[if lt IE 9]>
		<script src="../../assets/js/html5shiv.js"></script>
		<script src="../../assets/js/respond.min.js"></script>
		<![endif]-->
    <script type="text/javascript">
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
        var gradeid = getPar("gradeid");
        if (gradeid == "") {
            gradeid = 1;
        }
    </script>
</head>
<body ontouchstart>
    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>
        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
                <div class="breadcrumbs" id="breadcrumbs">
                    <script type="text/javascript">
                        try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
                    </script>
                    <ul class="breadcrumb">
                        <li>
                            <i class="icon-home home-icon"></i>
                            <a href="#"></a>
                        </li>
                        <li>
                            <a href="#">班级管理</a>
                        </li>
                        <li class="active">班级信息</li>
                    </ul>
                    <!-- .breadcrumb -->
                </div>
                <div class="page-content">
                    <div class="page-header">
                        <h1>班级信息<small><i class="icon-double-angle-right"></i>新建班级操作(学校:<%=schname %>)</small></h1>
                        <div class="nav-search" id="nav-search">
                            <a class="btn btn-danger btn-sm pull-right" href="javascript:window.history.go(-1);">
                                <i class="icon-reply icon-only"></i>
                            </a>
                        </div>
                    </div>
                    <!-- /.page-header -->
                    <div class="row">
                        <div class="col-xs-12">
                            <form class="form-horizontal" role="form">
                                <div class="form-group form-inline">
                                    <div class="col-sm-12">
                                        <div class="col-sm-2">年级：</div>
                                        <div class="col-sm-3 no-padding-right">
                                            <select id="gradelist"><%=gradesdrp%></select><span id="gradeboss">年级领导：<%=gradeboss %></span>
                                        </div>


                                    </div>
                                </div>
                                <div class="form-group form-inline">
                                    <div class="col-sm-12">
                                        <div class="col-sm-2">
                                            班级名称:
                                        </div>
                                        <div class="col-sm-3 no-padding-right">
                                            <input type="text" id="txtname" placeholder="班级名称" class="" />
                                        </div>
                                        <div class="col-sm-2 text-right">班主任：</div>
                                            <div class="col-sm-2">
                                                <select class="form-control col-sm-2" id="ClassTec">
                                                        <option value="">选择老师</option>
                                                        <%=tec %>
                                                </select>
                                            </div>
                                            <div class="col-sm-2">
                                                <select class="form-control col-sm-2" id="ClassSub">
                                                    <option value="">选择科目</option>
                                                        <%=subsdrp %>
                                                </select>
                                            </div>
                                    </div>
                                </div>
                                <div class="form-group form-inline">
                                    <div class="col-sm-12">
                                        <div class="col-sm-2">
                                            <label>添加任课老师:</label>
                                        </div>
                                        <div class="col-sm-10 no-padding-right text-left">
                                            <!--<select id="selusers" multiple></select>-->
                                            <div class="btn-group">
                                                <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle" style="display: block; margin-bottom: 0px;">
                                                    添加
													<span class="icon-caret-down icon-on-right"></span>
                                                </button>
                                                <ul id="Treedpt" class="dropdown-menu ztree"></ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group form-inline">
                                    <div class="col-sm-7">
                                        <table id="data_table" class="table table-striped table-bordered table-hover col-sm-5">
                                            
                                            <tbody id="teclist"></tbody>
                                        </table>
                                    </div>
                                </div>
                                <!--任课教师列表-->
                                <div class="space-4"></div>
                                <div class="clearfix form-actions">
                                    <div class="col-md-offset-3 col-md-9" style="margin-left: 16%;">
                                        <button class="btn btn-info" id="btndo" type="button" onclick="saveuser()"><i class="icon-ok bigger-110"></i><%=btnname %></button>
                                        &nbsp; &nbsp; &nbsp;
                                        <button class="btn" type="reset"><i class="icon-undo bigger-110"></i>Reset</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.page-content -->
            </div>
            <!-- /.main-content -->
        </div>
        <!-- /#ace-settings-container -->
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

    <!-- Latest compiled and minified JavaScript -->
    <script src="../../assets/js/bootstrap-tagsinput.js"></script>
    <script src="../../assets/js/jquery.ztree.all-3.5.min.js"></script>
    
    <script src="../../assets/CustomFunction/DataVerification.js"></script>
    <!-- (Optional) Latest compiled and minified JavaScript translation files -->

    <script type="text/javascript">
        var schid='<%=schid%>';
        var gradecode='<%=gradecode%>';
        var classid='<%=classid%>';
        var dotype='<%=dotype%>';
        //赋值
        var umodel = <%=umodelstr%>;
        
        if(umodel!="1")
        {
            $('#txtname').val(umodel.ClassName);
            $('#gradelist').val(umodel.GradeCode);
            
            //$("input[name='iscity'][value="+umodel.IsCity+"]").attr("checked",true);  
            //$("input[name='schstat'][value="+umodel.Stat+"]").attr("checked",true);
            //usersub SubId  $("input[name='radioName'][checked]").val(); 
        }
        else
        {
            $('#gradelist').val(gradecode);
        }
        
    </script>

    <!--下拉列表框使用的js和css文件-开始-->
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
        //zNodesGradeManager：年级领导下拉列表框数据填充
        var zNodesDpt =<%=depts%>;
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
                beforeClick: function (treeId, treeNode) {
                    // $("#btnDropdownDepart").text(treeNode.name); 
                },
                onCheck: dptTreeOnCheck//onCheck：用于捕获 checkbox / radio 被勾选 或 取消勾选的事件回调函数。如果设置了 setting.callback.beforeCheck 方法，且返回 false，将无法触发 onCheck 事件回调函数。
            }
        };
        //Main入口文件
        $(document).ready(function(){
            treedpt = $.fn.zTree.init($("#Treedpt"), settingdpt, zNodesDpt);//下拉列表框数据加载初始化
            if(zNodesDpt)
            {
                for (var x in zNodesDpt) {
                    if(zNodesDpt[x].checked=='true')
                    {
                        //多选人员
                        $('#selusers').tagsinput('add', { id: zNodesDpt[x].id, text: zNodesDpt[x].name });
                        //人员列表
                        teclistadd(zNodesDpt[x].id,zNodesDpt[x].name,zNodesDpt[x].subcode,zNodesDpt[x].isms);
                        
                    }
    
                }
            }
            //treedpt.expandAll(true);
        });
        //人员删除触发树节点取消
        $("#selusers").on("itemRemoved", function (event) {
            var node = treedpt.getNodeByParam("id",event.item.id , null);
            treedpt.checkNode(node, false, false);
            teclistremove(event.item.id ,event.item.text,"teclist");//删除任课教师DOM
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
                teclistadd(treeNode.id,treeNode.name,treeNode.sub,treeNode.isms);//添加任课教师DOM
            } else {
                $("#selusers").tagsinput("remove", { id: treeNode.id, text: treeNode.name });
                teclistremove(treeNode.id,treeNode.name,"teclist",1);//删除任课教师DOM
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
        //获取部门
        $('#gradelist').change(function () {
            var selv = $('#gradelist').val();
            var params = '{"schid":"'+schid+'","gradecode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SchClassEdit3.aspx/getgradeboss",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $("#gradelist option").each(function () {
                        if ($(this).val() == selv) {
                            $(this).attr("selected", true);
                        }
                        else {
                            $(this).removeAttr("selected");
                        }
                        
                    });
                    //领导
                    $('#gradeboss').html('年级领导:'+data.d);
                },
                error: function (obj, msg, e) {
                }
            });
        });
    </script>
    <!--下拉列表框使用的js和css文件-结束-->
</body>
</html>
<script type="text/javascript">
    var subs='<%=subsdrp%>';
    var tec='<%=tec%>';
    
    //以下是动态添加任课教师DOM
    function teclistadd(id,name,sub,isms)
    {
        if($("#tecid_hid_" + id).length > 0) return;
        var txtteclist = '';
        txtteclist += "<tr id=\""+id+"\">";
        txtteclist += "<td><input type=\"hidden\" id=\"tecid_hid_"+id+"\" name=\"tecids\" value=\""+id+"\" /><div id=\"tecname_"+id+"\"  name=\"tecnames\" style=\"display:none;\">"+name+"</div>任课教师：<select id=\"tecid_"+id+"\">"+tec+"</select></td>";
        txtteclist += "<td>任教科目：<select id=\"tecsub_"+id+"\" name=\"tecsubs\"><option value=\"\">请选择</option>"+subs+"</select></td>";
        txtteclist += "<td>是否班主任：";
        if(isms=="1")
        {
            $("#ClassTec").val(id);
            $("#ClassSub").val(sub);
            txtteclist +="<input type=\"radio\" id=\"tecms_"+id+"\" name=\"tecmss\" checked=\"checked\">";
        }
        else
        {
            txtteclist +="<input type=\"radio\" id=\"tecms_"+id+"\"name=\"tecmss\">";
        }
        txtteclist += "</td>";
        txtteclist += "<td>";
        txtteclist += "<a href=\"javascript:void();\" class=\"tooltip-error\" onclick=\"deletes('"+id+"','"+name+"')\" data-rel=\"tooltip\" title=\"删除\">";
        txtteclist += "<span class=\"red\">";
        txtteclist += "<i class=\"icon-trash bigger-120\"></i>";
        txtteclist += "</span>";
        txtteclist += "</a>";
        txtteclist += "</td>";
        txtteclist += "</tr>";
        $("#teclist").append(txtteclist);
        $("#tecsub_"+id).val(sub);//alert($("#tecid_"+id).val());
        $("#tecid_"+id).val(id);//alert($("#tecid_"+id).val());
        
    }
    //以上是动态添加任课教师DOM

    //以下是动态删除任课教师DOM
    function teclistremove(id,name)
    {
        $("#teclist #"+id+"").remove();
    }
    //以上是动态删除任课教师DOM

    function deletes(id,name){alert(id);
        var node = treedpt.getNodeByParam("id",id, null);
        treedpt.checkNode(node, false, false);
        teclistremove(id,name,"teclist");//删除任课教师DOM
    }

    //以下数据收集存储
    function saveuser()
    {
        /*
        var txt = SubmitEmailCk("txtname");//调用邮箱验证函数，参数是操作对象的id名称
        if(txt==false){return false;}
        
        var txt2 = SubmitPhoneCk("txtname");//调用手机号码验证函数，参数是操作对象的id名称
        if(txt2==false){return false;}
        
        var txt2 = SubmitTelPhoneCk("txtname");//调用手机号码和固定电话验证函数，参数是操作对象的id名称
        if(txt2==false){return false;}
        */
        var gradecode= $("#gradelist").val();//获取下拉列表中的年级ID

        var classname= $("#txtname").val();//获取班级名称
        if(classname==null||classname=="")
        {
            alert("请填写班级名称");
            return;}
        var tecids=$("[name='tecids']");
        var tecnames=$("[name='tecnames']");
        var tecnames=$("[name='tecnames']");
        var tecsubs=$("[name='tecsubs']");
        var tecmss=$("[name='tecmss']");
        var sendstr="";
        if(tecids.length>0)
        {
            for (var i = 0; i < tecids.length; i++) {
                var ims="0";
                var dd=tecmss[i].checked;
                if(tecmss[i].checked)
                {
                    ims="1";
                }
                sendstr+=$(tecids[i]).val().substring(2)+','+$(tecnames[i]).html()+','+$(tecsubs[i]).val()+','+ims+'|';
            }
            sendstr=sendstr.substring(0,sendstr.length-1);
            alert(sendstr);
        }
        var params = "{\"dotype\":\"" + dotype + "\",\"schid\":\"" + schid + "\",\"gradecode\":\"" + gradecode +"\",\"classid\":\"" + classid +"\",\"classname\":\"" + classname +"\",\"tagsusers\":\"" + sendstr +"\"}";
        $.ajax({
            type: "POST",  //请求方式
            url: "SchClassEdit3.aspx/classsave",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if(data.d=='success')
                {
                    alert("操作成功");
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
    }
</script>