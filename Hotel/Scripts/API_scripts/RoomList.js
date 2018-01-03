

$(function () {
    $('#btnLoad').click(function () {

        $(this).attr("disabled", true);
       $.ajax({
            url: 'http://localhost:11608/api/Room',
            method: 'GET',
            success: function (roomlistdata) {
                roomlistdata.forEach(function (room) {
                    var row = ' <h3 style="text-align: center; text-transform: uppercase; color: #4CAF50;">' + room.type + '</h3>';
                    var col = ' <p style="  border: 2px solid green; border-radius: 12px; text-indent: 50px;text-align: justify;text-align: left; margin-left:100px;width:700px;">' + room.description + '</p>';
                    $('#type').append('<img src="' + room.imagePath + '" class="img-responsive thumbnail" style="width:700px;margin-left:100px;"/>', row + col);
                });         
                
            }
        });

       $('#btnLoad').css("display", "none");
     
    });
});

