$(function () {

    $('#btnSave').click(function () {
        $.ajax({
            url: 'http://localhost:11608/api/Contact',
            method: 'POST',
            data: {
                name: $('#Name').val(),
                email: $('#Email').val(),
                phone: $('#Phone').val(),
                message: $('#Message').val(),
            },
            success: function (dept) {
                $('#msg').html("Successfully Submitted ");
            }
        });
    });
});
