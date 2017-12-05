<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassEdit.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.Grade.Class.ClassEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>班级信息</title>
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

							<li>
								<a href="#">年级信息</a>
							</li>
							<li class="active">班级信息</li>
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
								年级信息
								<small>
									<i class="icon-double-angle-right"></i>
									班级信息
								</small>
							</h1>
						</div><!-- /.page-header -->

						<div class="row">
							<div class="col-xs-12">

								<form class="form-horizontal" role="form">
                                    <input type="hidden" id="ClassId" name="ClassId" value=""/>
									<div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-1"> 班级编号： </label>

										<div class="col-sm-9">
											<input type="text" id="form-field-1" placeholder="ClassNumber" class="col-xs-10 col-sm-5" />
										</div>
									</div>
                                    
									<div class="space-4"></div>

									<div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-4">班级名称：</label>

										<div class="col-sm-9">
											<input class="input-sm" type="text" id="form-field-4" placeholder="ClassName" />
											<div class="space-2"></div>

											<div class="help-block" id="input-size-slider"></div>
										</div>
									</div>

                                    <div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-6">学校：</label>
                                            
                                        <input type="hidden" class="col-xs-10 col-sm-5" id="SchNameId" />
										
                                            <label id="SchNameTitle" class="col-sm-3" for="form-field-6"></label>
										
									</div>

									<div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-5">年级名称：</label>

										<div class="col-sm-9">
											<select class="width-80" id="form-field-select-2">
                                                <option value="">Choose a Grade...</option>
                                            </select>
                                            <span class="help-button" data-rel="popover" data-trigger="hover" data-placement="left" data-content="请选择年级" title="下拉列表框">?</span>
										</div>
									</div>
									<div class="space-4"></div>
                                    <script type="text/javascript">
                                        //$(document).ready(function () {
                                        $.ajax({
                                            url: "ashx/Class.ashx",
                                            type: "POST",//或GET
                                            async: true,//或false,是否异步
                                            data: { Action: "null" },
                                            dataType: "json",//返回的数据格式：json/xml/html/script/jsonp/text
                                            //timeout: 5000,    //超时时间
                                            contentType: "application/x-www-form-urlencoded; charset=utf-8",
                                            success: function (data, textStatus) {
                                                $.each(data.SchInfo, function (index, content) {
                                                    $("#SchNameTitle").html(content.SchName);
                                                    $("#SchNameId").val(content.SchId);
                                                });

                                                text2 = "<option value=\"00\">Choose a Greade...</option>";
                                                $.each(data.SchGradeInfo, function (index, content) {
                                                    text2 += "<option value=\"" + content.GradeId + "\">" + content.GradeName + "</option>";
                                                });
                                                $("#form-field-select-2").html(text2);//显示数据列表
                                            }
                                        });
                                        //});
                                                 </script>
									

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

		

		<!-- page specific plugin scripts -->

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
    function ClassAdd() {
        var cNo = $("#form-field-1").val();
        if (cNo == "") {
            alert("班级编号不允许为空");
            return false;
        }
        var cName = $("#form-field-4").val();
        if (cName == "") {
            alert("班级名称不允许为空");
            return false;
        }
        var gName = $("#form-field-select-2").val();
        if (gName == "00") {
            alert("请选择年级");
            return false;
        }
        var sId = $("#SchNameId").val();
        $.ajax({
            url: "ashx/Class.ashx",
            type: "POST",//或GET
            async: true,//或false,是否异步
            data: { Action: "Add", ClassNo: cNo, ClassName: cName, GradeName: gName, SchId: sId },
            dataType: "text",//返回的数据格式：json/xml/html/script/jsonp/text
            //timeout: 5000,    //超时时间
            contentType: "application/x-www-form-urlencoded; charset=utf-8",
            success: function (data, textStatus) {
                if (data > 0) {
                    alert("添加成功");
                    self.location = "/SchoolBaxicInfo/Grade/Class/ClassList.aspx";
                } else {
                    alert("添加失败");
                }
            }
        });
    }
    //编辑方法
    function ClassEdit(id) {
       
        if (confirm("确定编辑该班级吗?")) {
            $.ajax({
                url: "ashx/Class.ashx",
                type: "POST",//或GET
                async: true,//或false,是否异步
                data: { Action: "Edit", ClassId: id },
                dataType: "json",//返回的数据格式：json/xml/html/script/jsonp/text
                timeout: 5000,    //超时时间
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                success: function (data, textStatus) {
                    $.each(data.rows, function (index, content) {
                        $("#form-field-1").val(content.ClassNo);
                        $("#form-field-4").val(content.ClassName);
                        $("#form-field-select-2").val(content.GradeId);
                    });
                }
            });
        } else {
            alert("取消了编辑");
            self.location = "/SchoolBaxicInfo/Grade/Class/ClassList.aspx";
        }
    }
    //编辑保存数据库方法
    function ClassEditSave(id) {
        var cNo = $("#form-field-1").val();
        if (cNo == "") {
            alert("班级编号不允许为空");
            return false;
        }
        var cName = $("#form-field-4").val();
        if (cName == "") {
            alert("班级名称不允许为空");
            return false;
        }
        var gName = $("#form-field-select-2").val();
        if (gName == "00") {
            alert("请选择年级");
            return false;
        }
        var sId = $("#SchNameId").val();
        if (confirm("确定保存该班级吗?")) {
            $.ajax({
                url: "ashx/Class.ashx",
                type: "POST",//或GET
                async: true,//或false,是否异步
                data: { Action: "EditSave", ClassId: id, ClassNo: cNo, ClassName: cName, GradeName: gName },
                dataType: "text",//返回的数据格式：json/xml/html/script/jsonp/text
                timeout: 5000,    //超时时间
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                success: function (data, textStatus) {
                    if (data == "True") {
                        alert("编辑成功啦");
                        self.location = "/SchoolBaxicInfo/Grade/Class/ClassList.aspx";
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
    if (cid == false) {
        $(".icon-ok").html("添加");//如果没有ID，则说明是添加按钮
    } else {
        $(".icon-ok").html("保存"); //如果有ID，则说明是修改按钮
        $("#ClassId").val(cid);
        ClassEdit(cid); 
    }
    $(".btn-info").click(function () {
        var id = $("#ClassId").val();//获取班级编号（自动）
        if (id != "") {
             ClassEditSave(id);//保存编辑
        } else {
             ClassAdd();//添加保存
        }
    });
    </script>
