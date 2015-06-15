(function() {
    var script = document.createElement('script');
    script.type = 'text/javascript';
    script.src = '/Scripts/global/dataWaiter.js?t=' + new Date().getTime();
    document.getElementsByTagName('head')[0].appendChild(script);
}());