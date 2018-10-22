<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchDataListAdd.aspx.cs" Inherits="SchWebAdmin.Web.SchData.SchDataListAdd" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>Bootstrap表单组件金视野系统模板</title>
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
    <link rel="stylesheet" href="../../assets/css/bootstrap-select.css">
    <link rel="stylesheet" href="../../assets/css/metro.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>
    <style>
        /*所在位置的背景边框*/
        .breadcrumb_box {
            background: white;
            border-bottom: 1px solid #e4e4e4;
            /*color: #333333;*/
        }
        /*所在位置的提示高度*/
        .breadcrumbs {
            min-height: 32px;
            line-height: 30px;
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
        /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }

        i {
            font-family: FontAwesome !important;
        }
        /*定义标题大小*/
        .biaoti {
            font-size: 13px;
            color: #000000;
        }
            /*年级班级中的下拉选框中的颜色大小*/
            .biaoti select {
                font-size: 12px;
                color: #666666 !important;
            }
            /*年级班级中的下拉选框后边的提示语的颜色大小*/
            .biaoti span {
                font-size: 12px;
                color: #999999 !important;
            }
        /*定义内容大小*/
        .neirong {
            color: #999999 !important;
            font-size: 13px !important;
        }

        .neirong1 {
            color: #999999 !important;
            font-size: 12px !important;
        }
        /*学段，年级字体的大小颜色*/
        .color {
            font-size: 13px !important;
            color: #666666 !important;
        }
        /*内容区域的字体大小颜色*/
        .lbl {
            font-size: 12px !important;
            color: #999999;
            width: 82px;
        }
        /*表格中的每个单元格的内边距*/
        .table_box tr th {
            padding-left: 20px;
            padding-right: 20px;
        }
        /*去掉表格中输入框的边框*/
        .input_style {
            border: none !important;
        }
        /*每行的行高*/
        .lheight {
            line-height: 30px !important;
        }
        /*是否走读单选框的间距*/
        .jianju {
            padding-left: 24px;
        }
        /*每一行的间距*/
        .form-group {
            margin-bottom: 2px;
        }
        /*本页表格标题栏字体大小，颜色*/

        .liebiaobiaoti {
            font-size: 13px !important;
            color: #444444 !important;
            font-weight: bold !important;
            letter-spacing: 1px !important;
            text-align: center !important;
            line-height: 1.5 !important;
        }
        /*表格的内容区字体大小颜色*/
        .table tbody tr td {
            color: #666666 !important;
            font-size: 13px !important;
            text-align: center !important;
            line-height: 1.5 !important;
        }
        /*年级右内边距*/
        .nianji {
            padding-right: 1px;
        }
        /*科目下来框的颜色大小*/
        .ztree li a span {
            color: #666666;
            font-size: 12px !important;
        }
        /*输入框所在的盒子上下边距*/
        .input_box {
            padding: 4px 10px;
        }

        .search {
            margin-right: 10px;
            margin-left: 10px;
            font-size: 14px;
            color: #333333;
        }

        input[type="text"] {
            color: #999999;
            font-size: 12px;
            margin-left: 6px;
        }
        /*input中placeholder的颜色*/
        input::-webkit-input-placeholder, textarea::-webkit-input-placeholder { /* WebKit*/
            color: #999999;
            font-size: 12px;
        }

        input:-moz-placeholder, textarea:-moz-placeholder { /* Mozilla Firefox 4 to 18 */
            color: #999999;
            font-size: 12px;
        }

        input::-moz-placeholder, textarea::-moz-placeholder { /* Mozilla Firefox 19+ */
            color: #999999;
            font-size: 12px;
        }

        input:-ms-input-placeholder, textarea:-ms-input-placeholder { /* IE 10+ */
            color: #999999;
            font-size: 12px;
        }

        input:disabled {
            color: #999999 !important;
        }

        .breadcrumb > li + li:before {
            content: "";
        }
    </style>
</head>
<body>
    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>

        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
                <div class="breadcrumbs breadcrumb_box " id="breadcrumbs">
                    <script type="text/javascript">
                        try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
                    </script>

                    <ul class="breadcrumb breadcrumb_border ziti">
                        <li>
                            <%--<i class="icon-home home-icon"></i>--%>
                            目前位置：
                        </li>
                        <%--<li>
                            <a href="#">学校管理</a>
                        </li>--%>
                        <%--将学校信息改为学校及科目信息--%>
                        <li class="active">学校年级升级处理 </li>
                    </ul>
                    <!-- .breadcrumb -->


                </div>
                <style>
                    .thth {
                        text-align: right;
                        width: 110px;
                    }
                </style>
                <div class="page-content">

                    <%--<h1>用户管理
								<small>
                                    <i class="icon-double-angle-right"></i>
                                    用户操作(学校:<%=schname %>)
                                </small>
                        </h1>--%>
                    <div class="nav-search" id="nav-search">
                        <a class=" pull-right " href="javascript:window.history.go(-1);">
                            <i class="icon-reply icon-only"></i>
                            返回
                        </a>
                    </div>
                    <div class="row row col-sm-9 col-sm-offset-1">
                        <div class="row">
                            <div class="col-sm-12 ">
                                <div class="col-sm-12 text-right">
                                    <button class="btn btn-info btn-sm" id="btndo" type="button" onclick="SaveData()">
                                        <!--<i class="icon-ok bigger-110"></i>-->
                                        保存
                                    </button>

                                    &nbsp; &nbsp; &nbsp;
											<button class="btn btn-sm" id="btndoreset" type="button" onclick="notdo()">
                                                <%--<i class="icon-undo bigger-110"></i>--%>
                                                取消
                                            </button>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 no-padding-left">
                                <div class="col-sm-12 no-padding-left">
                                    <div class="col-sm-10 no-padding-left">
                                        <div class="input-group biaoti">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12">  
                            <form class="form-horizontal" role="form">
                                <div class=" form-inline lheight">
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right  text-right">
                                            <label class="biaoti">学校代码:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <input type="text" id="TestNo" placeholder="请输入学校代码" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">学校全称:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <input type="text" id="StuName" placeholder="请输入学校全称" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                 
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">所在区域:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <input type="text" id="CardNo" placeholder="请输入学校地址" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">&nbsp;</label>
                                        </div>
                                        <div class="col-sm-8">
                                            
                                        </div>
                                    </div>
                                </div>
                                <div class=" form-inline  lheight">
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">平台域名:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <input type="text" id="TelNo" placeholder="请输入平台域名" class="col-xs-12 col-sm-12 " />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">IP地址:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <input type="text" id="Addr" placeholder="请输入IP地址" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">&nbsp;</label>
                                        </div>
                                        <div class="col-sm-8">
                                           
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">&nbsp;</label>
                                        </div>
                                        <div class="col-sm-8">
                                        </div>
                                    </div>
                                </div>

                                   <div class="col-sm-12 text_style">
                                    <div class="col-sm-1 no-padding-right text-right">
                                        <label>学段及年级:</label>
                                    </div>
                                    <div class="col-sm-11">
                                        <div class="row">
                                            <div class="col-sm-2">
                                                <label><span class="no-margin-bottom color">学段：</span></label>&nbsp&nbsp
                                                    <label>
                                                        <input name="gradechkl" type="checkbox" class="ace" value="1">
                                                        <span class="lbl">幼儿园</span>
                                                    </label>
                                            </div>
                                            <div class="col-sm-10">
                                                <div class="col-sm-1 text-right nianji">
                                                    <label><span class=" color">年级：</span></label>
                                                </div>
                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="1001">
                                                        <span class="lbl">小小班</span>
                                                    </label>
                                                </div>
                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="1002">
                                                        <span class="lbl">小班</span>
                                                    </label>
                                                </div>
                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="1003">
                                                        <span class="lbl">中班</span>
                                                    </label>
                                                </div>
                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="1004">
                                                        <span class="lbl">大班</span>
                                                    </label>
                                                </div>
                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="1005">
                                                        <span class="lbl">学前班</span>
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                        <%--<div class="space-4"></div>--%>
                                        <div class="row">
                                            <div class="col-sm-2">
                                                <label><span class="color">学段：</span></label>&nbsp&nbsp
                                                    <label>
                                                        <input name="gradechkl" type="checkbox" class="ace" value="2">
                                                        <span class="lbl">小学</span>
                                                    </label>
                                            </div>
                                            <div class="col-sm-10">
                                                <div class="col-sm-1 text-right nianji ">
                                                    <label><span class=" color">年级：</span></label>
                                                </div>
                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="2001">
                                                        <span class="lbl">一年级</span>
                                                    </label>
                                                </div>
                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="2002">
                                                        <span class="lbl">二年级</span>
                                                    </label>
                                                </div>
                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="2003">
                                                        <span class="lbl">三年级</span>
                                                    </label>
                                                </div>
                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="2004">
                                                        <span class="lbl">四年级</span>
                                                    </label>
                                                </div>
                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="2005">
                                                        <span class="lbl">五年级</span>
                                                    </label>
                                                </div>

                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="2006">
                                                        <span class="lbl">六年级</span>
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- <div class="space-4"></div>--%>
                                        <div class="row">
                                            <div class="col-sm-2">
                                                <label><span class=" color">学段：</span></label>&nbsp&nbsp
                                                    <label>
                                                        <input name="gradechkl" type="checkbox" class="ace" value="3">
                                                        <span class="lbl">初中</span>
                                                    </label>
                                            </div>
                                            <div class="col-sm-10">
                                                <div class="col-sm-1 text-right nianji ">
                                                    <label><span class="color">年级：</span></label>
                                                </div>
                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="3001">
                                                        <span class="lbl">初一</span>
                                                    </label>
                                                </div>
                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="3002">
                                                        <span class="lbl">初二</span>
                                                    </label>
                                                </div>
                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="3003">
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
                                        <%--<div class="space-4"></div>--%>
                                        <div class="row">
                                            <div class="col-sm-2">
                                                <label><span class=" color">学段：</span></label>&nbsp&nbsp
                                                    <label>
                                                        <input name="gradechkl" type="checkbox" class="ace" value="4">
                                                        <span class="lbl">高中</span>
                                                    </label>
                                            </div>
                                            <div class="col-sm-10">
                                                <div class="col-sm-1 text-right nianji">
                                                    <label><span class=" color">年级：</span></label>
                                                </div>
                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="4001">
                                                        <span class="lbl">高一</span>
                                                    </label>
                                                </div>
                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="4002">
                                                        <span class="lbl">高二</span>
                                                    </label>
                                                </div>
                                                <div class="col-sm-1">
                                                    <label>
                                                        <input name="gradechk" type="checkbox" class="ace" value="4003">
                                                        <span class="lbl">高三</span>
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                       <br />
                                </div>





                                <br />
                                <br />
                                <div class=" form-inline lheight">
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right  text-right">
                                            <label class="biaoti">创建时间:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <input type="text" id="Text2" placeholder="请输入创建时间" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">启用时间:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <input type="text" id="Text3" placeholder="请输入启用时间"   readonly="readonly" class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">到期时间:</label>
                                        </div>
                                        <div class="col-sm-8">
                                            <input type="text" id="Text5" placeholder="请输入到期时间" readonly="readonly"  class="col-xs-12 col-sm-12" />
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="col-sm-4 no-padding-right text-right">
                                            <label class="biaoti">&nbsp;</label>
                                        </div>
                                        <div class="col-sm-8">
                                            
                                        </div>
                                    </div>
                                </div>
                                  <div class=" form-inline lheight">
                                    <div class="row">
                                        <div class="col-sm-12 text_style">
                                            <div class="col-sm-1 no-padding-right text-right ">
                                                <label>子系统:</label>
                                            </div>
                                            <div class="col-sm-8">
                                                <select id="Select1" multiple>
                                                </select>
                                                <br />
                                                <div class="btn-group text-right">
                                                    <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle button_bg text_size">
                                                        选择子系统
													<i class="icon-caret-down icon-on-right"></i>
                                                    </button>
                                                    <ul id="Ul1" class="dropdown-menu ztree ">
                                                        <li>222</li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <br />
                                 <div class=" form-inline lheight">
                                    <div class="row">
                                        <div class="col-sm-1 no-padding-right text-right ">
                                            <label>子系统状态:</label>
                                        </div>
                                        <div class="col-sm-2">
                                            <input type="text" readonly="readonly" style="border:none" value="待启用" class="col-xs-5 col-sm-5"  />
                                        </div>
                                    </div>
                                </div> 
                            </form>
                            <!-- PAGE CONTENT ENDS -->
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
    <script src="../../assets/js/bootstrap-select.js"></script>
    <script src="../../assets/js/bootstrap-tagsinput.js"></script>
    <script src="../../assets/js/jquery.ztree.all-3.5.min.js"></script>
    <script src="../../assets/js/i18n/defaults-zh_CN.min.js"></script>
    <script src="../../assets/js/learunui-validator.js"></script>
    <script src="../../assets/js/bootbox.min.js"></script>

</body>
</html>

<script type="text/javascript"> 
</script>
