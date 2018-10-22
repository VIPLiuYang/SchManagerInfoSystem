<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysPerDialog.aspx.cs" Inherits="SchWebAdmin.Web.SysSchbasic.SysPerDialog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="../../assets/css/chosen.css" />

    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/bootstrap-tagsinput.css" />
    <link rel="stylesheet" href="../../assets/css/metro.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>
    <style>
        .page-content {
            padding: 0px;
        }

        .row {
            margin: 0px;
            font-size: 14px;
            color: #999999;
        }

        .widget-box {
            margin: 0px;
            border: 0px;
        }

        .widget-body {
            border: 0px;
        }

        strong {
            margin-right: 15px;
            font-size: 14px;
            color: #393939;
        }
    </style>
</head>
<body ontouchstart>
    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>
        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
                <div class="page-content">
                    <div class="widget-box">
                        <div class="widget-body">
                            <div class="widget-main">
                                <div class="row">
                                    <div class="col-sm-6 col-xs-6"><strong>名称:</strong><input type="text" id="Name" style="width:70%" data-toggle="tooltip" maxlength="10" /></div>
                                    <div class="col-sm-6 col-xs-6">
                                        <strong>状态:</strong>
                                        <select id="Stat">
                                            <option value="1">正常</option>
                                            <option value="0">停用</option>
                                            <!--<option value="3">欠费</option>-->
                                        </select>
                                    </div>
                                </div>
                                <div class="space-4"></div>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <strong>年级:</strong><select disabled="disabled" id="tags-depts" multiple></select>
                                        <div>
                                            <%--   <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle btn_size">
                                                        选择年级
													        <span class="icon-caret-down icon-on-right"></span>
                                                    </button>--%>
                                            <ul id="treedept" class="dropdown-menu ztree">
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-right">
                            <input type="text" id="AutoId" hidden="hidden" />
                            <button class="btn btn-info btn-sm btn_size" id="btndo" type="button" onclick="save()"><%=btname %></button>
                            <button class="btn btn-sm btn_size" id="CancelBtn" type="reset">取消</button>
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
    <!-- (Optional) Latest compiled and minified JavaScript translation files -->
    <script src="../../assets/js/date-time/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="../../assets/css/datepicker.css" />
    <%--<script src="../../assets/js/i18n/defaults-zh_CN.min.js"></script>--%>
    <script type="text/javascript">
      
        var treeNodesgrade =<%=grademodelstr%>;
        $('#AutoId').val(<%=id%>);
        $('#Name').val('<%=name%>');
        $("#Stat").val(<%=stat%>);
        //部门树及部门选择
        //初始化部门选择
        $("#tags-depts").tagsinput({
            itemValue: 'id',
            itemText: 'text',
        });
        //部门删除触发
        $('#tags-depts').on('itemRemoved', function (event) {
            var node = treedeptObj.getNodeByParam("id", event.item.id, null);
            treedeptObj.checkNode(node, false, false);
            // event.item: contains the item
        });
        var treedeptObj;
        var settingdept = {
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
                    //  pIdKey: "pId",
                    checked: "checked",
                    rootPId: ""
                }
            },
            callback: {
                beforeClick: function (treeId, treeNode) {
                },
                onCheck: DeptzTreeOnCheck
            }
        };
        //与选中联动
        function DeptzTreeOnCheck(event, treeId, treeNode) {
            if (treeNode.checked) {
                $('#tags-depts').tagsinput('add', { id: treeNode.id, text: treeNode.name });
            } else {
                $('#tags-depts').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
            }
        };
        $(function () {
            if(treeNodesgrade)
            {
                for (var x in treeNodesgrade) {
                    if(treeNodesgrade[x].checked=='true')
                    {
                        $('#tags-depts').tagsinput('add', { id: treeNodesgrade[x].id, text: treeNodesgrade[x].name });
                    }  
                }
            }
            treedeptObj = $.fn.zTree.init($("#treedept"), settingdept, treeNodesgrade);
            treedeptObj.expandAll(true);

            $("#treeroles .checkbox_false_full").css("display","none");

        });
        $(document).on("click","#CancelBtn",function(){
            window.parent.createuserclose();
        });
        //数据收集并存库函数
        function save()
        {
            var userdpts=$("#tags-depts").val();
            //var userroles=$("#tags-select").val();
            var userroles="";
         
            var AutoId= $("#AutoId").val(); 
            var Name= $("#Name").val(); 
            if(Name=="")
            {
                alert("请填写名称");
                return false;
            }
            var Stat= $("#Stat").val(); 
            var params = '{"Name":"' + Name + '","stat":"' + Stat + '","AutoId":"' + AutoId + '"}';
            
            $.ajax({
                type: "POST",  //请求方式
                url: "SysPerDialog.aspx/save",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire")
                    {
                        window.location.href = "../../LoginExc.aspx";
                    }
                    else if (data.d.code == "error") {
                        alert(data.d.msg);
                    }
                    else if (data.d.code=='success')
                    {
                        alert(data.d.msg);
                        window.parent.createuserclose();                         
                    }
                },
                error: function (obj, msg, e) {
                }
            });
            
        }
 
    </script>
</body>
</html>
