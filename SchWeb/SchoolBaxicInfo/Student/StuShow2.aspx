<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuShow2.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.Student.StuShow2" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>学生详情</title>
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
        .page-content {
            padding:0px;
        }
        .widget-box {
            margin:0px;
            border:0px;
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
        .header {
        margin-top:0px;
        vertical-align:text-bottom;
        }
        .header.blue {
        }
        strong {
            margin-right:15px;
            font-size:14px;
            color:#393939;
        }
        .widget-body {
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
                            目前位置：学生/家长及账号信息
                        </li>
                        <%--<li>
                            <a href="#">学校管理</a>
                        </li>--%>
                        <%--将学校信息改为学校及科目信息--%>
                        <li class="active">显示学生信息 </li>
                    </ul>
                    <!-- .breadcrumb -->
                    <div class="nav-search" id="nav-search">
                            <a class=" pull-right " href="javascript:window.history.go(-1);">
                                <i class="icon-reply icon-only"></i>
                                返回
                            </a>
                        </div>

                </div>
                <div class="page-content">
                    <div class="widget-box">
                        <div class="widget-body">
                            <div class="widget-main">
                                <h4 class="header smaller lighter blue">年级班级</h4>
                                <div class="row">
                                   <div class="col-sm-3"><strong>年级名称:</strong><%=stugrade %></div><div class="col-sm-9"><strong>年级领导:</strong><%=stugradeboss %></div>
                                    
                                </div>
                                <div class="space-4"></div>
                                <div class="row">
                                    <div class="col-sm-3"><strong>班级名称:</strong><%=stuclass %></div><div class="col-sm-3"><strong>班&nbsp;&nbsp;主&nbsp; 任:</strong><%=stuclassms %></div><div class="col-sm-6"><strong>任课老师:</strong><%=stuclasstec %></div>
                                </div>
                                <div class="space-8"></div>
                                <h4 class="header smaller lighter blue">个人信息</h4>
                                <div class="row">
                                   <div class="col-sm-3"><strong>学生姓名:</strong><%=stuname %></div><div class="col-sm-3"><strong>系统编号:</strong><%=stuid %></div><div class="col-sm-3"><strong>学/考&nbsp;&nbsp;号:</strong><%=stucode %></div>
                                    <div class="col-sm-3"><strong>性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 别:</strong><%=stusex %></div>
                                </div>
                                <div class="space-4"></div>
                                <div class="row">
                                    <div class="col-sm-3"><strong>手&nbsp;&nbsp;机&nbsp;号:</strong><%=stutel %></div>
                                    <div class="col-sm-3"><strong>是否走读:</strong><%=stustp %></div><div class="col-sm-3"><strong>卡&nbsp;&nbsp;地&nbsp;址:</strong><%=stucard %></div><div class="col-sm-3"><strong>原班级:</strong><%=stuocls %></div>
                                </div>
                                <div class="space-4"></div>
                                <div class="row">
                                    <div class="col-sm-12"><strong>住&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址:</strong><%=stuaddr %></div>                                    
                                </div>
                                <div class="space-8"></div>
                                
                                <h4 class="header smaller lighter blue">家长信息</h4>
                                <div class="row">
                                   <div class="col-sm-3"><strong>姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名:</strong><%=stug1name %></div><div class="col-sm-3"><strong>关&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;系:</strong><%=stug1rl %></div>
                                    <div class="col-sm-3"><strong>电&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;话:</strong><%=stug1rt %></div><div class="col-sm-3"><strong></strong></div>
                                </div>
                                <div class="space-4"></div>
                                <div class="row">
                                    <div class="col-sm-3"><strong>姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名:</strong><%=stug2name %></div><div class="col-sm-3"><strong>关&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;系:</strong><%=stug2rl %></div>
                                    <div class="col-sm-3"><strong>电&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;话:</strong><%=stug2rt %></div><div class="col-sm-3"><strong></strong></div>
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
    <script type="text/javascript">
        
        
    </script>
</body>
</html>
