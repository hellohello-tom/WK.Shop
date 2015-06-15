(function () {
    function dataWaiter() {
        this.node = document.querySelector('.data-waiter') || this.createDom();
    }

    dataWaiter.prototype.show = function () {
        var self = this;
        if (!self.node) {
            this.createDom();
        }
        self.node.classList.remove('hidden');
        setTimeout(function () {
            self.node.classList.add('waiting');
        });
    };
    dataWaiter.prototype.createDom = function () {
        var dataWaiter = document.createElement('div');
        dataWaiter.className = "data-waiter hidden";
        dataWaiter.innerHTML = '<i class="fa fa-spinner fa-spin"></i>';
        document.body.appendChild(dataWaiter);
        return dataWaiter;
    };
    dataWaiter.prototype.close = function () {
        if (this.node) {
            this.node.classList.remove('waiting');
            this.node.addEventListener('transitionend', h, false);
            this.node.addEventListener('webkitTransitionEnd', h, false);
        }
        function h(e) {
            var target = e.target;
            target.classList.add('hidden');
            target.removeEventListener('transitionend', h, false);
            target.removeEventListener('webkitTransitionEnd', h, false);
        }
    };
    dataWaiter.prototype.remove = function () {
        var self = this;
        if (self.node) {
            document.body.removeChild(self.node);
        }
        return this;
    };
    window.dataWaiter = new dataWaiter();
    return window.dataWaiter;
}());