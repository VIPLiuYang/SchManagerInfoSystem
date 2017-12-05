<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartList.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.Department.DepartList" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>部门信息</title>
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300" />
    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/laypage.css" />
    <script src="js/vue.js" type="text/javascript"></script>
    <script src="../../assets/js/ace-extra.min.js"></script>
    <script src="http://www.jq22.com/jquery/jquery-1.10.2.js"></script>
    <script src="http://www.jq22.com/jquery/bootstrap-3.3.4.js"></script>
    <script src="../../assets/js/Pager/extendPagination.js"></script>
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
        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
                <div class="breadcrumbs" id="breadcrumbs">
                    <ul class="breadcrumb">
                        <li>
                            <i class="icon-home home-icon"></i>
                            <a href="DepartList.aspx">首页</a>
                        </li>
                        <li>
                            <a href="#">部门信息</a>
                        </li>
                    </ul>
                </div>
                <br />
                <div class="page-content">
                    <div class="row">
                        <div class="col-xs-12" id="demo">
                            &nbsp &nbsp &nbsp;&nbsp;<input type="text" id="Depname" style="width: 200px; height: 25px" placeholder="部门名称">
                            <button type="button" class="btn-info " v-on:click="sel"><i class="icon-search"></i>查询</button>
                            <button type="button" class="btn-info" v-on:click="add"><i class="icon-plus"></i>添加部门</button>
                            <h3 class="header smaller lighter blue"></h3>
                            <div class="table-header">
                                部门信息
                            </div>
                            <mytest v-bind:value="arraylist"></mytest>
                            <!--数据分页--开始-->
                            <div class="modal-footer no-margin-top">
                                <div class="pull-left">Showing 1 to <i id="PageIndex"></i>of <i id="RowCount"></i>entries</div>
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
                    <div class="row" style="height: 450px">
                        <div class="col-xs-12"> 
                            <template id="table">
									<div  >
										<div>
											<div>
												<table id="sample-table-2" class="table table-striped table-bordered table-hover">
													<thead>
														<tr>
															<th class="center">
																<label>
																<input type="checkbox" class="ace" />
																<span class="lbl"></span>
															</label>
															</th>
															<th>部门名称</th>
															<th>学校名称</th> 
															<th>上级部门
															</th>
															<th>
                                                                <i class="icon-time "></i>
                                                                最后编辑时间</th>
                                                            <th>最后编辑人</th>
                                                            <th class="hidden-480">状态</th>
                                                            <th>操作</th>
														</tr>
													</thead>
													<tbody>
														<tr v-for="item in value">
															<td class="center">
																<label>
																<input type="checkbox" class="ace" />
																<span class="lbl"></span>
															</label>
															</td>
															<td>{{item.DepartName}}</td>
															<td>{{item.SchName}}</td>
															
															<td>{{item.Pname}}</td>
															<td>{{item.LastRecTime}}</td>
                                                            <td>{{item.LastRecUser}}</td>
                                                            <td> 
                                                                <span v-if="item.Stat==0" style="color:	#007500">有效</span>
							                                    <span v-else style="color:#EA0000" >无效</span>
															</td>
                                                            <td>
                                                        <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons"> 
                                                            <a class="green" v-on:click="edit(item)">
                                                                <i class="icon-pencil bigger-130"></i>
                                                            </a> 
                                                            <a class="red" v-on:click="del(item)">
                                                                <i class="icon-trash bigger-130"></i>
                                                            </a>
                                                        </div> 
                                                        <div class="visible-xs visible-sm hidden-md hidden-lg">
                                                            <div class="inline position-relative">
                                                                <button class="btn btn-minier btn-yellow dropdown-toggle" data-toggle="dropdown">
                                                                    <i class="icon-caret-down icon-only bigger-120"></i>
                                                                </button> 
                                                            </div>
                                                        </div>
                                                    </td>
														</tr>
													</tbody> 
												</table>
                                                 <div  style="text-align:right;" id="callBackPager"></div>
											</div>
										</div>
									</div>
								</template>
                        </div>
                    </div>
                </div>
            </div>
        </div> 
        <script type="text/javascript">
            window.jQuery || document.write("<script src='../../assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
        </script>
        <script type="text/javascript">
            if ("ontouchend" in document) document.write("<script src='../../assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
        </script>
        <script src="../../assets/js/bootstrap.min.js"></script>
        <script src="../../assets/js/laypage.js" type="text/javascript"></script>
        <script src="../../assets/js/typeahead-bs2.min.js"></script>
        <script src="../../assets/js/jquery.dataTables.min.js"></script>
        <script src="../../assets/js/jquery.dataTables.bootstrap.js"></script>
        <script src="../../assets/js/ace-elements.min.js"></script>
        <script src="../../assets/js/bootbox.min.js"></script>
        <script src="../../assets/js/ace.min.js"></script>
        <%--<script src="../../assets/js/DelDialog.js" type="text/javascript"></script>--%>
        <script type="text/javascript">
            var PriDepList;
            var PriSch;
            var startIndex = 0;
            var endIndex = 10;
            window.onload = function () {
                //页面初始化获取数据
                Getlist();
            }
            function Getlist() {
                $.ajax({
                    type: "POST",
                    url: "ashx/Depart.ashx?action=Search",
                    dataType: "json",
                    data: { PageCount: 20, PageSize: 10, PageIndex: pageI },
                    success: function (data) {
                        dt.arraylist = data.rows;
                        $("#pages").html(data.pages);//显示数字分页格式
                        $("#RowCount").html(data.RowCount);//显示总条数
                        $("#PageIndex").html(data.PageIndex);//显示当前页 
                    }
                });
            }
            Vue.component('mytest', {
                props: ['value'],
                template: '#table',
                methods: {
                    //编辑弹出并绑定数据方法
                    edit: function (item) {
                        var depid = item.DepartId
                        self.location.href = "DeppartEdit.aspx?depid=" + depid;
                    },
                    //删除一行数据方法
                    del: function (item) {
                        var msg = "您真的确定要删除吗？\n\n请确认！";
                        if (confirm(msg) == true) {
                            $.ajax({
                                type: "POST",
                                url: "ashx/Depart.ashx?action=Delete",
                                dataType: "json",
                                data: { "DepartId": item.DepartId }, success: function (data) {
                                    alert(data);
                                }
                            });
                            for (var i = dt.arraylist.length - 1; i >= 0; i--) {
                                if (dt.arraylist[i].DepartId == item.DepartId)
                                    dt.arraylist.splice(i, 1);
                            }
                        } else {
                            return false;
                        }
                    }
                }
            })
            //显示数据列表
            var dt = new Vue({
                el: '#demo',
                data: {
                    arraylist: []
                },
                methods: {
                    //查询数据
                    sel: function () {
                        var Depname = $("#Depname").val();
                        $.ajax({
                            type: "POST",
                            url: "ashx/Depart.ashx?action=Search",
                            dataType: "json",
                            data: { Depname: Depname, PageCount: 20, PageSize: 10, PageIndex: pageI },
                            success: function (data) {
                                dt.arraylist = data.rows;
                                $("#pages").html(data.pages);//显示数字分页格式
                                $("#RowCount").html(data.RowCount);//显示总条数
                                $("#PageIndex").html(data.PageIndex);//显示当前页
                            }
                        });
                    },
                    //添加跳转
                    add: function () {
                        self.location.href = "DeppartEdit.aspx";
                    }
                }
            })
            //弹出框提示
            function Pridialog(mc) {
                bootbox.dialog({
                    message: mc,
                    buttons: {
                        "success": {
                            "label": "确定",
                            "className": "btn-sm btn-primary"
                        }
                    }
                });
            }
        </script>
</body>

</html>
