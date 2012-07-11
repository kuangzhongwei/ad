(function($) {
	$.fn.equalHeight = function() {
		var group = this;
		$(window).bind('resize', function() {
			var tallest = 0;
			$(group).height('auto').each(function() {
				tallest = Math.max(tallest, $(this).height());
			}).height(tallest);
		}).trigger('resize');
	};
})(jQuery);

$(window).load(function() {
	$(".col-height .col1-4").equalHeight();
});
