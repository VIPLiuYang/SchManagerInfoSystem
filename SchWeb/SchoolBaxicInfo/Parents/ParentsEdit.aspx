<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParentsEdit.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.Parents.ParentsEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>家长信息</title>
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
    
</head>
<body>
    <div class="main-container" id="main-container">
			<script type="text/javascript">
			    try { ace.settings.check('main-container', 'fixed') } catch (e) { }
			</script>

			<div class="main-container-inner">

				<div class="main-content" style="margin-left:0px">
					<div class="breadcrumbs" id="breadcrumbs">
						<script type="text/javascript">
						    try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
						</script>

						<ul class="breadcrumb">
							<li>
								<i class="icon-home home-icon"></i>
								<a href="#">首页</a>
							</li>
							<li class="active">家长信息</li>
						</ul><!-- .breadcrumb -->

						<div class="nav-search" id="nav-search">
							<form class="form-search">
								<span class="input-icon">
									<input type="text" placeholder="Search ..." class="nav-search-input" id="nav-search-input" autocomplete="off" />
									<i class="icon-search nav-search-icon"></i>
								</span>
							</form>
						</div><!-- #nav-search -->
					</div>

					<div class="page-content">
						<div class="page-header">
							<h1>
								家长信息
							</h1>
						</div><!-- /.page-header -->
                        <div class="row">
                            <div class="col-sm-12">现在正在<span id="caozuo"></span><span id="StuName" style="color:red;"></span> 的家长信息：</div>
                        </div>
						<div class="row">
							<div class="col-xs-12">

								<form class="form-horizontal" role="form">
                                    <input type="hidden" name="StuId" id="StuId" />
                                    <input type="hidden" id="Id" name="ClassId" value=""/>
									<div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-1"> 登录名： </label>

										<div class="col-sm-9">
											<input type="text" id="form-field-1" placeholder="登录名" class="col-xs-10 col-sm-5" />
										</div>
									</div>
                                    
									<div class="space-4"></div>

									<div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-4">密码：</label>

										<div class="col-sm-9">
											<input class="col-xs-10 col-sm-5" type="password" id="form-field-4" placeholder="******" />
											<div class="space-2"></div>

											<div class="help-block" id="input-size-slider"></div>
										</div>
									</div>

                                    <div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-6">家长姓名：</label>
                                         <div class="col-sm-9">
											<input class="col-xs-10 col-sm-5" type="text" id="form-field-6" placeholder="家长姓名" />
										</div>
									</div>

									<div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-5">手机号：</label>

										<div class="col-sm-9">
											<input class="col-xs-10 col-sm-5" type="text" id="form-field-5" placeholder="151********" />
										</div>
									</div>
                                    
                                    <div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-5">性别：</label>

										<div class="col-sm-9">
											<div class="radio">
													<label>
														<input name="form-field-radio" class="ace" type="radio" checked="checked" value="1" />&nbsp;
														<span class="lbl">男</span>
													</label>&nbsp;&nbsp;
                                                    <label>
														<input name="form-field-radio" class="ace" type="radio" value="0" />&nbsp;
														<span class="lbl">女</span>
													</label>
									        </div>
										</div>
									</div>
                                    <div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-5">头像：</label>

										<div class="col-sm-9">
                                            <input type="file" id="FileUp" name="FileUp" />
										</div>
									</div>
									
									<div class="space-4"></div>
                                   
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

		<!--[if lte IE 8]>
		  <script src="/assets/js/excanvas.min.js"></script>
		<![endif]-->

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

		<!-- ace scripts -->
		<script src="/assets/js/ace-elements.min.js"></script>
		<script src="/assets/js/ace.min.js"></script>
</body>
</html>
<script type="text/javascript">
    //添加保存数据方法
    function Add() {
        var ln = $("#form-field-1").val();
        if (ln == "") {alert("登录名不允许为空");return false;}
        var pwd = $("#form-field-4").val();
        if (pwd == "") {alert("密码不允许为空");return false;}
        var gn = $("#form-field-6").val();
        if (gn == "") {alert("家长姓名不允许为空");return false;}
        var mo = $("#form-field-5").val();
        if (mo == "") {alert("手机号码不允许为空");return false;} 
        var sex = $("input[name='form-field-radio']:checked").val();
        if (sex == "") {alert("性别不允许为空");return false;}
        var stuId = $("#StuId").val();
        $.ajax({
            url: "ashx/Parents.ashx",
            type: "POST",
            async: true,
            data: { Action: "Add",StuId:stuId, LoginName: ln, Pwd: pwd, GenName: gn, Mobile: mo,Sex:sex },
            dataType: "text",
            contentType: "application/x-www-form-urlencoded; charset=utf-8",
            success: function (data, textStatus) {
                if (data > 0) {
                    alert("添加成功");
                    self.location = "/SchoolBaxicInfo/Student/StudentList.aspx";
                } else {
                    alert("添加失败");
                }
            }
        });
    }
    //编辑方法
    function Edit(id) {
        if (confirm("确定编辑该家长信息吗?")) {
            $.ajax({
                url: "ashx/Parents.ashx",
                type: "POST",//或GET
                async: true,//或false,是否异步
                data: { Action: "Edit", GenId: id },
                dataType: "json",//返回的数据格式：json/xml/html/script/jsonp/text
                timeout: 5000,    //超时时间
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                success: function (data, textStatus) {
                    $.each(data.rows, function (index, content) {
                        $("#form-field-1").val(content.LoginName);
                        $("#form-field-4").val(content.Pwd);
                        $("#form-field-6").val(content.GenName);
                        $("#form-field-5").val(content.Mobile);
                        $("#StuName").html(content.StuName);
                        $("input[name='form-field-radio'][value="+content.Sex+"]").attr("checked", true);
                    });
                }
            });
        } else {
            alert("取消了编辑");
            self.location = "/SchoolBaxicInfo/Parents/ParentsList.aspx";
        }
    }
    //编辑保存数据库方法
    function EditSave(id) {
        var ln = $("#form-field-1").val();
        if (ln == "") {
            alert("登录名不允许为空");
            return false;
        }
        var pwd = $("#form-field-4").val();
        if (pwd == "") {
            alert("密码不允许为空");
            return false;
        }
        var gn = $("#form-field-6").val();
        if (gn == "") {
            alert("家长姓名不允许为空");
            return false;
        }
        var mo = $("#form-field-5").val();
        if (mo == "") {
            alert("手机号码不允许为空");
            return false;
        }
        var sex = $("input[name='form-field-radio']:checked").val(); 
        if (sex == "") {
            alert("性别不允许为空");
            return false;
        }
        if (confirm("确定保存该家长信息吗?")) {
            $.ajax({
                url: "ashx/Parents.ashx",
                type: "POST",//或GET
                async: true,//或false,是否异步
                data: { Action: "EditSave", sId: id, LoginName: ln, Pwd: pwd, GenName: gn, Mobile: mo, Sex: sex },
                dataType: "text",//返回的数据格式：json/xml/html/script/jsonp/text
                timeout: 5000,    //超时时间
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                success: function (data, textStatus) {
                    if (data == "True") {
                        alert("编辑成功啦");
                        self.location = "/SchoolBaxicInfo/Parents/ParentsList.aspx";
                    } else {
                        alert("编辑失败了");
                    }
                }
            });
        } else {
            alert("取消了编辑");
        }
    }
</script>
<script type="text/javascript">
    //获取GET参数方法
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
    var cid = getPar("id");//获取get参数
    var stuId = getPar("stuId");//获取get参数的学生ID
    if (stuId != false) {
        $("#StuId").val(stuId);
        $.ajax({
            url: "ashx/Parents.ashx",
            type: "POST",//或GET
            async: true,//或false,是否异步
            data: { Action: "null", StuId: stuId},
            dataType: "json",//返回的数据格式：json/xml/html/script/jsonp/text
            timeout: 5000,    //超时时间
            contentType: "application/x-www-form-urlencoded; charset=utf-8",
            success: function (data, textStatus) {
                $.each(data.SchStuInfo, function (index, content) {
                    $("#StuName").html(content.StuName);
                });
            }
        });
    }
    if (cid == false) {
        $(".icon-ok").html("添加");//如果没有ID，则说明是添加按钮
        $("#caozuo").html("添加");
    } else {
        $(".icon-ok").html("保存"); //如果有ID，则说明是修改按钮
        $("#caozuo").html("修改");
        $("#Id").val(cid);
        Edit(cid);
    }
    $(".btn-info").click(function () {
        var id = $("#Id").val();//获取班级编号（自动）
        if (id != "") {
            EditSave(id);//保存编辑
        } else {
            Add();//添加保存
        }
    });
    </script>