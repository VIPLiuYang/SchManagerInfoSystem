<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginExc.aspx.cs" Inherits="SchWebMaster.LoginExc" %>

<html> 
<head> 
<title>登录过期</title> 
<script language="javascript" type="text/javascript">
   // var i = 5;
    var i = 0;
    var intervalid;
    intervalid = setInterval("fun()", 1000);
    function fun() {
        if (i == 0) {
            window.top.location.href = "Login.aspx";
            clearInterval(intervalid);
        }
        document.getElementById("mes").innerHTML = i;
        i--;
    }
</script> 
</head> 
<body> 
<div id="errorfrm"> 
<h3>登录信息过期了.....</h3> 
<div id="error">
<p>正在转向登录页</p> 
<!--<p>将在 <span id="mes">5</span> 秒钟后转向登录页！</p> -->
</div> 

</div> 
</body> 
</html> 
