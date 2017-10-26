//--Functions to display a loading screen for all ajax calls  ajaxSend
$(function () {
    //$(document).ajaxStart(function (event, request, settings) {
    //    console.log("AJAX START");
    //    $('#site-overlay').addClass('site-overlay-active');
    //    $('#loadingDialog').addClass('progress-active');
    //    $('#loadingDialog').show();
    //});

    //$(document).ajaxComplete(function (event, request, settings) {
    //    console.log("AJAX COMPLETE");
    //    $('#site-overlay').removeClass('site-overlay-active');
    //    $('#loadingDialog').removeClass('progress-active');
    //    $('#loadingDialog').hide();
    //});

    //$(document).ajaxError(function (event, request, settings) {
    //    console.log("AJAX ERROR");
    //    $('#site-overlay').removeClass('site-overlay-active');
    //    $('#loadingDialog').removeClass('progress-active');
    //    $('#loadingDialog').hide();
    //});

    //$(document).ready(function () {
    //    console.log("doc ready");
    //    $('#site-overlay').removeClass('site-overlay-active');
    //    $('#loadingDialog').removeClass('progress-active');
    //    $('#loadingDialog').hide();
    //});

    myLoadingEventStart(function () {
        console.log("window start");
        $('#site-overlay').addClass('site-overlay-active');
        $('#loadingDialog').addClass('progress-active');
        $('#loadingDialog').show();
    });

    myLoadingEventStop(function () {
        console.log("window stop");
        $('#site-overlay').removeClass('site-overlay-active');
        $('#loadingDialog').removeClass('progress-active');
        $('#loadingDialog').hide();
    });
})

function myLoadingEventStart(func) {
    // assign any pre-defined functions on 'window.onload' to a variable
    var oldOnLoad = window.onloadstart;
    // if there is not any function hooked to it
    if (typeof window.onloadstart != 'function') {
        // you can hook your function with it
        window.onloadstart = func
    } else { // someone already hooked a function
        window.onloadstart = function () {
            // call the function hooked already
            oldOnLoad();
            func();
        }
    }
}

//onload will trigger once the document has completed loading
function myLoadingEventStop(func) {
    // assign any pre-defined functions on 'window.onload' to a variable
    var oldOnLoad = window.onload;
    // if there is not any function hooked to it
    if (typeof window.onload != 'function') {
        // you can hook your function with it
        window.onload = func
    } else { // someone already hooked a function
        window.onload = function () {
            // call the function hooked already
            oldOnLoad();
            func();
        }
    }
}
//-------------------------------------------------------------

//--Modal Dialog for all CRUD operations---
$(function () {
    $.ajaxSetup({ cache: false });

    $("a[data-modal]").on("click", function (e) {

        $(e.target).closest('.btn-group').children('.dropdown-toggle').dropdown('toggle');

        $('#myModalContent').load(this.href, function () {
            $('#myModal').modal({
                keyboard: true
            }, 'show');
            bindForm(this);
        });

        return false;
    });

    //$("a[loadclick]").on("click", function (e) {
    //    ajaxToExecute(this.href.replace('?Length=4', ''))
    //    return false;
    //});
});

//function ajaxToExecute(url) {
//    $.ajax({
//        cache: false,
//        type: "GET",
//        url: url,
//        success: function (result) {
//            $('#bodyDiv').html(result);
//        }
//    });

//    return false;
//}


function bindForm(dialog) {

    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#myModal').modal('hide');
                    location.reload();
                } else {
                    $('#myModalContent').html(result);
                    bindForm();
                    toastr.error("Error", "Please fix the specified errors");
                }
            }
        });
        return false;
    });
}
//------------------------------------------