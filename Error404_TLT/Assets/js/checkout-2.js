var parseQueryString = function (url) {
    var str = url;
    var objURL = {};
    str.replace(
        new RegExp("([^?=&]+)(=([^&]*))?", "g"),
        function ($0, $1, $2, $3) {

            if ($3 != undefined && $3 != null)
                objURL[$1] = decodeURIComponent($3);
            else
                objURL[$1] = $3;
        });
    return objURL;
};

$(document).ready(function () {
    setTimeout(function () {
        var stepCheckout = parseInt($('.step-sections').attr('step'));
        if (stepCheckout === 1) {
            var flagVal = 0;
            $('body').on('change', '#stored_addresses', function () {
                flagVal = $(this).val();
            });
            $('body').on('click', '.step-footer-continue-btn', function () {
                $(document).ajaxComplete(function (event, xhr, settings) {
                    if (settings.url.indexOf("form_next_step") > -1) {
                        $('#stored_addresses').val(flagVal);
                    }
                });
            })
            function check_required() {
                $('.field-required').each(function () {
                    var self = $(this).find('input');
                    var selfSelect = $(this).find('select');

                    if (self.val() !== '') {
                        self.parent().next().remove();
                        self.parents('.field-error').removeClass('field-error')
                    }

                    if (selfSelect !== null || selfSelect !== 0) {
                        selfSelect.parent().next().remove();
                        selfSelect.parents('.field-error').removeClass('field-error')
                    }
                });
            }
            $('body').on('change', '#stored_addresses', function () {
                check_required();
            });

        }
    }, 0)
})



var isInit = false;


function funcFormOnSubmit(e) {
    if (!isInit) {
        isInit = true;

        $.fn.tagName = function () {
            return this.prop("tagName").toLowerCase();
        };
    }

    if (typeof (e) == 'string') {
        var element = $(e);
        var formData = e;
    } else {
        var element = this;
        var formData = this;
        e.preventDefault();
    }

    $(element).find('button:submit').addClass('btn-loading');

    var formId = $(element).attr('id'), replaceElement = [], funcCallback;

    if (formId == undefined || formId == null || formId == '')
        return;
    if (formId == 'form_update_location_customer_shipping' || formId == 'form_update_location' || formId == 'form_update_shipping_method') {
        if ($('.order-checkout__loading--box').length > 0) {
            $('.order-checkout__loading--box').addClass('show');
        }
    }

    if (formId == 'form_next_step') {
        formData = '#section-payment-method';
        replaceElement.push('.step-sections');
    }
    else if (
        formId == 'form_redeem_add'
        || formId == 'form_redeem_remove'
        || formId == 'form_discount_add'
        || formId == 'form_discount_remove'
        || formId == 'section-shipping-rate'

    ) {

        replaceElement.push('#section-shipping-rate');
        replaceElement.push('.order-summary-toggle-inner .order-summary-toggle-total-recap');
        replaceElement.push('.order-summary-sections');
        replaceElement.push('.order-summary-section.order-summary-section-total-lines.total-line-table.total-line-table-footer');
        replaceElement.push('.order-summary-section.order-summary-section-total-lines.total-line-table.total-line.total-line-redeem');
        replaceElement.push('.order-summary-section.order-summary-section-redeem.redeem-login-section');

        replaceElement.push('#form_update_location');
        replaceElement.push('.inventory_location');
        replaceElement.push('.inventory_location_data');
        replaceElement.push('.order-summary-toggle-inner .order-summary-toggle-total-recap');
        replaceElement.push('.order-summary-sections');
    }


    if (!$(formData) || $(formData).length == 0) {
        window.location.reload();
        return false;
    }

    var inputurl = '';

    if (($(formData).tagName() != 'form' && $(formData).tagName() != 'input' && $(formData).tagName() != 'div')
        || ($(formData).tagName() == 'input' || $(formData).tagName() == 'div')) {

        formData += ' :input';
    }
    try {
        var listparameters = new URLSearchParams($(formData).serialize());
        var provincetmp = $('body').find('input[name$="selected_customer_shipping_province"]').val();
        if (provincetmp != '') listparameters.set('customer_shipping_province', provincetmp);

        var districttmp = $('body').find('input[name$="selected_customer_shipping_district"]').val();
        if (districttmp != '') listparameters.set('customer_shipping_district', districttmp);

        var wardtmp = $('body').find('input[name$="selected_customer_shipping_ward"]').val();
        if (wardtmp != '') listparameters.set('customer_shipping_ward', wardtmp);


        var address1tmp = $('body').find('input[name$="billing_address[address1]"]').val();
        if (address1tmp != '') listparameters.set('billing_address[address1]', address1tmp);

        listparameters.delete('selected_customer_shipping_province');
        listparameters.delete('selected_customer_shipping_district');
        listparameters.delete('selected_customer_shipping_ward');
        inputurl = listparameters.toString();

    } catch (err) {

        // Older Browser URLSearchParams not support
        var listparameters = parseQueryString($(formData).serialize());
        var provincetmp = $('body').find('input[name$="selected_customer_shipping_province"]').val();
        if (provincetmp != '' && listparameters.customer_shipping_province) listparameters.customer_shipping_province = provincetmp;

        var districttmp = $('body').find('input[name$="selected_customer_shipping_district"]').val();
        if (districttmp != '' && listparameters.customer_shipping_district) listparameters.customer_shipping_district = districttmp;

        var wardtmp = $('body').find('input[name$="selected_customer_shipping_ward"]').val();
        if (wardtmp != '' && listparameters.customer_shipping_ward) listparameters.customer_shipping_ward = wardtmp;

        var address1tmp = $('body').find('input[name$="billing_address[address1]"]').val();
        if (address1tmp != '' && listparameters.billing_address[address1]) listparameters.set('billing_address[address1]', address1tmp);

        delete listparameters.selected_customer_shipping_province;
        delete listparameters.selected_customer_shipping_district;
        delete listparameters.selected_customer_shipping_ward;

        var listObject = '';
        for (var key in listparameters) {
            listObject += '&' + key + '=' + encodeURIComponent(listparameters[key]);
        };
        inputurl = listObject.substring(1);

    }
    $.ajax({
        type: 'GET',
        url: window.location.origin + window.location.pathname + '?' + inputurl + encodeURI('&form_name=' + formId),
        success: function (html) {
            if ($(html).attr('id') == 'redirect-url') {
                window.location = $(html).val();
            } else {
                if (replaceElement.length > 0) {
                    for (var i = 0; i < replaceElement.length; i++) {
                        var tempElement = replaceElement[i];
                        var newElement = $(html).find(tempElement);

                        if (newElement.length > 0) {
                            if (tempElement == '.step-sections')
                                $(tempElement).attr('step', $(newElement).attr('step'));

                            var listTempElement = $(tempElement);

                            for (var j = 0; j < newElement.length; j++)
                                if (j < listTempElement.length)
                                    $(listTempElement[j]).html($(newElement[j]).html());
                        }
                    }
                }
                $('body').attr('src', $(html).attr('src'));
                $(element).find('button:submit').removeClass('btn-loading');

                if (($('body').find('.field-error') && $('body').find('.field-error').length > 0)
                    || ($('body').find('.has-error') && $('body').find('.has-error').length > 0)) {
                    $("html, body").animate({ scrollTop: 0 }, "slow");
                }
                if (formId == 'form_update_location_customer_shipping' || formId == 'form_update_location' || formId == 'form_update_shipping_method') {
                    if ($('.order-checkout__loading--box').length > 0) {
                        $('.order-checkout__loading--box').removeClass('show');
                    }
                }
                if (funcCallback)
                    funcCallback();
            }
        }
    }).fail(function () {
        $(element).find('button:submit').removeClass('btn-loading');
        if (formId == 'form_update_location_customer_shipping' || formId == 'form_update_location' || formId == 'form_update_shipping_method') {
            if ($('.order-checkout__loading--box').length > 0) {
                $('.order-checkout__loading--box').removeClass('show');
            }
        }
    });
    return false;
};
function funcSetEvent() {
    var effectControlFieldClass = '.field input, .field select, .field textarea';

    $('body')
        .on('focus', effectControlFieldClass, function () {
            funcFieldFocus($(this), true);
        })
        .on('blur', effectControlFieldClass, function () {
            funcFieldFocus($(this), false);
            funcFieldHasValue($(this), true);
        })
        .on('keyup input paste', effectControlFieldClass, function () {
            funcFieldHasValue($(this), false);
        })
        .on('submit', 'form', funcFormOnSubmit);



    $('body')
        .on('change', '#section-payment-method input:radio', function () {
            $('#section-payment-method .content-box-row.content-box-row-secondary').addClass('hidden');

            var id = $(this).attr('id');

            if (id) {
                var sub = $('body').find('.content-box-row.content-box-row-secondary[for=' + id + ']')

                if (sub && sub.length > 0) {
                    $(sub).removeClass('hidden');
                }
            }
        });



    $('body')
        .on('change', '#section-shipping-rate input:radio[name=shipping_rate_id]', function () {
            funcFormOnSubmit('#section-shipping-rate');
        })
        .on('change', '#section-payment-method  input:radio[name=payment_method_id]', function () {
            funcFormOnSubmit('#section-payment-method');
        });






};
function funcFieldFocus(fieldInputElement, isFocus) {
    if (fieldInputElement == undefined)
        return;

    var fieldElement = $(fieldInputElement).closest('.field');

    if (fieldElement == undefined)
        return;

    if (isFocus)
        $(fieldElement).addClass('field-active');
    else
        $(fieldElement).removeClass('field-active');
};
function funcFieldHasValue(fieldInputElement, isCheckRemove) {
    if (fieldInputElement == undefined)
        return;

    var fieldElement = $(fieldInputElement).closest('.field');

    if (fieldElement == undefined)
        return;

    if ($(fieldElement).find('.field-input-wrapper-select').length > 0) {
        var value = $(fieldInputElement).find(':selected').val();

        if (value == 'null')
            value = undefined;
    } else {
        var value = $(fieldInputElement).val();
    }

    if (!isCheckRemove) {
        if (value != $(fieldInputElement).attr('value'))
            $(fieldElement).removeClass('field-error');
    }

    var fieldInputBtnWrapperElement = $(fieldInputElement).closest('.field-input-btn-wrapper');

    if (value && value.trim() != '') {
        $(fieldElement).addClass('field-show-floating-label');
        $(fieldInputBtnWrapperElement).find('button:submit').removeClass('btn-disabled');
    }
    else if (isCheckRemove) {
        $(fieldElement).removeClass('field-show-floating-label');
        $(fieldInputBtnWrapperElement).find('button:submit').addClass('btn-disabled');
    }
    else {
        $(fieldInputBtnWrapperElement).find('button:submit').addClass('btn-disabled');
    }
};
function funcInit() {
    funcSetEvent();


}

function funcReplaceMembershipInfo(html, replaceElement) {
    var tempElement = $(replaceElement);
    var newElement = $(html).find(replaceElement);
    tempElement.html(newElement.html());
}

function funcMembershipInfo() {

}
$(document).ready(function () {

    funcInit();
    funcMembershipInfo();

});


