/*
**
**本文件为公共文件：公共文件与业务功能无直接关联
**
*/

//出错的监听
window.onerror = function(errorMessage, scriptURI, lineNumber, columnNumber, errorObj) {
	console.log("---ERROR---start---");
	console.log("错误信息-0:" + JSON.stringify(errorMessage.detail));
	console.log("错误信息-1:" + errorMessage);
	console.log("出错文件:" + scriptURI);
	console.log("出错行号:" + lineNumber);
	console.log("出错列号:" + columnNumber);
	console.log("错误详情:" + errorObj);
	console.log("---ERROR---end---");
}
//公共方法
var utils = (function(mod) {

	/**
	 * 获取url中的数据
	 * @param {String} url
	 */
	mod.getDataFromUrl = function(url) {
		var data = {};
		var index = url.indexOf("&");
		if(index != -1) {
			var dataStr = url.substring(index + 6, url.length);
			console.log("getDataFromUrl dataStr " + dataStr);
			data = JSON.parse(decodeURIComponent(dataStr));
		}
		console.log("getDataFromUrl url " + url);
		console.log("getDataFromUrl data " + JSON.stringify(data));
		return data;
	}
	/**
	 * 用mui打开一个页面，通过url传递数据
	 * @param {String} url 路径
	 * @param {Object} data 数据对象
	 */
	mod.mOpenWithData = function(url, data) {
		data = data || {};
		var ids = url.split("/");
		var dataStr = JSON.stringify(data);
		console.log("mOpen " + url + ' ' + dataStr);
		mui.openWindow(url + "?v=" + Math.random() + "&data=" + encodeURIComponent(dataStr), ids[ids.length - 1]);
	}
	/**
	 * 用window打开一个页面，通过url传递数据
	 * @param {String} url 路径
	 * @param {Object} data 数据对象
	 */
	mod.wOpenWithData = function(url, data) {
		data = data || {};
		var ids = url.split("/");
		var dataStr = JSON.stringify(data);
		console.log("wOpen " + url + ' ' + dataStr);
		window.open(url + "?v=" + Math.random() + "&data=" + encodeURIComponent(dataStr), ids[ids.length - 1]);
	}

	/**
	 *初始化mui的scrollY
	 * @param {Object} muiString
	 */
	mod.muiInitScrollY = function(muiString) {
		muiString = muiString || ".mui-scroll-wrapper";
		mui(muiString).scroll({
			scrollY: true, //是否竖向滚动
			scrollX: false, //是否横向滚动
			indicators: true, //是否显示滚动条
			deceleration: 0.003, //阻尼系数,系数越小滑动越灵敏
			bounce: true, //是否启用回弹
		});
	}
	/**
	 * 判断数据是否是undefined，null,""
	 * @param {Object} data
	 */
	mod.checkData = function(data) {
		if(data !== undefined && data !== null && data !== "") {
			return true;
		} else {
			return false;
		}
	}
	/**
	 * 获取时间 YYYY-MM-DD HH-MM-SS(2017-9-8 11:56:40)
	 */
	mod.getCurentTime = function() {
		var myDate = new Date();
		var year = myDate.getFullYear(); //年
		var month = myDate.getMonth() + 1; //月
		var day = myDate.getDate(); //日
		var hh = myDate.getHours(); //时
		var mm = myDate.getMinutes(); //分
		var ss = myDate.getSeconds(); //秒
		var clock = year + "-";
		if(month < 10) {
			clock += "0";
		}
		clock += month + "-";
		if(day < 10) {
			clock += "0";
		}
		clock += day + " ";
		if(hh < 10) {
			clock += "0";
		}
		clock += hh + ":";
		if(mm < 10) {
			clock += '0';
		}
		clock += mm + ":";
		if(ss < 10) {
			clock += '0';
		}
		clock += ss;
		return clock;
	}
	/**
	 * 格式化时间
	 * @param {String} data 201712061523
	 * @return {String} data 2017-12-06 15:23
	 */
	mod.initTime = function(data) {
		var year = data.substring(0, data.length - 8);
		var month = data.substring(data.length - 8, data.length - 6);
		var day = data.substring(data.length - 6, data.length - 4);
		var hour = data.substring(data.length - 4, data.length - 2);
		var minute = data.substring(data.length - 2);
		return year + "-" + month + "-" + day + " " + hour + ":" + minute;
	}
	/**
	 * href 打开一个页面，并保存SessionStorage数据
	 * @param {Object} data
	 */
	mod.hrefSessionStorage = function(url, data) {
		var sKey = new Date().getTime() + "" + parseInt(Math.random() * 1000);
		storageutil.setSessionStorage(sKey, JSON.stringify(data));
		location.href = url + "?sKey=" + sKey;
	}
	/**
	 * 通过url中的sKey,获取SessionStorage数据
	 * @return data
	 */
	mod.getSessionStorageByUrlsKey = function() {
		var search = location.search.toString();
		var keyword = "?sKey=";
		var index = search.indexOf(keyword);
		if(index != -1) {
			var sKey = search.substring(index + keyword.length);
			var sValue = storageutil.getSessionStorage(sKey)
			if(sValue) {
				var obj = JSON.parse(sValue);
				return obj;
			} else {
				return null;
			}
		} else {
			return null;
		}
	}
	/**
	 * 获取url中的key值
	 * @param {Object} key
	 */
	mod.getValueFromUrlByKey = function(key) {
		var search = location.search.toString();
		var keyword = "?" + key + "=";
		var index = search.indexOf(keyword);
		if(index != -1) {
			var value = search.substring(index + keyword.length);
			return value;
		} else {
			return null;
		}
	}
	/**
	 * 当前时间+随机数
	 */
	mod.timeAndRandom = function() {
		var value = new Date().getTime() + "" + parseInt(Math.random() * 1000);
		return value;
	}
    /**
         * 在本地存永久数据
         * @param {Object} key
         * @param {Object} value
    */
	mod.setLocalStorage = function (key, value) {
	    localStorage.setItem(key, value);
	}
    /**
	 * 取永久数据
	 * @param {Object} key
	 */
	mod.getLocalStorage = function (key) {
	    return localStorage.getItem(key);
	}
    /**
	 * 删除单个永久数据
	 * @param {Object} key
	 */
	mod.removeLocalStorage = function (key) {
	    localStorage.removeItem(key);
	}
    /**
	 * 删除所有的永久数据
	 */
	mod.clearLocalStorage = function () {
	    localStorage.clear();
	}
    /**
	 * 在本地存临时数据
	 * @param {Object} key
	 * @param {Object} value
	 */
	mod.setSessionStorage = function (key, value) {
	    sessionStorage.setItem(key, value);
	}
    /**
	 * 取临时数据
	 * @param {Object} key
	 */
	mod.getSessionStorage = function (key) {
	    return sessionStorage.getItem(key);
	}
    /**
	 * 删除单个临时数据
	 * @param {Object} key
	 */
	mod.removeSessionStorage = function (key) {
	    sessionStorage.removeItem(key);
	}
    /**
	 * 删除所有的临时数据
	 */
	mod.clearSessionStorage = function () {
	    sessionStorage.clear();
	}
	return mod;
})(window.utils || {});