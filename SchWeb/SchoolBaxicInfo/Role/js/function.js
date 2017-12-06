//获取GET参数方法
function getPar(par) {
    //获取当前URL
    var local_url = document.location.href;
    //获取要取得的get参数位置
    var get = local_url.indexOf(par + "=");
    if (get == -1) {
        return false;
    }
    //截取字符串
    var get_par = local_url.slice(par.length + get + 1);
    //判断截取后的字符串是否还有其他get参数
    var nextPar = get_par.indexOf("&");
    if (nextPar != -1) {
        get_par = get_par.slice(0, nextPar);
    }
    return get_par;
}
/* 
     * 截取指定字节长度的字符串 
     * 注：半角长度为1，全角长度为2
     * str:字符串 
     * len:截取长度
     * return: 截取后的字符串及是否截取的标记（扩展用）code=1 字符串截断   code=0  字符串未截断
     */
function cutStrByte(str, len) {
    //校验参数
    if (!str || !len) {
        return { "cutStr": "", "code": 0 };
    }
    var code = "1",// 默认返回code值，已截断
        strLen = str.length,// 原字符串长度
        cutStr;
    //如果字符串长度小于截取长度的一半,则返回全部字符串
    if (strLen <= len / 2) {
        cutStr = str;
        code = "0";
    } else {
        //遍历字符串
        var strByteCount = 0;
        for (var i = 0; i < strLen ; i++) {
            //中文字符字节加2  否则加1
            strByteCount += getByteLen(str.charAt(i));
            //i从0开始 截断时大于len 只截断到第i个
            if (strByteCount > len) {
                cutStr = str.substring(0, i);
                break;
            } else if (strByteCount == len) {
                cutStr = str.substring(0, i + 1);
                break;
            }
        }
    }
    //cutstr为空，没有截断字符串
    if (!cutStr) {
        cutStr = str;
        code = "0";
    }
    return { "cutStr": cutStr, "code": code };
};

/**
 * 获取字节长度，全角字符两个单位长度，半角字符1个单位长度
 */
function getByteLen(val) {
    var len = 0;
    if (!val) {
        return len;
    }
    for (var i = 0; i < val.length; i++) {
        if (!val[i]) {
            continue;
        }
        // 全角
        if (val[i].match(/[^\x00-\xff]/ig) != null) {
            len += 2;
        } else {
            len += 1;
        }
    }
    return len;
};
/*

请字符串转换为byte数组
*/
function stringToBytes(str) {
    var ch, st, re = [];
    for (var i = 0; i < str.length; i++) {
        ch = str.charCodeAt(i);  // get char   
        st = [];                 // set up "stack"  
        do {
            st.push(ch & 0xFF);  // push byte to stack  
            ch = ch >> 8;          // shift value down by 1 byte  
        }
        while (ch);
        // add stack contents to result  
        // done because chars have "wrong" endianness  
        re = re.concat(st.reverse());
    }
    // return an array of bytes  
    return re;
};