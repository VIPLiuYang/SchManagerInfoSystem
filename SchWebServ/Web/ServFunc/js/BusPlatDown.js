$("#TagsBusinessPlatfrom").tagsinput({
    itemValue: 'id',
    itemText: 'text',
});

var treeBusPlatObj;

var settingBusPlat = {
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
        $('#TagsBusinessPlatfrom').tagsinput('add', { id: treeNode.id, text: treeNode.name });
    } else {
        $('#TagsBusinessPlatfrom').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
    }
};
//科目删除触发
$('#TagsBusinessPlatfrom').on('itemRemoved', function (event) {
    var node = treeBusPlatObj.getNodeByParam("id", event.item.id, null);
    treeBusPlatObj.checkNode(node, false, false);
});


//初始化
$(function () {
    treeBusPlatObj = $.fn.zTree.init($("#treebusplat"), settingBusPlat, busPlatfromTreeNode);//选择科目初始化
});

