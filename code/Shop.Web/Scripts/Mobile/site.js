//(function() {
//    var script = document.createElement('script');
//    script.type = 'text/javascript';
//    script.src = '/Scripts/global/dataWaiter.js?t=' + new Date().getTime();
//    document.getElementsByTagName('head')[0].appendChild(script);
//}());

var goTop = function () {
    
    
    var scotop;

    window.onscroll = function () {
        var win = window.document.body || window.document.documentElement, $win = $(win),
        winH = $win.height();

        if (document.body.scrollTop) {
            scotop = document.body.scrollTop;
        } else {
            scotop = document.documentElement.scrollTop;
        }
        var $goTop = $('.go-top-btn');
        if (scotop > winH / 4) {
            $goTop.show();
        } else {
            $goTop.hide();
        }

    };


}
window.onload = goTop();
var goTop = function () {
    window.scrollTo(0, 0);
    return false;
};