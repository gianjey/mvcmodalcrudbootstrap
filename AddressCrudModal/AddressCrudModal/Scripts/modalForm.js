﻿
$(function () {
    $.ajaxSetup({ cache: false });

    $("a[data-modal]").on("click", function (e) {
        $('#myModalContent').load(this.href, function () {
            $('#myModal').modal({
                /*backdrop: 'static',*/
                keyboard: true
            }, 'show');
            bindForm(this);
        });
        return false;
    });
});

function bindForm(dialog) {
    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#myModal').modal('hide');
                    $('#replacetarget').load(result.url); //  Load data from the server and place the returned HTML into the matched element
                } else {
                    $('#myModalContent').html(result);
                    bindForm(dialog);
                }
            }
        });
        return false;
    });
}