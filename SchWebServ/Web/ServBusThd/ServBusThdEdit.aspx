<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServBusThdEdit.aspx.cs" Inherits="SchWebServ.Web.ServBusThd.ServBusThdEdit" %> 

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>业务功能管理</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />

    <link rel="stylesheet" href="../../assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="../../assets/css/chosen.css" />
    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/bootstrap-tagsinput.css">
    <link rel="stylesheet" href="../../assets/css/metro.css" />

    <script src="../../assets/js/ace-extra.min.js"></script>
    <style>
         /*定义字体*/
           body {
            font-family:微软雅黑;
        }
    </style>
</head>
<body ontouchstart>
    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>

        <div class="main-container-inner">

            <div class="main-content" style="margin-left: 0px; align-content: center">
                <div class="page-content content_box ">
                    <div class="space-8"></div>
                    <div class="row">

                        <div class="col-xs-3 text-right">第三方名称:</div>
                        <div class="col-xs-2 text-left">
                            <input type="text" name="ThdName" id="ThdName" placeholder="中国移动" maxlength="10" />
                            <input type="text" hidden="hidden" id="ccname" />
                            <input type="text" hidden="hidden" id="currentCode" />
                        </div>
                        <div class="col-xs-3 text-right">第三方套餐代码:</div>
                        <div class="col-xs-3 text-left">
                            <input type="text" name="ServiceId" id="ServiceId" onkeyup="checkTxt(this)" placeholder="000011" maxlength="10" />
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-3 text-right">第三方套餐名称:</div>
                        <div class="col-xs-2 text-left">
                            <input type="text" name="CnName" id="CnName" placeholder="请输入名称" maxlength="10" />
                        </div>
                        <div class="col-xs-3 text-right">第三方套餐资费:</div>
                        <div class="col-xs-3 text-left">
                            <input type="text" name="FeeCode" id="FeeCode" placeholder="请输入金额"  onkeyup="isInteger(this)" maxlength="10" />
                        </div>
                    </div>
                    <div class="space-8"></div>

                    <div class="row">
                        <div class="col-xs-3 text-right">资费时长:</div>
                        <div class="col-xs-2 text-left">
                            <select id="BusMonth">
                                <option value="0">请选择时长&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</option>
                                <option value="1">一个月</option>
                                <option value="2">二个月</option>
                                <option value="3">三个月</option>
                                <option value="4">四个月</option>
                                <option value="5">五个月</option>
                                <option value="6">半年</option>
                                <option value="7">七个月</option>
                                <option value="8">八个月</option>
                                <option value="9">九个月</option>
                                <option value="10">十个月</option>
                                <option value="11">十一个月</option>
                                <option value="12">一年</option>
                            </select>
                        </div>
                        <div class="col-xs-3 text-right">对应系统套餐:</div>
                        <div class="col-xs-3 text-left">
                            <select id="Mbusid">
                              
                            </select>
                        </div>
                    </div>
                    <%--    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-3 text-right">提供业务功能:</div>
                        <div class="col-xs-9 text-left">
                            <select class="col-xs-9" id="TagsBusinessPlatfrom" name="TagsBusinessPlatfrom" multiple></select>&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="btn-group">
                                <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle btn_size">
                                    选择平台
                                    <span class="icon-caret-down icon-on-right"></span>
                                </button>
                                <ul id="treebusplat" class="dropdown-menu ztree"></ul>
                            </div>
                        </div>
                    </div>--%>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-3 text-right">第三方套餐说明:</div>
                        <div class="col-xs-8 text-left">
                            <input type="text" class="col-xs-12" name="BusNote" id="BusNote" placeholder="请输入功能描述" maxlength="250" />
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <%=areastr %>
                    <div class="row">

                        <div class="col-xs-3 text-right">默认用户类型:</div>
                        <div class="col-xs-2 text-left">
                            <select id="BusUtype">
                                <option value="1">老师&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</option>
                                <option value="2">家长</option>
                                <option value="3">学生</option>
                            </select>
                        </div>
                        <div class="col-xs-3 text-right">默认订购时长:</div>
                        <div class="col-xs-3 text-left">
                            <select id="ThdMonth"> 
                                <option value="1">一个月&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</option>
                                <option value="2">二个月</option>
                                <option value="3">三个月</option>
                                <option value="4">四个月</option>
                                <option value="5">五个月</option>
                                <option value="6">半年</option>
                                <option value="7">七个月</option>
                                <option value="8">八个月</option>
                                <option value="9">九个月</option>
                                <option value="10">十个月</option>
                                <option value="11">十一个月</option>
                                <option value="12">一年</option>
                            </select>
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-3 text-right">备注:</div>
                        <div class="col-xs-8 text-left">
                            <input type="text" class="col-xs-12" name="Note" id="Note" placeholder="请输入备注" maxlength="50" />
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <button class="btn btn-info btn-sm text_size" id="btndo" type="button" onclick="saveuser()">保存</button>&nbsp; &nbsp; &nbsp;
                            <button class="btn btn-sm text_size" id="CancelBtn" type="button">取消</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        window.jQuery || document.write("<script src='../../assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
    </script>
    <script src="../../assets/js/bootstrap.min.js"></script>
    <script src="../../assets/js/typeahead-bs2.min.js"></script>
    <script src="../../assets/js/jquery-ui-1.10.3.custom.min.js"></script>
    <script src="../../assets/js/jquery.ui.touch-punch.min.js"></script>
    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>
    <!-- Latest compiled and minified JavaScript -->
    <script src="../../assets/js/bootstrap-tagsinput.js"></script>
    <script src="../../assets/js/jquery.ztree.all-3.5.min.js"></script>
    
    <script src="../../assets/js/learunui-validator.js"></script>
    <script type="text/javascript" src="../../assets/js/jquery.cookie.js"></script>
    <!-- (Optional) Latest compiled and minified JavaScript translation files -->
    <script type="text/javascript">
        //公共变量声明区域 
        var umodel=<%=umodelstr%>;
        var BusId=<%=BusId%>; 
        var servbus= <%=servbus%>;

        //对应套餐
        var busTypeOption="<option value=\"\">请选择对应套餐&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </option>";
        $.each(servbus, function (index, item) {
            busTypeOption +="<option value=\""+item.BusId+"\">"+item.CnName+"</option>";
        })
        $("#Mbusid").html(busTypeOption);


        //用户赋值 
        if(umodel!="1")
        {
            $('#ThdName').val(umodel.ThdName);
            $('#ServiceId').val(umodel.ServiceId);
            $('#CnName').val(umodel.CnName);
            $('#FeeCode').val(umodel.FeeCode);
            $('#BusMonth').val(umodel.BusMonth);
            $('#BusNote').val(umodel.BusNote);
            $('#BusUtype').val(umodel.BusUtype); 
            $('#ThdMonth').val(umodel.ThdMonth); 
            $('#Mbusid').val(umodel.Mbusid); 
            $('#Note').val(umodel.Note); 
            $('#ccname').val(umodel.CnName)
            $('#currentCode').val(umodel.ServiceId)
            
            
        }
        //数据收集并存库函数
        function saveuser() {
            var datasave = [];
            datasave.push("BusId#" + BusId);
            var ThdName = $("#ThdName").val();//第三方套餐名称
            if (ThdName == "") { alert("第三方名称"); return; }
            datasave.push("ThdName#" + ThdName);
            var ServiceId = $("#ServiceId").val();//第三方套餐代码
            if (ServiceId == "") { alert("请输入第三方套餐代码"); return; }
            datasave.push("ServiceId#" + ServiceId);
            var CnName = $("#CnName").val();//第三方套餐名称
            if (CnName == "") { alert("请输入第三方套餐名称"); return; }
            datasave.push("CnName#" + CnName);
            var FeeCode = $("#FeeCode").val();//第三方套餐资费
            if (FeeCode == "") { alert("请输入金额"); return; }
            datasave.push("FeeCode#" + FeeCode);
            var BusMonth = document.getElementById("BusMonth");//资费时长
            if (BusMonth.value == 0) { alert("请选择资费时长"); return; }
            datasave.push("BusMonth#" + BusMonth.value);
            var BusNote = $("#BusNote").val();//第三方套餐描述
            datasave.push("BusNote#" + BusNote);
            var BusArea = document.getElementById("acity");//归属地
            if (BusArea.value == 0) { alert("请选择归属地"); return; }
            datasave.push("BusArea#" + BusArea.value);
            var BusUtype = document.getElementById("BusUtype");//默认用户类型 
            datasave.push("BusUtype#" + BusUtype.value);
            var Mbusid = document.getElementById("Mbusid");//对应套餐id
            if (Mbusid.value == 0) { alert("请选择对应套餐id"); return; }
            datasave.push("Mbusid#" + Mbusid.value);
            var ThdMonth = document.getElementById("ThdMonth");//对应套餐id
            if (ThdMonth.value == 0) { alert("请选择默认订购时长"); return; }
            datasave.push("ThdMonth#" + ThdMonth.value);
            var Note = $("#Note").val();//备注
            datasave.push("Note#" + Note);
            var currentCnName = $("#ccname").val();//
            datasave.push("currentCnName#" + currentCnName);
            var currentCode = $("#currentCode").val();//
            datasave.push("currentCode#" + currentCode);
            $.ajax({
                type: "POST",  //请求方式
                url: "ServBusThdEdit.aspx/ServBusEditSave",  //请求路径：页面/方法名字
                data: JSON.stringify({ arr: datasave }),     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
                        alert(data.d.msg);
                        window.location.href = "../../LoginExc.aspx";
                    }else if (data.d.code == "success") {
                        alert(data.d.msg);
                        window.parent.createuserclose();
                    }else{
                        alert(data.d.msg);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        }
        //单击取消按钮时，关闭模态框
        $(document).on("click", "#CancelBtn", function () {
            window.parent.createuserclose();
        });
        var uareano="";
        //获取市
        $('#aprov').change(function () {
            var selv = $('#aprov').val();
            var params = '{"typecode":"1","pcode":"' + selv + '","uareano":"' + uareano + '","addall":true}';
            if (selv != "") {
                $.ajax({
                    type: "POST",  //请求方式
                    url: "../../PlcData.aspx/getarea",  //请求路径：页面/方法名字
                    data: params,     //参数
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d.code == "expire") {                            
                            window.location.href = "../../LoginExc.aspx";
                        } else if (data.d.code == "ExcepError") {
                            alert(edata.d.msg);
                        } else {
                            $('#acity').html(data.d.RspData);
                            $('#acity').change();
                            $("#aprov option").each(function () {
                                if ($(this).val() == selv) {
                                    $(this).attr("selected", true);
                                }
                                else {
                                    $(this).removeAttr("selected");
                                }

                            });
                        }
                    },
                    error: function (obj, msg, e) {
                    }
                });
            }
        });
        /*
        //获取区
        $('#acity').change(function () {
            var selv = $('#acity').val();
            var params = '{"typecode":"2","pcode":"' + selv + '"}';
            if (selv != "") {
                $.ajax({
                    type: "POST",  //请求方式
                    url: "ServBusThdAdd.aspx/getarea",  //请求路径：页面/方法名字
                    data: params,     //参数
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        $('#acoty').html(data.d);
                        $('#acoty').change();
                        $("#acity option").each(function () {
                            if ($(this).val() == selv) {
                                $(this).attr("selected", true);
                            }
                            else {
                                $(this).removeAttr("selected");
                            }
                        });
                    },
                    error: function (obj, msg, e) {
                    }
                });
            } else {
                $('#acoty').empty();
                $('#acoty').append("<option value=\"\">全部</option>");
                //$("#acoty option:first").prop("selected", 'selected');
            }
        });
        */
        //获取学校
        $('#acoty').change(function () {
            var selv = $('#acoty').val();
            var params = '{"typecode":"3","pcode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "ServBusThdAdd.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $('#asch').html(data.d);
                    $('#asch').change();
                    $("#acoty option").each(function () {
                        if ($(this).val() == selv) {
                            $(this).attr("selected", true);
                        }
                        else {
                            $(this).removeAttr("selected");
                        }

                    });
                },
                error: function (obj, msg, e) {
                }
            });
        });
        function checkTxt(o) {
            var regu = /^[0-9a-zA-Z]+$/;
            var re = new RegExp(regu);
            if (re.test($(o).val())) {
            } else {
                alert("请输入数字或者字母");
                o.focus(); o.value = "";
            }
        }
    </script>
</body>
</html>
