<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.Teacher.Teacher" %>


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
                  <h3 class="header smaller lighter blue"></h3>  
                    <div class="row" style="height: 450px">
                        <div class="col-xs-12">  
									<div class="row">
										<div>
											<div class="table-responsive">
												<table id="sample-tabl-1" class="table table-striped table-bordered table-hover">
													<thead>
														<tr>
															<th class="center">
																<label>
																<input type="checkbox" class="ace" id="selectAll" />
																<span class="lbl"></span>
															</label>
															</th>
															<th>姓名</th>
															<th>所在部门</th>
															<th>电话</th>
															<th>作为班主任的班级</th> 
														</tr>
													</thead>
													<tbody>
														<tr v-for="item in arraylist" >
															<td class="center">
																<label>
																<input type="checkbox" name="r" class="ace" />
																<span class="lbl"></span>
															</label>
															</td>
															<td>{{item.UserTname}}</td>
															<td>{{item.DepartIds}}</td>
															<td>{{item.Mobile}}</td>
															<td>{{item.ClassMs}}</td>
															 
														</tr>
													</tbody>
												</table>
											</div>
										</div>
									</div>
								 
                            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="PriModalLabel">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content"> 
                                        <div class="modal-header">         
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>           
                                            <h4 class="modal-title" id="PriModalLabel">新增</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="form-group">       
                                                <label for="txt_departmentname">部门名称</label>         
                                                <input type="text" name="txt_departmentname" v-model="DepartName"  class="form-control" id="txt_departmentname" placeholder="部门名称">    
                                            </div>      
                                            <div class="form-group">             
                                                <label for="txt_parentdepartment">上级部门</label>             
                                               <select class="form-control"  v-model="Pid"  >
                                                   <option>请选择一个部门</option>
																<option value="0">开发部</option>
																<option value="1">财务部</option>
                                                                <option value="2">采购部</option>
                                               <</select>      
                                            </div>    
                                            <div class="form-group">        
                                                <label for="txt_departmentlevel">学校</label>
                                              <select class="form-control"   v-model="SchId" >
																<option value="0">济南大学</option>
																<option value="1">山东大学</option>
                                                                <option value="2">烟台大学</option>
                                               <</select>
                                            </div>       
                                        </div>    
                                        <div class="modal-footer">               
                                            <button type="button" class="btn btn-default" data-dismiss="modal"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span>关闭</button>            
                                            <button type="button" id="btn_submit" v-on:click="save" class="btn btn-primary" data-dismiss="modal"><span class="icon-hdd" aria-hidden="true"></span>保存</button>
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
    <script src=""></script>

    <script type="text/javascript">
        window.onload = function () {
            $.ajax({
                type: "POST",
                url: "ashx/Depart.ashx?action=Search",
                dataType: "json",
                data: "",
                success: function (data) {
                    dt.arraylist = data;
                }
            });
        }
        jQuery(function ($) {
            var oTable1 = $('#sample-table-2').dataTable({
                "aoColumns": [{
                    "bSortable": false
                },
                    null, null, null, null, null,
                    {
                        "bSortable": false
                    }
                ]
            });
        })
        
        //var list = new Vue({
        //    el: '#myModal',
        //    data: {
        //        DepartName: '',
        //        Pid: '',
        //        SchId:''
        //    }, methods: {
        //        save: function () { 
        //            $.ajax({
        //                type: "POST",
        //                url: "ashx/Depart.ashx?action=Add",
        //                dataType: "json",
        //                data: { "DepartName": list.DepartName, "Pid": list.Pid, "SchId": list.SchId },
        //                success: function (data) {
                            
        //                }
        //            });
        //            Pridialog("添加成功！");
        //        }
        //    }
        //})
        var dt = new Vue({
            el: '#sample-tabl-1',
            data: {
                arraylist: []
            },
            methods: {
                sel: function () {
                    $.ajax({
                        type: "POST",
                        url: "ashx/Depart.ashx?action=Search",
                        dataType: "json",
                        data: "",
                        success: function (data) {
                            dt.arraylist = data;
                        }
                    });
                },
                add: function () {
                   
                },
                edit: function () {
                    
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
    <div style="display: none">
        <script src='http://v7.cnzz.com/stat.php?id=155540&web_id=155540' language='JavaScript' charset='gb2312'></script>
    </div>
</body>

</html>
