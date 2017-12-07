<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="SchWeb.PublicPage.Department.Department" %>

 
 
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    
    <link rel="stylesheet" href="../../assets/css/bootstrap.min.css" />
    <script src="../../assets/js/jQuery-2.1.4.min.js" type="text/javascript"></script>
    <script src="../../assets/js/bootstrap-treeview.min.js" type="text/javascript"></script>
    <script src="../../assets/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.onload = function () {
            $.ajax({
                type: "POST",
                url: "Department_h.ashx?action=Search",
                dataType: "json",
                data: {},
                success: function (data) {
                    defaultData = JSON.stringify(transDate(data, "id", "Pid"));  
                    $('#treeview1').treeview({
                        data: defaultData,
                    });
                    //初始显示时折叠父节点         
                    $('#treeview1').treeview('collapseAll', {
                        silent: true
                    });
                }
            });
        }

        //确认部门的选择   
        function confirmLeader() {
            var test = $('#treeview1').treeview('getSelected');
            var strRow = test[0].id + "|" + test[0].text;
            window.parent.bindBoxdep(strRow);

        } 
        function transDate(list, idstr, pidstr) {
            var result = [], temp = {};
            for (i = 0; i < list.length; i++) {
                temp[list[i][idstr]] = list[i];//将nodes数组转成对象类型
            }
            for (j = 0; j < list.length; j++) {
                tempVp = temp[list[j][pidstr]]; //获取每一个子对象的父对象
                if (tempVp) {//判断父对象是否存在，如果不存在直接将对象放到第一层
                    if (!tempVp["nodes"]) tempVp["nodes"] = [];//如果父元素的nodes对象不存在，则创建数组
                    tempVp["nodes"].push(list[j]);//将本对象压入父对象的nodes数组
                } else {
                    result.push(list[j]);//将不存在父对象的对象直接放入一级目录
                }
            }
            return result;
        }

    </script>
 
 
     
    <div id="treeview1"></div>
    </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-warning" data-dismiss="modal" onclick="confirmLeader()">确认</button>
                                    <button type="button" class="btn btn-primary" data-dismiss="modal">取消</button>
                                </div>
                            </div>
                        </div>
                    </div>
 
