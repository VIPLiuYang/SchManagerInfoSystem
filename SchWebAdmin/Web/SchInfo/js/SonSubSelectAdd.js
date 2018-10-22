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
    var node = treesubsObj.getNodeByParam("id", event.item.id, null);
    treesubsObj.checkNode(node, false, false);
});
/*下面是子系统选择下拉列表代码*/
//初始化 子系统 选择
$("#sonsys").tagsinput({
    itemValue: 'id',
    itemText: 'text',
});
//子系统树配置
var settingsonsys = {
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
        onCheck: SonsysTreeOnCheck
    }
};
//与选中联动(子系统选择）
function SonsysTreeOnCheck(event, treeId, treeNode) {
    if (treeNode.checked) {
        $('#sonsys').tagsinput('add', { id: treeNode.id, text: treeNode.name });
    } else {
        $('#sonsys').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
    }
};
//子系统删除触发
$('#sonsys').on('itemRemoved', function (event) {
    var node = treeSonsysObj.getNodeByParam("id", event.item.id, null);
    treeSonsysObj.checkNode(node, false, false);
});
//初始化
$(function () {
    treesubsObj = $.fn.zTree.init($("#substree"), settingsubs, treesubsNodes);//选择科目初始化
    treeSonsysObj = $.fn.zTree.init($("#sonsystree"), settingsonsys, treesonsysNodes);//选择子系统初始化
    //設置子系統缺省值
    if (treesonsysNodes)//判斷子系統對象是否存在
    {
        for (var x in treesonsysNodes) {//遍歷子系統數據
            if (treesonsysNodes[x].checked == 'true')//如果check為true
            {
                $('#sonsys').tagsinput('add', { id: treesonsysNodes[x].id, text: treesonsysNodes[x].name });//向select多項框中添加
            }
        }
    }
});