<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChnAdd.aspx.cs" Inherits="SchWebMaster.Web.SchChn.ChnAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
        /*字体*/
        body {
            font-family: "微软雅黑" !important;
        }
        /*输入框和下拉框的字号大小*/
        input[type="text"], select {
            font-size: 12px;
            height: 30px;
        }
        /*行高*/
        .lineheight {
            line-height: 30px;
        }
        .widget-box {
            border-top: 1px solid #CCC;
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


        strong {
            margin-right: 15px;
            font-size: 14px;
            color: #393939;
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
                    <div class="widget-box">
                        <div class="widget-body">
                            <div class="widget-main">
                                <input type="text" id="Chnid" hidden="hidden" />
                                <div class="row">
                                    <div class="col-sm-3"><strong>栏目名称:</strong><input type="text" id="ChnName" data-toggle="tooltip" placeholder="请输入栏目名称" maxlength="10" /></div>
                                    <div class="col-sm-3">
                                        <strong>栏目代码:</strong><select id="ChnCode">
                                            <option value="">请选择栏目代码 </option>
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
                                            <option value="13">13</option>
                                            <option value="14">14</option>
                                            <option value="15">15</option>
                                            <option value="16">16</option>
                                            <option value="17">17</option>
                                            <option value="18">18</option>
                                            <option value="19">19</option>
                                            <option value="20">20</option>
                                        </select>
                                    </div>
                                    <div class="col-sm-3">
                                        <strong>上级栏目:</strong><select id="Pid">
                                            <option value="0">根目录</option><%=chndrp %>
                                        </select>
                                    </div>
                                    <div class="col-sm-3">
                                        <strong>栏目状态:</strong><select id="Stat">
                                            <option value="1">正常</option>
                                            <option value="0">屏蔽</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="space-4"></div>
                                <div class="row">
                                    <div class="col-sm-12"><strong>栏目备注:</strong><input type="text" id="Note" style="width:80%;" data-toggle="tooltip" placeholder="请输入栏目备注" maxlength="150" /></div>
                                </div>
                                <div class="space-4"></div>
                                <div class="row">
                                    <span  style="float: right;"><button class="btn btn-info btn-sm btn_size" id="btndo" type="button" onclick="saveuser()">确定</button>
                                
                                <button class="btn btn-sm btn_size" id="CancelBtn" type="reset">取消</button></span>
                                </div>
                            </div>
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
    <script type="text/javascript">
       
    var umodel=<%=umodelstr%>;
        //用户赋值 
        if(umodel!="1")
        {
            $('#Chnid').val(umodel.ChnId);
            $('#ChnName').val(umodel.ChnName); 
            $('#Note').val(umodel.Note); 
            $('#Pid').val(umodel.Pid); 
            $('#ChnCode').val(umodel.ChnCode);
            if(umodel.Stat==1){  
                $("#Stat").val(1); 
            }else{ 
               
                $("#Stat").val(0); 
            }
        }

        //数据收集并存库函数
        function saveuser()
        {    
            var Chnid= $("#Chnid").val(); 
            var ChnName= $("#ChnName").val(); 
            if($.trim(ChnName)=="") 
            {
                alert('请输入栏目名称!');
                return false;
            }
            var Pid= $("#Pid").val(); 
            
            var ChnCode= $("#ChnCode").val(); 
            if($.trim(ChnCode)=="") 
            {
                alert('请选择栏目代码!');
                return false;
            }
            var Note= $("#Note").val(); 
            var Stat= $("#Stat").val(); 
            if($.trim(Stat)=="") 
            {
                alert('请选择栏目状态!');
                return false;
            }
            var params = '{"Chnid":"' + Chnid + '","ChnName":"' + ChnName + '","ChnCode":"' + ChnCode + '","Note":"' + Note + '","Stat":"' + Stat + '","Pid":"' + Pid + '"}';
            $.ajax({
                type: "POST",  //请求方式
                url: "ChnAdd.aspx/save",  //请求路径：页面/方法名字
                data: params,     //参数
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if(data.d.code=='success')
                    {
                        alert(data.d.msg);
                        window.parent.createuserclose();
                    } 
                    else if (data.d.code == "expire") {
                        window.location.href = "../../LoginExc.aspx";
                    }
                    else if (data.d.code == "error") {
                        alert(data.d.msg);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
            
        }

        $(document).on("click","#CancelBtn",function(){
            window.parent.createuserclose();
        });
    </script>
</body>
</html>

