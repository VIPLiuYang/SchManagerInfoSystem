//$(document).find("#TagsExtPer0").tagsinput({
//    itemValue: 'id',
//    itemText: 'text',
//});

//var treeServBusObj0;

var settingServFuncExt = {
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
            rootPId: "0",
        }
    },
    callback: {
        beforeClick: function (treeId, treeNode) {
        },
        onCheck: ServFuncExtTreeOnCheck
    }
};
//與選中聯動
function ServFuncExtTreeOnCheck(event, treeId, treeNode) {
    var tagid = treeId.substring(4, treeId.length);
    if (treeNode.checked) {
        $("#" + tagid).tagsinput('add', { id: treeNode.id, text: treeNode.name });
    } else {
        $("#" + tagid).tagsinput('remove', { id: treeNode.id, text: treeNode.name });
    }
};

//刪除select下拉列表item時觸發
$(document).on("itemRemoved", "select[name=\"SelectFuncExt\"]", function (event) {
    var rel = $(this).attr("index");
    var name = $(this).attr("class");
    var treeObjss = $.fn.zTree.getZTreeObj("tree" + name + rel);
    var nodess = treeObjss.getNodeByParam("id", event.item.id, null);
    treeObjss.checkNode(nodess, false, false);
})
