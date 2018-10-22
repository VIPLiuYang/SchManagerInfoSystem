
$("#TagsOrderPackage").tagsinput({
    itemValue: 'id',
    itemText: 'text',
});

var treeServBusObj;

var settingServBus = {
    check: {
        enable: true,
        autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]   
        chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]   
        chkStyle: "radio",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
        //enable: true,//设置 zTree 的节点上是否显示 checkbox / radio。参数说明：true / false 分别表示 显示 / 不显示 复选框或单选框
        //chkboxType: { "Y": "ps", "N": "ps" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
        //chkStyle: "radio",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效] 
        //radioType: "all",
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
            rootPId: "0",
            FeeCode: "FeeCode",
            BusMonth: "BusMonth"
        }
    },
    callback: {
        beforeClick: function (treeId, treeNode) {
        },
        onCheck: ServBusTreeOnCheck
    }
};
//與選中聯動
function ServBusTreeOnCheck(event, treeId, treeNode) {
    if (treeNode.checked) {
        $("#BusTariff").val((treeNode.FeeCode / treeNode.BusMonth) + "元/月");
        $('#TagsOrderPackage').tagsinput('add', { id: treeNode.id, text: treeNode.name });
    } else {
        $('#TagsOrderPackage').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
    }
};
//刪除時觸發
$('#TagsOrderPackage').on('itemRemoved', function (event) {
    var node = treeServBusObj.getNodeByParam("id", event.item.id, null);
    treeServBusObj.checkNode(node, false, false);
    if ($('#TagsOrderPackage').val() == null) {
        $("#BusTariff").val("");
    }
});


//初始化
$(function () {
    treeServBusObj = $.fn.zTree.init($("#treeorderpackage"), settingServBus, ServBusTreeNode);//初始化
    if (ServBusTreeNode) {
        for (var x in ServBusTreeNode) {
            if ((ServBusTreeNode[x].checked).toLowerCase() == "true") {
                $("#TagsOrderPackage").tagsinput("add", { id: ServBusTreeNode[x].id, text: ServBusTreeNode[x].name });
            }

        }
    }
});

