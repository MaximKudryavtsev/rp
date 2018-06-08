$(document).ready(function () {
    var value = $("#value");
    $("#form").submit(function () {
        return false;
    });
    /*$.ajax({
        type: "POST",
        url: "http://127.0.0.1:5000/api/values",
        data: value.val(),
        success: function (data) {
            
        }
    });*/
});