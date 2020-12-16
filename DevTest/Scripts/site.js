$(document).ready(function () {
    bindEvents();
});

function bindEvents() {
    $('.isfavourite').on('click', function () {
        var userId = $(this).attr("data-userId");
        var favButton = $(this);
        $.ajax({
            url: "/Home/Bookmark",
            type: "POST",
            data: JSON.stringify({ userId }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            error: function (response) {
                alert(response.responseText);
            },
            success: function (response) {
                favButton.parent().parent().css("background-color", "#FAFAFA");
                favButton.toggleClass('on');
            }
        });
    });
}