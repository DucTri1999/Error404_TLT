(function ($) {
    "use strict";

$(document).ready(function(){
/*---------------------------------------
	update cart 
----------------------------------------- */	
 
	var subtotal = 0;
	$(".shipping-cart-overly").each(function () {
		$(this).find(".shipping-item").each(function () {
			var price_P = parseFloat($(this).find(".giaSP").text().replace("$", ""));
			var quantity_P = parseFloat($(this).find(".so-luong").text());
			subtotal = subtotal + (price_P * quantity_P);
		});
	});
	$(".shipping-total").text("$" + (Math.round(subtotal * 100) / 100).toFixed(2));

	
/*---------------------------------------
	update number product in shop gird
----------------------------------------- */	

	function update_num_product_shopgird() {
		var num_product = 0;

		$(".all-gategory-product").each(function(){
			$(this).find(".row").each(function(){
				$(this).find(".gategory-product").each(function(){
					$(this).find(".gategory-product-list").each(function(){
						num_product +=1;
					});
				});
			});
		});
		$(".num_product_shopgird").text(num_product);
	}
	update_num_product_shopgird();

/*---------------------------------------
	update number product in shop list
----------------------------------------- */	

function update_num_product_shoplist() {
	var num_product = 0;

	$(".all-gategory-product").each(function(){
		$(this).find(".row").each(function(){
			$(this).find(".gategory-product").each(function(){
				$(this).find(".cat-product-list").each(function(){
					num_product +=1;
				});
			});
		});
	});
	$(".num_product_shoplist").text(num_product);
}
update_num_product_shoplist();


/*---------------------------------------
	update number product in cart page
----------------------------------------- */

	function update_num_product() {
		var num_product = 0;

		$(".cart-row-product").each(function(){
			$(this).find("tr").each(function(){
				num_product +=1;
			});
		});
		$(".num-products").text(num_product);
	}
	update_num_product();



/*---------------------------------------
	update price product in cart page
----------------------------------------- */

	var total_price = 0;
	$(".cart-row-product").each(function(){
		$(this).find("tr").each(function(){
			var priceProduct = parseFloat($(this).find(".cart-unit").children(".price").children(".price").text().replace("$", ""));
			var soluong = parseFloat($(this).find(".cart_quantity")
										.children(".cart-plus-minus-button").children(".cart-plus-minus").val());
			$(this).find(".cart-total").children(".price").text("$" + priceProduct);
			total_price = total_price + (priceProduct*soluong);
		});
	});
	var price_shipping = parseFloat($("#total_shipping").text().replace("$", ""));
	var voucher = parseFloat($("#voucher").text().replace("$", ""));
	$(".cart-total-price #total_product").text("$" + (Math.round(total_price * 100) / 100).toFixed(2));
	var total = total_price + price_shipping - voucher;
	$("#total-price").text("$" + (Math.round(total_price * 100) / 100).toFixed(2));



/*---------------------------------------
	price range ui slider js
----------------------------------------- */		
	$( "#price-range" ).slider({
		range: true,
		min: 1,
		max: 100,
		values: [ 10, 90 ],
		slide: function( event, ui ) {
			$( "#slidevalue" ).val( "$" + ui.values[ 0 ] + " - $" + ui.values[ 1 ] );
		}
	});
	$( "#slidevalue" ).val( "$" + $( "#price-range" ).slider( "values", 0 ) +
		" - $" + $( "#price-range" ).slider( "values", 1 ) );	

/*---------------------------------------
	mobile menu
----------------------------------------- */	
		$('.mobile-menu').meanmenu();	
		
/*---------------------------------------
	new  product, sale product carousel
----------------------------------------- */	
	$('.new-pro-carousel, .sale-carousel').owlCarousel({
		items : 2,
		itemsDesktop : [1199,2],
		itemsDesktopSmall : [991,1],
		itemsTablet: [767,2],
		itemsMobile : [480,1],
		autoPlay: false,
		navigation: true,
		pagination: false,
		navigationText:['<i class="fa fa-angle-left owl-prev-icon"></i>','<i class="fa fa-angle-right owl-next-icon"></i>']
	});	
		
/*---------------------------------------
	featured  product, bestseller, carousel
----------------------------------------- */	
	$('.feartured-carousel, .bestseller-carousel').owlCarousel({
		items : 5,
		itemsDesktop : [1199,4],
		itemsDesktopSmall : [991,3],
		itemsTablet: [767,2],
		itemsMobile : [480,1],
		autoPlay :  false,
		stopOnHover: false,		
		navigation: true,
		pagination: false,
		navigationText:['<i class="fa fa-angle-left owl-prev-icon"></i>','<i class="fa fa-angle-right owl-next-icon"></i>']	
	});	
		
/*---------------------------------------
	related-product  carousel
----------------------------------------- */	
	$('.related-product').owlCarousel({
		items : 4,
		itemsDesktop : [1199,4],
		itemsDesktopSmall : [991,3],
		itemsTablet: [767,2],
		itemsMobile : [480,1],
		autoPlay :  false,
		stopOnHover: false,		
		navigation: true,
		pagination: false,
		navigationText:['<i class="fa fa-angle-left owl-prev-icon"></i>','<i class="fa fa-angle-right owl-next-icon"></i>']	
	});	
		
/*---------------------------------------
	latest news carousel
----------------------------------------- */	
	$('.latest-news-carousel').owlCarousel({
		items : 4,
		itemsDesktop : [1199,3],
		itemsDesktopSmall : [991,3],
		itemsTablet: [767,2],
		itemsMobile : [480,1],
		autoPlay :  false,
		stopOnHover: false,		
		navigation: true,
		pagination: false,
		navigationText:['<i class="fa fa-angle-left owl-prev-icon"></i>','<i class="fa fa-angle-right owl-next-icon"></i>']
	});	
		
/*---------------------------------------
	client carousel
----------------------------------------- */	
	$('.client-carousel').owlCarousel({
		items : 6,
		itemsDesktop : [1199,4],
		itemsDesktopSmall : [991,3],
		itemsTablet: [767,2],
		itemsMobile : [480,1],
		autoPlay :  false,
		stopOnHover: false,		
		navigation: true,
		pagination: false,
		navigationText:['<i class="fa fa-angle-left owl-prev-icon"></i>','<i class="fa fa-angle-right owl-next-icon"></i>']
	});	
/*---------------------------------------
	home 2 left category menu
----------------------------------------- */	
	$('.category-heading').on( "click", function(){
		$('.category-menu-list').slideToggle(300);
	});	
		

/*---------------------------------------
	sidebar best seller carousel
----------------------------------------- */
	$('.sidebar-best-seller-carousel').owlCarousel({
		items : 1,
		itemsDesktop : [1199,1],
		itemsDesktopSmall : [991,1],
		itemsTablet: [767,1],
		itemsMobile : [480,1],
		autoPlay :  false,
		stopOnHover: false,		
		navigation: true,
		pagination: false,
		navigationText:['<i class="fa fa-angle-left owl-prev-icon"></i>','<i class="fa fa-angle-right owl-next-icon"></i>']
	});
		
/*---------------------------------------
	tab product carousel	
----------------------------------------- */	
	$('.tab-carousel-1, .tab-carousel-2, .tab-carousel-3').owlCarousel({
		items : 4,
		itemsDesktop : [1199,4],
		itemsDesktopSmall : [991,3],
		itemsTablet: [767,2],
		itemsMobile : [480,1],
		autoPlay :  false,
		stopOnHover: false,		
		navigation: true,
		pagination: false,
		navigationText:['<i class="fa fa-angle-left owl-prev-icon"></i>','<i class="fa fa-angle-right owl-next-icon"></i>']
	});
			
/*---------------------------------------
	mainSlider
----------------------------------------- */	
	$('#mainSlider').nivoSlider({
		controlNav: true,
		 directionNav: false,
		 pauseTime: 4000,
		nextText: '<div class="slider-bolut"></div>',
		prevText: '<div class="slider-bolut"></div>'
		
	});		

/*---------------------------------------
	single product product thumbnail
----------------------------------------- */	
	$('.bxslider').bxSlider({
	  minSlides: 3,
	  maxSlides: 3,
	  slideWidth: 88,
	  responsive:true,
	   nextText: '<i class="fa fa-angle-left"></i>',
	  prevText: '<i class="fa fa-angle-right"></i>'
	});	

/*---------------------------------------
	francy box lightbox
----------------------------------------- */	
	$(".fancybox").fancybox();	

/*-----------------------------------------
	cart plus minus button
--------------------------------------------*/	  

	$(".cart-plus-minus-button").append('<div class="dec qtybutton">-</div><div class="inc qtybutton">+</div>');
	$(".qtybutton").on("click", function() {
	var oldValue = $(this).parent().find("input").val();
	if ($(this).text() == "+") {
		var newVal = parseFloat(oldValue) + 1;
		changePrice();
	} else {
		// Don't allow decrementing below zero
		if (oldValue > 1) {
		var newVal = parseFloat(oldValue) - 1;
		} else {
		newVal = 1;
		}
		}
		$(this).parent().find("input").val(newVal);
		changePrice();
	});

	$(".cart_quantity_delete").click(function () {
		$(this).parents(".cart-delete").parents("tr").remove();
		changePrice();
		update_num_product();
	});


	function changePrice(){
		var total_price = 0;
		$(".cart-row-product").each(function(){
			$(this).find("tr").each(function(){
				var priceProduct = parseFloat($(this).find(".cart-unit").children(".price").children(".price").text().replace("$", ""));
				var soluong = parseFloat($(this).find(".cart_quantity")
											.children(".cart-plus-minus-button").children(".cart-plus-minus").val());
				$(this).find(".cart-total").children(".price").text("$" + (priceProduct*soluong).toFixed(2));
				total_price = total_price + (priceProduct*soluong);
			});
		});
		var price_shipping = parseFloat($("#total_shipping").text().replace("$", ""));
		var voucher = parseFloat($("#voucher").text().replace("$", ""));
		$(".cart-total-price #total_product").text("$" + (Math.round(total_price * 100) / 100).toFixed(2));
		var total = total_price + price_shipping - voucher;
		$("#total-price").text("$" + (Math.round(total * 100) / 100).toFixed(2));
	}


/*---------------------------------------
	xóa hàng trong giỏ hàng tạm
----------------------------------------- */

	$(".remove").click(function () {
		$(this).parents(".shipping-item").remove();
		changed();
	});

	function changed() {
		var subtotal = 0;
		var subproduct = 0;
		$(".shipping-cart-overly").each(function () {
			$(this).find(".shipping-item").each(function () {
				var price_P = parseFloat($(this).find(".giaSP").text().replace("$", ""));
				var quantity_P = parseFloat($(this).find(".so-luong").text());
				subtotal = subtotal + (price_P * quantity_P);
				subproduct +=1;
			});
		});
		$(".shipping-total").text("$" + (Math.round(subtotal * 100) / 100).toFixed(2));
		$(".ajax-cart-quantity").text(subproduct);
	}

/*---------------------------------------
	cart page
----------------------------------------- */



		
/*---------------------------------------
	scroll to top
----------------------------------------- */	
	$(window).scroll(function(){
		if ($(this).scrollTop() > 250) {
			$('.bstore-scrollertop').fadeIn();
		} else {
			$('.bstore-scrollertop').fadeOut();
		}
	});
	//Click event to scroll to top
	$('.bstore-scrollertop').on( "click", function(){
		$('html, body').animate({scrollTop : 0},800);
		return false;
	});	

/*---------------------------------------
	thêm hàng vào giỏ hàng tạm
----------------------------------------- 

	$(".single-product-add-cart .add-cart-text").on("click", function(){
		$(".shipping-cart-overly").append('<div class="shipping-item"><span class="remove"><i class="fa fa-remove" aria-hidden="true"></i></span><div class="shipping-item-image"><a href="#"><img src="img/shopping-image.jpg" alt="shopping image" /></a></div><div class="shipping-item-text"><span><p class="so-luong">2</p><a href="#" class="pro-cat">Watch</a></span><span class="pro-quality"><a href="#">S,Black</a></span><p class="giaSP">$22.95</p></div></div>');
	});
*/

	
/*---------------------------------------
	đăng nhập
----------------------------------------- */
	var modal = document.getElementById('login_form');
	var modal1 = document.getElementById('signup_form');
	var modal2 = document.getElementById('recover_password-form');

	// When the user clicks anywhere outside of the modal, close it
	window.onclick = function(event) {
		if (event.target == modal||event.target == modal1||event.target == modal2) {
			modal.style.display = "none";
			modal1.style.display = "none";
			modal2.style.display = "none";
		}
		
	}
	
		
}); 
	
})(jQuery);	



function quenmk(){
    var modal3 = document.getElementById('recover_password-form');
	var modal4 = document.getElementById('login_form');
    modal3.style.display="block";
	modal4.style.display="none";
}

function dangky(){
    var modal5 = document.getElementById('login_form');
	var modal6 = document.getElementById('signup_form');
    modal5.style.display="none";
	modal6.style.display="block";
}

function send_code(){
    var modal7 = document.getElementById('send_mail');
	var modal8 = document.getElementById('code');
    modal7.style.display="none";
	modal8.style.display="block";
}

function pass_new(){
    var modal9 = document.getElementById('code');
	var modal10 = document.getElementById('new_pass');
    modal9.style.display="none";
	modal10.style.display="block";
}