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
    <script src="js/vue.js" type="text/javascript"></script>
    <script src="../../assets/js/ace-extra.min.js"></script>
    <script src="http://www.jq22.com/jquery/jquery-1.10.2.js"></script>
<script src="http://www.jq22.com/jquery/bootstrap-3.3.4.js"></script>
<script src="../../assets/js/Pager/extendPagination.js"></script>
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
                            <a href="#">部门信息</a>
                        </li> 
                    </ul> 
                </div>
                <br />   
                <div class="page-content">
                       
                    <div class="row">
                        <div class="col-xs-12" id="demo"> 
                           <%-- <button class="btn btn-info" v-on:click="sel">
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
                            </button>
                            <h3 class="header smaller lighter blue"></h3>
                                <div class="table-header">
                                    部门信息
                                </div>--%>
                              &nbsp &nbsp &nbsp;&nbsp;<input type="text" id="Depname" style="width: 200px; height: 25px" placeholder="部门名称">
                                <button type="button" class="btn-info " v-on:click="sel"><i class="icon-search"></i>查询</button>
                                <button type="button" class="btn-info" v-on:click="add"><i class="icon-plus"></i>添加部门</button>
                                <h3 class="header smaller lighter blue"></h3>
                                <div class="table-header">
                                    部门信息
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
                                                                <span v-if="item.Stat==1" style="color:	#007500">有效</span>
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
                            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="PriModalLabel">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content"> 
                                        <div class="modal-header">         
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>           
                                            <h4 class="modal-title" id="PriModalLabel"></h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="form-group">       
                                                <label for="txt_departmentname">部门名称</label>         
                                                <input type="text" name="txt_departmentname" v-model="DepartName"  class="form-control" id="txt_departmentname" placeholder="部门名称">    
                                            </div>      
                                            
                                            <div class="form-group">             
                                                <label for="txt_parentdepartment">上级部门</label>             
                                                 <input v-model="type"  style="display:none" />
                                                 <input v-model="DepartId"  style="display:none" />
                                                <select class="form-control" id="select" v-model="Pid"> 
                                                               <option id="selectDropdown" :value='item.DepartId' v-for="item in Depar">{{item.DepartName}}</option> 
                                                            </select>  
                                            </div>    
                                            <div class="form-group">        
                                                <label for="txt_departmentlevel">学校</label>
                                               
                                                <select class="form-control" id="select1" v-model="SchId"> 
                                                               <option id="selectDropdown1" :value='item1.SchId' v-for="item1 in Sch">{{item1.SchName}}</option> 
                                                            </select> 
                                            </div>       
                                        </div>    
                                        <div class="modal-footer">               
                                            <button type="button" class="btn btn-default" data-dismiss="modal"><img src="../../assets/images/删除筛选项.png" width="15px" height="15px" />关闭</button>            
                                            <button type="button" id="btn_submit" v-on:click="save(type)"  class="btn btn-primary" data-dismiss="modal"><img src="../../assets/images/保存.png" width="15px" height="15px" /></span>保存</button>
                                        </div>          
                                    </div>     
                                </div>
                            </div>



                        </div>
                        <!-- /.col -->
                    </div>
            <!-- /.row -->
        </div>
        <!-- /.page-content -->
    </div>
    <!-- /.main-content -->

    <!-- /#ace-settings-container -->
    </div>
        <!-- /.main-container-inner -->
    </div>
    <!-- /.main-container -->

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
    <%--<script src="../../assets/js/DelDialog.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        var PriDepList;
        var PriSch;
        window.onload = function () {

            $.ajax({
                type: "POST",
                url: "ashx/Depart.ashx?action=Search",
                dataType: "json",
                data: "",
                success: function (data) {
                    dt.arraylist = data;
                    var totalCount = dt.arraylist.length, showCount = 10, limit = 10;
                    $('#callBackPager').extendPagination({
                        totalCount: totalCount,
                        showCount: showCount,
                        limit: limit,
                        callback: function (curr, limit, totalCount) {

                        }
                    });
                }
            });

            $.ajax({
                type: "POST",
                url: "ashx/Depart.ashx?action=Getdep",
                dataType: "json",
                data: "",
                success: function (data) {
                    PriDepList = data;
                }
            });
            $.ajax({
                type: "POST",
                url: "ashx/Depart.ashx?action=GetSch",
                dataType: "json",
                data: "",
                success: function (data) {
                    PriSch = data;
                }
            });
        }
        Vue.component('mytest', {
            props: ['value'],
            template: '#table',
            methods: {
                //编辑弹出并绑定数据方法
                edit: function (item) {
                    list.type = "E";
                    $("#PriModalLabel").text("编辑部门信息");
                    $('#myModal').modal();
                    list.DepartName = item.DepartName;
                    //$("#PriDep option:selected").text(item.Departname);
                    //$("#PriDep option:selected").val(item.DepartIds);
                  //  list.Pid = item.Pid;
                    list.SchId = item.SchId;
                    list.Depar = PriDepList;
                    list.DepartId = item.DepartId;
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
        var list = new Vue({
            el: '#myModal',
            data: {
                type: '',
                DepartId:'',
                DepartName: '',
                Pid: '',
                SchId: '',
                Depar: [],
                Sch:[]
            }, methods: {
                save: function (type) {
                    if (type == 'A') {
                        if (list.DepartName == "")
                            return
                        else if (list.Pid == "")
                            return
                        else if (list.SchId == "")
                            return 
                        $.ajax({
                            type: "POST",
                            url: "ashx/Depart.ashx?action=Add",
                            dataType: "json",
                            data: { "DepartName": list.DepartName, "Pid": list.Pid, "SchId": list.SchId },
                            success: function (data) {  }
                        });
                        Pridialog("添加成功！");
                        window.onload();
                        list.DepartName = "";
                        list.SchId = "";
                        list.Pid = ""; 
                    } else { 
                        if (list.DepartName == "")
                            return
                        else if (list.Pid == "")
                            return
                        else if (list.SchId == "")
                            return
                        $.ajax({
                            type: "POST",
                            url: "ashx/Depart.ashx?action=Edit",
                            dataType: "json",
                            data: { "DepartName": list.DepartName, "Pid": list.Pid, "SchId": list.SchId,"DepartId":list.DepartId },
                            success: function (data) { }
                        });
                        Pridialog("修改成功！"); 
                        list.DepartName = "";
                        list.SchId = "";
                        list.Pid = "";
                    }
                }
            }
        })
        var dt = new Vue({
            el: '#demo',
            data: {
                arraylist: []
            },
            methods: {
                sel: function () {
                    var Depname = $("#Depname").val();
                    $.ajax({
                        type: "POST",
                        url: "ashx/Depart.ashx?action=Search",
                        dataType: "json",
                        data: { "Depname": Depname },
                        success: function (data) {
                            dt.arraylist = data;
                        }
                    });
                },
                add: function () {
                    list.type = "A";
                    $("#PriModalLabel").text("添加部门信息");
                    $('#myModal').modal();
                    list.Depar = PriDepList;
                    list.Sch = PriSch;
                },
                edit: function () {
                    $("#PriModalLabel").text("编辑部门信息");
                    $('#myModal').modal();
                    alert(list.type);
                },
                del: function () {

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
