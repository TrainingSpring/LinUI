/**
 * 操作Icon 点击图标复制
 * @param el
 */
let total = Total.getSingle({
    fontSize:"14px"
});
function iconHandle(el){
    let item = el.getElementsByClassName("dib");
    $(item).click(function (e) {
        let codeName = $(".code-name",this).text();
        let name = codeName.replace(".icon-","");
        name = name.replace(/[\s]?/g,"");
        let content = `<Icon Name="${name}" Size="14"></Icon>`
        copy(content);
        total.show("已复制到剪贴板");
    })
}
function getAllIconInfo(){
    return iconfont.glyphs;
}