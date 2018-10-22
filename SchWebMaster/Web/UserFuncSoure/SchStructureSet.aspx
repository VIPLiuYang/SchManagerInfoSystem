<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchStructureSet.aspx.cs" Inherits="SchWebMaster.Web.UserFuncSoure.SchStructureSet" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>学校信息维护</title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" /> 

    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,300" />

    <!-- ace styles -->

    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <link rel="stylesheet" href="../../assets/css/metrodpt.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>

    <style>
        /*输入框中字体的颜色*/
        .form input {
            color: #999999!important;
        }

        .form-control, select, input {
            font-family: "微软雅黑" !important;
            color: #999999!important;
            font-size: 12px !important;
            margin-left: 10px;
            margin-right: 10px;
        }
       
        i {
            font-family: FontAwesome !important;
        }
        /*所在位置的提示高度*/
        .breadcrumbs {
            min-height: 32px;
            line-height: 30px;
        }
        /*所在位置的背景边框*/
        .breadcrumb_box {
            background: white;
            border-bottom: 1px solid #e4e4e4;
            margin-bottom: 20px;
        }
        /*坐在位置的坐边竖线*/
        .breadcrumb_border {
            border-left: 2px solid #63bbff;
            margin-left: 0px;
            padding-left: 12px;
        }
        /*表格标题栏字体大小，颜色*/

        .table thead > tr > th > td {
            font-family:微软雅黑;
            font-size: 13px;
            color: #444444 !important;
            font-weight: bold !important;
            letter-spacing: 1px !important;
            text-align: center !important;
            line-height: 1.5 !important;
        }
        /*表格的内容区字体大小颜色*/
        .table tbody > tr > td {
            font-family:微软雅黑;
            color: #666666 !important;
            font-size: 13px !important;
            text-align: center !important;
            line-height: 1.5 !important;
            vertical-align: middle;
            padding: 0px;
        }

        /*框中的部门名称等标题大小大小的字体大小*/
        .biaoti {
            font-family:微软雅黑;
            font-size: 13px;
            color: #000000;
        }
        /*部门名称边距*/
        .bumenbianju {
            margin-top: 20px;
            margin-bottom: 10px;
        }
        /*保存按钮边距*/
        .baocunbianju {
            margin-top: 10px;
        }
        /*位置提示字体大小*/
        .breadcrumb > li {
            font-family:微软雅黑;
            font-size: 13px !important;
            color: #666666 !important;
        }
        /*学校名称等左边标签的样式*/
        .text_style {
            font-family:微软雅黑;
            /*font-size: 15px !important;*/
            line-height: 30px !important;
            color: #333333 !important;
        }
        /*搜索栏的字体颜色*/
        .input-group {
            font-family:微软雅黑;
            font-size: 14px;
            color: #000000;
        }
        /*输入框字体的颜色*/
        input[type="text"] {
            font-family:微软雅黑;
            color: #999999;
            font-size: 12px;
        }

        /*input中placeholder的颜色*/
        input::-webkit-input-placeholder, textarea::-webkit-input-placeholder { /* WebKit*/
            color: #999999;
            font-size: 12px;
            font-family:微软雅黑;
        }

        input:-moz-placeholder, textarea:-moz-placeholder { /* Mozilla Firefox 4 to 18 */
            color: #999999;
            font-size: 12px;
            font-family:微软雅黑;
        }

        input::-moz-placeholder, textarea::-moz-placeholder { /* Mozilla Firefox 19+ */
            color: #999999;
            font-size: 12px;
            font-family:微软雅黑;
        }

        input:-ms-input-placeholder, textarea:-ms-input-placeholder { /* IE 10+ */
            color: #999999;
            font-size: 12px;
            font-family:微软雅黑;
        }
        /*按钮的字体大小*/
        .text_size {
            font-size: 12px;
            font-family:微软雅黑;
        }
        /*部门结构、部门信息标题样式*/
        .title1 {
            font-size: 13px;
            font-weight: bold;
            letter-spacing: 1px;
            color: #444444;
            font-family:微软雅黑;
        }
        /*部门结构中的树的行高*/
        .ztree li {
            line-height: 6px;
        }

        .ztree li a {
            color: #666666;
       }
        /*部门结构中的字体样式*/
        .ztree li a span:nth-child(2) {
            font-family:微软雅黑;
            font-size:13px;
        }
       

        .dropdown > p > span {
            display: none;
        }

        @media screen and (min-width: 768px) {
            .modal-dialog {
                padding-top: 100px;
            }
        }
        /*添加班级弹出框中班级选择的行距*/
        .modal-body > div > div {
            padding-top: 2px;
            padding-bottom: 2px;
        }
        /*弹出框表头的颜色*/
        .bootstrap-dialog.type-warning .modal-header {
            background-color: #ffffff !important;
        }
        /*弹出框表头标题的颜色大小*/
        .bootstrap-dialog .bootstrap-dialog-title {
            font-family:微软雅黑;
            font-size: 18px !important;
            color: #f96161 !important;
        }
        /*确定按钮的颜色*/
        .btn-warning {
            background-color: #428bca !important;
            border-color: #428bca;
        }
            /*确定按钮鼠标移动到上边时的颜色*/
            .btn-warning:hover {
                background-color: #1b6aaa!important;
                border-color: #428bca;
            }

        .jianju {
            margin-left: 5px;
            margin-right: 5px;
        }
        /*弹出框的标题样式*/
        .title-style {
            font-family:微软雅黑;
            font-size:14px;
            font-weight:bold;
            letter-spacing:1px;
        }
        .btn-style {
            font-family:微软雅黑;
            font-size:12px;
        }
    </style>

    <style type="text/css">
        .ban_body {
            height: 100%;
            overflow: hidden;
        }

        .fl {
            float: left;
        }

        .fr {
            float: right;
        }

        .cls {
            clear: both;
        }
        /*#SchClassSettingData tr td {line-height:27px;}*/
        /*面包屑导航左边样式*/
        .breadcrumb_border {
            border-left: 2px solid #63bbff;
            margin-left: 0px;
            padding-left: 12px;
        }
        /*面包屑导航背景样式*/
        .breadcrumb_box {
            background: white;
            border-bottom: 1px solid #e4e4e4;
        }
        /*开设科目、班级设置和部门设置大标题的样式*/
        .subleadertitle {
            font-family:微软雅黑;
            color: #000000;
            font-size: 14px;
            font-weight: bold;
            letter-spacing: 1px;
            height: 20px;
            line-height: 20px;
        }

        #SchOpenSub {
            font-family:微软雅黑;
            line-height: 20px;
            height: 20px;
            font-size: 13px;
            color: #666666;
        }

        #SchClassSetting #SchClassSettingData thead tr td {
            font-family:微软雅黑;
            text-align: center;
            font-weight: bold;
            font-size: 13px;
            color: #444444 !important;
            letter-spacing: 1px !important;
            line-height: 1.5 !important;
        }
        /* dropdown */
        .dropdown { /*width:186px;margin:0 auto;*/
            margin-left: 15px;
            margin-top: 5px;
            position: relative;
        }

            .dropdown p {
                font-size: 12px;
                width: 72px;
                height: 24px;
                line-height: 24px;
                text-align: center;
                border: 1px solid #3C9BFF;
                color: #3C9BFF;
                cursor: pointer;
                margin: 0px;
            }
        /*.dropdown ul{width:72px; background:#ffffff;margin-top:2px; border:1px solid #A3A2A3; position:absolute; display:none;margin:0;padding:0;z-index:9;}
        .dropdown ul li{height:30px; line-height:30px; text-indent:10px;list-style-type:none;border-bottom:#E5E5E5 solid 1px;}
        .dropdown ul li:last-child{border-bottom:none;}
        .dropdown ul li a{display:block; height:30px; color:#807a62; text-decoration:none;}
        .dropdown ul li a:hover{background:#c6dbfc; color:#369}
        */
        .SchClassResult {
            margin: 0px 0px auto 10px;
            color: #B4B3B5;
            line-height: 24px;
        }

            .SchClassResult .item {
                border: #CDCDCD solid 1px;
                margin: 5px;
                padding-left: 5px;
                padding-right: 5px;
            }

                .SchClassResult .item .closeitem {
                    margin-left: 10px;
                    font-size: 12px;
                    border: 0px;
                    line-height: 22px;
                    cursor: pointer;
                }

        #EditCfmGradeClass .modal-body input {
            width: 20px;
            height: 20px;
            margin: 0px;
        }

        #EditCfmGradeClass .modal-body .classtit {
            width: 48px;
            height: 20px;
            font-family:微软雅黑;
        }

        #EditCfmGradeClass .modal-body .row {
            padding: 5px 0px 5px 0px;
        }
        .ztree li a.curSelectedNode span:nth-child(2) {
    color: #428bca !important;
    font-weight:bold;
}
        .ztree li a.curSelectedNode {
    padding-top: 0px;
    background-color: #ffffff;
    
    height: 21px;
    opacity: 0.8;
}
    </style>
</head>
<body>
    <div class="main-container" id="main-container">
        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">
                <!--面包屑导航-->
                <div class="breadcrumbs breadcrumb_box " id="breadcrumbs">
                    <ul class="breadcrumb breadcrumb_border ziti">
                        <li>目前位置：</li>
                        <li class="active">学校架构设置</li>
                    </ul>
                </div>
                <!--//面包屑导航-->
                <!--面包屑导航右侧的返回按钮-->
                <!--<div class="nav-search" id="nav-search" style="font-family: 微软雅黑">
                    <a class=" pull-right " href="javascript:window.history.go(-1);">
                        <i class="icon-reply icon-only"></i>返回
                    </a>
                </div>-->
                <!--//面包屑导航右侧的返回按钮-->
                <div class="page-content">
                    <!--开设科目-->
                    <div class="row">
                        <div class="col-sm-1 no-padding text-center subleadertitle">开设科目：</div>
                        <div class="col-sm-11 no-padding-left" id="SchOpenSub">
                            <%=schsubname %>
                        </div>
                    </div>
                    <!--//开设科目-->
                    <div class="space-10"></div>
                    <!--班级设置-->
                    <div class="row">
                        <div class="row no-margin-right no-margin-left">
                            <div class="col-sm-1 no-padding text-center subleadertitle">班级设置：</div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-1 no-padding"></div>
                        <div class="col-sm-11 no-padding-left" id="SchClassSetting">
                            <table id="SchClassSettingData" class="table table-striped table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <td class="col-sm-1">年级</td>
                                        <td>班级</td>
                                    </tr>
                                </thead>
                                <tbody id="SchClassSettBody"></tbody>
                            </table>
                        </div>
                    </div>
                    <!--//班级设置-->
                    <div class="space-10"></div>
                    <!--部门架构-->
                    <div class="row" id="searchbar">
                        <div class="col-xs-12">
                            <div class="col-sm-12">
                                <div class="col-sm-9">
                                    <div class="input-group pull-right">
                                        <%=areastr %>
                                        <button class="btn btn-sm btn-info text_size" type="button" onclick="search();">查询</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="space-10"></div>
                    <div class="row">
                        <div class="row no-margin-right no-margin-left">
                            <div class="col-sm-1 no-padding text-center subleadertitle">部门设置：</div>
                        </div>
                    </div>
                    <div class="space-10"></div>
                    <div class="row">
                        <div class="col-sm-1 no-padding"></div>
                        <div class="col-xs-11 no-padding">
                          
                            <div class="col-sm-4 no-padding">
                                <div class="widget-box" style="margin: 0px;">
                                    <div class="widget-header widget-header-flat" id="tjbm">
                                        <h4 class="title1" >部门结构</h4>
                                        
                                    </div>
                                    <div class="widget-body">
                                        <div class="widget-main">
                                            <div class="row">
                                                <ul id="treedept" class="ztree"></ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-8">
                                <div class="widget-box" style="margin: 0px;display:none;" id="widget-box-right">
                                    <div class="widget-header widget-header-flat">
                                        <h4 class="title1" id="titlestr">部门信息</h4>
                                    </div>

                                    <div class="widget-body">
                                        <div class="widget-main">
                                            <div class="row bumenbianju text_style">
                                                <div class="col-sm-2 no-padding-right text-right ">
                                                    <label class=" biaoti">部门名称:</label>
                                                </div>
                                                <div class="col-sm-6 form no-padding-left">
                                                    <input  type="text" maxlength="10" id="dptname" placeholder="部门名称" />
                                                </div>

                                            </div>
                                            <div class="row text_style">
                                                <div class="col-sm-2 no-padding-right text-right ">
                                                    <label class=" biaoti">上级部门:</label>
                                                </div>
                                                <div class="col-sm-6 no-padding-left">
                                                    <select id="dptp">
                                                        <option value="0">顶级部门</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="row" id="dptstatdiv">
                                                <div class="col-sm-2 no-padding-right">
                                                    <label>状态:</label>
                                                </div>
                                                <div class="col-sm-6">
                                                    <select id="dptstat">
                                                        <option value="1">正常</option>
                                                        <option value="0">停用</option>
                                                    </select>
                                                </div>
                                            </div>
                                           
                                            <div class="row bumenbianju" id="orderidbtn" style="display:none;">
                                                <div class="col-sm-2 no-padding-right text-right biaoti">排序:</div>
                                                <div class="col-sm-6">
                                                    <input type="button" name="MoveUp" class="MoveUp jianju" rel_id="up" value="上移"/ >
                                                    <input type="button" name="MoveDown" class="MoveDown jianju" rel_id="down" value="下移"/>
                                                </div>
                                            </div>
                                            <div class="space-10"></div>
                                            <div class="row" >
                                                <div class="col-sm-4 col-sm-offset-2">
                                                    <button id="savebtn" class="btn btn-sm btn-info baocunbianju btn-style" type="button">
                                                        保存
                                                    </button>
                                                    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
										            <button id="cancelbtn" class="btn btn-sm baocunbianju btn-style" onclick="RoleAdd(1,1,'2')" >
                                                            取消
                                                    </button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--//部门设置-->
                    <div class="space-10"></div>
                </div><!--.page-content-->
            </div><!--.main-content-->
        </div><!--.main-container-inner-->
    </div><!--.main-container-->

    <!-- 模态框   打开班级模态框 -->
    <div class="modal fade" id="EditCfmGradeClass">
        <div class="modal-dialog" style="width: 45%; height: 65%;">
            <div class="modal-content message_align" style="width: 100%; /*height: 95%;*/">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                    <h4 class="modal-title title-style">班级信息</h4>
                </div>
                <div class="modal-body"></div>
                <div class="modal-footer" style=" margin-top: 0px;">
                    <button type="button" class="btn btn-default btn-style" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-primary btn-style" id="SchClassSaveData" onclick="donull()">保存</button>
                </div>
            </div>
        </div>
    </div>
    <!-- //模态框   打开新建班级模态框 -->

    <script type="text/javascript">
        window.jQuery || document.write("<script src='../../assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
    </script>
    <script src="../../assets/js/bootstrap.min.js"></script>
    <script src="../../assets/js/typeahead-bs2.min.js"></script>
      <link href="../../assets/css/bootstrap-dialog.css" rel="stylesheet" />
    <script src="../../assets/js/bootstrap-dialog.js"></script>
    <!-- ace scripts -->

    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>
     <script src="../../assets/js/bootstrap-paginator.js"></script>

    <script src="../../assets/js/jquery.ztree.all-3.5.min.js"></script>
    <!-- inline scripts related to this page -->


</body>
</html>
<script type="text/javascript">
    var txtname = '';
    var schid = '<%=schid%>';
    var ustat = '';
    var cotycode = '<%=cotycode%>';
    var schgradeinfo = <%=schgradeinfo%>;    
    var isedit = '<%=isedit%>';
    var isdel = '<%=isdel%>';
    var islook = '<%=islook%>';
    var isadd = '<%=isadd%>';
    // $(function () {
    if (isadd=="True") {
        $("#tjbm").html("<a class=\"btn btn-link pull-right\" href=\"javascript:RoleAdd(1,1,'2')\"><i class=\"icon-plus bigger-125\" title=\"添加部门\" style=\"line-height:28px\"></i></a>");
      
    }   
        
    //班级设置--Start
    //判断数组是否是从1开始的连续数字
    function isContinuationInteger(array){
        if(!array){
            return false;//数组为null
        }
        if(array.length==0){
            return true;//数组为[]
        }
        var len=array.length;
        var arr0=array[0];
        if(arr0!="01"){return false;}
        var sortDirection=1;//默认升序
        if(array[0]>array[len-1]){
            sortDirection=-1;//降序
        }
            
        var isContinuation=true;
        for(var i=0;i<len;i++){
            var s = (i+arr0*sortDirection);
            var ss = parseInt(array[i]);
            if(parseInt(array[i])!==(i+arr0*sortDirection)){
                isContinuation=false;
                break;
            }
        }
        return isContinuation;
    }
        
    function getClassData(){
        var params = '{"schid":"' + schid + '"}';
        $.ajax({
            type: "POST",  //请求方式
            url: "SchStructureSet.aspx/getclassdatas",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                doclassdom(eval("(" + data.d + ")"));
                //alert($("#SchClassSettBody .SchClassResult").html());
                /*var sss = $("#SchClassSettBody .SchClassResult");
                var ssslen = $("#SchClassSettBody .SchClassResult").length;
                for(var i=0;i<ssslen;i++){
                    if($(sss[i]).html()=="         "){alert($(sss[i]).html());
                        $("#SchClassSettBody .SchClassResult").html("<span class=\"default\">请创建新班级</span>");
                    }
                }*/
            },
            error: function (obj, msg, e) {
            }
        });
    }
    function getSchSub(){
        var params = '{"schid":"' + schid + '"}';
        $.ajax({
            type: "POST",  //请求方式
            url: "SchStructureSet.aspx/getschsub",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#SchOpenSub").html(data.d);
            },
            error: function (obj, msg, e) {
                alert(msg);
            }
        });
    }
    function getSchGrade(){
        var params = '{"schid":"' + schid + '"}';
        $.ajax({
            type: "POST",  //请求方式
            url: "SchStructureSet.aspx/getschgrade",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                schgradeinfo = eval(data.d);
                //doclassdomalert(eval(schgradeinfo));
            },
            error: function (obj, msg, e) {
                alert(msg);
            }
        });
    }
    function doclassdom(data){
        if (schgradeinfo != null && schgradeinfo != "") {
            var schgradedom = "";var schgradedoms = "";
            $.each(schgradeinfo, function (index, item) { //遍历返回的json
                schgradedom +="<tr>";
                schgradedom +="     <td class=\"text-center\">"+item.GradeName+"</td>";
                schgradedom +="     <td>";
                schgradedom +="         <div id=\"SchClassResult"+item.GradeId+"\" class=\"SchClassResult fl\">";
                $.each(data,function(indexs,items){
                    if(item.GradeId==items.GradeId){
                        //schgradedom +="<input type=\"hidden\" name=\"valname\" gradeid=\""+item.GradeId+"\" value=\""+items.ClassName+"\" />";
                        schgradedom +="<div class=\"item fl\" val=\"" + items.ClassId + "\" ><input type=\"hidden\" name=\"valname\" gradeid=\""+item.GradeId+"\" value=\""+items.ClassName+"\" />" + items.ClassName ;
                        if (isdel == "True") {
                            schgradedom+=   "<span class=\"closeitem\">X</span>";
                        }
                        schgradedom +=" </div>";
                    }
                });
                if (isadd == "True") {
                    schgradedom +="     <div class=\"dropdown fl\">";
                    schgradedom +="         <p gradecode=\""+item.GradeYear+"\" gradeid=\""+item.GradeId+"\" gradename=\""+item.GradeName+"\">添加班级<span>&or;</span></p>";
                    schgradedom +="     </div>";
                }
                schgradedom +="         </div>";
                /*if (isadd == "True") {
                    schgradedom +="     <div class=\"dropdown fl\">";
                    schgradedom +="         <p gradecode=\""+item.GradeYear+"\" gradeid=\""+item.GradeId+"\" gradename=\""+item.GradeName+"\">添加班级<span>&or;</span></p>";
                    schgradedom +="     </div>";
                }*/
                schgradedom +="         <div class=\"cls\"></div>";
                schgradedom +="     </td>";
                schgradedom +="</tr>";
            });
            $("#SchClassSettBody").html(schgradedom);
        }
    }
    getClassData();//初始化班级设置数据
    //$(document).ready(function(){
            
        var mydate = new Date();
        //mydate.getYear(); //获取当前年份(2位)
        var currentYear = mydate.getFullYear(); //获取完整的年份(4位,1970-????)
        // 打开新建班级模态框
        $(document).on("click",".dropdown p",function(){
            $("html,body").addClass("ban_body")
            $("#EditCfmGradeClass").show(100);

            var chkboxdom = "";
            var substringstr = $(this).attr("gradecode");//undefined
            var schgradeidstr = $(this).attr("gradeid");
            var schgradenamestr = $(this).attr("gradename");
            var selectitem = $(this).parent(".dropdown").parent(".SchClassResult").parent("td").find(".SchClassResult").find("input");
            var selectlen = selectitem.length;
                
            $("#EditCfmGradeClass .modal-title").html(schgradenamestr+"--添加班级");
                
            if(isNaN(substringstr)){
                substringstr = currentYear.toString();
            }

            var gradecodesubstr = substringstr.substring(2);
            chkboxdom += "<div class=\"row\">";
            chkboxdom += "<input type=\"hidden\" name=\"schgradeidstr\" value=\""+schgradeidstr+"\" />";
            ///
            for(var i=1;i<=54;i++){
                chkboxdom += "<div class=\"col-sm-2\">";
                if(i<10){
                    chkboxdom += "<input class=\"fl\" type=\"checkbox\" name=\"schclassname\" value=\""+gradecodesubstr+"0"+i+"班\"";
                    for(var j=0;j<10;j++){
                        if($(selectitem[j]).val()==gradecodesubstr+"0"+i+"班"){
                            chkboxdom += " checked=\"checked\" disabled=\"disabled\" ";
                        }
                    }
                    chkboxdom += "/><div class=\"classtit fl\">"+gradecodesubstr+"0"+i+"班</div> ";
                }else{
                    chkboxdom += "<input class=\"fl\" type=\"checkbox\" name=\"schclassname\" value=\""+gradecodesubstr+i+"班\"";
                    for(var j=0;j<54;j++){
                        if($(selectitem[j]).val()==gradecodesubstr+i+"班"){
                            chkboxdom += " checked=\"checked\" disabled=\"disabled\" ";
                        }
                    }
                    chkboxdom += "/><div class=\"classtit fl\">"+gradecodesubstr+i+"班</div> ";
                }
                chkboxdom += "<div class=\"cls\"></div></div>";
                if(i%6==0){
                    chkboxdom += "</div>";
                    chkboxdom += "<div class=\"row\">";
                }
            }
            ///
            $("#EditCfmGradeClass .modal-body").html(chkboxdom);

            $("#EditCfmGradeClass").modal({
                backdrop: 'static',
                keyboard: false
            });

        });
        $("#EditCfmGradeClass").on("hide.bs.modal",
        function () {
            $("html,body").removeClass("ban_body")
            getClassData();
        })
           
            
    //});
    //$(document).on("click","#SchClassSaveData",function(){
        function SchClassSaveData(){
            IsChkBoxed=0;
            $("#SchClassSaveData").attr("onclick","donull()");
            var schgradeidstr = $("input:hidden[name=\"schgradeidstr\"]").val();
            var val = $("input:checkbox[name=\"schclassname\"]:checked");
            var len = $("input:checkbox[name=\"schclassname\"]:checked").length;
            var isNum = [];
            var classnamestr=[];
            for(var i=0;i<len;i++){
                classnamestr.push($(val[i]).val());
                //alert($(val[i]).val().substring(0,4));
                isNum.push($(val[i]).val().substring(2,4));
            }
            if(classnamestr.toString()!=""){
                //if(isContinuationInteger(isNum)){
                var params = '{"schid":"' + schid + '","gradeid":"' + schgradeidstr + '","classnamestr":"' + classnamestr.toString() + '"}';
                $.ajax({
                    type: "POST",  //请求方式
                    url: "SchStructureSet.aspx/ClassNameSave",  //请求路径：页面/方法名字
                    data: params,     //参数
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if(data.d==1){
                            alert("添加成功");
                            $("#EditCfmGradeClass").modal("hide");
                        }else{
                            alert("添加失败");
                        }
                    },
                    error: function (obj, msg, e) {
                    }
                });
                //}else{
                //    alert("请选择连续的班级！！");
                //}
            }else{
                alert("先选择班级！！");
            }
        }
    //});
    $(document).on("click", ".closeitem", function () {
        var SchClassResult = $(this).parent(".item").parent(".SchClassResult");
        var schclassid = $(this).parent(".item").attr("val");
        var delitem = $(this).parent(".item");
        var deldomid = "SchClassResult"+delitem.find("input").attr("gradeid");
        //var lenss = $("#"+deldomid).find("input[name=\"valname\"]").length;
        //delitem.remove();
        //var mydate = new Date();
        //var deldomid = mydate.getFullYear().toString().substring(0,2)+delitem.text().substring(0,2);
        //alert(SchClassResult.length);
        var val = $("#"+deldomid).find("input[name=\"valname\"]");
        var len = $("#"+deldomid).find("input[name=\"valname\"]").length;
        var isNum = [];
        for(var i=0;i<len;i++){
            isNum.push($(val[i]).val().substring(2,4));
        }

        //var params = '{"schid":"' + schid + '","schclassid":"' + schclassid + '"}';
        //if(isContinuationInteger(isNum)){
        RemoveClass(schid,schclassid);   
        if(deletesuccess==1){
            delitem.remove(".item");
            if (SchClassResult.find(".item").length == 0) {
                SchClassResult.html("<span class=\"default\">请创建新班级</span>");
            }
        }
        
        $.ajax({
            type: "POST",  //请求方式
            url: "SchStructureSet.aspx/ClassDelete",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if(data.d==1){
                    delitem.remove(".item");
                    if (SchClassResult.find(".item").length == 0) {
                        SchClassResult.html("<span class=\"default\">请创建新班级</span>");
                    }
                    alert("删除成功");
                }else{
                    alert("先删除班级内的学生信息");
                }
            },
            error: function (obj, msg, e) {
            }
        });
               
        //}else{
        //    alert("先删除后面一个班级，班级不允许隔断");getClassData();
        //}
    });
    var IsChkBoxed=0;//判断是否有添加了新的班级
    $(document).on("click","#EditCfmGradeClass input[name=\"schclassname\"]",function(){
        if($(this).is(':checked')){
            IsChkBoxed++;
        }else{
            IsChkBoxed--;
        }
        if(IsChkBoxed==0){
            $("#SchClassSaveData").attr("onclick","donull()");
        }else if(IsChkBoxed >0){
            $("#SchClassSaveData").attr("onclick","SchClassSaveData()");
        }
    });
    
    function donull(){
        alert("请先选择班级");
    }
    //班级设置--End
    //});
    //部门设置--Start--Main主入
    $(document).ready(function () {
        $("#titlestr").html("添加部门信息");
        $("#savebtn").text("保存");
        $("#orderidbtn").css("display", "none");
        $('.ztree li a').css('display', '');//人员分页列表
        if (cotycode == '') {
            $('#searchbar').hide()
        }
        $('#dptstatdiv').hide();
        getdata();
    });
    //部门设置--End
    //获取市
    $('#aprov').change(function () {
        var selv = $('#aprov').val();
        var params = '{"typecode":"1","pcode":"' + selv + '"}';
        $.ajax({
            type: "POST",  //请求方式
            url: "../Users/UserInfo.aspx/getarea",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $('#acity').html(data.d);
                $('#acity').change();
            },
            error: function (obj, msg, e) {
            }
        });
    });
    //获取区
    $('#acity').change(function () {
        var selv = $('#acity').val();
        var params = '{"typecode":"2","pcode":"' + selv + '"}';
        $.ajax({
            type: "POST",  //请求方式
            url: "../Users/UserInfo.aspx/getarea",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $('#acoty').html(data.d);
                $('#acoty').change();
            },
            error: function (obj, msg, e) {
            }
        });
    });
    //获取学校
    $('#acoty').change(function () {
        var selv = $('#acoty').val();
        var params = '{"typecode":"3","pcode":"' + selv + '"}';
        $.ajax({
            type: "POST",  //请求方式
            url: "../Users/UserInfo.aspx/getarea",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $('#asch').html(data.d);
            },
            error: function (obj, msg, e) {
            }
        });
    });
    function getdata() {
        var params = '{"schid":"' + schid + '","stat":"' + ustat + '","selfid":"","selid":""}';
        $.ajax({
            type: "POST",  //请求方式
            url: "SchStructureSet.aspx/getdpt",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                dotree(eval("(" + data.d + ")"));
            },
            error: function (obj, msg, e) {
            }
        });
    }
    var treedeptObj;
    function dotree(d) {
        var treeNodesdept = d;
        var settingdept = {
            check: {
                //enable: true,
                //autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]   
                chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]   
                chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
            },
            view: {
                //addHoverDom: addHoverDom,
                //removeHoverDom: removeHoverDom,
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
                    // RoleEdit(treeId, treeNode);
                }
            }
        };
        $(function () {
            treedeptObj = $.fn.zTree.init($("#treedept"), settingdept, treeNodesdept);
            treedeptObj.expandAll(true);
            var nodes = treedeptObj.getNodesByFilter(filter);
            if (nodes.length > 0) {
                for (var item in nodes) {
                    addHoverDom('treedept', nodes[item]);
                }
            }
        });
    };
    function filter(node) {
        return true;
    }
    function addHoverDom(treeId, treeNode) {
        var sObj = $("#" + treeNode.tId + "_span");
        if (treeNode.editNameFlag || $("#addBtn_" + treeNode.tId).length > 0) return;
        var addStr = " ";
        if (isdel == "True") {
            addStr += "<span class='button remove'  id='removeBtn_" + treeNode.tId
                    + "' title='移除' onfocus='this.blur();'></span>";
        }
        if (isedit == "True") {
            addStr += "<span class='button edit'   id='editBtn_" + treeNode.tId + "' title='修改' onfocus='this.blur();'></span>";
        }
        if (isadd == "True") {
            addStr += "<span class='button add'  id='addBtn_" + treeNode.tId + "' title='添加' onfocus='this.blur();'></span>";
        }
        addStr += " ";
        sObj.after(addStr);
        var btn = $("#addBtn_" + treeNode.tId);
        if (btn) btn.bind("click", function () { 
            RoleAdd(treeId, treeNode, "1");
            $("#titlestr").html("添加部门信息");
        });
        var btnedit = $("#editBtn_" + treeNode.tId);
        if (btnedit) btnedit.bind("click", function () {
            RoleEdit(treeId, treeNode);
            $("#titlestr").html("修改部门信息");
        });
        var btnremove = $("#removeBtn_" + treeNode.tId);
        if (btnremove) btnremove.bind("click", function () {
            RoleDel(treeId, treeNode);
        });
    };

    function removeHoverDom(treeId, treeNode) {
        $("#addBtn_" + treeNode.tId).unbind().remove();
        $("#removeBtn_" + treeNode.tId).unbind().remove();
        $("#editBtn_" + treeNode.tId).unbind().remove();
    };
    //删除权限
    function RoleDel(treeId, treeNode) {
        var msg = "确认删除这条信息吗？";
        //$.showConfirm = function (str, funcok, funcclose) {
        BootstrapDialog.confirm({
            title: "提示框",
            message: msg,
            type: BootstrapDialog.TYPE_WARNING, // <-- Default value is // BootstrapDialog.TYPE_PRIMARY
            closable: true, // <-- Default value is false，点击对话框以外的页面内容可关闭
            draggable: true, // <-- Default value is false，可拖拽
            btnCancelLabel: "取消", // <-- Default value is 'Cancel',
            btnOKLabel: "确定", // <-- Default value is 'OK',
            btnOKClass: "btn-warning", // <-- If you didn't specify it, dialog type
            size: BootstrapDialog.SIZE_SMALL,
            // 对话框关闭的时候执行方法
            //onhide: funcclose,
            callback: function (result) {
                if (result) {// 点击确定按钮时，result为true
                    var params = '{"schid":"' + schid + '","id":"' + treeNode.id + '"}';
                    $.ajax({
                        type: "POST",  //请求方式
                        url: "SchStructureSet.aspx/deldpt",  //请求路径：页面/方法名字
                        data: params,     //参数
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            if (data.d) {
                                if (data.d == 'success') {
                                    //删除节点
                                    treedeptObj.removeNode(treeNode);
                                    dptadd(0);
                                } else if (data.d == "expire") {
                                    window.location.href = "../../LoginExc.aspx";
                                }
                                else {
                                    alert(data.d);
                                }
                            }
                        },
                        error: function (obj, msg, e) {
                        }
                    });
                }
            }
        });
    }
    //编辑权限
    function RoleEdit(treeId, treeNode) {
        $("#orderidbtn .MoveUp").attr("orderid", treeNode.OrderId);
        $("#orderidbtn .MoveDown").attr("orderid", treeNode.OrderId);
        $('#dptname').val(treeNode.name);
        $('#dptstat').val(treeNode.stat);
        $('#savebtn').text("保存");
        $('#savebtn').attr('onclick', 'savedpt();');
        $('#savebtn').val(treeNode.id);
        $("#titlestr").html("修改部门信息");
        $("#orderidbtn").css("display", "block");
        $("#widget-box-right").css("display", "block");
        var params = '{"schid":"' + schid + '","stat":"1","selfid":"' + treeNode.id + '","selid":"' + treeNode.pId + '"}';
        $.ajax({
            type: "POST",  //请求方式
            url: "SchStructureSet.aspx/getdpt",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d == "expire") {
                    window.location.href = "../../LoginExc.aspx";
                } else {
                    $('#dptp').html(data.d);
                }
            },
            error: function (obj, msg, e) {
            }
        });
        $('#dptname').focus();
    };
    //保存,并更新树节点
    function savedpt() {
        var dptname = $('#dptname').val();
        var stat = $('#dptstat').val();
        var pid = $('#dptp').val();
        var id = $('#savebtn').val();
        if (dptname.length < 1) {
            alert("请填写名称!");
            return;
        }
        var params = '{"schid":"' + schid + '","id":"' + id + '","dptname":"' + dptname + '","stat":"1","pid":"' + pid + '"}';
        $.ajax({
            type: "POST",  //请求方式
            url: "SchStructureSet.aspx/updpt",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d == 'success') {
                    alert("修改成功");
                    getdata();
                } else if (data.d == "expire") {
                    window.location.href = "../../LoginExc.aspx";
                }
                else {
                    alert(data.d);
                }
            },
            error: function (obj, msg, e) {
            }
        });
    };
    $('#savebtn').attr('onclick', 'adddpt();');//初始化
    function RoleAdd(treeId, treeNode, sl) {
        $("#orderidbtn").css("display", "none");
        $("#widget-box-right").css("display", "block");
        if (sl == "2") {
            $('#savebtn').attr('onclick', 'adddpt();');
            $('#savebtn').text("保存");
            $("#titlestr").html("添加部门信息");
            $("#dptname").val("");
            $("#dptp option:first").prop("selected", "selected");
            dptadd(treeNode.id);
        } else {
            dptadd(treeNode.id);
        }

    };
    function dptadd(id) {
        if (schid == "0" || schid == "" || schid == null) {
            alert("请选择学校");
            return false;
        }
        $('#dptname').val('');
        $('#savebtn').text("保存");
        $('#savebtn').attr('onclick', 'adddpt();');
        var params = '{"schid":"' + schid + '","stat":"1","selfid":"0","selid":"' + id + '"}';
        $.ajax({
            type: "POST",  //请求方式
            url: "SchStructureSet.aspx/getdpt",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d == "expire") {
                    window.location.href = "../../LoginExc.aspx";
                } else {
                    $('#dptp').html(data.d);
                }
            },
            error: function (obj, msg, e) {
            }
        });
        $('#dptname').focus();
    }
    //保存记录,并添加树节点
    function adddpt() {
        //获取名称
        var dptname = $('#dptname').val();
        if (dptname == "") {
            alert("部门名称不能为空");
            return false;
        }
        if (schid == "0" || schid == "" || schid == null) {
            alert("请选择学校");
            return false;
        }
        var pid = $('#dptp').val();
        var stat = $('#dptstat').val();

        var params = '{"schid":"' + schid + '","dptname":"' + dptname + '","pid":"' + pid + '","stat":"1"}';
        $.ajax({
            type: "POST",  //请求方式
            url: "SchStructureSet.aspx/adddpt",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (!isNaN(data.d)) {
                    var newNodes = [{ name: dptname, id: data.d, pId: pid }];
                    var node = treedeptObj.getNodeByParam("id", pid, null);
                    treedeptObj.addNodes(node, newNodes);
                    var nodesnew = treedeptObj.getNodeByParam("id", data.d, null);
                    addHoverDom('treedept', nodesnew);
                    alert("添加成功");
                    $("#dptname").val("");
                    $("#dptp option:first").prop("selected", "selected");
                    dptadd(pid);
                }
                else {
                    alert(data.d);
                }
            },
            error: function (obj, msg, e) {
            }
        });
    };
    //删除班级
    function RemoveClass(schid,schclassid) {
        var msg = "确认删除班级吗？";
        //$.showConfirm = function (str, funcok, funcclose) {
        BootstrapDialog.confirm({
            title: "提示框",
            message: msg,
            type: BootstrapDialog.TYPE_WARNING, // <-- Default value is // BootstrapDialog.TYPE_PRIMARY
            closable: true, // <-- Default value is false，点击对话框以外的页面内容可关闭
            draggable: true, // <-- Default value is false，可拖拽
            btnCancelLabel: "取消", // <-- Default value is 'Cancel',
            btnOKLabel: "确定", // <-- Default value is 'OK',
            btnOKClass: "btn-warning", // <-- If you didn't specify it, dialog type
            size: BootstrapDialog.SIZE_SMALL,
            // 对话框关闭的时候执行方法
            //onhide: funcclose,
            callback: function (result) {
                if (result) {// 点击确定按钮时，result为true
                    DelRun(schid,schclassid);// 执行方法
                }
            }
        });
        //};
    }
    function DelRun(schid,schclassid){
        var params = '{"schid":"' + schid + '","schclassid":"' + schclassid + '"}';
        $.ajax({
            type: "POST",  //请求方式
            url: "SchStructureSet.aspx/ClassDelete",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if(data.d==1){
                    deletesuccess=1;
                    alert("删除成功");
                    window.location.reload();
                }else{
                    alert("班级已设置了班主任、任课老师或班级内有学生！");
                }
            },
            error: function (obj, msg, e) {
            }
        });
    }
    function search() {
        //清除树以及添加
        $('#treedept').html('');
        $('#dptname').val('');
        $('#dptp').html('<option value="0">顶级部门</option>');
        //$('#savebtn').text("请选择节点");
        $('#savebtn').attr('onclick', '');
        schid = $('#asch').val();
        if (schid == "0" || schid == "" || schid == null) {
            alert("请选择学校");
            return false;
        }
        txtname = $('#txtname').val();
        if ($('#acoty').val()) {
            cotycode = $('#acoty').val();
        }
        ustat = $('#ustat').val();
        $('#dptp').html('<option value="0">顶级部门</option>');
        RoleAdd(1, 1, '2');//初始化右边的默认设置
        getdata();
        getSchGrade();
        getClassData();//获取班级信息
        getSchSub();//获取开始科目
        

    }
    $(document).on("click", "#cancelbtn", function () {
        $("#dptname").val("");
        $("#dptp option:first").prop("selected", "selected");
    });
    //部门排序上移
    $("#orderidbtn .MoveUp").click(function () {
        var CurrentDtpId = $("#savebtn").val();//当前部门的ID
        var SuperiorDtpPid = $("#dptp").val();//上级部门ID
        //var CuerentDtpOrderId = $("#orderidbtn .MoveUp").attr("orderid");//当前排序ID
        var moveType = $("#orderidbtn .MoveUp").attr("rel_id");
        var params = '{"dptid":"' + CurrentDtpId + '","moveType":"' + moveType + '"}';//将参数拼接为json对象字符串
        $.ajax({
            type: "POST",  //请求方式
            url: "SchStructureSet.aspx/MoveUpDown",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d == "success") {
                    alert("上移成功");
                    //RoleAdd(1, 1, '2');
                    getdata();
                }
                else if (data.d == "success01") {
                    alert("已经到了第一个");
                }
                else {
                    alert(data.d);
                }
            },
            error: function (obj, msg, e) {
            }
        });
    });
    //部门排序下移
    $("#orderidbtn .MoveDown").click(function () {
        var CurrentDtpId = $("#savebtn").val();//当前部门的ID
        var SuperiorDtpPid = $("#dptp").val();//上级部门ID
        //var CuerentDtpOrderId = $("#orderidbtn .MoveDown").attr("orderid");//当前排序ID
        var moveType = $("#orderidbtn .MoveDown").attr("rel_id");
        var params = '{"dptid":"' + CurrentDtpId + '","moveType":"' + moveType + '"}';//将参数拼接为json对象字符串
        $.ajax({
            type: "POST",  //请求方式
            url: "SchStructureSet.aspx/MoveUpDown",  //请求路径：页面/方法名字
            data: params,     //参数
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.d == "success") {
                    alert("下移成功");
                    //RoleAdd(1, 1, '2');
                    getdata();
                }
                else if (data.d == "success01") {
                    alert("已经到了最后一个");
                }
                else {
                    alert(data.d);
                }
            },
            error: function (obj, msg, e) {
            }
        });
    });


    //alert($("#SchClassSettBody .SchClassResult").length);
    //var sss = $("#SchClassSettBody .SchClassResult").html();
    //if(sss==undefined){
    //    $("#SchClassSettBody .SchClassResult").html("<span class=\"default\">请创建新班级</span>");
    //}
</script>