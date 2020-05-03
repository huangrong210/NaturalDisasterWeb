$(function () {
    //判断是否有图片：有则显示，无则隐藏
    function isShow() {
        var img = document.getElementById('imgshow');
        var isCent = document.getElementById('imgCent');
        var isImg = img.src;
        var strFilter = ".jpeg|.gif|.jpg|.png|.bmp|.pic|";
        if (isImg.indexOf(".") > -1) {
            var p = isImg.lastIndexOf(".");
            var strPostfix = isImg.substring(p, isImg.length) + '|';
            strPostfix = strPostfix.toLowerCase();
            if (strFilter.indexOf(strPostfix) > -1) {
                img.style.display = "block";
            } else {
                return false;
            }
        } else {
            img.style.display = "none";
        }
    }
    isShow();
});