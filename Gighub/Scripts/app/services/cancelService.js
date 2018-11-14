var CancelService = function() {

    var cancelAGig = function(gigId, done, fail) {
        $.ajax({
                url: "/api/gigs/" + gigId,
                method: "DELETE"
            })
            .done(done)
            .fail(fail);
    };

    return {
        cancelAGig: cancelAGig
    };

}();