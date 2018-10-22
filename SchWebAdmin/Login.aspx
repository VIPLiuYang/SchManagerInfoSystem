<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SchWebAdmin.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>支撑管理系统登录</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!-- 基本样式 -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/css/font-awesome.min.css" />
    <!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

    <!-- 页面特定的插件样式 -->

    <!-- 字体 -->
     

    <!-- ace 样式 -->

    <link rel="stylesheet" href="assets/css/ace.min.css" />
    <link rel="stylesheet" href="assets/css/ace-rtl.min.css" />

    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->

    <!-- 与此页面相关的内联样式 -->

    <!-- HTML5填充和Respond.js IE8支持HTML5元素和媒体查询 -->

    <!--[if lt IE 9]>
		<script src="assets/js/html5shiv.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->

</head>

<body class="login-layout">
    <div class="main-container">
        <div class="main-content" style="margin-left: 0px">
            <div class="row">
                <div class="col-sm-10 col-sm-offset-1">
                    <div class="login-container">
                        <div class="center">
                            <h1>
                                <i class="icon-leaf green"></i>
                                <span class="red">智慧校园</span>
                                <span class="white">支撑管理系统</span>
                            </h1>
                            <h4 class="blue">&copy; 金视野</h4>
                        </div>

                        <div class="space-6"></div>

                        <div class="position-relative">
                            <div id="login-box" class="login-box visible widget-box no-border">
                                <div class="widget-body">
                                    <div class="widget-main">
                                        <h4 class="header blue lighter bigger">
                                            <i class="icon-coffee green"></i>
                                            请输入您的信息
                                        </h4>

                                        <div class="space-6"></div>

                                        <form id="LoginForm">
                                            <div id="publicKey" style="display: none;"></div>
                                            <fieldset>
                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <input id="LgName" type="text" class="form-control" placeholder="请输入用户名" autofocus />
                                                        <i class="icon-user"></i>
                                                    </span>
                                                </label>

                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <input id="Pwd" type="password" class="form-control" placeholder="请输入密码" />
                                                        <i class="icon-lock"></i>
                                                    </span>
                                                </label>
                                                <label class="block clearfix">
                                                    验证码：
                                                        <input id="TxtCode" style="width:70px;" type="text">
                                                    <img src="viewImg.aspx" onclick="javascript:mmsCheckCode();" id="Img" />
                                                </label>
                                                <div class="space"></div>

                                                <div class="clearfix">
<%--                                                    <label class="inline">
                                                        <input id="iscookies" type="checkbox" class="ace" />
                                                        <span class="lbl">一个星期内免登录</span>
                                                    </label>--%>

                                                    <button id="btnLogin" type="button" class="width-35 pull-right btn btn-sm btn-primary">
                                                        <i class="icon-key"></i>
                                                        登录
                                                    </button>
                                                </div>

                                                <div class="space-4"></div>
                                            </fieldset>
                                        </form>
                                        <!--
											<div class="social-or-login center">
												<span class="bigger-110">或者使用其他方式登录</span>
											</div>

											<div class="social-login center">
												<a class="btn btn-primary">
													<i class="icon-facebook"></i>
												</a>

												<a class="btn btn-info">
													<i class="icon-twitter"></i>
												</a>

												<a class="btn btn-danger">
													<i class="icon-google-plus"></i>
												</a>
											</div>-->
                                    </div>
                                    <!-- /widget-main -->

                                    <%--<div class="toolbar clearfix">
                                        <div>
                                            <a href="#" onclick="show_box('forgot-box'); return false;" class="forgot-password-link">
                                                <i class="icon-arrow-left"></i>
                                                我忘记了我的密码
                                            </a>
                                        </div>
                                    </div>--%>
                                </div>
                                <!-- /widget-body -->
                            </div>
                            <!-- /login-box -->
                            <!--找回密码--开始-->
                            <div id="forgot-box" class="forgot-box widget-box no-border">
                                <div class="widget-body">
                                    <div class="widget-main">
                                        <h4 class="header red lighter bigger">
                                            <i class="icon-key"></i>
                                            找回密码
                                        </h4>

                                        <div class="space-6"></div>
                                        <p>
                                            请输入您的电子邮件并收到验证码
                                        </p>

                                        <form>
                                            <fieldset>
                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <input type="email" class="form-control" placeholder="请输入您的电子邮箱" />
                                                        <i class="icon-envelope"></i>
                                                    </span>
                                                </label>

                                                <div class="clearfix">
                                                    <button type="button" class="width-35 pull-right btn btn-sm btn-danger">
                                                        <i class="icon-lightbulb"></i>
                                                        发生到邮箱
                                                    </button>
                                                </div>
                                            </fieldset>
                                        </form>
                                    </div>
                                    <!-- /widget-main -->

                                    <div class="toolbar center">
                                        <a href="#" onclick="show_box('login-box'); return false;" class="back-to-login-link">返回到登录页面
												<i class="icon-arrow-right"></i>
                                        </a>
                                    </div>
                                </div>
                                <!-- /widget-body -->
                            </div>
                            <!-- /forgot-box -->
                            <!--找回密码--结束-->

                        </div>
                        <!-- /position-relative -->
                    </div>
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
        </div>
    </div>
    <!-- /.main-container -->

    <!-- 基本脚本 -->

    <!--[if !IE]> -->
    <!-- <![endif]-->

    <!--[if IE]>
        <![endif]-->

    <!--[if !IE]> -->
    <script type="text/javascript">
        window.jQuery || document.write("<script src='assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
    </script>
    <!-- <![endif]-->

    <!--[if IE]>
        <script type="text/javascript">
         window.jQuery || document.write("<script src='assets/js/jquery-1.10.2.min.js'>"+"<"+"/script>");
        </script>
        <![endif]-->

    <script type="text/javascript">
        if ("ontouchend" in document) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
    </script>

    <!-- 与此页面相关的内联脚本 -->
    <script type="text/javascript">
        function mmsCheckCode() {
            var myimg = document.getElementById("Img");
            myimg.src = 'viewImg.aspx?abc=' + Math.random();
            $("#TxtCode").val('');
        }
        function show_box(id) {
            jQuery('.widget-box.visible').removeClass('visible');
            jQuery('#' + id).addClass('visible');
        }
    </script>
    <script type="text/javascript">
        $.ajax({
            url: "Login.ashx",
            type: "POST",
            data: { Action: "null" },
            dataType: "text",
            success: function (data) {
                $("#publicKey").html(data);
            },
            error: function (error) {
                alert(error);
            }
        });
    </script>
    <script type="text/javascript" src="assets/js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="assets/js/jquery.cookie.js"></script>
    <script type="text/javascript" src="assets/js/jsencrypt.min.js"></script>
    <script type="text/javascript">

        var btnLoginFun = "";//单击等事件名称

        // 使用jsencrypt类库加密js方法，
        function encryptRequest(reqUrl, data, publicKey) {
            var encrypt = new JSEncrypt();
            encrypt.setPublicKey(publicKey);
            // ajax请求发送的数据对象
            var sendData = new Object();
            // 将data数组赋给ajax对象
            for (var key in data) {
                sendData[key] = encrypt.encrypt(data[key]);
            }
            sendData["Action"] = "Login";
            var prikey = "";

            var uncrypted = 0;
            $.ajax({
                url: reqUrl,
                type: "POST",
                //async:false,
                data: { Action: sendData["Action"], UserName: sendData["LgName"], PassWord: sendData["Pwd"], TxtCode: sendData["TxtCode"], IsCookies: sendData["IsCookies"] },
                //data:sendData,
                dataType: "json",
                //contentType: 'application/json; charset=utf-8',
                success: function (data, textStatus) {
                    if (data == "1") {
                        window.location.href = "index.aspx";
                    }
                    else if (data == "2") {
                        window.location.href = "UserPwdEdit.aspx";
                    } else if (data == "3") {
                        alert("账号或密码错误,或者被停用，请联系管理员。");
                        $("#btnLogin").bind("click", btnLoginFun);
                        $("#btnLogin").removeAttr("disabled");
                    } else if (data == "4") {
                        alert("用户名不能为空!");
                        $("#btnLogin").bind("click", btnLoginFun);
                        $("#btnLogin").removeAttr("disabled");
                    } else if (data == "5") {
                        alert("验证码错误!");
                        $("#btnLogin").bind("click", btnLoginFun);
                        $("#btnLogin").removeAttr("disabled");
                    } else {
                        mmsCheckCode();
                        alert(data);
                        $("#btnLogin").bind("click", btnLoginFun);
                        $("#btnLogin").removeAttr("disabled");
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(XMLHttpRequest.status);
                    alert(XMLHttpRequest.readyState);
                    alert(textStatus);
                    alert(errorThrown);
                }
            });
        }
        // 当页面完成加载时调用这个代码。
        $(function () {
            btnLoginFun = function () {

                $("#btnLogin").unbind();
                $("#btnLogin").attr("disabled", "disabled");

                var data = [];
                data["LgName"] = $("#LgName").val();
                data["Pwd"] = $("#Pwd").val();
                data["TxtCode"] = $("#TxtCode").val();//ace
                data["IsCookies"] = "0";
                if ($("#iscookies").attr('checked') == 'checked') {
                    data["IsCookies"] = "1";
                }
                var pkey = $("#publicKey").html();
                encryptRequest("Login.ashx", data, pkey);
            }
            $("#btnLogin").click(function () {
                btnLoginFun();
            });
            //当按下键盘上的回车键时，提交登录表单
            $(document).keyup(function (event) {
                var data = [];
                data["LgName"] = $("#LgName").val();
                data["Pwd"] = $("#Pwd").val();
                data["TxtCode"] = $("#TxtCode").val();//ace
                data["IsCookies"] = "0";
                if (event.keyCode == 13) {
                    if (data["LgName"] != "" && data["Pwd"] != "" && data["TxtCode"] != "") {
                        if ($("#iscookies").attr('checked') == 'checked') {
                            data["IsCookies"] = "1";
                        }
                        var pkey = $("#publicKey").html();
                        encryptRequest("Login.ashx", data, pkey);
                    } else {
                        if (data["LgName"] == "") { alert("用户名不允许为空！"); }
                        if (data["Pwd"] == "") { alert("请填写密码！"); }
                        if (data["TxtCode"] == "") { alert("请填写验证码！"); }
                    }
                }
            });
        });
    </script>
</body>
</html>
