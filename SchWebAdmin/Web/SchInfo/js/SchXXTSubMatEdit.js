//声明变量区
var treeHomeSubsObj1 = ""; var treeHomeSubsObj2 = ""; var treeHomeSubsObj3 = ""; var treeHomeSubsObj4 = "";
var treeHomeMaterObj1 = ""; treeHomeMaterObj2 = ""; treeHomeMaterObj3 = ""; treeHomeMaterObj4 = "";
///单击科目的CheckBox或radio时触发的回调函数
function TreeHomSchSubsOnCheck(event, treeId, treeNode) {
    var subeduvernum = treeId.substring(treeId.length - 1, treeId.length);
    var curentsubcode = treeNode.id;
    var tagsval = $("#TagsHomSch" + subeduvernum).val();
    var treeObjs = $.fn.zTree.getZTreeObj("TreeHomSchMat" + subeduvernum);
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
                $("#TagsHomSch" + subeduvernum).tagsinput('remove', { id: tagsval[i], text: null });
            }
        }
    }
}
///单击教版的CheckBox或radio时触发的回调函数
function TreeHomSchMaterOnCheck(event, treeId, treeNode) {
    var treeIdnum = treeId.substring(treeId.length - 1, treeId.length);
    if (treeNode.subcodechk != "") {
        var submatid = treeNode.subcodechk + "|" + treeNode.MaterCode;
        var submattext = treeNode.SubName + "(" + treeNode.name + ")";

        var treeObjSubsstr = $.fn.zTree.getZTreeObj("TreeHomSchSub" + treeIdnum);//科目树
        var treeObjsubsenode = treeObjSubsstr.getNodeByParam("id", treeNode.subcodechk, null);//对应科目节点

        var treeMatObjs = $.fn.zTree.getZTreeObj(treeId);//教版树
        if (treeNode.checked) {
            $("#TagsHomSch" + treeIdnum).tagsinput('add', { id: submatid, text: submattext });
            treeObjsubsenode.checked = true;
            treeObjSubsstr.updateNode(treeObjsubsenode);
        } else {
            $("#TagsHomSch" + treeIdnum).tagsinput('remove', { id: submatid, text: submattext });
            var nodess = treeMatObjs.getCheckedNodes(true);
            if (nodess.length == 0) {
                treeObjsubsenode.checked = false;
                treeObjSubsstr.updateNode(treeObjsubsenode);
            }
        }
        $("#HomSchPer" + treeIdnum).prop("checked", "checked");
    } else {
        alert("请选择科目");
    }
}
//声明多选select变量
$("#TagsHomSch1").tagsinput({
    itemValue: 'id',
    itemText: 'text',
});
$("#TagsHomSch2").tagsinput({
    itemValue: 'id',
    itemText: 'text',
});
$("#TagsHomSch3").tagsinput({
    itemValue: 'id',
    itemText: 'text',
});
$("#TagsHomSch4").tagsinput({
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
            var tagsval = $("#TagsHomSch" + subeduvernum).val();//科目选择
            var treeObjs = $.fn.zTree.getZTreeObj("TreeHomSchMat" + subeduvernum);//教版树
            var treeObjSubs = $.fn.zTree.getZTreeObj("TreeHomSchSub" + subeduvernum);//科目树
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
        onCheck: TreeHomSchSubsOnCheck//单击复选框或者单选框时执行
    }
};
//以上是学科科目---End
//初始化科目树
treeHomeSubsObj1 = $.fn.zTree.init($("#TreeHomSchSub1"), settingSub, treeNodesSubss);//初始化幼儿园科目树
treeHomeSubsObj2 = $.fn.zTree.init($("#TreeHomSchSub2"), settingSub, treeNodesSubss);//初始化小学科目树
treeHomeSubsObj3 = $.fn.zTree.init($("#TreeHomSchSub3"), settingSub, treeNodesSubss);//初始化初中科目树
treeHomeSubsObj4 = $.fn.zTree.init($("#TreeHomSchSub4"), settingSub, treeNodesSubss);//初始化高中科目树
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
            var treeObjMats = $.fn.zTree.getZTreeObj("TreeHomSchMat" + treeIdnum);//教版树
            var treeusernode = treeObjMats.getNodeByParam("id", treeNode.id, null);
            treeObjMats.selectNode(treeusernode, false);
        },
        onCheck: TreeHomSchMaterOnCheck
    }
};
//以上是教版---End
//初始化教版树
treeHomeMaterObj1 = $.fn.zTree.init($("#TreeHomSchMat1"), settingmater, treeNodeMater);//初始化幼儿园教版树
treeHomeMaterObj2 = $.fn.zTree.init($("#TreeHomSchMat2"), settingmater, treeNodeMater);//初始化小学教版树
treeHomeMaterObj3 = $.fn.zTree.init($("#TreeHomSchMat3"), settingmater, treeNodeMater);//初始化初中教版树
treeHomeMaterObj4 = $.fn.zTree.init($("#TreeHomSchMat4"), settingmater, treeNodeMater);//初始化高中教版树

$(function () {
    //当触发多选select删除按钮时
    $("#TagsHomSch1").on('itemRemoved', function (event) {
        var eidstr = event.item.id;//当前删除教版id值
        var eidsubid = eidstr.split('|')[0];//科目code
        var eidmatid = eidstr.split('|')[1];//教版code
        //
        var node = treeHomeMaterObj1.getNodeByParam("id", eidmatid, null);
        treeHomeMaterObj1.checkNode(node, false, false);//取消当前教版code复选框的勾选状态
        //查询科目教版多选（select)下拉框中是否还有当前科目code
        var issubtags1 = 0
        var tags1val = $("#TagsHomSch1").val();
        for (var i in tags1val) {
            if (tags1val[i].split('|')[0] == eidsubid) {
                issubtags1++;
            }
        }
        if (issubtags1 == 0) {//如果没有科目code
            var nodesub = treeHomeSubsObj1.getNodeByParam("id", eidsubid, null);
            nodesub.checked = false;
            treeHomeSubsObj1.updateNode(nodesub);//取消当前科目code复选框的勾选状态
        }
        if (Number($("#TagsHomSch1").val()) == 0) {
            $("#HomSchPer1").prop("checked", false);
        }
    });
    $("#TagsHomSch2").on('itemRemoved', function (event) {
        var eidstr = event.item.id;//当前删除教版id值
        var eidsubid = eidstr.split('|')[0];//科目code
        var eidmatid = eidstr.split('|')[1];//教版code
        //
        var node = treeHomeMaterObj2.getNodeByParam("id", eidmatid, null);
        treeHomeMaterObj2.checkNode(node, false, false);//取消当前教版code复选框的勾选状态
        //查询科目教版多选（select)下拉框中是否还有当前科目code
        var issubtags2 = 0
        var tags1val = $("#TagsHomSch2").val();
        for (var i in tags1val) {
            if (tags1val[i].split('|')[0] == eidsubid) {
                issubtags2++;
            }
        }
        if (issubtags2 == 0) {//如果没有科目code
            var nodesub = treeHomeSubsObj2.getNodeByParam("id", eidsubid, null);
            nodesub.checked = false;
            treeHomeSubsObj2.updateNode(nodesub);//取消当前科目code复选框的勾选状态
        }
        if (Number($("#TagsHomSch2").val()) == 0) {
            $("#HomSchPer2").prop("checked", false);
        }
    });
    $("#TagsHomSch3").on('itemRemoved', function (event) {
        var eidstr = event.item.id;//当前删除教版id值
        var eidsubid = eidstr.split('|')[0];//科目code
        var eidmatid = eidstr.split('|')[1];//教版code
        //
        var node = treeHomeMaterObj3.getNodeByParam("id", eidmatid, null);
        treeHomeMaterObj3.checkNode(node, false, false);//取消当前教版code复选框的勾选状态
        //查询科目教版多选（select)下拉框中是否还有当前科目code
        var issubtags3 = 0
        var tags1val = $("#TagsHomSch3").val();
        for (var i in tags1val) {
            if (tags1val[i].split('|')[0] == eidsubid) {
                issubtags3++;
            }
        }
        if (issubtags3 == 0) {//如果没有科目code
            var nodesub = treeHomeSubsObj3.getNodeByParam("id", eidsubid, null);
            nodesub.checked = false;
            treeHomeSubsObj3.updateNode(nodesub);//取消当前科目code复选框的勾选状态
        }
        if (Number($("#TagsHomSch3").val()) == 0) {
            $("#HomSchPer3").prop("checked", false);
        }
    });
    $("#TagsHomSch4").on('itemRemoved', function (event) {
        var eidstr = event.item.id;//当前删除教版id值
        var eidsubid = eidstr.split('|')[0];//科目code
        var eidmatid = eidstr.split('|')[1];//教版code
        //
        var node = treeHomeMaterObj4.getNodeByParam("id", eidmatid, null);
        treeHomeMaterObj4.checkNode(node, false, false);//取消当前教版code复选框的勾选状态
        //查询科目教版多选（select)下拉框中是否还有当前科目code
        var issubtags4 = 0
        var tags1val = $("#TagsHomSch4").val();
        for (var i in tags1val) {
            if (tags1val[i].split('|')[0] == eidsubid) {
                issubtags4++;
            }
        }
        if (issubtags4 == 0) {//如果没有科目code
            var nodesub = treeHomeSubsObj4.getNodeByParam("id", eidsubid, null);
            nodesub.checked = false;
            treeHomeSubsObj4.updateNode(nodesub);//取消当前科目code复选框的勾选状态
        }
        if (Number($("#TagsHomSch4").val()) == 0) {
            $("#HomSchPer4").prop("checked", false);
        }
    });

    //单击科目教版按钮时触发
    $(document).on("click", ".submatbtn", function () {
        var relid = $(this).attr("relid");
        var treeObj = $.fn.zTree.getZTreeObj("TreeHomSchSub" + relid);
        treeObj.checkAllNodes(false);
        var tagsval = $("#TagsHomSch" + relid).val();
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
            //var treeObjSubs = $.fn.zTree.getZTreeObj("TreeSub" + relid);
            treeObj.checkAllNodes();
            //科目树默认第一个触发单击事件
            var enodeext = treeObj.getNodeByParam("id", "01", null);
            treeObj.setting.callback.beforeClick(treeObj.setting.treeId, enodeext);
            treeObj.selectNode(enodeext);
        }
    });

    if (showmaterxxttree) {
        for (var x in showmaterxxttree) {
            if (showmaterxxttree[x].PerCode == "1") {
                //if (showmatertreeNodes[x].checked ==true) {
                var submatsid = showmaterxxttree[x].SubCode + "|" + showmaterxxttree[x].MaterCode;
                var submattext = showmaterxxttree[x].SubName + "(" + showmaterxxttree[x].MaterName + ")";
                $("#TagsHomSch1").tagsinput('add', { id: submatsid, text: submattext });
                //}
            }
        }
    }
    if ($("#TagsHomSch1").val() != null) {
        $("#HomSchPer1").prop("checked", true);
    }

    if (showmaterxxttree) {
        for (var x in showmaterxxttree) {
            if (showmaterxxttree[x].PerCode == "2") {
                //if (showmatertreeNodes[x].checked ==true) {
                var submatsid = showmaterxxttree[x].SubCode + "|" + showmaterxxttree[x].MaterCode;
                var submattext = showmaterxxttree[x].SubName + "(" + showmaterxxttree[x].MaterName + ")";
                $("#TagsHomSch2").tagsinput('add', { id: submatsid, text: submattext });
                //}
            }
        }
    }
    if ($("#TagsHomSch2").val() != null) {
        $("#HomSchPer2").prop("checked", true);
    }

    if (showmaterxxttree) {
        for (var x in showmaterxxttree) {
            if (showmaterxxttree[x].PerCode == "3") {
                //if (showmatertreeNodes[x].checked ==true) {
                var submatsid = showmaterxxttree[x].SubCode + "|" + showmaterxxttree[x].MaterCode;
                var submattext = showmaterxxttree[x].SubName + "(" + showmaterxxttree[x].MaterName + ")";
                $("#TagsHomSch3").tagsinput('add', { id: submatsid, text: submattext });
                //}
            }
        }
    }
    if ($("#TagsHomSch3").val() != null) {
        $("#HomSchPer3").prop("checked", true);
    }

    if (showmaterxxttree) {
        for (var x in showmaterxxttree) {
            if (showmaterxxttree[x].PerCode == "4") {
                //if (showmatertreeNodes[x].checked ==true) {
                var submatsid = showmaterxxttree[x].SubCode + "|" + showmaterxxttree[x].MaterCode;
                var submattext = showmaterxxttree[x].SubName + "(" + showmaterxxttree[x].MaterName + ")";
                $("#TagsHomSch4").tagsinput('add', { id: submatsid, text: submattext });
                //}
            }
        }
    }
    if ($("#TagsHomSch4").val() != null) {
        $("#HomSchPer4").prop("checked", true);
    }

})