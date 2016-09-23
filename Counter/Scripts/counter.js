$(document).ready(function () {
    $('#btnIncrement').click(function (e) {
        $('#result').text('');
        $('#error').text('');

        $.get('/home/increment/', function (result) {
            $('#result').text(result.count);
            $('#error').text(result.error);
        });
    });

    $('#btnReset').click(function (e) {
        $('#result').text('');
        $('#error').text('');

        $.get('/home/reset/', function (result) {
            $('#result').text(result.count);
        });
    });
});
