<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uploadfile.aspx.cs" Inherits="SchWebServ.uploadfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <style type="text/css">
body {
    font-family:微软雅黑;
}

.file{
   position: relative;
   background-color: #3C9BFE;
   border: 1px solid #ddd;
   width: 68px;
   height: 25px;
   display: inline-block;
   text-decoration: none;
   text-indent: 0;
   line-height: 25px;
   font-size: 12px;
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
    <span class="biaoqian">选择文件：</span><input id="txt_filePath" type="text" readonly="readonly"/>
    <a class="file"><input id="btnfile" name="btnfile" accept="image/gif, image/jpeg, image/jpg, image/png" type="file"/>浏览</a>
    <p id="userheadpic"></p>
    <p id="uploadsuccess"></p>
    <p class="tishi">*允许上传的头像格式：jpg|jpeg|gif|png</p>
    <script type="text/javascript">
        window.jQuery || document.write("<script src='./assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
    </script>
    <script src="assets/js/ajaxfileupload.js"></script>
    <script type="text/javascript">
        var userid = "<%=userid %>";
        
        $(function () {
            //选择文件
            $(".file").on("change", "input[type='file']", function () {
                var filePath = $(this).val();//獲取本地文件路徑
                var fileUp = $(this);//獲取上傳文件
                var boolfile = fileChangeCheck(fileUp);
                if (boolfile) {
                    //设置上传文件类型
                    if (filePath.indexOf("jpg") != -1 || filePath.indexOf("jpeg") != -1 || filePath.indexOf("gif") != -1 || filePath.indexOf("png") != -1) {
                        //上传文件
                        $.ajaxFileUpload({
                            url: "UpUserImg.ashx?userid=" + userid,
                            secureuri: false,
                            fileElementId: "btnfile",
                            dataType: "json",
                            success: function (data) {
                                if (data.RspTxt == '正常') {
                                    alert('头像更改成功');
                                }
                                else {
                                    alert(data.RspTxt);
                                }
                            },
                            error: function (data, status, e) {
                                alert(data);
                            }
                        });
                    }
                }
            });
        })
        function fileChangeCheck(fileUp) {
            var fileName = fileUp["0"].files["0"].name;//獲取本地文件名稱
            var fileSize = fileUp["0"].files["0"].size;//獲取文件大小
            //檢查上傳文件是否超過2MB
            fileSize = fileSize / 1024;
            if (fileSize > 2048) {
                alert("图片不能大于2MB");
                $(this).val("");
                return false;
            } else {
                return true;
            }
            //檢查上傳文件是圖片文件
            var fileName = fileName.substring(fileName.lastIndexOf(".") + 1).toLowerCase();
            if (fileName != "jpg" && fileName != "jpeg" && fileName != "png" && fileName != "gif") {
                alert("请选择图片格式上传(jpg,png,gif,gif等)！");
                $(this).val("");
                return false;
            } else {
                return true;
            }
        }
    </script>
</body>
</html>
