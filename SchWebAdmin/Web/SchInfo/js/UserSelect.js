/*下面是选择人员下拉列表*/
//初始化部门选择
$("#tags-depts").tagsinput({
    itemValue: 'id',
    itemText: 'text',
});
var treedeptObj;
//$('#tags-depts').on('itemRemoved', function (event) {
//    var node = treedeptObj.getNodeByParam("id", event.item.id, null);
//    treedeptObj.checkNode(node, false, false);
//    // event.item: contains the item
//});

var settingdept = {
    view:
            {
                //addHoverDom: addHoverDom,//用于当鼠标移动到节点上时，显示用户自定义控件，显示隐藏状态同 zTree 内部的编辑、删除按钮
                //removeHoverDom: removeHoverDom,//用于当鼠标移出节点时，隐藏用户自定义控件，显示隐藏状态同 zTree 内部的编辑。删除按钮.请务必与 addHoverDom 同时使用；
                //selectedMulti: true,//设置是否允许同时选中多个节点。
                dblClickExpand: false,
                showLine: true,
                selectedMulti: false
            },
    check:
    {
        enable: true,//设置 zTree 的节点上是否显示 checkbox / radio。参数说明：true / false 分别表示 显示 / 不显示 复选框或单选框
        chkboxType: { "Y": "ps", "N": "ps" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
        chkStyle: "radio",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效] 
        radioType: "all",
    },
    data:
    {
        simpleData:
        {
            enable: true,//配置数据是否父子数据分级。如果enable值为true，则以树形结构输出；否则，依次按顺序平级的形式输出。
            idKey: "id",
            pIdKey: "pId",
            checked: "checked",
            rootPId: "0"
        }
    },
    edit:
    {
        enable: false//配置添加、删除、编辑是否可以操作。如果enable值为true，则可以操作；否则，不可以操作。
    },
    callback: {
        beforeClick: function (treeId, treeNode) {
        },
        onCheck: DeptzTreeOnCheck
    }
};
$(function () {
            
    treedeptObj = $.fn.zTree.init($("#treedept"), settingdept, treeNodesdept);
    treedeptObj.expandAll(true);

    //$("#treeroles .checkbox_false_full").css("display","none");

});
//与选中联动
function DeptzTreeOnCheck(event, treeId, treeNode) {
    
    if (treeNode.checked) {
        $("#FrontlineTechni").val(treeNode.name);
        //$('#tags-depts').tagsinput('add', { id: treeNode.id, text: treeNode.name });
    } else {
        //$('#tags-depts').tagsinput('remove', { id: treeNode.id, text: treeNode.name });
    }
};
/*以上是选择人员下拉列表*/
//初始化
//$(function () {
//    //选择人员
//    if(treeNodesdept)
//    {
//        for (var x in treeNodesdept) {
//            if(treeNodesdept[x].checked=='true')
//            {
//                $('#tags-depts').tagsinput('add', { id: treeNodesdept[x].id, text: treeNodesdept[x].name });
//            }
    
//        }
//    } 
//});