<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsShow.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.SchNews.NewsShow" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8" />
    <title>新闻查看</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,栏目,2018" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />

    <!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

    <!-- page specific plugin styles -->


    <!-- fonts -->



    <!-- ace styles -->

    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
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
        }
        /*坐在位置的坐边竖线*/
        .breadcrumb_border {
            border-left: 2px solid #63bbff;
            margin-left: 0px;
            padding-left: 12px;
        }
        /*位置提示字体大小*/
        .breadcrumb > li {
            font-size: 13px !important;
            color: #666666 !important;
        }
        /*内容上边距*/
        .content_box {
            padding-top: 24px;
        }
        /*输入框和下拉选框的间距*/
        select, input {
            font-size: 12px;
            margin-left: 10px;
            margin-right: 10px;
            color: #999999;
        }
        /*搜索栏的字体颜色*/
        .input-group {
            font-size: 13px;
            color: #000000;
        }
        /*输入框字体的颜色*/
        input[type="text"] {
            color: #999999;
            font-size: 12px;
        }
        /*表格标题栏颜色*/
        .table.table-bordered thead tr th {
            font-size: 13px !important;
            color: #444444;
            text-align: center;
            line-height: 1.5;
        }
        /*表格内容区颜色*/
        .table.table-bordered tbody tr td {
            font-size: 13px !important;
            color: #666666;
            text-align: center;
            line-height: 1.5;
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
        /*按钮的字体大小*/
        .text_size {
            font-size: 12px;
        }

        .breadcrumb > li + li:before {
            content: "";
        }

        .form-actions {
            border: none;
            background: none;
        }

        #content_detail_0 {
            font-size: 16px;
            text-align: justify;
        }

        #insert {
            font-size: 16px;
            text-align: justify;
        }
    </style>
    <style type="text/css">
        .a-upload {
            padding: 4px 10px;
            width: 90px;
            height: 40px;
            box-sizing: border-box;
            line-height: 31px;
            position: relative;
            cursor: pointer;
            color: #FFFFFF;
            background: #1AAD19;
            border: 1px solid #ddd;
            border-radius: 4px;
            overflow: hidden;
            display: inline-block;
            *display: inline;
            *zoom: 1;
        }

            .a-upload input {
                position: absolute;
                font-size: 200px;
                opacity: 0;
                filter: alpha(opacity=0);
                cursor: pointer;
                width: 0px;
                height: 30px;
                left: 0;
                top: 0;
            }

            .a-upload:hover {
                color: #FFFFFF;
                background: #1AAD19;
                border-color: #ccc;
                text-decoration: none;
            }

        #cloum-range-grade-class span {
            margin: auto 5px auto 5px;
        }

        #form-label-title {
            font-size: 24px;
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
                <div class="breadcrumbs breadcrumb_box" id="breadcrumbs">
                    <script type="text/javascript">
                        try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
                    </script>

                    <ul class="breadcrumb breadcrumb_border">
                        <li>目前位置：
                        </li>
                        <li class="active">新闻查看</li>
                    </ul>
                </div>

                <div class="nav-search" id="nav-search">
                    <a class=" pull-right " href="javascript:window.history.go(-1);">
                        <i class="icon-reply icon-only"></i>
                        返回
                    </a>
                </div>

                <div class="page-content content_box ">

                    <!--发布新闻表单-->
                    <form class="form-horizontal" role="form">
                        <div class="form-group">
                            <label id="form-label-title" class="col-sm-12 text-center" for="form-field-title"></label>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label no-padding-right" for="form-field-content"></label>
                            <div class="col-sm-4 text-center" id="cloum-range-grade-class"></div>
                            <label class="col-sm-4 control-label no-padding-right" for="form-field-content"></label>
                        </div>
                        <div class="space-8"></div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label no-padding-right" for="form-field-content"></label>
                            <div class="col-sm-8">
                                <div class="row">
                                    <div id="insert" class="col-sm-12"></div>
                                </div>
                            </div>
                            <div class="col-sm-1"></div>
                        </div>
                        <div class="space-8"></div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label text-left" for="form-field-content"></label>
                            <div id="form-field-reference" class="col-sm-1 control-label" style="text-align: left;word-wrap:break-word ;"></div>
                            <div id="text-reference" class="col-sm-4 control-label" style="text-align: left;word-wrap:break-word ;"></div>
                            <div id="form-field-reply" class="col-sm-1 control-label no-padding text-right"></div>
                        </div>
                        <div class="space-8"></div>
                    </form>
                    <!--//发布新闻表单-->
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


    <!-- (Optional) Latest compiled and minified JavaScript translation files -->
    <script type="text/javascript">

        var gradename = '<%=gradename%>';
        var newlv = '<%=newlv%>';
        var chnname = '<%=chnname%>';
        var classname = '<%=classname%>';
        var content = '<%=content%>';
        var isqur = '<%=isqur%>';
        var qurl = '<%=qurl%>';
        var topic = '<%=topic%>';
        var isrep = '<%=isrep%>';

        $("#form-label-title").html(topic);
        var headstr = "";
        headstr += "<span>栏目：" + chnname + "</span>";
        if (newlv == "0") {//班级
            headstr += "<span>类别：班级</span>";
        } else if (newlv == "1") {//年级
            headstr += "<span>类别：年级</span>";
        } else if (newlv == "2") {//学校
            headstr += "<span>类别：学校</span>";
        }
        if (gradename != "") {
            headstr += "<span>年级：" + gradename + "</span>";
        }
        if (classname != "") {
            headstr += "<span>班级：" + classname + "</span>";
        }
        $("#cloum-range-grade-class").html(headstr);
        if (content != "") {
            var contsarr = content.match(/\<section\>(.*?)\<\/section\>/g);//正則表達式進行按區域分解
            var contlen = contsarr.length;
            var str = "";
            for (var i = 0; i < contlen; i++) {
                var paragraph = "";
                var picture = "";
                var pattern = new RegExp('<p class="paragraph">(.*?)<\/p>', 'i');//獲取段落標籤內的正則表達式
                if (contsarr[i].match(pattern) != null) {
                    paragraph = contsarr[i].match(pattern)[1]
                    console.log(contsarr[i].match(pattern)[1]);//獲取段落標籤內的內容
                }
                var pattern2 = new RegExp('<p class="picture"><img src="(.*?)" alt="" /><\/p>', 'i');//獲取圖片標籤內的正則表達式
                if (contsarr[i].match(pattern2) != null) {
                    picture = contsarr[i].match(pattern2)[1];
                    console.log(contsarr[i].match(pattern2)[1]);//獲取圖片標籤內的內容
                }
                str += '<div class=\"row childen\" id=\"yc' + i + '\">';
                str += '    <div class=\"col-sm-11\">';
                str += '        <div class=\"row\">';
                str += '            <div class=\"col-sm-10\" id=\"content_detail_' + i + '\" style=\"text-indent:40px;word-wrap:break-word\">';
                str += '                ' + paragraph;
                str += '            </div>';
                str += '            <div class=\"col-sm-1\"></div>';
                str += '        </div>';
                str += '        <div class="space-8"></div>';
                if (picture != "") {
                    str += '        <div class=\"row\">';
                    str += '            <div class=\"col-sm-11\" style=\"text-align:center;\"><img id=\"Priimg_' + i + '\" class=\"Priimg\" style=\"width:60%;\" src=\"' + picture + '\" /></div>';
                    str += '            <div class=\"col-sm-1\"></div>';
                    str += '        </div>';
                    str += '        <div class="space-8"></div>';
                }
                str += '    </div>';
                str += '</div>';

            }
            $("#insert").append(str);
        }
        if (isqur == "1") {
            $("#form-field-reference").html("是否引用：是");
            $("#text-reference").html("引用地址：" + qurl);
        } else {
            $("#form-field-reference").html("是否引用：否");
        }
        if (isrep == "1") {
            $("#form-field-reply").html("是否允许回复：是");
        } else {
            $("#form-field-reply").html("是否允许回复：否");
        }
    </script>


</body>
</html>
