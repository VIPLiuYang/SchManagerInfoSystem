<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserOrderDetails.aspx.cs" Inherits="SchWebServ.Web.UserOrderInfo.UserOrderDetails" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>用户订购信息列表</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- basic styles -->

    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />

    <!--[if IE 7]>
		  <link rel="stylesheet" href="../../assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

    <!-- page specific plugin styles -->

    <link rel="stylesheet" href="../../assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="../../assets/css/chosen.css" />

    

    <!-- ace styles -->

    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/bootstrap-tagsinput.css">
    <link rel="stylesheet" href="../../assets/css/metro.css" />
    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="../../assets/css/ace-ie.min.css" />
		<![endif]-->

    <!-- inline styles related to this page -->

    <!-- ace settings handler -->

    <script src="../../assets/js/ace-extra.min.js"></script>

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

    <!--[if lt IE 9]>
		<script src="../../assets/js/html5shiv.js"></script>
		<script src="../../assets/js/respond.min.js"></script>
		<![endif]-->
    <style type="text/css">
         /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }

        i {
            font-family: FontAwesome !important;
        }
        fieldset {
            padding: .35em .625em .75em;
            margin: 18px 2px;
            border: 1px solid silver;
        }
        legend {
            margin-left:-9px;
            padding-right:10px;
            padding-left:10px;
            border: 0;
            width: auto;
            color:#FF7519;
            font-size:12px;
            font-weight:bold;
        }
        #OrderPackDown .bootstrap-tagsinput {
            padding:0px;
            width:159px;
        }
        #OrderPackDown .bootstrap-tagsinput .tag {
            background-color: white!important;
            color:#393939;
        }
        #OrderPackDown .btn {
            font-size: 12px;
            padding: 5px;
            background-color: #33CCFF!important;
            border: 0px;
            font-weight:bold;
        }
        #AccountSearchBtn {
            background-color: #33CCFF;
            color: #fff;
            font-size: 14px;
            padding: 4px;
            margin-left: 10px;
            text-align: center;
            width: 68px;
            float: left;
            cursor: pointer;
        }
        .modal-backdrop {
            filter: alpha(opacity=0)!important;
            opacity: 0!important;
        }
        #aprov,#acity {
            /*将默认的select选择框样式清除*/
            appearance:none;
            -moz-appearance:none;
            -webkit-appearance:none;
            /*在选择框的最右侧中间显示小箭头图片*/
            /*background: url("arrow.png") no-repeat scroll right center transparent;*/
            background-color:#f2f2f2;
            /*为下拉小箭头留出一点位置，避免被文字覆盖*/
            /*padding-right: 14px;*/
        }
        /*清除ie的默认选择框样式清除，隐藏下拉箭头*/
        /*select::-ms-expand { display: none; }*/
    </style>
</head>
<body ontouchstart>
    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>

        <div class="main-container-inner">

            <div class="main-content" style="margin-left: 0px">
                <div class="page-content content_box ">
                   
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-1 text-right no-padding">账号：</div>
                        <div class="col-xs-3 text-left">
                            <input class="col-xs-12" type="text" name="Account" id="Account" placeholder="请输入账号" maxlength="11" disabled="disabled" />
                        </div>
                        <div class="col-xs-1 text-right no-padding">账号类型：</div>
                        <div class="col-xs-3 text-left"><input class="col-xs-12" type="text" name="AccountType" id="AccountType" readonly="readonly" maxlength="10" /></div>
                        <div class="col-xs-1 text-right no-padding">姓名：</div>
                        <div class="col-xs-3 text-left"><input class="col-xs-12" type="text" name="UserTname" id="UserTname" readonly="readonly" maxlength="10" /></div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-1 text-right no-padding">归属(省)：</div>
                        <div class="col-xs-3 text-left">
                            <select class="col-xs-12" id="aprov" disabled="disabled">
                            <%=province %>
                            </select>
                        </div>
                        <div class="col-xs-1 text-right no-padding">归属(市)：</div>
                        <div class="col-xs-3 text-left">
                            <select class="col-xs-12" id="acity" disabled="disabled">
                                <%=city %>
                            </select>
                        </div>
                        <div class="col-xs-1 text-right no-padding">用户来源：</div>
                        <div class="col-xs-3 text-left"><input  type="text" class="col-xs-12" name="UserSource" id="UserSource" readonly="readonly" value="手工"/></div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-1 text-right no-padding">来源附加：</div>
                        <div class="col-xs-3 text-left"><input  type="text" class="col-xs-12" name="Additional" id="Additional" readonly="readonly" maxlength="250" value="<%=uname %>" /></div>
                        <div class="col-xs-1 text-right no-padding">订购套餐：</div>
                        <div class="col-xs-3 text-left" id="OrderPackDown">
                       <input  type="text" class="col-xs-12" name="ServBusTreeNode" id="ServBusTreeNode" readonly="readonly"   maxlength="250"   /> 
                            <%--<div class="btn-group">--%>
                               <%-- <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle btn_size">
                                    选择套餐
                                    <span class="icon-caret-down icon-on-right"></span>
                                </button>--%>
                              <%--  <ul id="treeorderpackage" class="dropdown-menu ztree"></ul>
                            </div>--%>
                        </div>
                        <div class="col-xs-1 text-right no-padding">套餐资费：</div>
                        <div class="col-xs-3 text-left"><input  type="text" class="col-xs-12" name="BusTariff" id="BusTariff" readonly="readonly"/></div>
                    </div>
              
                    <div class="row">
                        <div class="col-xs-12" id="AdditionalFunc"></div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-1 text-right no-padding">订购时长：</div>
                        <div class="col-xs-3 text-left">
                          <%--  <select class="col-xs-12" name="OrderLength" id="OrderLength"  style="width: 200px; background-color: #EEEEEE;" disabled="disabled"><option value="">请先选择订购套餐</option></select>--%>

                             <input  type="text" class="col-xs-12" name="OrderLength" id="OrderLength" readonly="readonly" maxlength="250"   /> 
                        </div>
                        <div class="col-xs-1 text-right no-padding">缴费金额：</div>
                        <div class="col-xs-3 text-left"><input  type="text" class="col-xs-12" name="PayAmount" id="PayAmount" placeholder="自动结算缴费金额" readonly="readonly" /></div>
                        <div class="col-xs-1 text-right no-padding">结束时间：</div>
                        <div class="col-xs-3 text-left"><input  type="text" class="col-xs-12" name="OrderEndTime" id="OrderEndTime" readonly="readonly" placeholder="" maxlength="250" /></div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-1 text-right no-padding">备注：</div>
                        <div class="col-xs-11 text-left"><input  type="text" class="col-xs-12" name="Note" id="Note" placeholder="请输入备注" maxlength="250" disabled="disabled" /></div>
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
        //公共變量定義區域
        var ServBusTreeNode = <%=servbustree%>;
        var fristTimeLength = 0;//計算消費金額使用
        var fristFeeCode = 0;//默認繳費金額
        var currentFeeCode=0;//當前繳費金額
        var varname="treeServBusObj0";
        var treeAddInfoObj={};
        var varnameprd="";
        var treeAddExtObj={};
        var servUserForModel=<%=servUserForModel%>;

        //下拉部门框点击屏蔽
        $(document).on("click",".dropdown-menu",function(e){
            e.stopPropagation();
        });
        //单击取消按钮时，关闭模态框
        $(document).on("click", "#CancelBtn", function () {
            window.parent.closeEditCfmmodel();
        });
    </script>
    
    <script src="js/AssignmentShow.js"></script><!--初始化数据-->
    <script src="js/ServBusDownShow.js"></script><!--业务平台下拉列表-->
    <script src="js/ServFuncExtShow.js"></script><!--功能擴展下拉列表-->
    <script type="text/javascript">
        function servfuncdom(data){
            var servfuncdom="";
            $.each(eval("("+data+")").retobj, function (index, item) {
                servfuncdom += "<fieldset id=\"UOrdAddfield"+index+"\" funcode=\""+item.FuncCode+"\" class=\"UOrdAddField\">";
                servfuncdom += "    <legend>"+item.FuncName+"</legend>";
                servfuncdom += "<div class=\"row\">";
                servfuncdom += "<div class=\"col-xs-12\" id=\"userordaddext"+index+"\">";
                var i=0;
                $.each(eval("("+data+")").servfuncext,function(indexext,itemext){
                    if(item.AutoId==itemext.FuncId){
                        servfuncdom += "        <span>"+itemext.Title+"</span>";
                        servfuncdom += "        <select id=\"TagsExt"+itemext.NapeCode+index+"\" index=\""+index+"\" class=\"TagsExt"+itemext.NapeCode+"\" name=\"SelectFuncExt\" seletype=\""+itemext.NapeCode+"\" disabled=\"disabled\" multiple></select>";
                        servfuncdom += "        <div class=\"btn-group\">";
                        servfuncdom += "            <button data-toggle=\"dropdown\" index=\""+index+"\" type=\""+itemext.NapeCode+"\" funcid=\""+itemext.FuncId+"\" class=\"btn btn-info btn-sm dropdown-toggle btn_size\">";
                        servfuncdom += "                选择";
                        servfuncdom += "                <span class=\"icon-caret-down icon-on-right\"></span>";
                        servfuncdom += "            </button>";
                        servfuncdom += "            <ul id=\"treeTagsExt"+itemext.NapeCode+index+"\" class=\"dropdown-menu ztree\"></ul>";
                        servfuncdom += "        </div>";
                        var syspers=eval("("+data+")").sysext;
                        varnameprd=itemext.NapeCode+"_"+itemext.FuncId;
                        treeAddExtObj[varnameprd] = syspers[varnameprd];
                    }
                })
                servfuncdom += "    </div>";
                servfuncdom += "</div>";
                servfuncdom += "</fieldset>";
            })
            $("#AdditionalFunc").html(servfuncdom);
            //初始化附加功能下拉列表框
            
            var UOrdAddFieldObj = $(document).find(".UOrdAddField");
            var UOrdAddFieldLen = UOrdAddFieldObj.length;
            for(var i=0;i<UOrdAddFieldLen;i++){
                var btndown = $("#UOrdAddfield"+i).find("button");
                var btndownlen = btndown.length;
                for(var j=0;j<btndownlen;j++){
                    var type = $(btndown[j]).attr("type");
                    var index = $(btndown[j]).attr("index");
                    var funcid = $(btndown[j]).attr("funcid");
                    $(document).find("#TagsExt"+type+index).tagsinput({
                        itemValue: 'id',
                        itemText: 'text',
                    });

                    var varname="treeFuncExt"+type+"Obj"+index;
                    var sssss = treeAddExtObj[type+"_"+funcid];
                    treeAddInfoObj[varname] = $.fn.zTree.init($("#treeTagsExt"+type+index), settingServFuncExt, treeAddExtObj[type+"_"+funcid]);
                    //
                    if (treeAddExtObj[type+"_"+funcid]) {
                        for (var x in treeAddExtObj[type+"_"+funcid]) {
                            if ((treeAddExtObj[type+"_"+funcid][x].checked).toLowerCase() == 'true') {
                                $('#TagsExt'+type+index).tagsinput('add', { id: treeAddExtObj[type+"_"+funcid][x].id, text: treeAddExtObj[type+"_"+funcid][x].name });
                            }

                        }
                    }
                    //
                }
            }
        }
        //單擊功能擴展下拉列表時觸發事件
        $(document).on("click","#AdditionalFunc .dropdown-toggle",function(){
            var type = $(this).attr("type");
            var funcid = $(this).attr("funcid");
            var index = $(this).attr("index");
            var TagsExtSubVal = $("#TagsExt"+type+index).val();
            if(TagsExtSubVal != null && TagsExtSubVal.length>0){
                var treeObj = $.fn.zTree.getZTreeObj("treeTagsExt"+type + index);
                var TagsExtSubValArr = TagsExtSubVal.split(',');
                for(var i=0;i<TagsExtSubValArr.length;i++){
                    var enodeext = treeObj.getNodeByParam("id", TagsExtSubValArr[i], null);
                    enodeext.checked =true;
                    treeObj.updateNode(enodeext);
                }
            }else{
                varname="treeFuncExt"+type+"Obj"+index;
                var sssss = treeAddExtObj[type+"_"+funcid];
                treeAddInfoObj[varname] = $.fn.zTree.init($("#treeTagsExt"+type+index), settingServFuncExt, treeAddExtObj[type+"_"+funcid]);
            }
        });
    </script>
    <script type="text/javascript">
        function aprovchange(uareano){
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
                            $("#acity").html(data.d.RspData);
                            $("#acity").change();
                        }
                    },
                    error: function (obj, msg, e) {
                    }
                });
            }
        }
        //获取市
        $("#aprov").change(function () {
            aprovchange("");
        });
        //選擇電話、姓名以及區域賦值
        function selectuserinfo(uname,utname,uareano){
            var OldAccount = $("#Account").val();//獲取更換之前的賬號
            $("#Account").val(uname);//重新更改新賬號
            $("#UserTname").val(utname);//給姓名賦值
            $("#aprov").val(uareano.substring(0,2)+"0000");//給當前賬號手機號碼所在省部
            aprovchange(uareano);//如果省部更新時，市區也自動更新
            $("#acity").val(uareano.substring(0,4)+"00");//給當前賬號手機號碼所在市區
            closeEditCfmmodel();//關閉模態框
            if(OldAccount != uname){//切換賬號時觸發
                var node = treeServBusObj.getNodeByParam("id", $("#TagsOrderPackage").val(), null);
                node.checked=false;
                treeServBusObj.updateNode(node);
                settingServBus.callback.onCheck('','',node);
            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function(){
            //編輯頁面給當前ID記錄初始化
            if(servUserForModel!="0"){
                $("#Account").val(servUserForModel.UserName);
                $("#UserTname").val(servUserForModel.UTname);
                if(servUserForModel.Uareano){
                    var aprovinceno = servUserForModel.Uareano.substring(0,2)+"0000";
                    $("#aprov").val(aprovinceno);
                    var cityno = servUserForModel.Uareano.substring(0,4)+"00";
                    aprovchange(servUserForModel.Uareano);//如果省部更新時，市區也自動更新
                    $("#cityno").val(cityno);
                }
                $("#UserSource").val(servUserForModel.FromType);
                //$("#BusTariff").val((servUserForModel.FeeM/servUserForModel.ServMonth)+"元/月");
                $("#BusTariff").val(servUserForModel.FeeCode +"元/"+servUserForModel.BusMonth+"月");
                $("#OrderLength").val(servUserForModel.ServMonth+"个月");
                $("#ServBusTreeNode").val(servUserForModel.CnName);
                
                $("#PayAmount").val(servUserForModel.FeeM);
                $("#OrderEndTime").val(servUserForModel.EndTime);
                $("#Note").val(servUserForModel.DoNote);
            }

            var TagsOrderPackageval = $("#TagsOrderPackage").val();
            if(TagsOrderPackageval!=""){
                //查詢附加功能
                var params = '{"ordpack":"' + TagsOrderPackageval + '"}';
                if (TagsOrderPackageval != "") {
                    $.ajax({
                        type: "POST",
                        url: "UserOrderEdit.aspx/getServFunc",
                        data: params,
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            servfuncdom(data.d);
                        },
                        error: function (obj, msg, e) {
                        }
                    });
                }
            }
        })
    </script>
</body>
</html>