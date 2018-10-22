<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchSubLeaderinfo.aspx.cs" Inherits="SchWebAdmin.Web.SchSearch.SchSubLeaderinfo" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <meta name="keywords" content="金视野,教育,平台" />
    <meta name="description" content="金视野开发部,模板,2017" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../assets/css/jquery-ui-1.10.3.custom.min.css" />
    <link rel="stylesheet" href="../../assets/css/jquery.gritter.css" />
     
    <link rel="stylesheet" href="../../assets/css/ace.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-rtl.min.css" />
    <link rel="stylesheet" href="../../assets/css/ace-skins.min.css" />
    <script src="../../assets/js/ace-extra.min.js"></script>
    <style type="text/css">
        .main-container {
            /*min-height: 900px;*/
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
            font-size: 13px !important;
            color: #666666 !important;
        }
        /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }

        i {
            font-family: FontAwesome !important;
        }
        /*表格的行距*/
        .table thead > tr > th, .table tbody > tr > td {
            line-height: 1.5;
            text-align: center;
        }
        /*表格标题栏字体大小，颜色*/
        .table thead tr th {
            color: #444444 !important;
            font-weight: bold !important;
            font-size: 13px !important;
            letter-spacing: 1px !important;
        }
        /*表格的内容区字体大小颜色*/
        .table tbody tr td {
            color: #666666 !important;
            font-size: 13px !important;
        }
        /*学科组长等大标题的样式*/
        .subleadertitle {
            color: #000000;
            font-size: 14px;
            font-weight: bold;
            letter-spacing: 1px;
        }
        /*学科组长中的人名样式*/
        #SubLearder .row .row span {
            display: inline-block;
            width: 25%;
            border: 1px solid #E5E5E5;
            text-align: center;
            margin: 3px;
            font-size: 12px;
            color: #999999;
        }
        /*学科组长中的科目样式*/
        #SubLearder .subtitle {
            font-size: 13px;
            color: #666666;
            text-align: center;
        }

        #SubLearder .tr {
            width: 95%;
            margin-bottom: 10px;
        }
        /*年级领导中的人名样式*/
        #GradeManager .row .row span {
            display: inline-block;
            width: 80px;
            border: 1px solid #E5E5E5;
            text-align: center;
            margin-left: 5px;
            margin-right: 5px;
            font-size: 12px;
            color: #999999;
        }
        /*年级领导中的年级标题*/
        #GradeManager .gradetitle {
            text-align: center;
            font-size: 13px;
            color: #666666;
        }

        #GradeManager .tr {
            width: 95%;
            margin-bottom: 10px;
        }

        #searchbar select {
            margin-left: 5px;
            margin-right: 5px;
        }

        .breadcrumb > li + li:before {
            content: "";
        }
        /*按钮的字体大小*/
        .text-size {
            font-size: 12px;
        }
        /*输入框和下拉选框的间距*/
        select, input {
            font-size: 12px;
            margin-left: 10px;
            margin-right: 10px;
            color: #999999;
        }
        /*搜索栏中的标签大小*/
        .text-style {
            font-size: 13px;
            color: #666666;
        }

        input[type="text"] {
            font-size: 12px;
            color: #999999;
        }
        /*弹出框的标题样式*/
        .title-style {
            font-size: 14px;
            font-weight: bold;
            letter-spacing: 1px;
        }

        .page-content {
            padding: 8px 20px 8px;
        }
        /*添加班级弹出框的顶端距离*/
        @media screen and (min-width: 768px) {
            .modal-dialog {
                padding-top: 130px;
            }
        }
        /*弹出框表头的颜色*/
        .bootstrap-dialog.type-warning .modal-header {
            background-color: #ffffff !important;
        }
        /*弹出框表头标题的颜色大小*/
        .bootstrap-dialog .bootstrap-dialog-title {
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

        #modelSubLeader .ztree li a span {
            color: #999999 !important;
        }
    </style>
</head>
<body>

    <div class="main-container" id="main-container">
        <script type="text/javascript">
            try { ace.settings.check('main-container', 'fixed') } catch (e) { }
        </script>

        <div class="main-container-inner">
            <div class="main-content" style="margin-left: 0px">

                <div class="page-content">
                    <!--搜索-->
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-8" id="searchbar">
                                <div class="input-group pull-right">
                                    <br />
                                    <%=areastr %>
                                    <br />
                                    <br />

                                </div>
                            </div>
                        </div>
                    </div>
                    <!--//搜索-->
                    <br />
                    <!--学科组长-->
                    <div class="row">
                        <div class="col-sm-1 text-center subleadertitle">一、学科组长：</div>
                        <div class="col-sm-11" id="SubLearder">
                            <!--<div class="row" id="SubLearder"></div>-->
                        </div>
                    </div>
                    <!--//学科组长-->
                    <br />
                    <!--年级领导-->
                    <div class="row">
                        <div class="col-sm-1 text-center subleadertitle">二、年级领导：</div>
                        <div class="col-sm-11" id="GradeManager">
                            <!--<div class="row" id="GradeManager"></div>-->
                        </div>
                    </div>
                    <!--//年级领导-->
                    <br />

                    <div class="row">
                        <div class="row no-margin-right no-margin-left">
                            <div class="col-sm-1 text-center subleadertitle">三、任课老师：</div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-1"></div>
                        <div class="col-sm-10 text-center text-style">
                            是否已毕业:
                                <select id="ustat">
                                    <option value="">全部</option>
                                    <option value="1">已毕业</option>
                                    <option value="0">正常</option>
                                </select>
                            教师姓名:<input type="text" id="txtname" placeholder="教师姓名">
                            <span class="text-style">年级:</span>
                            <select id="schgradeSearch">
                                <option value="">全部</option>
                            </select>
                            <span class="text-style">班级:</span>
                            <select id="schclassSearch">
                                <option value="">全部</option>
                            </select>
                            <span class="text-style">任教科目:</span>
                            <select id="schsubsSearch">
                                <option value="">全部</option>
                            </select>
                            <button class="btn btn-sm btn-info text-right text-size" type="button" onclick="search();">查询</button>
                        </div>
                        <div class="col-sm-1" id="addstr"></div>
                    </div>
                    <div class="space-10"></div>
                    <div class="row" id="list">
                        <div class="col-sm-12 pull-right" style="margin: 0px auto;"></div>
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
    <!-- ace scripts -->
    <script src="../../assets/js/ace-elements.min.js"></script>
    <script src="../../assets/js/ace.min.js"></script>
    <script src="../../assets/js/bootstrap-paginator.js"></script>
    <link href="../../assets/css/bootstrap-dialog.css" rel="stylesheet" />
    <script src="../../assets/js/bootstrap-dialog.js"></script>
    <!-- inline scripts related to this page -->
    <script type="text/javascript"> 
        var txtname = '';
        var schid = '0';
        var cotycode = '';
        var ustat = '';
        var gradecode = '';
        var classid="";
        var subcode="";
        
        var grades = <%=grades%>;
        var subs = <%=subs%>;
        var subUser = <%=subUser%>;
        var selv="";
        schid = '<%=schid%>';//第一次赋给ID
        var systype = '<%=systype%>';
        cotycode = '<%=cotycode%>';
        if (cotycode == '') {
            $('#searchbar').hide()
        }
       
        var addstr = "";
       
        $("#addstr").html(addstr);
        //搜索框当前学校的科目
        var schsubsoption="<option value=\"\">全部</option>";
        $.each(subs.ds, function (index, item) {
            schsubsoption += "<option value=\""+item.SubCode+"\">"+item.SubName+"</option>";
        });
        //搜索框当前学校的年级
        var schgradeoption="<option value=\"\">全部</option>";
        $.each(grades, function (index, item) {
            schgradeoption += "<option value=\""+item.GradeId+"\">"+item.GradeName+"</option>";
        });
        
        $("#schgradeSearch").html(schgradeoption);
        $("#schsubsSearch").html(schsubsoption);

        //搜索框当前学校的班级
        function schclassoption(data){
            var schclassoption="<option value=\"\">全部</option>";
            $.each(eval("(" + data + ")"), function (index, item) {
                schclassoption += "<option value=\""+item.ClassId+"\">"+item.ClassName+"</option>";
            });
            $("#schclassSearch").html(schclassoption);
        }
        
        //获取数据
        function getdata() {
            var params = '{"txtname":"' + txtname + '","ustat":"' + ustat + '","cotycode":"' + cotycode + '","schid":"' + schid + '","gradeCode":"' + gradecode + '","classid":"' + classid + '","subcode":"' + subcode + '"}';
            //SubLearderSearch(subs,subUser);//科目组长初始化
            getSearchData();
            //GradeManagerSearch(grades,gradecode);//年级领导初始化
            $.ajax({
                type: "POST",  //请求方式
                url: "SchSubLeaderinfo.aspx/page",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }else{
                        dodata(data.d);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        };
        //表格生成处理
        function dodata(data) {
            //alert(subcode);
            if (eval("(" + data + ")") != null && data != "") {
                var str = '';
                str += '<table id="data_table" class="table table-striped table-bordered table-hover" style="width:95%;margin:0px auto;">';
                str += '<thead>';
                str += '<tr>';
                str += '<th>年级名称</th>';
                str += '<th>班级名称</th>';
                str += '<th class="hidden-480">班主任</th>';
                str += '<th class="hidden-480">任课老师</th>';
                
                str += '</tr>';
                str += '</thead>';
                str += '<tbody>';
                $.each(eval("(" + data + ")"), function (index, item) { //遍历返回的json
                    var strTCstr="";var strCNstr="";
                    if(subtext==""){
                        strTCstr = item.TeacherClass;
                        strCNstr = item.TeacherSub;
                    }else{
                        if(subtext!="全部"){
                            var reg = RegExp(subtext);
                            //班主任
                            var strTC = item.TeacherClass;
                            if(reg.test(strTC)){
                                strTCstr = item.TeacherClass;     
                            }
                            //科任老师
                            var strCN = item.TeacherSub;
                            var strCNarr = strCN.split(',');
                            var strCNlen = strCNarr.length;
                            for(var i=0;i<strCNlen;i++){
                                if(reg.test(strCNarr[i])){
                                    strCNstr = strCNarr[i];
                                }
                            }
                        }
                        else
                        {
                            strTCstr = item.TeacherClass;
                            strCNstr = item.TeacherSub;
                        }
                    }
                    
                    //
                    str += '<tr>';
                    str += '<td>' + item.GradeName + '</td>';
                    str += '<td>' + item.ClassName + '</td>';
                    str += '<td class="hidden-480">' + strTCstr + '</td>';
                    str += '<td class="hidden-480">' + strCNstr + '</td>';
                   
                    str += '</tr>';
                    
                });
                str += '</tbody>';
                str += '</table>';
                $('#list').empty();
                $('#list').append(str);

                $('table th input:checkbox').on('click', function () {
                    var that = this;
                    $(this).closest('table').find('tr > td:first-child input:checkbox')
                    .each(function () {
                        this.checked = that.checked;
                        $(this).closest('tr').toggleClass('selected');
                    });

                });
            }
            else {
                $('#list').empty();
                $('#list').append("暂无数据!");
            }
        };
        //获取班级
        $('#schgradeSearch').change(function () {
            var selv = $('#schgradeSearch').val();
            var params = '{"typecode":"5","pcode":"' + selv + '","isall":"1"}';
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
                        $('#schclassSearch').html(data.d.data);
                        $('#schclassSearch').change();
                        $("#schclassSearch option").each(function () {
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
    <!--//-->
    <script type="text/javascript">
        //搜索事件
        var subsearch={};
        var gradesearch={};
        var subtecsearch={};
        var subtext="";
        function search() {
            txtname = $('#txtname').val();//获取教师姓名
            selv = $('#asch').val();//获取学校编号
            if(typeof(selv)=="undefined"){selv = schid;}
            cotycode = $('#acoty').val();//获取县区编号
            ustat = $('#ustat').val();//获取状态：是否毕业
            if(ustat==""){ustat="0";}
            gradecode = $("#schgradeSearch").val();//获取年级编号
            if(gradecode=="0")gradecode="";
            classid = $("#schclassSearch").val();//获取班级编号
            if(classid=="0")classid="";
            subcode = $("#schsubsSearch").val();//获取科目编号
            if(subcode=="0")subcode="";
            subtext = $("#schsubsSearch option:selected").text();
            //getSearchData();
            //
            getdata();

        }
        //
        function getSearchData(){
            var params = '{"schid":"'+selv+'","gradecode":"'+gradecode+'","subcode":"' + subcode + '","ustat":"' + ustat + '"}';
            //alert(params);
            $.ajax({
                type: "POST",  //请求方式
                url: "SchSubLeaderinfo.aspx/getSearch",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d == "expire"){
                        window.location.href="../../LoginExc.aspx";
                    }else{
                        var obj = eval('('+data.d+')');
                        //subsearch = obj.subs;gradesearch=obj.grade;subtecsearch=obj.subtec;
                        SubLearderSearch(obj.subs,obj.subtec);//科目组长初始化
                        GradeManagerSearch(obj.grade,gradecode);//年级领导初始化
                    }
                },
                error: function (obj, msg, e) {
                }
            });
        }
    </script> 
     
   
     
    <style type="text/css">
        .ban_body {
            height: 100%;
            overflow: hidden;
        }
    </style>
    <!-- //模态框   打开学科组长模态框 -->
    <script type="text/javascript">
       
        $(document).ready(function () {
            if(selv==""){selv=schid;}
            //getSearchData();
            getdata();//初始化班级数据

        });
 
        // 打开新建班级模态框，函数名：showGradeEditeModal
        function showGradeEditeModal(obj, gradecode, classid, dotype) {

            $("html,body").addClass("ban_body")
            $("#EditCfmGradeClass").show(100);

            var selv = $("#asch").val();
            if(typeof(selv)!="undefined"){
                schid = $("#asch").val();
            }
            if(typeof(selv)=="undefined"){selv=schid;}
            if(gradecode==""){//添加班级
                gradecode = $("#schgradeSearch").val();
                var url = "SubLeaderEdit.aspx?dotype=" + dotype + "&schid=" + selv + "&gradecode=" + gradecode + "&classid=" + classid;
            }else{//编辑班级
                var url = "../GradeClassSet/SchClassE.aspx?dotype=" + dotype + "&schid=" + schid + "&gradecode=" + gradecode + "&classid=" + classid;
            }
            $("#modelClassAdd").attr("src", url);
            $("#EditCfmGradeClass").modal({
                backdrop: 'static',
                keyboard: false
            });
        }
        $(function () {
            $('#EditCfmGradeClass').on('hide.bs.modal',
            function () {
                $("html,body").removeClass("ban_body")
                getdata();
            })
        });

        

        // 打开修改年级模态框，函数名：GradeEditeModal
        function GradeEditeModal(obj, gradecode, dotype) {

            $("html,body").addClass("ban_body")
            $("#EditCfmGrade").show(100);

            var selv = $("#asch").val();
            if(typeof(selv)=="undefined"){selv=schid;}
            var url = "SchGradeEdit.aspx?dotype=" + dotype + "&schid=" + selv + "&gradeid=" + gradecode;
            $("#modelGradeAdd").attr("src", url);
            $("#EditCfmGrade").modal({
                backdrop: 'static',
                keyboard: false
            });
        }
        $(function () {
            $('#EditCfmGrade').on('hide.bs.modal',
            function () {
                $("html,body").removeClass("ban_body")
                getSearchData();
            })
        });
        
        // 打开学科组长模态框，函数名：SubLearderEditeModal
        function SubLearderEditeModal(obj, gradecode, dotype) {

            $("html,body").addClass("ban_body")
            $("#EditCfmSubs").show(100);

            var selv = $("#asch").val();
            if(typeof(selv)=="undefined"){selv=schid;}
            var url = "SchSubLeadEdit.aspx?dotype=" + dotype + "&schid=" + selv + "&subid=" + gradecode;
            $("#modelSubLeader").attr("src", url);
            $("#EditCfmSubs").modal({
                backdrop: 'static',
                keyboard: false
            });
        }
        $(function () {
            $('#EditCfmSubs').on('hide.bs.modal',
            function () {
                $("html,body").removeClass("ban_body")
                getSearchData();
                
            })
        });

        //关闭年组长模态框
        function closesubleaderemodel() {
            $("#EditCfmSubs").modal("hide");
        }


        //关闭年级模态框
        function closegroademodel() {
            $("#EditCfmGrade").modal("hide");
        }

        //关闭班级模态框
        function closeclassmodel() {
            $("#EditCfmGradeClass").modal("hide");
        }
        

        //学科组长#SubLearder
        function SubLearderSearch(subs,subUser){
            var SubLearderDom = "";
            SubLearderDom += "<div class=\"row tr\">";
            $.each(subs.ds, function (index, item) {
                
                SubLearderDom += "<div class=\"col-sm-3\">";
                SubLearderDom += "<div class=\"row\">";
                SubLearderDom += "  <div class=\"col-sm-3 no-padding subtitle\">"+item["SubName"]+":</div>";
                SubLearderDom += "  <div class=\"col-sm-9 no-padding\">";
                $.each(subUser.ds, function (indexUser, itemUser) {
                    if(itemUser.SubCode==item.SubCode){
                        SubLearderDom += "<span>"+itemUser["UserTname"]+"</span>";
                    }
                });
                //SubLearderDom +="   </div>";
                //SubLearderDom += "  <div class=\"col-sm-1\">";
              
                SubLearderDom += "  </div>";
                SubLearderDom += "</div>";
                SubLearderDom += "</div>";
                if((index+1)%4==0){
                    SubLearderDom += "</div>";
                    SubLearderDom += "<div class=\"row tr\">";
                }
                
            });
            SubLearderDom += "</div>";
            $("#SubLearder").html(SubLearderDom);
        }

        //年级领导#GradeManager
        function GradeManagerSearch(grades,gradecode){
            var GradeManagerDom = "";
            GradeManagerDom += "<div class=\"row tr\">";
            $.each(grades, function (index, item) {
                var gradebossarr = item["GradeBoss"].split(',');
                var gradebosslen = gradebossarr.length;
                
                GradeManagerDom += "<div class=\"col-sm-6\">";
                GradeManagerDom += "<div class=\"row\">";
                GradeManagerDom += "    <div class=\"col-sm-2 gradetitle\">"+item["GradeName"]+":</div>";
                GradeManagerDom += "    <div class=\"col-sm-10\">";
                for(var i=0;i<gradebosslen;i++){
                    if(gradebossarr[i]!=""){
                        GradeManagerDom += "    <span>"+gradebossarr[i]+"</span>";
                    }
                }
                //GradeManagerDom += "    </div>";
                //GradeManagerDom += "    <div class=\"col-sm-1\">";
               
                GradeManagerDom += "    </div>";
                GradeManagerDom += "</div>";
                GradeManagerDom += "</div>";
                if((index+1)%2==0){
                    GradeManagerDom += "</div>";
                    GradeManagerDom += "<div class=\"row tr\">";
                }
                
            });
            GradeManagerDom += "</div>";
            $("#GradeManager").html(GradeManagerDom);
        }
    </script>
</body>
</html>
