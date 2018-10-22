<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchMenuSys.aspx.cs" Inherits="SchWebAdmin.Web.SchSearch.SchMenuSys" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title></title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />





    <!-- ace styles -->

    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/metrodpt.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>
    <style>
        /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }

        i {
            font-family: FontAwesome !important;
        }
        /*所在位置的提示高度*/
        .breadcrumbs {
            min-height: 32px;
            line-height: 30px;
        }
        /*所在位置的背景边框*/
        .breadcrumb_box {
            background: white;
            border-bottom: 1px solid #e4e4e4;
            color: #333333;
        }
        /*坐在位置的坐边竖线*/
        .breadcrumb_border {
            border-left: 2px solid #63bbff;
            margin-left: 0px;
            padding-left: 12px;
            /*padding-top: 4px;
            padding-bottom: 4px;*/
        }
        /*位置提示字体大小*/
        .breadcrumb > li {
            font-size: 13px !important;
            color: #666666 !important;
        }
        /*上边距*/
        .page-content {
            padding-top: 20px;
        }
        /*表格标题栏字体大小，颜色*/
        .table thead tr th {
            color: #444444 !important;
            font-weight: bold !important;
            font-size: 13px !important;
            letter-spacing: 1px !important;
        }
        /*表格的内容区字体大小颜色*/
        .table tbody tr td {
            color: #666666 !important;
            font-size: 13px !important;
        }

        body {
            background-color: transparent;
            overflow: -Scroll;
            overflow-x: hidden;
        }

        .search {
            margin-right: 10px;
            margin-left: 10px;
            font-size: 13px;
            color: #000000;
        }
        /*输入框  下拉选框中的字体样式*/
        input, select, textarea {
            font-size: 12px;
            color: #999999;
        }
            /*输入框中的字体样式*/
            input[type="text"] {
                font-size: 12px;
                color: #999999;
            }
        /*查询按钮的字体大小*/
        .text_size {
            font-size: 12px;
        }
        /*表格的行距*/
        .table thead > tr > th, .table tbody > tr > td {
            line-height: 1.5;
            text-align: center;
        }

        .breadcrumb > li + li:before {
            content: "";
        }
        /*树形结构的菜单字体颜色*/
        .ztree li span {
            color: #666;
        }
        /*树状结构点击状态*/
        .ztree li a.curSelectedNode {
            padding-top: 0px;
            background-color: #ffffff;
            color: #428bca;
            height: 21px;
            opacity: 0.8;
        }

            .ztree li a.curSelectedNode span:nth-child(2) {
                font-weight: bold;
            }
    </style>
</head>
<body>
    <div class="main-container" id="main-container">
        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
                <div class="row">
                    <div class="col-xs-12">
                        &nbsp;&nbsp;
            <label>子系统：</label><label id="zxt" style="color: #999999;"></label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <label>子系统状态：</label>
                        <label style="color: #999999;"><%=stat %></label>
                        <br />
                        <br />
                        <div class="col-sm-4">
                            <div class="widget-box" style="margin: 0px;">
                                <div class="widget-header widget-header-flat">
                                    <h5 style="color: #000000">学校后台管理菜单</h5>
                                </div>
                                <div class="widget-body">
                                    <div class="widget-main">
                                        <div class="row">
                                            <ul id="adminmenu" class="ztree"></ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="widget-box" style="margin: 0px;">
                                <div class="widget-header widget-header-flat">
                                    <h5 style="color: #000000">学校前台管理菜单</h5>
                                </div>
                                <div class="widget-body">
                                    <div class="widget-main">
                                        <div class="row">
                                            <ul id="usermenu" class="ztree"></ul>
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
    <script src="../../assets/js/bootstrap.min.js"></script>
    <script src="../../assets/js/typeahead-bs2.min.js"></script>
    <link href="../../assets/css/bootstrap-dialog.css" rel="stylesheet" />
    <script src="../../assets/js/bootstrap-dialog.js"></script>
    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>
    <script src="../../assets/js/bootstrap-paginator.js"></script>
    <script src="../../assets/js/jquery.ztree.all-3.5.min.js"></script>
    <script type="text/javascript">
        var adminmenu = '<%=adminmenu%>';
        var usermenu = '<%=usermenu%>';
        var zxt = '<%=zxt%>';
        window.onload = function () {
            zxt = eval("(" + zxt + ")");
            for (var i = 0; i < zxt.length; i++) {
                var jsonObj = zxt[i];
                document.getElementById('zxt').innerHTML += jsonObj.AppName + '&nbsp;&nbsp;';
            }
            admindotree(eval("(" + adminmenu + ")"));
            userdotree(eval("(" + usermenu + ")"))
        }
        var treedeptObj;
        function admindotree(d) {
            var treeNodesdept = d;
            var settingdept = {
                check: {
                    //enable: true,
                    //autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]   
                    chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]   
                    chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
                },
                view: {
                    //addHoverDom: addHoverDom,
                    //removeHoverDom: removeHoverDom,
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
                        rootPId: ""
                    }
                },
                callback: {
                    beforeClick: function (treeId, treeNode) {
                        // RoleEdit(treeId, treeNode);
                    }
                }
            };
            $(function () {
                treedeptObj = $.fn.zTree.init($("#adminmenu"), settingdept, treeNodesdept);
                treedeptObj.expandAll(true);
                var nodes = treedeptObj.getNodesByFilter(filter);

            });
        };
        function userdotree(d) {
            var treeNodesdept = d;
            var settingdept = {
                check: {
                    //enable: true,
                    //autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]   
                    chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]   
                    chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
                },
                view: {
                    //addHoverDom: addHoverDom,
                    //removeHoverDom: removeHoverDom,
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
                        rootPId: ""
                    }
                },
                callback: {
                    beforeClick: function (treeId, treeNode) {
                        // RoleEdit(treeId, treeNode);
                    }
                }
            };
            $(function () {
                treedeptObj = $.fn.zTree.init($("#usermenu"), settingdept, treeNodesdept);
                treedeptObj.expandAll(true);
                var nodes = treedeptObj.getNodesByFilter(filter);

            });
        };
        function filter(node) {
            return true;
        }


    </script>
</body>
</html>
