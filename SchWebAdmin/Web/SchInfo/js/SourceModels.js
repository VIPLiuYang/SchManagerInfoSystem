//资源模块树级资源模块选择--Start
//初始化资源模块选择
$("#tags-soures").tagsinput({
    itemValue: 'id',
    itemText: 'text',
});
//资源模块删除触发
$('#tags-soures').on('itemRemoved', function (event) {
    var node = treesouresObj.getNodeByParam("id", event.item.id, null);
    treesouresObj.checkNode(node, false, false);
});
var treesouresObj;

var settingsoures = {
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
            rootPId: ""
        }
    },
    callback: {
        beforeClick: function (treeId, treeNode) {
        },
        onCheck: SoureszTreeOnCheck
    }
};
$(function () {
    if(treeNodessoure)
    {
        for (var x in treeNodessoure) {
            if(treeNodessoure[x].checked=='true')
            {
                //var idval = "";
                //var ss = treeNodessoure[x].isShar;
                //if (treeNodessoure[x].isShar == 'true') {
                //    idval = treeNodessoure[x].id+',1';
                //}else{
                //    idval = treeNodessoure[x].id + ',0';
                //}
                $('#tags-soures').tagsinput('add', { id: treeNodessoure[x].id, text: treeNodessoure[x].name });
            }
    
        }
    }
    treesouresObj = $.fn.zTree.init($("#treesoure"), settingsoures, treeNodessoure);
    treesouresObj.expandAll(true);

});
//与选中联动
function SoureszTreeOnCheck(event, treeId, treeNode) {
    if (treeNode.checked) {
        $('#tags-soures').tagsinput('add', { id: treeNode.id, text: treeNode.name });
    } else {
        $('#tags-soures').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
    }
};
//资源模块树级资源模块选择--End