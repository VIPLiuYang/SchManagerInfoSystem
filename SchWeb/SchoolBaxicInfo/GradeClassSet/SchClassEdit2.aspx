<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchClassEdit2.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.GradeClassSet.SchClassEdit2" %>

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
        .tianjiabianju { 
            padding:6px;
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
                                    <div class="col-xs-2 text-right">年级:</div>
                                    <div class="col-xs-8 no-padding-right">
                                        <select id="gradelist"><%=gradesdrp%></select><span id="gradeboss">年级领导：<%=gradeboss %></span>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="form-group form-inline">
                            <div class="col-xs-12">
                                <div class="row">
                                    <div class="col-xs-2 text-right">班级名称:</div>
                                    <div class="col-xs-5 no-padding-right">
                                        <input type="text" id="txtname" placeholder="班级名称" class="drpsub" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-group form-inline">
                            <div class="col-xs-12">
                                <div class="row">
                                    <div class="col-xs-2 text-right">班主任:</div>
                                    <div class="col-xs-10">
                                        <div class="row">
                                            <div class="col-xs-5">

                                                <select class="form-control col-sm-2 drptec" onchange="drps(this)" id="ClassTec">
                                                    <option value="">选择老师</option>
                                                    <%=depts %>
                                                </select>
                                            </div>
                                            <div class="col-xs-5">
                                                <select class="form-control col-sm-2" id="ClassSub">
                                                    <option value="">选择科目</option>
                                                    <%=subsdrp %>
                                                </select>
                                            </div>
                                            
                                        </div>
                                    </div>
                                </div>
                                <div class="space-2"></div>
                                <div class="row">
                                    <div class="col-xs-2 text-right">科任老师:</div>
                                    <div class="col-xs-10" id="TeacherAddList">
                                        <!--<div class="row" id="row1">
                                            <div class="col-xs-5">
                                                <input type="hidden" name="ids" />
                                                <select class="form-control drpsub" name="tecsub" id="sub_1">
                                                    <option value="">请选择</option>
                                                    <%//=subsdrp %>
                                                </select>
                                            </div>
                                            <div class="col-xs-5">
                                                <select class="form-control drptec" name="tecnames" onchange="drps(this)" id="tec_1">
                                                    <option value="">请选择</option>
                                                    <%//=depts %>
                                                </select>
                                            </div>
                                            <div class="col-xs-1 DelTeacherSubject" rel="1">
                                                <a href="#" class="tooltip-error DelTeacherSubject" data-rel="tooltip" title="删除">
                                                    <span class="red">
                                                        <i class="icon-trash bigger-120"></i>
                                                    </span>
                                                </a>
                                            </div>
                                        </div>-->
                                        <div class="space-2"></div>
                                        <div class="row" id="initdiv">
                                            <div class="col-xs-5">
                                                <input type="hidden" name="ids" />
                                                <select class="form-control" name="tecsub" onchange="drpsub(this)" id="sub_0">
                                                    <option value="">请选择</option>
                                                    <%=subsdrp %>
                                                </select>
                                            </div>
                                            <div class="col-xs-5">
                                                <select name="tecnames" class="form-control" id="tec_0" onchange="drps(this)">
                                                    <option value="">请选择</option>
                                                    <%=depts %>
                                                </select>
                                            </div>
                                            <div class="col-xs-1 tianjiabianju" >
                                                <a href="javascript:void();" class="glyphicon glyphicon-plus" id="TeacherAddDom" title="添加"></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-8"></div>
                                <div class="row tr">
                                    <div class="col-xs-12 text-right">
                                        <button type="button" class="btn  btn-primary" onclick="saveuser()"><%=btnname %></button>&nbsp;&nbsp;&nbsp;&nbsp;
                                
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

            $(document).on("click", ".DelTeacherSubject", function () {
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
        function teclistadd(id,sub,isms)
        {//alert(name);
            //if($("#sub_" + id).length > 0) return;
            if(isms==1)
            {
                $('#ClassTec').val("u_"+id);
                $('#ClassSub').val(sub);
                return;
            }
            var txtteclist = "";
            
            txtteclist += "<div class=\"row\" id=\"row" + id  + "_"+sub+"\">";
            txtteclist += " <input type=\"hidden\" name=\"ids\" />";
            txtteclist += "  <div class=\"col-xs-5\">";
            txtteclist += "      <select name=\"tecsub\" class=\"form-control drpsub\" id=\"sub_" + id + "_"+sub+"\" >";
            txtteclist += "         <option value=\"\">请选择</option>";
            txtteclist += "          "+subs+"";
            txtteclist += "      </select>";
            txtteclist += "  </div>";
            txtteclist += "  <div class=\"col-xs-5\">";
            txtteclist += "      <select name=\"tecnames\" class=\"form-control drptec\" onchange=\"drps(this)\" id=\"tec_" + id  + "_"+sub+"\">";
            txtteclist += "         <option value=\"\">请选择</option>";
            txtteclist += "          "+tecs+"";
            txtteclist += "      </select>";
            txtteclist += "  </div>";
            txtteclist += " <div class=\"col-xs-1 \">";
            txtteclist += "     <a href=\"#\" class=\"tooltip-error DelTeacherSubject\"\ data-rel=\"tooltip\" title=\"删除\" rel=\"" + id  + "_"+sub+"\">";
            txtteclist += "         <span class=\"red\">";
            txtteclist += "             <i class=\"icon-trash bigger-120\"></i>";
            txtteclist += "         </span>";
            txtteclist += "     </a>";
            txtteclist += " </div>";
            txtteclist += "</div>";
            txtteclist += "<div class=\"space-2\"></div>";
            //$("#teclist").append(txtteclist);
            $("#initdiv").before(txtteclist);
            if(sub=="")
            {
                $("#tec_"+id + "_"+sub).val($("#tec_0").val());
                $("#sub_"+id + "_"+sub).val($("#sub_0").val());
            }
            else
            {
                $("#tec_"+id + "_"+sub).val("u_"+id);
                $("#sub_"+id + "_"+sub).val(sub);
            }
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
            var tecnames=$("[name='tecnames'] option:selected");
            var tecsubs=$("[name='tecsub'] option:selected");
            var ids=$("[name='ids']");
            var ClassTec = $("#ClassTec option:selected").val();//获取班主任姓名
            var ClassTectxt = $("#ClassTec option:selected").text();//获取班主任姓名
            var ClassSub = $("#ClassSub").val();//获取版主任任教科目
            var Sub="";
            var Tec="";
            var sendstr="";
            if(ids.length>0)
            {
                //合并任课教师信息字符串
                for (var i = 0; i < ids.length; i++) {
                    if($(tecnames[i]).val() !="" || $(tecsubs[i]).val() !==""){
                        sendstr+=$.trim($(tecnames[i]).val())+','+$(tecsubs[i]).val()+','+$.trim($(tecnames[i]).text())+',0|';
                    }
                }
                sendstr+=$.trim(ClassTec)+","+ClassSub+','+$.trim(ClassTectxt)+',1|';//合并班主任信息字符串
                sendstr=sendstr.substring(0,sendstr.length-1);//去掉最后一个字符
                //alert(sendstr);
            }
            var params = "{\"dotype\":\"" + dotype + "\",\"schid\":\"" + schid + "\",\"gradecode\":\"" + gradecode +"\",\"classid\":\"" + classid +"\",\"classname\":\"" + classname +"\",\"tagsusers\":\"" + sendstr +"\"}";
            $.ajax({
                type: "POST",  //请求方式
                url: "SchClassEdit2.aspx/classsave",  //请求路径：页面/方法名字
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
    <script type="text/javascript">
        
        //赋值
        var umodel = <%=umodelstr%>;
        
        if(umodel!="1")
        {
            $('#txtname').val(umodel.ClassName);
            $('#gradelist').val(umodel.GradeCode);
            
            //$("input[name='iscity'][value="+umodel.IsCity+"]").attr("checked",true);  
            //$("input[name='schstat'][value="+umodel.Stat+"]").attr("checked",true);
            //usersub SubId  $("input[name='radioName'][checked]").val(); 
            if(deptss)
            {
                for (var x in deptss) {
                    //人员列表
                    teclistadd(deptss[x].id,deptss[x].subcode,deptss[x].isms);
                }
            }
            //$("#sub_0").hide();
            //$("#tec_0").hide();
            //$("#row1 .DelTeacherSubject").hide();
            //$("#sub_1").hide();
            //$("#tec_1").hide();
        }
        else
        {
            $('#gradelist').val(gradecode);
        }
        function drpsub(obj){
            var selv = $(obj).val();
            var tecsubs=$("[name='tecsub'] option:selected");
            var teclength = tecsubs.length-1;
            for(var i=0;i<teclength;i++){
                //var s = $(document).find(tecsubs.eq(i)).attr("cszzz");
                //var ss = $(tecsubs.eq(i)).val();
                //if($(tecsubs[i]).val() != ""){
                if($(tecsubs[i]).val()==selv){
                    alert("你已经添加过了");
                    $(obj).find("option:first").prop("selected", 'selected');
                }
                //}
            }

        };
    </script>
    <style type="text/css">
        .DelTeacherSubject {
            line-height: 30px;
        }
    </style>
</body>
</html>

