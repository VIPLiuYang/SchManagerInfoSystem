<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServBusEdit.aspx.cs" Inherits="SchWebServ.Web.ServBus.ServBusEdit" %>
 

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

    

    <!-- ace styles -->

    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/bootstrap-tagsinput.css">
    <link rel="stylesheet" href="../../assets/css/metro.css" /> 
    <script src="../../assets/js/ace-extra.min.js"></script> 
    <style type="text/css">
         /*定义字体*/
          body {
            font-family:微软雅黑;
        }

 
        .file {
            clear: both;
            margin: 5px;
            position: relative;
            background-color: #6FB2DF;
            border: 1px solid #ddd;
            width: 68px;
            height: 25px;
            display: inline-block;
            text-decoration: none;
            text-indent: 0;
            line-height: 25px;
            font-size: 12px;
            color: #fff;
            cursor: pointer;
            text-align: center;
            border: none;
            border-radius: 3px;
            top:50px;
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
                        <div class="col-xs-2 text-right">套餐图片:</div>
                        <div class="col-xs-2 text-left">
                            <input type="hidden" id="PlatformIco" placeholder="" data-toggle="tooltip" maxlength="20" class="col-xs-9 col-sm-9" readonly="readonly" disabled="disabled" /> 
                            <img id="PlatformIcoimg" style="width: 80px; height: 80px; display: none; float: left;" src="" />
                            
                        </div>
                        <input id="btnfile" name="btnfile" accept="image/png, image/jpg" type="file" style="display: none;" />
                            <a class="file">上传图标</a>
                       <%-- <div class="col-xs-3 text-left">
                            <input type="text" hidden="hidden" name="UseRange" id="Text2" placeholder="请输入金额" maxlength="10" />
                        </div>--%>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">

                        <div class="col-xs-2 text-right">套餐代码:</div>
                        <div class="col-xs-2 text-left">
                            <input type="text" name="ServiceId" id="ServiceId"  onkeyup="checkTxt(this)"  placeholder="请输入套餐代码" maxlength="10" />
                        </div>
                        <div class="col-xs-4 text-right">套餐名称:</div>
                        <div class="col-xs-3 text-left">
                            <input type="text" name="CnName" id="CnName" placeholder="请输入套餐名称" maxlength="10" />
                            <input type="text" name="CnName" id="name"  hidden="hidden" maxlength="10" />
                             <input type="text" name="CnName" id="code" hidden="hidden" maxlength="10" />
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-2 text-right">业务类型:</div>
                        <div class="col-xs-3 text-left">
                            <select id="BusType">
                                <option value="0">请选择业务类型&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</option>
                                <option value="1">自定义套餐</option>
                                <option value="2">CP套餐</option>
                            </select>
                        </div>
                        <div class="col-xs-3 text-right">资费(元):</div>
                        <div class="col-xs-3 text-left">
                            <input type="text" name="FeeCode" id="FeeCode" placeholder="请输入金额" maxlength="10" />
                        </div>
                    </div>
                    <div class="space-8"></div>

                    <div class="row">
                        <div class="col-xs-2 text-right">资费时长:</div>
                        <div class="col-xs-3 text-left">
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
                        <div class="col-xs-3 text-right">系统显示名称:</div>
                        <div class="col-xs-3 text-left">
                            <input type="text" name="CapName" id="CapName" maxlength="25" />
                            <!--<input type="text" hidden="hidden" name="UseRange" id="Text1" placeholder="请输入金额" maxlength="10" />-->
                        </div>
                    </div>
                   
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-2 text-right">提供业务功能:</div>
                       <div class="col-xs-9 text-left">
                            <select class="col-xs-9" id="TagsBusinessPlatfrom" name="TagsBusinessPlatfrom" multiple></select>&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="btn-group">
                                <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle btn_size">
                                    选择功能
                                    <span class="icon-caret-down icon-on-right"></span>
                                </button>
                                <ul id="treebusplat" class="dropdown-menu ztree"></ul>
                            </div>
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-2 text-right">功能描述:</div>
                        <div class="col-xs-9 text-left">
                            <input type="text" class="col-xs-12" name="BusNote" id="BusNote" placeholder="请输入功能描述" maxlength="250" />
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-2 text-right">备注:</div>
                        <div class="col-xs-9 text-left">
                            <input type="text" class="col-xs-12" name="Note" id="Note" placeholder="请输入备注" maxlength="50" />
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-2 text-right">类型:</div>
                        <div class="col-xs-9 text-left">
                            <input type="radio" name="FrmType" value="0" checked="checked" />本系统套餐类型&#8195;
                            <input type="radio" name="FrmType" value="1" />第三方套餐类型
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row" id="Thd" style="display:none;">
                        <div class="col-xs-2 text-right">地区:</div>
                        <div class="col-xs-9 text-left">
                            <select id="aprov">
                            <%=province %>
                            </select>
                            <select id="acity">
                                <%=city %>
                            </select>
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
    <script type="text/javascript" src="../../assets/js/jquery.cookie.js"></script>
    <!-- (Optional) Latest compiled and minified JavaScript translation files -->
    <script type="text/javascript">
        //公共变量声明区域
        var umodel=<%=umodelstr%>;
        var BusId=<%=BusId%>; 
        var busPlatfromTreeNode = <%=businessPlatfrom%>;
        //用户赋值 
        if(umodel!="1")
        {
            $('#ServiceId').val(umodel.ServiceId);
            $('#CnName').val(umodel.CnName);
            $('#BusType').val(umodel.BusType);
            $('#FeeCode').val(umodel.FeeCode);
            $('#BusMonth').val(umodel.BusMonth);
            $('#FuncStr').val(umodel.FuncStr);
            $('#BusNote').val(umodel.BusNote);
            $('#Note').val(umodel.Note); 
            $('#name').val(umodel.CnName);
            $('#code').val(umodel.ServiceId);  
            $("#PlatformIco").val(umodel.BusUrl);

            //$('#BusArea').val(umodel.BusArea);
            $('#CapName').val(umodel.CapName);  
            $("input[name='FrmType'][value='"+umodel.FrmType+"']").prop('checked', true);
            if(umodel.FrmType=="1"){
                $("#Thd").css("display","block");
            }else{
                $("#Thd").css("display","none");
            }

            $("#PlatformIcoimg").attr("src", "../.." + umodel.BusUrl);
            $("#PlatformIcoimg").css("display", "block");
            if (umodel.BusUrl=="") {
                $("#PlatformIcoimg").attr("src", "../../UploadFileDir/img.png");
                $("#PlatformIcoimg").css("display", "block");
            }
        }
        var uareano=umodel.BusArea;

        //获取市
        $("#aprov").change(function () {
            var selv = $('#aprov').val();
            if (selv != "") {
                var params = '{"typecode":"1","pcode":"' + selv + '","uareano":"' + uareano + '","addall":true}';
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
                        }
                    },
                    error: function (obj, msg, e) {
                    }
                });
            }
        })
        $(document).on("click","input[name='FrmType']",function(){
            var FrmType = $(this).val();
            if(FrmType=="1"){
                $("#Thd").css("display","block");
            }else{
                $("#Thd").css("display","none");
            }
        })

        //数据收集并存库函数
        function saveuser() {
            var datasave = [];  
            datasave.push("BusId#" + BusId);
            var ServiceId = $("#ServiceId").val();//套餐代码
            if (ServiceId=="") {alert("请输入套餐代码");return; }
            datasave.push("ServiceId#" + ServiceId);
            var CnName = $("#CnName").val();//套餐名称
            if (CnName=="") {alert("请输入套餐名称");return; }
            datasave.push("CnName#" + CnName);
            var BusType = document.getElementById("BusType");//业务类型 
            if (BusType.value==0) {alert("请选择业务类型"); return;}
            datasave.push("BusType#" + BusType.value);
            var FeeCode = $("#FeeCode").val();//资费 
            if (FeeCode=="") {alert("请输入金额");return; }
            datasave.push("FeeCode#" + FeeCode);
            var BusMonth = document.getElementById("BusMonth");//资费时长
            if (BusMonth.value==0) {alert("请选择资费时长"); return;}
            datasave.push("BusMonth#" + BusMonth.value);  
            var TagsBusinessPlatfrom = $("#TagsBusinessPlatfrom").val(); //提供业务功能
            if (TagsBusinessPlatfrom==null) {alert("请选择业务功能");return; }
            datasave.push("FuncStr#" + TagsBusinessPlatfrom); 
            var BusNote = $("#BusNote").val();//功能描述
            datasave.push("BusNote#" + BusNote);
            var Note = $("#Note").val();//备注
            datasave.push("Note#" + Note); 
            var cnname = $("#name").val();//备注
            datasave.push("cnname#" + cnname); 
            var code = $("#code").val();//备注
            datasave.push("code#" + code); 
            var BusUrl = $("#PlatformIco").val();//套餐图片
            datasave.push("BusUrl#" + BusUrl);  
            var CapName = $("#CapName").val();//系统显示名称
            if(CapName==""){
                alert("请输入系统显示名称");
                $("#CapName").focus();
                return false;
            }else if(CapName.length>10){
                alert("系统显示名称不得超过10个汉字");
                $("#CapName").focus();
                return false;
            }
            datasave.push("CapName#"+CapName);
            var acity = $("#acity").val();//地区
            datasave.push("acity#"+acity);
            var FrmType = $("input[name='FrmType']:checked").val();//类型
            datasave.push("FrmType#"+FrmType);

            $.ajax({
                type: "POST",  //请求方式
                url: "ServBusEdit.aspx/ServBusEditSave",  //请求路径：页面/方法名字
                data: JSON.stringify({ arr: datasave }),     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    }else if (data.d.code == 'success') {
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

        //功能业务-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        $("#TagsBusinessPlatfrom").tagsinput({
            itemValue: 'id',
            itemText: 'text',
        });

        var treeBusPlatObj;

        var settingBusPlat = {
            check: {
                enable: true,
                //autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]   
                chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]   
                chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
            },
            view: {
                dblClickExpand: false,
                showLine: true,
                selectedMulti: true
            },
            data: {
                simpleData: {
                    enable: true,
                    idKey: "id",
                    pIdKey: "pId",
                    checked: "checked",
                    rootPId: "0"
                }
            },
            callback: {
                beforeClick: function (treeId, treeNode) {
                },
                onCheck: SubsTreeOnCheck
            }
        };
        //与选中联动
        function SubsTreeOnCheck(event, treeId, treeNode) {
            if (treeNode.checked) {
                $('#TagsBusinessPlatfrom').tagsinput('add', { id: treeNode.id, text: treeNode.name });
            } else {
                $('#TagsBusinessPlatfrom').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
            }
        };
        //删除触发
        $('#TagsBusinessPlatfrom').on('itemRemoved', function (event) {
            var node = treeBusPlatObj.getNodeByParam("id", event.item.id, null);
            treeBusPlatObj.checkNode(node, false, false);
        });


        //初始化
        $(function () {
            treeBusPlatObj = $.fn.zTree.init($("#treebusplat"), settingBusPlat, busPlatfromTreeNode);//选择科目初始化
            //设置科目缺省值
            if (busPlatfromTreeNode) {
                for (var x in busPlatfromTreeNode) {
                    if (busPlatfromTreeNode[x].checked == 'true') {
                        $('#TagsBusinessPlatfrom').tagsinput('add', { id: busPlatfromTreeNode[x].id, text: busPlatfromTreeNode[x].name });
                    }

                }
            }
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
      <script type="text/javascript" src="../../assets/js/ajaxfileupload.js"></script>
    <script type="text/javascript" src="js/Uploadico.js"></script>
    <!--学校添加页面的上传图标-->
</body>
</html>
