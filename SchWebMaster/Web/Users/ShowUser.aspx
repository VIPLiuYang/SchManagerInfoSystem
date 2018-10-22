<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowUser.aspx.cs" Inherits="SchWebMaster.Web.Users.ShowUser" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>用户信息详细</title>
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
    <style>
        .widget-box {
            border-bottom:0px;
        }
        .row {
            border-bottom: 1px dotted #e4e4e4;
            margin:0px;
            font-size:14px;
            color:#999999;
        }
        .widget-main {
    padding: 12px 12px 24px 12px;
    /*border:0px;*/
}
        .widget-body {
        border:0px;
        }
        .header {
        margin-top:0px;
        vertical-align:text-bottom;
        }
        strong {
            margin-right:15px;
            font-size:14px;
            color:#393939;
        }
        .page-content {
            padding:0px;
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
                                <h4 class="header smaller lighter blue">个人信息</h4>
                                <div class="row">
                                    <div class="col-sm-3"><strong>老师姓名:</strong><%=utname %></div>
                                    <div class="col-sm-3"><strong>系统编号:</strong><%=uid %></div>
                                    <div class="col-sm-3"><strong>性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 别:</strong><%=usex %></div>
                                    <div class="col-sm-3"><strong>职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 务:</strong><%=ujb %></div>
                                </div>
                                <div class="space-4"></div>
                                <div class="row">
                                    <div class="col-sm-3"><strong>职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 称:</strong><%=ups %></div>
                                    <div class="col-sm-3"><strong>联系方式:</strong><%=utl %></div>
                                    <div class="col-sm-3"><strong>账&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 号:</strong><%=uname %></div>
                                    <div class="col-sm-3"><strong><%=upwname %></strong><%=upw %></div>
                                </div>
                                <div class="space-4"></div>
                                <div class="row">
                                    <div class="col-sm-3"><strong>账号状态:</strong><%=ustat %></div>
                                    <div class="col-sm-9"><strong>所在部门:</strong><%=udpts %></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.page-content -->
            </div>
            <!-- /.main-content -->
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
    <script src="../../assets/js/jsencrypt.min.js"></script>
    <script type="text/javascript">
        
        
    </script>
    <style type="text/css">
        .nobg {
            height: 28px;
            line-height: 28px;
            background-color: #abbac3!important;
        }
    </style>
</body>
</html>
