var GigsController = function (attendanceService) {
    var button;

    var done = function () {
        var text = button.text() === "Going" ? "Going?" : "Going";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    var fail = function () {
        alert("Something failed");
    };

    var toggleAttendance = function (e) {
        button = $(e.target);

        var gigId = button.attr("data-gig-id");



        //if the going button is default with question mark, create an attendances on the database
        if (button.hasClass("btn-default"))
            attendanceService.createAttendance(gigId, done, fail);

        //else the going button is info with no question mark, create an attendances on the database
        else
            attendanceService.deleteAttendance(gigId, done, fail);
    };

    var init = function(container) {
        //$(".js-toggle-attendance").click(toggleAttendance);
        $(container).on("click", ".js-toggle-attendance", toggleAttendance);
    };


    return {
        init: init
    };

}(AttendanceService);