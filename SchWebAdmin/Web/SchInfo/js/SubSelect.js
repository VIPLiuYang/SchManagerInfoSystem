/*下面是科目选择下拉列表代码*/
//初始化 科目 选择
$("#selsubs").tagsinput({
    itemValue: 'id',
    itemText: 'text',
});
//科目树配置
var settingsubs = {
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
            rootPId: "0"
        }
    },
    callback: {
        beforeClick: function (treeId, treeNode) {
        },
        onCheck: SubsTreeOnCheck
    }
};
//与选中联动(选择科目）
function SubsTreeOnCheck(event, treeId, treeNode) {
    if (treeNode.checked) {
        $('#selsubs').tagsinput('add', { id: treeNode.id, text: treeNode.name });
    } else {
        $('#selsubs').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
    }
};
//科目删除触发
$('#selsubs').on('itemRemoved', function (event) {
    //if (event.item.id > 10) { event.item.id += "0" + event.item.id; }
    var params = '{"schid":"' + schid + '","subcode":"' + event.item.id + '"}';
    $.ajax({
        type: "POST",  //请求方式
        url: "SchEdit.aspx/isSchSub",  //请求路径：页面/方法名字
        data: params,     //参数
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d.code == 'ClassTeacher') {
                alert(data.d.msg);
                $('#selsubs').tagsinput('add', { id: event.item.id, text: event.item.text });

            }
            else if (data.d.code == 'SubLeader') {
                alert("科目已在科目组长中设置使用，不允许删除");
                $('#selsubs').tagsinput('add', { id: event.item.id, text: event.item.text });

            } else if (data.d.code == "0000") {
                var node = treesubsObj.getNodeByParam("id", event.item.id, null);
                treesubsObj.checkNode(node, false, false);
            } else if (data.d.code == "expire") {
                window.location.href = "../../LoginExc.aspx";
            }
            else if (data.d.code == "ExcepError")
            {
                alert(data.d.msg);
            }
        },
        error: function (obj, msg, e) {
        }
    });

    //var node = treesubsObj.getNodeByParam("id", event.item.id, null);
    //treesubsObj.checkNode(node, false, false);
});


//初始化
$(function () {
    treesubsObj = $.fn.zTree.init($("#substree"), settingsubs, treesubsNodes);//选择科目初始化
    //设置科目缺省值
    if (schsubsNodes) {
        for (var x in schsubsNodes) {
            
            $('#selsubs').tagsinput('add', { id: schsubsNodes[x].id, text: schsubsNodes[x].name });
            

        }
    }
});