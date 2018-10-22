<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchSigninDialog.aspx.cs" Inherits="SchWebAdmin.Web.SchSignin.SchSigninDialog" %>

<!DOCTYPE html>
<html>
<head>
    <title>ww </title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>
    <style>
        
        /*表头样式*/
        .table tbody tr th {
            font-family: 微软雅黑;
            font-size: 13px;
            font-weight: bold;
            letter-spacing: 1px;
            color: #444444;
            text-align: center;
        }
        /*表格内容样式*/
        .table tbody tr td {
            font-family: 微软雅黑;
            font-size: 13px;
            color: #666666;
            text-align: center;
        }

        body {
            background-color: transparent;
            overflow: -Scroll;
            overflow-x: hidden;
            font-family: 微软雅黑;
        }
        /*定义内容大小*/
        .neirong {
            color: #999999 !important;
            font-size: 13px !important;
        }

        .neirong1 {
            color: #999999 !important;
            font-size: 12px !important;
        }
        /*去掉表格中输入框的边框*/
        .input_style {
            border: none !important;
            border: 0px;
            background: rgba(0, 0, 0, 0);
        }

        .center {
            width: 100%;
            padding: 10px;
            color: #fff;
            margin: 20px auto;
        }
        /*弹出框中的学校下拉框的样式*/
        #asch {
            max-width:260px;
        }
        .text_size {
            padding: 0 6px;
            line-height: 22px;
        }
        input[type="text"] , select {
            font-size:12px !important;
        }
    </style>

</head>
<body>

    <div class="page-content">
        <div class="row">
            <div class="col-xs-12 no-padding">
                <div class="col-sm-12 no-padding">
                    <%=areastr %>  &nbsp; 
                    <input type="text" style="width: 100px;display:none;" id="txtname" placeholder="00001"  />&nbsp;&nbsp;&nbsp;
                    <button class="btn btn-sm btn-info text_size" type="button" onclick="search();">查询</button>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12">
                <%--  <div class="space-10"></div>
                <div class="table-responsive" id="list"></div> --%>
                <br />
                <div>
                    <input type="text" hidden="hidden" id="a" />
                    <input type="text" hidden="hidden" id="b" />
                    <input type="text" hidden="hidden" id="c" />
                    <input type="text" hidden="hidden" id="d" />
                    <input type="text" hidden="hidden" id="e" />

                </div>
                <table id="table" class="table table-striped table-bordered table-hover">
                </table>
                <div style="text-align: right">
                    <a class="btn btn-link" href="#" id="TeacherAddRow"><%--<!--onclick="yugi.addRow(table)--%>
                        <i class="icon-plus align-top bigger-125"></i>
                    </a>
                </div>
                <%--<input type="button" value="添加" onclick="yugi.addRow(table)" />--%>
            </div>
        </div>
        <div class="center">
            <div class="col-sm-4 col-sm-offset-4" style="text-align: center;">
                <button id="savebtn" class="btn btn-sm btn-info baocunbianju" onclick="SaveData(table,table.this)" type="button">
                    保存
                </button>
                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
				<button id="CancelBtn" class="btn btn-sm baocunbianju">
                    取消
                </button>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        window.jQuery || document.write("<script src='../../assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
        if ("ontouchend" in document) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
    </script>


    <script src="../../assets/js/bootstrap.min.js"></script>
    <script src="../../assets/js/typeahead-bs2.min.js"></script>
    <link href="../../assets/css/bootstrap-dialog.css" rel="stylesheet" />
    <script src="../../assets/js/bootstrap-dialog.js"></script>
    <!-- ace scripts -->
    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>
    <script src="../../assets/js/bootstrap-paginator.js"></script>
    <script type="text/javascript">


        $(document).on("click", "#CancelBtn", function () {
            window.parent.createuserclose();
        });

        $("#TeacherAddRow").on('click', function () {
            teclistadd();
            i++;
        });

        var schid = '<%=schid%>';
        var cotycode = '';
        var ustat = '';
        var PageIndex = 1;
        var PageSize = 10;
        var pageCount = 1;
        var txtname = '';

        var Priaid = "";
        var i = 0;
        var SysName = ''; var SysUrl = ''; var SysUserNameTips = ''; var SysUserPwTips = ''; var SysLoginUrl = ''; var PriAutoId = 0;
        $(document).ready(function () { getdata(); });
        function search() {
            txtname = $('#txtname').val();
            //if ($('#acoty').val()) {
            //    cotycode = $('#acoty').val(); 
            schid = $("#asch").val();
            getdata();
        }
        //获取数据
        function getdata() {
            var params = '{"PageIndex":"' + PageIndex + '","PageSize":"' + PageSize + '","txtname":"' + txtname + '","cotycode":"' + cotycode + '","schid":"' + schid + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SchSigninDialog.aspx/page",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    }
                    else if (data.d.code == "error") {
                        alert(data.d.msg);
                    }
                    else {
                        dodata(eval('(' + data.d.data + ')'));
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        }; 
        //以下是动态添加任课教师DOM
        function teclistadd() {//alert(name);

            var str = "";
            str += '<tr>';
            str += '<td><input type="text" maxlength="15" name="AutoId" hidden="hidden" value="0"  /><input type="text" maxlength="30" name="SysName" id="SysName' + i + '"/></td>';
            str += '<td><input type="text"  maxlength="100" name="SysUrl" id="SysUrl' + i + '"/></td>';
            str += '<td><input type="text"  maxlength="15" name="SysUserNameTips" id="SysUserNameTips' + i + '"/></td>';
            str += '<td><input type="text"  maxlength="15" name="SysUserPwTips" id="SysUserPwTips' + i + '"/></td>';
            str += '<td><input type="text"  maxlength="100" name="SysLoginUrl" id="SysLoginUrl' + i + '"/></td>';
            str += '<td >'
            //str += "<a  href='###'    title='编辑'>";
            //str += "<span class='blue'><i class='icon-edit bigger-120'></i></span></a> &nbsp;";
            str += "<a href='#' onclick='del(table,this)' class='tooltip-error' data-rel='tooltip' title='删除'>";
            str += "<span class='red'> <i class='icon-trash bigger-120'></i></span> </a>";
            str += '</td>';
            str += '</tr>';
          //  document.getElementById("table").innerHTML += str;
            $("#table").append(str);
            i++;
            $('.dropdown-menu').click(function (e) {
                e.stopPropagation();
            });
        }
        //以上是动态添加任课教师DOM 

        function updata(table, row) {
            //var r = row.parentElement.parentElement,
            //       c = r.cells;
            //   if (/.*span.*/g.test(row.innerHTML)) {
            //       for (var i = 0; i < c.length - 1; i++) {
            //           var ci = c[i]; 
            //           var txt = document.createElement("input");
            //           txt.type = "text"; 
            //           txt.style = "width: 120px;"
            //           txt.value = ci.innerHTML;
            //           ci.innerHTML = "";
            //           ci.appendChild(txt);
            //       } 
            //   }
        }
        function del(table, row, aid) {//移除table当前行，保存id
            Priaid += aid + ',';
            var r = row.parentElement.parentElement,
                  c = r.cells;
            r.parentNode.removeChild(r);

        }
        //表格生成处理
        function dodata(data) {
            var str = '';
            str += '<tr>';
            str += ' <th>第三方系统名称</th>  ';
            str += ' <th>域名或IP地址</th> ';
            str += '   <th>用户框标识</th> ';
            str += ' <th>密码框标识</th> ';
            str += '   <th>登录首页URL</th>  ';
            str += '   <th width="10%">操作</th>  ';
            str += '  </tr> ';
            $.each(data.list, function (index, item) { //遍历返回的json  
                str += '<tr>';
                str += '<td><input type="text" name="AutoId" hidden="hidden" value="' + item.AutoId + '"  /><input type="text" maxlength="30" class="neirong col-sm-12 input_style text-center"   name="SysName" value="' + item.SysName + '" /></td>';
                str += '<td><input type="text"  maxlength="50" class="neirong col-sm-12 input_style text-center"   name="SysUrl"value="' + item.SysUrl + '" /></td>';
                str += '<td><input type="text"  maxlength="15" class="neirong col-sm-12 input_style text-center"   name="SysUserNameTips"value="' + item.SysUserNameTips + '" /></td>';
                str += '<td><input type="text"  maxlength="15" class="neirong col-sm-12 input_style text-center"   name="SysUserPwTips"value="' + item.SysUserPwTips + '" /></td>';
                str += '<td><input type="text"  maxlength="50" class="neirong col-sm-12 input_style text-center"   name="SysLoginUrl"value="' + item.SysLoginUrl + '" /></td>';
                str += '<td >'
                //  str += "<a  href='###' onclick='updata(table,this)'   title='编辑'>";
                // str += "<span class='blue'><i class='icon-edit bigger-120'></i></span></a> &nbsp;";
                str += "<a href='#' onclick='del(table,this," + item.AutoId + ")' class='tooltip-error' data-rel='tooltip' title='删除'>";
                str += "<span class='red'> <i class='icon-trash bigger-120'></i></span> </a>";
                str += '</td>';
                str += '</tr>';
            });
            $('#table').empty();
            $('#table').append(str);
        };

        //保存
        function SaveData(table, row) {
            var AutoId = $("[name='AutoId']");
            var SysName = $("[name='SysName']");
            var SysUrl = $("[name='SysUrl']");
            var SysUserNameTips = $("[name='SysUserNameTips']");
            var SysUserPwTips = $("[name='SysUserPwTips']");
            var SysLoginUrl = $("[name='SysLoginUrl']");
            var sendstr = "";
            var PriAutoId = 0;
            if (SysName.length > 0) {
                for (var i = 0; i < SysName.length; i++) {
                    if (i == 0 && $(SysName[i]).val() != "" && $(SysUrl[i]).val() != "" && $(SysUserNameTips[i]).val() != "" && $(SysUserPwTips[i]).val() != "" && $(SysLoginUrl[i]).val() != "") {
                        sendstr += $(AutoId[i]).val() + ',' + $(SysName[i]).val() + ',' + $(SysUrl[i]).val() + ',' + $(SysUserNameTips[i]).val() + ',' + $(SysUserPwTips[i]).val() + ',' + $(SysLoginUrl[i]).val() + ',1|';
                    } else {
                        if ($(SysName[i]).val() != "" && $(SysUrl[i]).val() != "" && $(SysUserNameTips[i]).val() != "" && $(SysUserPwTips[i]).val() != "" && $(SysLoginUrl[i]).val() != "") {
                            var tempstr = $(AutoId[i]).val() + ',' + $(SysName[i]).val() + ',' + $(SysUrl[i]).val() + ',' + $(SysUserNameTips[i]).val() + ',' + $(SysUserPwTips[i]).val() + ',' + $(SysLoginUrl[i]).val() + ',|';

                            if (sendstr.indexOf(tempstr) < 0) {
                                sendstr += tempstr;
                            }
                        } else {
                            alert("请输入完整的数据！");
                            return;
                        }
                    }

                }

                sendstr = sendstr.substring(0, sendstr.length - 1);//去掉最后一个字符 
            }

            if (Priaid != "") {
                Priaid = Priaid.substring(0, Priaid.length - 1);//去掉最后一个字符 
            }

            var params = '{"sendstr":"' + sendstr + '","delAutoId":"' + Priaid + '","schid":"' + schid + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "SchSigninDialog.aspx/Save",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "success") {
                        alert(data.d.msg);
                        Priaid = "";
                        getdata();
                    } else if (data.d.code == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    } else if (data.d.code == "error") {
                        alert(data.d.msg);
                    }
                },
                error: function (obj, msg, e) {
                    alert(msg);
                }
            }); 
        }

        //获取市
        $('#aprov').change(function () {
            var selv = $('#aprov').val();
            var params = '{"typecode":"1","pcode":"' + selv + '","isall":"0"}';
            if (selv != "") {
                $.ajax({
                    type: "POST",  //请求方式
                    url: "../../PlcData.aspx/getarea",  //请求路径：页面/方法名字
                    data: params,     //参数
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d.code == "expire") {                            
                            window.location.href = "../../LoginExc.aspx";
                        } else if (data.d.code == "ExcepError") {
                            alert(edata.d.msg);
                        } else {
                            $('#acity').html(data.d.data);
                            $('#acity').change();
                            $("#aprov option").each(function () {
                                if ($(this).val() == selv) {
                                    $(this).attr("selected", true);
                                }
                                else {
                                    $(this).removeAttr("selected");
                                }

                            });
                        }
                    },
                    error: function (obj, msg, e) {
                    }
                });
            } else {
                $('#acity').empty();
                $('#acity').append("<option value=\"\">全部</option>");
                //$("#acity option:first").prop("selected", 'selected');
                $('#acoty').empty();
                $('#acoty').append("<option value=\"\">全部</option>");
                //$("#acoty option:first").prop("selected", 'selected');
            }
        });
        //获取区
        $('#acity').change(function () {
            var selv = $('#acity').val();
            var params = '{"typecode":"2","pcode":"' + selv + '","isall":"0"}';
            if (selv != "") {
                $.ajax({
                    type: "POST",  //请求方式
                    url: "../../PlcData.aspx/getarea",  //请求路径：页面/方法名字
                    data: params,     //参数
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d.code == "expire") {                            
                            window.location.href = "../../LoginExc.aspx";
                        } else if (data.d.code == "ExcepError") {
                            alert(edata.d.msg);
                        } else {
                            $('#acoty').html(data.d.data);
                            $('#acoty').change();
                            $("#acity option").each(function () {
                                if ($(this).val() == selv) {
                                    $(this).attr("selected", true);
                                }
                                else {
                                    $(this).removeAttr("selected");
                                }
                            });
                        }
                    },
                    error: function (obj, msg, e) {
                    }
                });
            } else {
                $('#acoty').empty();
                $('#acoty').append("<option value=\"\">全部</option>");
                //$("#acoty option:first").prop("selected", 'selected');
            }
        });
        //获取学校
        $('#acoty').change(function () {
            var selv = $('#acoty').val();
            var params = '{"typecode":"3","pcode":"' + selv + '","isall":"0"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "../../PlcData.aspx/getarea",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == "expire") {                            
                        window.location.href = "../../LoginExc.aspx";
                    } else if (data.d.code == "ExcepError") {
                        alert(edata.d.msg);
                    } else {
                        $('#asch').html(data.d.data);
                        $('#asch').change();
                        $("#acoty option").each(function () {
                            if ($(this).val() == selv) {
                                $(this).attr("selected", true);
                            }
                            else {
                                $(this).removeAttr("selected");
                            }

                        });
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        });

    </script>
</body>
</html>
