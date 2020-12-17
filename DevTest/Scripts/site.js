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
                favButton.toggleClass('on');
            }
        });
    });

    $('.membershipGroup').on('click', function () {
        var userId = $(this).attr("data-userId");
        var groupId = $(this).attr("data-groupId");
        var membershipIcon = $(this);
        $.ajax({
            url: "/Home/AddMembership",
            type: "POST",
            data: JSON.stringify({ userId, groupId }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            error: function (response) {
                alert(response.responseText);
            },
            success: function (response) {
                membershipIcon.toggleClass('active-button');
            }
        });
    });
}