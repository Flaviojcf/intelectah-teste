$(function () {

});

function FctRegistrar() {
    $("#login").addClass("d-none");

    $.ajax({
        url: "/Home/Register",
        type: "GET",
        success: function (data) {
            $('#registerPartialView').html(data);
        }
    });
}
