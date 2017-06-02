$(document).ready(function () {
    init();
});

var init = function () {
    localStorage.clear();
    $('#loginBtn').unbind('click').click(getToken);
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
            Email: $('#Email').val(),
            Password: $('#Password').val()
        },
        success: function (response) {
            console.log(response);
            localStorage.setItem('token', JSON.stringify(response));
        },
        error: function (xhr, status, error) {
            console.log(xhr);
        }
    });
}