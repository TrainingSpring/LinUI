/**
 * @desc 组件列表
 * @type {{}}
 */
let SelectList = {};
/**
 * @desc 初始化Select
 * @param dotNetObj
 * @param selectId
 * @param title
 * @param data
 * @param connector
 * @param position
 */
function initSelect(dotNetObj,selectId,title,data,connector,position) {
    data = JSON.parse(data);
    SelectList[selectId] = new MobileSelect({
        trigger:"#"+selectId,
        title:title,
        wheels: data,
        position: position,
        connector:connector,
        callback: function (indexArr, sdata) {
            dotNetObj.invokeMethodAsync("Selected",indexArr,sdata);
        },
        transitionEnd:function (indexArr,sdata) {
            dotNetObj.invokeMethodAsync("SelectChange",indexArr,sdata);
        }
    })
}

/**
 * @desc 更新数据
 * @param selectId
 * @param data
 */
function updateSelect(selectId,title,data){
    let obj = SelectList[selectId];
    if (obj.title !== title)
        obj.setTitle(title);
    if (JSON.stringify(obj.wheels) === data)return;
    data = JSON.parse(data);
    if (data.childs)
        obj.updateWheels(data);
    else
        obj.updateWheel(0,data[0].data);
}