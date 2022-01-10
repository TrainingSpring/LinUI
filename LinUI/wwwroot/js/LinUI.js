function copy(content){
    let input = document.createElement("input");
    // input.style.display = "none";
    document.body.appendChild(input);
    input.value = content;
    input.select();
    if (document.execCommand('copy')) {
        document.execCommand('copy');
    }
    document.body.removeChild(input);
}
// 返回上一个页面
function backPage() {
    history.back();
}
// 获取历史记录数据量
function getHistoryLength() {
    return history.length;
}
const names = {
    toast:"T-Toast"
}

/********************************************************************
 * 轻提醒对象
 * @param options
 * @returns {Toast}
 * @constructor
 ********************************************************************/
function Toast(options){
    this.options = {
        delay:3000,
        fontSize:"12px"
    }
    let toast = document.createElement("div");
    toast.id=names.toast;
    this.options = Object.assign({},this.options,options);
    toast.innerHTML = `<span class="t-toast-text" style="font-size: ${this.options.fontSize}"></span>`;
    document.body.append(toast)
    return this;
}
Toast.instance = null;
// 显示toast
Toast.prototype.show = function(title){
    let toast = document.getElementById(names.toast);
    toast.style.display = "block";
    toast.style.opacity = "1";
    toast.querySelector(".t-toast-text").innerHTML = title;
    setTimeout(function () {
        toast.style.opacity = "0";
    },this.options.delay)
    setTimeout(function () {
        toast.style.display = "none";
    },this.options.delay+200)
}
// 单例模式
Toast.getSingle = function(options){
    console.log(Toast.instance == null);
    if (Toast.instance == null)Toast.instance = new Toast(options);
    return Toast.instance;
}
// 初始化Toast
function initToast(options) {
    Toast.getSingle(options);
}
/****************************************************************
 * @description 加载插件
 * @param options
 * @returns {Loading}
 * @constructor
 ****************************************************************/
function Loading(options){
    this._options = {
        tip:"加载中...",
        icon:"icon-loading-1",
        iconSIze:18,
        bgColor:"rgba(255,255,255,0.8)",
        color:"#333",
        iconColor:"#999"
    };
    let box = document.querySelectorAll(".t-loading-box");
    if (box.length > 0)return;
    this._options = Object.assign({},this._options,options);
    this.doc = document.createElement("div");
    this.doc.style.backgroundColor = this._options.bgColor;
    this.doc.className = "t-loading-box";

    this.doc.innerHTML = `
            <div class="t-loading-body">
                <div class="t-loading-icon">
                    <span class="iconfont ${this._options.icon}" style="color:${this._options.iconColor};font-size: ${this._options.iconSIze}px"></span>
                </div>
                <div class="t-loading-tip" style="color: ${this._options.color};">
                    ${this._options.tip}
                </div>
            </div> 
        `;
    document.body.append(this.doc);
    return this;
}
Loading.instance = null;
// 显示
Loading.prototype.show = function(){
    console.log("showLoading")
    let doc = document.querySelector(".t-loading-box");
    doc.className = "t-loading-box t-loading-show";
}
// 隐藏
Loading.prototype.hide = function (){
    let doc = document.querySelector(".t-loading-box");
    doc.className = "t-loading-box";
}
// 修改文字
Loading.prototype.correctTip=function (str){
    this.doc.querySelector(".t-loading-top").innerText = str;
}
// 设置options
Loading.prototype._setOptions = function (options){
    document.body.querySelector(".t-loading.box").remove();
    Loading.instance = new Loading(options);
}
// 单例模式
Loading.getLoading = function (options){
    if (Loading.instance==null)
        Loading.instance = new Loading(options);
    else if (options){
        // 修改配置
        Loading.instance._setOptions(options);
    }
    return Loading.instance;
}


/**
 * @description 执行组件命令
 * @param objectName  对象名
 * @param command  命令
 * @param arg  参数
 */
function handleComponents(objectName , command,arg){
    let obj;
    switch (objectName){
        case "Toast":
            obj = Toast.getSingle();
            break;
        case "Loading":
            obj = Loading.getLoading();
            break;
    }
    console.log(obj, command);
    let func = obj[command];
    if (typeof func === "function")
        if (arg==null)func();
        else func(arg);
}