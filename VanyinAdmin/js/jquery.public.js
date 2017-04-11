$(function() {

	$(".userbox ").hover(function() {

		$(".userbox .usersetbox").stop().animate({
			"height": "121px"
		}, 300);

	}).mouseleave(function() {

		$(".userbox .usersetbox").stop().animate({
			"height": "0px"
		}, 300);

	})

	$(".leftlist .title").click(function() {
		var _this = $(this);
		if(_this.hasClass("active")) {
			_this.parents(".leftlist").find(".leftlink").stop().animate({ "height": "0" }, 300);
			_this.removeClass("active");
		} else {
			var parentbox = _this.parents(".leftlist").find(".leftlink");
			parentbox.stop().animate({ "height": parentbox.find("a").length * 30 + "px" }, 300);
			_this.parents(".leftlist").siblings().find(".leftlink").stop().animate({ "height": "0" }, 300);
			_this.parents(".leftlist").siblings().find(".title").removeClass("active");
			_this.addClass("active");
		}
	})
})

var SetLeftMenu = function(title, subtitle) {

	$(".leftlistbox .leftlist").each(function() {

		var _this = $(this);
		if(_this.find(".title span").text() == title) {
			_this.find(".title").addClass("active");
			_this.find(".leftlink").stop().animate({ "height": _this.find(".leftlink a").length * 30 + "px" });

			_this.find(".leftlink a").each(function() {
				var $this = $(this);
				if($this.find("span").text() == subtitle) {
					$this.addClass("active");
				}

			})

		}

	})

}