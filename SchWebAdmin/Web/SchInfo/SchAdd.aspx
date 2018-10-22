<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchAdd.aspx.cs" Inherits="SchWebAdmin.Web.SchInfo.SchAdd" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>学校操作</title>
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
    <script src="../../assets/CustomFunction/DataVerification.js"></script>
    <link rel="stylesheet" href="css/SchAddStyle.css?v=3" />

            
</head>

<body ontouchstart>

    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>
        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
                <div class="breadcrumbs breadcrumb_box " id="breadcrumbs">
                    <script type="text/javascript">
                        try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
                    </script>

                    <ul class="breadcrumb breadcrumb_border">
                        <li>
                            <%--<i class="icon-home home-icon"></i>--%>
                            目前位置：
                        </li>
                        <%--<li>
                            <a href="#">学校管理</a>
                        </li>--%>
                        <%--将学校信息改为学校及科目信息--%>
                        <li class="active">新建/修改学校基本信息 </li>
                    </ul>
                    <!-- .breadcrumb -->
                </div>

                <div class="page-content content_box">
                    <div class="row">
                        <div class="col-sm-11 ">
                                        <div class="col-sm-12 text-right">
                                            <button class="btn btn-info btn-sm text_size" id="btndo" type="button" onclick="saveuser()">
                                                保存
                                            </button>
                                            &nbsp; &nbsp; &nbsp;
											<button class="btn btn-sm text_size" id="btndoreset" type="button" onclick="notdo()">
                                                取消
                                            </button>

                                        </div>
                                    </div>
                        <div class="col-sm-12 biaoti">基础信息</div>
                                    
                        <div class="col-sm-1"></div>
                    </div>
                    <div class="space-4"></div>
                    <div class="row">
                        <%--减小栅格栏--%>
                        <div class="col-xs-12  col-sm-10 col-sm-offset-1">
                            <!-- PAGE CONTENT BEGINS -->
                            <form class="form-horizontal  " role="form">
                                <div class="space-8"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">学校代码:</label>
                                        </div>
                                        <div class="col-sm-2 input_box">
                                            <input type="text" id="SchIdstr" maxlength="10" class="col-xs-12 col-sm-12" value="" readonly="readonly" />
                                        </div>
                                        <div class="col-sm-1 no-padding text-right">
                                            <label >学校全称:</label>
                                        </div>
                                        <div class="col-sm-2 input_box">
                                            <input type="text" id="schname" placeholder="学校全称" data-toggle="tooltip" title="必填,长度1-25字" onblur="checkTxt(this,'^.{1,25}$')" class="col-xs-12 col-sm-12" maxlength="25" />
                                        </div>
                                        <div class="col-sm-1 no-padding  text-right">
                                            <label >所在区域:</label>
                                        </div>
                                        <div class="col-sm-3 no-padding">
                                            <%=areastr %>
                                        </div>
                                        <div class="col-sm-1 no-padding-right text-right">
                                            <label class="">是否为城区:</label>
                                        </div>
                                        <div class="col-sm-1">
                                            <div class="control-group col-xs-12 col-sm-12 no-padding">
                                                <label>
                                                    <input name="iscity" type="radio" value="1" class="ace" checked="checked">
                                                    <span class="lbl ">是</span>
                                                </label>
                                                &nbsp &nbsp 
                                                <label>
                                                    <input name="iscity" type="radio" value="0" class="ace">
                                                    <span class="lbl ">否</span>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding  text-right ">
                                            <label class="">学校地址:</label>
                                        </div>
                                        <div class="col-sm-2 input_box">
                                            <input type="text" id="schaddr" placeholder="学校地址" data-toggle="tooltip" maxlength="100" title="长度100字" onblur="checkTxt(this,'^.{0,100}$')" class="col-xs-12 col-sm-12 address" />
                                        </div>
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">管理员姓名:</label>
                                        </div>
                                        <div class="col-sm-2 input_box">
                                            <input type="text" id="schmaster" maxlength="10" title="必填,长度1-10字" onblur="checkTxt(this,'^.{1,25}$')" placeholder="系统管理" class="col-xs-12 col-sm-12" value="" />
                                        </div>
                                        <div class="col-sm-1 no-padding text-right text_style ">
                                            <label class="">管理员职务:</label>
                                        </div>
                                        <div class="col-sm-1 text_style input_box">
                                            <input type="text" id="schmasterpst" placeholder="职务" data-toggle="tooltip" maxlength="20"  class="col-xs-12 col-sm-12" />
                                        </div>
                                        <div class="col-sm-1 no-padding  text-right ">
                                            <label >管理员手机:</label>
                                        </div>
                                        <div class="col-sm-3 input_box">
                                            <input type="text" id="schmastertel" data-toggle="tooltip" maxlength="11" title="请输入正确的11位手机号" onblur="checkTxt(this,'^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$')" placeholder="联系电话" class="col-xs-12 col-sm-12 phone" />
                                        </div>
                                    </div>
                                </div>
                                <div class="space-2"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">管理员账号:</label>
                                        </div>
                                        <div class="col-sm-2 input_box">
                                            <input type="text" id="ManagerAcount" title="账号长度需要在6至18位英文字母或数字" onblur="checkTxt(this,'(^$)|^([a-zA-Z0-9]{6,18})$')" maxlength="18" placeholder="" class="col-xs-12 col-sm-12" value="" />
                                        </div>
                                        <div class="col-sm-1 no-padding text-right text_style ">
                                            <label class="">初始密码:</label>
                                        </div>
                                        <div class="col-sm-3 text_style input_box">
                                            <input type="text" id="InitialPwd" placeholder="" data-toggle="tooltip" maxlength="20" title="字母或数字的长度6-18位组合" onblur="checkTxt(this,'(^$)|^([a-zA-Z0-9]{6,18})$')" class="col-xs-12 col-sm-12" readonly="readonly" />
                                        </div>
                                        <div class="col-sm-1 no-padding  text-right ">
                                            <label >一线技术人员:</label>
                                        </div>
                                        <div class="col-sm-1 input_box">
                                            <input type="text" id="FrontlineTechni" readonly="readonly" maxlength="30" title="" class="col-xs-12 col-sm-12" />
                                        </div>
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">创建者:</label>
                                        </div>
                                        <div class="col-sm-1 input_box">
                                            <input type="text" id="Creator" maxlength="10" class="col-xs-12 col-sm-12" value="admin" readonly="readonly" />
                                        </div>
                                    </div>
                                </div>
                                <div class="space-2"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">校长姓名:</label>
                                        </div>
                                        <div class="col-sm-2 input_box">
                                            <input type="text" id="PrincipalName" maxlength="10" class="col-xs-12 col-sm-12" value="" />
                                        </div>
                                        <div class="col-sm-1 no-padding text-right text_style ">
                                            <label class="">校长手机:</label>
                                        </div>
                                        <div class="col-sm-3 text_style input_box">
                                            <input type="text" id="PrincipalTel" placeholder="" data-toggle="tooltip" maxlength="11" title="请输入正确的11位手机号" onblur="checkTxt(this,'^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$')" class="col-xs-12 col-sm-12" />
                                        </div>
                                        <div class="col-sm-1 no-padding  text-right ">
                                            <label >客服人员姓名:</label>
                                        </div>
                                        <div class="col-sm-1 input_box">
                                            <input type="text" id="CustomerServiceStaffName" data-toggle="tooltip" maxlength="10" class="col-xs-12 col-sm-12" />
                                        </div>
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">客服人员电话:</label>
                                        </div>
                                        <div class="col-sm-1 input_box">
                                            <input type="text" id="CustomerServiceStaffNameTel" maxlength="11" title="请输入正确的11位手机号" onblur="checkTxt(this,'^(^$)|0?(13[0-9]|15[012356789]|17[013678]|18[0-9]|14[57])[0-9]{8}$')" class="col-xs-12 col-sm-12" value="" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">学校类型:</label>
                                        </div>
                                        <div class="col-sm-2 input_box">
                                            <select id="Per">
                                            <option value="0">普通学校</option>
                                                <option value="1">大学校园</option>
                                        </select>
                                        </div>
                                        <div class="col-sm-1 no-padding text-right text_style ">
                                            <label class="">入学月份:</label>
                                        </div>
                                        <div class="col-sm-3 text_style input_box">
                                            <select id="DrpM">
                                            <option value="1">1</option>
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
                                    </div>
                                </div>
                                <div class="space-2"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                    <div class="col-sm-12 no-padding text_style">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label >学段及年级:</label>
                                        </div>
                                        <div class="col-sm-11" id="SchoolSection">
                                            
                                        </div>
                                    </div>
                                    </div>
                                </div>
                                <div class="space-2"></div>
                                 <div class="row">
                                     <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding-right text-right ">
                                            <label>开设科目:</label>
                                        </div>
                                        <div class="col-sm-11">
                                            <select id="selsubs" multiple>
                                            </select>
                                            <br />
                                            <div class="btn-group text-right">
                                                <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle button_bg text_size">
                                                    添加科目
													<i class="icon-caret-down icon-on-right"></i>
                                                </button>
                                                <ul id="substree" class="dropdown-menu ztree ">
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-2"></div>
                                 <div class="row">
                                     <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding-right text-right ">
                                            <label for="schnote" class="text_style">毕业年级:</label>
                                        </div>
                                        <div class="col-sm-10" id="Div1">
                                            
                                        </div>
                                    </div>
                                 </div>
                            </form>
                            <!-- PAGE CONTENT ENDS -->
                        </div><!-- /.col -->
                    </div><!-- /.row -->
                    <div class="space-4"></div>
                    <div class="row">
                        <div class="col-sm-12 biaoti">1、管理平台信息</div>
                        <div class="col-sm-11"></div>
                    </div>
                    <div class="space-4"></div>
                    <div class="row">
                        <div class="col-xs-12  col-sm-10 col-sm-offset-1">
                            <!-- PAGE CONTENT BEGINS -->
                            <form class="form-horizontal  " role="form">
                                <div class="space-2"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">平台名称:</label>
                                        </div>
                                        <div class="col-sm-2 input_box">
                                            <input type="text" id="PlatformName" placeholder="请填写管理平台名称" maxlength="20" class="col-xs-12 col-sm-12" value="" />
                                        </div>
                                        <div class="col-sm-1 no-padding text-right text_style ">
                                            <label class="">平台图标:</label>
                                        </div>
                                        <div class="col-sm-2 text_style input_box">
                                            <input type="hidden" id="PlatformIco" data-toggle="tooltip" maxlength="20"  class="col-xs-9 col-sm-9"  readonly="readonly" disabled="disabled"/>
                                            <img id="PlatformIcoimg" style="width:32px;display:none;float:left;margin:3px;" src="" />
                                            <input id="btnfile" name="btnfile" accept="image/gif, image/jpeg, image/jpg" type="file" style="display:none;"/>
                                            <a class="file">上传图标</a>
                                        </div>
                                        <div class="col-sm-1 no-padding  text-right ">
                                            <label >平台域名:</label>
                                        </div>
                                        <div class="col-sm-2 input_box">
                                            <input type="text" id="PlatformUrl" placeholder="格式：http://www.baidu.com" data-toggle="tooltip" maxlength="50" class="col-xs-12 col-sm-12" />
                                        </div>
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">IP地址:</label>
                                        </div>
                                        <div class="col-sm-2 input_box">
                                            <input type="text" id="IPAddress" placeholder="格式：192.168.1.1" maxlength="15" class="col-xs-12 col-sm-12" value="" onblur="checkTxt(this,'^(^[\u4e00-\u9fa5]$')" />
                                        </div>
                                    </div>
                                </div>
                                <div class="space-2"></div>
                               <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding-right text-right ">
                                            <label for="schnote" class="text_style">子系统:</label>
                                        </div>
                                        <div class="col-sm-11" style="font-size:12px;color:gray;">应用首页&nbsp;&nbsp;基础信息
                                            <select id="sonsys" multiple>
                                            </select>
                                            <br />
                                            <div class="btn-group text-right">
                                                <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle button_bg text_size">
                                                    选择子系统
													<i class="icon-caret-down icon-on-right"></i>
                                                </button>
                                                <ul id="sonsystree" class="dropdown-menu ztree  ">
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                               </div>
                               <div class="space-10"></div>
                               <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding-right text-right ">
                                            <label for="schnote" class="text_style">服务状态:</label>
                                        </div>
                                        <div class="col-sm-10" id="SonsysStat">
                                            <span class="Enable" rel="1" style="color:green;">启用</span>
                                        </div>
                                    </div>
                               </div>
                            </form>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="row">
                        <div class="col-sm-12 biaoti">2、资源平台信息</div>
                        <div class="col-sm-11"></div>
                    </div>
                    <div class="space-4"></div>
                    <div class="row">
                        <div class="col-xs-12  col-sm-10 col-sm-offset-1">
                            <!-- PAGE CONTENT BEGINS -->
                            <form class="form-horizontal  " role="form">
                                <div class="space-2"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">平台名称:</label>
                                        </div>
                                        <div class="col-sm-2 input_box">
                                            <input type="text" id="ResourcePlatformName" placeholder="请填写资源平台名称" maxlength="20" class="col-xs-12 col-sm-12" value="" />
                                        </div>
                                        <div class="col-sm-1 no-padding text-right text_style ">
                                            <label class="">平台图标:</label>
                                        </div>
                                        <div class="col-sm-2 text_style input_box">
                                            <input type="hidden" id="ResourcePlatformIco" placeholder="平台图标" data-toggle="tooltip" maxlength="20"  class="col-xs-9 col-sm-9"  readonly="readonly" disabled="disabled"/>
                                            <img id="ResourcePlatformIcoimg" style="width:32px;display:none;float:left;margin:3px;" src="" />
                                            <input id="Resourcebtnfile" name="Resourcebtnfile" accept="image/gif, image/jpeg, image/jpg" type="file" style="display:none;"/>
                                            <a class="Resourcefile">上传图标</a>
                                        </div>
                                        <div class="col-sm-1 no-padding  text-right ">
                                            <label >平台域名:</label>
                                        </div>
                                        <div class="col-sm-2 input_box">
                                            <input type="text" id="ResourcePlatformUrl" placeholder="格式：http://www.baidu.com" data-toggle="tooltip" maxlength="50" class="col-xs-12 col-sm-12" />
                                        </div>
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">IP地址:</label>
                                        </div>
                                        <div class="col-sm-2 input_box">
                                            <input type="text" placeholder="格式：192.168.1.1" id="ResourcePlatformIP" maxlength="15" class="col-xs-12 col-sm-12" value="" />
                                        </div>
                                    </div>
                                </div>
                                <div class="space-10"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">资料科目及教版:</label>
                                        </div>
                                        <div class="col-sm-11 no-padding text-right">
                                            <div class="row" style="margin-right:0px;margin-left:0px;padding-left:5px;">
                                                <div class="col-sm-1 text-left no-padding">
                                                    <label>
                                                        学段：
														<input id="Per1" name="kindergartenPer" class="ace" type="checkbox" value="1">
														<span class="lbl">幼儿园</span>
													</label>
                                                </div>
                                                <div class="col-sm-1 text-left"><label>科目：</label></div>
                                                <div class="col-sm-10 text-left">
                                                    <select id="Tags1" multiple></select>
                                                    <div class="btn-group">
                                                        <button data-toggle="dropdown" id="submatbtn1" class="btn btn-info btn-sm btn_size submatbtn" relid="1">
                                                            添加科目及教版
													            <span class="icon-caret-down icon-on-right"></span>
                                                        </button>
                                                        <div id="downdom1" class="dropdown-menu">
                                                            <div class="col-sm-6 no-padding">
                                                                <div class="EduVerTitle">教版科目</div>
                                                                <ul id="TreeSub1" class="ztree"></ul></div>
                                                            <div class="col-sm-6 no-padding">
                                                                <input type="hidden" id="treesubhidden" class="treesubhidden" />
                                                                <div class="SelectEduTitle" relid="1">选择教版</div>
                                                                <ul id="TreeEduVer1" class="ztree"></ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="margin-right:0px;margin-left:0px;padding-left:5px;">
                                                <div class="col-sm-1 text-left no-padding">
                                                    <label>
                                                        学段：
														<input id="Per2" name="primaryPer" class="ace" type="checkbox" value="2">
														<span class="lbl">小学</span>
													</label>
                                                </div>
                                                <div class="col-sm-1 text-left"><label>科目：</label></div>
                                                <div class="col-sm-10 text-left">
                                                    <select id="Tags2" multiple></select>
                                                    <div class="btn-group">
                                                        <button data-toggle="dropdown" id="submatbtn2" class="btn btn-info btn-sm btn_size submatbtn" relid="2">
                                                            添加科目及教版
													            <span class="icon-caret-down icon-on-right"></span>
                                                        </button>
                                                        <div id="downdom2" class="dropdown-menu" style="clear:both;">
                                                            <div class="col-sm-6 no-padding">
                                                                <div class="EduVerTitle">教版科目</div>
                                                                <ul id="TreeSub2" class="ztree"></ul>
                                                            </div>
                                                            <div class="col-sm-6 no-padding">
                                                                <input type="hidden" id="treesubprimaryhidden" class="treesubhidden" />
                                                                <div class="SelectEduTitle">选择教版</div>
                                                                <ul id="TreeEduVer2" class="ztree"></ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="margin-right:0px;margin-left:0px;padding-left:5px;">
                                                <div class="col-sm-1 text-left no-padding">
                                                    <label>
                                                        学段：
														<input id="Per3" name="juniorPer" class="ace" type="checkbox" value="3">
														<span class="lbl">初中</span>
													</label>
                                                </div>
                                                <div class="col-sm-1 text-left"><label>科目：</label></div>
                                                <div class="col-sm-10 text-left">
                                                    <select id="Tags3" multiple></select>
                                                    <div class="btn-group">
                                                        <button data-toggle="dropdown" id="submatbtn3" class="btn btn-info btn-sm btn_size submatbtn" relid="3">
                                                            添加科目及教版
													            <span class="icon-caret-down icon-on-right"></span>
                                                        </button>
                                                        <div id="downdom3"" class="dropdown-menu" style="margin-left:0px;margin-right:0px;clear:both;">
                                                            <div class="col-sm-6 no-padding">
                                                                <div class="EduVerTitle">教版科目</div>
                                                                <ul id="TreeSub3" class="ztree"></ul>
                                                            </div>
                                                            <div class="col-sm-6 no-padding">
                                                                <input type="hidden" id="treeJuniorhidden" class="treesubhidden" />
                                                                <div class="SelectEduTitle">选择教版</div>
                                                                <ul id="TreeEduVer3" class="ztree"></ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="margin-right:0px;margin-left:0px;padding-left:5px;">
                                                <div class="col-sm-1 text-left no-padding">
                                                    <label>
                                                        学段：
														<input id="Per4" name="HighPer" class="ace" type="checkbox" value="4">
														<span class="lbl">高中</span>
													</label>
                                                </div>
                                                <div class="col-sm-1 text-left"><label>科目：</label></div>
                                                <div class="col-sm-10 text-left">
                                                    <select id="Tags4" multiple></select>
                                                    <div class="btn-group">
                                                        <button data-toggle="dropdown" id="submatbtn4" class="btn btn-info btn-sm btn_size submatbtn" relid="4">
                                                            添加科目及教版
													            <span class="icon-caret-down icon-on-right"></span>
                                                        </button>
                                                        <div id="downdom4"" class="dropdown-menu" style="clear:both;">
                                                            <div class="col-sm-6 no-padding">
                                                                <div class="EduVerTitle">教版科目</div>
                                                                <ul id="TreeSub4" class="ztree"></ul>
                                                            </div>
                                                            <div class="col-sm-6 no-padding">
                                                                <input type="hidden" id="treeHighHidden" class="treesubhidden" />
                                                                <div class="SelectEduTitle">选择教版</div>
                                                                <ul id="TreeEduVer4" class="ztree"></ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-10"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">资源模块:</label>
                                        </div>
                                        <div class="col-sm-11 no-padding text-left">
                                            <select id="tags-soures" multiple></select>
                                            <div class="btn-group">
                                                <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle btn_size">
                                                    添加资源模块
													    <span class="icon-caret-down icon-on-right"></span>
                                                </button>
                                                <ul id="treesoure" class="dropdown-menu ztree">
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-10"></div>
                               <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding-right text-right ">
                                            <label for="schnote" class="text_style">服务状态:</label>
                                        </div>
                                        <div class="col-sm-10" id="SourceServerStat">
                                            <span class="Enable" rel="0" style="color:red;">待启用</span>
                                        </div>
                                    </div>
                               </div>
                            </form>
                        </div>
                    </div>
                    <div class="space-4"></div>
                    <div class="row">
                        <div class="col-sm-12 biaoti">3、家校互通平台</div>
                        <div class="col-sm-11"></div>
                    </div>
                    <div class="space-4"></div>
                    <div class="row">
                        <div class="col-xs-12  col-sm-10 col-sm-offset-1">
                            <!-- PAGE CONTENT BEGINS -->
                            <form class="form-horizontal  " role="form">
                                <div class="space-2"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">平台名称:</label>
                                        </div>
                                        <div class="col-sm-2 input_box">
                                            <input type="text" id="HomeSchoolingName" placeholder="请填写家校互通平台名称" maxlength="20" class="col-xs-12 col-sm-12" value="" />
                                        </div>
                                        <div class="col-sm-1 no-padding text-right text_style ">
                                            <label class="">平台图标:</label>
                                        </div>
                                        <div class="col-sm-2 text_style input_box">
                                            <input type="hidden" id="HomeSchoolingIco" placeholder="平台图标" data-toggle="tooltip" maxlength="20"  class="col-xs-9 col-sm-9"  readonly="readonly" disabled="disabled"/>
                                            <img id="HomeSchoolingImg" style="width:32px;display:none;float:left;margin:3px;" src="" />
                                            <input id="HomeSchoolingBtnFile" name="HomeSchoolingBtnFile"  accept="image/gif, image/jpeg, image/jpg" type="file" style="display:none;"/>
                                            <a class="HomeSchoolingfile">上传图标</a>
                                        </div>
                                        <div class="col-sm-1 no-padding  text-right ">
                                            <label >平台域名:</label>
                                        </div>
                                        <div class="col-sm-2 input_box">
                                            <input type="text" id="HomeSchoolingUrl" placeholder="格式：http://www.baidu.com" data-toggle="tooltip" maxlength="50" class="col-xs-12 col-sm-12" />
                                        </div>
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">IP地址:</label>
                                        </div>
                                        <div class="col-sm-2 input_box">
                                            <input type="text" placeholder="格式：192.168.1.1" id="HomeSchoolingIP" maxlength="15" class="col-xs-12 col-sm-12" value="" />
                                        </div>
                                    </div>
                                </div>
                                <div class="space-10"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">科目及教版:</label>
                                        </div>
                                        <div class="col-sm-11 no-padding text-left">
                                            <div class="row" style="margin-right:0px;margin-left:0px;padding-left:5px;">
                                                <div class="col-sm-1 text-left no-padding">
                                                    <label>
                                                        学段：
														<input id="HomSchPer1" name="kindergartenPer" class="ace" type="checkbox" value="1">
														<span class="lbl">幼儿园</span>
													</label>
                                                </div>
                                                <div class="col-sm-1 text-left"><label>科目：</label></div>
                                                <div class="col-sm-10 text-left">
                                                    <select id="TagsHomSch1" multiple></select>
                                                    <div class="btn-group">
                                                        <button data-toggle="dropdown" id="homsubmatbtn1" class="btn btn-info btn-sm btn_size submatbtn" relid="1">
                                                            添加科目及教版
													            <span class="icon-caret-down icon-on-right"></span>
                                                        </button>
                                                        <div id="downhomsch1" class="dropdown-menu">
                                                            <div class="col-sm-6 no-padding">
                                                                <div class="EduVerTitle">教版科目</div>
                                                                <ul id="TreeHomSchSub1" class="ztree"></ul></div>
                                                            <div class="col-sm-6 no-padding">
                                                                <input type="hidden" id="Hidden1" class="treesubhidden" />
                                                                <div class="SelectEduTitle" relid="1">选择教版</div>
                                                                <ul id="TreeHomSchMat1" class="ztree"></ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="margin-right:0px;margin-left:0px;padding-left:5px;">
                                                <div class="col-sm-1 text-left no-padding">
                                                    <label>
                                                        学段：
														<input id="HomSchPer2" name="primaryPer" class="ace" type="checkbox" value="2">
														<span class="lbl">小学</span>
													</label>
                                                </div>
                                                <div class="col-sm-1 text-left"><label>科目：</label></div>
                                                <div class="col-sm-10 text-left">
                                                    <select id="TagsHomSch2" multiple></select>
                                                    <div class="btn-group">
                                                        <button data-toggle="dropdown" id="homsubmatbtn2" class="btn btn-info btn-sm btn_size submatbtn" relid="2">
                                                            添加科目及教版
													            <span class="icon-caret-down icon-on-right"></span>
                                                        </button>
                                                        <div id="downhomsch2" class="dropdown-menu" style="clear:both;">
                                                            <div class="col-sm-6 no-padding">
                                                                <div class="EduVerTitle">教版科目</div>
                                                                <ul id="TreeHomSchSub2" class="ztree"></ul>
                                                            </div>
                                                            <div class="col-sm-6 no-padding">
                                                                <input type="hidden" id="Hidden2" class="treesubhidden" />
                                                                <div class="SelectEduTitle">选择教版</div>
                                                                <ul id="TreeHomSchMat2" class="ztree"></ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="margin-right:0px;margin-left:0px;padding-left:5px;">
                                                <div class="col-sm-1 text-left no-padding">
                                                    <label>
                                                        学段：
														<input id="HomSchPer3" name="juniorPer" class="ace" type="checkbox" value="3">
														<span class="lbl">初中</span>
													</label>
                                                </div>
                                                <div class="col-sm-1 text-left"><label>科目：</label></div>
                                                <div class="col-sm-10 text-left">
                                                    <select id="TagsHomSch3" multiple></select>
                                                    <div class="btn-group">
                                                        <button data-toggle="dropdown" id="homsubmatbtn3" class="btn btn-info btn-sm btn_size submatbtn" relid="3">
                                                            添加科目及教版
													            <span class="icon-caret-down icon-on-right"></span>
                                                        </button>
                                                        <div id="downhomsch3"" class="dropdown-menu" style="margin-left:0px;margin-right:0px;clear:both;">
                                                            <div class="col-sm-6 no-padding">
                                                                <div class="EduVerTitle">教版科目</div>
                                                                <ul id="TreeHomSchSub3" class="ztree"></ul>
                                                            </div>
                                                            <div class="col-sm-6 no-padding">
                                                                <input type="hidden" id="Hidden3" class="treesubhidden" />
                                                                <div class="SelectEduTitle">选择教版</div>
                                                                <ul id="TreeHomSchMat3" class="ztree"></ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="margin-right:0px;margin-left:0px;padding-left:5px;">
                                                <div class="col-sm-1 text-left no-padding">
                                                    <label>
                                                        学段：
														<input id="HomSchPer4" name="HighPer" class="ace" type="checkbox" value="4">
														<span class="lbl">高中</span>
													</label>
                                                </div>
                                                <div class="col-sm-1 text-left"><label>科目：</label></div>
                                                <div class="col-sm-10 text-left">
                                                    <select id="TagsHomSch4" multiple></select>
                                                    <div class="btn-group">
                                                        <button data-toggle="dropdown" id="homsubmatbtn4" class="btn btn-info btn-sm btn_size submatbtn" relid="4">
                                                            添加科目及教版
													            <span class="icon-caret-down icon-on-right"></span>
                                                        </button>
                                                        <div id="downhomsch4"" class="dropdown-menu" style="clear:both;">
                                                            <div class="col-sm-6 no-padding">
                                                                <div class="EduVerTitle">教版科目</div>
                                                                <ul id="TreeHomSchSub4" class="ztree"></ul>
                                                            </div>
                                                            <div class="col-sm-6 no-padding">
                                                                <input type="hidden" id="Hidden4" class="treesubhidden" />
                                                                <div class="SelectEduTitle">选择教版</div>
                                                                <ul id="TreeHomSchMat4" class="ztree"></ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-10"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding text-right">
                                            <label class="">子模块:</label>
                                        </div>
                                        <div class="col-sm-11 no-padding text-left">
                                            <select id="tags-homeSching" multiple></select>
                                            <div class="btn-group">
                                                <button data-toggle="dropdown" class="btn btn-info btn-sm dropdown-toggle btn_size">
                                                    添加子模块
													    <span class="icon-caret-down icon-on-right"></span>
                                                </button>
                                                <ul id="treehomesch" class="dropdown-menu ztree">
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="space-10"></div>
                                <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding-right text-right ">
                                            <label for="schnote" class="text_style">基础数据维护:</label>
                                        </div>
                                        <div class="col-sm-10" id="HomeSchoolBaxicStat">
                                            <span class="Enable" rel="0" style="color:red;">客服维护</span>
                                        </div>
                                    </div>
                               </div>
                                <div class="space-10"></div>
                               <div class="row">
                                    <div class="form-group form-inline">
                                        <div class="col-sm-1 no-padding-right text-right ">
                                            <label for="schnote" class="text_style">服务状态:</label>
                                        </div>
                                        <div class="col-sm-10" id="HomeSchoolServStat">
                                            <span class="Enable" rel="0" style="color:red;">待启用</span>
                                        </div>
                                    </div>
                               </div>
                            </form>
                        </div>
                    </div>
                </div>
                <!-- /.page-content -->
            </div>
            <!-- /.main-content -->

            <!-- /#ace-settings-container -->
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
    <script type="text/javascript" src="../../assets/js/jquery.cookie.js"></script>
    <!-- (Optional) Latest compiled and minified JavaScript translation files -->
    <script type="text/javascript">
        function fileChange(target) {  //filefujianChange
            var fileSize = 0;           
            if (isIE && !target.files) {       
                var filePath = target.value;       
                var fileSystem = new ActiveXObject("Scripting.FileSystemObject");          
                var file = fileSystem.GetFile (filePath);       
                fileSize = file.Size;      
            } else {      
                fileSize = target.files[0].size;       
            }     
            var size = fileSize / 1024;      
            if(size>2000){    
                alert("附件不能大于2M");  
                target.value="";  
                return  
            }  
            var name=target.value;  
            var fileName = name.substring(name.lastIndexOf(".")+1).toLowerCase();  
            if(fileName !="jpg" && fileName !="jpeg" && fileName !="png" && fileName !="gif" ){  
                alert("请选择图片格式文件上传(jpg,png,gif,gif等)！");  
                target.value="";  
                return  
            }  
        }
    </script>

    <script type="text/javascript">
        var schid='<%=schid%>';
        var treeSonsysObj;//子系统树对象
        var treesubsObj;//科目树对象
        var treegradesNodes =<%=grades%>; 
        var treesubsNodes =<%=subs%>;
        var treesonsysNodes =<%=sonsys%>;
        var treeNodeMater =<%=sysmatertree%>;
        var treeNodessoure =<%=souretree%>;
        var treeNodesdept =<%=deptsuser%>;
        var treeNodesSubss = <%=subsmat%>;
        var usertname = "<%=usertname%>";
        var treeNodeHomSch=<%=homeschtree%>;

        //遍历学段、年级的DOM
        var SchoolSection="";
        var mydate = new Date();
        var sysyearcurrent = mydate.getFullYear();
        var sysmonth = mydate.getMonth();
        var StartYear="";
        if(sysmonth<8){StartYear=sysyearcurrent-1;}else{StartYear=sysyearcurrent;}
        $.each(treegradesNodes,function(index,item){
            if(item.pId=="0"){
                //alert(item.GradeYear);
                SchoolSection+="<div class=\"row\">";
                SchoolSection+="    <div class=\"col-sm-1 no-padding\">";
                SchoolSection+="        <label>&nbsp;&nbsp;<span class=\"color\">学段：</span></label>";
                SchoolSection+="        <label>";
                SchoolSection+="            <input name=\"gradechkl\" type=\"checkbox\" class=\"ace\" value=\""+item.id+"\" />";
                SchoolSection+="            <span class=\"lbl\">"+item.name+"</span>";
                SchoolSection+="        </label>";
                SchoolSection+="    </div>";
                //SchoolSection+="    <div class=\"col-sm-11 no-padding\">";
                SchoolSection+="    <div class=\"col-sm-1 no-padding text-center nianji\"><label><span class=\"color\">年级：</span></label></div>";
                SchoolSection+="    <div class=\"col-sm-10 no-padding\">";
                SchoolSection+="    <div class=\"row\">";
                $.each(treegradesNodes,function(indexs,items){
                    if(item.id==items.pId&&items.IsFinish=="0"){
                        SchoolSection+="<div class=\"col-sm-2 no-padding\">";
                        SchoolSection+="    <label>";
                        SchoolSection+="        <input name=\"gradechk\" type=\"checkbox\" class=\"ace\" StartYear=\""+StartYear+"\" GradeName=\""+items.name+"\" GradeId=\""+items.GradeId+"\" value=\""+items.id+"\" disabled=\"disabled\">";
                        SchoolSection+="        <span class=\"lbl\">"+items.name+"【"+StartYear+"级】</span>";
                        SchoolSection+="    </label>";
                        SchoolSection+="</div>";
                        StartYear--;
                    }
                })
                SchoolSection+="    </div>";
                SchoolSection+="    </div>";
                SchoolSection+="    </div>";
                //SchoolSection+="</div>";
            }
            
            if(item.id=="1"||item.id=="2"||item.id=="3"||item.id=="4"){
                if(sysmonth<8){
                    StartYear=sysyearcurrent-1;
                }else{
                    StartYear=sysyearcurrent;
                }
            }

        });
        $("#SchoolSection").html(SchoolSection);

        //下拉部门框点击屏蔽
        $('.dropdown-menu').click(function(e) {
            e.stopPropagation();
        });

        $('.ztree .row').click(function(e) {
            e.stopPropagation();
        });
       
        //取消按钮执行函数
        function notdo()
        { 
            window.history.go(-1);
        }
        

        function checkTxt(o,reg){
            var re = new RegExp(reg);
            if (re.test($(o).val())) {
                //判断账号是否为空
                var unameid = $(o).attr("id");
                if(unameid =="ManagerAcount"){
                    if($(o).val()!=""){
                        //判断账号是否存在
                        var params = '{"usertname":"' + $(o).val() + '","schid":"' + schid + '"}';
                        $.ajax({
                            type: "POST",  //请求方式
                            url: "SchAdd.aspx/existuser",  //请求路径：页面/方法名字
                            data: params,     //参数
                            dataType: "json",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                if (data.d.code== "expire") 
                                {
                                    window.location.href = "../../LoginExc.aspx";
                                }
                                else if(data.d.code== "error")
                                {
                                    alert(data.d.msg);
                                }
                            },
                            error: function (obj, msg, e) {
                            }
                        });
                    }
                    //密码框的行为样式
                    if($("#"+unameid).val()!="undefined"||$("#"+unameid).val()!=""){
                        $("#InitialPwd").attr("type","text");
                        $("#InitialPwd").val("123456");
                    }
                    if($("#"+unameid).val()==""){
                        $("#InitialPwd").val("");
                    }
                }
                return true;
            }else{
                $(o).tooltip('show');
                $(o).focus();
                return false;
            }
            
        }
       
        $(document).ready(function(){
            $("#FrontlineTechni").val(usertname);
            $("#Creator").val(usertname);
            var sonsysstatrel = $("#SonsysStat .Enable").attr("rel");//获取管理平台状态
            var resourcestatrel = $("#SourceServerStat .Enable").attr("rel");//获取资源平台状态
            if(sonsysstatrel=="1" || sonsysstatrel=="1"){//如果管理平台与资源平台其中之一为启用状态时，家校互通平台的服务状态为“学校维护”
                $("#HomeSchoolBaxicStat .Enable").attr("rel","1");
                $("#HomeSchoolBaxicStat .Enable").html("学校维护");
                $("#HomeSchoolBaxicStat .Enable").css("color","green");
            }else{
                $("#HomeSchoolBaxicStat .Enable").attr("rel","0");
                $("#HomeSchoolBaxicStat .Enable").html("客服维护");
                $("#HomeSchoolBaxicStat .Enable").css("color","green");
            }
        });
    </script>
    <script type="text/javascript" src="js/SonSubSelectAdd.js"></script>
    <script type="text/javascript" src="js/SourceModelsAdd.js"></script>
    <script type="text/javascript" src="js/SectionGradeAdd.js"></script>
    <script type="text/javascript" src="js/DataSubEduVerAdd.js"></script><!--学校添加页面的资料科目及教版-->
    <script type="text/javascript" src="js/LinkageAdd.js?v=1.1"></script><!--省市区联动-->
    <script type="text/javascript" src="js/SaveSchAdd.js?v=1.0"></script><!--学校添加页面的数据收集以及保存-->
    <script type="text/javascript" src="../../assets/js/ajaxfileupload.js"></script><!--学校添加页面的上传图标类库-->
    <script type="text/javascript" src="js/UploadicoAdd.js"></script><!--学校添加页面的上传图标-->
    <script type="text/javascript" src="js/SCHXXTModelsAdd.js"></script><!--家校互通子模块-->
    <script type="text/javascript" src="js/SchXXTSubMatAdd.js"></script><!--学校添加页面的家校互通平台科目及教版-->
</body>
</html>