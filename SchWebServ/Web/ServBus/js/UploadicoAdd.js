﻿
    //上传管理平台图标
    $(document).on("click", ".file", function () {
        $("#btnfile").click();
    });
    $(document).on("change", "#btnfile", function () {
        //var filePath = $(this).val();//獲取本地文件路徑
        var fileUp = $(this);//獲取上傳文件
        var boolfile = fileChangeCheck(fileUp);
        if (boolfile) {
            //设置上传文件类型
            //if (filePath.indexOf("jpg") != -1 || filePath.indexOf("jpeg") != -1) {
                //上传文件
                $.ajaxFileUpload({
                    url: "UploadFile.ashx",
                    secureuri: false,
                    fileElementId: "btnfile",
                    dataType: "json",
                    success: function (data, status) {
                        //获取上传文件路径
                        $("#PlatformIco").val(data.filenewname);
                        $("#PlatformIcoimg").attr("src", "../.." + data.filenewname);
                        $("#PlatformIcoimg").css("display", "block");
                        alert("文件上传成功！");
                        $("#btnfile").val("");
                    },
                    error: function (data, status, e) {
                        alert(data); alert(status); alert(e);
                    }
                });
            //}
        }
    });
  

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
        //檢查上傳文件是圖片文件
        var fileName = fileName.substring(fileName.lastIndexOf(".") + 1).toLowerCase();
        if (fileName != "jpg" && fileName != "png") {
            alert("请选择图片格式上传(jpg,png)！");
            $(this).val("");
            return false;
        } else {
            return true;
        }
    }
    
}