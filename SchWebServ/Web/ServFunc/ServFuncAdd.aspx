<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServFuncAdd.aspx.cs" Inherits="SchWebServ.Web.ServFunc.ServFuncAdd" %>

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
     
    <link rel="stylesheet" href="../../assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="../../assets/css/chosen.css" /> 

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
                    <div class="row">
                        <div class="col-xs-2 text-right">业务类型：</div>
                        <div class="col-xs-4 text-left">
                            <select id="BusinessType" class="col-xs-12"></select>
                        </div>
                        <div class="col-xs-2 text-right">功能代码：</div>
                        <div class="col-xs-4 text-left"><input  type="text" name="BusinessCode" id="BusinessCode"  onkeyup="checkTxt(this)" placeholder="请输入功能代码" maxlength="10" /></div>
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
                                        <select id="SelectContent0" class="SelectContent" name="SelectContent" multiple></select>
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
                                        <select id="SelectNum0" name="SelectNum">
                                            <option value="0">0</option>
                                            <option value="1" selected="selected">1</option>
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
                            <select class="col-xs-9" id="TagsBusinessPlatfrom" name="TagsBusinessPlatfrom" multiple></select> 
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
        var addinfoTreeNode = <%=addinfo%>;
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
            var FuncName = $("#FuncName").val();
            datasave.push("funcname#" + FuncName);
            if (FuncName == "") {
                alert("请输入功能名称！");
                return;
            }

            var UseRange = $("#UseRange").val();
            if (UseRange == "") {
                alert("请输入使用范围！");
                $("#UseRange").focus();
                return;
            }
            datasave.push("userange#" + UseRange);
         
            //var AddSetInfo = $("#AddSetInfo").val();
            var AdditionalInfoVal=$("[name='AdditionalInfo']");
            var SelectContentVal=$("[name='SelectContent']");
            var SelectNumVal=$("[name='SelectNum']");
            var sendAdditionalstr="";//格式：附加信息!選擇內容!可選個數|附加信息!選擇內容!可選個數
            var  arrayObj=[];
            if(AdditionalInfoVal.length>0&&SelectContentVal.length>0&&SelectNumVal.length>0){
                for(var i=0;i<AdditionalInfoVal.length;i++){
                    if($(SelectContentVal[i]).val()==null){
                        alert("附加设置信息第"+(i+1)+"个，选择内容不允许为空");
                        return false;
                    }
                    
                    //if($(SelectNumVal[i]).val()=="0"){
                    //    alert("“可选个数”设置为“0”时，“选择内容”只能选择一个");
                    //    return false;
                    //}

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
            if (TagsBusinessPlatfrom == null) {
                alert("请选择所属平台！");
                return;
            }
            var Note = $("#Note").val(); 
            datasave.push("note#" + Note);
            
            $.ajax({
                type: "POST",  //请求方式
                url: "ServFuncAdd.aspx/FuncAddSave",  //请求路径：页面/方法名字
                data: JSON.stringify({ arr: datasave }),     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data){
                    if(data.d.code == "expire"){
                        window.location.href = "../../LoginExc.aspx";
                    }else if (data.d.code == 'success'){
                        alert(data.d.msg);
                        window.parent.closeEditCfmmodel();
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
                url: "ServFuncAdd.aspx/getaddcont",
                data: params,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    var oo = eval('('+data.d+')');
                    if(oo.retxt=="grd"){
                        selectconGrdTreeNode = oo.retobj;
                        treeAddInfoObj[varname] = $.fn.zTree.init($("#treeSelect"+thisrel), settinAddInfo, selectconGrdTreeNode);
                    }else if(oo.retxt=="sub"){
                        selectconSubreeNode = oo.retobj;
                        treeAddInfoObj[varname] = $.fn.zTree.init($("#treeSelect"+thisrel), settinAddInfo, selectconSubreeNode);
                    }else if(oo.retxt=="utp"){
                        selectconUtpTreeNode = oo.retobj;
                        treeAddInfoObj[varname] = $.fn.zTree.init($("#treeSelect"+thisrel), settinAddInfo, selectconUtpTreeNode);
                    }else if(oo.retxt=="mat"){
                        selectconMatTreeNode = oo.retobj;
                        treeAddInfoObj[varname] = $.fn.zTree.init($("#treeSelect"+thisrel), settinAddInfo, selectconMatTreeNode);
                    }else if(oo.retxt=="prd"){
                        selectconPrdTreeNode = oo.retobj;
                        treeAddInfoObj[varname] = $.fn.zTree.init($("#treeSelect"+thisrel), settinAddInfo, selectconPrdTreeNode);
                    }else{
                        selectconNullTreeNode = "";
                        treeAddInfoObjnull = $.fn.zTree.init($("#treeSelect"+thisrel), settinAddInfo, selectconNullTreeNode);
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
        var addlen=1;
        $(document).on("click","#Additionaladdbtn",function(){
            Additionaladddom="";//初始化為空
            Additionaladddom +="<div class=\"row\" id=\"addDefault"+addlen+"\">";
            Additionaladddom +="    <div class=\"col-xs-2 no-padding text-center\">附加信息：</div>";
            Additionaladddom +="    <div class=\"col-xs-1 no-padding\">";
            Additionaladddom +="        <select class=\"AdditionalInfo\" id=\"AdditionalInfo"+addlen+"\" rel=\""+addlen+"\" name=\"AdditionalInfo\"></select>";
            Additionaladddom +="    </div>";
            Additionaladddom +="    <div class=\"col-xs-2 no-padding text-center\">选择内容：</div>";
            Additionaladddom +="    <div class=\"col-xs-3 no-padding\">";
            Additionaladddom +="        <select id=\"SelectContent"+addlen+"\" class=\"SelectContent\" rel=\""+addlen+"\" name=\"SelectContent\" multiple></select>";
            Additionaladddom +="        <div class=\"btn-group\">";
            Additionaladddom +="            <button data-toggle=\"dropdown\" class=\"btn btn-info btn-sm dropdown-toggle btn_size\">";
            Additionaladddom +="                选择";
            Additionaladddom +="                <span class=\"icon-caret-down icon-on-right\"></span>";
            Additionaladddom +="            </button>";
            Additionaladddom +="            <ul id=\"treeSelect"+addlen+"\" class=\"dropdown-menu ztree\"></ul>";
            Additionaladddom +="        </div>";
            Additionaladddom +="    </div>";
            Additionaladddom +="    <div class=\"col-xs-2 no-padding text-center\">可选个数：</div>";
            Additionaladddom +="    <div class=\"col-xs-1 no-padding\">";
            Additionaladddom +="        <select id=\"SelectNum"+addlen+"\" name=\"SelectNum\">";
            Additionaladddom +="            <option value=\"0\">0</option>";
            Additionaladddom +="            <option value=\"1\" selected=\"selected\">1</option>";
            Additionaladddom +="            <option value=\"2\">2</option>";
            Additionaladddom +="            <option value=\"3\">3</option>";
            Additionaladddom +="            <option value=\"4\">4</option>";
            Additionaladddom +="            <option value=\"5\">5</option>";
            Additionaladddom +="            <option value=\"6\">6</option>";
            Additionaladddom +="            <option value=\"7\">7</option>";
            Additionaladddom +="            <option value=\"8\">8</option>";
            Additionaladddom +="            <option value=\"9\">9</option>";
            Additionaladddom +="            <option value=\"10\">10</option>";
            Additionaladddom +="        </select>";
            Additionaladddom +="    </div>";
            Additionaladddom +="    <div class=\"col-xs-1 no-padding text-center\">";
            //Additionaladddom +="        <i class=\"glyphicon glyphicon-plus\" id=\"Additionaladdbtn\" title=\"添加\" style=\"cursor:pointer;\"></i>&#8195;";
            Additionaladddom +="        <i class=\"glyphicon glyphicon-minus\" id=\"Additionaldelbtn\" rel=\""+addlen+"\" title=\"刪除\" style=\"cursor:pointer;\"></i>";
            Additionaladddom +="    </div>";
            Additionaladddom +="</div>";
            Additionaladddom +="<div class=\"space-8\" id=\"rownull"+addlen+"\"></div>";
            //
            $("#fieldsetid").append(Additionaladddom);
            $("#AdditionalInfo"+addlen).html(addInfoOption);//給附加信息下拉列表賦值
            $("#SelectContent"+addlen).tagsinput({
                itemValue: 'id',
                itemText: 'text',
            });
            
            var varname="treeAddInfoObj"+addlen;
            treeAddInfoObj[varname] = $.fn.zTree.init($("#treeSelect"+addlen), settinAddInfo, selectconPrdTreeNode);
            $("#SelectContent"+addlen).on("itemRemoved", function (event) {
                var node = treeAddInfoObj[varname].getNodeByParam("id", event.item.id, null);
                treeAddInfoObj[varname].checkNode(node, false, false);
            });
            
            addlen++;
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
    <script src="js/BusPlatDown.js"></script><!--业务平台下拉列表-->
    <script src="js/SelectContent.js"></script><!--附加設置信息選擇內容下拉列表-->
</body>
</html>
