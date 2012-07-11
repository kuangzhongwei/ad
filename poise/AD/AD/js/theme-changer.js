$(document).ready(function($) {

	$('#stylesw').styleSwitcher();
		
	$('.open-close-demo').click(function() {
		if ($(this).parent().css('left') == '-148px') {
			$(this).parent().animate({
				"left": "0"
			}, 300);
		} else {
			$(this).parent().animate({
				"left": "-148px"
			}, 300);
		}
	});
	
	var Color = '#777777';
	var bodyColor = '#f1f1f1';
	var darkColor = '#202020';
	var borderColor = $('textarea').css('border-top-color');
	var textColor = $('body').css('color');

	$('a.col1').click(function() {

		var bgColor = '#34739F';

		$('.project').mouseover(function() {
			$(this).find('div.proj-info').stop().animate({
				"background-color": bgColor,
				"color": "#fff"
			}, 'fast');
		}).mouseout(function() {
			$(this).find('div.proj-info').stop().animate({
				"background-color": "#fff",
				"color": Color
			}, 300);
		});
		$('a.more').mouseover(function() {
			$(this).stop().animate({
				"background-color": bgColor
			}, 'fast');
		}).mouseout(function() {
			$(this).stop().animate({
				"background-color": bodyColor
			});
		});
		$('.date-comments a.comments').hover(function() {
			$(this).stop().animate({
				"background-color": bgColor,
				"color": "#fff"
			}, 'fast');
		}, function() {
			$(this).stop().animate({
				"background-color": "#efefef",
				"color": darkColor
			});
		});
		$('.send-wrap div input').hover(function() {
			$(this).stop().animate({
				"background-color": bgColor,
				"border-color": bgColor,
				"color": '#fff'
			}, 'fast');
		}, function() {
			$(this).stop().animate({
				"background-color": '#fff',
				"border-color": borderColor,
				"color": textColor
			});
		});
		return false;
	});
	
	$('a.col2').click(function() {

		var bgColor = '#3E9F34';

		$('.project').mouseover(function() {
			$(this).find('div.proj-info').stop().animate({
				"background-color": bgColor,
				"color": "#fff"
			}, 'fast');
		}).mouseout(function() {
			$(this).find('div.proj-info').stop().animate({
				"background-color": "#fff",
				"color": Color
			}, 300);
		});
		$('a.more').mouseover(function() {
			$(this).stop().animate({
				"background-color": bgColor
			}, 'fast');
		}).mouseout(function() {
			$(this).stop().animate({
				"background-color": bodyColor
			});
		});
		$('.date-comments a.comments').hover(function() {
			$(this).stop().animate({
				"background-color": bgColor,
				"color": "#fff"
			}, 'fast');
		}, function() {
			$(this).stop().animate({
				"background-color": "#efefef",
				"color": darkColor
			});
		});
		$('.send-wrap div input').hover(function() {
			$(this).stop().animate({
				"background-color": bgColor,
				"border-color": bgColor,
				"color": '#fff'
			}, 'fast');
		}, function() {
			$(this).stop().animate({
				"background-color": '#fff',
				"border-color": borderColor,
				"color": textColor
			});
		});
		return false;
	});

	$('a.col3').click(function() {

		var bgColor = '#F38D43';

		$('.project').mouseover(function() {
			$(this).find('div.proj-info').stop().animate({
				"background-color": bgColor,
				"color": "#fff"
			}, 'fast');
		}).mouseout(function() {
			$(this).find('div.proj-info').stop().animate({
				"background-color": "#fff",
				"color": Color
			}, 300);
		});
		$('a.more').mouseover(function() {
			$(this).stop().animate({
				"background-color": bgColor
			}, 'fast');
		}).mouseout(function() {
			$(this).stop().animate({
				"background-color": bodyColor
			});
		});
		$('.date-comments a.comments').hover(function() {
			$(this).stop().animate({
				"background-color": bgColor,
				"color": "#fff"
			}, 'fast');
		}, function() {
			$(this).stop().animate({
				"background-color": "#efefef",
				"color": darkColor
			});
		});
		$('.send-wrap div input').hover(function() {
			$(this).stop().animate({
				"background-color": bgColor,
				"border-color": bgColor,
				"color": '#fff'
			}, 'fast');
		}, function() {
			$(this).stop().animate({
				"background-color": '#fff',
				"border-color": borderColor,
				"color": textColor
			});
		});
		return false;
	});

	$('a.col4').click(function() {

		var bgColor = '#E75151';

		$('.project').mouseover(function() {
			$(this).find('div.proj-info').stop().animate({
				"background-color": bgColor,
				"color": "#fff"
			}, 'fast');
		}).mouseout(function() {
			$(this).find('div.proj-info').stop().animate({
				"background-color": "#fff",
				"color": Color
			}, 300);
		});
		$('a.more').mouseover(function() {
			$(this).stop().animate({
				"background-color": bgColor
			}, 'fast');
		}).mouseout(function() {
			$(this).stop().animate({
				"background-color": bodyColor
			});
		});
		$('.date-comments a.comments').hover(function() {
			$(this).stop().animate({
				"background-color": bgColor,
				"color": "#fff"
			}, 'fast');
		}, function() {
			$(this).stop().animate({
				"background-color": "#efefef",
				"color": darkColor
			});
		});
		$('.send-wrap div input').hover(function() {
			$(this).stop().animate({
				"background-color": bgColor,
				"border-color": bgColor,
				"color": '#fff'
			}, 'fast');
		}, function() {
			$(this).stop().animate({
				"background-color": '#fff',
				"border-color": borderColor,
				"color": textColor
			});
		});
		return false;
	});

	$('a.col5').click(function() {

		var bgColor = '#aa60ba';

		$('.project').mouseover(function() {
			$(this).find('div.proj-info').stop().animate({
				"background-color": bgColor,
				"color": "#fff"
			}, 'fast');
		}).mouseout(function() {
			$(this).find('div.proj-info').stop().animate({
				"background-color": "#fff",
				"color": Color
			}, 300);
		});
		$('a.more').mouseover(function() {
			$(this).stop().animate({
				"background-color": bgColor
			}, 'fast');
		}).mouseout(function() {
			$(this).stop().animate({
				"background-color": bodyColor
			});
		});
		$('.date-comments a.comments').hover(function() {
			$(this).stop().animate({
				"background-color": bgColor,
				"color": "#fff"
			}, 'fast');
		}, function() {
			$(this).stop().animate({
				"background-color": "#efefef",
				"color": darkColor
			});
		});
		$('.send-wrap div input').hover(function() {
			$(this).stop().animate({
				"background-color": bgColor,
				"border-color": bgColor,
				"color": '#fff'
			}, 'fast');
		}, function() {
			$(this).stop().animate({
				"background-color": '#fff',
				"border-color": borderColor,
				"color": textColor
			});
		});
		return false;
	});

	$('a.col6').click(function() {

		var bgColor = '#27bea3';

		$('.project').mouseover(function() {
			$(this).find('div.proj-info').stop().animate({
				"background-color": bgColor,
				"color": "#fff"
			}, 'fast');
		}).mouseout(function() {
			$(this).find('div.proj-info').stop().animate({
				"background-color": "#fff",
				"color": Color
			}, 300);
		});
		$('a.more').mouseover(function() {
			$(this).stop().animate({
				"background-color": bgColor
			}, 'fast');
		}).mouseout(function() {
			$(this).stop().animate({
				"background-color": bodyColor
			});
		});
		$('.date-comments a.comments').hover(function() {
			$(this).stop().animate({
				"background-color": bgColor,
				"color": "#fff"
			}, 'fast');
		}, function() {
			$(this).stop().animate({
				"background-color": "#efefef",
				"color": darkColor
			});
		});
		$('.send-wrap div input').hover(function() {
			$(this).stop().animate({
				"background-color": bgColor,
				"border-color": bgColor,
				"color": '#fff'
			}, 'fast');
		}, function() {
			$(this).stop().animate({
				"background-color": '#fff',
				"border-color": borderColor,
				"color": textColor
			});
		});
		return false;
	});

	$('a.col7').click(function() {

		var bgColor = '#70ac2a';

		$('.project').mouseover(function() {
			$(this).find('div.proj-info').stop().animate({
				"background-color": bgColor,
				"color": "#fff"
			}, 'fast');
		}).mouseout(function() {
			$(this).find('div.proj-info').stop().animate({
				"background-color": "#fff",
				"color": Color
			}, 300);
		});
		$('a.more').mouseover(function() {
			$(this).stop().animate({
				"background-color": bgColor
			}, 'fast');
		}).mouseout(function() {
			$(this).stop().animate({
				"background-color": bodyColor
			});
		});
		$('.date-comments a.comments').hover(function() {
			$(this).stop().animate({
				"background-color": bgColor,
				"color": "#fff"
			}, 'fast');
		}, function() {
			$(this).stop().animate({
				"background-color": "#efefef",
				"color": darkColor
			});
		});
		$('.send-wrap div input').hover(function() {
			$(this).stop().animate({
				"background-color": bgColor,
				"border-color": bgColor,
				"color": '#fff'
			}, 'fast');
		}, function() {
			$(this).stop().animate({
				"background-color": '#fff',
				"border-color": borderColor,
				"color": textColor
			});
		});
		return false;
	});

	$('a.col8').click(function() {

		var bgColor = '#b58f24';

		$('.project').mouseover(function() {
			$(this).find('div.proj-info').stop().animate({
				"background-color": bgColor,
				"color": "#fff"
			}, 'fast');
		}).mouseout(function() {
			$(this).find('div.proj-info').stop().animate({
				"background-color": "#fff",
				"color": Color
			}, 300);
		});
		$('a.more').mouseover(function() {
			$(this).stop().animate({
				"background-color": bgColor
			}, 'fast');
		}).mouseout(function() {
			$(this).stop().animate({
				"background-color": bodyColor
			});
		});
		$('.date-comments a.comments').hover(function() {
			$(this).stop().animate({
				"background-color": bgColor,
				"color": "#fff"
			}, 'fast');
		}, function() {
			$(this).stop().animate({
				"background-color": "#efefef",
				"color": darkColor
			});
		});
		$('.send-wrap div input').hover(function() {
			$(this).stop().animate({
				"background-color": bgColor,
				"border-color": bgColor,
				"color": '#fff'
			}, 'fast');
		}, function() {
			$(this).stop().animate({
				"background-color": '#fff',
				"border-color": borderColor,
				"color": textColor
			});
		});
		return false;
	});

	$('#pat1').click(function() {
		$('body').css({background: 'url(images/patterns/chains.png) #f1f1f1 repeat'});
		return false;
	});
	$('#pat2').click(function() {
		$('body').css({background: 'url(images/patterns/china-tile.png) #f1f1f1 repeat'});
		return false;
	});
	$('#pat3').click(function() {
		$('body').css({background: 'url(images/patterns/cilinders.png) #f1f1f1 repeat'});
		return false;
	});
	$('#pat4').click(function() {
		$('body').css({background: 'url(images/patterns/egypt-waves.png) #f1f1f1 repeat'});
		return false;
	});
	$('#pat5').click(function() {
		$('body').css({background: 'url(images/patterns/garden.png) #f1f1f1 repeat'});
		return false;
	});
	$('#pat6').click(function() {
		$('body').css({background: 'url(images/patterns/meteors.png) #f1f1f1 repeat'});
		return false;
	});
	$('#pat7').click(function() {
		$('body').css({background: 'url(images/patterns/rain.png) #f1f1f1 repeat'});
		return false;
	});
	$('#pat8').click(function() {
		$('body').css({background: 'url(images/patterns/turtle.png) #f1f1f1 repeat'});
		return false;
	});
	$('#backgr-image').click(function() {
		$('body').css({background: 'url(images/patterns/dragon.png) #f1f1f1 no-repeat top right'});
		return false;
	});

});
