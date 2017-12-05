$(function () { 
    alert('222');
    //初始化文件上传工具
    $("#Uploadify_Nhxebz").uploadify({//初始化函数
        'uploader': '../../assets/js/uploadify/uploadify.swf', //flash文件位置
        'script': 'ashx/UploadFile.ashx?action=upload', //后台处理的请求
        'cancelImg': '../../assets/js/uploadify/cancel.png',
        'buttonImg': '../../assets/js/uploadify/upload.gif',
        'height': 35,
        'width': 128,
        'wmode': 'transparent',
        'queueID': 'fileQueue',
        'fileExt': '*.*',
        'fileDesc': '支持格式(所有格式)',
        'sizeLimit': '10485760', // 10M
        'multi': true,
        'onSelect': function (e, queueId, fileObj) {
            isSelect = 1;
        },
        onComplete: function (event, queueID, fileObj, response, data) {
            alert('11');
            var dataObj = eval("(" + response + ")"); //转换为json对象 
            if (dataObj.status = "true") {
                $('#FileUrl').html(dataObj.url);
                var url = $('#FileUrl').html().replace(/,/g, '/');
                var tindex = url.indexOf("/App_File/");
                var fileUrl = url.substring(tindex);
                var li = document.createElement("li");
                li.setAttribute("style", "padding:5px");
                li.innerHTML = "<a class='aNode' href='../ashx/Download.ashx?path=" + fileUrl + "&title=" + fileObj.name + "'  title =" + fileObj.name + " name=" + fileUrl + "  >" + fileObj.name + "</a> <a onclick='del(this)' href='javascript:void(0);'> 删除</a>";
                document.getElementById("files").appendChild(li);
            } else if (dataObj.status = "false") {
                $.messager.alert("操作提示", "文件上传失败！", "error");
            }
            fileResult += dataObj.status;
        },
        onAllComplete: function (event, data) {

            if (fileResult.indexOf("false") < 0) {
                $.messager.alert("操作提示", "文件上传成功！", "info", function () {
                    //附单据张数 赋值
                    var liNodeList = $('.aNode');

                    $("#uploadFile").dialog("close");
                });
            } else {
                $.messager.alert("操作提示", "文件上传失败！", "error");
            }
        },
        onError: function (event, queueID, fileObj, errorObj) {
            if (errorObj.type == "File Size") {
                parent.ShowMessage('系统提醒', "文件:" + fileObj.name + " 大于10M，上传失败！");
            } else {
                parent.ShowMessage('系统提醒', "文件:" + fileObj.name + " 上传失败");
            }
        }
    });


});
