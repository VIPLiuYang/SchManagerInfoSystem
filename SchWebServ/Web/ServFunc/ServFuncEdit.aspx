<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServFuncEdit.aspx.cs" Inherits="SchWebServ.Web.ServFunc.ServFuncEdit" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>业务功能管理</title>
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
           body {
            font-family:微软雅黑;
        }
        fieldset {
            padding: .35em .625em .75em;
            margin: 0 2px;
            border: 1px solid silver;
        }

        legend {
            padding: .5em;
            border: 0;
            width: auto;
            color:#FF9900;
            font-size:12px;
            margin-bottom:1px;
        }
        /*.bootstrap-tagsinput {
            width: 114px;
        }*/
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
                    <input type="hidden" name="autoid" id="autoid" />
                    <input type="hidden" name="oldFuncCode" id="oldFuncCode" />
                    <div class="row">
                        <div class="col-xs-2 text-right">业务类型：</div>
                        <div class="col-xs-4 text-left">
                            <select id="BusinessType" class="col-xs-12"></select>
                        </div>
                        <div class="col-xs-2 text-right">功能代码：</div>
                        <div class="col-xs-4 text-left"><input  type="text" name="BusinessCode" id="BusinessCode" placeholder="请输入功能代码"  onkeyup="checkTxt(this)" maxlength="10" /></div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-2 text-right">功能名称：</div>
                        <div class="col-xs-4 text-left"><input  type="text" name="FuncName" id="FuncName" placeholder="请输入功能名称" maxlength="10" /></div>
                        <div class="col-xs-2 text-right">使用范围：</div>
                        <div class="col-xs-4 text-left"><input  type="text" name="UseRange" id="UseRange" placeholder="请输入使用范围" maxlength="10" /></div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-12">
                            
                            <fieldset id="fieldsetid">
                                <legend>附加设置信息</legend>
                                <div class="row"><div class="col-xs-12" style="height:30px;color:red;margin-left: 6px;">“可选个数”设置为“0”时，“选择内容”只能选择一个</div></div>
                                <div class="space-8"></div>
                                <div class="row" id="addDefault0">
                                    <div class="col-xs-2 no-padding text-center">附加信息：</div>
                                    <div class="col-xs-1 no-padding">
                                        <select class="AdditionalInfo" id="AdditionalInfo0" rel="0" name="AdditionalInfo"></select>
                                    </div>
                                    <div class="col-xs-2 no-padding text-center">选择内容：</div>
                                    <div class="col-xs-3 no-padding">
                                        <select id="SelectContent0" class="SelectContent" name="SelectContent" rel="0" multiple></select>
                                        <div class="btn-group">
                                            <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle btn_size">
                                                选择
                                                <span class="icon-caret-down icon-on-right"></span>
                                            </button>
                                            <ul id="treeSelect0" class="dropdown-menu ztree"></ul>
                                        </div>
                                    </div>
                                    <div class="col-xs-2 no-padding text-center">可选个数：</div>
                                    <div class="col-xs-1 no-padding">
                                        <select id="SelectNum0" name="SelectNum" rel="0">
                                            <option value="0">0</option>
                                            <option value="1">1</option>
                                            <option value="2">2</option>
                                            <option value="3">3</option>
                                            <option value="4">4</option>
                                            <option value="5">5</option>
                                            <option value="6">6</option>
                                            <option value="7">7</option>
                                            <option value="8">8</option>
                                            <option value="9">9</option>
                                            <option value="10">10</option>
                                        </select>
                                    </div>
                                    <div class="col-xs-1 no-padding text-center">
                                        <i class="glyphicon glyphicon-plus" id="Additionaladdbtn" title="添加" style="cursor:pointer;"></i><!--&#8195;-->
                                        <!--<i class="glyphicon glyphicon-minus" id="Additionaldelbtn" rel="0" title="刪除" style="cursor:pointer;"></i>-->
                                    </div>
                                </div>
                                <div class="space-8"></div>
                              </fieldset>
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-2 text-left">业务功能描述：</div>
                        <div class="col-xs-10 text-left"><input  type="text" class="col-xs-12" name="BusinessDesc" id="BusinessDesc" placeholder="请输入功能描述" maxlength="250" /></div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-2 text-left">所属业务平台：</div>
                        <div class="col-xs-10 text-left">
                            <select class="col-xs-9" id="TagsBusinessPlatfrom" name="TagsBusinessPlatfrom" multiple></select>&nbsp;&nbsp;&nbsp;&nbsp;
                            <div class="btn-group">
                                <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle btn_size">
                                    选择平台
                                    <span class="icon-caret-down icon-on-right"></span>
                                </button>
                                <ul id="treebusplat" class="dropdown-menu ztree"></ul>
                            </div>
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-2 text-right">备注：</div>
                        <div class="col-xs-10 text-left"><input  type="text" class="col-xs-12" name="Note" id="Note" placeholder="请输入备注" maxlength="250" /></div>
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
        //下拉框点击屏蔽
        $(document).on("click",".dropdown-menu",function(e){
            e.stopPropagation();
        });
        //公共变量声明区域
        var schid = "<%=schid%>";
        var businessType = <%=businessType%>;
        var busPlatfromTreeNode = <%=businessPlatfrom%>;
        var servfuncModelNode = <%=servfuncModel%>;
        var addinfoTreeNode = <%=editServSysNape%>;
        var selectconPrdTreeNode = <%=selectprdcontent%>;//學段
        var selectconGrdTreeNode=[];//年級
        var selectconSubTreeNode=[];//科目
        var selectconUtpTreeNode=[];//角色
        var selectconMatTreeNode=[];//教版
        var selectconNullTreeNode=[];//空
        var treeNodestr={};
        var treeAddInfoObj={};
        var varname="treeAddInfoObj0";
        var treeAddInfoObjnull;
        var servfuncextjson = <%=servfuncextjson%>;
        var optionjson = [{"optionval":"0","optiontxt":"0"},{"optionval":"1","optiontxt":"1"},{"optionval":"2","optiontxt":"2"},{"optionval":"3","optiontxt":"3"},{"optionval":"4","optiontxt":"4"}];
        treeAddInfoObj[varname]=<%=selectprdcontent%>;

        //业务类型下拉框赋值
        var busTypeOption="<option value=\"\">请选择业务类型</option>";
        $.each(businessType, function (index, item) {
            busTypeOption +="<option value=\""+item.TypeCode+"\">"+item.TypeName+"</option>";
        })
        $("#BusinessType").html(busTypeOption);
        //附加設置信息下拉框赋值
        var addInfoOption="";
        $.each(addinfoTreeNode, function (index, item) {
            addInfoOption +="<option value=\""+item.NapeCode+"\">"+item.NapeName+"</option>";
        })
        $(".AdditionalInfo").html(addInfoOption);
        //数据收集并存库函数
        function saveuser() {
            var datasave = [];

            datasave.push("schid#" + schid);

            var AutoId = $("#autoid").val();
            datasave.push("autoid#" + AutoId);

            var BusinessType = $("#BusinessType").val();
            datasave.push("businesstype#" + BusinessType);
            if (BusinessType == "") {
                alert("请选择业务类型！");
                return;
            }
            var BusinessCode = $("#BusinessCode").val();
            datasave.push("businesscode#" + BusinessCode);
            if (BusinessCode == "") {
                alert("请输入功能代码！");
                return;
            }
            var oldBusinessCode = $("#oldFuncCode").val();
            datasave.push("oldbusinesscode#"+oldBusinessCode);

            var FuncName = $("#FuncName").val();
            datasave.push("funcname#" + FuncName);
            if (FuncName == "") {
                alert("请输入功能名称！");
                return;
            }
            var UseRange = $("#UseRange").val();
            datasave.push("userange#" + UseRange);

            //var AddSetInfo = $("#AddSetInfo").val();
            var AdditionalInfoVal=$("[name='AdditionalInfo']");
            var SelectContentVal=$("[name='SelectContent']");
            var SelectNumVal=$("[name='SelectNum']");
            var sendAdditionalstr="";
            var  arrayObj=[];
            if(AdditionalInfoVal.length>0&&SelectContentVal.length>0&&SelectNumVal.length>0){
                for(var i=0;i<AdditionalInfoVal.length;i++){
                    if($(SelectContentVal[i]).val()==null){
                        alert("附加设置信息第"+(i+1)+"个，选择内容不允许为空");
                        return false;
                    }
                    //if($(SelectContentVal[i]).val()!=""){
                    //    var scstr = $(SelectContentVal[i]).val();
                    //    if(scstr){
                    //        var scstrarr = scstr.toString().split(',');
                    //        if(scstrarr.length>$(SelectNumVal[i]).val()){
                    //            alert("你选择的第"+(i+1)+"个，选择内容的长度大于可选个数");
                    //            return false;
                    //        }
                    //    }
                    //}
                    sendAdditionalstr += $(AdditionalInfoVal[i]).val()+"!"+$(SelectContentVal[i]).val()+"!"+$(SelectNumVal[i]).val()+"|";
                    arrayObj.push($(AdditionalInfoVal[i]).val());
                }
            }
            //判断附加信息只能选择一次，不允许重复
            var arrStr = JSON.stringify(arrayObj),str;
            for (var i = 0; i < arrayObj.length; i++) {
                if (arrStr.indexOf(arrayObj[i]) != arrStr.lastIndexOf(arrayObj[i])){
                    alert("附加信息不允许重复！");
                    return true;
                }
            };
            sendAdditionalstr=sendAdditionalstr.substring(0,sendAdditionalstr.length-1);
            datasave.push("addsetinfo#" + sendAdditionalstr);

            var BusinessDesc = $("#BusinessDesc").val();
            datasave.push("businessdesc#" + BusinessDesc);

            var TagsBusinessPlatfrom = $("#TagsBusinessPlatfrom").val(); 
            datasave.push("tagsbusplatfrom#" + TagsBusinessPlatfrom);

            var Note = $("#Note").val(); 
            datasave.push("note#" + Note);
            
            $.ajax({
                type: "POST",  //请求方式
                url: "ServFuncEdit.aspx/FuncEditSave",  //请求路径：页面/方法名字
                data: JSON.stringify({ arr: datasave }),     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
                        alert(data.d.msg);
                        window.location.href = "../../LoginExc.aspx";
                    } else if (data.d.code == 'success') {
                        alert(data.d.msg);
                        window.parent.closeEditCfmmodel();
                    } else{
                        alert(data.d.msg);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
            
        }
        //单击取消按钮时，关闭模态框
        $(document).on("click", "#CancelBtn", function () {
            window.parent.closeEditCfmmodel();
        });
        //附加信息改變時觸發，并重置選擇內容
        $("#fieldsetid").on("change","select.AdditionalInfo",function(){
            var thisrel = $(this).attr("rel");
            var thisval = $(this).val();
            varname="treeAddInfoObj"+thisrel;

            //清空選擇內容
            var selcont = $('#SelectContent'+thisrel).val();
            if(selcont){
                var selcontarr = selcont.toString().split(',');
                for(var i=0;i<selcontarr.length;i++){
                    $('#SelectContent'+thisrel).tagsinput('remove', { id: selcontarr[i] });
                }
            }
            //可選個數重置
            $('#SelectNum'+thisrel+' option:first').attr("selected","selected");

            var params = '{"napecode":"' + thisval + '"}';
            $.ajax({
                type: "POST",
                url: "ServFuncEdit.aspx/getaddcont",
                data: params,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var oo = eval('('+data.d+')');
                    if(oo.retxt=="grd"){
                        selectconGrdTreeNode = oo.retobj;
                        treeAddInfoObj[varname] = $.fn.zTree.init($("#treeSelect"+thisrel), settinEditInfo, selectconGrdTreeNode);
                        treeAddInfoObj[varname].checkAllNodes(false);
                    }else if(oo.retxt=="sub"){
                        selectconSubreeNode = oo.retobj;
                        treeAddInfoObj[varname] = $.fn.zTree.init($("#treeSelect"+thisrel), settinEditInfo, selectconSubreeNode);
                        treeAddInfoObj[varname].checkAllNodes(false);
                    }else if(oo.retxt=="utp"){
                        selectconUtpTreeNode = oo.retobj;
                        treeAddInfoObj[varname] = $.fn.zTree.init($("#treeSelect"+thisrel), settinEditInfo, selectconUtpTreeNode);
                        treeAddInfoObj[varname].checkAllNodes(false);
                    }else if(oo.retxt=="mat"){
                        selectconMatTreeNode = oo.retobj;
                        treeAddInfoObj[varname] = $.fn.zTree.init($("#treeSelect"+thisrel), settinEditInfo, selectconMatTreeNode);
                        treeAddInfoObj[varname].checkAllNodes(false);
                    }else if(oo.retxt=="prd"){
                        selectconPrdTreeNode = oo.retobj;
                        treeAddInfoObj[varname] = $.fn.zTree.init($("#treeSelect"+thisrel), settinEditInfo, selectconPrdTreeNode);
                        treeAddInfoObj[varname].checkAllNodes(false);
                    }else{
                        selectconNullTreeNode = "";
                        treeAddInfoObjnull = $.fn.zTree.init($("#treeSelect"+thisrel), settinEditInfo, selectconNullTreeNode);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
            
        });
        $(document).on("click","#Additionaldelbtn",function(){
            var rel = $(this).attr("rel");
            $("#addDefault"+rel).remove();
            $("#rownull"+rel).remove();
        });
        //附加信息添加按鈕事件
        var Additionaladddom="";
        $(document).on("click","#Additionaladdbtn",function(){
            var editlen = $(document).find(".AdditionalInfo").length;
            Additionaladddom="";//初始化為空
            Additionaladddom +="<div class=\"row\" id=\"addDefault"+editlen+"\">";
            Additionaladddom +="    <div class=\"col-xs-2 no-padding text-center\">附加信息：</div>";
            Additionaladddom +="    <div class=\"col-xs-1 no-padding\">";
            Additionaladddom +="        <select class=\"AdditionalInfo\" id=\"AdditionalInfo"+editlen+"\" rel=\""+editlen+"\" name=\"AdditionalInfo\"></select>";
            Additionaladddom +="    </div>";
            Additionaladddom +="    <div class=\"col-xs-2 no-padding text-center\">选择内容：</div>";
            Additionaladddom +="    <div class=\"col-xs-3 no-padding\">";
            Additionaladddom +="        <select id=\"SelectContent"+editlen+"\" class=\"SelectContent\" rel=\""+editlen+"\" name=\"SelectContent\" multiple></select>";
            Additionaladddom +="        <div class=\"btn-group\">";
            Additionaladddom +="            <button data-toggle=\"dropdown\" class=\"btn btn-info btn-sm dropdown-toggle btn_size\">";
            Additionaladddom +="                选择";
            Additionaladddom +="                <span class=\"icon-caret-down icon-on-right\"></span>";
            Additionaladddom +="            </button>";
            Additionaladddom +="            <ul id=\"treeSelect"+editlen+"\" class=\"dropdown-menu ztree\"></ul>";
            Additionaladddom +="        </div>";
            Additionaladddom +="    </div>";
            Additionaladddom +="    <div class=\"col-xs-2 no-padding text-center\">可选个数：</div>";
            Additionaladddom +="    <div class=\"col-xs-1 no-padding\">";
            Additionaladddom +="        <select id=\"SelectNum"+editlen+"\" name=\"SelectNum\">";
            $.each(optionjson,function(index,items){
                Additionaladddom +="            <option value=\""+items.optionval+"\">"+items.optiontxt+"</option>";
            })
            Additionaladddom +="        </select>";
            Additionaladddom +="    </div>";
            Additionaladddom +="    <div class=\"col-xs-1 no-padding text-center\">";
            //Additionaladddom +="        <i class=\"glyphicon glyphicon-plus\" id=\"Additionaladdbtn\" title=\"添加\" style=\"cursor:pointer;\"></i>&#8195;";
            Additionaladddom +="        <i class=\"glyphicon glyphicon-minus\" id=\"Additionaldelbtn\" rel=\""+editlen+"\" title=\"刪除\" style=\"cursor:pointer;\"></i>";
            Additionaladddom +="    </div>";
            Additionaladddom +="</div>";
            Additionaladddom +="<div class=\"space-8\" id=\"rownull"+editlen+"\"></div>";
            //
            $("#fieldsetid").append(Additionaladddom);
            $("#AdditionalInfo"+editlen).html(addInfoOption);//給附加信息下拉列表賦值
            $("#SelectContent"+editlen).tagsinput({
                itemValue: 'id',
                itemText: 'text',
            });
            
            var varname="treeAddInfoObj"+editlen;
            treeAddInfoObj[varname] = $.fn.zTree.init($("#treeSelect"+editlen), settinEditInfo, selectconPrdTreeNode);
            $("#SelectContent"+editlen).on("itemRemoved", function (event) {
                var node = treeAddInfoObj[varname].getNodeByParam("id", event.item.id, null);
                treeAddInfoObj[varname].checkNode(node, false, false);
            });
            treeAddInfoObj[varname].checkAllNodes(false);
            editlen++;
        });
    </script>
    <script src="js/BusPlatDownEdit.js"></script><!--业务平台下拉列表-->
    <script src="js/SelectContentEdit.js"></script><!--附加設置信息選擇內容下拉列表-->

    <script type="text/javascript">
        //修改页面初始化
        //编辑初始化
        if(servfuncModelNode!=""){
            $("#autoid").val(servfuncModelNode.AutoId);
            $("#BusinessType").val(servfuncModelNode.TypeCode);
            $("#BusinessCode").val(servfuncModelNode.FuncCode);
            $("#oldFuncCode").val(servfuncModelNode.FuncCode);
            $("#FuncName").val(servfuncModelNode.FuncName);
            $("#UseRange").val(servfuncModelNode.FuncRange);
            $("#AddSetInfo").val(servfuncModelNode.FuncSet);
            $("#BusinessDesc").val(servfuncModelNode.FuncDes);
            //$("#TagsBusinessPlatfrom").val(servfuncModelNode.TypeCode)
            $("#Note").val(servfuncModelNode.FuncNote)
        }
        //遍历附加信息初始化DOM
        var Additionalexitdom="";
        var editlen=1;
        $.each(servfuncextjson, function (index, item) { //遍历返回的json
            if(index=="0"){
                $("#AdditionalInfo0").val(item.NapeCode);
                $("#SelectNum0").val(item.NapeC);
            }else{
                Additionalexitdom +="<div class=\"row\" id=\"addDefault"+index+"\">";
                Additionalexitdom +="    <div class=\"col-xs-2 no-padding text-center\">附加信息：</div>";
                Additionalexitdom +="    <div class=\"col-xs-1 no-padding\">";
                Additionalexitdom +="        <select class=\"AdditionalInfo\" id=\"AdditionalInfo"+index+"\" rel=\""+index+"\" name=\"AdditionalInfo\">";
                $.each(addinfoTreeNode, function (indexs, items) {
                    if(item.NapeCode==items.NapeCode){
                        Additionalexitdom +="        <option value=\""+items.NapeCode+"\" selected>"+items.NapeName+"</option>";
                    }else{
                        Additionalexitdom +="        <option value=\""+items.NapeCode+"\">"+items.NapeName+"</option>";
                    }
                })
                Additionalexitdom +="        </select>";
                Additionalexitdom +="    </div>";
                Additionalexitdom +="    <div class=\"col-xs-2 no-padding text-center\">选择内容：</div>";
                Additionalexitdom +="    <div class=\"col-xs-3 no-padding\">";
                Additionalexitdom +="        <select id=\"SelectContent"+index+"\" class=\"SelectContent\" rel=\""+index+"\" name=\"SelectContent\" multiple></select>";
                Additionalexitdom +="        <div class=\"btn-group\">";
                Additionalexitdom +="            <button data-toggle=\"dropdown\" class=\"btn btn-info btn-sm dropdown-toggle btn_size\">";
                Additionalexitdom +="                选择";
                Additionalexitdom +="                <span class=\"icon-caret-down icon-on-right\"></span>";
                Additionalexitdom +="            </button>";
                Additionalexitdom +="            <ul id=\"treeSelect"+index+"\" class=\"dropdown-menu ztree\"></ul>";
                Additionalexitdom +="        </div>";
                Additionalexitdom +="    </div>";
                Additionalexitdom +="    <div class=\"col-xs-2 no-padding text-center\">可选个数：</div>";
                Additionalexitdom +="    <div class=\"col-xs-1 no-padding\">";
                Additionalexitdom +="        <select id=\"SelectNum"+index+"\" name=\"SelectNum\">";
                $.each(optionjson,function(indexs,items){
                    if(items.optionval==item.NapeC){
                        Additionalexitdom +="            <option value=\""+items.optionval+"\" selected>"+items.optiontxt+"</option>";
                    }else{
                        Additionalexitdom +="            <option value=\""+items.optionval+"\">"+items.optiontxt+"</option>";
                    }
                })
                Additionalexitdom +="        </select>";
                Additionalexitdom +="    </div>";
                Additionalexitdom +="    <div class=\"col-xs-1 no-padding text-center\">";
                //Additionalexitdom +="        <i class=\"glyphicon glyphicon-plus\" id=\"Additionaladdbtn\" title=\"添加\" style=\"cursor:pointer;\"></i>&#8195;";
                Additionalexitdom +="        <i class=\"glyphicon glyphicon-minus\" id=\"Additionaldelbtn\" rel=\""+index+"\" title=\"刪除\" style=\"cursor:pointer;\"></i>";
                Additionalexitdom +="    </div>";
                Additionalexitdom +="</div>";
                Additionalexitdom +="<div class=\"space-8\" id=\"rownull"+index+"\"></div>";
            }
            editlen = index+1;
        })
        $("#fieldsetid").append(Additionalexitdom);
        //编辑页面初始化下拉列表树以及Select多选初始化赋值
        for(var i=0;i<editlen;i++){
            $(document).find("#SelectContent"+i).tagsinput({
                itemValue: 'id',
                itemText: 'text',
            });
            var params = '{"napecode":"' + $("#AdditionalInfo"+i).val() + '"}';
            $.ajax({
                type: "POST",
                url: "ServFuncEdit.aspx/getaddcont",
                data: params,
                dataType: "json",
                async: false,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var oo = eval('('+data.d+')');
                    if(oo.retxt=="prd"){
                        selectconPrdTreeNode = oo.retobj;
                        $.fn.zTree.init($("#treeSelect"+i), settinEditInfo, selectconPrdTreeNode);
                        if (selectconPrdTreeNode) {
                            for (var x in selectconPrdTreeNode) {
                                if (selectconPrdTreeNode[x].checked == 'true') {
                                    $('#SelectContent'+i).tagsinput('add', { id: selectconPrdTreeNode[x].id, text: selectconPrdTreeNode[x].name });
                                }

                            }
                        }
                    }else if(oo.retxt=="grd"){
                        selectconGrdTreeNode = oo.retobj;
                        $.fn.zTree.init($("#treeSelect"+i), settinEditInfo, selectconGrdTreeNode);
                        if (selectconGrdTreeNode) {
                            for (var x in selectconGrdTreeNode) {
                                if (selectconGrdTreeNode[x].checked == 'true') {
                                    $('#SelectContent'+i).tagsinput('add', { id: selectconGrdTreeNode[x].id, text: selectconGrdTreeNode[x].name });
                                }

                            }
                        }
                    }else if(oo.retxt=="sub"){
                        selectconSubreeNode = oo.retobj;
                        $.fn.zTree.init($("#treeSelect"+i), settinEditInfo, selectconSubreeNode);
                        if (selectconSubreeNode) {
                            for (var x in selectconSubreeNode) {
                                if (selectconSubreeNode[x].checked == 'true') {
                                    $('#SelectContent'+i).tagsinput('add', { id: selectconSubreeNode[x].id, text: selectconSubreeNode[x].name });
                                }

                            }
                        }
                    }else if(oo.retxt=="utp"){
                        selectconUtpTreeNode = oo.retobj;
                        $.fn.zTree.init($("#treeSelect"+i), settinEditInfo, selectconUtpTreeNode);
                        if (selectconUtpTreeNode) {
                            for (var x in selectconUtpTreeNode) {
                                if (selectconUtpTreeNode[x].checked == 'true') {
                                    $('#SelectContent'+i).tagsinput('add', { id: selectconUtpTreeNode[x].id, text: selectconUtpTreeNode[x].name });
                                }

                            }
                        }
                    }else if(oo.retxt=="mat"){
                        selectconMatTreeNode = oo.retobj;
                        $.fn.zTree.init($("#treeSelect"+i), settinEditInfo, selectconMatTreeNode);
                        if (selectconMatTreeNode) {
                            for (var x in selectconMatTreeNode) {
                                if (selectconMatTreeNode[x].checked == 'true') {
                                    $('#SelectContent'+i).tagsinput('add', { id: selectconMatTreeNode[x].id, text: selectconMatTreeNode[x].name });
                                }

                            }
                        }
                        }else{
                            selectconNullTreeNode = "";
                            treeAddInfoObjnull = $.fn.zTree.init($("#treeSelect"+i), settinEditInfo, selectconNullTreeNode);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        }
        //Select下拉列表框中删除某一项时触发
        $(document).find(".SelectContent").on("itemRemoved", function (event) {
            var rel = $(this).attr("rel");
            var treeObjss = $.fn.zTree.getZTreeObj("treeSelect" + rel);
            var nodess = treeObjss.getNodeByParam("id", event.item.id, null);
            treeObjss.checkNode(nodess, false, false);
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
