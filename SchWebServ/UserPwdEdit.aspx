<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPwdEdit.aspx.cs" Inherits="SchWebServ.UserPwdEdit" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>修改密码</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!-- basic styles -->

    <link href="./assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="./assets/css/font-awesome.min.css" />

    <!--[if IE 7]>
		  <link rel="stylesheet" href="../../assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

    <!-- page specific plugin styles -->

    <link rel="stylesheet" href="./assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="./assets/css/chosen.css" />

    <!-- fonts -->

     

    <!-- ace styles -->

    <link rel="stylesheet" href="./assets/css/ace.min.css" />
    <link rel="stylesheet" href="./assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="./assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="./assets/css/metro.css" />
    <style>
       /*所在位置的提示高度*/
        .breadcrumbs {
            min-height:32px;
            line-height:30px;
        }
         /*所在位置的背景边框*/
        .breadcrumb_box {
            background: white;
            border-bottom: 1px solid #e4e4e4;
            
        }
        /*坐在位置的坐边竖线*/
        .breadcrumb_border {
            border-left: 2px solid #63bbff;
            margin-left: 0px;
            padding-left: 12px;
           
        }
         /*位置提示字体大小*/
        .breadcrumb > li {
            font-family:微软雅黑;
            font-size:13px !important;
            color:#666666 !important;
        }
        /*用户名等左边标签*/
        .text_style {
            font-family:微软雅黑;
            font-size:14px !important
        }
        /*保存、取消按钮的样式*/
        .text_size {
            font-family:微软雅黑;
            font-size:12px !important;
            text-shadow:none !important;
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
    </style>

    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="./assets/css/ace-ie.min.css" />
		<![endif]-->

    <!-- inline styles related to this page -->

    <!-- ace settings handler -->

    <script src="./assets/js/ace-extra.min.js"></script>

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

    <!--[if lt IE 9]>
		<script src="./assets/js/html5shiv.js"></script>
		<script src="./assets/js/respond.min.js"></script>
		<![endif]-->
    
</head>

<body ontouchstart>

    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>
        <style type="text/css">
    .breadcrumb>li+li:before{content:none;}
    input[type=checkbox].ace:disabled+.lbl::before, input[type=radio].ace:disabled+.lbl::before, input[type=checkbox].ace[disabled]+.lbl::before, input[type=radio].ace[disabled]+.lbl::before, input[type=checkbox].ace.disabled+.lbl::before, input[type=radio].ace.disabled+.lbl::before{color:#32A3CF;}
        </style>
        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
                <div class="breadcrumbs breadcrumb_box " id="breadcrumbs">
                    <script type="text/javascript">
                        try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
                    </script>

                    <ul class="breadcrumb breadcrumb_border">
                        <li>
                            <%--<i class="icon-home home-icon"></i>--%>
                            目前位置：
                        </li>
                        <%--<li>
                            <a href="#">学校管理</a>
                        </li>--%>
                        <%--将学校信息改为学校及科目信息--%>
                        <li class="active">修改密码 </li>
                    </ul>
                    <!-- .breadcrumb -->
                </div>

                <div class="page-content content_box">
                    <div class="row">
                        <%--减小栅格栏--%>
                        <div class="col-xs-12  col-sm-10 col-sm-offset-2">
                            <!-- PAGE CONTENT BEGINS -->

                            <form class="form-horizontal  " role="form">
                                <input type="hidden" id="usertid" value="<%=usertid %>" />
                                <div class="space-8"></div>
                                <div class="form-group form-inline ">
                                    <div class="row text_style">
                                        <div class="col-sm-3 no-padding-right text-right">
                                            <label >用户名:</label>
                                        </div>
                                        <div class="col-sm-3 input_box">
                                            <input type="text" id="username" placeholder="用户名" data-toggle="tooltip" class="col-xs-12 col-sm-12" maxlength="25" disabled="disabled"  readonly="readonly" value="<%=username %>"/>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group form-inline ">
                                    <div class="row text_style">
                                        <div class="col-sm-3 no-padding-right text-right">
                                            <label >密码:</label>
                                        </div>
                                        <div class="col-sm-3 input_box">
                                            <input type="password" id="password" placeholder="密码"  data-toggle="tooltip" title="字母和数字的长度6-18位组合" onblur="checkTxt(this,'^([a-zA-Z0-9]{6,18})$')" maxlength="18" class="col-xs-12 col-sm-12" maxlength="25" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group form-inline ">
                                    <div class="row text_style">
                                        <div class="col-sm-3 no-padding-right text-right">
                                            <label >确认密码:</label>
                                        </div>
                                        <div class="col-sm-3 input_box">
                                            <input type="password" id="pwd" placeholder="确认密码" data-toggle="tooltip" title="字母和数字的长度6-18位组合" onblur="checkTxt(this,'^([a-zA-Z0-9]{6,18})$')" maxlength="18"  class="col-xs-12 col-sm-12" maxlength="25" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                        <div class="col-sm-9 text-center">
                                            <button class="btn btn-info btn-sm text_size" id="btndo" type="button" onclick="saveuser()">
                                                <%--<i class="icon-ok bigger-110"></i>--%>
                                                保存
                                            </button>

                                            &nbsp; &nbsp; &nbsp;
											<button class="btn btn-sm text_size" id="btndoreset" type="button" onclick="notdo()">
                                                <%--<i class="icon-undo bigger-110"></i>--%>
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

            <!-- /#ace-settings-container -->
        </div>
        <!-- /.main-container-inner -->
    </div>

    <script type="text/javascript">
        window.jQuery || document.write("<script src='./assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
    </script>
    <script src="./assets/js/bootstrap.min.js"></script>
    <script src="./assets/js/typeahead-bs2.min.js"></script>
    <script src="./assets/js/jquery-ui-1.10.3.custom.min.js"></script>
    <script src="./assets/js/jquery.ui.touch-punch.min.js"></script>
    <script src="./assets/js/ace-elements.min.js"></script>
    <script src="./assets/js/ace.min.js"></script>
    <!-- Latest compiled and minified JavaScript -->
    

    <script type="text/javascript">
        
        var schid='<%=schid%>';
        var dotype='<%=dotype%>';
        var systype='<%=systype%>';
       
        function saveuser()
        {
            var password = $('#password').val();
            var pwd= $('#pwd').val();
            var username = $('#username').val();
            var usertid = $('#usertid').val();
            if (password != pwd) {
                alert("密码不一致");
                return false;
            }
            if (password == "") {
                alert("密码不允许为空");
                return false;
            }
            var params = '{"dotype":"' + dotype + '","schid":"' + schid + '","username":"' + username + '","usertid":"' + usertid + '","password":"' + password + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "UserPwdEdit.aspx/schsave",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d=='success')
                    {
                        window.top.location.href = "index.aspx";
                    }
                    else
                    {
                        alert(data.d);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
            
        }
        function notdo() {
            window.history.go(-1);
        }
        function LoginOut() {
            $.ajax({
                url: "Login.ashx",
                type: "POST",
                //async:false,
                data: { Action: "out" },
                //data:sendData,
                dataType: "text",
                //contentType: 'application/json; charset=utf-8',
                success: function (data, textStatus) {
                    if (data == "out") {
                        window.parent.location.href = "Login.aspx";
                    }
                    else {
                        alert("退出登录失败");
                    }
                }
            })
        };
        function checkTxt(o, reg) {
            var re = new RegExp(reg);
            if (re.test($(o).val())) {
                return true;
            } else {
                $(o).tooltip('show');
                $(o).focus();
                return false;
            }
        }
    </script>
    
</body>
</html>
