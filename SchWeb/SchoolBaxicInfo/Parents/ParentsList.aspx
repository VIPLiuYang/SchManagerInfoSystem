<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParentsList.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.Parents.ParentsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="keywords" content="金视野,教育,平台" />
	<meta name="description" content="金视野开发部,模板,2017" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>家长信息列表</title>
    <!-- basic styles -->
    <link href="/assets/css/bootstrap.min.css" rel="stylesheet" />
	<link rel="stylesheet" href="/assets/css/font-awesome.min.css" />
    <!--[if IE 7]>
        <link rel="stylesheet" href="/assets/css/font-awesome-ie7.min.css" />
	<![endif]-->
    <!-- page specific plugin styles -->
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

	<!-- ace settings handler -->
	<script src="/assets/js/ace-extra.min.js"></script>
	<!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
	<!--[if lt IE 9]>
        <script src="/assets/js/html5shiv.js"></script>
		<script src="/assets/js/respond.min.js"></script>
	<![endif]-->
    <script>
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
        var pageI = getPar("page");
        if (pageI == "") {
            pageI = 1;
        }
    </script>
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
								<a href="#">家长</a>
							</li>
							<li class="active">家长基本数据</li>
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

						<div class="row">
							<div class="col-xs-12">
								
								<div class="row">
									<div class="col-xs-12">
										<h3 class="header smaller lighter blue">家长基本数据&nbsp;&nbsp;<div id="add" class="btn btn-minier btn-yellow">添加</div></h3>
										<div class="table-header">
											家长基本信息管理
										</div>
										<div class="table-responsive">
											<table id="sample-table-2" class="table table-striped table-bordered table-hover">
												<thead>
													<tr>
														<th class="center">
															<label>
																<input type="checkbox" class="ace" />
																<span class="lbl"></span>
															</label>
														</th>
														<th>登录名</th>
														<th>性别</th>
														<th>家长姓名</th>
														<th>手机号码</th>
														<th>登陆时间</th>
														<th>操作</th>
													</tr>
												</thead>

												<tbody id="StuList">
                                                    <script type="text/javascript">
                                                        $.ajax({
                                                            url: "ashx/Parents.ashx",
                                                            type: "POST",//或GET
                                                            async: true,//或false,是否异步
                                                            data: { Action: "List", PageCount: 20, PageSize: 5, PageIndex: pageI },
                                                            dataType: "json",//返回的数据格式：json/xml/html/script/jsonp/text
                                                            timeout: 5000,    //超时时间
                                                            success: function (data, textStatus) {
                                                                var text = "";
                                                                $.each(data.rows, function (index, content) {
                                                                    var sex = content.Sex;
                                                                    if (sex == 1) {
                                                                        sex = "男";
                                                                    } else {
                                                                        sex = "女";
                                                                    }
                                                                    text += "<tr>";
                                                                    text += "   <td class=\"center\">";
                                                                    text += "       <label>";
                                                                    text += "           <input type=\"checkbox\" class=\"ace\" value=\"" + content.GenId + "\" />";
                                                                    text += "           <span class=\"lbl\"></span>";
                                                                    text += "       </label>";
                                                                    text += "   </td>";
                                                                    text += "   <td>" + content.LoginName + "</td>";
                                                                    text += "   <td>" + sex + "</td>";
                                                                    text += "   <td>" + content.GenName + "</td>";
                                                                    text += "   <td>" + content.Mobile + "</td>";
                                                                    text += "   <td>" + content.LoginTime + "</td>";
                                                                    text += "   <td>";
                                                                    text += "       <div class=\"visible-md visible-lg hidden-sm hidden-xs action-buttons\">";
                                                                    text += "	        <a class=\"blue\" href=\"#\">";
                                                                    text += "		        <i class=\"icon-zoom-in bigger-130\"></i>";
                                                                    text += "	        </a>";
                                                                    text += "	        <a class=\"green\" href=\"ParentsEdit.aspx?id=" + content.GenId + "\">";
                                                                    text += "		        <i class=\"icon-pencil bigger-130\"></i>";
                                                                    text += "	        </a>";
                                                                    text += "	        <a class=\"red\" href=\"#\">";
                                                                    text += "		        <i class=\"icon-trash bigger-130\" onclick=\"ParentDelete(" + content.GenId + ")\"></i>";
                                                                    text += "	        </a>";
                                                                    text += "       </div>";
                                                                    text += "   </td>";
                                                                    text += "<tr>";
                                                                });
                                                                $("#StuList").html(text);//显示数据列表
                                                                $("#pages").html(data.pages);//显示数字分页格式
                                                                $("#RowCount").html(data.RowCount);//显示总条数
                                                                $("#PageIndex").html(data.PageIndex);//显示当前页
                                                            }
                                                        });
                                                    </script>
												</tbody>
											</table>
										</div>
                                        <!--数据分页--开始-->
                                        <div class="modal-footer no-margin-top">
                                            <div class="pull-left">Showing 1 to <i id="PageIndex"></i> of <i id="RowCount"></i> entries</div>
                                            <ul class="pagination pull-right no-margin" id="pages">
                                                <li class="prev disabled">
                                                    <a href="#"><i class="icon-double-angle-left"></i></a>
                                                </li>
                                                <li class="active"><a href="#">1</a></li>
                                                <li><a href="#">2</a></li>
                                                <li><a href="#">3</a></li>
                                                <li class="next">
                                                    <a href="#"><i class="icon-double-angle-right"></i></a>
                                                </li>
                                            </ul>
										</div>
                                        <!--数据分页--结束-->
									</div>
								</div>

							</div><!-- /.col -->
						</div><!-- /.row -->
					</div><!-- /.page-content -->
				</div><!-- /.main-content -->

				<!-- /#ace-settings-container -->
			</div><!-- /.main-container-inner -->
		</div><!-- /.main-container -->
    <!-- basic scripts -->

    <script type="text/javascript">
        if ("ontouchend" in document) document.write("<script src='/assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
    </script>
    <script src="/assets/js/bootstrap.min.js"></script>
    <script src="/assets/js/typeahead-bs2.min.js"></script>
    <!-- page specific plugin scripts -->
    <!--<script src="/assets/js/jquery.dataTables.min.js"></script>//JS数字分页-->
    <script src="/assets/js/jquery.dataTables.bootstrap.js"></script>
    <!-- ace scripts -->
    <script src="/assets/js/ace-elements.min.js"></script>
    <script src="/assets/js/ace.min.js"></script>
    <!-- inline scripts related to this page -->
    
    <script type="text/javascript">
        $(document).ready(function () {
            
            //数据列表顶部复选框控制师傅全选或反选
            $("table#sample-table-2 th input:checkbox").click(function () {
                
                var that = this;
                $(this).closest("#sample-table-2").find("tr > td:first-child input:checkbox")
                .each(function () {
                    this.checked = that.checked;
                    $(this).closest("tr").toggleClass("selected");
                });
            });
            //进入添加页面
            $("#add").click(function () {
                self.location.href = "ParentsEdit.aspx";
            })
        })
    </script>
</body>
</html>
<script type="text/javascript">
    //软删除数据
    function ParentDelete(id) {
        if (confirm("确定删除该家长信息吗?")) {
            $.ajax({
                url: "ashx/Parents.ashx",
                type: "POST",//或GET
                async: true,//或false,是否异步
                data: { Action: "Delete", ParentsId: id },
                dataType: "text",//返回的数据格式：json/xml/html/script/jsonp/text
                //timeout: 5000,    //超时时间
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                success: function (data, textStatus) {
                    if (data == "True") {
                        alert("删除成功啦");
                        self.location = "/SchoolBaxicInfo/Parents/ParentsList.aspx";
                    } else {
                        alert("删除失败了");
                    }
                }
            });
        } else {
            alert("取消删除");
        }
    }
</script>