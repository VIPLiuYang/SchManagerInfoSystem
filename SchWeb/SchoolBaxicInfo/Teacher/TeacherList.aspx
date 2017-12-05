<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherList.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.Teacher.TeacherList" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>教师信息</title>
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300" />
    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <script src="js/vue.js" type="text/javascript"></script>
    <script src="../../assets/js/ace-extra.min.js"></script>
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
                            <a href="#">首页</a>
                        </li>
                        <li>
                            <a href="#">教师信息</a>
                        </li>
                    </ul>
                </div>
                <br />
                <div class="page-content">
                    <div class="row">
                        <div class="col-xs-12" id="demo">
                            &nbsp &nbsp &nbsp;&nbsp;<input type="text" id="UserTname" style="width: 200px; height: 25px" placeholder="教师姓名">
                            <button type="button" class="btn-info " v-on:click="sel"><i class="icon-search"></i>查询</button>
                            <button type="button" class="btn-info" v-on:click="add"><i class="icon-plus"></i>添加教师</button>
                            <h3 class="header smaller lighter blue"></h3>
                            <div class="table-header">
                                教师信息
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
												<table class="table table-striped table-bordered table-hover">
                                            <thead>
                                                <tr>
                                                    <th class="center">
                                                        <label>
                                                            <input type="checkbox" class="ace" />
                                                            <span class="lbl"></span>
                                                        </label>
                                                    </th>
                                                    <th>姓名</th>
                                                    <th>所在部门</th>
                                                    <th>手机号</th>
                                                    <th>作为班主任的班级</th>
                                                    <th>创建时间</th>
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
                                                    <td>{{item.UserTname}}</td>
                                                    <td>{{item.Departname}}</td>
                                                    <td>{{item.Mobile}}</td>
                                                    <td>{{item.ClassMs}}</td>
                                                    <td>{{item.RecTime}}</td>
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
											</div>
										</div>
									</div>
								</template>
                        </div>
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
    <script src="../../assets/js/typeahead-bs2.min.js"></script>
    <script src="../../assets/js/jquery.dataTables.min.js"></script>
    <script src="../../assets/js/jquery.dataTables.bootstrap.js"></script>
    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/bootbox.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>
    <script type="text/javascript">
        var PriDepList;
        var PriGradeList;
        //初始化页面查询
        window.onload = function () {
            $.ajax({
                type: "POST",
                url: "ashx/Teacher.ashx?action=Search",
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
        //创建自定义组件
        Vue.component('mytest', {
            props: ['value'],
            template: '#table',
            methods: {
                //编辑弹出并绑定数据方法
                edit: function (item) {
                    var UserId = item.UserId
                    self.location.href = "TeacherEdit.aspx?depid=" + UserId;
                },
                //删除一行数据方法
                del: function (item) {
                    var msg = "您真的确定要删除吗？\n\n请确认！";
                    if (confirm(msg) == true) {
                        $.ajax({
                            type: "POST",
                            url: "ashx/Teacher.ashx?action=Delete",
                            dataType: "json",
                            data: { "UserId": item.UserId },
                            success: function (data) {
                                alert(data);
                            }
                        });
                        for (var i = dt.arraylist.length - 1; i >= 0; i--) {
                            if (dt.arraylist[i].UserId == item.UserId)
                                dt.arraylist.splice(i, 1);
                        }
                    } else {
                        return false;
                    } 
                }
            }
        }) 
        //数据列表组件
        var dt = new Vue({
            el: '#demo',
            data: {
                arraylist: []
            },
            methods: {
                //查询带有条件的方法
                sel: function () {
                    var UserTname = $("#UserTname").val();
                    $.ajax({
                        type: "POST",
                        url: "ashx/Teacher.ashx?action=Search",
                        dataType: "json",
                        data: { "UserTname": UserTname, PageCount: 20, PageSize: 10, PageIndex: pageI },
                        success: function (data) {
                            dt.arraylist = data.rows;
                        }
                    });
                },
                //添加弹出框
                add: function () {
                    self.location.href = "TeacherEdit.aspx";
                }
            }
        })
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
