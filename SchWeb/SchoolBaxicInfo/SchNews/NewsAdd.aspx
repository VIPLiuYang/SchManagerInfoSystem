<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsAdd.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.SchNews.NewsAdd" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8" />
    <title>文章添加</title>
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
        .form-actions {
            border: none;
            background: none;
        }

        #form-select-class {
            min-width: 90px;
        }
    </style>
    <style type="text/css">
        #form-text-annex {
            height: 40px;
        }


        #form-select-grade {
            min-width: 78px;
        }

        #form-field-select-column {
            min-width: 92px;
        }

        .widget-box {
            border-top: 1px solid #CCC;
            border-bottom: 0px;
        }

        .childen {
            margin-top: 20px;
            border: 1px solid #CCC;
        }

        .row {
            margin: 0px;
            font-size: 14px;
            color: #999999;
        }

        .widget-main {
            padding: 12px 12px 24px 12px;
            /*border:0px;*/
        }

        .header {
            margin-top: 0px;
            vertical-align: text-bottom;
        }

        .btn-xs {
            margin: 0 10px;
        }

        strong {
            margin-right: 15px;
            font-size: 14px;
            color: #393939;
        }

        .page-content {
            padding: 0px;
        }

        .widget-body {
        }

        textarea {
            border-bottom: 1px solid #CCC;
            border-left: 0px solid;
            border-right: 0px solid;
            BORDER-TOP: 0px solid;
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
                        <li class="active">文章添加</li>
                    </ul>
                </div>

                <div class="nav-search" id="nav-search">
                    <a class=" pull-right " href="javascript:window.history.go(-1);">
                        <i class="icon-reply icon-only"></i>
                        返回
                    </a>
                </div>

                <div class="page-content">
                    <div class="widget-box">
                        <div class="widget-body">
                            <div class="widget-main">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <strong>文章标题:</strong><input type="text" id="form-field-title" class="col-sm-12 col-xs-12 weui-input" placeholder="标题" maxlength="25" />
                                    </div>
                                </div>
                                <div class="space-4"></div>
                                <div class="row">
                                    <div class="col-sm-3">
                                        <strong>所在栏目:</strong><select id="form-field-select-column"><%=chndrp %></select>
                                    </div>
                                    <div class="col-sm-3">
                                        <strong>文章类别:</strong><label>
                                            <select id="form-select-newlv">
                                            </select></label><label>
                                                <select id="form-select-grade"></select></label>
                                        <label>
                                            <select id="form-select-class"></select></label>
                                    </div>
                                    <div class="col-sm-3">
                                        <strong>允许回复:</strong><label>
                                            <input id="switch-field-reply" name="switch-field-reply" class="ace ace-switch ace-switch-4" type="checkbox" />
                                            <span class="lbl"></span>
                                        </label>
                                    </div>
                                    <div class="col-sm-3">
                                        <strong>是否引用:</strong><label>
                                            <input id="switch-field-reference" name="switch-field-reference" class="ace ace-switch ace-switch-4" type="checkbox" />
                                            <span class="lbl"></span>
                                        </label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12"><strong>引用地址:</strong><input id="text-reference" name="text-reference" style="display: none;" type="text" class="col-sm-12" /></div>
                                </div>
                                <div class="space-4"></div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <strong>文章内容:</strong>
                                        <div id="insert">
                                            <div class="childen" id="yc0">
                                                <div class="row">
                                                    <textarea name="dlc" id="content_detail_0" class="col-sm-12 col-xs-12 weui-input" placeholder="请输入段落内容" style="height: 150px"></textarea>
                                                </div>
                                                <div class="row text-right">
                                                    <img id="Priimg_0" class="Priimg" style="width: 30%" src="" />
                                                </div>
                                                <div class="row text-right">
                                                    <input id="Prifile0" type="file" style="display: none;" /><input class="part-imgaddr" name="dle" id="Priimgname_0" type="hidden" />
                                                    <button class="btn btn-xs a-upload btn-purple" relid="0"><i class="icon-cloud-upload align-top"></i>上传图片</button>
                                                    <button class="btn btn-xs" id="delDiv_0" onclick="delDiv(0);return false;">
                                                        <i class="icon-minus align-top"></i>
                                                        删除该段
                                                    </button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row text-right" style="margin: 20px 0px;">
                                    <button class="btn btn-xs btn-pink" onclick="addDiv();return false;">
                                        <i class="icon-plus align-top"></i>
                                        添加段落
                                    </button>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12 text-right">
                                        <button class="btn btn-info btn-sm" id="btndo" type="button" onclick="saveuser()">保存</button>

                                        &nbsp; &nbsp; &nbsp;
											<button class="btn btn-sm" id="btndoreset" type="button" onclick="notdo()">
                                                取消
                                            </button>

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
    <script src="../../assets/js/jquery-ui-1.10.3.custom.min.js"></script>
    <script src="../../assets/js/jquery.ui.touch-punch.min.js"></script>
    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>
    <!-- Latest compiled and minified JavaScript -->


    <!-- (Optional) Latest compiled and minified JavaScript translation files -->
    <script type="text/javascript">
        var NewsCopeDrp = '<%=NewsCopeDrp%>';//年級
        var NewsCopeDrpClass = '<%=NewsCopeDrpClass%>';
        var NewsCope = '<%=NewsCope%>';//班級
        var encs = new Object();
    </script>
    <script type="text/javascript">
        //范围初始化
        function currentvalfun() {
            if (currentval == "0") {//班级
                $("#form-select-grade").css("display", "block");
                $("#form-select-class").css("display", "block");
                $("#form-select-grade").html(NewsCopeDrp);
                //班级初始化
                $("#form-select-class").html(NewsCopeDrpClass);
            } else if (currentval == "1") {//年级
                $("#form-select-grade").css("display", "block");
                $("#form-select-class").css("display", "none");
                //年级初始化
                $("#form-select-grade").html(NewsCopeDrp);
            } else if (currentval == "2") {//学校
                $("#form-select-grade").css("display", "none");
                $("#form-select-class").css("display", "none");
            } else {
                $("#form-select-grade").css("display", "none");
                $("#form-select-class").css("display", "none");
            }
        }
        $("#form-select-newlv").html(NewsCope);
        var currentval = $("#form-select-newlv").val();

        currentvalfun();

        $("#form-select-newlv").bind("change", function () {
            currentval = $(this).val();
            if (currentval == "0") {//班级
                $("#form-select-grade").css("display", "block");
                $("#form-select-class").css("display", "block");
                //年级初始化
                $("#form-select-grade").html(NewsCopeDrp);
                //班级初始化
                $("#form-select-class").html(NewsCopeDrpClass);
            } else if (currentval == "1") {//年级
                $("#form-select-grade").css("display", "block");
                $("#form-select-class").css("display", "none");
                $("#form-select-class").children().remove();
                //年级初始化
                $("#form-select-grade").html(NewsCopeDrp);
            } else if (currentval == "2") {//学校
                $("#form-select-grade").css("display", "none");
                $("#form-select-class").css("display", "none");
                $("#form-select-grade").children().remove();
                $("#form-select-class").children().remove();
            } else {
                $("#form-select-grade").css("display", "none");
                $("#form-select-class").css("display", "none");
            }
        })
        //类型与年级联动
        $("#form-select-newlv").bind("change", function () {
            var curtp = $(this).val();
            var params = '{"gradeid":"","newlv":"' + curtp + '","lv":1}';

            $.ajax({
                type: "POST",  //请求方式
                url: "NewsAdd.aspx/getclass",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    } else {
                        $("#form-select-grade").html(data.d.RspData);
                        $("#form-select-grade").change();
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        });
        //年级、班级联动
        $("#form-select-grade").bind("change", function () {
            var currentgrdid = $(this).val();
            var curtp = $("#form-select-newlv").val();
            var params = '{"gradeid":"' + currentgrdid + '","newlv":"' + curtp + '","lv":0}';

            $.ajax({
                type: "POST",  //请求方式
                url: "NewsAdd.aspx/getclass",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    } else {
                        $("#form-select-class").html(data.d.RspData);
                    }
                },
                error: function (obj, msg, e) {
                }
            });

        });
        $(document).find("#switch-field-reference").click(function () {
            var isChecked = $("#switch-field-reference").prop("checked");
            if (isChecked == true) {
                $("#text-reference").css("display", "block");
            } else {
                $("#text-reference").css("display", "none");
            }
        });

        $(document).on("click", ".a-upload", function () {
            var relid = $(this).attr("relid");
            $("#Prifile" + relid).click();
        });

        var SchNews = new Object();
        //保存
        function saveuser() {
            var title = $("#form-field-title").val().trim();//標題
            if (title == "") {
                alert("标题不允许为空"); return false;
            } else {
                SchNews.title = title;
            }
            var column = $("#form-field-select-column").val();//欄目
            if (column == null || column == "") {
                alert("请先选择栏目"); return false;
            }
            SchNews.column = column;
            var range = $("#form-select-newlv").val();//範圍
            SchNews.range = range;
            var gradeid = $("#form-select-grade").val();//年級
            SchNews.gradeid = gradeid;
            var grdclassid = $("#form-select-class").val();
            if (grdclassid == null) { grdclassid = "" }//班級
            SchNews.grdclassid = grdclassid;
            if (range == "0" && gradeid == "") {
                alert("年级不允许为空"); return false;
            }
            if (range == "0" && grdclassid == "") {
                alert("班级不允许为空"); return false;
            }
            if (range == "1" && gradeid == "") {
                alert("年级不允许为空"); return false;
            }
            var contents = "";
            var regtobr = new RegExp("\n", "g");//將英文半角回車轉換為HTML中<br />
            var regto1 = new RegExp("\"", "g");//將英文半角左邊單引號轉換為中文全角左邊單引號
            var regto2 = new RegExp("\"", "g");//將英文半角右邊單引號轉換為中文全角右邊單引號
            var regto3 = new RegExp(",", "g");//將英文半角逗號轉換為中文全角逗號
            var insertChildLen = $("#insert .childen").length;
            if (insertChildLen > 0) {
                for (var i = 0; i < insertChildLen; i++) {
                    var content_detail = $("#content_detail_" + i).val().replace(regtobr, "<br/>").replace("\"", "“") + ",";
                    var content_image = $("#Priimgname_" + i).val() + "|";
                    contents += content_detail + content_image;
                }
            }
            if (contents == ",") {
                alert("内容不允许为空"); return false;
            }
            SchNews.content = contents.substring(0, contents.length - 1);//內容
            //var annex = $("#form-text-annex").val();//附件
            //SchNews.annex=annex;
            var IsReference = $("#switch-field-reference").prop("checked");
            SchNews.isreference = IsReference;//是否引用
            var textReference = "";
            if (IsReference == true) {
                textReference = $("#text-reference").val();//引用地址
                if (textReference == "") {
                    alert("引用地址不允许为空"); return false;
                } else {
                    SchNews.textreference = textReference;//引用地址
                }
            } else {
                SchNews.textreference = "";//引用地址
            }

            var IsReply = $("#switch-field-reply").prop("checked");//是否回復
            SchNews.isreply = IsReply;
            SchNews.encs = FileDataArray;
            //console.log(JSON.stringify(SchNews));
            var params = '{"arr":\'' + JSON.stringify(SchNews) + '\'}';
            //console.log(params);

            $.ajax({
                type: "POST",  //请求方式
                url: "NewsAdd.aspx/newsaddsave",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    } else if (data.d.code == "success") {
                        alert(data.d.msg);
                        //window.history.go(-1);//在前面如果有alert時，不兼容火狐
                        location.href = document.referrer;//在前面如果有alert時，兼容谷歌、火狐
                    }
                    else {
                        alert(data.d.msg);
                    }
                },
                error: function (obj, msg, e) {
                }
            });

        }

    </script>

    <script type="text/javascript">
        var count1 = 1;

        function addDiv() {
            var str = "";
            str += '<div class="childen" id="yc' + count1 + '">';
            str += '<div class="row">';
            str += '<textarea name="dlc" id="content_detail_' + count1 + '" class="col-sm-12 col-xs-12 weui-input" placeholder="请输入段落内容" style="height: 150px"></textarea>';
            str += '</div>';
            str += '<div class="row text-right">';
            str += '<img id="Priimg_' + count1 + '" class="Priimg" style="width: 30%" src="" />';
            str += '</div>';
            str += '<div class="row text-right">';
            str += '<input id="Prifile' + count1 + '" type="file" style="display: none;" /><input class="part-imgaddr" name="dle" id="Priimgname_' + count1 + '" type="hidden" />';
            str += '<button class="btn btn-xs a-upload btn-purple" relid="' + count1 + '"><i class="icon-cloud-upload align-top"></i>上传图片</button>';
            str += '<button class="btn btn-xs" id="delDiv_' + count1 + '" onclick="delDiv(' + count1 + ');return false;">';
            str += '<i class="icon-minus align-top"></i>';
            str += '删除该段';
            str += '</button>';
            str += '</div>';
            str += '</div>';
            $("#insert").append(str);
            var Priid = "Prifile" + count1;
            var Priimgname = "Priimgname_" + count1;
            var Priimg = "Priimg_" + count1;
            initUploaderfj(Priid, Priimgname, Priimg);
            count1++;
        }
        function delDiv(currentno) {
            var childenDom = $(document).find("#insert .childen");
            var childenLen = childenDom.length;
            //刪除當前段落
            $(document).find("#yc" + currentno).remove();
            //後面的段落ID編號依次減1
            for (var i = childenLen - 1; i >= currentno; i--) {
                $(childenDom[i]).attr("id", "yc" + (i));
                //$("#yc"+(i)+" .part-title").attr("id","content_title_"+(i));
                $("#yc" + (i) + " .weui-input").attr("id", "content_detail_" + (i));
                $("#yc" + (i) + " .part-imgaddr").attr("id", "Priimgname_" + (i));
                $("#yc" + (i) + " .Priimg").attr("id", "Priimg_" + (i));
                $("#yc" + (i) + " .delDiv").attr("onclick", "delDiv(" + (i) + ");return false;");
            }
            count1--;
        }

    </script>

    <!--七牛引用的核心文件-->
    <script src="../../assets/lib/qiniu/qiniu.min.js"></script>
    <script src="../../assets/lib/plupload/plupload.full.min.js"></script>
    <script src="../../assets/lib/plupload/moxie.min.js"></script>
    <!--公共方法-->
    <script src="../../assets/utils/utils.js"></script>
    <!--配置文件-->
    <script src="../../assets/utils/storageutil.js"></script>
    <!--七牛公共文件-->
    <script src="../../assets/utils/cloudutil.js"></script>
    <!--JS DES加密函数公共文件-->
    <script src="../../assets/utils/cryption.js"></script>
    <!--在plupload控件上自定義的方法-->
    <script src="../../assets/utils/pluploadutil.js"></script>
    <script type="text/javascript">

        var bannerUploader; //上传banner七牛对象
        var uptokenData; //上传的token
        var imgurl = ""; //圖片地址   

        var FileDataArray = [];

        //初始化上传
        //initUploaderfj("上傳input的ID屬性","返回圖片地址填充的input的ID屬性","返回圖片地址填充的img的ID屬性")

        window.onload = function () {
            initUploaderfj("Prifile0", "Priimgname_0", "Priimg_0");
        }


        function initUploaderfj(Priid, Priimgname, Priimg) {
            var bannerOption = {
                disable_statistics_report: true, // 禁止自动发送上传统计信息到七牛，默认允许发送
                runtimes: 'html5,flash,html4', // 上传模式,依次退化
                browse_button: Priid, // 上传选择的点选按钮，**必需** 
                uptoken_func: function (file) { // 在需要获取 uptoken 时，该方法会被调用 
                    console.log("uptoken_func:" + JSON.stringify(file));
                    uptokenData = null;
                    uptokenData = getQNUpToken(file);
                    console.log("获取uptoken回调:" + JSON.stringify(uptokenData));
                    if (uptokenData && uptokenData.code) { //成功   
                        return uptokenData.data.Data[0].Token;
                    } else {
                        bannerUploader.stop();
                    }
                },
                unique_names: false, // 默认 false，key 为文件名。若开启该选项，JS-SDK 会为每个文件自动生成key（文件名）
                save_key: false, // 默认 false。若在服务端生成 uptoken 的上传策略中指定了 `save_key`，则开启，SDK在前端将不对key进行任何处理
                get_new_uptoken: true, // 设置上传文件的时候是否每次都重新获取新的 uptoken
                domain: storageutil.QNPBDOMAIN, // bucket 域名，下载资源时用到，如：'http://xxx.bkt.clouddn.com/' **必需**
                max_file_size: '10mb', // 最大文件体积限制
                flash_swf_url: '../../js/lib/plupload/Moxie.swf', //引入 flash,相对路径
                max_retries: 0, // 上传失败最大重试次数
                dragdrop: false, // 开启可拖曳上传
                chunk_size: '4mb', // 分块上传时，每块的体积
                auto_start: true, // 选择文件后自动上传，若关闭需要自己绑定事件触发上传,
                filters: {
                    mime_types: [ //只允许上传图片和zip文件
                        {
                            title: "Image files",
                            extensions: "jpg,png,jpeg,gif,bmp"
                        }
                    ]
                },
                init: {
                    'FilesAdded': function (up, files) {
                        plupload.each(files, function (file) {
                            // 文件添加进队列后,处理相关的事情
                        });
                    },
                    'UploadProgress': function (up, file) {
                        // 每个文件上传时,处理相关的事情  
                    },
                    'FileUploaded': function (up, file, info) {
                        // 每个文件上传成功后,处理相关的事情 
                        console.log("文件:info:" + JSON.stringify(info));
                        if (info.status == 200) {
                            var cc = eval("(" + info.response + ")");
                            imgurl = "https://qn-cspb.jiaobaowang.net/" + cc.key;
                            console.log("imgurl:" + imgurl);
                            document.getElementById(Priimgname).value = imgurl;
                            $("#" + Priimg).attr("src", imgurl);

                            var imgLink = Qiniu.imageView2({
                                mode: 3, // 缩略模式，共6种[0-5]
                                w: 100, // 具体含义由缩略模式决定 
                                h: 100, // 具体含义由缩略模式决定
                                q: 100, // 新图的图像质量，取值范围：1-100
                                format: 'png' // 新图的输出格式，取值范围：jpg，gif，png，webp等
                            }, cc.key);
                            console.log("imgLink:" + imgLink);

                            encs.saveurl = imgurl; //图片地址
                            encs.imgurl = imgLink;
                            encs.oldname = file.name;
                            encs.newname = cc.key;
                            encs.filesize = file.size;
                            FileDataArray.push(encs);

                            console.log("encs:" + JSON.stringify(encs));
                        } else {
                            //上传失败
                        }
                    },
                    'Error': function (up, err, errTip) {
                        //操作失败
                    },
                    'UploadComplete': function () {
                        //队列文件处理完毕后,处理相关的事情
                        //console.log("UploadComplete");
                    },
                    'Key': function (up, file) {
                        // 若想在前端对每个文件的key进行个性化处理，可以配置该函数
                        // 该配置必须要在 unique_names: false , save_key: false 时才生效
                        if (uptokenData && uptokenData.code) { //成功
                            return uptokenData.data.Data[0].Key;
                        }
                    }
                }
            }
            bannerUploader = Qiniu.uploader(bannerOption);
        }
        /*
        **获取七牛上传token
        */
        function getQNUpToken(file) {
            var myDate = new Date();
            var fileName = myDate.getTime() + "" + parseInt(Math.random() * 1000);
            var types = file.name.split(".");
            fileName = fileName + "." + types[types.length - 1];
            var getTokenData = {
                appId: storageutil.QNQYWXKID,//應用程式id
                mainSpace: storageutil.QNPUBSPACE,//七牛公開空間
                saveSpace: storageutil.QNQYWXFN,//網站配置空間(第二前綴名)
                fileArray: [{
                    qnFileName: fileName,
                }]
            }
            var upToken;
            cloudutil.getFileUpTokens(getTokenData, function (data) {
                upToken = data;
            });
            console.log("gettokendata：" + JSON.stringify(getTokenData))
            return upToken;
        }
        function notdo() {
            window.history.go(-1);
        }
    </script>

</body>
</html>
