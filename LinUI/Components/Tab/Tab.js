function tTabClick(el,index){
    let tabs = el.querySelectorAll(".t-tab-item");
    let box = el.getElementsByClassName("t-tab-box")[0];
    let w = el.clientWidth;
    let box_w = box.scrollWidth;
    if (box_w < w)return;
    else if (index === 0 || index === 1){
        box.style.transform = "translateX(0)";
        return;
    }
    let offsetLeft = 0;
    for (let i = 0;i<index-1;i++){
        if (box_w - offsetLeft >w){
            offsetLeft += tabs[i].clientWidth;
        }
    }
    box.style.transform = "translateX("+(-offsetLeft)+"px)";
}