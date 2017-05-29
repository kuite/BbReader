$(document).ready(function () {
    init();
});

var init = function () {
    $('#loginBtn').click(getToken);
}

var getToken = function() {
    $.ajax({
        url: "http://localhost:51740/api/Token/GetToken",
        type: "POST",
        async: true,
        headers: {
            contentType: "application/json"
        },
        data: {
            Email: "admin@wp.pl",
            Password: "polska12"
        },
        success: function (response) {
            console.log(response);
        },
        error: function (xhr, status, error) {
            console.log(xhr);
        }
    });
}