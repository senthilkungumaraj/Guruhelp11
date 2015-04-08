/*
 * *************************
 * SITE JS (REQUIRES jQUERY)
 * *************************
*/
$(document).ready(function(){

	/*main nav hover*/
	(function(nav){
		var $nav = $(nav);
		var toggle;
		if ($nav.length) {
			toggle = function($li, action) {
				var intent = $li.data('intent');
				if (intent) {
					clearTimeout(intent);
				}
				if (action) {
					intent = setTimeout(function(){
						if (action === 'open') {
							$li.addClass('hover');
							width = ($li.outerWidth() + 36);
							$li.find('.sub-menu').width(width).stop(true, true).slideDown(200);
						} else {
							$li.removeClass('hover');
							$li.find('.sub-menu').stop(true, true).slideUp(200);
						}
					}, 100);
				}
				$li.data('intent', intent);
			};
			$nav.on('mouseenter mouseleave', '.haschildren', function(e){
				toggle($(this), (e.type === 'mouseenter' ? 'open' : 'close'));
			}).on('mouseenter', '.sub-menu', function(e){
				toggle($(this).closest('li'));
			});
		}
	})('.mainnav ul');
});
