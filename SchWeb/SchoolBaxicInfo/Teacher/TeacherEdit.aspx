<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherEdit.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.Teacher.TeacherEdit" %>

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
    <%--<script src="../../assets/js/jquery.min.js"></script>--%>


    <link href="../../assets/js/jquery.uploadify-v2.1.0/example/css/default.css"  rel="stylesheet" type="text/css" />
    <link href="../../assets/js/jquery.uploadify-v2.1.0/uploadify.css" rel="stylesheet" type="text/css" /> 
    <script type="text/javascript"   src="../../assets/js/jquery.uploadify-v2.1.0/jquery-1.3.2.min.js"></script> 
    <script type="text/javascript"  src="../../assets/js/jquery.uploadify-v2.1.0/swfobject.js"></script> 
    <script type="text/javascript"  src="../../assets/js/jquery.uploadify-v2.1.0/jquery.uploadify.v2.1.0.min.js"></script>
     <script type="text/javascript">
         var PriImgurl;
         $(document).ready(function () {
             $("#uploadify").uploadify({
                 'uploader': '../../assets/js/jquery.uploadify-v2.1.0/uploadify.swf',//进度条，Uploadify里面含有
                 'script': 'ashx/Teacher.ashx?action=upload',
                 'cancelImg': '../../assets/js/jquery.uploadify-v2.1.0/cancel.png',
                 'folder': '../../UploadFileDir/Teacher',
                 'queueID': 'fileQueue',
                 'auto': true,
                 'multi': false,
                 'fileExt': '*.jpg;*.jpeg;*.png',
                 'fileDesc': '不超过2M的图片 (*.gif;*.jpg;*.png)',
                 'sizeLimit': 2048000,  //允许上传的文件大小(kb)  此为2M
                 'onSelectOnce': function (event, data) { //在单文件或多文件上传时，选择文件时触发 
                 },
                 'onComplete': function (event, queueID, fileObj, response, data) {//当单个文件上传完成后触发   
                     $("#imgurl").attr("src", fileObj.filePath);
                     PriImgurl = fileObj.filePath;
                     $("#name").text("       图片名称：" + fileObj.name);
                     $("#size").text("       图片大小：" + fileObj.size + "KB");
                     $("#dz").text("       图片地址：" + fileObj.filePath);
                 },
                 'onError': function (event, queueID, fileObj) {//当单个文件上传出错时触发
                     alert("文件:" + fileObj.name + " 上传失败！");
                 },
                 
                 //'width': 60,//浏览按钮的宽和高
                 //'height': 24 

             });
         });
    </script>
    <%--<script src="http://www.jq22.com/jquery/jquery-1.10.2.js"></script>--%>
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
                            <a href="TeacherList.aspx">首页</a>
                        </li> 
                        <li>
                            <a href="#">教师信息</a>
                        </li> 
                    </ul> 
                </div>
                <br />   
                <div class="page-content">
                       <div class="page-header">
							<h1 id="title"> </h1>
						</div><!-- /.page-header -->
                    <div class="row">
							<div class="col-xs-12"> 
								<form class="form-horizontal" role="form" id="form">
                                    <input type="hidden" id="Id" name="ClassId" value=""/>
                                    <div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-1"> 登录名： </label> 
										<div class="col-sm-9">
											<input type="text"  v-model="UserName" placeholder="登录名" class="col-xs-10 col-sm-5" />
										</div>
									</div>
                                    <div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-1"> 密码： </label> 
										<div class="col-sm-9">
											<input type="password"   v-model="PassWord" placeholder="密码" class="col-xs-10 col-sm-5" />
										</div>
									</div>
									<div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-1"> 教师姓名： </label> 
										<div class="col-sm-9">
											<input type="text"   v-model="UserTname" placeholder="教师姓名" class="col-xs-10 col-sm-5" />
										</div>
									</div>
                                    <div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-1"> 手机号： </label> 
										<div class="col-sm-9">
											<input type="text"   v-model="Mobile" placeholder="手机号" class="col-xs-10 col-sm-5" />
										</div>
									</div> 
									<div class="space-4"></div> 
									<div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-4">所在部门：</label> 
										<div class="col-sm-9"> 
                                            <div id="Pridep">
                                            <select class="col-xs-10 col-sm-5"   > 
                                                  <option  value='0' selected="selected" >请选择所在部门...</option> 
                                                   <option id="selectDropdown" :value='item.DepartId' v-for="item in Depar">{{item.DepartName}}</option> 
                                            </select>  
                                                </div>
											<div class="space-2"></div> 
											<div class="help-block" id="input-size-slider"></div>
										</div>
									</div> 
                                    <div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-4">作为班主任的班级：</label> 
										<div class="col-sm-9">
                                            <div id="Prishc">  
											<select class="col-xs-10 col-sm-5" > 
                                                  <option  value='0' selected="selected" >请选择班级...</option> 
                                                   <option id="selectDropdown1" :value='item1.gradeid' v-for="item1 in Sch">{{item1.gradename}}</option> 
                                            </select> 
                                                 </div>
											<div class="space-2"></div> 
											<div class="help-block" id="input-size-slider5"></div>
										</div>
									</div>  
                                    <div class="form-group">
										<label class="col-sm-3 control-label no-padding-right" for="form-field-10">头像：</label>
                                        
										<div class="col-sm-9"> 
                                            <table>
                                                <tr>
                                                    <td>
                                                        <div style="width: 160px; height: 155px; border:dashed;text-align:center">
                                                            <img  src="" style="width: 150px; height: 150px;" id="imgurl" border="0" />
                                                        </div> 
                                                    </td>
                                                    <td style="text-align:left">
                                                        <span id="name" style="text-align:left">&nbsp;&nbsp;&nbsp;&nbsp;</span><br /><br />
                                                        <span id="size" style="text-align:left">&nbsp;&nbsp;&nbsp;&nbsp;</span> <br /><br />
                                                         <span id="dz" style="text-align:left">&nbsp;&nbsp;&nbsp;&nbsp;</span> 
                                                    </td>
                                                   
                                                </tr>
                                                <tr>
                                                    <td><input type="file" name="uploadify" id="uploadify" /> </td>
                                                     
                                                </tr>
                                            </table>
                                                 
                                                <%--  <p>
                                                     
                                                     <%--<a href="javascript:$('#uploadify').uploadifyClearQueue()">取消上传</a>--%>
                                                     <%--<button class="btn btn-sm btn-danger active " onclick="$('#uploadify').uploadifyClearQueue()" type="button">
												      <i class="icon-ok bigger-110"></i>
												        移除
											             </button> 

                                                  </p> --%>
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
                url: "ashx/Teacher.ashx?action=Getdep",
                dataType: "json",
                data: "",
                success: function (data) {
                    PriDepList = data;
                    form.Depar = PriDepList;;
                }
            });
            //获取班级信息
            $.ajax({
                type: "POST",
                url: "ashx/Teacher.ashx?action=Getgrade",
                dataType: "json",
                data: "",
                success: function (data) {
                    PriSch = data;
                    form.Sch = PriSch;
                }
            });
            //判断是否为编辑
            PriUserId = getDataFromUrl(document.location.href); 
            if (JSON.stringify(PriUserId) != undefined) {//编辑
                form.type = 'E';
                $("#title").text("编辑教师信息");
                $.ajax({
                    type: "POST",
                    url: "ashx/Teacher.ashx?action=Search",
                    dataType: "json",
                    data: { "PriUserId": PriUserId, PageCount: 20, PageSize: 10, PageIndex: 1 },
                    success: function (data) { 
                        $("#imgurl").attr("src", data.rows[0].ImgUrl);
                        form.UserName = data.rows[0].UserName;
                        form.UserTname = data.rows[0].UserTname;
                        form.PassWord = data.rows[0].PassWord;
                        form.Mobile = data.rows[0].Mobile;
                        $("#Pridep option:selected").val(data.rows[0].DepartIds);
                        $.ajax({
                            type: "POST",
                            url: "ashx/Teacher.ashx?action=Getdep",
                            dataType: "json",
                            data: { 'depid': data.rows[0].DepartIds },
                            success: function (data1) {
                                $("#Pridep option:selected").text(data1[0].DepartName);
                            }
                        });
                        var Pri_shc = $("#Prishc option:selected").val(data.rows[0].SchId);
                        $.ajax({
                            type: "POST",
                            url: "ashx/Teacher.ashx?action=Getgrade",
                            dataType: "json",
                            data: { 'schid': data.rows[0].SchId },
                            success: function (data1) {
                                $("#Prishc option:selected").text(data1[0].ClassMs);
                            }
                        });
                        form.SchId = data.rows[0].SchId;
                        form.Stat = data.rows[0].Stat;
                    }
                });
            } else {//添加
                form.type = 'A';
                $("#title").text("添加教师信息");
            }
        }
        //form数据列表
        var form = new Vue({
            el: "form",
            data: {
                UserName: '', PassWord: '', UserTname: '', Mobile: '', Depar: [], Sch: [], Stat: '' | 0
            },
            methods: {
                //添加保存和编辑保存
                Save: function () {
                    if (form.type == 'A') {//添加 
                        var Pridep = $("#Pridep option:selected").val();
                        var Pri_shc = $("#Prishc option:selected").val();
                        if (form.UserName == "") {
                            Pridialog("登录名不能为空");
                            return false;
                        }
                        if (form.PassWord == "") {
                            Pridialog("密码不能为空");
                            return false;
                        }
                        if (form.UserTname == "") {
                            Pridialog("教师不能为空");
                            return false;
                        }
                        if (form.Mobile == "") {
                            Pridialog("手机号不能为空");
                            return false;
                        }
                        if (Pridep == 0) {
                            Pridialog("请选择所属部门");
                            return false;
                        }
                        if (Pri_shc == 0) {
                            Pridialog("请选择班级");
                            return false;
                        }
                        var Pridep = $("#Pridep option:selected").val();
                        var Pri_shc = $("#Prishc option:selected").val();
                        $.ajax({
                            type: "POST",
                            url: "ashx/Teacher.ashx?action=Add",
                            dataType: "json",
                            data: { "UserName": form.UserName, "PassWord": form.PassWord, "UserTname": form.UserTname, "Mobile": form.Mobile, "DepartIds": Pridep, "ClassMs": Pri_shc, "Stat": form.Stat,"imgurl":PriImgurl },
                            success: function (data) { }
                        });
                        self.location = "/SchoolBaxicInfo/Teacher/TeacherList.aspx";
                        Pridialog("添加成功！");
                        form.DepartName = "";
                        form.SchId = "";
                        form.Pid = "";
                        form.Stat = '';
                    } else { //编辑
                        if (form.UserName == "") {
                            Pridialog("登录名不能为空");
                            return false;
                        }
                        if (form.PassWord == "") {
                            Pridialog("密码不能为空");
                            return false;
                        }
                        if (form.UserTname == "") {
                            Pridialog("教师不能为空");
                            return false;
                        }
                        if (form.Mobile == "") {
                            Pridialog("手机号不能为空");
                            return false;
                        }
                        if (Pridep == 0) {
                            Pridialog("请选择所属部门");
                            return false;
                        }
                        if (Pri_shc == 0) {
                            Pridialog("请选择班级");
                            return false;
                        }
                        $.ajax({
                            type: "POST",
                            url: "ashx/Teacher.ashx?action=Edit",
                            dataType: "json",
                            data: { "PriUserId": PriUserId, "UserName": form.UserName, "PassWord": form.PassWord, "UserTname": form.UserTname, "Mobile": form.Mobile, "DepartIds": Pridep, "ClassMs": Pri_shc, "Stat": form.Stat, "imgurl": PriImgurl },
                            success: function (data) { }
                        });
                        self.location = "/SchoolBaxicInfo/Teacher/TeacherList.aspx";
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

