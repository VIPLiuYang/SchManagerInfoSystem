<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchSourceSharEdit.aspx.cs" Inherits="SchWebAdmin.Web.SchResourceSharSet.SchSourceSharEdit" %>

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
        /*字体*/
         body { 
       font-family: "微软雅黑" !important;
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
                        <div id="schsouresharedit"></div>
                        <div class="space-4"></div>
                         <div class="clearfix form-actions" style="background-color:#ffffff;border-top:none;">
                            <div class="col-xs-12 text-right">
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
    <style type="text/css">
        .form-actions {
           
            margin: 0px auto;
        }
        /*
        #btndo {
            background-color: #ffffff!important;
            border:#6fb3e0 solid 1px;
            color:#6fb3e0!important;
        }
        #btndo:hover{background:none!important}
       
        #CancelBtn {
            background-color: #ffffff!important;
            border:#abbac3 solid 1px;
            color:#abbac3!important;
        }
        */
        #schsouresharedit .row {
                margin: 20px auto 20px auto;
        }
    </style>

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

        var umodelsarstr=<%=umodelsarstr%>;

        //用户赋值 
        if(umodel!="1")
        {
            window.parent.schsourcesharedittile(umodel.SchId,umodel.SchName);
        }
        if(umodelsarstr!="1"){
            var str = '';
            var i=1;

            str += '<div class="row">';
            $.each(umodelsarstr, function (index, item) {
                if(item.checked=="true"){
                    str += '    <div class="col-xs-2 no-padding text-right titleheight ">';
                    str += '        <label>'+item.AppName+'：</label>';
                    str += '    </div>';
                    str += '    <div class="col-xs-3 no-padding-right">';
                    if(item.UsharStat=="1"){
                        str += '<input class="ace sharset" name="isshar'+i+'" type="radio" value="'+item.AppCode+',1" class="ace" checked="checked"><span class="lbl ">共享</span>&nbsp;&nbsp;&nbsp;&nbsp;';
                        str += '<input class="ace sharset" name="isshar'+i+'" type="radio" value="'+item.AppCode+',0" class="ace"><span class="lbl ">不共享</span>';
                    }else{
                        str += '<input class="ace sharset" name="isshar'+i+'" type="radio" value="'+item.AppCode+',1" class="ace"><span class="lbl ">共享</span>&nbsp;&nbsp;&nbsp;&nbsp;';
                        str += '<input class="ace sharset" name="isshar'+i+'" type="radio" value="'+item.AppCode+',0" class="ace" checked="checked"><span class="lbl ">不共享</span>';
                    }
                    str += '    </div>';
                    if((i%2)==0){
                        str += '</div>';
                        str += '<div class="row">';
                    }
                    i++;
                }
            })
            $("#schsouresharedit").html(str);
        }
        if(i==1){
            $(".form-actions").html("请先在学校基础信息中设置资源模块！");
        }
        //数据收集并存库函数
        function saveuser()
        {
            var sharsetlen = $(".sharset").length;
            var vals="";
            for(var i=1;i<=sharsetlen/2;i++){
                vals += $('input:radio[name="isshar'+i+'"]:checked').val()+"|";
            }
            
            var pstr=schid+'#'+vals.substring(0,vals.length-1);
            
            $.ajax({
                type: "POST",  //请求方式
                url: "SchSourceSharEdit.aspx/schsubsave",  //请求路径：页面/方法名字
                data: JSON.stringify({ arr: pstr }),     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d.code == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }
                    else if(data.d.code=='success')
                    {
                        alert(data.d.msg);
                        window.parent.createuserclose();                        
                    }
                    else{
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