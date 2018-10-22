<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysSchbasicInfo.aspx.cs" Inherits="SchWebAdmin.Web.SysSchbasic.SysSchbasicInfo" %>

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
        * {
            font-family: "微软雅黑" !important;
        }

        i {
            font-family: FontAwesome !important;
        }

        .table thead > tr > th, .table tbody > tr > td {
            text-align: center;
        }

        .pagination {
            border-top: 1px solid #DDD;
            padding-top: 12px;
            padding-bottom: 12px;
            background-color: #eff3f8;
        }

        .page-content {
            padding: 0px;
        }
        .tab-content {        
        padding: 0px;
        border-width:1px 0px 0px 0px;
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
                        <li>目前位置：
                        </li>
                        <li class="active">基础信息</li>
                    </ul>
                </div>
                <div class="page-content">
                    <ul class="nav nav-tabs" id="myTab">
                        <li id="mr"><a href="#SysPer" data-toggle="tab" onclick="clickiframe('SysPer','SysPer.aspx')">学段维护</a></li>
                        <li><a href="#SysColl" data-toggle="tab" onclick="clickiframe('SysColl','SysColl.aspx')">院系维护</a></li>
                        <li><a href="#SysMajor" data-toggle="tab" onclick="clickiframe('SysMajor','SysMajor.aspx')">专业维护</a></li>
                        <li><a href="#SysSub" data-toggle="tab" onclick="clickiframe('SysSub','SysSub.aspx')">科目维护</a></li>
                        <li><a href="#SysMater" data-toggle="tab" onclick="clickiframe('SysMater','SysMater.aspx')">教版维护</a></li>
                        <li><a href="#SysFasc" data-toggle="tab" onclick="clickiframe('SysFasc','SysFasc.aspx')">教材分册维护</a></li>
                        <li><a href="#SysTerm" data-toggle="tab" onclick="clickiframe('SysTerm','SysTerm.aspx')">季期维护</a></li>
                        <li><a href="#ServSysNape" data-toggle="tab" onclick="clickiframe('ServSysNape','ServSysNape.aspx')">计费系统附加信息维护</a></li>
                        <li><a href="#SysUType" data-toggle="tab" onclick="clickiframe('SysUType','SysUType.aspx')">计费系统角色维护</a></li>
                        <li><a href="#SysArts" data-toggle="tab" onclick="clickiframe('SysArts','SysArts.aspx')">分科维护</a></li>
                    </ul>
                    <div class="tab-content">
                        <!------------------------------------------------------------学段维护----------------------------------------------------------------------------------------------->
                        <!--默认选择home active-->
                        <div class="tab-pane active" id="SysPer">
                        </div>
                        <!------------------------------------------------------------科目维护----------------------------------------------------------------------------------------------->
                        <div id="SysColl" class="tab-pane">
                        </div>
                        <!------------------------------------------------------------科目维护----------------------------------------------------------------------------------------------->
                        <div id="SysMajor" class="tab-pane">
                        </div>
                        <!------------------------------------------------------------科目维护----------------------------------------------------------------------------------------------->
                        <div id="SysSub" class="tab-pane">
                        </div>
                        <!------------------------------------------------------------教版维护----------------------------------------------------------------------------------------------->
                        <div id="SysMater" class="tab-pane">
                        </div>
                        <!------------------------------------------------------------教材分册维护----------------------------------------------------------------------------------------------->
                        <div id="SysFasc" class="tab-pane">
                        </div>
                        <!------------------------------------------------------------季期维护----------------------------------------------------------------------------------------------->
                        <div id="SysTerm" class="tab-pane">
                        </div>
                        <!------------------------------------------------------------计费系统附加信息维护----------------------------------------------------------------------------------------------->
                        <div id="ServSysNape" class="tab-pane">
                        </div>

                        <!------------------------------------------------------------计费系统角色维护----------------------------------------------------------------------------------------------->
                        <div id="SysUType" class="tab-pane">
                        </div>
                        <!------------------------------------------------------------分科维护----------------------------------------------------------------------------------------------->
                        <div id="SysArts" class="tab-pane">
                        </div>


                        <iframe class="content" name="iframe1" id="iframe1" style="width: 100%;" frameborder="no" border="0" marginwidth="0" marginheight="0" src="SysPer.aspx" frameborder="0" ></iframe>
                        <script type="text/javascript">
                            function reinitIframe() {
                                var iframe = document.getElementById("iframe1");
                                try {
                                    var bHeight = iframe.contentWindow.document.body.scrollHeight;
                                    //var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
                                    //var dHeight = iframe.contentWindow.document.getElementsByClassName('main-container')[0].scrollHeight;
                                    //var ddd = $("html")[0].scrollHeight;
                                    var dHeight = iframe.contentWindow.document.getElementsByClassName('main-container')[0].scrollHeight;
                                    if (dHeight < 300)
                                    {
                                        dHeight = dHeight + 200;
                                    }
                                    //var dHeight = iframe.contentWindow.document.getElementsByClassName('main-container')[0].height();
                                    //var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
                                    var height = Math.max(bHeight, dHeight);
                                    iframe.height = height;
                                    //console.log(height);
                                } catch (ex) { }
                            }
                            window.setInterval("reinitIframe()", 200);
                            window.onresize = function () {
                                reinitIframe();
                            }
                            </script>
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
    $('#myTab li:eq(0) a').tab('show');// 选取第1个标签页（从 0 开始索引）。 
    var PageIndex = 1;
    var PageSize = 20;
    var pageCount = 1;
    /*启用选项卡*/
    $("#myTab a").click(function (e) {
        e.preventDefault();/*不要执行与事件有关的默认动作*/
        $(this).tab('show');
    })

    function clickiframe(id, dz) {
        $('#iframe1').attr("src",dz);
    }


</script>
