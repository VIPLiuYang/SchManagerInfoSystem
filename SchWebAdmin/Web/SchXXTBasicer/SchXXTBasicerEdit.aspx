<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchXXTBasicerEdit.aspx.cs" Inherits="SchWebAdmin.Web.SchXXTBasicer.SchXXTBasicerEdit" %>

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
    <style type="text/css">
        body {
            font-family:微软雅黑;
        }
        #SonSysStat {
            padding: 0px 3px;
            height: 25px;
        }
        #input-group {
            height: 25px;
        }
        #SonSysEndTime {
            height: 25px;
        }
        .input-group-addon {
            height: 25px;
            padding: 0px 3px;
        }
          select { 
                font-size: 12px;
                color:#999999;
        }
        input[type="text"] { 
            font-size: 12px;
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
                <div class="page-content" style="padding-top: 24px;">
                    <form class="form-horizontal" role="form">
                        <div class="row">
                            <div class="col-xs-5 no-padding text-right titleheight ">
                                            <label>学校代码</label>
                            </div>
                            <div class="col-xs-5 no-padding-right">
                                            <input type="text" id="SchId"  data-toggle="tooltip" readonly="readonly" disabled="disabled" maxlength="10" />
                            </div>
                            <div class="col-xs-2"></div>
                        </div>
                        <div class="space-4"></div>
                        <div class="row">
                            <div class="col-xs-5 no-padding text-right titleheight ">
                                            <label>学校名称</label>
                            </div>
                            <div class="col-xs-5 no-padding-right">
                                            <input type="text" id="SchName" placeholder="学校名称" data-toggle="tooltip" title="学校名称" onblur="checkTxt(this,'^.{1,10}$')" readonly="readonly" disabled="disabled" maxlength="10" />
                            </div>
                            <div class="col-xs-2"></div>
                        </div>
                        <div class="space-4"></div>
                        <div class="row">
                            <div class="col-xs-5 no-padding text-right titleheight ">
                                                <label>数据维护</label>
                            </div>
                            <div class="col-xs-5 no-padding-right">
                                    <input type="hidden" id="SchSonSysEnableTime" />
                                    <select id="SonSysStat">
                                        <option value="0">客服维护</option>
                                        <option value="1">学校维护</option>
                                    </select>
                            </div>
                            <div class="col-xs-2"></div>
                        </div>
                        <div class="space-4"></div>
                        <div class="clearfix form-actions" style="background-color:#ffffff;border-top:none;">
                            <div class="col-xs-12 text-center">
                                <button class="btn btn-info btn-sm btn_size" id="btndo" type="button" onclick="saveuser()">确定</button>
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
    
    <script type="text/javascript">
        var schid = <%=schid%>;

        var umodel=<%=umodelstr%>;
        //用户赋值 
        if(umodel!="1")
        {
            $('#SchId').val(umodel.SchId);
            $('#SchName').val(umodel.SchName);
            $("#SonSysStat").val(umodel.HomeSchBasicStat);
            //服务状态：0代表停用；1代表启用
            if(umodel.SonSysStat=="1"||umodel.SourceSerStat=="1"){
                //数据维护：0代表客服维护；1代表学校维护
                if(umodel.HomeSchBasicStat=="1"){
                    $("#SonSysStat").attr("disabled","disabled");//如果管理平台服务状态与资源平台服务状态其中之一为启用并数据维护为学校维护时，不允许选择客服维护
                }
            }
        }

        //数据收集并存库函数
        function saveuser()
        {
            var pstr="";
            pstr=schid+'|'+$("#SonSysStat").val();
            
            $.ajax({
                type: "POST",  //请求方式
                url: "SchXXTBasicerEdit.aspx/schsubsave",  //请求路径：页面/方法名字
                data: JSON.stringify({ arr: pstr }),     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d.code=='success')
                    {
                        alert(data.d.msg);
                        window.parent.createuserclose();
                        
                    }
                    else if (data.d.code == "error") {
                        alert(data.d.msg);
                    }
                    else if(data.d.code == "expire"){
                        window.location.href="../../LoginExc.aspx";
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