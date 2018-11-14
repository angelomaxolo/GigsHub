

//$(".js-cancel-gig").click(function (e) {
//    var link = $(e.target);
//    bootbox.dialog({
//        message: "Are you sure you want to delete this gig?",
//        title: "Confirm",
//        buttons: {
//            no: {
//                label: "no",
//                className: "btn-default",
//                callback: function () {
//                    bootbox.hideAll();
//                }
//            },
//            yes: {
//                label: "yes",
//                className: "btn-danger",
//                callback: function () {
//                    $.ajax({
//                            url: "/api/gigs/" + link.attr("data-gig-id"),
//                            method: "DELETE"
//                        })
//                        .done(function () {
//                            link.parents("li").fadeOut(function () {
//                                $(this).remove();
//                            });
//                        })
//                        .fail(function () {
//                            alert("Something failed");
//                        });
//                }
//            }
//        }

//    });

//});

