//声明变量区
var treeSubsObj1 = ""; var treeSubsObj2 = ""; var treeSubsObj3 = ""; var treeSubsObj4 = "";
var treeMaterObj1 = ""; treeMaterObj2 = ""; treeMaterObj3 = ""; treeMaterObj4 = "";
///单击科目的CheckBox或radio时触发的回调函数
function TreeSubsOnCheck(event, treeId, treeNode) {
    var subeduvernum = treeId.substring(treeId.length - 1, treeId.length);
    var curentsubcode = treeNode.id;
    var tagsval = $("#Tags" + subeduvernum).val();
    var treeObjs = $.fn.zTree.getZTreeObj("TreeEduVer" + subeduvernum);
    treeObjs.checkAllNodes();
    var nodess = treeObjs.getNodes();
    if (nodess.length > 0) {
        for (var j = 0; j < nodess.length; j++) {
            if (nodess[j].SubCode == curentsubcode && nodess[j].PerCode == subeduvernum) {
                nodess[j].checked = true;

            }
            nodess[j].subcodechk = treeNode.id;//SubCode
            nodess[j].SubName = treeNode.name;//SubName
            treeObjs.updateNode(nodess[j]);
        }
    }
    if (treeNode.checked == false) {
        for (var i = 0; i < tagsval.length; i++) {
            if (tagsval[i].split('|')[0] == treeNode.id) {
                $("#Tags" + subeduvernum).tagsinput('remove', { id: tagsval[i], text: null });
            }
        }
    }
}
///单击教版的CheckBox或radio时触发的回调函数
function TreeMaterOnCheck(event, treeId, treeNode) {
    var treeIdnum = treeId.substring(treeId.length - 1, treeId.length);
    if (treeNode.subcodechk != "") {
        var submatid = treeNode.subcodechk + "|" + treeNode.MaterCode;
        var submattext = treeNode.SubName + "(" + treeNode.name + ")";

        var treeObjSubsstr = $.fn.zTree.getZTreeObj("TreeSub" + treeIdnum);//科目树
        var treeObjsubsenode = treeObjSubsstr.getNodeByParam("id", treeNode.subcodechk, null);//对应科目节点

        var treeMatObjs = $.fn.zTree.getZTreeObj(treeId);//教版树
        if (treeNode.checked) {
            $("#Tags" + treeIdnum).tagsinput('add', { id: submatid, text: submattext });
            treeObjsubsenode.checked = true;
            treeObjSubsstr.updateNode(treeObjsubsenode);
        } else {
            $("#Tags" + treeIdnum).tagsinput('remove', { id: submatid, text: submattext });
            var nodess = treeMatObjs.getCheckedNodes(true);
            if (nodess.length == 0) {
                treeObjsubsenode.checked = false;
                treeObjSubsstr.updateNode(treeObjsubsenode);
            }
        }
        $("#Per" + treeIdnum).prop("checked", "checked");
    } else {
        alert("请选择科目");
    }
}
//声明多选select变量
$("#Tags1").tagsinput({
    itemValue: 'id',
    itemText: 'text',
});
$("#Tags2").tagsinput({
    itemValue: 'id',
    itemText: 'text',
});
$("#Tags3").tagsinput({
    itemValue: 'id',
    itemText: 'text',
});
$("#Tags4").tagsinput({
    itemValue: 'id',
    itemText: 'text',
});
//以下是学科科目---Start
var settingSub = {
    check: {
        enable: true,
        //autoCheckTrigger: true,//设置自动关联勾选时是否触发 beforeCheck / onCheck 事件回调函数。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
        chkboxType: { "Y": "", "N": "" },//勾选 checkbox 对于父子节点的关联关系。[setting.check.enable = true 且 setting.check.chkStyle = "checkbox" 时生效]  
        chkStyle: "checkbox",//勾选框类型(checkbox 或 radio）[setting.check.enable = true 时生效]  
        chkDisabledInherit: true
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
            datacode: "datacode",
            rootPId: "",
            chkDisabled: true,
        }
    },
    callback: {
        beforeClick: function (treeId, treeNode) {
            var subeduvernum = treeId.substring(treeId.length - 1, treeId.length);//科目树节点ID
            var curentsubcode = treeNode.id;//当前科目CODE
            var tagsval = $("#Tags" + subeduvernum).val();//科目选择
            var treeObjs = $.fn.zTree.getZTreeObj("TreeEduVer" + subeduvernum);//教版树
            var treeObjSubs = $.fn.zTree.getZTreeObj("TreeSub" + subeduvernum);//科目树
            treeObjs.checkAllNodes(false);
            var nodess = treeObjs.getNodes();//教版树节点
            if (nodess.length > 0) {
                if (tagsval != null && tagsval.length > 0)//有选择的科目
                {
                    for (var i = 0; i < tagsval.length; i++) {
                        var submaterstr = tagsval[i];
                        var submater = submaterstr.split('|');
                        if (submater[0] == curentsubcode) {
                            var enode = treeObjs.getNodeByParam("id", submater[1], null);
                            enode.checked = true;
                            treeObjs.updateNode(enode);
                        }
                    }
                }
                for (var j = 0; j < nodess.length; j++) {
                    if (nodess[j].SubCode == curentsubcode) {// && nodess[j].PerCode == subeduvernum
                        nodess[j].checked = true;
                    }
                    nodess[j].subcodechk = treeNode.id;//SubCode
                    nodess[j].SubName = treeNode.name;//SubName
                    treeObjs.updateNode(nodess[j]);
                }

            }
        },
        onCheck: TreeSubsOnCheck//单击复选框或者单选框时执行
    }
};
//以上是学科科目---End
//初始化科目树
treeSubsObj1 = $.fn.zTree.init($("#TreeSub1"), settingSub, treeNodesSubss);//初始化幼儿园科目树
treeSubsObj2 = $.fn.zTree.init($("#TreeSub2"), settingSub, treeNodesSubss);//初始化小学科目树
treeSubsObj3 = $.fn.zTree.init($("#TreeSub3"), settingSub, treeNodesSubss);//初始化初中科目树
treeSubsObj4 = $.fn.zTree.init($("#TreeSub4"), settingSub, treeNodesSubss);//初始化高中科目树
//以下是教版---Start
var settingmater = {
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
            rootPId: "",
            subcodechk: "subcodechk"
        }
    },
    callback: {
        beforeClick: function (treeId, treeNode) {
            //alert(treeNode.subcodechk);
            var treeObjMats = $.fn.zTree.getZTreeObj("TreeEduVer" + treeIdnum);//教版树
            //var treeIdnum = treeId.substring(treeId.length - 1, treeId.length);
            //if (treeNode.subcodechk != "") {
            //    var submatid = treeNode.subcodechk + "|" + treeNode.MaterCode;
            //    var submattext = treeNode.SubName + "(" + treeNode.name + ")";
            //    $("#Tags" + treeIdnum).tagsinput('add', { id: submatid, text: submattext });
            //    $("#" + treeId).parent().parent().parent().parent().parent().find("#Per" + treeIdnum).prop("checked", "checked");

            //    var enodemats = treeObjMats.getNodeByParam("id", treeNode.id, null);
            //    enodemats.checked = true;
            //    treeObjMats.updateNode(enodemats);

            //} else {
            //    alert("请选择科目");
            //}
            var treeusernode = treeObjMats.getNodeByParam("id", treeNode.id, null);
            treeObjMats.selectNode(treeusernode, false);
        },
        onCheck: TreeMaterOnCheck
    }
};
//以上是教版---End
//初始化教版树
treeMaterObj1 = $.fn.zTree.init($("#TreeEduVer1"), settingmater, treeNodeMater);//初始化幼儿园教版树
treeMaterObj2 = $.fn.zTree.init($("#TreeEduVer2"), settingmater, treeNodeMater);//初始化小学教版树
treeMaterObj3 = $.fn.zTree.init($("#TreeEduVer3"), settingmater, treeNodeMater);//初始化初中教版树
treeMaterObj4 = $.fn.zTree.init($("#TreeEduVer4"), settingmater, treeNodeMater);//初始化高中教版树

$(function () {
    //当触发多选select删除按钮时
    $("#Tags1").on('itemRemoved', function (event) {
        var eidstr = event.item.id;//当前删除教版id值
        var eidsubid = eidstr.split('|')[0];//科目code
        var eidmatid = eidstr.split('|')[1];//教版code
        //
        var node = treeMaterObj1.getNodeByParam("id", eidmatid, null);
        treeMaterObj1.checkNode(node, false, false);//取消当前教版code复选框的勾选状态
        //查询科目教版多选（select)下拉框中是否还有当前科目code
        var issubtags1 = 0
        var tags1val = $("#Tags1").val();
        for (var i in tags1val) {
            if (tags1val[i].split('|')[0] == eidsubid) {
                issubtags1++;
            }
        }
        if (issubtags1 == 0) {//如果没有科目code
            var nodesub = treeSubsObj1.getNodeByParam("id", eidsubid, null);
            nodesub.checked = false;
            treeSubsObj1.updateNode(nodesub);//取消当前科目code复选框的勾选状态
        }
        if (Number($("#Tags1").val()) == 0) {
            $("#Per1").prop("checked", false);
        }
    });
    $("#Tags2").on('itemRemoved', function (event) {
        var eidstr = event.item.id;//当前删除教版id值
        var eidsubid = eidstr.split('|')[0];//科目code
        var eidmatid = eidstr.split('|')[1];//教版code
        //
        var node = treeMaterObj2.getNodeByParam("id", eidmatid, null);
        treeMaterObj2.checkNode(node, false, false);//取消当前教版code复选框的勾选状态
        //查询科目教版多选（select)下拉框中是否还有当前科目code
        var issubtags2 = 0
        var tags1val = $("#Tags2").val();
        for (var i in tags1val) {
            if (tags1val[i].split('|')[0] == eidsubid) {
                issubtags1++;
            }
        }
        if (issubtags2 == 0) {//如果没有科目code
            var nodesub = treeSubsObj2.getNodeByParam("id", eidsubid, null);
            nodesub.checked = false;
            treeSubsObj2.updateNode(nodesub);//取消当前科目code复选框的勾选状态
        }
        if (Number($("#Tags2").val()) == 0) {
            $("#Per2").prop("checked", false);
        }
    });
    $("#Tags3").on('itemRemoved', function (event) {
        var eidstr = event.item.id;//当前删除教版id值
        var eidsubid = eidstr.split('|')[0];//科目code
        var eidmatid = eidstr.split('|')[1];//教版code
        //
        var node = treeMaterObj3.getNodeByParam("id", eidmatid, null);
        treeMaterObj3.checkNode(node, false, false);//取消当前教版code复选框的勾选状态
        //查询科目教版多选（select)下拉框中是否还有当前科目code
        var issubtags3 = 0
        var tags1val = $("#Tags3").val();
        for (var i in tags1val) {
            if (tags1val[i].split('|')[0] == eidsubid) {
                issubtags1++;
            }
        }
        if (issubtags3 == 0) {//如果没有科目code
            var nodesub = treeSubsObj3.getNodeByParam("id", eidsubid, null);
            nodesub.checked = false;
            treeSubsObj3.updateNode(nodesub);//取消当前科目code复选框的勾选状态
        }
        if (Number($("#Tags3").val()) == 0) {
            $("#Per3").prop("checked", false);
        }
    });
    $("#Tags4").on('itemRemoved', function (event) {
        var eidstr = event.item.id;//当前删除教版id值
        var eidsubid = eidstr.split('|')[0];//科目code
        var eidmatid = eidstr.split('|')[1];//教版code
        //
        var node = treeMaterObj4.getNodeByParam("id", eidmatid, null);
        treeMaterObj4.checkNode(node, false, false);//取消当前教版code复选框的勾选状态
        //查询科目教版多选（select)下拉框中是否还有当前科目code
        var issubtags4 = 0
        var tags1val = $("#Tags4").val();
        for (var i in tags1val) {
            if (tags1val[i].split('|')[0] == eidsubid) {
                issubtags1++;
            }
        }
        if (issubtags4 == 0) {//如果没有科目code
            var nodesub = treeSubsObj4.getNodeByParam("id", eidsubid, null);
            nodesub.checked = false;
            treeSubsObj4.updateNode(nodesub);//取消当前科目code复选框的勾选状态
        }
        if (Number($("#Tags4").val()) == 0) {
            $("#Per4").prop("checked", false);
        }
    });

    //单击科目教版按钮时触发
    $(document).on("click", ".submatbtn", function () {
        var relid = $(this).attr("relid");
        var treeObj = $.fn.zTree.getZTreeObj("TreeSub" + relid);
        treeObj.checkAllNodes(false);
        var tagsval = $("#Tags" + relid).val();
        var nodes = treeObj.getNodes();
        for (var i in nodes) {
            nodes[i].chkDisabled = true;
            treeObj.updateNode(nodes[i]);
        }
        if (tagsval) {
            for (var i = 0; i < tagsval.length; i++) {
                var tagsval1 = tagsval[i].split('|')[0];
                var enodeext = treeObj.getNodeByParam("id", tagsval1, null);
                enodeext.checked = true;
                treeObj.updateNode(enodeext);
            }
            //默认显示第一个选中科目的教版
            for (var i = 0; i < tagsval.length; i++) {
                var tagsval1 = tagsval[i].split('|')[0];
                var enodeext = treeObj.getNodeByParam("id", tagsval1, null);
                treeObj.setting.callback.beforeClick(treeObj.setting.treeId, enodeext);
                treeObj.selectNode(enodeext);
                break;

            }
        } else {
            treeObj.checkAllNodes();
            //科目树默认第一个触发单击事件
            //var enodeext = treeObj.getNodeByParam("id", "01", null);
            var enodeext = "";
            if (treesubsNodes) {
                for (var x in treesubsNodes) {
                    enodeext = treeObj.getNodeByParam("id", treesubsNodes[x].id, null);
                    break;
                }
            }
            treeObj.setting.callback.beforeClick(treeObj.setting.treeId, enodeext);
            treeObj.selectNode(enodeext);
        }
    });
})