<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchTypeAdd.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.School.SchTypeAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="/Assets/Js/jquery-1.10.2.min.js"></script>
    <script>
        $(document).ready(function () {
            //学校类型添加功能Jquery方法
            $("#submit").click(function () {
                $.ajax({
                    url: "ashx/SchType.ashx",
                    type: "POST",//或GET
                    data: {
                        SchTypeCode: $("#SchTypeCode").val(),
                        SchTypeName: $("#SchTypeName").val(),
                        Stat: $('input:radio[name="Stat"]:checked').val(),
                        NOTE: $("#NOTE").val(),
                        Action: "Add"
                    },
                    dataType: "text",//返回的数据格式：json/xml/html/script/jsonp/text
                    success: function (data, textStatus) {
                        alert(textStatus);
                        if (data > 0) {
                            alert("成功")
                        } else {
                            alert("失败");
                        }
                    },
                    error: function (data, textStatus) { alert(textStatus); alert("取值范围：-128到127"); }
                });
                /*
                $.post("ashx/SchType.ashx",
                {
                    SchTypeCode: $("#SchTypeCode").val(),
                    SchTypeName: $("#SchTypeName").val(),
                    Stat: $('input:radio[name="Stat"]:checked').val(),
                    NOTE: $("#NOTE").val(),
                    Action: "Add"
                },
                function (data, status) {
                    alert(data);
                    if (data > 0) {
                        alert("添加成功");
                    } else {
                        alert("添加失败");
                    }
                });*/
            });
            //#submit单击事件结束
            
            //
        });
</script>
</head>
<body>
    <table>
        <tr>
            <td>学校类型代码:</td><td><input type="text" name="SchTypeCode" id="SchTypeCode" /></td>
        </tr>
        <tr>
            <td>类型名称:</td><td><input ty[p="text" name="SchTypeName" id="SchTypeName" /></td>
        </tr>
        <tr>
            <td>状态:</td><td><input type="radio" name="Stat" id="Enabled" checked="checked" value="1"/>启用<input type="radio" name="Stat" id="Disabled" value="0" />禁用</td>
        </tr>
        <tr>
            <td>备注:</td><td><textarea cols="50" rows="10" name="NOTE" id="NOTE"></textarea></td>
        </tr>
        <tr>
            <td colspan="2"><div id="submit" style="cursor:pointer;">添加</div></td>
        </tr>
    </table>
</body>
</html>
