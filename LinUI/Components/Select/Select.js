function initSelect(dotNetObj,selectId,title,data,connector,position) {
    console.log("初始化重复")
    new MobileSelect({
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