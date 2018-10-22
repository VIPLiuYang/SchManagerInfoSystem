<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserE.aspx.cs" Inherits="SchWebMaster.Web.Users.UserE" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>用户修改</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!-- basic styles -->

    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />

    <!--[if IE 7]>
		  <link rel="stylesheet" href="../../assets/css/font-awesome-ie7.min.css" />
		<![endif]-->

    <!-- page specific plugin styles -->

    <link rel="stylesheet" href="../../assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="../../assets/css/chosen.css" />

    <!-- fonts -->


    <!-- ace styles -->

    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/bootstrap-tagsinput.css">
    <link rel="stylesheet" href="../../assets/css/metro.css" />


    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="../../assets/css/ace-ie.min.css" />
		<![endif]-->

    <!-- inline styles related to this page -->

    <!-- ace settings handler -->

    <script src="../../assets/js/ace-extra.min.js"></script>

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->

    <!--[if lt IE 9]>
		<script src="../../assets/js/html5shiv.js"></script>
		<script src="../../assets/js/respond.min.js"></script>
		<![endif]-->
    <style>
        .widget-box {
            border-bottom: 0px;
        }

        .row {
            border-bottom: 1px dotted #e4e4e4;
            margin: 0px;
            font-size: 14px;
            color: #999999;
        }

        .widget-main {
            padding: 12px 12px 24px 12px;
            /*border:0px;*/
        }

        .header {
            margin-top: 0px;
            vertical-align: text-bottom;
        }

            .header.blue {
            }

        strong {
            margin-right: 15px;
            font-size: 14px;
            color: #393939;
        }

        .widget-body {
            border:0px;
        }
        .page-content {
            padding:0px;
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
                <div class="page-content">
                    <div class="widget-box">
                        <div class="widget-body">
                            <div class="widget-main">
                                <h4 class="header smaller lighter blue">个人信息</h4>
                                <div class="row">
                                    <div class="col-sm-4"><strong>老师姓名:</strong><input type="text" value="<%=utname %>" id="usertname" placeholder="姓名(必填)" data-toggle="tooltip" title="1-10个汉字长度,必填" onblur="checkTxt(this,'^.{1,10}$')" maxlength="10" /></div>
                                    <div class="col-sm-4"><strong>系统编号:</strong><input type="text" value="<%=uno %>" disabled="disabled" /></div>
                                    <div class="col-sm-4">
                                        <strong>性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 别:</strong><label>
                                            <input name="usersex" type="radio" value="1" class="ace" checked="checked">
                                            <span class="lbl">男</span>
                                        </label>
                                        <label>
                                            <input name="usersex" type="radio" value="0" class="ace">
                                            <span class="lbl">女</span>
                                        </label>
                                    </div>

                                </div>
                                <div class="space-4"></div>
                                <div class="row">
                                    <div class="col-sm-4"><strong>职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 务:</strong><input type="text" value="<%=ups %>" id="userpst" onblur="checkTxt(this,'^.{0,10}$')" maxlength="10" /></div>
                                    <div class="col-sm-4"><strong>职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 称:</strong><input type="text" value="<%=ujb %>" id="usertitle" onblur="checkTxt(this,'^.{0,10}$')" maxlength="10" /></div>
                                    <div class="col-sm-4"><strong>联系方式:</strong><input type="text" value="<%=utl %>" id="usermobile" placeholder="请输入联系方式" data-toggle="tooltip" title="请正确输入11位手机号" maxlength="11" /></div>
                                </div>
                                <div class="space-4"></div>
                                <div class="row">

                                    <div class="col-sm-4"><strong>账&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 号:</strong><input type="text" value="<%=uname %>" id="uname" placeholder="账号" data-toggle="tooltip" title="字母和数字的长度6-18位组合" onblur="checkTxt(this,'(^$)|^([a-zA-Z0-9]{6,18})$')" maxlength="18" /></div>
                                    <div class="col-sm-4">
                                        <strong><%=upwname %></strong><input type="password" id="userpw" value="<%=upw %>" title="字母和数字的长度6-18位组合" onblur="checkTxt(this,'^[a-zA-Z][a-zA-Z0-9]{6,18}$')" maxlength="18" />
                                        <i id="resetPwd" class="icon-white badge badge-info pull-right" style="display: none; color: white; height: 28px; line-height: 28px; padding-right: 6px; padding-left: 6px; background: #6FB3E0 !important">
                                            <a style="color: white; font-family: 微软雅黑; font-size: 12px !important;" onclick="ResetPwdClick()" href="#">重置密码</a>

                                        </i>
                                    </div>
                                    <div class="col-sm-4">
                                        <strong>账号状态:</strong><label>
                                            <input name="userstat" type="radio" value="1" class="ace" />
                                            <span class="lbl">正常</span>
                                        </label>
                                        &nbsp;&nbsp;
                                                <label>
                                                    <input name="userstat" type="radio" value="0" class="ace" />
                                                    <span class="lbl">停用</span>
                                                </label>
                                    </div>
                                </div>
                                <div class="space-4"></div>
                                <div class="row">

                                    <div class="col-sm-12">
                                        <strong>所在部门:</strong><select id="tags-depts" multiple></select>
                                        <div class="btn-group">
                                            <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle btn_size">
                                                选择部门
													    <span class="icon-caret-down icon-on-right"></span>
                                            </button>
                                            <ul id="treedept" class="dropdown-menu ztree">
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-ms-12 text-right">
                            <button class="btn btn-info btn-sm btn_size" id="btndo" type="button" onclick="saveuser()">
                                <%=btnname %>
                            </button>
                            &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
										<button class="btn btn-sm btn_size" id="CancelBtn" type="reset">
                                            取消
                                        </button>
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.page-content -->
            </div>
            <!-- /.main-content -->
        </div>
        <!-- /.main-container-inner -->
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
    <script type="text/javascript">

    </script>
    <script src="../../assets/js/jsencrypt.min.js"></script>
    <script type="text/javascript">
        
        var dotype='<%=dotype%>';
        var userid='<%=uid%>';
        var uname='<%=uname%>';
        var upw='<%=upw%>';
        //下拉部门框点击屏蔽
        $('.dropdown-menu').click(function(e) {
            e.stopPropagation();
        });
        
        //将添加改成保存
        $('#btndo').html("保存");
        var publicKey = "<%=publicKey%>";
        //publicKey = publicKey.replace(",","\r\n");
        var regv = new RegExp(",", "g"); //创建正则RegExp对象
        publicKey = publicKey.replace(regv, "\r\n");
        
        //部门树及部门选择
        //初始化部门选择
        $("#tags-depts").tagsinput({
            itemValue: 'id',
            itemText: 'text',
        });
        //部门删除触发
        $('#tags-depts').on('itemRemoved', function (event) {
            var node = treedeptObj.getNodeByParam("id", event.item.id, null);
            treedeptObj.checkNode(node, false, false);
            // event.item: contains the item
        });
        var treedeptObj;
        var treeNodesdept =<%=depts%>;
        var settingdept = {
            check: {
                enable: true,
                //autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  


                chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  


                chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
            },
            view: {
                dblClickExpand: false,
                showLine: true,
                selectedMulti: true
            },
            data: {
                simpleData: {
                    enable: true,
                    idKey: "id",
                    pIdKey: "pId",
                    checked: "checked",
                    rootPId: ""
                }
            },
            callback: {
                beforeClick: function (treeId, treeNode) {
                },
                onCheck: DeptzTreeOnCheck
            }
        };
        $(function () {
            if(treeNodesdept)
            {
                for (var x in treeNodesdept) {
                    if(treeNodesdept[x].checked=='true')
                    {
                        $('#tags-depts').tagsinput('add', { id: treeNodesdept[x].id, text: treeNodesdept[x].name });
                    }
    
                }
            }
            treedeptObj = $.fn.zTree.init($("#treedept"), settingdept, treeNodesdept);
            treedeptObj.expandAll(true);

            $("#treeroles .checkbox_false_full").css("display","none");

        });
        //与选中联动
        function DeptzTreeOnCheck(event, treeId, treeNode) {
            if (treeNode.checked) {
                $('#tags-depts').tagsinput('add', { id: treeNode.id, text: treeNode.name });
            } else {
                $('#tags-depts').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
            }
        };
        //num代表传入的数字，n代表要保留的字符的长度  
        function PreFixInterge(num, n) {
            return (Array(n).join(0) + num).slice(-n);
        }
        //用户赋值
        
        if(dotype=="e")
        {            
            if(uname==""){                
                $("#userpw").attr("disabled","disabled");
                $("#resetPwd").css("display","none");
                $("input[name='userstat']").attr("disabled","disabled");
                $("input[name='userstat'][value='1']").attr("checked",false);
            }else{
                if(upw=="123456"){//初始密码
                    $("#lblpwd").text("初始密码:");
                    $('#userpw').val("123456");
                    $('#userpw').attr("type","text");
                }else if(upw=="●●●●●●"){//非初始密码
                    $('#userpw').attr("type","password");
                    $("#resetPwd").css("display","block");
                    $('#userpw').val("●●●●●●");
                }
                $("#uname").attr("disabled","disabled");                
            }
            
            $("input[name='usersex'][value="+<%=usex%>+"]").attr("checked",true);  
            $("input[name='userstat'][value="+<%=ustat%>+"]").attr("checked",true);
            //usersub SubId  $("input[name='radioName'][checked]").val(); 
            if(upw!=""){
                $("#userpw").attr("disabled","disabled");
            }
        }else{
            $("#userpw").attr("disabled","disabled");
            $("#resetPwd").css("display","none");
            $("input[name='userstat']").attr("disabled","disabled");
        }
        function saveuser()
        {
            var encrypt = new JSEncrypt();
            encrypt.setPublicKey(publicKey);
            var usertname= $('#usertname').val();
            if($.trim(usertname)=="")//usercode==""||
            {
                alert('姓名不允许为空!');
                return false;
            }
            var username= $('#uname').val();            
            var usertel= $('#usertel').val();
            if(typeof(usertel)=="undefined"){usertel="";}
            var userpst= $('#userpst').val();
            var usertitle= $('#usertitle').val();
            var usermobile= $('#usermobile').val();  
            var userpw="";
            if($('#userpw').val()!=""){
                userpw= encrypt.encrypt($('#userpw').val());
            }
            var usersex=$("input[name='usersex']:checked").val();
            var userstat=$("input[name='userstat']:checked").val();
            if(typeof(userstat) =="undefined"){userstat="";}
            var userdpts=$("#tags-depts").val();
            if(userdpts==null){
                alert("请选择部门");
                return false;
            }
            if(!checkTxtSave("#uname",'(^$)|^([a-zA-Z0-9]{6,18})$')){
                alert("账号：字母和数字的长度6-18位组合");
                $('#uname').focus();
                return false;
            }
            if(!checkTxtSave("#usermobile",'^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$')){
                alert("请输入正确的手机号码！");
                $('#usermobile').focus();
                return false;
            }

            var params = '{"dotype":"' + dotype + '","userid":"' + userid + '","usertname":"' + usertname + '","usertel":"' + usertel + '","userpst":"' + userpst + '","usertitle":"' + usertitle + '","usermobile":"' + usermobile + '","username":"' + username + '","userpw":"' + userpw + '","usersex":"' + usersex + '","userstat":"' + userstat + '","userdpts":"' + userdpts + '"}';
            
            $.ajax({
                type: "POST",  //请求方式
                url: "UserE.aspx/usersave",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d=='success')
                    {
                        alert("操作成功");
                        
                        window.parent.createuserclose();
                        //window.history.go(-1);
                        //window.location.href="UserInfo.aspx";
                    }else if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }
                    else
                    {
                        var extstr = data.d;
                        extstr = extstr.split(',');
                        alert("账号："+username+"以前是"+extstr[1]+"["+extstr[0]+"]占用，不能再使用！");
                        //alert(data.d);
                        if(data.d == "账号重复!"){ 
                            $("#uname").focus();
                        }
                    }
                },
                error: function (obj, msg, e) {
                }
            });
            
        }
        function checkTxt(o,reg){
            var re = new RegExp(reg);
            var ov=$(o).val();
            if (re.test($(o).val())) {
                //判断账号是否为空
                var unameid = $(o).attr("id");
                if(unameid =="uname"){
                    if($("#"+unameid).val()!="undefined"&&$("#"+unameid).val()!="")
                    {
                        $("input[name=\"userstat\"][value=\"1\"]").prop("checked","checked");
                        $("input[name=\"userstat\"]").removeAttr("disabled");
                        $("#userpw").attr("type","text");
                        $("#userpw").val("123456");
                        $("#treeroles .checkbox_false_full").css("display","inline-block");
                    }
                    if($("#"+unameid).val()=="")
                    {
                        $("#userpw").val("");
                        $("input[name=\"userstat\"]").attr("disabled","disabled");
                        $("input[name=\"userstat\"][value=\"1\"]").removeAttr("checked");
                        $("#treeroles .checkbox_false_full").css("display","none");
                    }
                }
                return true;
            }else{
                $(o).tooltip('show');
                $(o).focus();
                return false;
            }
            
        }
        function checkTxtSave(o,reg){
            var re = new RegExp(reg);
            if (re.test($(o).val())) {
                return true;
            }else{
                $(o).tooltip('show');
                $(o).focus();
                return false;
            }
            
        }
        function ResetPwdClick(){
            $("#userpw").val("123456");
            $("#userpw").attr("type","text");
            $("#resetPwd").attr("style","background-color:none;");
            $("#resetPwd").addClass("nobg");
            $("#resetPwd a").attr("onclick","#");
            $("#resetPwd a").css("cursor","default");
            $("#resetPwd a:hover").css("text-decoration","none");
        }
        
        $(document).on("click","#CancelBtn",function(){
            window.parent.createuserclose();
        });
        $("#rolename").blur();
        $(document).ready(function(){
            
            if(uname!=""){
                $("#treeroles .checkbox_false_full").css("display","inline-block");
            }
        });
    </script>
    <style type="text/css">
        .nobg {
            height: 28px;
            line-height: 28px;
            background-color: #abbac3!important;
        }
    </style>
</body>
</html>
