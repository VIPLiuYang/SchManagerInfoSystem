<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchShow.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.School.SchShow" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>学校操作</title>
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

    <!-- fonts -->

     

    <!-- ace styles -->

    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/bootstrap-tagsinput.css">
    <link rel="stylesheet" href="../../assets/css/metro.css" />
    <style>
        .bootstrap-tagsinput {
            border:0px;
            box-shadow:none;
        }
        .label-info {
            background-color:white!important;            
        }
        .label {
            font-size:14px;
            color:black;
        }
        .bootstrap-tagsinput .tag {
            color:black;
        }
        .form-group input[disabled], .form-group input:disabled,.form-group select:disabled,input:disabled {
            color: #999999!important;
            background-color: #fff!important;
            border-style: none;
            font-size:12px;
        }
        /**/
        control[disabled], .form-control[readonly], fieldset[disabled] .form-control {
            cursor: not-allowed;
            background-color: #fffefe;
            border-style: none;
        }
        /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }

        i {
            font-family: FontAwesome !important;
        }
        /*所在位置的提示高度*/
        .breadcrumbs {
            min-height:32px;
            line-height:30px;
        }
        /*所在位置的背景边框*/
        .breadcrumb_box {
            background: white;
            border-bottom: 1px solid #e4e4e4;
            
        }
        /*坐在位置的坐边竖线*/
        .breadcrumb_border {
            border-left: 2px solid #63bbff;
            margin-left: 0px;
            padding-left: 12px;
            
        }
        /*内容上边距*/
        .content_box {
            padding-top: 24px;
        }

        /*学校名称等左边标签的样式*/
        .text_style {
            
            line-height: 30px !important;
            color: #000000 !important;
        }
        .text_style label {
            font-size: 14px !important;
         }
        /*内容区域的字体大小颜色*/
        .lbl {
            font-size: 12px !important;
            color: #999999;
        }
        /*学段，年级字体的大小颜色*/
        .color {
            font-size: 13px !important;
            color: #666666 !important;
        }
        /*备注区域的最小高度*/
        .note {
            min-height: 100px;
        }
        /*年级右内边距*/
        .nianji {
            padding-right:0;
        }
        /*位置提示字体大小*/
        .breadcrumb > li {
            font-size:13px !important;
            color:#666666 !important;
        }
        /*科目的颜色*/
        .bootstrap-tagsinput .tag {
            font-size:12px;
            color:#999999 !important;
        }
        /*输入框所在的盒子上下边距*/
        .input_box {
            padding:4px 10px;
        }
        /*下拉选框 输入框的大小*/
         select, input {
            font-size:12px;
            color:#999999;
        }
        input[type="text"] {
            color:#999999 !important;
            font-size:12px !important;
        }
         /*每一行的间距*/
        .form-group {
            margin-bottom:2px;
        }
        /*当屏幕大于768时联系方式和地址的最大宽度*/
        @media (min-width:768px) {
            .phone {
                max-width: 150px;
            }

            .address {
                max-width: 400px;
            }
        }

        .button_bg {
            margin-top: 10px !important;
            margin-bottom: 10px !important;
        }
        /*当屏幕小于768时取消学段的浮动*/
         @media (max-width:768px) {
            .bianju {
                text-align:initial !important;
            }
        }
    </style>

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
    <script src="../../assets/CustomFunction/DataVerification.js"></script>
</head>

<body ontouchstart>

    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>
        <style type="text/css">
    .breadcrumb>li+li:before{content:none;}
    input[type=checkbox].ace:disabled+.lbl::before, input[type=radio].ace:disabled+.lbl::before, input[type=checkbox].ace[disabled]+.lbl::before, input[type=radio].ace[disabled]+.lbl::before, input[type=checkbox].ace.disabled+.lbl::before, input[type=radio].ace.disabled+.lbl::before{color:#32A3CF;}
        </style>
        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
                <div class="breadcrumbs breadcrumb_box " id="breadcrumbs">
                    <script type="text/javascript">
                        try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
                    </script>

                    <ul class="breadcrumb breadcrumb_border">
                        <li>
                            <%--<i class="icon-home home-icon"></i>--%>
                            目前位置：
                        </li>
                        <%--<li>
                            <a href="#">学校管理</a>
                        </li>--%>
                        <%--将学校信息改为学校及科目信息--%>
                        <li class="active">学校及科目信息 </li>
                    </ul>
                    <!-- .breadcrumb -->
                </div>

                <div class="page-content content_box">
                    <%--<div class="page-header">
                        <h1>学校信息
								<small>
                                    <i class="icon-double-angle-right"></i>
                                    学校操作
                                </small>
                        </h1>
                        <%=returl %>
                    </div>--%>
                    <!-- /.page-header -->

                    <div class="row">
                        <%--减小栅格栏--%>
                        <div class="col-xs-12  col-sm-10 col-sm-offset-2">
                            <!-- PAGE CONTENT BEGINS -->

                            <form class="form-horizontal  " role="form">
                                
                                <div class="space-8"></div>
                                <div class="form-group form-inline ">
                                    <div class="col-sm-4 text_style">
                                        <div class="col-sm-3 no-padding-right text-right">
                                            <label >学校名称:</label>
                                        </div>
                                        <div class="col-sm-9 input_box">
                                            <input type="text" id="schname"     disabled="disabled"/>
                                        </div>
                                    </div>
                                    <div class="col-sm-8 text_style">
                                        <div class="col-sm-2 no-padding-right  text-right">
                                            <label >所在区域:</label>
                                        </div>
                                        <div class="col-sm-9">
                                            <%=areastr %>
                                        </div>
                                    </div>

                                </div>
                                <div class="form-group form-inline">
                                    <div class="col-sm-4 text_style">
                                        <div class="col-sm-3 no-padding-right text-right">
                                            <label class="">是否为城区:</label>
                                        </div>
                                        <div class="col-sm-3">
                                            <div class="control-group col-xs-12 col-sm-12 no-padding-right no-padding-left">
                                                <label>
                                                    <input name="iscity" type="radio" value="1" class="ace" disabled="disabled">
                                                    <span class="lbl ">是</span>
                                                </label>
                                                &nbsp &nbsp 
                                                <label>
                                                    <input name="iscity" type="radio" value="0" class="ace" disabled="disabled">
                                                    <span class="lbl ">否</span>
                                                </label>
                                            </div>
                                        </div>
                                        <div class="col-sm-2 no-padding-right schstatdiv text-right ">
                                            <label class="">状态:</label>
                                        </div>
                                        <div class="col-sm-4 schstatdiv">
                                            <div class="control-group col-xs-12 col-sm-12 no-padding-right no-padding-left">
                                                <label>
                                                    <input name="schstat" type="radio" value="1" class="ace" disabled="disabled">
                                                    <span class="lbl">正常</span>
                                                </label>&nbsp &nbsp 
                                                <label>
                                                    <input name="schstat" type="radio" value="0" class="ace" disabled="disabled">
                                                    <span class="lbl">废弃</span>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-8 text_style">
                                        <div class="col-sm-2 no-padding-right  text-right ">
                                            <label class="">学校地址:</label>
                                        </div>
                                        <div class="col-sm-9 input_box">
                                            <input type="text" id="schaddr"  class="col-xs-12 col-sm-12 address" disabled="disabled" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group form-inline">
                                    <div class="col-sm-4 text_style">
                                        <div class="col-sm-3 no-padding-right text-right">
                                            <label class="">系统管理员:</label>
                                        </div>
                                        <div class="col-sm-3 input_box">
                                            <input type="text" id="schmaster"  class="col-xs-12 col-sm-12"  disabled="disabled"/>
                                        </div>
                                        <div class="col-sm-2 no-padding-right text-right text_style">
                                            <label class="">职务:</label>
                                        </div>
                                        <div class="col-sm-4 text_style input_box">
                                            <input type="text" id="schmasterpst"  class="col-xs-12 col-sm-12"  disabled="disabled"/>
                                        </div>
                                    </div>
                                    <div class="col-sm-8 text_style">
                                        <div class="col-sm-2 no-padding-right  text-right ">
                                            <label >联系电话:</label>
                                        </div>
                                        <div class="col-sm-9 input_box ">
                                            <input type="text" id="schmastertel"  class="col-xs-12 col-sm-12 phone"  disabled="disabled"/>
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="space-2"></div>--%>
                                
                                <div class="row">
                                    <div class="col-sm-12 text_style">
                                        <div class="col-sm-1 no-padding-right text-right">
                                            <label >学段及年级:</label>
                                        </div>
                                        <div class="col-sm-11">
                                            <div class="row">
                                                <div class="col-sm-2">
                                                    <label><span class="lbl color">学段：</span></label>&nbsp&nbsp
                                                    <label>
                                                        <input name="gradechkl" type="checkbox" class="ace" value="1" disabled="disabled">
                                                        <span class="lbl">幼儿园</span>
                                                    </label>
                                                </div>
                                                <div class="col-sm-10">
                                                    <div class="col-sm-1 text-right nianji"><label><span class="lbl color">年级：</span></label></div>
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="1001" disabled="disabled">
                                                            <span class="lbl">小小班</span>
                                                        </label>
                                                    </div>
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="1002" disabled="disabled">
                                                            <span class="lbl">小班</span>
                                                        </label>
                                                    </div>
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="1003" disabled="disabled">
                                                            <span class="lbl">中班</span>
                                                        </label>
                                                    </div>
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="1004" disabled="disabled">
                                                            <span class="lbl">大班</span>
                                                        </label>
                                                    </div>
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="1005" disabled="disabled">
                                                            <span class="lbl">学前班</span>
                                                        </label>
                                                    </div>
                                                </div>
                                            </div>
                                           <%-- <div class="space-2"></div>--%>
                                            <div class="row">
                                                <div class="col-sm-2">
                                                    <label><span class="lbl color">学段：</span></label>&nbsp&nbsp
                                                    <label>
                                                        <input name="gradechkl" type="checkbox" class="ace" value="2" disabled="disabled">
                                                        <span class="lbl">小学</span>
                                                    </label>
                                                </div>
                                                <div class="col-sm-10">
                                                    <div class="col-sm-1 text-right nianji "><label><span class="lbl color">年级：</span></label></div>
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="2001" disabled="disabled">
                                                            <span class="lbl">一年级</span>
                                                        </label>
                                                    </div>
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="2002" disabled="disabled">
                                                            <span class="lbl">二年级</span>
                                                        </label>
                                                    </div>
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="2003" disabled="disabled">
                                                            <span class="lbl">三年级</span>
                                                        </label>
                                                    </div>
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="2004" disabled="disabled">
                                                            <span class="lbl">四年级</span>
                                                        </label>
                                                    </div>
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="2005" disabled="disabled">
                                                            <span class="lbl">五年级</span>
                                                        </label>
                                                    </div>
                                                    
                                                    <div class="col-sm-2">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="2006" disabled="disabled">
                                                            <span class="lbl">六年级</span>
                                                        </label>
                                                    </div>
                                                    
                                                </div>
                                            </div>
                                            <%--<div class="space-2"></div>--%>
                                            <div class="row">
                                                <div class="col-sm-2">
                                                    <label><span class="lbl color">学段：</span></label>&nbsp&nbsp
                                                    <label>
                                                        <input name="gradechkl" type="checkbox" class="ace" value="3" disabled="disabled">
                                                        <span class="lbl">初中</span>
                                                    </label>
                                                </div>
                                                <div class="col-sm-10">
                                                    <div class="col-sm-1 text-right nianji "><label><span class="lbl color">年级：</span></label></div>
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="3001" disabled="disabled">
                                                            <span class="lbl">初一</span>
                                                        </label>
                                                    </div>
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="3002" disabled="disabled">
                                                            <span class="lbl">初二</span>
                                                        </label>
                                                    </div>
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="3003" disabled="disabled">
                                                            <span class="lbl">初三</span>
                                                        </label>
                                                    </div>
                                                    <!--
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="3004">
                                                            <span class="lbl">初四</span>
                                                        </label>
                                                    </div>
                                                    -->
                                                </div>
                                            </div>
                                           <%-- <div class="space-2"></div>--%>
                                            <div class="row">
                                                <div class="col-sm-2">
                                                    <label><span class="lbl color">学段：</span></label>&nbsp&nbsp
                                                    <label>
                                                        <input name="gradechkl" type="checkbox" class="ace" value="4" disabled="disabled">
                                                        <span class="lbl">高中</span>
                                                    </label>
                                                </div>
                                                <div class="col-sm-10">
                                                    <div class="col-sm-1 text-right nianji"><label><span class="lbl color">年级：</span></label></div>
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="4001" disabled="disabled">
                                                            <span class="lbl">高一</span>
                                                        </label>
                                                    </div>
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="4002" disabled="disabled">
                                                            <span class="lbl">高二</span>
                                                        </label>
                                                    </div>
                                                    <div class="col-sm-1">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="4003" disabled="disabled">
                                                            <span class="lbl">高三</span>
                                                        </label>
                                                    </div>
                                                    <!--
                                                    <div class="col-sm-2">
                                                        <label>
                                                            <input name="gradechk" type="checkbox" class="ace" value="4004">
                                                            <span class="lbl">高四</span>
                                                        </label>
                                                    </div>
                                                    -->
                                                </div>
                                            </div>
                                            
                                            
                                        </div>
                                    </div>
                                </div>
                                <div class="space-2"></div>
                                 <div class="row">
                                    <div class="col-sm-12 text_style">
                                        <div class="col-sm-1 no-padding-right text-right ">
                                            <label>开设科目:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <select id="selsubs" disabled="disabled" multiple>
                                            </select>
                                            <br />
                                            
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="space-10"></div>--%>
                                <%--<div class="row">
                                    <div class="col-sm-12">
                                        <div class="col-sm-1 no-padding-right text-right ">
                                            <label for="schnote" class="text_style">其他说明:</label>
                                        </div>
                                        <div class="col-sm-10">
                                            <textarea id="schnote" class="form-control note" data-toggle="tooltip" title="最长1000字" onblur="checkTxt(this,'^.{0,1000}$')" placeholder="说明(最长1000汉字)"></textarea>
                                        </div>
                                    </div>
                                </div>--%>
                            </form>
                            <!-- PAGE CONTENT ENDS -->
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.page-content -->
            </div>
            <!-- /.main-content -->

            <!-- /#ace-settings-container -->
        </div>
        <!-- /.main-container-inner -->
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
    <script type="text/javascript">

    </script>

    <script type="text/javascript">
        
        //下拉部门框点击屏蔽
        $('.dropdown-menu').click(function(e) {
            e.stopPropagation();
        });
        //初始化 学段 选择
        $("#selgrades").tagsinput({
            itemValue: 'id',
            itemText: 'text',
        });
        //初始化 科目 选择
        $("#selsubs").tagsinput({
            itemValue: 'id',
            itemText: 'text',
        });
        
        var treegradesObj;//年级树
        var treesubsObj;//科目树
        var treegradesNodes =<%=grades%>; 
        var treesubsNodes =<%=subs%>;
        //学段树配置
        var settinggrads = {
            check: {
                enable: true,
                autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  


                chkboxType: { "Y": "ps", "N": "ps" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  


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
                onCheck: GradesTreeOnCheck
            }
        };
        //学段树配置
        var settingsubs = {
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
        $("input[name='gradechkl']").change(function() 
        {
            var tf=$(this).is(':checked')
            var vl=$(this).attr("value");
            var grade=$("input[name='gradechk']");
            for (var i in grade) {
                var ival=$(grade[i]).attr("value");
                if(ival.substring(0,1)==vl)
                {
                    $(grade[i]).prop("checked",tf);
                    if(!tf)
                    {
                        $(grade[i]).removeAttr("checked");
                    }
                    else
                    {
                        $(grade[i]).attr("checked","checked");
                    }
                }
            }
        });
        $("input[name='gradechk']").change(function() 
        {
            var tf=$(this).is(':checked')
            var vl=$(this).attr("value");  
            
            if(tf)
            {
                var od=$("input[name='gradechkl'][value="+vl.substring(0,1)+"]");
                $("input[name='gradechkl'][value="+vl.substring(0,1)+"]").prop("checked",true);
                $(this).attr("checked","checked");                
            }
            else
            {
                var grade=$("input[name='gradechk']");
                $(this).removeAttr("checked");
                var ii=0;
                for (var i = 0; i < grade.length; i++) {
                    var gradeval=$(grade[i]).attr("value");
                    if(gradeval.substring(0,1)==vl.substring(0,1))
                    {
                        if($(grade[i]).attr('checked')=="checked")
                        {
                            ii++;
                            break;
                        }
                    }  
                }
                if(ii==0)
                {
                    $("input[name='gradechkl'][value="+vl.substring(0,1)+"]").prop("checked",false);
                }
            }
            
        });
        //与选中联动
        function GradesTreeOnCheck(event, treeId, treeNode) {
            var arry = [ "1", "2", "3", "4" ]; 
            var result= $.inArray(treeNode.id, arry);
            if (treeNode.checked) {                
                if(result==-1)//学段不添加
                {
                    $('#selgrades').tagsinput('add', { id: treeNode.id, text: treeNode.name,pId:treeNode.pId });
                }
                else
                {   
                    if($("input[name='gradechk'][value="+treeNode.id+"]").attr("checked")!="checked")
                    {
                        $("input[name='gradechk'][value="+treeNode.id+"]").click();
                    }
                    $("input[name='gradechk'][value="+treeNode.id+"]").attr("checked","checked"); //勾选上学段
                    
                }
            } 
            else //删除
            {
                if(result==-1)//学段不添加
                {
                    $('#selgrades').tagsinput('remove', { id: treeNode.id, text: treeNode.name,pId:treeNode.pId});
                }
                else
                {
                    //$("input[name='gradechk'][value="+treeNode.id+"]").attr("checked",false); 
                    $("input[name='gradechk'][value="+treeNode.id+"]").removeAttr("checked"); 
                }
            }
        };
        //与选中联动
        function SubsTreeOnCheck(event, treeId, treeNode) {
            if (treeNode.checked) {
                $('#selsubs').tagsinput('add', { id: treeNode.id, text: treeNode.name });
            } else {
                $('#selsubs').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
            }
        };
        //年级删除触发树节点取消
        $('#selgrades').on('itemRemoved', function (event) {
            var node = treegradesObj.getNodeByParam("id", event.item.id, null);
            treegradesObj.checkNode(node, false, false);
            //看该父节点下的子节点是否还有子节点是选中的,如果无,则取消父节点的选中
            var nodep = treegradesObj.getNodeByParam("id", event.item.pId, null);
            var nodeschk = treegradesObj.getNodesByFilter(filter, false ,nodep);
            if(nodeschk.length==0)
            {                
                treegradesObj.checkNode(nodep, false, false);
                $("input[name='gradechk'][value="+event.item.pId+"]").removeAttr("checked"); 
            }
            // event.item: contains the item
        });
        function filter(node) {
            return (node.checked == true);
        }
        //科目删除触发
        $('#selsubs').on('itemRemoved', function (event) {
            var node = treesubsObj.getNodeByParam("id", event.item.id, null);
            treesubsObj.checkNode(node, false, false);
            // event.item: contains the item
        });

        $(function () {
            //年级树
            if(treegradesNodes)
            {
                for (var x in treegradesNodes) {
                    if(treegradesNodes[x].checked=='true')
                    {
                        var arry = [ "1", "2", "3", "4" ]; 
                        var result= $.inArray(treegradesNodes[x].id, arry);
                        if(result==-1)
                        {
                            //$('#selgrades').tagsinput('add', { id: treegradesNodes[x].id, text: treegradesNodes[x].name,pId:treegradesNodes[x].pId });
                            $("input[name='gradechk'][value="+treegradesNodes[x].id+"]").attr("checked",true); 
                            $("input[name='gradechkl'][value="+treegradesNodes[x].pId+"]").attr("checked",true); 
                        }
                        
                    }
    
                }
            }
            treegradesObj = $.fn.zTree.init($("#gradestree"), settinggrads, treegradesNodes);
            
            treegradesObj.expandAll(true);
            var enode=treegradesObj.getNodeByParam("id", 0, null);
            if(enode)
            {
                treegradesObj.setChkDisabled(enode,true);
            }
            //科目树
            if(treesubsNodes)
            {
                for (var x in treesubsNodes) {
                    if(treesubsNodes[x].checked=='true')
                    {
                        $('#selsubs').tagsinput('add', { id: treesubsNodes[x].id, text: treesubsNodes[x].name });
                    }
    
                }
            }
            treesubsObj = $.fn.zTree.init($("#substree"), settingsubs, treesubsNodes);
            
            treesubsObj.expandAll(true);
            var enodesub=treesubsObj.getNodeByParam("id", 0, null);
            if(enodesub)
            {
                treesubsObj.setChkDisabled(enodesub,true);
            }
            if(systype!="2")
            {
                $('input,select,textarea',$('.form-horizontal')).attr('readonly',true);
                $('input,select,textarea',$('.form-horizontal')).attr("disabled", "disabled");
                $('.label-info span').hide();
                $('.dropdown-toggle').hide();
            }
        });
        var schid='<%=schid%>';
        var dotype='<%=dotype%>';
        var systype='<%=systype%>';
        if(systype!="2")
        {
            $('.schstatdiv').hide();
            $('#btndo').text("点击编辑");
            $('#btndo').attr('onclick', 'godo()');
            $('#btndoreset').hide();
        }
        function godo()
        {
            $('#btndo').text("保存");
            $('#btndo').attr('onclick', 'saveuser()');
            $('input,select,textarea',$('.form-horizontal')).removeAttr("readonly");
            $('input,select,textarea',$('.form-horizontal')).removeAttr("disabled");
            $('#btndoreset').show();
            $('.label-info span').show();
            $('.dropdown-toggle').show();
        }
        function notdo()
        {
            $('#btndo').text("点击编辑");
            $('#btndo').attr('onclick', 'godo()');
            $('#btndoreset').hide();
            $('input,select,textarea',$('.form-horizontal')).attr('readonly',true);
            $('input,select,textarea',$('.form-horizontal')).attr("disabled", "disabled");
            $('.label-info span').hide();
            $('.dropdown-toggle').hide();
        }
        //用户赋值
        var umodel=<%=umodelstr%>;
        if(umodel!="1")
        {
            $('#schname').val(umodel.SchName);
            $('#schaddr').val(umodel.SchAddr);
            $('#schmaster').val(umodel.SchMaster);
            $('#schmasterpst').val(umodel.MasterPostion);
            $('#schmastertel').val(umodel.SchTel);
            $('#schnote').val(umodel.SchNote);
            $("input[name='iscity'][value="+umodel.IsCity+"]").attr("checked",true);  
            $("input[name='schstat'][value="+umodel.Stat+"]").attr("checked",true);
            //usersub SubId  $("input[name='radioName'][checked]").val(); 
        }
        function saveuser()
        {
            var schname= $('#schname').val();
            var schaddr= $('#schaddr').val();
            var schmaster= $('#schmaster').val();
            var schmasterpst= $('#schmasterpst').val();
            var schmastertel= $('#schmastertel').val();
            //var schnote= $('#schnote').val();
            
            var iscity=$("input[name='iscity']:checked").val();
            var schstat=$("input[name='schstat']:checked").val();
            //获取科目并合并科目信息
            var gradechkval = gradechk= $("input[name=\"gradechk\"]:checked");
            var gradechklen = gradechk= $("input[name=\"gradechk\"]:checked").length;
            var gradechk = "";
            for(var i=0;i<gradechklen;i++){
                gradechk += $(gradechkval[i]).val()+",";
            }
            var selgrades = gradechk.substring(0,gradechk.length-1);
            
            //var selgrades= $('#selgrades').val();
            var selsubs=$("#selsubs").val();
            var areano=$("#acoty").val();
            if(schname!=""){
                //检查学校名称，只能使用字母、数字和汉字
                var regschname = /^[0-9a-zA-Z\u0391-\uFFE5]{1,25}$/;
                var resulschname = checkTxt("#schname",regschname);
                if(resulschname==false){
                    return false;
                }
            }
            if(schmaster!=""){
                //检查系统管理员，只能使用字母、数字和汉字
                var regschmaster = /^[0-9a-zA-Z\u0391-\uFFE5].{1,25}$/;
                var resulschmaster = checkTxt("#schmaster",regschmaster);
                if(resulschmaster==false){
                    return false;
                }
            }
            if(schmasterpst!=""){
                //检查职务，只能使用字母、数字和汉字
                var regschmasterpst = /^[0-9a-zA-Z\u0391-\uFFE5].{1,25}$/;
                var resulschmasterpst = checkTxt("#schmasterpst",regschmasterpst);
                if(resulschmasterpst==false){
                    return false;
                }
            }
            if(schmastertel!=""){
                var regphone = /(^[0-9]{3,4}\-[0-9]{7,8}$)|(^[0-9]{7,8}$)|(^\([0-9]{3,4}\)[0-9]{3,8}$)|(^0{0,1}13|15[0-9]{9}$)/;
                var resultxt = checkTxt("#schmastertel",regphone);
                if(resultxt==false){
                    return false;
                }
            }
            if(schaddr!=""){
                //检查学校地址，只能使用字母、数字和汉字
                var regschaddr = /^[0-9a-zA-Z|\u0391-\uFFE5].{0,100}$/;
                var resulschaddr = checkTxt("#schaddr",regschaddr);
                if(resulschaddr==false){
                    return false;
                }
            }
            //判断学科是否为空，如果为null，提示请添加科目,javascript中null类型是是一个object
            
            if(selsubs=="null" || selsubs==null){
                alert("请添加科目");
                return false;
            }
            if(selgrades==""){
                alert("请选择学段");
                return false;
            }
            var params = '{"dotype":"' + dotype + '","schid":"' + schid + '","schname":"' + schname + '","schaddr":"' + schaddr + '","schmaster":"' + schmaster + '","schmasterpst":"' + schmasterpst + '","schmastertel":"' + schmastertel + '","iscity":"' + iscity + '","schstat":"' + schstat + '","selgrades":"' + selgrades + '","selsubs":"' + selsubs + '","areano":"' + areano + '","schnote":""}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SchEdit.aspx/schsave",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d=='success')
                    {
                        alert("操作成功");
                    }
                    else
                    {
                        alert(data.d);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
            
        }
        //获取市
        $('#aprov').change(function () {
            var selv = $('#aprov').val();
            var params = '{"typecode":"1","pcode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "../Users/UserInfo.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $('#acity').html(data.d);
                    $('#acity').change();
                },
                error: function (obj, msg, e) {
                }
            });
        });
        //获取区
        $('#acity').change(function () {
            var selv = $('#acity').val();
            var params = '{"typecode":"2","pcode":"' + selv + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "../Users/UserInfo.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $('#acoty').html(data.d);
                    $('#acoty').change();
                },
                error: function (obj, msg, e) {
                }
            });
        });
        function checkTxt(o,reg){
            var regu =reg;
            var re = new RegExp(regu);
            if (re.test($(o).val())||re.test($(o).text())) {
                return true;
            }else{
                $(o).tooltip('show');
                $(o).focus();
                return false;
            }
        }
    </script>
    <script type="text/javascript">

        $.each(treegradesNodes, function(ids, obj) {
            
        });            
    </script>
</body>
</html>