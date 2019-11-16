/* ======================================
-----------------------------------------
	Real Estate | HTML Template
	Version: 1.0
 ---------------------------------------
 =======================================*/


'use strict';


$(window).on('load', function() {
	/*------------------
		Preloder
	--------------------*/
	$(".loader").fadeOut();
	$("#preloder").delay(400).fadeOut("slow");

});

(function($) {

	/*------------------
		Navigation
	--------------------*/
	$('.nav-switch').on('click', function(event) {
		$(this).toggleClass('active');
		$('.main-menu').slideToggle(400);
		event.preventDefault();
	});


	/*------------------
		Background Set
	--------------------*/
	$('.set-bg').each(function() {
		var bg = $(this).data('setbg');
		$(this).css('background-image', 'url(' + bg + ')');
	});


	/*------------------
		Hero Slider
	--------------------*/
		var bigimage = $(".hero-slider");
		var thumbs = $(".hero-nav-slider");
		var syncedSecondary = true;
	  
		bigimage.owlCarousel({
		  items: 1,
		  slideSpeed: 1500,
		  nav: true,
		  autoplay: true,
		  dots: false,
		  animateOut: 'fadeOut',
    	  animateIn: 'fadeIn',
		  loop: true,
		  responsiveRefreshRate: 200,
		  navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
		}).on("changed.owl.carousel", syncPosition);
	  
		thumbs.on("initialized.owl.carousel", function() {
		  thumbs.find(".owl-item").eq(0).addClass("current");
		}).owlCarousel({
		  dots: false,
		  nav: false,
		  smartSpeed: 200,
		  slideSpeed: 500,
		  responsiveRefreshRate: 100,
		  responsive : {
			0 : {
				items: 1,
				slideBy: 1
			},
			576 : {
				items: 1,
				slideBy: 1
			},
			768 : {
				items: 3,
				slideBy: 3
			},
		}
		}).on("changed.owl.carousel", syncPosition2);
	  
		function syncPosition(el) {
		  //if loop is set to false, then you have to uncomment the next line
		  //var current = el.item.index;
	  
		  //to disable loop, comment this block
		  var count = el.item.count - 1;
		  var current = Math.round(el.item.index - el.item.count / 2 - 0.5);
	  
		  if (current < 0) {
			current = count;
		  }
		  if (current > count) {
			current = 0;
		  }
		  //to this
		  thumbs.find(".owl-item").removeClass("current").eq(current).addClass("current");
		  var onscreen = thumbs.find(".owl-item.active").length - 1;
		  var start = thumbs .find(".owl-item.active").first() .index();
		  var end = thumbs.find(".owl-item.active").last() .index();
	  
		  if (current > end) {
			thumbs.data("owl.carousel").to(current, 100, true);
		  }
		  if (current < start) {
			thumbs.data("owl.carousel").to(current - onscreen, 100, true);
		  }
		}
	  
		function syncPosition2(el) {
		  if (syncedSecondary) {
			var number = el.item.index;
			bigimage.data("owl.carousel").to(number, 100, true);
		  }
		}
	  
		thumbs.on("click", ".owl-item", function(e) {
		  e.preventDefault();
		  var number = $(this).index();
		  bigimage.data("owl.carousel").to(number, 300, true);
		});


	/*------------------
		Design Slider
	--------------------*/
	$('.design-slider').owlCarousel({
		loop: true,
		nav: true,
		dots:false,
		items: 3,
		autoWidth:true,
		margin: 30,
		navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
	});
	

	/*------------------
		Features Slider
	--------------------*/
	$('.features-slider').owlCarousel({
		nav: true,
		dots:false,
		margin: 30,
		navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
		responsive : {
			0 : {
				items: 1,
			},
			576 : {
				items: 2,
				
			},
			768 : {
				items: 3,
			},
			991 : {
				items: 4,
			},
			1200 : {
				items: 5,
			}
		}
	});
	
	/*------------------
		About Slider
	--------------------*/
	$('.about-slider').owlCarousel({
		loop: true,
		nav: true,
		dots:false,
		autoplay: true,
		items: 1,
		navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
	});

	/*------------------------------
		Property Features Slider
	-------------------------------*/
	$('.property-features-slider').owlCarousel({
		nav: true,
		dots:false,
		items: 3,
		navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
		margin: 30,
		responsive : {
			0 : {
				items: 1,
				margin: 20,
			},
			576 : {
				items: 2,
				margin: 20,
			},
			768 : {
				items: 3,
				margin: 20,
			},
			991 : {
				items: 3,
				margin: 30,
			}
		}
	});


	/*------------------
		Video Popup
	--------------------*/
	$('.play-btn').magnificPopup({
		type: 'iframe'
	});

	/*------------------
		Image Popup
	--------------------*/
	$('.img-popup-gallery').magnificPopup({
		type: 'image',
		removalDelay: 300,
		mainClass: 'mfp-fade',
	});

})(jQuery);
