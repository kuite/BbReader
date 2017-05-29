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

//    var form = new FormData();
//
//    var settings = {
//        "async": true,
//        "crossDomain": true,
//        "url": "http://localhost:51740/api/Token/GetToken",
//        "method": "POST",
//        "headers": {
//            "username": "admin@wp.pl",
//            "password": "polska12",
//            "cache-control": "no-cache",
//            "postman-token": "26521a68-3ac7-ab00-276e-89b5d4b528b4"
//        },
//        "processData": false,
//        "contentType": false,
//        "mimeType": "multipart/form-data",
//        "data": form
//    }
//
//    $.ajax(settings).done(function (response) {
//        console.log(response);
//    });
}