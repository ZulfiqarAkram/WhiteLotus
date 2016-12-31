var ReserveClassController = function (enrollService) {
    var toggleEnroll, done, fail;
    var btn;

    var init = function (container) {
        $(container).on("click", ".js-toggle-attendance", toggleEnroll);
    };

    toggleEnroll = function (e) {
        btn = $(e.target);
        var eventId = btn.attr("data-evento-id");

        if (btn.hasClass("btn-default"))
            attendanceService.createAttendance(eventId, done, fail);
        else
            attendanceService.deleteAttendance(eventId, done, fail);
    };
    done = function () {
        var text = (btn.text() == "Going" ? "Going ?" : "Going");
        btn.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };
    fail = function () {
        alert("something wrong!!!");
    };
    return {
        init: init
    }
}(EnrollService);


var EnrollService = function () {
    var createAttendance = function (eventId, done, fail) {
        $.post("/api/attendances", { eventId: eventId })
            .done(done)
            .fail(fail);
    };
    var deleteAttendance = function (eventId, done, fail) {
        $.ajax({
            url: "/api/attendances/" + eventId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    };

    return {
        createAttendance: createAttendance,
        deleteAttendance: deleteAttendance
    };

}();
