function initEnv() {
	$("body").append(DWZ.frag["dwzFrag"]);

	if ( $.browser.msie && /6.0/.test(navigator.userAgent) ) {
		try {
			document.execCommand("BackgroundImageCache", false, true);
		}catch(e){}
	}
	//清理浏览器内存,只对IE起效
	if ($.browser.msie) {
		window.setInterval("CollectGarbage();", 10000);
	}

	$(window).resize(function(){
		initLayout();
		$(this).trigger(DWZ.eventType.resizeGrid);
	});

	var ajaxbg = $("#background,#progressBar");
	ajaxbg.hide();
	$(document).ajaxStart(function(){
		ajaxbg.show();
	}).ajaxStop(function(){
		ajaxbg.hide();
	});
	
	$("#leftside").jBar({minW:150, maxW:700});
	
	if ($.taskBar) $.taskBar.init();
	navTab.init();
	if ($.fn.switchEnv) $("#switchEnvBox").switchEnv();
	if ($.fn.navMenu) $("#navMenu").navMenu();
		
	setTimeout(function(){
		initLayout();
		initUI();
		
		// navTab styles
		var jTabsPH = $("div.tabsPageHeader");
		jTabsPH.find(".tabsLeft").hoverClass("tabsLeftHover");
		jTabsPH.find(".tabsRight").hoverClass("tabsRightHover");
		jTabsPH.find(".tabsMore").hoverClass("tabsMoreHover");
	
	}, 10);

}
function initLayout(){
	var iContentW = $(window).width() - (DWZ.ui.sbar ? $("#sidebar").width() + 10 : 34) - 5;
	var iContentH = $(window).height() - $("#header").height() - 34;

	$("#container").width(iContentW);
	$("#container .tabsPageContent").height(iContentH - 34).find("[layoutH]").layoutH();
	$("#sidebar, #sidebar_s .collapse, #splitBar, #splitBarProxy").height(iContentH - 5);
	$("#taskbar").css({top: iContentH + $("#header").height() + 5, width:$(window).width()});
}

function initUI(_box){
	var $p = $(_box || document);

	$("div.panel", $p).jPanel();

	//tables
	$("table.table", $p).jTable();
	
	// css tables
	$('table.list', $p).cssTable();

	//auto bind tabs
	$("div.tabs", $p).each(function(){
		var $this = $(this);
		var options = {};
		options.currentIndex = $this.attr("currentIndex") || 0;
		options.eventType = $this.attr("eventType") || "click";
		$this.tabs(options);
	});

	$("ul.tree", $p).jTree();
	$('div.accordion', $p).each(function(){
		var $this = $(this);
		$this.accordion({fillSpace:$this.attr("fillSpace"),alwaysOpen:true,active:0});
	});

	$(":button.checkboxCtrl, :checkbox.checkboxCtrl", $p).checkboxCtrl($p);
	
	if ($.fn.combox) $("select.combox",$p).combox();
	
	if ($.fn.xheditor) {
		$("textarea.editor", $p).each(function(){
			var $this = $(this);
			var op = { html5Upload: false, skin: 'vista', tools: $this.attr("tools") || 'full', onUpload: DWZ.jsonEval($this.attr("onUpload")) };
			var upAttrs = [
				["upLinkUrl","upLinkExt","zip,rar,txt"],
				["upImgUrl","upImgExt","jpg,jpeg,gif,png"],
				["upFlashUrl","upFlashExt","swf"],
				["upMediaUrl","upMediaExt","avi"]
			];
			
			$(upAttrs).each(function(i){
				var urlAttr = upAttrs[i][0];
				var extAttr = upAttrs[i][1];
				
				if ($this.attr(urlAttr)) {
					op[urlAttr] = $this.attr(urlAttr);
					op[extAttr] = $this.attr(extAttr) || upAttrs[i][2];
				}
			});
			
			$this.xheditor(op);
		});
	}
	
	if ($.fn.uploadify) {
	    if ($.fn.uploadify) {
	        $(":file[uploaderOption]", $p).each(function () {
	            var $this = $(this);
	            var options = {
	                fileObjName: $this.attr("name") || "file",
	                auto: true,
	                multi: true,
	                onUploadError: uploadifyError
	            };

	            var uploaderOption = DWZ.jsonEval($this.attr("uploaderOption"));
	            $.extend(options, uploaderOption);

	            DWZ.debug("uploaderOption: " + DWZ.obj2str(uploaderOption));

	            $this.uploadify(options);
	        });
	    }
	}
	
	// init styles
	$("input[type=text], input[type=password], textarea", $p).addClass("textInput").focusClass("focus");

	$("input[readonly], textarea[readonly]", $p).addClass("readonly");
	$("input[disabled=true], textarea[disabled=true]", $p).addClass("disabled");

	$("input[type=text]", $p).not("div.tabs input[type=text]", $p).filter("[alt]").inputAlert();

	//Grid ToolBar
	$("div.panelBar li, div.panelBar", $p).hoverClass("hover");

	//Button
	$("div.button", $p).hoverClass("buttonHover");
	$("div.buttonActive", $p).hoverClass("buttonActiveHover");
	
	//tabsPageHeader
	$("div.tabsHeader li, div.tabsPageHeader li, div.accordionHeader, div.accordion", $p).hoverClass("hover");

	//validate form
	$("form.required-validate", $p).each(function(){
		var $form = $(this);
		$form.validate({
			onsubmit: false,
			focusInvalid: false,
			focusCleanup: true,
			errorElement: "span",
			ignore:".ignore",
			invalidHandler: function(form, validator) {
				var errors = validator.numberOfInvalids();
				if (errors) {
					var message = DWZ.msg("validateFormError",[errors]);
					alertMsg.error(message);
				} 
			}
		});
		
		$form.find('input[customvalid]').each(function(){
			var $input = $(this);
			$input.rules("add", {
				customvalid: $input.attr("customvalid")
			})
		});
	});

if (WdatePicker) {
		$('input.date', $p).each(function(){
			var $this = $(this);
			var opts = {};
			if ($this.attr("dateFmt")) opts.pattern = $this.attr("dateFmt");
			if ($this.attr("minDate")) opts.minDate = $this.attr("minDate");
			if ($this.attr("maxDate")) opts.maxDate = $this.attr("maxDate");
			if ($this.attr("mmStep")) opts.mmStep = $this.attr("mmStep");
			if ($this.attr("ssStep")) opts.ssStep = $this.attr("ssStep");
			$this.datepicker(opts);
		});
	}

	// navTab
	$("a[target=navTab]", $p).each(function(){
		$(this).click(function(event){
			var $this = $(this);
			var title = $this.attr("title") || $this.text();
			var tabid = $this.attr("rel") || "_blank";
			var fresh = eval($this.attr("fresh") || "true");
			var external = eval($this.attr("external") || "false");
			var url = unescape($this.attr("href")).replaceTmById($(event.target).parents(".unitBox:first"));
			DWZ.debug(url);
			if (!url.isFinishedTm()) {
				alertMsg.error($this.attr("warn") || DWZ.msg("alertSelectMsg"));
				return false;
			}
			navTab.openTab(tabid, url,{title:title, fresh:fresh, external:external});

			event.preventDefault();
		});
	});
	
	//dialogs
	$("a[target=dialog]", $p).each(function(){
		$(this).click(function(event){
			var $this = $(this);
			var title = $this.attr("title") || $this.text();
			var rel = $this.attr("rel") || "_blank";
			var options = {};
			var w = $this.attr("width");
			var h = $this.attr("height");
			if (w) options.width = w;
			if (h) options.height = h;
			options.max = eval($this.attr("max") || "false");
			options.mask = eval($this.attr("mask") || "false");
			options.maxable = eval($this.attr("maxable") || "true");
			options.minable = eval($this.attr("minable") || "true");
			options.fresh = eval($this.attr("fresh") || "true");
			options.resizable = eval($this.attr("resizable") || "true");
			options.drawable = eval($this.attr("drawable") || "true");
			options.close = eval($this.attr("close") || "");
			options.param = $this.attr("param") || "";

			var url = unescape($this.attr("href")).replaceTmById($(event.target).parents(".unitBox:first"));
			DWZ.debug(url);
			if (!url.isFinishedTm()) {
				alertMsg.error($this.attr("warn") || DWZ.msg("alertSelectMsg"));
				return false;
			}
			$.pdialog.open(url, rel, title, options);
			
			return false;
		});
	});
	$("a[target=ajax]", $p).each(function(){
		$(this).click(function(event){
			var $this = $(this);
			var rel = $this.attr("rel");
			if (rel) {
				var $rel = $("#"+rel);
				$rel.loadUrl($this.attr("href"), {}, function(){
					$rel.find("[layoutH]").layoutH();
				});
			}

			event.preventDefault();
		});
	});
	
	$("div.pagination", $p).each(function(){
		var $this = $(this);
		$this.pagination({
			targetType:$this.attr("targetType"),
			rel:$this.attr("rel"),
			totalCount:$this.attr("totalCount"),
			numPerPage:$this.attr("numPerPage"),
			pageNumShown:$this.attr("pageNumShown"),
			currentPage:$this.attr("currentPage")
		});
	});

	if ($.fn.sortDrag) $("div.sortDrag", $p).sortDrag();

	// dwz.ajax.js
	if ($.fn.ajaxTodo) $("a[target=ajaxTodo]", $p).ajaxTodo();
	if ($.fn.dwzExport) $("a[target=dwzExport]", $p).dwzExport();

	if ($.fn.lookup) $("a[lookupGroup]", $p).lookup();
	if ($.fn.multLookup) $("[multLookup]:button", $p).multLookup();
	if ($.fn.suggest) $("input[suggestFields]", $p).suggest();
	if ($.fn.itemDetail) $("table.itemDetail", $p).itemDetail();
	if ($.fn.selectedTodo) $("a[target=selectedTodo]", $p).selectedTodo();
	if ($.fn.pagerForm) $("form[rel=pagerForm]", $p).pagerForm({parentBox:$p});

	// 这里放其他第三方jQuery插件...
	
	//zTree-3.5 tomCat
	/*if($.fn.zTree) { 
		$("ul.ztree",$p).each(function(){
			var setting=null;//zSetting
			var nodes= new Array();//用li来记录 zNodes参数
			$(this).find("li").each(function(i){
				var	nodeAttr="{";//拼接nodes键值对
				$(this.attributes).each(function(){
	  				nodeAttr+=this.name+":'"+this.value+"',";
	  			});	
	  			nodeAttr=nodeAttr.substr(0,nodeAttr.length-1)+"}";
	  			nodes[i]=eval("("+nodeAttr+")");		
				
			});
			var treeAttr="{";//拼接setting键值对
			$(this.attributes).each(function(){
				treeAttr+=this.name+":'"+this.value+"',";
			});
			treeAttr=treeAttr.substr(0,treeAttr.length-1)+"}";
			setting=eval("("+treeAttr+")");
			$.fn.zTree.init($(this),setting,nodes);
		});
	}*/


	//jqGrid-4.x tomCat
	if ($.fn.jqGrid) {
	    $("table.jqGrid").each(function () {
	        var $grid = $(this);
	       
	        //拼接colModel键值对
	        var colModelArr=[];
	        $grid.find("tr:first td").each(function(i){
	        	$td=$(this);
colModel[i]={
		align:$td.attr("align"),
		classes:$td.attr("classes"),
		datefmt:$td.attr("datefmt"),
		defval:$td.attr("defval"),
		editable:$td.attr("editable"),
		editoptions:$td.attr("editoptions"),
		editrules:$td.attr("editrules"),
		edittype:$td.attr("edittype"),
		fixed:$td.attr("fixed"),
		formoptions:$td.attr("formoptions"),
		formatoptions:$td.attr("formatoptions"),
		formatter:$td.attr("formatter"),
		hidedlg:$td.attr("hidedlg"),
		hidden:$td.attr("hidden"),
		index:$td.attr("index"),
		jsonmap:$td.attr("jsonmap"),
		key:$td.attr("key"),
		label:$td.attr("label"),
		name:$td.attr("name"),
		resizable:$td.attr("resizable"),
		search:$td.attr("search"),
		searchoptions:$td.attr("searchoptions"),
		sortable:$td.attr("sortable"),
		sorttype:$td.attr("sorttype"),
		stype:$td.attr("stype"),
		surl:$td.attr("surl"),
		width:$td.attr("width"),
		xmlmap:$td.attr("xmlmap"),
		unformat:$td.attr("unformat")
};
	        });
	        //拼接setting键值对
	    var gridAttr = {
	    	colModel:colModelArr,
	    		ajaxGridOptions:$grid.attr("ajaxGridOptions"),
	    		ajaxSelectOptions:$grid.attr("ajaxSelectOptions"),
	    		altclass:$grid.attr("altclass"),
	    		altRows:$grid.attr("altRows"),
	    		autoencode:$grid.attr("autoencode"),
	    		autowidth:$grid.attr("autowidth"),
	    		caption:$grid.attr("caption"),
	    		cellLayout:$grid.attr("cellLayout"),
	    		cellEdit:$grid.attr("cellEdit"),
	    		cellsubmit:$grid.attr("cellsubmit"),
	    		cellurl:$grid.attr("cellurl"),
	    		datastr:$grid.attr("datastr"),
	    		datatype:$grid.attr("datatype"),
	    		direction:$grid.attr("direction"),
	    		editurl:$grid.attr("editurl"),
	    		emptyrecords:$grid.attr("emptyrecords"),
	    		ExpandColClick:$grid.attr("ExpandColClick"),
	    		footerrow:$grid.attr("footerrow"),
	    		forceFit:$grid.attr("forceFit"),
	    		gridstate:$grid.attr("gridstate"),
	    		gridview:$grid.attr("gridview"),
	    		height:$grid.attr("height"),
	    		
	    		hiddengrid:$grid.attr("hiddengrid"),
	    			hidegrid:$grid.attr("hidegrid"),
	    			hoverrows:$grid.attr("hoverrows"),
	    			jsonReader:$grid.attr("jsonReader"),
	    			lastpage:$grid.attr("lastpage"),
	    			loadonce:$grid.attr("loadonce"),
	    			lastsort:$grid.attr("lastsort"),
	    			loadtext:$grid.attr("loadtext"),
	    			loadui:$grid.attr("loadui"),
	    			mtype:$grid.attr("mtype"),
	    			multikey:$grid.attr("multikey"),
	    			multiboxonly:$grid.attr("multiboxonly"),
	    			multiselect:$grid.attr("multiselect"),
	    			multiselectWidth:$grid.attr("multiselectWidth"),
	    			page:$grid.attr("page"),
	    			pager:$grid.attr("pager"),
	    			pgbuttons:$grid.attr("pgbuttons"),
	    			pginput:$grid.attr("pginput"),
	    			pgtext:$grid.attr("pgtext"),
	    			
	    			prmNames:$grid.attr("prmNames"),
	    				
	    				pginput:$grid.attr("pginput"),
	    					pginput:$grid.attr("pginput"),
	    					pginput:$grid.attr("pginput"),
	    					pginput:$grid.attr("pginput"),
	    					pginput:$grid.attr("pginput"),
	    					pginput:$grid.attr("pginput")
	    		
	    };
	        var defaults = {//默认参数
	            datatype: "json",
	            mtype: "post",
	            autowidth: true,
	            shrinkToFit: true,
	            multiselect: false,
	            sortorder: "desc",
	            loadComplete: function (xhr) {
	                $("#background,#progressBar").hide();
	            }
	        };
	        gridAttr = $.extend(defaults, gridAttr);
	        $grid.jqGrid(gridAttr);

	        /* pager 
            if(options.pager!=null && options.pager!="")
            {
	            var pagerAttr = "{";
	            $($(options.pager).get(0).attributes).each(function () {
	            pagerAttr += this.name + ":" + this.value + ",";
	            });
	            pagerAttr += "}";
	            $grid.navGrid(options.pager, eval("(" + pagerAttr + ")"));
	        }
            */
	    });
    }
}


