<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeppartEdit.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.Department.DeppartEdit" %>

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
                       <div class="page-header">
							<h1 id="title"></h1>
						</div><!-- /.page-header -->
                    <div class="row">
							<div class="col-xs-12"> 
								<form class="form-horizontal" role="form" id="form">
                                    <input type="hidden" id="Id" name="ClassId" value=""/>
									<div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-1"> 部门名称： </label> 
										<div class="col-sm-9">
											<input type="text" id="form-field-1" v-model="DepartName" placeholder="部门名称" class="col-xs-10 col-sm-5" />
										</div>
									</div> 
									<div class="space-4"></div> 
									<div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-4">上级部门：</label> 
										<div class="col-sm-9"> 
                                            <div id="Pripid">
                                            <select class="col-xs-10 col-sm-5"   > 
                                                  <option  value='0' selected="selected" >请选择上级部门...</option> 
                                                   <option id="selectDropdown" :value='item.DepartId' v-for="item in Depar">{{item.DepartName}}</option> 
                                            </select>  
                                                </div>
											<div class="space-2"></div> 
											<div class="help-block" id="input-size-slider"></div>
										</div>
									</div> 
                                    <div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-4">所属学校：</label> 
										<div class="col-sm-9">
                                            <div id="Prishc">  
											<select class="col-xs-10 col-sm-5" > 
                                                  <option  value='0' selected="selected" >请选择所属学校...</option> 
                                                   <option id="selectDropdown1" :value='item1.SchId' v-for="item1 in Sch">{{item1.SchName}}</option> 
                                            </select> 
                                                 </div>
											<div class="space-2"></div> 
											<div class="help-block" id="input-size-slider5"></div>
										</div>
									</div> 
                                    <div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-6">状态：</label>
                                         <div class="col-sm-9"> 
                                             <select v-model="Stat" class="col-xs-10 col-sm-5" > 
                                                   <option  value='0' selected="selected" >有效</option> 
                                                   <option  value='1' >无效</option> 
                                            </select> 
										</div>
									</div> 
									<div class="clearfix form-actions">
										<div class="col-md-offset-3 col-md-9">
											<button class="btn btn-info " v-on:click="Save" type="button">
												<i class="icon-ok bigger-110"></i>
												保存
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
    <%--<script src="../../assets/js/DelDialog.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        var PriDepList;
        var PriSch;
        var PriDepid;
        window.onload = function () {
            //获取部门信息
            $.ajax({
                type: "POST",
                url: "ashx/Depart.ashx?action=Getdep",
                dataType: "json",
                data: "",
                success: function (data) {
                    PriDepList = data;
                    form.Depar = PriDepList;;
                }
            });
            //获取学校信息
            $.ajax({
                type: "POST",
                url: "ashx/Depart.ashx?action=GetSch",
                dataType: "json",
                data: "",
                success: function (data) {
                    PriSch = data;
                    form.Sch = PriSch;
                }
            });
            //判断是否为编辑
            PriDepid = getDataFromUrl(document.location.href);
            if (JSON.stringify(PriDepid) != undefined) {
                form.type = 'E';
                $("#title").text("编辑部门信息");
                $.ajax({
                    type: "POST",
                    url: "ashx/Depart.ashx?action=Search",
                    dataType: "json",
                    data: { "depid": PriDepid, PageCount: 20, PageSize: 10, PageIndex:1 },
                    success: function (data) { 
                        form.DepartName = data.rows[0].DepartName;
                        $("#Pripid option:selected").val(data.rows[0].Pid);
                        //获取部门信息绑定
                        $.ajax({
                            type: "POST",
                            url: "ashx/Depart.ashx?action=Getdep",
                            dataType: "json",
                            data: { 'depid': data.rows[0].Pid },
                            success: function (data1) { 
                                $("#Pripid option:selected").text(data1[0].DepartName);
                            }
                        }); 
                        var Pri_shc = $("#Prishc option:selected").val(data.rows[0].SchId);
                        //获取学校信息绑定
                        $.ajax({
                            type: "POST",
                            url: "ashx/Depart.ashx?action=GetSch",
                            dataType: "json",
                            data: { 'schid': data.rows[0].SchId },
                            success: function (data1) { 
                                $("#Prishc option:selected").text(data1[0].SchName);
                            }
                        });
                        form.SchId = data.rows[0].SchId;
                        form.Stat = data.rows[0].Stat;
                    }
                });
            } else {
                //添加
                form.type = 'A';
                $("#title").text("添加部门信息");
            }
        } 
        //form数据列表
        var form = new Vue({
            el: "form",
            data: {
                DepartName: '', Stat: '' |0, Depar: [], Sch: [], type: '', DepartId: ''
            },
            methods: {
                //添加保存和编辑保存
                Save: function () {
                    if (form.type == 'A') {//添加
                        var Pri_pid = $("#Pripid option:selected").val();
                        var Pri_shc = $("#Prishc option:selected").val(); 
                        if (form.DepartName == "") {
                            Pridialog("部门名称不能为空");
                            return false;
                        }
                        if (Pri_pid == 0) {
                            Pridialog("请选择上级部门");
                            return false;
                        }
                        if (Pri_shc == 0) {
                            Pridialog("请选择所属学校");
                            return false;
                        }
                        $.ajax({
                            type: "POST",
                            url: "ashx/Depart.ashx?action=Add",
                            dataType: "json",
                            data: { "DepartName": form.DepartName, "Pid": Pri_pid, "SchId": Pri_shc, "Stat": form.Stat },
                            success: function (data) { }
                        });
                        self.location = "/SchoolBaxicInfo/Department/DepartList.aspx";
                        Pridialog("添加成功！");
                        form.DepartName = "";
                        form.SchId = "";
                        form.Pid = "";
                        form.Stat = '';
                    } else {//编辑
                        if (form.DepartName == "") {
                            Pridialog("部门名称不能为空");
                            return false;
                        }
                        if (form.Pid == "") {
                            Pridialog("请选择上级部门");
                            return false;
                        }
                        if (form.SchId == "") {
                            Pridialog("请选择所属学校");
                            return false;
                        }
                        $.ajax({
                            type: "POST",
                            url: "ashx/Depart.ashx?action=Edit",
                            dataType: "json",
                            data: { "DepartId": PriDepid, "DepartName": form.DepartName, "Pid": form.Pid, "SchId": form.SchId, "Stat": form.Stat },
                            success: function (data) { }
                        });
                        self.location = "/SchoolBaxicInfo/Department/DepartList.aspx";
                        Pridialog("修改成功！");
                    }
                }
            }
        }) 
        //获取id
        function getDataFromUrl(url) {
            var ret = url.split("=")[1];
            return ret;
        }
        //弹框
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

