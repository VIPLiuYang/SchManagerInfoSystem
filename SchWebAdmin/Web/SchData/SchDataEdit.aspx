<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchDataEdit.aspx.cs" Inherits="SchWebAdmin.Web.SchData.SchDataEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
        body {
            font-family:微软雅黑;
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
                    <form class="form-horizontal" role="form">
                        <h3 style="text-align:center;"><%=schname %></h3>
                        <!--以下是需要进行毕业的年级：<br />-->
                        <div id="dergraduate" style="margin:20px 100px 0px 100px;"></div>
                        <!--如果要处理，请继续单击“确定”按钮。-->
                        <div class="space-4"></div>
                        <div class="clearfix form-actions" style="background-color:#ffffff;border-top:none;">
                            <div class="col-xs-12 text-center">
                                <button class="btn btn-info btn-sm btn_size" id="btndo" type="button" onclick="saveuser()">升级</button>
                                        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                                <button class="btn btn-sm btn_size" id="CancelBtn" type="reset">取消</button>
                            </div>
                        </div>
                        <div class="space-4"></div>
                    </form>
                </div>
            </div>
        </div>
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
    <script src="../../assets/js/date-time/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="../../assets/css/datepicker.css" />
    <script src="../../assets/js/i18n/defaults-zh_CN.min.js"></script>
    <script type="text/javascript">
        var updateGradeDataObj = <%=updateGrade%>;
        var schid = <%=schid%>;
        $(document).ready(function(){
            var dergraduate = "";var kindren="";var prim="";var midd="";var jar="";
            $.each(updateGradeDataObj,function(name,item) {
                if(item.GradeCode.substring(0,1)=="1"){
                    kindren+="<p>"+item.GradeName+"["+item.GradeYear+"级]"+"做毕业处理</p>";
                }else if(item.GradeCode.substring(0,1)=="2"){
                    prim+="<p>"+item.GradeName+"["+item.GradeYear+"级]"+"做毕业处理</p>";
                }else if(item.GradeCode.substring(0,1)=="3"){
                    midd+="<p>"+item.GradeName+"["+item.GradeYear+"级]"+"做毕业处理</p>";
                }else if(item.GradeCode.substring(0,1)=="4"){
                    jar+="<p>"+item.GradeName+"["+item.GradeYear+"级]"+"做毕业处理</p>";
                }
            });
            if(kindren!=""){
                dergraduate +="<div style=\"float:left;\">幼儿园：&nbsp;&nbsp;&nbsp;&nbsp;</div><div style=\"float:left;\">"+kindren+"</div><div style=\"clear:both;\"></div>";
            }
            if(prim!=""){
                dergraduate +="<div style=\"float:left;\">小学：&nbsp;&nbsp;&nbsp;&nbsp;</div><div style=\"float:left;\">"+prim+"</div><div style=\"clear:both;\"></div>";
            }
            if(midd!=""){
                dergraduate +="<div style=\"float:left;\">初中：&nbsp;&nbsp;&nbsp;&nbsp;</div><div style=\"float:left;\">"+midd+"</div><div style=\"clear:both;\"></div>";
            }
            if(jar!=""){
                dergraduate +="<div style=\"float:left;\">高中：&nbsp;&nbsp;&nbsp;&nbsp;</div><div style=\"float:left;\">"+jar+"</div><div style=\"clear:both;\"></div>";
            }
            $("#dergraduate").html(dergraduate);

            $(document).on("click","#CancelBtn",function(){
                window.parent.createuserclose();
            });

        });

        //数据收集并存库函数
        function saveuser()
        {
            var datasave=[];
            datasave.push("schid#"+schid);
            //var schname= $("#SchName").val();
            //datasave.push("schname#"+schname);
            $.ajax({
                type: "POST",  //请求方式
                url: "SchDataEdit.aspx/schDatasave",  //请求路径：页面/方法名字
                data: JSON.stringify({ arr: datasave }),     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
                        alert(data.d.msg);
                        window.location.href = "../../LoginExc.aspx";
                    } else if (data.d.code == "Success") {
                        alert(data.d.msg);
                        window.parent.createuserclose();
                    } else if (data.d.code == "Error") {
                        alert(data.d.msg);
                    }else{
                        alert("操作失败，请联系管理员");
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        }

    </script>
</body>
</html>
