<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SchWeb.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>系统登录</title>
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
    <style type="text/css">
        #forgot-box {
            padding: 0px;
            border-radius: 15px;
        }

        html, body, .main-container {
            height: 100%;
        }

        body {
            /*
            background-image: url("assets/images/JysLogin.png");
            background-size: cover;
            background-repeat: no-repeat;
            overflow: -Scroll;
            overflow-x: hidden;
            width: 100%;*/
        }

        #login-box {
            border: 2px;
            border-radius: 10px;
            padding: 0px;
            /*margin-bottom: 108px;*/
            /*width: 350px;right:0px;float:right;*/
        }

            #login-box .widget-main {
                background-color: #fff!important;
            }

        #LgName {
            width: 88%;
            border: none;
        }

        #Pwd {
            width: 88%;
            border: none;
        }



        #btnLogin {
            background-color: #1299D2!important;
            border: none;
            border-radius: 1px;
            width: 100%!important;
            height: 40px;
        }

        .icon-user:before {
            content: none;
        }

        .input-icon.input-icon-right > [class*="icon-"] {
            left: 3px;
            right: auto;
        }

        .input-icon.input-icon-right > input {
            padding: 1px 2px 3px 30px;
            height: 33px;
        }

        .icon-user img {
            width: 35px;
            height: 35px;
        }

        .body_header {
            background: url("assets/images/login_bg_01.png");
            background-size: cover;
            height: 7%;
            margin: 0;
            padding: 0;
        }

        .body_body {
            background: url("assets/images/login_bg_02.png");
            background-size: cover;
            height: 86%;
            margin: 0;
            padding-top:100px;           
            position: relative;
        }

        .body_footer {
            background: url("assets/images/login_bg_03.png");
            background-size: cover;
            height: 7%;
            position: absolute;
            bottom: 0;
            left: 0;
            right: 0;
            color: #969696;
            text-align: center;
        }

        .body_footer p {
            text-align: center;
            margin-bottom:0px;
            top: 50%;/*元素的顶部边界离父元素的的位置是父元素高度的一半*/ 
        }

            .body_footer p .TechnicalSupport {
                margin-right: 10px;
                color: #000;
            }

            .body_footer p .CaseNumber {
                margin-left: 10px;
                color: #000;
            }
    </style>
</head>

<body class="login-layout">
    <div class="main-container">
        <div class="body_header">
            <div class="col-sm-7" style="text-align:center;">
                <div style="font-size:30px;height: 50px;font-weight:500;"><img src="assets/images/logo.png" style="height: 50px" />智慧校园管理平台</div>
            </div>
            <div class="col-sm-5" style="margin-top:20px;">
                
                    <span style="font-size: 15px; color: #CBCBCB;">
                        <img src="assets/images/az.png" style="height: 21px" />&nbsp;Android下载
                    </span>
                    <span style="font-size: 15px; color: #CBCBCB;margin-right:20px;margin-left:20px;">
                        <img src="assets/images/ios.png" style="height: 21px;" />&nbsp;IOS版下载
                    </span>
                    <span style="font-size: 15px; color: #CBCBCB;margin-right:20px;">|</span>
                    <span>
                        <img src="assets/images/11.png" style="height: 21px" /></span>

            </div>
        </div>

        <div class="row body_body">
            <div class="col-sm-10">
                <div class="login-container" style="float:right">
                    <div class="position-relative">
                        <!--login-box-->
                        <div id="login-box" class="login-box visible widget-box no-border">
                            <div class="widget-body">
                                <div class="widget-main">
                                    <h4 class="lighter bigger" style="margin-top: 30px; margin-bottom: 30px;">
                                        <img src="assets/images/JsyUser.png" />
                                    </h4>

                                    <div class="space-6"></div>

                                    <form id="LoginForm">
                                        <div id="publicKey" style="display: none;"></div>
                                        <label class="block clearfix" style="border: #d2d1d1 solid 1px; border-radius: 0px; padding: 0px; margin-bottom: 30px;">
                                            <span class="block input-icon input-icon-right">
                                                <i class="icon-user" style="padding-left: 0px; padding-right: 0px; left: 0px; top: 0px;">
                                                    <img src="assets/images/u.png" /></i>
                                                <input type="text" placeholder="账号" id="LgName" name="UserName" style="margin-left: 10px;" />
                                            </span>
                                        </label>

                                        <label class="block clearfix" style="border: #d2d1d1 solid 1px; border-radius: 0px; padding: 0px; margin-bottom: 10px;">
                                            <span class="block input-icon input-icon-right">
                                                <i class="icon-user" style="padding-left: 0px; padding-right: 0px; left: 0px; top: 0px;">
                                                    <img src="assets/images/p.png" /></i><input type="password" placeholder="密码" id="Pwd" name="PassWord" style="margin-left: 10px;" />
                                            </span>
                                        </label>

                                        <br />

                                        验证码：
                                                    <input type="text" id="TxtCode" placeholder="验证码" name="TxtCode" />
                                        <img src="viewImg.aspx" onclick="javascript:mmsCheckCode();" id="Img" />


                                        <div class="space"></div>
                                        <div class="clearfix">
                                            <label class="inline">
                                                <input id="iscookies" type="checkbox" class="ace" />
                                                <span class="lbl">自动登录</span>
                                            </label>
                                            <label class="inline" style="float: right;">
                                                <a href="#" onclick="show_box('forgot-box'); return false;" class="forgot-password-link" style="color: #808080;">忘记密码
                                                </a>
                                            </label>
                                        </div>
                                        <div class="space"></div>
                                        <div class="clearfix" style="text-align: center;">
                                            <button id="btnLogin" type="button" class="width-35 btn btn-sm btn-primary">
                                                立即登录
                                            </button>
                                        </div>

                                        <div class="space-4"></div>

                                    </form>
                                </div>
                                <!-- /widget-main -->
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
                </div>
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
        <div class="body_footer">
            <div style="height:30%"></div>
            <p class="center"><span class="TechnicalSupport">技术支持：山东金视野教育科技股份有限公司</span><span class="CaseNumber">鲁ICP备09042772号-6</span></p>
        </div>
    </div>

</body>
</html>
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

        //var uncrypted = 0;
        $.ajax({
            url: reqUrl,
            type: "POST",
            //async:false,
            data: { Action: sendData["Action"], UserName: sendData["LgName"], PassWord: sendData["Pwd"], TxtCode: sendData["TxtCode"], IsCookies: sendData["IsCookies"] },
            //data:sendData,
            dataType: "json",
            //contentType: 'application/json; charset=utf-8',
            success: function (data, textStatus) {
                if (data.RspCode == "1") {
                    window.location.href = "index.aspx";
                }
                else if (data.RspCode == "2") {
                    window.location.href = "UserPwdEdit.aspx";
                }
                else {
                    alert(data.RspTxt);
                    mmsCheckCode();
                    $("#btnLogin").bind("click", btnLoginFun);
                    $("#btnLogin").removeAttr("disabled");
                }

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //alert(XMLHttpRequest.status);
                //alert(XMLHttpRequest.readyState);
                //alert(textStatus);
                //alert(errorThrown);
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
