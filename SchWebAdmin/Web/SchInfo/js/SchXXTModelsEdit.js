
//初始化子模块选择
$("#tags-homeSching").tagsinput({
    itemValue: 'id',
    itemText: 'text',
});
//资源模块删除触发
$('#tags-homeSching').on('itemRemoved', function (event) {
    var node = treehomeschObj.getNodeByParam("id", event.item.id, null);
    treehomeschObj.checkNode(node, false, false);
});
var treehomeschObj;
var settinghomsch = {
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
        onCheck: HomeSchTreeOnCheck
    }
};
$(function () {
    if (sarxxttreeNode) {
        for (var x in sarxxttreeNode) {
            if (sarxxttreeNode[x].checked == 'true') {
                $('#tags-homeSching').tagsinput('add', { id: sarxxttreeNode[x].id, text: sarxxttreeNode[x].name });
            }

        }
    }
    treehomeschObj = $.fn.zTree.init($("#treehomesch"), settinghomsch, sarxxttreeNode);
    treehomeschObj.expandAll(true);

});
//与选中联动
function HomeSchTreeOnCheck(event, treeId, treeNode) {
    if (treeNode.checked) {
        $('#tags-homeSching').tagsinput('add', { id: treeNode.id, text: treeNode.name });
    } else {
        $('#tags-homeSching').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
    }
};
