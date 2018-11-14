var CancelGigController = new function(cancelService) {
    var cancelLink;

    var done = function() {
        cancelLink.parents("li").fadeOut(function() {
            $(this).remove();
        });
    };

    var fail = function() {
        alert("Something failed");
    };

    var cancelClick = function(e) {
        cancelLink = $(e.target);

        var gigId = cancelLink.attr("data-gig-id");

        bootbox.dialog({
            message: "Are you sure you want to delete this gig?",
            title: "Confirm",
            buttons: {
                no: {
                    label: "no",
                    className: "btn-default",
                    callback: function() {
                        bootbox.hideAll();
                    }
                },
                yes: {
                    label: "yes",
                    className: "btn-danger",
                    callback: function() {
                        cancelService.cancelAGig(gigId, done, fail);
                    }
                }
            }

    });
    };

    var init = function() {
        $(".js-cancel-gig").click(cancelClick);
    };
    return {
        init: init
    };


}(CancelService);