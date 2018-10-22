<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysUTypeDialog.aspx.cs" Inherits="SchWebAdmin.Web.SysSchbasic.SysUTypeDialog" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
        /*字体*/
        .page-content {
            padding: 0px;
        }

        .row {
            margin: 0px;
            font-size: 14px;
            color: #999999;
        }

        .widget-box {
            margin: 0px;
            border: 0px;
        }

        .widget-body {
            border: 0px;
        }

        strong {
            margin-right: 15px;
            font-size: 14px;
            color: #393939;
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
                    <div class="widget-box">
                        <div class="widget-body">
                            <div class="widget-main">
                                <div class="row">
                                    <div class="col-sm-6 col-xs-6"><strong>名称:</strong><input type="text" id="Name" data-toggle="tooltip" maxlength="10" /></div>
                                    <div class="col-sm-6 col-xs-6">
                                        <strong>状态:</strong>
                                        <select id="Stat">
                                            <option value="1">正常</option>
                                            <option value="0">停用</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-right">
                            <input type="text" id="AutoId" hidden="hidden" />
                            <button class="btn btn-info btn-sm btn_size" id="btndo" type="button" onclick="saveuser()"><%=btname %></button>
                            <button class="btn btn-sm btn_size" id="CancelBtn" type="reset">取消</button>
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
    <script src="../../assets/js/jquery-ui-1.10.3.custom.min.js"></script>
    <script src="../../assets/js/jquery.ui.touch-punch.min.js"></script>
    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>
    <script type="text/javascript">
       

        $('#AutoId').val(<%=id%>);
        $('#Name').val('<%=name%>');
        $("#Stat").val(<%=stat%>);

        //数据收集并存库函数
        function saveuser()
        {  
            var AutoId= $("#AutoId").val(); 
            var Name= $("#Name").val(); 
            if(Name=="")
            {
                alert("请填写名称");
                return false;
            }
            var Stat= $("#Stat").val(); 
            var params = '{"Name":"' + Name + '","stat":"' + Stat + '","AutoId":"' + AutoId + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SysUTypeDialog.aspx/save",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d.code=='success')
                    {
                        alert(data.d.msg);
                        window.parent.createuserclose();
                    } 
                    else if (data.d.code == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    }
                    else if (data.d.code == "error") {
                        alert(data.d.msg);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
            
        }

        $(document).on("click","#CancelBtn",function(){
            window.parent.createuserclose();
        });
    </script>
</body>
</html>

