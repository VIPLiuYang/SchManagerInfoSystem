<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetRolePurview.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.Role.SetRolePurview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>角色权限信息</title>
    <meta name="keywords" content="金视野,教育,平台" />
		<meta name="description" content="金视野开发部,模板,2017" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0" />

		<!-- basic styles -->

		<link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
		<link rel="stylesheet" href="/assets/css/font-awesome.min.css" />

		<!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

		<!-- page specific plugin styles -->

		<link rel="stylesheet" href="/assets/css/jquery-ui-1.10.3.custom.min.css" />
		<link rel="stylesheet" href="/assets/css/chosen.css" />
		<link rel="stylesheet" href="/assets/css/datepicker.css" />
		<link rel="stylesheet" href="/assets/css/bootstrap-timepicker.css" />
		<link rel="stylesheet" href="/assets/css/daterangepicker.css" />
		<link rel="stylesheet" href="/assets/css/colorpicker.css" />

		<!-- fonts -->

		<link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300" />

		<!-- ace styles -->

		<link rel="stylesheet" href="/assets/css/ace.min.css" />
		<link rel="stylesheet" href="/assets/css/ace-rtl.min.css" />
		<link rel="stylesheet" href="/assets/css/ace-skins.min.css" />

		<!--[if lte IE 8]>
		  <link rel="stylesheet" href="/assets/css/ace-ie.min.css" /> 
		<![endif]-->

		<!-- inline styles related to this page -->

		<!-- ace settings handler -->

		<script src="/assets/js/ace-extra.min.js"></script>

		<!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

		<!--[if lt IE 9]>
		<script src="/assets/js/html5shiv.js"></script>
		<script src="/assets/js/respond.min.js"></script>
		<![endif]-->
    <!-- basic scripts -->


		<!--[if !IE]> -->

		<script type="text/javascript">
		    window.jQuery || document.write("<script src='/assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
		</script>

		<!-- <![endif]-->

		<!--[if IE]>
<script type="text/javascript">
 window.jQuery || document.write("<script src='/assets/js/jquery-1.10.2.min.js'>"+"<"+"/script>");
</script>
<![endif]-->

		<script type="text/javascript">
		    if ("ontouchend" in document) document.write("<script src='/assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
		</script>
		<script src="/assets/js/bootstrap.min.js"></script>
		<script src="/assets/js/typeahead-bs2.min.js"></script>
    <style type="text/css">
        #form-field-1 {
            color:red;
        }
    </style>
</head>
<body>
    <div class="main-container" id="main-container">
			<script type="text/javascript">
			    try { ace.settings.check('main-container', 'fixed') } catch (e) { }
			</script>
			<div class="main-container-inner">
				<div class="main-content" style="margin-left:0px">
					<div class="page-content">
						<div class="page-header">
							<h1>角色权限</h1>
						</div><!-- /.page-header -->
						<div class="row">
							<div class="col-xs-12">
								<form class="form-horizontal" role="form">
                                    <input type="hidden" id="Id" name="RoleId" value=""/>
									<div class="form-group">
										<div class="col-sm-9">
											你正在设置角色为<label id="form-field-1"></label>的权限：
										</div>
									</div>
									<div class="form-group">
                                        <div class="col-sm-9" id="SchFuncList"></div>
                                        <!---->
        <link rel="StyleSheet" href="css/dtree.css" type="text/css" />
        <script type="text/javascript" src="js/dtree.js"></script>
        <div class="dtree" id="dtree_div">
        <p><a href="javascript:  d.closeAll();">打开</a> | <a href="javascript: d.openAll();">关闭</a></p>
        <input id="dosearch_text" type="text" />
        <input id="dosearch" type="button" value="查询" onClick="nodeSearching() " />
        <script type="text/javascript">
            d = new dTree('d', true);   //参数一: 树名称。参数二：单选多选 true多选  false单选  默认单选               
            d.add(0, -1, '权限管理');
            var parentCount = 0;
            $.ajax({
                url: "ashx/Role.ashx",
                type: "POST",
                async: false,
                data: { Action: "null" },
                dataType: "json",
                success: function (data, textStatus) {
                    $.each(data.FuncList, function (index, content) {
                        if (content.Pid == "0") { parentCount++; }
                        // dTree实例属性以此为：  节点ID，父类ID，chechbox的名称，chechbox的值，chechbox的显示名称，
                        //chechbox是否被选中--默认是不选，chechbox是否可用：默认是可用，节点链接：默认是虚链接
                        d.add(content.FuncId, content.Pid, content.FuncType, content.FuncCode, content.FuncName, false, false);
                        
                    });
                }
            });
            document.write(d);
            d.openAll();
            
        </script>
    </div>
    
    <script type="text/javascript">
        function test() {
            var count = 0;
            var obj = document.all.authority;

            for (i = 0; i < obj.length; i++) {
                if (obj[i].checked) {
                    alert(obj[i].value);
                    count++;
                }
            } alert(count);
        }
        //搜索节点并展开节点
        function nodeSearching() {
            var dosearch = $.trim($("#dosearch_text").val());//获取要查询的文字
            var dtree_div = $("#dtree_div").find(".dtree_node").show().filter(":contains('" + dosearch + "')");//获取所有包含文本的节点
            $.each(dtree_div, function (index, element) {
                var s = $(element).attr("node_id");
                //var id = $(element).parent().attr("id");
                //$("#" + id).css("color", "red");
                d.openTo(s);//根据id打开节点
            });
        }
</script>
<script type="text/javascript">
    //#region 页面执行入口
    $(document).ready(function () {
        //#region 浏览器检测相关方法
        window["MzBrowser"] = {}; (function () {
            if (MzBrowser.platform) return;
            var ua = window.navigator.userAgent;
            MzBrowser.platform = window.navigator.platform;
            MzBrowser.firefox = ua.indexOf("Firefox") > 0;
            MzBrowser.opera = typeof (window.opera) == "object";
            MzBrowser.ie = !MzBrowser.opera && ua.indexOf("MSIE") > 0;
            MzBrowser.mozilla = window.navigator.product == "Gecko";
            MzBrowser.netscape = window.navigator.vendor == "Netscape";
            MzBrowser.safari = ua.indexOf("Safari") > -1;
            if (MzBrowser.firefox) var re = /Firefox(\s|\/)(\d+(\.\d+)?)/;
            else if (MzBrowser.ie) var re = /MSIE( )(\d+(\.\d+)?)/;
            else if (MzBrowser.opera) var re = /Opera(\s|\/)(\d+(\.\d+)?)/;
            else if (MzBrowser.netscape) var re = /Netscape(\s|\/)(\d+(\.\d+)?)/;
            else if (MzBrowser.safari) var re = /Version(\/)(\d+(\.\d+)?)/;
            else if (MzBrowser.mozilla) var re = /rv(\:)(\d+(\.\d+)?)/;
            if ("undefined" != typeof (re) && re.test(ua))
                MzBrowser.version = parseFloat(RegExp.$2);
        })();
    }); 
</script>
                                        <!--//-->
										
									</div>
									<div class="clearfix form-actions">
										<div class="col-md-offset-3 col-md-9">
											<button class="btn btn-info" type="button">
												<i class="icon-ok bigger-110"></i>
											</button>
											&nbsp; &nbsp; &nbsp;
											<button class="btn" type="reset">
												<i class="icon-undo bigger-110"></i>
												重置
											</button>
										</div>
									</div>
									<div class="hr hr-24"></div>
								</form>
							</div><!-- /.col -->
						</div><!-- /.row -->
					</div><!-- /.page-content -->
				</div><!-- /.main-content -->
				<!-- /#ace-settings-container -->
			</div><!-- /.main-container-inner -->
		</div><!-- /.main-container -->
		<!-- page specific plugin scripts -->
		<!--[if lte IE 8]>
		  <script src="/assets/js/excanvas.min.js"></script>
		<![endif]-->
    <!--
		<script src="/assets/js/jquery-ui-1.10.3.custom.min.js"></script>
		<script src="/assets/js/jquery.ui.touch-punch.min.js"></script>
		<script src="/assets/js/chosen.jquery.min.js"></script>
		<script src="/assets/js/fuelux/fuelux.spinner.min.js"></script>
		<script src="/assets/js/date-time/bootstrap-datepicker.min.js"></script>
		<script src="/assets/js/date-time/bootstrap-timepicker.min.js"></script>
		<script src="/assets/js/date-time/moment.min.js"></script>
		<script src="/assets/js/date-time/daterangepicker.min.js"></script>
		<script src="/assets/js/bootstrap-colorpicker.min.js"></script>
		<script src="/assets/js/jquery.knob.min.js"></script>
		<script src="/assets/js/jquery.autosize.min.js"></script>
		<script src="/assets/js/jquery.inputlimiter.1.3.1.min.js"></script>
		<script src="/assets/js/jquery.maskedinput.min.js"></script>
		<script src="/assets/js/bootstrap-tag.min.js"></script>
   
		
		<script src="/assets/js/ace-elements.min.js"></script>
		<script src="/assets/js/ace.min.js"></script>-->
</body>
</html>

<script type="text/javascript">
    $(document).ready(function () {
        

    });
    //查询功能列表
    /*
    $.ajax({
        url: "ashx/Role.ashx",
        type: "POST",//或GET
        async: true,//或false,是否异步
        data: { Action: "null" },
        dataType: "json",//返回的数据格式：json/xml/html/script/jsonp/text
        //timeout: 5000,    //超时时间
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        success: function (data, textStatus) {
            var JsonData = data.FuncList;
            var text = "<ul>";
            $.each(JsonData, function (index, content) {
                if (content.Pid == 0) {
                    text += "<li>";
                    text += "<input class=\"parent\" type=\"checkbox\" name=\"FuncId[]\" value=\"" + content.FuncId + "\" />" + content.FuncName + "-" + content.FuncCode + "-" + content.FuncId + "-" + content.Pid;
                    text += "<ul class=\"children\">";
                    $.each(JsonData, function (indexs, contents) {
                        if (contents.Pid == content.FuncId) {
                            text += "<li><input type=\"checkbox\" name=\"FuncId[]\" value=\"" + contents.FuncId + "\" />" + contents.FuncName + " - " + contents.FuncCode + " - " + contents.FuncId + " - " + contents.Pid + "</li>";
                        }
                    });
                    text += "</ul>";
                    text += "</li>";
                }
            });
            text += "</ul>";
            $("#SchFuncList").html(text);
        }
    });*/
    // });
</script>
<script type="text/javascript" src="js/function.js"></script>
<script type="text/javascript">
    var cid = getPar("Id");//获取get参数
    if (cid == false) {
        $(".icon-ok").html("添加");//如果没有ID，则说明是添加按钮
    } else {
        $(".icon-ok").html("保存"); //如果有ID，则说明是修改按钮
        $("#Id").val(cid);
        Edit(cid);
       
    }
    $(".btn-info").click(function () {
        var id = $("#Id").val();//获取班级编号（自动）
        EditSave(id);//保存编辑
    });
    //编辑方法
    function Edit(id) {
        if (confirm("确定编辑该角色权限吗?")) {
            $.ajax({
                url: "ashx/Role.ashx",
                type: "POST",//或GET
                async: true,//或false,是否异步
                data: { Action: "Edit", Id: id },
                dataType: "json",//返回的数据格式：json/xml/html/script/jsonp/text
                timeout: 5000,    //超时时间
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                success: function (data, textStatus) {
                    $.each(data.rows, function (index, content) {
                        $("#form-field-1").html(content.RoleName);
                        var RoleStr = content.RoleStr;
                        for (var i = 0; i < RoleStr.length; i++) {
                            if (RoleStr.charAt(i) == 1) {
                                $('input[name="FunMenu"]:checkbox').eq(i).attr('checked', 'true');
                            }
                        }
                    });
                }
            });
            
        } else {
            alert("取消了编辑");
            self.location = "/SchoolBaxicInfo/Role/RoleList.aspx";
        }
    }
    //编辑保存数据库方法
    function EditSave(id) {
        var cNo = $("#Id").val();
        if (cNo == "") { alert("角色编号不允许为空"); return false; }
        var rolestrval = "";
        $("[name='FunMenu']").each(function () {
            if ($(this).is(':checked') == true) {
                rolestrval += "1";
            } else {
                rolestrval += "0";
            }
        });
        if (confirm("确定保存该角色权限吗?")) {
            $.ajax({
                url: "ashx/Role.ashx",
                type: "POST",//或GET
                async: true,//或false,是否异步
                data: { Action: "EditSavePurview", sId: id, RoleStr: rolestrval },
                dataType: "text",//返回的数据格式：json/xml/html/script/jsonp/text
                timeout: 5000,    //超时时间
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                success: function (data, textStatus) {
                    if (data == "True") {
                        alert("编辑成功啦");
                        window.close();
                    } else {
                        alert("编辑失败了");
                    }
                }
            });
        } else {
            alert("取消了编辑");
        }
    }
    
    function ceshi() {
        for (i = 1; i <= parentCount; i++) {
            //alert("#dd" + i + "  .dTreeNodeChild");
            var length = $("#dd" + i + "  .dTreeNodeChild").length;
            for (j = 1; j <= length; j++) {
                alert($("#dd" + i + "  .dTreeNodeChild input").get(0).checked);
                /*.get(0).checked
                if ($("#dd" + i + "  .dTreeNodeChild input").is(':checked')) {

                }*/
            }
        }
        //alert($("#dd1 .dTreeNodeChild").length);
    }
    </script>
<script type="text/javascript">
    $(document).ready(function(){
        //
        /*
        for (i = 1; i <= parentCount; i++) {
            //alert("#dd" + i + "  .dTreeNodeChild");
            var length = $("#dd" + i + "  .dTreeNodeChild").length;
            for (j = 1; j <= length; j++) {
                alert($("#dd" + i + "  .dTreeNodeChild input").get(0).checked);
                 .get(0).checked
                 if ($("#dd" + i + "  .dTreeNodeChild input").is(':checked')) {

                 }
            }
        }
        //alert($("#dd1 .dTreeNodeChild").length);
        */
        //
    })
</script>