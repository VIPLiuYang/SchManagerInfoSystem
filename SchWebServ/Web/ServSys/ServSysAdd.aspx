﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServSysAdd.aspx.cs" Inherits="SchWebServ.Web.ServSys.ServSysAdd" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>学校信息维护</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />

    <!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

    <!-- page specific plugin styles -->


    <!-- fonts -->


    <!-- ace styles -->

    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>
    <style>
         /*定义字体*/
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
                <div class="page-content content_box ">
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-4 col-xs-offset-1 text-right">平台代码：</div>
                        <div class="col-xs-6 text-left"><input  type="text" name="platfromCode" id="platfromCode" onkeyup="checkTxt(this)" placeholder="请输入平台代码" maxlength="10" /></div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-4 col-xs-offset-1 text-right">平台类型：</div>
                        <div class="col-xs-6 text-left"><input  type="text" name="platfromType" id="platfromType" placeholder="请输入平台类型" maxlength="25"/></div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-4 col-xs-offset-1 text-right">平台域名：</div>
                        <div class="col-xs-6 text-left"><input  type="text" name="platfromURL" id="platfromUrl" placeholder="请输入平台域名" maxlength="250" /></div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <button class="btn btn-info btn-sm text_size" id="btndo" type="button" onclick="saveuser()">保存</button>&nbsp; &nbsp; &nbsp;
                            <button class="btn btn-sm text_size" id="CancelBtn" type="button">取消</button>
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
    <link href="../../assets/css/bootstrap-dialog.css" rel="stylesheet" />
    <script src="../../assets/js/bootstrap-dialog.js"></script>
    <!-- ace scripts -->

    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>
    <script src="../../assets/js/bootstrap-paginator.js"></script>

    <!-- inline scripts related to this page -->
    <script type="text/javascript">
        //公共变量声明区域
        var schid = "<%=schid%>";

        //数据收集并存库函数
        function saveuser() {
            var datasave = [];
            datasave.push("schid#" + schid);
            var platfromCode = $("#platfromCode").val();
            if (platfromCode == "") {
                alert("平台代码不允许为空！");
                return;
            }
            datasave.push("code#" + platfromCode);
            var platfromType = $("#platfromType").val();
            if (platfromType =="") {
                alert("业务类型不允许为空！");
                return;
            }
            datasave.push("type#" + platfromType);
            var platfromUrl = $("#platfromUrl").val();
            if (platfromUrl == "") {
                alert("平台域名不允许为空！");
                return;
            }
            if (platfromUrl.length > 300) {
                alert("平台域名长度不允许超长30个字符！");
                return;
            }
            datasave.push("url#" + platfromUrl);

            $.ajax({
                type: "POST",  //请求方式
                url: "ServSysAdd.aspx/ServSysAddSave",  //请求路径：页面/方法名字
                data: JSON.stringify({ arr: datasave }),     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
                        alert(data.d.msg);
                        window.location.href = "../../LoginExc.aspx";
                    } else if (data.d.code == 'success') {
                        alert(data.d.msg);
                        window.parent.closeEditCfmmodel();
                    } else {
                        alert(data.d.msg);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        }
        function checkTxt(o) {
            var regu = /^[0-9a-zA-Z]+$/;
            var re = new RegExp(regu);
            if (re.test($(o).val())) {
            } else {
                alert("请输入数字或者字母");
                o.focus(); o.value = "";
            }
        }
        //单击取消按钮时，关闭模态框
        $(document).on("click", "#CancelBtn", function () {
            window.parent.closeEditCfmmodel();
        });
    </script>
</body>
</html>
