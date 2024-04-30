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

    $('#copyBtn').click(function () {
        var selectedRow = $('input[name="selection"]:checked').closest('tr');

        if (selectedRow.length === 0) {
            $('#confirmModalCopy').modal('hide');

            setTimeout(function () {
                $('#alertCopy').show();

                setTimeout(function () {
                    $('#alertCopy').fadeOut();
                }, 6000);
            }, 400);

            return;
        }

        var detailId = selectedRow.find('td:eq(1) input').val();
        $.ajax({
            url: '/Home/CopyOperation',
            method: 'POST',
            data: { id: detailId },
            success: function (result) {
                if (result.success) {
                    localStorage.setItem('showSuccessAlert', 'true');
                } else {
                    localStorage.setItem('showErrorAlert', 'true');
                    localStorage.setItem('alertMessage', result.message);
                }
                location.reload();
            },
            error: function () {
                localStorage.setItem('showErrorAlert', 'true');
                localStorage.setItem('alertMessage', 'Произошла ошибка при выполнении AJAX запроса');
                location.reload();
            }
        });
    });

    $(document).ready(function () {
        if (localStorage.getItem('showSuccessAlert') === 'true') {
            $('#alertSuccessCopy').show();

            setTimeout(function () {
                $('#alertSuccessCopy').fadeOut();
            }, 3000);

            localStorage.removeItem('showSuccessAlert');
        }

        if (localStorage.getItem('showErrorAlert') === 'true') {
            $('#errorAlertCopy').show();
            $('.text-errorCopy').text(localStorage.getItem('alertMessage'));

            setTimeout(function () {
                $('#errorAlertCopy').fadeOut();
            }, 10000);

            localStorage.removeItem('showErrorAlert');
            localStorage.removeItem('alertMessage');
        }
    });
});

