<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserOrderRenewals.aspx.cs" Inherits="SchWebServ.Web.UserOrderInfo.UserOrderRenewals" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>用户订购信息列表</title>
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
    <style type="text/css">
         /*定义字体*/
        * {
            font-family: "微软雅黑" !important;
        }

        i {
            font-family: FontAwesome !important;
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
                <div class="page-content content_box ">
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-1"><input type="hidden" id="AutoId" /><input type="hidden" id="OldServMonth" /></div>
                        <div class="col-xs-1 text-center no-padding">账号</div>
                        <div class="col-xs-1 text-center no-padding" style="color:#15A1FF;font-weight:bold;">[<span id="Account"></span>]</div>
                        <div class="col-xs-2 text-center no-padding">给订购的</div>
                        <div class="col-xs-1 text-center no-padding" style="color:#15A1FF;font-weight:bold;">[<span id="OrderPackName"></span>]</div>
                        <div class="col-xs-2 text-center no-padding">资费</div>
                        <div class="col-xs-1 text-center no-padding" style="color:#15A1FF;font-weight:bold;">[<span id="BusTariff"></span>]</div>
                        <div class="col-xs-1 text-center no-padding">账号状态</div>
                        <div class="col-xs-1 text-center no-padding" style="color:#15A1FF;font-weight:bold;">[<span id="AcountStat"></span>]</div>
                        <div class="col-xs-2"></div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-1"></div>
                        <div class="col-xs-11">原订购信息：</div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-1"></div>
                        <div class="col-xs-11">
                            <div class="row">
                                <div class="col-xs-1"></div>
                                <div class="col-xs-2 text-right no-padding">缴费金额：</div>
                                <div class="col-xs-1 text-left"><span id="PayAmount"></span>元</div>
                                <div class="col-xs-2 text-right no-padding">订购时间：</div>
                                <div class="col-xs-2 text-left"><span id="OrderTime"></span></div>
                                <div class="col-xs-2 text-right no-padding">结束时间：</div>
                                <div class="col-xs-2 text-left"><span id="OrderEndTime"></span></div>
                            </div>
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-1"></div>
                        <div class="col-xs-11">续费信息：</div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-1"></div>
                        <div class="col-xs-11">
                            <div class="row">
                                <div class="col-xs-1"></div>
                                <div class="col-xs-2 text-right no-padding">订购时长：</div>
                                <div class="col-xs-3 text-left"><select class="col-xs-12" name="OrderLength" id="OrderLength"><option value="">请先选择订购套餐</option></select></div>
                                <div class="col-xs-2 text-right no-padding">缴费金额：</div>
                                <div class="col-xs-3 text-left"><input  type="text" class="col-xs-12" name="PayAmount" id="PayAmountRen" placeholder="自动结算缴费金额" readonly="readonly" /></div>
                            </div>
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-1"></div>
                        <div class="col-xs-11">
                            <div class="row">
                                <div class="col-xs-1"></div>
                                <div class="col-xs-2 text-right no-padding">续费时间：</div>
                                <div class="col-xs-3 text-left"><input  type="text" class="col-xs-12" name="OrderEndTime" id="OrderCurrTimeRen" readonly="readonly" placeholder="" maxlength="250" /></div>
                                <div class="col-xs-2 text-right no-padding">结束时间：</div>
                                <div class="col-xs-3 text-left"><input  type="text" class="col-xs-12" name="OrderEndTime" id="OrderEndTimeRen" readonly="readonly" placeholder="" maxlength="250" /></div>
                            </div>
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-1"></div>
                        <div class="col-xs-11">
                            <div class="row">
                                <div class="col-xs-1"></div>
                                <div class="col-xs-2 text-right no-padding">备注：</div>
                                <div class="col-xs-7 text-left"><input  type="text" class="col-xs-12" name="Note" id="Note" placeholder="请输入备注" maxlength="250" /></div>
                            </div>
                        </div>
                    </div>
                    <div class="space-8"></div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <button class="btn btn-info btn-sm text_size" id="btndo" type="button" onclick="saveOrder()">保存</button>&nbsp; &nbsp; &nbsp;
                            <button class="btn btn-sm text_size" id="CancelBtn" type="button">取消</button>
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
    <script type="text/javascript" src="../../assets/js/jquery.cookie.js"></script>
    <!-- (Optional) Latest compiled and minified JavaScript translation files -->

    <script type="text/javascript">
        //公共變量定義區域
        var servUserForModel=<%=servUserForModel%>;

        //下拉部门框点击屏蔽
        $(document).on("click",".dropdown-menu",function(e){
            e.stopPropagation();
        });
        //单击取消按钮时，关闭模态框
        $(document).on("click", "#CancelBtn", function () {
            window.parent.closeEditCfmmodel();
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function(){
            //編輯頁面給當前ID記錄初始化
            if(servUserForModel!="0"){
                $("#AutoId").val(servUserForModel.AutoId);
                $("#OldServMonth").val(servUserForModel.ServMonth);
                $("#Account").text(servUserForModel.UserName);
                $("#OrderPackName").text(servUserForModel.CnName);

                if(servUserForModel.ServStat="1"){
                    $("#AcountStat").text("正常");
                }else{
                    $("#AcountStat").text("禁用");
                }

                //$("#BusTariff").text((servUserForModel.FeeM/servUserForModel.ServMonth));
                $("#BusTariff").text(servUserForModel.FeeCode +"元/"+servUserForModel.BusMonth+"月");
                $("#OrderTime").text(servUserForModel.RecTime.substring(0,10));
                $("#PayAmount").text(servUserForModel.FeeM);

                $("#OrderEndTime").text(servUserForModel.EndTime.substring(0,10));
                var ordertimelength="";
                var ServMonth = "";
                ordertimelength += "<option value=\"\">请选择时长</option>";
                for(var i=0;i<6;i++){
                    if(i==0){
                        ServMonth = servUserForModel.BusMonth
                    }else{
                        ServMonth = ServMonth+servUserForModel.BusMonth;
                    }
                    ordertimelength += "<option value=\""+ServMonth+"\">"+ServMonth+"个月</option>";
                }
                $("#OrderLength").html(ordertimelength);
                var date = new Date();
                var fullyear = date.getFullYear();
                var month = date.getMonth()+1;
                var day = date.getDate();
                $("#OrderCurrTimeRen").val(fullyear+"-"+month+"-"+day);

            }
            //訂購套餐改變時觸發，計算繳費金額
            $("#OrderLength").change(function(){
                var orderlengthval = $(this).val();
                if(orderlengthval){
                    //計算繳費金額：（订购时长/套餐最小月份）*最小月份资费
                    var PayAmountRenFee = (orderlengthval/servUserForModel.BusMonth)*servUserForModel.FeeCode;
                    $("#PayAmountRen").val(PayAmountRenFee);
                    //計算結束日期/結束時間
                    var currendate = $("#OrderEndTime").text();//当前结束日期
                    var currendatearr="";
                    if(currendate!=""){
                        currendatearr = currendate.split('-');
                    }
                    var currendyear = currendatearr[0];
                    var currendmonth = currendatearr[1];
                    var currendday = currendatearr[2];
                    var lastMonth = 12-currendmonth;//當前年份剩餘月份
                    var month = orderlengthval-lastMonth
                    if(month>0){
                        var remainder = (orderlengthval-lastMonth)%12;//取餘數
                        var Rounding = Math.ceil((orderlengthval-lastMonth)/12);//向上取整
                        $("#OrderEndTimeRen").val((parseInt(currendyear)+parseInt(Rounding))+"-"+remainder+"-"+currendday);
                    }else{
                        if(orderlengthval<lastMonth){
                            $("#OrderEndTimeRen").val(currendyear+"-"+(parseInt(currendmonth)+parseInt(orderlengthval))+"-"+currendday);
                        }else{
                            $("#OrderEndTimeRen").val(currendyear+"-"+(parseInt(currendmonth)+parseInt(lastMonth))+"-"+currendday);
                        }
                    }
                }else{
                    $("#PayAmountRen").val("");
                    $("#OrderEndTimeRen").val("");
                }
            });
        })
    </script>
    <script type="text/javascript">

        //數據收集並且存儲數據庫
        function saveOrder(){
            var datasave = [];

            var autoid = $("#AutoId").val();
            datasave.push("autoid#" + autoid);

            var ordertimelen = $("#OrderLength").val();
            datasave.push("ordertimelen#" + ordertimelen);

            var payamountren = $("#PayAmountRen").val();
            datasave.push("payamountren#" + payamountren);

            var orderendtimeren = $("#OrderEndTimeRen").val();
            datasave.push("orderendtimeren#" + orderendtimeren);

            var note = $("#Note").val();
            datasave.push("note#" + note);
            
            $.ajax({
                type: "POST",
                url: "UserOrderRenewals.aspx/UserOrderRenSave",
                data: JSON.stringify({ arr: datasave }),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data.d.code == 'expire') {
                        alert(data.d.msg);
                        window.location.href = "../../LoginExc.aspx";
                    }else if (data.d.code == 'success') {
                        alert(data.d.msg);
                        window.parent.closeEditCfmmodel();
                    }else{
                        alert(data.d.msg);
                    }
                },
                error: function (obj, msg, e) {
                }
            });
            
        }
    </script>
    
</body>
</html>