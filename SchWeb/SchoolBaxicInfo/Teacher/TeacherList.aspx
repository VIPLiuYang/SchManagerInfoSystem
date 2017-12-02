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
                            <%--<button class="btn btn-info" v-on:click="sel">
                                <i class="icon-search"></i>
                                查询
                            </button>
                            <button class="btn btn-info" v-on:click="add">
                                <i class="icon-plus"></i>
                                添加
                            </button>
                            <button class="btn btn-info" id="edit">
                                <i class="icon-pencil"></i>
                                修改
                            </button>
                            <button class="btn btn-info" id="del">
                                <i class="icon-trash "></i>
                                删除
                            </button>--%>
                             &nbsp &nbsp &nbsp;&nbsp;<input type="text" id="UserTname" style="width: 200px; height: 25px" placeholder="教师姓名">
                                <button type="button" class="btn-info " v-on:click="sel"><i class="icon-search"></i>查询</button>
                                <button type="button" class="btn-info" v-on:click="add"> <i class="icon-plus"></i>添加教师</button>
                                <h3 class="header smaller lighter blue"></h3>
                                <div class="table-header">
                                    教师信息
                                </div>
                            <mytest v-bind:value="arraylist"></mytest>
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
                            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="PriModalLabel">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content"> 
                                        <div class="modal-header">         
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>           
                                            <h4 class="modal-title" id="PriModalLabel">新增</h4>
                                        </div>
                                        <div class="modal-body">
                                                <table>
                                                <tr>
                                                    <td>教师姓名:</td>
                                                    <td><input type="text" v-model="UserTname" style="width:150px;height:30px" /></td>
                                                    <input v-model="type"  style="display:none" />
                                                   <input v-model="UserId"  style="display:none" />
                                                    <td>所在部门:</td>
                                                    <td> 
                                                        <div id="PriDep">
                                                            <select class="form-control" id="select" style="width:150px;height:30px"> 
                                                               <option id="selectDropdown" :value='item.DepartId' v-for="item in Depar">{{item.DepartName}}</option> 
                                                            </select> 
                                                            </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>手机号:</td>
                                                    <td><input type="text" v-model="Mobile" style="width:150px;height:30px" /></td>
                                                    <td>作为班主任的班级:</td>
                                                    <td>
                                                        <div id="PriGrad">
                                                        <select class="form-control" id="select1" style="width:150px;height:30px"> 
                                                               <option id="selectDropdown1" :value='item1.gradeid' v-for="item1 in Grade">{{item1.gradename}}</option> 
                                                        </select> 
                                                            </div>
                                                    </td>
                                                </tr>
                                            </table>
                                             
                                        </div>    
                                        <div class="modal-footer">               
                                            <button type="button" class="btn btn-default" data-dismiss="modal"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span>关闭</button>            
                                            <button type="button" id="btn_submit" v-on:click="save(type)" class="btn btn-primary" data-dismiss="modal"><span class="icon-hdd" aria-hidden="true"></span>保存</button>
                                        </div>          
                                    </div>     
                                </div>
                            </div> 
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
                data: "",
                success: function (data) {
                    dt.arraylist = data;
                }
            });

            $.ajax({
                type: "POST",
                url: "ashx/Teacher.ashx?action=Getdep",
                dataType: "json",
                data: "",
                success: function (data) {
                    PriDepList = data;
                }
            });
            $.ajax({
                type: "POST",
                url: "ashx/Teacher.ashx?action=Getgrade",
                dataType: "json",
                data: "",
                success: function (data) {
                    PriGradeList = data;
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
                    list.type = "E";
                    $("#PriModalLabel").text("编辑部门信息");
                    $('#myModal').modal();
                    list.UserTname = item.UserTname;
                    //$("#PriDep option:selected").text(item.Departname);
                    //$("#PriDep option:selected").val(item.DepartIds);
                    list.Mobile = item.Mobile;
                    list.Depar = PriDepList;
                    list.ClassMs = item.ClassMs;
                    list.UserId = item.UserId;
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
        //弹出窗口组件
        var list = new Vue({
            el: '#myModal',
            data: {
                type: '',
                UserId:'',
                UserTname: '',
                DepartIds: '',
                Mobile: '',
                ClassMs: '',
                Depar: [],
                Grade: [{ GradeId: "1001", GradeName:"一年级"}]
            }, methods: {
                //添加保存方法
                save: function (type) { 
                    if (type=="A") {
                        var PriDep = $("#PriDep option:selected").val();
                        var PriGrad = $("#PriGrad option:selected").text(); 
                        $.ajax({
                            type: "POST",
                            url: "ashx/Teacher.ashx?action=Add",
                            dataType: "json",
                            data: { "UserTname": list.UserTname, "DepartIds": PriDep, "Mobile": list.Mobile, "ClassMs": PriGrad },
                            success: function (data) {
                            }
                        });
                        Pridialog("添加成功！");
                        window.onload();
                        list.UserTname = "";
                        list.DepartIds = "";
                        list.Mobile = "";
                        list.ClassMs = "";
                    } else {
                        var PriDep = $("#PriDep option:selected").val();
                        $.ajax({
                            type: "POST",
                            url: "ashx/Teacher.ashx?action=Edit",
                            dataType: "json",
                            data: { "UserTname": list.UserTname, "DepartIds": PriDep, "Mobile": list.Mobile, "ClassMs": list.ClassMs, "UserId": list.UserId },
                            success: function (data) {
                            }
                        });
                        Pridialog("修改成功！");
                        window.onload();
                        list.UserTname = "";
                        list.DepartIds = "";
                        list.Mobile = "";
                        list.ClassMs = "";
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
                        data: { "UserTname": UserTname },
                        success: function (data) {
                            dt.arraylist = data;
                        }
                    });
                },
                //添加弹出框-获取教师信息
                add: function () {
                    list.type = "A";
                    list.Depar = PriDepList;
                    list.Grade = PriGradeList;
                    $("#PriModalLabel").text("添加教师");
                    $('#myModal').modal(); 
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