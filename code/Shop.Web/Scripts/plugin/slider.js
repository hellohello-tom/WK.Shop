﻿(function (a) {
    a.fn.jdSlider = function (d) {
        var e, f;
        var i = a(this);
        var n = a(this).find(".img-wrapper");
        var o = a(this).find(".pro-wrapper");
        var g = 0;
        var l = false;
        var m = o.eq(0).width();
        var k = {
            initX: 0,
            initY: 0,
            startX: 0,
            endX: 0,
            sliderX: 0,
            _sliderDirection: 1,
            startY: 0,
            sliderFlag: false,
            finalX: 0
        };
        var j = a.extend({},
        {
            lineNum: 1,
            fitToScreen: false
        },
        d);
        var b = function () {
            if (!j.fitToScreen) {
                return;
            }
            e = i.width();
            var q = m;
            var p = Number(e) % q;
            f = parseInt(e / q);
            q = q + parseInt(p / f);
            n.css({
                width: o.length / j.lineNum * q
            });
            o.css({
                width: q
            });
        };
        var c = function (p) {
            if (p != undefined) { }
            if (a("#suite-slider").attr("opend")) {
                n.css("-webkit-transform", "translate3d(0,0,0)");
            }
            k.endX = 0;
            e = i.width();
            b();
            if (j.lineNum == 1) {
                var r = 0;
                for (var q = 0; q < o.length; q++) {
                    r = r + o.eq(q).width();
                }
                n.css({
                    width: r
                });
                g = r;
                a("#tempforsuite").on("click",
                function () {
                    c(111);
                });
            } else {
                g = Number(o.width()) * parseInt(o.length / j.lineNum);
            }
            if (g <= e) {
                l = true;
            }
            n.css({
                height: Number(o.height()) * j.lineNum
            });
            window.addEventListener("orientationchange",
            function () {
                c();
            });
        };
        var h = function (p) {
            n.css("-webkit-transform", "translate3d(" + (k.endX = p) + "px,0,0)");
        };
        i.on("touchstart",
        function (q) {
            if (l) {
                return;
            }
            k.sliderFlag = true;
            var p = q.touches[0];
            k.startX = p.pageX;
            k.initX = p.pageX;
            k.finalX = p.pageX;
            k.initY = p.pageY;
        });
        i.on("touchmove",
        function (q) {
            if (l) {
                return;
            }
            var p = q.touches[0];
            if (k.sliderFlag && Math.abs(p.pageY - k.initY) / Math.abs(p.pageX - k.initX) < 0.6) {
                k._sliderDirection = (p.pageX - k.startX < 0) ? "LEFT" : "RIGHT";
                k.finalX = p.pageX;
                q.preventDefault();
            } else {
                k.sliderFlag = false;
            }
        });
        i.on("touchend",
        function (r) {
            if (l) {
                return;
            }
            if (!k.sliderFlag) {
                return;
            }
            var q = r.touches[0];
            if (Math.abs(k.finalX - k.startX) < 50) {
                return;
            }
            if (k.endX > 0) {
                h(k.endX = 0);
            } else {
                if (k.endX < -(g - e)) {
                    h(k.endX = -(g - e));
                } else {
                    if (k._sliderDirection == "LEFT") {
                        var p = g - e;
                        k.sliderX = (g - e - Math.abs(k.sliderX) < e) ? -p : k.sliderX - e;
                        h(k.sliderX);
                    } else {
                        k.sliderX = (k.sliderX + e > 0) ? 0 : k.sliderX + e;
                        h(k.sliderX);
                    }
                }
            }
            k.sliderFlag = false;
        });
        return c();
    };
})(Zepto);