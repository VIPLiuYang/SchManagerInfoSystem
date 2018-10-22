<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsAdd.aspx.cs" Inherits="SchWebMaster.Web.SchNews.NewsAdd" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8" />
    <title>新闻添加</title>
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
         /*位置提示字体大小*/
        .breadcrumb > li {
            font-size:13px !important;
            color:#666666 !important;
        }
         /*内容上边距*/
        .content_box {
            padding-top: 24px;
        }
        /*输入框和下拉选框的间距*/
        select, input {
            font-size:12px;
            margin-left:10px;
            margin-right:10px;
            color:#999999;
        }
        /*搜索栏的字体颜色*/
        .input-group {
           font-size:13px;
           color:#000000;
        }
        /*输入框字体的颜色*/
        input[type="text"] {
            color:#999999;
            font-size:12px;
        }
        /*表格标题栏颜色*/
        .table.table-bordered thead tr th {
            font-size:13px !important;
            color:#444444;
            text-align:center;
            line-height: 1.5
        }
        /*表格内容区颜色*/
        .table.table-bordered tbody tr td {
            font-size:13px !important;
            color:#666666;
            text-align:center;
            line-height: 1.5
        }
        
        /*input中placeholder的颜色*/
       input::-webkit-input-placeholder, textarea::-webkit-input-placeholder { /* WebKit*/  
            color:#999999;
            font-size:12px;  
        }  
        input:-moz-placeholder, textarea:-moz-placeholder { /* Mozilla Firefox 4 to 18 */  
            color:#999999;
            font-size:12px;  
        }  
        input::-moz-placeholder, textarea::-moz-placeholder { /* Mozilla Firefox 19+ */  
            color:#999999;
            font-size:12px;  
        }  
        input:-ms-input-placeholder, textarea:-ms-input-placeholder { /* IE 10+ */  
            color:#999999;
            font-size:12px;  
        }
        /*按钮的字体大小*/
        .text_size {
            font-size:12px;
        }
        .breadcrumb > li + li:before {
            content:"";
        }
        .form-actions {
            border: none;
            background: none;
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
				text-decoration: none
			}
        #filename {
            height: 40px;
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
                        <li>
                            目前位置：
                        </li>
                        <li class="active">新闻发布</li>
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
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-1"> 标题 </label>
                        <div class="col-sm-9">
                            <input type="text" id="form-field-title" placeholder="标题" class="col-xs-10 col-sm-5" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-column"> 栏目 </label>
                        <div class="col-sm-1">
                            <select class="form-control" id="form-field-select-column"></select>
                        </div>
                        <div class="col-sm-8"></div>
                    </div>
                    <div class="space-8"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-range"> 范围 </label>
                        <div class="col-sm-9">
                            <div class="row">
                                <div class="col-sm-1">
                                    <select class="form-control" id="form-Select-range">
                                        <option value="0">班级</option>
                                        <option value="1">年级</option>
                                        <option value="2">学校</option>
                                    </select>
                                </div>
                                <div class="col-sm-11"></div>
                            </div>
                            <div class="space-8"></div>
                            <div class="row">
                                <div class="col-sm-1" id="form-field-select-gride">
                                    <select class="form-control" id="form-select-gride"></select>
                                </div>
                                <div class="col-sm-1" id="form-field-select-class">
                                    <select class="form-control" id="form-select-class"></select>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-content"> 内容 </label>
                        <div class="col-sm-8">
                            <div class="row">
                                <div id="insert" class="col-sm-12"></div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="row">
                                        <div class="col-sm-1" onclick="addDiv();return false;" style="cursor:pointer; color: #FFFFFF;  font-size:14px; width: 100px; height: 30px;line-height: 30px;text-align: center; background-color: #09BB07;margin:auto 20px auto 20px;">添加段落</div>
                                        <div class="col-sm-1" onclick="delDiv();return false;" style="cursor:pointer; color: #FFFFFF; font-size:14px; width: 100px; height: 30px;line-height: 30px;text-align: center; background-color: #E64340;">删除段落</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-1"></div>
                    </div>
                    <div class="space-8"></div>
                    <div class="form-group">
                        <label class="col-sm-3 control-label no-padding-right" for="form-field-annex"> 附件 </label>
                        <div class="col-sm-7">
                            <input id="filename" type="text" class="col-sm-12" />
                        </div>
                        <div class="col-sm-1">
                            <a href="#" style="float:right" class="a-upload"><input id="upload" type="file" value="搜索" />附件上传</a>
                        </div>
                        <div class="col-sm-1"></div>
                    </div>
                    <div class="space-8"></div>
                    <div class="form-group">
                        <div class="col-sm-3 control-label no-padding-right">是否引用</div>
                        <div class="col-sm-9">
                            <label>
                                <input name="switch-field-reference" class="ace ace-switch ace-switch-4" type="checkbox" />
                                <span class="lbl"></span>
                            </label>
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="form-group">
                        <div class="col-sm-3 control-label no-padding-right"></div>
                        <div class="col-sm-9">
                            <input id="text-reference" name="text-reference" style="display:none;" type="text" class="col-sm-9" />
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="form-group">
                        <div class="col-sm-3 control-label no-padding-right">是否允许回复</div>
                        <div class="col-sm-9" style="padding-top: 7px;">
                            <label>
                                <input name="switch-field-reply" class="ace ace-switch ace-switch-4" type="checkbox" />
                                <span class="lbl"></span>
                            </label>
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="clearfix form-actions">
                        <div class="col-md-offset-3 col-md-9">
                            <button class="btn btn-info" type="button" onclick="saveuser()">
                                <i class="icon-ok bigger-110"></i>
                                发布
                            </button>
                            &nbsp; &nbsp; &nbsp;
                            <button class="btn" type="reset" onclick="notdo()">
                                <i class="icon-undo bigger-110"></i>
                                取消
                            </button>
                        </div>
                    </div>
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
        var SchChnJsonStr = <%=SchChnJsonStr%>;//栏目json对象
        var SchGradeJsonStr = <%=SchGradeJsonStr%>;
        var SchClassJsonStr = <%=SchClassJsonStr%>;
    </script>
    <script type="text/javascript">
        //栏目初始化
        var optionSchShn="";
        $.each(SchChnJsonStr, function (index, item) {
            optionSchShn += "<option value=\""+item.ChnCode+"\">"+item.ChnName+"</option>";
        });
        $("#form-field-select-column").html(optionSchShn);
        //范围初始化
        $("#form-Select-range").bind("change",function () {
            var currentval = $(this).val();
            if(currentval=="0"){//班级
                $("#form-select-gride").css("display","block");
                $("#form-select-class").css("display","block");
            }else if(currentval=="1"){//年级
                $("#form-select-gride").css("display","block");
                $("#form-select-class").css("display","none");
            }else if(currentval=="2"){//学校
                $("#form-select-gride").css("display","none");
                $("#form-select-class").css("display","none");
            }else{
                $("#form-select-gride").css("display","none");
                $("#form-select-class").css("display","none");
            }
        })
        //年级初始化
        var optionGrade = "";
        $.each(SchGradeJsonStr,function(index,item){
            optionGrade += "<option value=\""+item.GradeCode+"\">"+item.GradeName+"</option>";
        });
        $("#form-select-gride").html(optionGrade);
        //班级初始化
        var optionClass = "";
        $.each(SchClassJsonStr,function(index,item){
            optionClass += "<option value=\""+item.ClassId+"\">"+item.ClassName+"</option>";
        });
        $("#form-select-class").html(optionClass);
        //年级、班级联动
        $("#form-select-gride").bind("change",function () {
            var currentgrdcode = $(this).val();
            var params = '{"gradecode":"' + currentgrdcode + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "NewsAdd.aspx/getclass",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }else{
                        $("#form-select-class").html(data.d.data);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        });
        $(document).find("input[name='switch-field-reference']").click(function(){
            var isChecked = $("input[name='switch-field-reference']").prop("checked");
            if(isChecked==true){
                $("#text-reference").css("display","block");
            }else{
                $("#text-reference").css("display","none");
            }
        });
        

        //保存
        function saveuser(){
            var datasave = [];
            var title = $("#form-field-title").val();           datasave.push("title#" + title);
            var column = $("#form-field-select-column").val();  datasave.push("column#" + column);
            var range = $("#form-Select-range").val();          datasave.push("range#" + range);
            var grade = $("#form-select-gride").val();          datasave.push("grade#" + grade);
            var grdclass = $("#form-select-class").val();       datasave.push("grdclass#" + grdclass);
            var content = $("#form-editor-content").val();      datasave.push("content#" + content);
            //var annex = $("#form-field-annex").val();         datasave.push("annex#" + annex);
            $.ajax({
                type: "POST",  //请求方式
                url: "NewsAdd.aspx/newsaddsave",  //请求路径：页面/方法名字
                data: JSON.stringify({ arr: datasave }),     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code== "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    } else if (data.d.code == "success") {
                        alert(data.d.msg);
                        window.history.go(-1);
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
        var count1=0;
        var str="";

        function addDiv() {
            var str="";
            str += '<div class=\"row childen\" id=\"yc' + count1 + '\">';
            str += '    <div class=\"col-sm-12\">';
            str += '        <div class=\"row\">';
            str += '            <div class=\"col-sm-1\">段落标题'+(count1+1)+'</div>';
            str += '            <div class=\"col-sm-10\"><input class=\"col-sm-12\" name=\"dlt\" id=\"title' + count1 + '\" placeholder="请输入节标题"  type="text" style=\"height:40px;\" ></div>';
            str += '            <div class=\"col-sm-1\"></div>';
            str += '        </div>';
            str += '        <div class="space-8"></div>';
            str += '        <div class=\"row\">';
            str += '            <div class=\"col-sm-1\">段落内容'+(count1+1)+'</div>';
            str += '            <div class=\"col-sm-10\">';
            str += '                <textarea name=\"dlc\" id=\"conten' + count1 + '\"   v-model.lazy=\"newscontent.message\" class=\"col-sm-12 weui-input\" style=\"margin-left:10px;\"></textarea>';
            str += '            </div>';
            str += '            <div class=\"col-sm-1\"></div>';
            str += '        </div>';
            str += '        <div class="space-8"></div>';
            str += '        <div class=\"row\">';
            str += '            <div class=\"col-sm-1\"></div>';
            str += '            <div class=\"col-sm-10 kuan\"><input class=\"col-sm-11\" name=\"dle\" id=\"Priimgname' + count1 + '\" type=\"text\" style=\"height:40px;\" /></div>';
            str += '            <div class=\"col-sm-1 an\"><a href=\"#\" style=\"float:right\" class=\"a-upload\"><input id=\"Prifile' + count1 + '\" type=\"file\"  />上传图片</a></div>';
            str += '        </div>';
            str += '        <div class="space-8"></div>';
            str += '    </div>';
            str += '</div>';
            $("#insert").append(str);
            count1++;
        }
        function delDiv(){
            var childenLen = $(document).find("#insert .childen").length;
            var childen_i=childenLen-1;
            $(document).find("#yc"+childen_i).remove();
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
        //var vm_loading; //等待框
        //var fileUploader; //上传logo七牛对象
        var bannerUploader; //上传banner七牛对象
        var uptokenData; //上传的token
        var imgurl = ""; //圖片地址   
        //var FileDataArray = new Array(); //附件参数
        //var imgName;
        //var PriNewsId;

        var objArray = new Array();

        //初始化上传
        window.onload = function() {
            initUploaderfj();
        }


        function initUploaderfj() {
            var bannerOption = {
                disable_statistics_report: true, // 禁止自动发送上传统计信息到七牛，默认允许发送
                runtimes: 'html5,flash,html4', // 上传模式,依次退化
                browse_button: 'upload', // 上传选择的点选按钮，**必需** 
                uptoken_func: function(file) { // 在需要获取 uptoken 时，该方法会被调用 
                    console.log("uptoken_func:" + JSON.stringify(file));
                    uptokenData = null;
                    uptokenData = getQNUpToken(file);
                    console.log("获取uptoken回调:" + JSON.stringify(uptokenData));
                    if(uptokenData && uptokenData.code) { //成功   
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
                    'FilesAdded': function(up, files) {
                        plupload.each(files, function(file) {
                            // 文件添加进队列后,处理相关的事情
                        });
                    },
                    'UploadProgress': function(up, file) {
                        // 每个文件上传时,处理相关的事情  
                    },
                    'FileUploaded': function(up, file, info) {
                        // 每个文件上传成功后,处理相关的事情 
                        console.log("文件:info:" + JSON.stringify(info));
                        if(info.status == 200) {
                            var cc = eval("(" + info.response + ")");
                            imgurl = "https://qn-cspb.jiaobaowang.net/" + cc.key;
                            console.log("imgurl:" + imgurl);
                            document.getElementById('filename').value = imgurl;
                        } else {
                            //上传失败
                        }
                    },
                    'Error': function(up, err, errTip) {
						    //操作失败
                    },
                    'UploadComplete': function() {
						    //队列文件处理完毕后,处理相关的事情
						    //console.log("UploadComplete");
                    },
                    'Key': function(up, file) {
						    // 若想在前端对每个文件的key进行个性化处理，可以配置该函数
						    // 该配置必须要在 unique_names: false , save_key: false 时才生效
						    if(uptokenData && uptokenData.code) { //成功
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
            cloudutil.getFileUpTokens(getTokenData, function(data) {
                upToken = data;
            });
            console.log("gettokendata：" + JSON.stringify(getTokenData))
            return upToken;
        }
    </script>
    
</body>
</html>
