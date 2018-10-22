<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="SchWebMaster.Web.Users.CreateUser" %>

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
        .label-info {
            background-color: white!important;
        }

         .label {
            font-size: 14px;
            color: black;
        }

         /*.bootstrap-tagsinput .tag {
            color: black;
        }*/

        i {
            font-family: FontAwesome !important;
        }
       /*输入框的字体颜色*/
        .form-group input {
            color: #999999!important;
           
        }
        /*所在位置的提示高度*/
        .breadcrumbs {
            min-height:32px;
            line-height:30px;
        }
        /*所在位置的背景边框*/
        .breadcrumb_box {
            background: white;
            border-bottom: 1px solid #e4e4e4;
            /*color: #333333;*/
        }
        /*坐在位置的坐边竖线*/
        .breadcrumb_border {
            border-left: 2px solid #63bbff;
            margin-left: 0px;
            padding-left: 12px;
            /*padding-top: 4px;
            padding-bottom: 4px;*/
        }
         /*位置提示字体大小*/
        .breadcrumb > li {
            font-size:13px !important;
            color:#666666 !important;
        }
        /*返回按钮的样式*/
        .nav-search {
            line-height:20px !important;
            font-size:12px !important;
        }
        /*学校名称等左边标签的样式*/
        .text_style {
            line-height: 30px !important;
            color: #000000 !important;
        }

        .text_style label {
            font-family:微软雅黑  !important;
            font-size: 14px !important;
         }
        /*按钮中字的大小*/
        .btn_size{
            font-family:微软雅黑;
            font-size:12px;
        }
         /*去掉上边多余的横线*/
        .page_box {
            border-bottom: none;
            padding-top: 0;
            padding-bottom: 0;
            margin-bottom: 0;
        }
        /*内容区域的字体大小颜色*/
        .lbl {
            font-size: 12px !important;
            color: #999999;
        }
        /*部门字段的上边距*/
        .department {
            padding-top: 0px !important;
        }
        /*密码输入框右边距*/
        .password {
            padding-right: 0px;
        }
        /*部门权限的左边距*/
        .tbox {
            padding-left: 6px !important;
            }
         /*选中部门的颜色*/
        .bootstrap-tagsinput .tag {
            font-family: 微软雅黑;
            color: #999999 !important;
            font-size:12px;
        }
        /*选择部门输入框的样式*/
        .bootstrap-tagsinput {
            box-shadow:none;
            border-radius:0px;
            line-height:18px;
            padding-left: 4px;
            padding-right: 4px;
        }
        /*选择部门树状图字体样式*/
        .ztree li a span:nth-child(2) {
            font-family:微软雅黑;
            color:#666666 !important;
            font-size:12px !important;
        }
        /*当屏幕小于800px时样式调整（1月9号添加的）*/
        @media screen and (max-width: 768px) {
            .text-title {
                text-align: initial;
            }

            .tbox {
                padding-left: 12px;
                padding-right: 12px;
            }

            .table_box {
                float: none !important;
            }

            .table2 {
                padding-left: 0px;
                padding-right: 0px;
                margin-top: 16px;
            }

            .btn {
                margin-top: 10px;
            }
        }
         /*表格标题栏字体大小，颜色*/
        .widget-header h4{
            font-family:微软雅黑;
            color:#444444 !important;
            font-weight:bold !important;
            font-size:13px !important;
            letter-spacing:1px !important;
        }
        
        /*表格中的zree中的字体*/
       .widget-body ul li a span:nth-child(2) {
            font-family:微软雅黑;
            color:#666666 !important;
            font-size:12px !important;
        }
        #SpecialAuthorityShow{display:none;}
        #SpecialAuthorityShow:hover{cursor:pointer;}
        #rolextdiv{display:none;}
        /*下拉选框 输入框的大小*/
         select, input {
            font-size:12px;
            color:#999999;
        }
        input[type="text"] {
            color:#999999 !important;
            font-size:12px !important;
            line-height:inherit !important;
        }
         /*input中placeholder的颜色*/
       input::-webkit-input-placeholder, textarea::-webkit-input-placeholder { /* WebKit*/  
            font-family:微软雅黑;
            color:#999999;
            font-size:12px;  
        }  
        input:-moz-placeholder, textarea:-moz-placeholder { /* Mozilla Firefox 4 to 18 */  
            font-family:微软雅黑;
            color:#999999; 
            font-size:12px;  
        }  
        input::-moz-placeholder, textarea::-moz-placeholder { /* Mozilla Firefox 19+ */ 
            font-family:微软雅黑; 
            color:#999999; 
            font-size:12px;  
        }  
        input:-ms-input-placeholder, textarea:-ms-input-placeholder { /* IE 10+ */  
            font-family:微软雅黑;
            color:#999999; 
            font-size:12px;  
        }
        /*输入框的内边距*/
        .input_box {
            padding:4px 10px;
        }
        .breadcrumb > li + li:before {
            content:"";
        }
        /*ztree父节点关联半勾选状态*/
        /*
        #treedept li span.button.chk.checkbox_false_part {
            background-position: -26px -47px;
            
        }
        */
        /*ztree父节点不关联勾选*/
        #treedept li span.button.chk.checkbox_false_part{
            background-position: -5px -25px;
        }
         /*每个标题字体样式*/
        label { 
            color:#333333;
            font-size:13px !important;
            font-family:微软雅黑 !important;
        }
          /*树状结构点击后的状态*/
         .ztree li a.curSelectedNode {
            padding-top: 0px;
            background-color: #ffffff;
            color: black;
            height: 21px;
            opacity: 0.8;
            font-weight:bold;
            }
            .ztree li a.curSelectedNode span:nth-child(2) { 
                color: #428bca !important;
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
                    <div class="space-10"></div>
                    <div class="row">
                        <div class="col-xs-12">
                            <!-- PAGE CONTENT BEGINS -->
                            <form class="form-horizontal" role="form">
                                <div class="form-inline">
                                    <div class="row">
                                        <div class="col-xs-1 no-padding text-right titleheight ">
                                            <label>系统编号:</label>
                                        </div>
                                        <div class="col-xs-3 no-padding-right">
                                            <input type="text" id="SysId"  data-toggle="tooltip" readonly="readonly" disabled="disabled" maxlength="10" />
                                        </div>
                                        <div class="col-xs-1 no-padding text-right titleheight ">
                                            <label style="color: red;">姓名(*):</label>
                                        </div>
                                        <div class="col-xs-3 no-padding-right">
                                            <input type="text" id="usertname" placeholder="姓名(必填)" data-toggle="tooltip" title="1-10个汉字长度,必填" onblur="checkTxt(this,'^.{1,10}$')" maxlength="10" />
                                        </div>
                                        <div class="col-xs-1 no-padding text-right titleheight ">
                                            <label>性 别:</label>
                                        </div>
                                        <div class="col-xs-3 no-padding-right">
                                            <label>
                                                    <input name="usersex" type="radio" value="1" class="ace" style="margin-right: 6px; vertical-align: middle;" checked="checked">
                                                    <span class="lbl">男</span>
                                                </label>
                                                &nbsp &nbsp &nbsp
                                                <label>
                                                    <input name="usersex" type="radio" value="0" class="ace">
                                                    <span class="lbl">女</span>
                                                </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-4"></div>
                                <div class="form-inline">
                                    <div class="row">
                                        <div class="col-xs-1 no-padding-right text-right">
                                            <label class="department">部 门:</label>
                                        </div>
                                        <div class="col-xs-7 no-padding-right text-left">
                                            <select id="tags-depts" multiple></select>
                                            <div class="btn-group">
                                                <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle btn_size">
                                                    选择部门
													    <span class="icon-caret-down icon-on-right"></span>
                                                </button>
                                                <ul id="treedept" class="dropdown-menu ztree">
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="col-xs-1 no-padding text-right">
                                            <label>职 务:</label>
                                        </div>
                                        <div class="col-xs-1 no-padding-right text-left">
                                            <input type="text" id="userpst" onblur="checkTxt(this,'^.{0,10}$')" maxlength="10" />
                                        </div>
                                    </div>
                                </div>
                                <div class="space-4"></div>
                                <div class="form-inline">
                                    <div class="row">
                                        <div class="col-xs-1 no-padding text-right titleheight ">
                                            <label>职 称:</label>
                                        </div>
                                        <div class="col-xs-3 no-padding-right">
                                            <input type="text" id="usertitle" onblur="checkTxt(this,'^.{0,10}$')" maxlength="10" />
                                        </div>
                                        <div class="col-xs-1 no-padding text-right titleheight ">
                                            <label>联系方式:</label>
                                        </div>
                                        <div class="col-xs-3 no-padding-right">
                                            <input type="text" id="usermobile" placeholder="请输入联系方式" data-toggle="tooltip" title="请正确输入11位手机号"  onblur="checkTxt(this,'^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$')" maxlength="11" />
                                        </div>
                                    </div>
                                </div>
                                <div class="space-4"></div>
                                <div class="form-inline">
                                    <div class="row">
                                        <div class="col-xs-1 no-padding text-right titleheight ">
                                            <label>账 号:</label>
                                        </div>
                                        <div class="col-xs-3 no-padding-right">
                                            <input type="text" id="username" placeholder="账号" data-toggle="tooltip" title="字母和数字的长度6-18位组合" onblur="checkTxt(this,'(^$)|^([a-zA-Z0-9]{6,18})$')" maxlength="18" />
                                        </div>
                                        <div class="col-xs-1 no-padding text-right titleheight ">
                                            <label id="lblpwd">密 码:</label>
                                        </div>
                                        <div class="col-xs-3 no-padding-right">
                                            <input type="password" id="userpw" title="字母和数字的长度6-18位组合" class="col-xs-7" onblur="checkTxt(this,'(^$)|^([a-zA-Z0-9]{6,18})$')" maxlength="18" />
                                            <i id="resetPwd" class="icon-white badge badge-info col-sm-3 pull-right" style="display:none;color: white; height: 28px;line-height:28px; padding-right:6px;padding-left:6px;background:#6FB3E0 !important ">
                                                <a style="color: white;font-family:微软雅黑; font-size: 12px !important;" onclick="ResetPwdClick()" href="#">重置密码</a>

                                            </i>
                                        </div>
                                        <div class="col-xs-1 no-padding text-right titleheight ">
                                            <label>账号状态:</label>
                                        </div>
                                        <div class="col-xs-3 no-padding-right">
                                            <label>
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
                                </div>
                                <div class="space-4"></div>
                                <div class="clearfix form-actions" style="background-color:#ffffff;border-top:none;">
                                    <div class="col-xs-12 text-right">
                                        <button class="btn btn-info btn-sm btn_size" id="btndo" type="button" onclick="saveuser()">
                                            <%=btnname %>
                                        </button>
                                        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
										<button class="btn btn-sm btn_size" id="CancelBtn" type="reset">
                                                取消
                                        </button>
                                    </div>
                                </div>
                            </form>
                            <!-- PAGE CONTENT ENDS -->
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
        

      

        //下拉部门框点击屏蔽
        $('.dropdown-menu').click(function(e) {
            e.stopPropagation();
        });
        
        var schid='<%=schid%>';
        var systype='<%=systype%>';
        var dotype='<%=dotype%>';
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
        var umodel=<%=umodelstr%>;
        var userid=0;
        if(umodel!="1")
        {
            $("#SysId").val(PreFixInterge(umodel.UserId,8));
            //$('#usercode').val(umodel.UserNo);
            $('#usertname').val(umodel.UserTname);
            //$('#usertel').val(umodel.Telno);
            $('#userpst').val(umodel.Postion);
            $('#usertitle').val(umodel.Title);
            $('#usermobile').val(umodel.Mobile);
            $('#username').val(umodel.UserName);
            if(umodel.UserName==""){
                $("#lblpwd").text("初始密码:");
                $("#userpw").attr("disabled","disabled");
                $("#resetPwd").css("display","none");
                $("input[name='userstat']").attr("disabled","disabled");
                $("input[name='userstat'][value='1']").attr("checked",false);
            }else{
                if(umodel.PassWord=="******"){//初始密码
                    $("#lblpwd").text("初始密码:");
                    $('#userpw').val("123456");
                    $('#userpw').attr("type","text");
                }else if(umodel.PassWord=="●●●●●●"){//非初始密码
                    $('#userpw').attr("type","password");
                    $("#resetPwd").css("display","block");
                    $('#userpw').val("●●●●●●");
                }
                $("#username").attr("disabled","disabled");
                
            }
            //$('#userpw').val(umodel.PassWord);
            $("input[name='usersex'][value="+umodel.Sex+"]").attr("checked",true);  
            $("input[name='userstat'][value="+umodel.AccStat+"]").attr("checked",true);
            //$('#usersub').val(umodel.SubCode);
            userid=umodel.UserId;
            //usersub SubId  $("input[name='radioName'][checked]").val(); 
            if(umodel.PassWord!=""){
                $("#userpw").attr("disabled","disabled");
            }
        }else{
            $("#userpw").attr("disabled","disabled");
            $("#resetPwd").css("display","none");
            $("input[name='userstat']").attr("disabled","disabled");
            $("#lblpwd").text("初始密码:");
            $("#userpw").val("");
        }
        function saveuser()
        {
            var encrypt = new JSEncrypt();
            encrypt.setPublicKey(publicKey);
            var usercode='00000';// $('#usercode').val();
            var usertname= $('#usertname').val();
            if($.trim(usertname)=="")//usercode==""||
            {
                alert('姓名不允许为空!');
                return false;
            }
            var username= $('#username').val();            
            var usertel= $('#usertel').val();
            if(typeof(usertel)=="undefined"){usertel=" ";}
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
            //var usersub= $('#usersub').val();
            var usersub="";
            var userdpts=$("#tags-depts").val();
            //var userroles=$("#tags-select").val();
            var userroles="";
            if(userdpts==null){
                alert("请选择部门");
                return false;
            }
            if(!checkTxtSave("#username",'(^$)|^([a-zA-Z0-9]{6,18})$')){
                alert("账号：字母和数字的长度6-18位组合");
                return false;
            }
            if(!checkTxtSave("#usermobile",'^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$')){
                alert("请输入正确的手机号码！");
                return false;
            }

            var params = '{"dotype":"' + dotype + '","schid":"' + schid + '","systype":"' + systype + '","userid":"' + userid + '","usercode":"' + usercode + '","usertname":"' + usertname + '","usertel":"' + usertel + '","userpst":"' + userpst + '","usertitle":"' + usertitle + '","usermobile":"' + usermobile + '","username":"' + username + '","userpw":"' + userpw + '","usersex":"' + usersex + '","userstat":"' + userstat + '","usersub":"' + usersub + '","userdpts":"' + userdpts + '","userroles":"' + userroles + '"}';
            
            $.ajax({
                type: "POST",  //请求方式
                url: "CreateUser.aspx/usersave",  //请求路径：页面/方法名字
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
                            $("#username").focus();
                        }
                    }
                },
                error: function (obj, msg, e) {
                }
            });
            
        }
        function checkTxt(o,reg){
            var re = new RegExp(reg);
            if (re.test($(o).val())) {
                //判断账号是否为空
                var unameid = $(o).attr("id");
                if(unameid =="username"){
                    if($("#"+unameid).val()!="undefined"||$("#"+unameid).val()!=""){
                        $("input[name=\"userstat\"][value=\"1\"]").prop("checked","checked");
                        $("input[name=\"userstat\"]").removeAttr("disabled");
                        $("#lblpwd").text("初始密码:");
                        $("#userpw").attr("type","text");
                        $("#userpw").val("123456");
                        $("#treeroles .checkbox_false_full").css("display","inline-block");
                    }
                    if($("#"+unameid).val()==""){
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
            
            if(umodel.UserName!=""){
                $("#treeroles .checkbox_false_full").css("display","inline-block");
            }
        });
    </script>
    <style type="text/css">
        .nobg {
            height: 28px;line-height:28px;
            background-color: #abbac3!important;
        }
    </style>
</body>
</html>
