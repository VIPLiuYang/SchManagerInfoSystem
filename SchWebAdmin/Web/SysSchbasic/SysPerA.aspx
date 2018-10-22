<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysPerA.aspx.cs" Inherits="SchWebAdmin.Web.SysSchbasic.SysPerA" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="../../assets/css/chosen.css" />

    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/bootstrap-tagsinput.css" />
    <link rel="stylesheet" href="../../assets/css/metro.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>
    <style>
        .page-content {
            padding: 0px;
        }

        .row {
            margin: 0px;
            font-size: 14px;
            color: #999999;
        }

        .widget-box {
            margin: 0px;
            border: 0px;
        }

        .widget-body {
            border: 0px;
        }

        strong {
            margin-right: 15px;
            font-size: 14px;
            color: #393939;
        }
    </style>
</head>
<body ontouchstart>
    <form id="form1" runat="server">
    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>
        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
                <div class="page-content">
                    <div class="widget-box">
                        <div class="widget-body">
                            <div class="widget-main">
                                <div class="row">
                                    <div class="col-sm-2 col-xs-2"><strong>编号:</strong><input type="text" id="lbcode" value="<%=code %>" style="width:30%" data-toggle="tooltip" disabled="disabled" maxlength="10" />
                                    </div>
                                    <div class="col-sm-4 col-xs-4"><strong>学段名称:</strong><input type="text" id="Name" data-toggle="tooltip" maxlength="10" /></div>
                                    <div class="col-sm-3 col-xs-3">
                                        <strong>学年制:</strong>
                                        <select id="DrpY">
                                            <option value="1">1</option>
                                            <option value="2">2</option>
                                            <option value="3">3</option>
                                            <option value="4">4</option>
                                            <option value="5">5</option>
                                            <option value="6">6</option>
                                            <option value="7">7</option>
                                            <option value="8">8</option>
                                            <option value="9">9</option>
                                            <option value="10">10</option>
                                            <option value="11">11</option>
                                            <option value="12">12</option>
                                        </select>
                                    </div>
                                    <div class="col-sm-3 col-xs-3">
                                        <strong>状态:</strong>
                                        <select id="Stat">
                                            <option value="1">正常</option>
                                            <option value="0">停用</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="space-4"></div>
                                    <div class="col-xs-12">
                                        <strong>年级:</strong><br />
                                        <div id="gradelist">
                                        <div class="row"><strong>1年级:</strong><input name="grade" placeholder="必填" type="text" id="grade1" data-toggle="tooltip" maxlength="10" /></div>
                                        <div class="space-4"></div>
                                            </div>
                                    </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-right">
                            <input type="text" id="AutoId" hidden="hidden" />
                            <button class="btn btn-info btn-sm btn_size" id="btndo" type="button" onclick="save()"><%=btname %></button>
                            <button class="btn btn-sm btn_size" id="CancelBtn" type="reset">取消</button>
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
    <script src="../../assets/js/bootstrap-tagsinput.js"></script>
    <script src="../../assets/js/jquery.ztree.all-3.5.min.js"></script>
    <!-- (Optional) Latest compiled and minified JavaScript translation files -->
    <script src="../../assets/js/date-time/bootstrap-datepicker.min.js"></script>
    <link rel="stylesheet" href="../../assets/css/datepicker.css" />
    <%--<script src="../../assets/js/i18n/defaults-zh_CN.min.js"></script>--%>
    <script type="text/javascript">
      
        $('#AutoId').val(<%=id%>);
        $('#Name').val('<%=name%>');
        $("#Stat").val(<%=stat%>); 
        $("#DrpY").val(<%=year%>);
        var gradenames = '<%=grademodelstr%>';
        if (gradenames.length > 0)
        {
            gradelistedit();
        }
        $(document).on("click","#CancelBtn",function(){
            window.parent.createuserclose();
        });
        function gradelistedit() {
            var liststr = "";
            var grs = gradenames.split("|");
            for (var i = 1; i <= grs.length; i++) {
                liststr += '<div class="row"><strong>' + i + '年级:</strong><input name="grade" type="text" id="grade' + i + '" value="' + grs[i-1] + '" placeholder="必填" data-toggle="tooltip" maxlength="10" /></div>';
                liststr += '<div class="space-4"></div>';
            }
            $("#gradelist").html(liststr);
        }
        function gradelistdo(leni) {
            var liststr = "";
            var k = Number(leni);
            var gn = "";
            for (var i = 1; i <= k; i++) {
                if (i == 1)
                {
                    gn = "一年级";
                }
                if (i == 2) 
                {
                    gn = "二年级";
                }
                if (i == 3) {
                    gn = "三年级";
                }
                if (i == 4) {
                    gn = "四年级";
                }
                if (i == 5) {
                    gn = "五年级";
                }
                if (i == 6) {
                    gn = "六年级";
                }
                if (i == 7) {
                    gn = "七年级";
                }
                if (i == 8) {
                    gn = "八年级";
                }
                if (i == 9) {
                    gn = "九年级";
                }
                if (i == 10) {
                    gn = "十年级";
                }
                if (i == 11) {
                    gn = "十一年级";
                }
                if (i == 12) {
                    gn = "十二年级";
                }
                

                liststr += '<div class="row"><strong>' + i + '年级:</strong><input name="grade" type="text" id="grade' + i + '" placeholder="必填" value="' + gn + '" data-toggle="tooltip" maxlength="10" /></div>';
                liststr += '<div class="space-4"></div>';
            }            
            $("#gradelist").html(liststr);
        }
        $("#DrpY").bind("change", function () {
            var yy = $(this).val();
            gradelistdo(yy);
        });
        //数据收集并存库函数
        function save()
        {
            var AutoId= $("#AutoId").val(); 
            var Name= $("#Name").val(); 
            if(Name=="")
            {
                alert("请填写学段名称");
                return false;
            }
            var grades = $("input[name$='grade']");
            var gradeerror = "";
            var gradestr = "";
            if (grades.length > 0) {
                gradestr.replace(/|/g, "");
                for (var i = 0; i < grades.length; i++) {
                    var gradename = $(grades[i]).val().replace(/|/g, "").trim();
                    if (gradename.length == 0) {
                        gradeerror = "请将所有年级名称填写正确";
                    }
                    else {
                        gradestr += gradename + "|";
                    }
                }
            }
            else {
                alert("年级无,请生成年级");
                return false;
            }
            if (gradeerror.length > 0)
            {
                alert(gradeerror);
                return false;
            }
            gradestr = gradestr.substring(0, gradestr.length - 1);
            var Stat = $("#Stat").val();
            var year = $("#DrpY").val();
            var code = $("#lbcode").val();
            var params = '{"Name":"' + Name + '","GradeNames":"' + gradestr + '","Year":"' + year + '","Code":"' + code + '","stat":"' + Stat + '","AutoId":"' + AutoId + '"}';
            
            $.ajax({
                type: "POST",  //请求方式
                url: "SysPerA.aspx/save",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire")
                    {
                        window.location.href = "../../LoginExc.aspx";
                    }
                    else if (data.d.code == "error") {
                        alert(data.d.msg);
                    }
                    else if (data.d.code=='success')
                    {
                        alert(data.d.msg);
                        window.parent.createuserclose();                         
                    }
                },
                error: function (obj, msg, e) {
                }
            });
            
        }
 
    </script>
    </form>
</body>
</html>
