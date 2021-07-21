$(document).ready(function(){
    var pShowGrid = 12;
    var pShowList = 12;
    var pTotalGrid = $('.gategory-product .gategory-product-list').length;
    var pTotalList = $('.gategory-product .cat-product-list').length;
    var numPagesGrid = pTotalGrid/pShowGrid;
    var numPagesList = pTotalList/pShowList;
    var lastPageGrid = Math.ceil(numPagesGrid)-1;
    var lastPageList = Math.ceil(numPagesList) - 1;
    const ul_grid = $(".pagination-bar");
    ul_grid.append('<li><a href="#" class="prev"><i class="fa fa-chevron-left"></i></a></li>');
    //shop grid
    for(i = 0;i < numPagesGrid;i++) {
        var pageNum = i + 1;
        ul_grid.append('<li><a class="pagi-num" href="#" rel="'+i+'">'+pageNum+'</a></li> ');
    }
    //shop list
    for(i = 0;i < numPagesList;i++) {
        var pageNum = i + 1;
        ul_grid.append('<li><a class="pagi-num" href="#" rel="'+i+'">'+pageNum+'</a></li> ');
    }
    ul_grid.append('<li><a href="# class="next"><i class="fa fa-chevron-right"></i></a></li>');
    
    //shop grid
    $('.gategory-product .gategory-product-list').hide();
    $('.gategory-product .gategory-product-list').slice(0, pShowGrid).show();
    $('.pagination-bar .pagi-num:first').addClass('active');
    $('.prev').addClass('disabled');$('.next').addClass('active');
    $('.pagination-bar .pagi-num').on('click', function(){
        $('.pagination-bar .pagi-num').removeClass('active');
        $(this).addClass('active');
        var currPage = $(this).attr('rel');
        var startItem = currPage * pShowGrid;
        var endItem = startItem + pShowGrid;
        $('.gategory-product .gategory-product-list').css('opacity','0.0').hide().
        slice(startItem, endItem).css('display','table-row').animate({opacity:1}, 300);

        if($(this).attr('rel')==0){
            $('.pagination-bar .prev').addClass('disabled');
            $('.pagination-bar .prev').removeClass('active');
            $('.pagination-bar .next').addClass('active');
            $('.pagination-bar .next').removeClass('disabled');  
        }
        else if($(this).attr('rel')==lastPageGrid){
            $('.pagination-bar .prev').addClass('active');
            $('.pagination-bar .prev').removeClass('disabled');
            $('.pagination-bar .next').addClass('disabled');
            $('.pagination-bar .next').removeClass('active');
        }
        else{
            $('.pagination-bar .prev').addClass('active');
            $('.pagination-bar .prev').removeClass('disabled');
            $('.pagination-bar .next').addClass('active');    
            $('.pagination-bar .next').removeClass('disabled');    
        }
    });


    // shop list
    $('.gategory-product .cat-product-list').hide();
    $('.gategory-product .cat-product-list').slice(0, pShowList).show();
    $('.pagination-bar .pagi-num:first').addClass('active');
    $('.prev').addClass('disabled');$('.next').addClass('active');
    $('.pagination-bar .pagi-num').on('click', function(){
        $('.pagination-bar .pagi-num').removeClass('active');
        $(this).addClass('active');
        var currPage = $(this).attr('rel');
        var startItem = currPage * pShowGrid;
        var endItem = startItem + pShowGrid;
        $('.gategory-product .cat-product-list').css('opacity','0.0').hide().
        slice(startItem, endItem).css('display','table-row').animate({opacity:1}, 300);

        if($(this).attr('rel')==0){
            $('.pagination-bar .prev').addClass('disabled');
            $('.pagination-bar .prev').removeClass('active');
            $('.pagination-bar .next').addClass('active');
            $('.pagination-bar .next').removeClass('disabled');  
        }
        else if($(this).attr('rel')==lastPageList){
            $('.pagination-bar .prev').addClass('active');
            $('.pagination-bar .prev').removeClass('disabled');
            $('.pagination-bar .next').addClass('disabled');
            $('.pagination-bar .next').removeClass('active');
        }
        else{
            $('.pagination-bar .prev').addClass('active');
            $('.pagination-bar .prev').removeClass('disabled');
            $('.pagination-bar .next').addClass('active');    
            $('.pagination-bar .next').removeClass('disabled');    
        }
    });
    // Prev page click
    $('.pagination-bar .prev').on('click', function(){
        // Lấy phần tử đầu tiên có class = "pagi-num" 
        const first = $('.pagination-bar .pagi-num').siblings().first();
        // Nếu phần tử đó không có class='active' thì xử lý:
        if(!first.hasClass('active')){
            // Lấy phần tử có class .pagi-num và có class .active
            const active = $('.pagination-bar .pagi-num').siblings('.active');
            // Xóa class active 
            $('.pagination-bar .pagi-num').removeClass('active');
            // Lấy phần tử trước đó
            const prevItem = active.prev();
            prevItem.addClass('active');
            // Lấy giá trị 'rel' của prevItem
            
            var currPage = prevItem.attr('rel');
            var startItem = currPage * pShowGrid;
            var endItem = startItem + pShowGrid;
            $('.gategory-product .gategory-product-list').css('opacity','0.0').hide().
            slice(startItem, endItem).css('display','table-row').animate({opacity:1}, 300);

            if($(this).attr('rel')==0){
                $('.pagination-bar .prev').addClass('disabled');
                $('.pagination-bar .prev').removeClass('active');
                $('.pagination-bar .next').addClass('active');
                $('.pagination-bar .next').removeClass('disabled');  
            }
            else if($(this).attr('rel')==lastPageGrid){
                $('.pagination-bar .prev').addClass('active');
                $('.pagination-bar .prev').removeClass('disabled');
                $('.pagination-bar .next').addClass('disabled');
                $('.pagination-bar .next').removeClass('active');
            }
            else{
                $('.pagination-bar .prev').addClass('active');
                $('.pagination-bar .prev').removeClass('disabled');
                $('.pagination-bar .next').addClass('active');    
                $('.pagination-bar .next').removeClass('disabled');    
            }
        }
    });

    // Next page click
    $('.pagination-bar .next').on('click', function(){
        const last = $(this).siblings().last();
        if(!last.hasClass('active')){
            const active = $('.pagination-bar .pagi-num').siblings('pagi-num');
            $('.pagination-bar .pagi-num').removeClass('active');
            const nextItem = active.next();
            nextItem.addClass('active');
            
            var currPage = nextItem.attr('rel');
            var startItem = currPage * pShowGrid;
            var endItem = startItem + pShowGrid;
            $('.gategory-product .gategory-product-list').css('opacity','0.0').hide().
            slice(startItem, endItem).css('display','table-row').animate({opacity:1}, 300);

            if($(this).attr('rel')==0){
                $('.pagination-bar .prev').addClass('disabled');
                $('.pagination-bar .prev').removeClass('active');
                $('.pagination-bar .next').addClass('active');
                $('.pagination-bar .next').removeClass('disabled');  
            }
            else if($(this).attr('rel')==lastPageGrid){
                $('.pagination-bar .prev').addClass('active');
                $('.pagination-bar .prev').removeClass('disabled');
                $('.pagination-bar .next').addClass('disabled');
                $('.pagination-bar .next').removeClass('active');
            }
            else{
                $('.pagination-bar .prev').addClass('active');
                $('.pagination-bar .prev').removeClass('disabled');
                $('.pagination-bar .next').addClass('active');    
                $('.pagination-bar .next').removeClass('disabled');    
            }
        }
    });

    // /////////////////////////////////////////////////////////////////////////////
    
    
    
    
});


