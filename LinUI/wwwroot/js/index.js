/**
 * 操作Icon 点击图标复制
 * @param el
 */
let toast = Toast.getSingle({
    fontSize:"14px"
});
function iconHandle(el){
    let item = el.getElementsByClassName("dib");
    $(".dib-box").on('click',".dib",function (e) {
        let codeName = $(".code-name",this).text();
        let name = codeName.replace(".icon-","");
        name = name.replace(/[\s]?/g,"");
        let content = `<Icon Name="${name}" Size="14"></Icon>`
        copy(content);
        toast.show("已复制到剪贴板");
    })
}
function getAllIconInfo(){
    return iconfont.glyphs;
}