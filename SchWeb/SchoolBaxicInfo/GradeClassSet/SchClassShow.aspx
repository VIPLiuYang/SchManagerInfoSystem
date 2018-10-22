<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchClassShow.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.GradeClassSet.SchClassShow" %>

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
         .titleheight { 
            line-height:30px;
        }
         .titlebianju { 
            margin-left:10px;
        }
         /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }

        i {
            font-family: FontAwesome !important;
        }
         .spanziti { 
            font-family: FontAwesome !important;

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
    <script type="text/javascript">
        //检查文本框的值：必填,字母和数字的长度6-18位组合
        function checkTxt(o, reg,targetid) {
            var regu = reg;
            var re = new RegExp(regu);
            if (re.test($(o).val())) {
                //$("#"+targetid).html("<span style=\"color:green;\">√</span>");
                //document.getElementById(targetid).innerHTML="<span style=\"color:green;\">√</span>";
                return true;
            } else {
                //$("#"+targetid).html("<span style=\"color:red;\">×</span>");
                //document.getElementById(targetid).innerHTML="<span style=\"color:red;\">×</span>";
                $(o).tooltip('show');
                $(o).focus();
                return false;
            }
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
                <div class="page-content">
                    <div class="page-header">
                        <h1><small><i class="icon-double-angle-right"></i><%=btnname %>班级(学校:<%=schname %>)</small></h1>
                    </div>
                    <!-- /.page-header -->
                    <!---->
                    <style type="text/css">
                        .tr {
                            margin-bottom: 10px;
                        }
                    </style>
                    <div class="form-horizontal">

                        <div class="form-group form-inline">
                            <div class="col-xs-12">
                                <div class="row">
                                    <div class="col-xs-2 text-right titleheight" >年级:</div>
                                    <div class="col-xs-8 no-padding-right">
                                        <select id="gradelist" readonly="readonly" disabled="disabled"><%=gradesdrp%> </select><span id="gradeboss" class="titlebianju">年级领导：<%=gradeboss %></span>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="form-group form-inline">
                            <div class="col-xs-12">
                                <div class="row">
                                    <div class="col-xs-2 text-right titleheight" >班级名称:</div>
                                    <div class="col-xs-5 no-padding-right">
                                        <input type="text" id="txtname" placeholder="班级名称" title="必填,只能输入中文、数字和字母" onblur="checkTxt(this,'^[0-9a-zA-Z]|[\u0391-\uFFE5]+$','schgradenametxt')" class="drpsub" readonly="readonly" disabled="disabled" />
                                    </div>
                                    <div class="col-xs-2 no-padding titleheight" id="schgradenametxt" ></div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group form-inline">
                            <div class="col-xs-12">
                                <div class="row">
                                    <div class="col-xs-2 text-right titleheight" >班主任:</div>
                                    <div class="col-xs-10">
                                        <div class="row">
                                            <div class="col-xs-5">
                                                <div class="btn-group btn-block">
                                                    <button data-toggle="dropdown" id="btntree_1" name="tecnames" class="btn btn-info btn-sm dropdown-toggle btn-block" onclick="dptuserdrp(this,'tree_1');" readonly="readonly" disabled="disabled">
                                                        选择老师
													<span class="icon-caret-down icon-on-right spanziti"></span>
                                                    </button>
                                                    <ul class="dropdown-menu dropdown-info pull-left ztree" id="tree_1">
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="col-xs-5">
                                                <select class="form-control col-sm-2" name="tecsubs" id="drpsub_1" readonly="readonly" disabled="disabled">
                                                    <option value="">选择科目</option>
                                                    <%=subsdrp %>
                                                </select>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="space-6"></div>
                                <div class="row">
                                    <div class="col-xs-2 text-right titleheight" >科任老师:</div>
                                    <div class="col-xs-10" id="TeacherAddList">
                                       
                                        <div class="row" id="initdiv">
                                            <div class="col-xs-5">
                                                <select class="form-control col-sm-2" name="tecsubs" id="drpsub_0" readonly="readonly" disabled="disabled">
                                                    <option value="">选择科目</option>
                                                    <%=subsdrp %>
                                                </select>
                                            </div>
                                            <div class="col-xs-5">
                                                <div class="btn-group btn-block">
                                                    <button data-toggle="dropdown" id="btntree_0" name="tecnames0" class="btn btn-info btn-sm dropdown-toggle btn-block" onclick="dptuserdrp(this,'tree_0');" readonly="readonly" disabled="disabled">
                                                        选择老师
													<span class="icon-caret-down icon-on-right spanziti"></span>
                                                    </button>
                                                    <ul class="dropdown-menu dropdown-info pull-left ztree" id="tree_0">
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="col-xs-1" style="padding: 6px 12px;">
                                               
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-20"></div>
                                <div class="row tr">
                                    <div class="col-xs-12 text-right">
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--//.form-horizontal-->
                    <!--//-->
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

    <!-- (Optional) Latest compiled and minified JavaScript translation files -->
    <script type="text/javascript">
        var schid='<%=schid%>';
        var gradecode='<%=gradecode%>';
        var classid='<%=classid%>';
        var dotype='<%=dotype%>';
        var subs='<%=subsdrp%>';
        var tecs='<%=depts%>';
        var deptss = <%=deptss%>;
        var i = 2;
        function DelTeacherSubject(id) {
            alert(id);
            //$("#row" + id).remove();
        }
    
        $(document).ready(function () {
            $("#TeacherAddDom").on('click', function () {
                teclistadd(i,"","");
                i++;
            });

            $(document).on("click", ".deltecdiv", function () {
                var rel = $(this).attr("rel");
                $("#row" + rel).remove();
            });
            
            $(document).on("change", ".drpsub", function () {
                var selv = $(this).val();
                
                // 
            });
        });
        
    </script>
    <script type="text/javascript">
    

        //以下是动态添加任课教师DOM
        function teclistadd(id,sub,isms,name)
        {//alert(name);
            //if($("#sub_" + id).length > 0) return;
            if(isms==1)
            {
                $('#btntree_1').attr("value",id);
                $('#btntree_1').attr("valuename",name);
                $('#btntree_1').html(name+'<span class="icon-caret-down icon-on-right"></span>');
                //给科目下拉赋值
                $("#drpsub_1").val(sub);
                return;
            }
            var txtteclist = "";
            
            txtteclist +='<div class="row" id="row' + i  +'">';
            txtteclist +='<div class="col-xs-5">';
            txtteclist +='<select name="tecsubs" class="form-control drpsub" id="drpsub_' + i + '" readonly="readonly" disabled="disabled" >';
            txtteclist +='<option value="">请选择科目</option>';
            txtteclist +=subs;
            txtteclist +="</select>";
            txtteclist +="</div>";
            txtteclist +='<div class="col-xs-5">';
            txtteclist +='<div class="btn-group btn-block">';
            txtteclist +='<button data-toggle="dropdown" id="btntree_' + i  +'" name="tecnames" class="btn btn-info btn-sm dropdown-toggle btn-block" onclick="dptuserdrp(this,\'tree_' + i  +'\');" readonly="readonly" disabled="disabled">';
            txtteclist +='请选择老师';
            txtteclist +='<span class="icon-caret-down icon-on-right"></span>';
            txtteclist +='</button>';
            txtteclist +='<ul class="dropdown-menu dropdown-info pull-left ztree" id="tree_' + i  +'">';
            txtteclist +='</ul>';
            txtteclist +='</div>';

            txtteclist +='</div>';
            txtteclist +='<div class="col-xs-1">';
            //txtteclist +='<a href="#" class="tooltip-error deltecdiv" data-rel="tooltip" title="删除" rel="' + i  +'">';
           // txtteclist +='<span class=\"red\">';
            //txtteclist +='<i class="icon-trash bigger-120"></i>';
            //txtteclist +='</span>';
            //txtteclist +='</a>';
            txtteclist +='</div>';
            txtteclist +='</div>';
            txtteclist +='<div class="space-2"></div>';

            $("#initdiv").before(txtteclist);
            if(sub=="")
            {
                //给btn赋值
                $('#btntree_'+i).attr("value",$('#btntree_0').attr("value"));
                $('#btntree_'+i).attr("valuename",$('#btntree_0').attr("valuename"));
                $('#btntree_'+i).html($('#btntree_0').html());
                //给科目下拉赋值
                $("#drpsub_"+i).val($("#drpsub_0").val());
            }
            else
            {
                //给btn赋值
                $('#btntree_'+i).attr("value",id);
                $('#btntree_'+i).attr("valuename",name);
                $('#btntree_'+i).html(name+'<span class="icon-caret-down icon-on-right"></span>');
                //给科目下拉赋值
                $("#drpsub_"+i).val(sub);
            }
            i++;
            $('.dropdown-menu').click(function(e) {
                e.stopPropagation();
            });
        }
        //以上是动态添加任课教师DOM
    
        //以下数据收集存储
        function saveuser()
        {
            var gradecode= $("#gradelist").val();//获取下拉列表中的年级ID

            var classname= $("#txtname").val();//获取班级名称
            if(classname==null||classname=="")
            {
                alert("请填写班级名称");
                return;
            }
            var resultxt = checkTxt("#txtname",'^[0-9a-zA-Z]|[\u0391-\uFFE5]+$','schgradenametxt')
            if(resultxt==false){
                return false;
            }
            var tecnames=$("[name='tecnames']");
            var tecsubs=$("[name='tecsubs']");
            var sendstr="";
            if(tecnames.length>0)
            {
                //合并任课教师信息字符串
                for (var i = 0; i < tecnames.length; i++) {
                    if(i==0)
                    {
                        sendstr+=$(tecnames[i]).attr("value")+','+$(tecsubs[i]).val()+','+$(tecnames[i]).attr("valuename")+',1|';
                    }
                    else{
                        if($(tecnames[i]).attr("value")!=""&&$(tecsubs[i]).val()!="")
                        {
                            var tempstr=$(tecnames[i]).attr("value")+','+$(tecsubs[i]).val()+','+$(tecnames[i]).attr("valuename")+',0|';

                            if(sendstr.indexOf(tempstr)<0)
                            {
                                sendstr+=tempstr;
                            }
                        }
                    }
                }
                sendstr=sendstr.substring(0,sendstr.length-1);//去掉最后一个字符
                //alert(sendstr);
            }
            var params = "{\"dotype\":\"" + dotype + "\",\"schid\":\"" + schid + "\",\"gradecode\":\"" + gradecode +"\",\"classid\":\"" + classid +"\",\"classname\":\"" + classname +"\",\"tagsusers\":\"" + sendstr +"\"}";
            $.ajax({
                type: "POST",  //请求方式
                url: "SchClassE.aspx/classsave",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d=='success')
                    {
                        alert("操作成功");
                        window.parent.closeclassmodel();
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
    <script type="text/javascript">
        
        //赋值
        var umodel = <%=umodelstr%>;
        
        if(umodel!="1")
        {
            $('#txtname').val(umodel.ClassName);
            $('#gradelist').val(umodel.GradeCode);
            
            if(deptss)
            {
                for (var x in deptss) {
                    //人员列表
                    teclistadd(deptss[x].id,deptss[x].subcode,deptss[x].isms,deptss[x].name);
                }
            }
        }
        else
        {
            $('#gradelist').val(gradecode);
        }
    </script>
    <script>
        $('.dropdown-menu').click(function(e) {
            e.stopPropagation();
        });
        var treedpt;
        //部门人员下拉
        var zNodesDpt =<%=deptusers%>;
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
                selectedMulti: false
            },
            check: 
            {
                enable: true,//设置 zTree 的节点上是否显示 checkbox / radio。参数说明：true / false 分别表示 显示 / 不显示 复选框或单选框
                chkboxType: { "Y": "ps", "N": "ps" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
                chkStyle: "radio",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效] 
                radioType: "all",
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
        function dptuserdrp(btn,drptreeid)
        {
            treedpt = $.fn.zTree.init($("#"+drptreeid), settingdpt, zNodesDpt);//下拉列表框数据加载初始化
            //并附加选中
            var id=$(btn).attr("value");
            var nodep = treedpt.getNodeByParam("id",id, null);
            treedpt.checkNode(nodep, true, false);
        }
        function dptTreeOnCheck(event, treeId, treeNode)
        {
            if (treeNode.checked) {
                $('#btn'+treeId).attr("value",treeNode.id);
                $('#btn'+treeId).attr("valuename",treeNode.name);
                $('#btn'+treeId).html(treeNode.name+'<span class="icon-caret-down icon-on-right"></span>');
                
            } else {
                $('#btn'+treeId).attr("value","");
                $('#btn'+treeId).attr("valuename","");
                $('#btn'+treeId).html('选择老师<span class="icon-caret-down icon-on-right"></span>');
            }
        }
    </script>
    <style type="text/css">
        .DelTeacherSubject {
            line-height: 30px;
        }
    </style>
</body>
</html>