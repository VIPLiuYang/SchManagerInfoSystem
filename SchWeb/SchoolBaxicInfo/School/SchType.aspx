<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchType.aspx.cs" Inherits="SchWeb.SchoolBaxicInfo.School.SchType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>学校类型</title>
    <script type="text/javascript" src="/Assets/Js/jquery-1.10.2.min.js"></script>
    
</head>
<body>
    
    <script type="text/javascript">
        $.ajax({
            url: "ashx/SchType.ashx",
            type: "POST",//或GET
            async: true,//或false,是否异步
            data: { Action: "List" },
            dataType: "json",//返回的数据格式：json/xml/html/script/jsonp/text
            timeout: 5000,    //超时时间
            success: function (data, textStatus) {
                document.write("<table>");
                $.each(data.rows, function (index, content) {
                    
                    document.write("<tr>");
                    document.write("<td>"+index+"</td><td>"+content.SchTypeCode+"</td><td>"+content.Stat+"</td>");
                    document.write("</tr>");
                    
                });
                document.write("</table>");
            },
            error: function (data, textStatus) { alert(data); }
        });
        
    </script>
    <!--
        {"total":5,"rows":[{"SchTypeId":"1","SchTypeCode":"123","SchTypeName":"sdf","Stat":"1","NOTE":"dsf"},{"SchTypeId":"5","SchTypeCode":"102","SchTypeName":"小学","Stat":"1","NOTE":"备注"},{"SchTypeId":"6","SchTypeCode":"103","SchTypeName":"中学","Stat":"1","NOTE":"备注"},{"SchTypeId":"7","SchTypeCode":"104","SchTypeName":"中学","Stat":"0","NOTE":"备注"},{"SchTypeId":"8","SchTypeCode":"102","SchTypeName":"中学","Stat":"0","NOTE":"备注"}]}
        -->
</body>
</html>
