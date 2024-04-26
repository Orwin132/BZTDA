$(document).ready(function () {
    $(document).keyup(function (e) {
        if (e.which === 113) { // Код клавиши F2
            var rashRascenkiUrl = $('#table').data('rash-rascenki-url');

            $.ajax({
                url: rashRascenkiUrl,
                type: 'POST',
                success: function (data) {
                    console.log('Method RashRascenki succesful.');
                },
                error: function (error) {
                    console.error('Method execution error RashRascenki: ', error);
                }
            });
        }
    });

    function copyCellData(cell) {
        var copyDetailsUrl = $('table2').data('copy-details-url');

        $.ajax({
            url: copyDetailsUrl,
            type: 'POST',

            success: function (data) {
                console.log('Method CopyOperation succesful.');
            },
            error: function (error) {
                console.error('Method execution error CopyOperation: ', error);
            }
        });

        console.log('Copy data for rows: ', cell);
    }

    $("#confirmDeleteButton").click(function () {
        $.ajax({
            url: '/HomeController/DeleteRecord',
            type: 'POST',
            data: {
                id: id
            },
            success: function (result) {
                console.log('Operation succesful');
            }
        });
    });

    $("#confirmDeleteButton2").click(function () {
        $.ajax({
            url: '/HomeController/DeleteRecord',
            type: 'POST',
            data: {
                id: id
            },
            success: function (result) {
                console.log('Operation succesful');
            }
        });
    });
});

