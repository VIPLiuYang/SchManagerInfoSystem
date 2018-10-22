  <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SchWebServ.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=utitlename %></title>
    <meta name="keywords" content="<%=utitlename %>" />
    <meta name="description" content="<%=utitlename %>" />
    <!-- basic styles -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/css/font-awesome.min.css" />

    <!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

    <!-- page specific plugin styles -->

    <!-- fonts -->


    <!-- ace styles -->

    <link rel="stylesheet" href="assets/css/ace.min.css" />
    <link rel="stylesheet" href="assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="assets/css/ace-skins.min.css" />

    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->

    <!-- inline styles related to this page -->

    <!-- ace settings handler -->

    <script src="assets/js/ace-extra.min.js"></script>

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

    <!--[if lt IE 9]>
		<script src="assets/js/html5shiv.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
    <style>
         /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }
         
        /*定义字体*/
        i {
            font-family: FontAwesome !important;
        }
        /*顶部导航条背景*/
        .nav_bg {
            background: #3c9bfe;
        }
        /*系统管理隐藏*/
        .hide {
            display: none;
        }
        /*去掉个人设置所在的li标签的背景边框*/
        .Set_box {
            background: none !important;
            border: none !important;
        }
        /*去掉个人设置所在的a标签的背景*/
        .set_bg {
            background: none !important;
            padding: 0px 20px !important;
        }

        /*去掉个人设置所在的span标签的背景*/
        .text_bg {
            background: none !important;
        }
        /*个人设置的上下边距*/
        .text_jianju {
            top: 0px !important;
            padding-top: 3px !important;
        }
        /*内容区域所在的容器背景*/
        .content_bg {
            background: white;
            padding-top: 0px;
            padding-bottom: 0px;
        }
        /*内容区域的最小高度和去掉边框*/
        .content {
            border: none;
            /*min-height: 980px;*/
            min-height: 800px;
        }
        /*将右边的设置悬浮按钮去掉；将左边的上方四个设置按钮去掉*/
        .hide {
            display: none;
        }
        /*左边导航栏字号*/
        .nav-list > li > a > span {
            font-family: 微软雅黑;
            font-size: 14px !important;
            color: #000000;
        }
        /*点击后个人设置的背景*/
        .ace-nav > li.open.green > a {
            background: rgba(32, 121, 238, 1) !important;
        }
        /*鼠标移动到顶部菜单栏上是背景颜色*/
        .ace-nav > li > a:hover {
            background: #579ec8 !important;
        }
        /*顶部导航栏的字体样式*/
        .ziti {
            font-family: 微软雅黑;
            font-size: 13px;
        }
        /*头像大小*/
        .ace-nav .nav-user-photo {
            max-width: 30px;
        }
        /*个人设置弹出框的最小宽度*/
        .dropdown-menu {
            min-width: 128px;
            left: 15px !important;
        }
            /*跟人设置弹出框位置*/
            .dropdown-menu.dropdown-close {
                left: 0px;
            }
        /*个人设置弹出框的字体颜色*/
        .text_color {
            font-family: 微软雅黑;
            font-size: 12px !important;
            color: #666666 !important;
        }
        /*左上角的大标题智慧XXXXX*/
        .navtitle {
            font-family: 微软雅黑;
            letter-spacing: 1px;
            font-weight: bold;
        }
        /*导航栏的栏目间距*/
        .nav-list > li > a {
            height: 34px;
            line-height: 32px;
        }

        /*二级菜单的高度大小字体*/
        .nav-list > li .submenu > li > a {
            height: 30px;
            line-height: 16px;
            font-family: 微软雅黑;
            font-size: 13px;
            color: #666666;
        }
        /*二级菜单图标的位置*/
        .nav-list > li .submenu > li a > [class*="icon-"]:first-child {
            left: 32px;
        }
        /*个人设置弹出框的样式*/
        .dropdown-menu .divider {
            margin: 0;
        }
        /*选中时span标签中的内容变化*/
        .nav-list > li.active > a > span {
            color: #2b7dbc;
        }

        .nav-list > li > a:hover > span {
            color: #1963aa;
        }

        .main-container {
            margin-top: 45px!important;
        }

        .fixed {
            position: fixed;
            top: 45px;
            left: 0;
        }
        /*上传头像所在的li的左边距*/
        .p-left {
            padding-left: 2px;
        }
        /*Chrome(谷歌)浏览器识别
        @media screen and (-webkit-min-device-pixel-ratio:0){.main-container{margin-top:45px;}}*/
        /* 仅firefox 识别 
        @-moz-document .main-container{margin-top:45px;}*/
        /*.page-content.content_bg.no-padding-right {
            background: #fff;
        }*/
        .sidebar{
            width: 245px;
        }
        .sidebar:before {
            width: 245px;
        }
        .main-content {
            margin-left: 257px;
        }
        .page-content {
            padding:0px;
        }
        .nav-list > li > .submenu li > .submenu > li > a {
            padding-left: 46px;
        }
        .col-xs-12 {
            width: 99%;
        }
    </style>
    <style type="text/css">
        /*#navbar {
                position: fixed;
                width:100%;
            }
            #sidebar {
                position: fixed;
                top: 45px;
            }
            #indexmain {
                margin-top:45px;
            }*/
    </style>
</head>
<body ontouchstart>
    <div class="navbar navbar-default nav_bg navbar-fixed-top" id="navbar">
        <script type="text/javascript">
            try { ace.settings.check('navbar', 'fixed') } catch (e) { }
        </script>

        <div class="navbar-container" id="navbar-container">
            <div class="navbar-header pull-left">
                <a href="#" class="navbar-brand ">
                    <small class="navtitle">
                        <i class="icon-leaf"></i>
                        <%=utitlename %>
                         <!--<span id="PlatformIco"></span>
                        <span id="PlatformName"></span>-->
                    </small>
                </a>
                <!-- /.brand -->
            </div>
            <!-- /.navbar-header -->

            <div class="navbar-header pull-right" role="navigation">
                <ul class="nav ace-nav">
                    <li class="grey hide">
                        <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                            <i class="icon-tasks"></i>
                            <span class="badge badge-grey">系统管理</span>
                        </a></li>
                    <li class="light-blue Set_box">
                        <a data-toggle="dropdown" href="#" class="dropdown-toggle set_bg">
                            <!--<img class="nav-user-photo" src="assets/avatars/user.jpg" alt="Jason's Photo" />-->
                            <span class="user-info" style="line-height: 30px; max-width: none;">
                                <small class="ziti" style="display: inline;">登录账号：</small>
                                <span id="UserName" class="ziti" style="display: inline;"><%=uname %></span>
                            </span>

                            <%--<i class="icon-caret-down"></i>--%>
                        </a>
                        <%--将头像下的弹出框隐藏--%>
                        <%-- <ul class="user-menu pull-right dropdown-menu dropdown-yellow dropdown-caret dropdown-close">
                            <li>
                                <a href="#">
                                    <i class="icon-cog"></i>
                                    设置
                                </a>
                            </li>

                            <li>
                                <a href="#">
                                    <i class="icon-user"></i>
                                    个人资料
                                </a>
                            </li>

                            <li class="divider"></li>
                            
                            <li>
                                <a href="javascript:void();" onclick="LoginOut()">
                                    <i class="icon-off"></i>
                                    退出
                                </a>
                            </li>
                        </ul>--%>
                    </li>
                    <li class="green Set_box ">
                        <a data-toggle="dropdown" class="dropdown-toggle set_bg" href="#">
                            <!--<i class="icon-tasks"></i>-->
                            <img class="nav-user-photo no-margin-right" src="<%=imgurl %>" id="userpicture" alt="Jason's Photo" />
                            <span class="badge badge-grey text_bg  text_jianju ziti no-padding-right no-padding-left"><%=usertname %></span>
                            <i class="icon-caret-down"></i>
                        </a>
                        <%--  弹出框--%>
                        <ul class="user-menu  dropdown-menu dropdown-yellow dropdown-caret dropdown-close ">
                            <li class="p-left">
                               <a href="<%=UploadHeadPic %>" target="iframe0" class="text_color">
                                    <i class="icon-user" style="margin-right:10px;"></i>上传头像
                                </a>
                            </li>
                            <li class="divider"></li>
                            <li>
                                <a href="./UserPwdEdit.aspx" target="iframe0" class="text_color">
                                    <i class="icon-cog" style="margin-right: 8px;"></i>修改密码
                                </a>
                            </li>

                        </ul>
                    </li>

                    <%-- 添加退出按钮--%>
                    <li class="Set_box ">
                        <a href="javascript:void();" onclick="LoginOut();" class="set_bg ziti">
                            <i class="icon-off"></i>
                            退出
                        </a>
                    </li>
                </ul>
                <!-- /.ace-nav -->
            </div>
            <!-- /.navbar-header -->
        </div>
        <!-- /.container -->
    </div>

    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>

        <div class="main-container-inner">
            <a class="menu-toggler" id="menu-toggler" href="#">
                <span class="menu-text"></span>
            </a>

            <div class="sidebar" id="sidebar">
                <script type="text/javascript">
                    try { ace.settings.check('sidebar', 'fixed') } catch (e) { }
                </script>

                <div class="sidebar-shortcuts hide" id="sidebar-shortcuts">
                    <div class="sidebar-shortcuts-large" id="sidebar-shortcuts-large">
                        <button class="btn btn-success">
                            <i class="icon-signal"></i>
                        </button>

                        <button class="btn btn-info">
                            <i class="icon-pencil"></i>
                        </button>

                        <button class="btn btn-warning">
                            <i class="icon-group"></i>
                        </button>

                        <button class="btn btn-danger">
                            <i class="icon-cogs"></i>
                        </button>
                    </div>

                    <div class="sidebar-shortcuts-mini" id="sidebar-shortcuts-mini">
                        <span class="btn btn-success"></span>

                        <span class="btn btn-info"></span>

                        <span class="btn btn-warning"></span>

                        <span class="btn btn-danger"></span>
                    </div>
                </div>
                <!-- #sidebar-shortcuts -->

                <ul class="nav nav-list">
                    <%=treestr %>
                </ul>
                <!-- /.nav-list -->

                <div class="sidebar-collapse" id="sidebar-collapse">
                    <i class="icon-double-angle-left" data-icon1="icon-double-angle-left" data-icon2="icon-double-angle-right"></i>
                </div>

                <script type="text/javascript">
                    try { ace.settings.check('sidebar', 'collapsed') } catch (e) { }
                </script>
            </div>

            <div class="main-content">
                <div class="page-content content_bg no-padding-right">
                    <div class="row">
                        <div class="col-xs-12 no-padding-right" id="indexmain">
                            <iframe class="content" name="iframe0" id="iframe0" style="width: 100%;" frameborder="no" border="0" marginwidth="0" marginheight="0" src="<%=indexpage %>" frameborder="0" ></iframe>
                            <script type="text/javascript">
                                function reinitIframe() {
                                    var iframe = document.getElementById("iframe0");
                                    try {
                                        var bHeight = iframe.contentWindow.document.body.scrollHeight;
                                        //var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
                                        //var dHeight = iframe.contentWindow.document.getElementsByClassName('main-container')[0].scrollHeight;
                                        var dHeight = document.getElementsByClassName('main-container')[0].height();
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
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.page-content -->
            </div>
            <!-- /.page-content -->
            <!-- /.main-content -->

            <div class="ace-settings-container hide" id="ace-settings-container">
                <div class="btn btn-app btn-xs btn-warning ace-settings-btn" id="ace-settings-btn">
                    <i class="icon-cog bigger-150"></i>
                </div>

                <div class="ace-settings-box" id="ace-settings-box">
                    <div>
                        <div class="pull-left">
                            <select id="skin-colorpicker" class="hide">
                                <option data-skin="default" value="#438EB9">#438EB9</option>
                                <option data-skin="skin-1" value="#222A2D">#222A2D</option>
                                <option data-skin="skin-2" value="#C6487E">#C6487E</option>
                                <option data-skin="skin-3" value="#D0D0D0">#D0D0D0</option>
                            </select>
                        </div>
                        <span>&nbsp; 选择皮肤</span>
                    </div>

                    <div>
                        <input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-navbar" />
                        <label class="lbl" for="ace-settings-navbar">固定导航条</label>
                    </div>

                    <div>
                        <input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-sidebar" />
                        <label class="lbl" for="ace-settings-sidebar">固定滑动条</label>
                    </div>

                    <div>
                        <input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-breadcrumbs" />
                        <label class="lbl" for="ace-settings-breadcrumbs">固定面包屑</label>
                    </div>

                    <div>
                        <input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-rtl" />
                        <label class="lbl" for="ace-settings-rtl">切换到左边</label>
                    </div>

                    <div>
                        <input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-add-container" />
                        <label class="lbl" for="ace-settings-add-container">
                            切换窄屏
								<b></b>
                        </label>
                    </div>
                </div>
            </div>
            <!-- /#ace-settings-container -->
        </div>
        <!-- /.main-container-inner -->

        <a href="#" id="btn-scroll-up" class="btn-scroll-up btn btn-sm btn-inverse">
            <i class="icon-double-angle-up icon-only bigger-110"></i>
        </a>
    </div>
    <!-- /.main-container -->

    <!-- basic scripts -->

    <!--[if !IE]> -->

    <script src="assets/js/jquery-2.0.3.min.js"></script>

    <!-- <![endif]-->

    <!--[if IE]>

<![endif]-->

    <!--[if !IE]> -->

    <script type="text/javascript">
        window.jQuery || document.write("<script src='assets/js/jquery-2.0.3.min.js'>" + "<" + "script>");
    </script>

    <!-- <![endif]-->

    <!--[if IE]>
<script type="text/javascript">
 window.jQuery || document.write("<script src='assets/js/jquery-1.10.2.min.js'>"+"<"+"script>");
</script>
<![endif]-->

    <%--    <script type="text/javascript">
        if ("ontouchend" in document) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "script>");
    </script>--%>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/typeahead-bs2.min.js"></script>

    <!-- page specific plugin scripts -->

    <!--[if lte IE 8]>
		  <script src="assets/js/excanvas.min.js"></script>
		<![endif]-->

    <script src="assets/js/jquery-ui-1.10.3.custom.min.js"></script>
    <script src="assets/js/jquery.ui.touch-punch.min.js"></script>
    <script src="assets/js/jquery.slimscroll.min.js"></script>
    <script src="assets/js/jquery.easy-pie-chart.min.js"></script>
    <script src="assets/js/jquery.sparkline.min.js"></script>
    <script src="assets/js/flot/jquery.flot.min.js"></script>
    <script src="assets/js/flot/jquery.flot.pie.min.js"></script>
    <script src="assets/js/flot/jquery.flot.resize.min.js"></script>

    <!-- ace scripts -->

    <script src="assets/js/ace-elements.min.js"></script>
    <script src="assets/js/ace.min.js"></script>

    <!-- inline scripts related to this page -->

    <script type="text/javascript">

        jQuery(function ($) {
            $('.easy-pie-chart.percentage').each(function () {
                var $box = $(this).closest('.infobox');
                var barColor = $(this).data('color') || (!$box.hasClass('infobox-dark') ? $box.css('color') : 'rgba(255,255,255,0.95)');
                var trackColor = barColor == 'rgba(255,255,255,0.95)' ? 'rgba(255,255,255,0.25)' : '#E2E2E2';
                var size = parseInt($(this).data('size')) || 50;
                $(this).easyPieChart({
                    barColor: barColor,
                    trackColor: trackColor,
                    scaleColor: false,
                    lineCap: 'butt',
                    lineWidth: parseInt(size / 10),
                    animate: /msie\s*(8|7|6)/.test(navigator.userAgent.toLowerCase()) ? false : 1000,
                    size: size
                });
            })

            $('.sparkline').each(function () {
                var $box = $(this).closest('.infobox');
                var barColor = !$box.hasClass('infobox-dark') ? $box.css('color') : '#FFF';
                $(this).sparkline('html', { tagValuesAttribute: 'data-values', type: 'bar', barColor: barColor, chartRangeMin: $(this).data('min') || 0 });
            });




            var placeholder = $('#piechart-placeholder').css({ 'width': '90%', 'min-height': '150px' });
            var data = [
              { label: "social networks", data: 38.7, color: "#68BC31" },
              { label: "search engines", data: 24.5, color: "#2091CF" },
              { label: "ad campaigns", data: 8.2, color: "#AF4E96" },
              { label: "direct traffic", data: 18.6, color: "#DA5430" },
              { label: "other", data: 10, color: "#FEE074" }
            ]
            function drawPieChart(placeholder, data, position) {
                $.plot(placeholder, data, {
                    series: {
                        pie: {
                            show: true,
                            tilt: 0.8,
                            highlight: {
                                opacity: 0.25
                            },
                            stroke: {
                                color: '#fff',
                                width: 2
                            },
                            startAngle: 2
                        }
                    },
                    legend: {
                        show: true,
                        position: position || "ne",
                        labelBoxBorderColor: null,
                        margin: [-30, 15]
                    }
                  ,
                    grid: {
                        hoverable: true,
                        clickable: true
                    }
                })
            }
            drawPieChart(placeholder, data);

            /**
            we saved the drawing function and the data to redraw with different position later when switching to RTL mode dynamically
            so that's not needed actually.
            */
            placeholder.data('chart', data);
            placeholder.data('draw', drawPieChart);



            var $tooltip = $("<div class='tooltip top in'><div class='tooltip-inner'></div></div>").hide().appendTo('body');
            var previousPoint = null;

            placeholder.on('plothover', function (event, pos, item) {
                if (item) {
                    if (previousPoint != item.seriesIndex) {
                        previousPoint = item.seriesIndex;
                        var tip = item.series['label'] + " : " + item.series['percent'] + '%';
                        $tooltip.show().children(0).text(tip);
                    }
                    $tooltip.css({ top: pos.pageY + 10, left: pos.pageX + 10 });
                } else {
                    $tooltip.hide();
                    previousPoint = null;
                }

            });






            var d1 = [];
            for (var i = 0; i < Math.PI * 2; i += 0.5) {
                d1.push([i, Math.sin(i)]);
            }

            var d2 = [];
            for (var i = 0; i < Math.PI * 2; i += 0.5) {
                d2.push([i, Math.cos(i)]);
            }

            var d3 = [];
            for (var i = 0; i < Math.PI * 2; i += 0.2) {
                d3.push([i, Math.tan(i)]);
            }


            var sales_charts = $('#sales-charts').css({ 'width': '100%', 'height': '220px' });
            $.plot("#sales-charts", [
                { label: "Domains", data: d1 },
                { label: "Hosting", data: d2 },
                { label: "Services", data: d3 }
            ], {
                hoverable: true,
                shadowSize: 0,
                series: {
                    lines: { show: true },
                    points: { show: true }
                },
                xaxis: {
                    tickLength: 0
                },
                yaxis: {
                    ticks: 10,
                    min: -2,
                    max: 2,
                    tickDecimals: 3
                },
                grid: {
                    backgroundColor: { colors: ["#fff", "#fff"] },
                    borderWidth: 1,
                    borderColor: '#555'
                }
            });


            $('#recent-box [data-rel="tooltip"]').tooltip({ placement: tooltip_placement });
            function tooltip_placement(context, source) {
                var $source = $(source);
                var $parent = $source.closest('.tab-content')
                var off1 = $parent.offset();
                var w1 = $parent.width();

                var off2 = $source.offset();
                var w2 = $source.width();

                if (parseInt(off2.left) < parseInt(off1.left) + parseInt(w1 / 2)) return 'right';
                return 'left';
            }


            $('.dialogs,.comments').slimScroll({
                height: '300px'
            });


            //Android's default browser somehow is confused when tapping on label which will lead to dragging the task
            //so disable dragging when clicking on label
            var agent = navigator.userAgent.toLowerCase();
            if ("ontouchstart" in document && /applewebkit/.test(agent) && /android/.test(agent))
                $('#tasks').on('touchstart', function (e) {
                    var li = $(e.target).closest('#tasks li');
                    if (li.length == 0) return;
                    var label = li.find('label.inline').get(0);
                    if (label == e.target || $.contains(label, e.target)) e.stopImmediatePropagation();
                });

            $('#tasks').sortable({
                opacity: 0.8,
                revert: true,
                forceHelperSize: true,
                placeholder: 'draggable-placeholder',
                forcePlaceholderSize: true,
                tolerance: 'pointer',
                stop: function (event, ui) {//just for Chrome!!!! so that dropdowns on items don't appear below other items after being moved
                    $(ui.item).css('z-index', 'auto');
                }
            }
            );
            $('#tasks').disableSelection();
            $('#tasks input:checkbox').removeAttr('checked').on('click', function () {
                if (this.checked) $(this).closest('li').addClass('selected');
                else $(this).closest('li').removeClass('selected');
            });

        });
        $('.atg').click(function () {
            $('.atg').removeClass("active");
            $(this).addClass("active");
            $("#sidebar").removeClass("display");
        });
        var $sidebar = $("#sidebar");
        var offset = $sidebar.offset();
        $(window).scroll(function () {
            var scrollTop = $(window).scrollTop();
            if (offset.top < scrollTop) {
                $sidebar.addClass("fixed");
            } else {
                $sidebar.removeClass("fixed");
            }
        });


    </script>
</body>
</html>
<script type="text/javascript">
    
    var utitlename = "<%=utitlename %>";
    
    $(window).load(function () {
        var h = $(window).height();//获取页面的高度
        document.getElementById("iframe0").style.height = h * 0.94 + "px";//设置iframe根据显示屏自适应高度。iframe高度是根据显示屏高度的94%，防止出现滚动条。
    });
</script>
<script type="text/javascript" src="assets/js/jquery.cookie.js"></script>
<script type="text/javascript">
    $(window).load(function () {
        var skins = '<%=uskin%>';
        $('#skin-colorpicker').val(skins);
        $("#skin-colorpicker option").each(function () {
            if ($(this).val() == skins) {
                $(this).attr("selected", true);
            }
            else {
                $(this).removeAttr("selected");
            }

        });
        $("#skin-colorpicker").change();

        var h = $(window).height();//获取页面的高度
        document.getElementById("iframe0").style.height = h * 0.94 + "px";//设置iframe根据显示屏自适应高度。iframe高度是根据显示屏高度的94%，防止出现滚动条。

    });

    if ($.cookie("uname") != null) {
        var uname = $.cookie("uname");
        $("#UserName").html(uname);
    }
    function LoginOut() {
        $.ajax({
            url: "Login.ashx",
            type: "POST",
            //async:false,
            data: { Action: "out" },
            //data:sendData,
            dataType: "text",
            //contentType: 'application/json; charset=utf-8',
            success: function (data, textStatus) {
                if (data == "out") {
                    //alert("退出登录成功");
                    window.location.href = "Login.aspx";
                }
                else {
                    alert("退出登录失败");
                }
            }
        })
    }

    $(".ace-nav").mouseleave(function () {
        $(".dropdown-menu").parent("li").removeClass("open");
    });

    function strolltop() {
        window.scrollTo(0, 0);
    }
    function uploadpicture(filenewnamedir) {
        $("#userpicture").attr("src", filenewnamedir);
    }
</script>
