﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="SchWebMaster.Web.UserFuncSoure.UploadFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <style type="text/css">
.file{
   position: relative;
   background-color: #b32b1b;
   border: 1px solid #ddd;
   width: 68px;
   height: 25px;
   display: inline-block;
   text-decoration: none;
   text-indent: 0;
   line-height: 25px;
   font-size: 14px;
   color: #fff;
   margin: 0 auto;
   cursor: pointer;
   text-align: center;
   border: none;
   border-radius: 3px;         
}
.file input{
   position: absolute;
   top: 0;
   left: -2px;
   opacity: 0;
   width: 10px;
}
/*选择文件标签的样式*/
.biaoqian {
    font-size:14px;

}
/*提示文字的样式*/
.tishi {
    font-size: 12px;
    color: red;
}
    </style>
    <div class="space-20" style=" margin-top: 20px; margin-bottom: 20px;"></div>
    <span  class="biaoqian">选择文件：</span><input id="txt_filePath" type="text" readonly="readonly"/>
    <a class="file"><input id="btnfile" name="btnfile" type="file"/>浏览</a>
    <p class="tishi">*允许上传的头像格式：jpg|jpeg</p>
    <script type="text/javascript">
        window.jQuery || document.write("<script src='./assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
    </script>
    <script src="assets/js/ajaxfileupload.js"></script>
    <script type="text/javascript">
        var systype = <%=systype%>;
        $(function () {
            //选择文件
            $(".file").on("change", "input[type='file']", function () {
                var filePath = $(this).val();
                //设置上传文件类型
                if (filePath.indexOf("jpg") != -1 || filePath.indexOf("jpeg") != -1) {
                    //上传文件
                    $.ajaxFileUpload({
                        url: "UploadFile.ashx",
                        secureuri: false,
                        fileElementId: "btnfile",
                        dataType: "json",
                        success: function (data, status) {
                            if (data.status == "success01") {
                                alert("上传失败，"+data.error);
                                if(systype=="2"||systype=="1"){
                                    window.location.href = "SchStructureSet.aspx";
                                }else{
                                    window.location.href = "jsywebindex.html";
                                }
                            } else if (data.status == "success02") {
                                alert("上传失败，"+data.error);
                            }else if (data.status == "error") {
                                alert("登录失效，"+data.error);
                            } else {
                                //获取上传文件路径
                                $("#txt_filePath").val(data.filenewname);
                                alert("文件上传成功！");
                                window.parent.uploadpicture(data.filenewname);
                                if(systype=="1"){
                                    window.location.href = "SchStructureSet.aspx";
                                }else if(systype=="0"){
                                    //window.location.href = "jsywebindex.html";
                                }else{
                                   // window.location.href = "./SchoolBaxicInfo/School/SchInfo.aspx";
                                }
                            }
                        },
                        error: function (data, status, e) {
                            alert(data); alert(status); alert(e);
                        }
                    });
                } else {
                    alert("请选择正确的文件格式！");
                    //清空上传路径
                    $("#txt_filePath").val("");
                    return false;
                }
            });
        })
    </script>
</body>
</html>
