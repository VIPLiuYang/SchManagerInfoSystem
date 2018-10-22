$("#SelectContent0").tagsinput({
    itemValue: 'id',
    itemText: 'text',
});



var settinAddInfo = {
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
        //beforeClick: function (treeId, treeNode) {
        //},
        onCheck: AddInfoTreeOnCheck
    }
};
//与选中联动(选择科目）
function AddInfoTreeOnCheck(event, treeId, treeNode) {
    treeNodestr = treeNode;
    var treeIdstr = treeId.substring(10, treeId.length);
    if (treeNode.checked) {
        $('#SelectContent' + treeIdstr).tagsinput('add', { id: treeNode.id, text: treeNode.name });
    } else {
        $('#SelectContent' + treeIdstr).tagsinput('remove', { id: treeNode.id, text: treeNode.name });
    }
};

$('#SelectContent0').on('itemRemoved', function (event) {
    var node = treeAddInfoObj[varname].getNodeByParam("id", event.item.id, null);
    treeAddInfoObj[varname].checkNode(node, false, false);
});



//初始化
$(function () {
    treeAddInfoObj[varname] = $.fn.zTree.init($("#treeSelect0"), settinAddInfo, selectconPrdTreeNode);
});

