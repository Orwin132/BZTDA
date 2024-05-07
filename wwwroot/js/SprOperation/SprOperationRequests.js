$(document).ready(function () {
    var newRow = {};
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

        if (e.which === 112) {
            newData.kodDetal = $('#newKodDetal').val();
            newData.NameDetal = $('#newNameDetal').val();
            newData.ShifrDetal = $('#newShifrDetal').val();
            newData.TimeComput = $('#newTimeComput').val();
            newData.Rascenka = $('#newRascenka').val();

            $.ajax({
                url: '/Home/SaveNewRow',
                type: 'POST',
                data: newData,
                success: function (response) {
                    if (response.success) {
                        $('#newKodDetal').val('');
                        $('newNameDetal').val('');
                        $('#newShifrDetal').val('');
                        $('#newTimeComput').val('');
                        $('#newRascenka').val('');

                        $('#newRow').hide();

                        localStorage.setItem('showSuccessAlertInsertNewRow', 'true');
                        localStorage.setItem('showSuccessAlertInsertNewRowMessage', response.message);

                        location.reload();
                    } else {
                        localStorage.setItem('showErrorAlertInsertNewRow', 'true');

                        location.reload();
                    }
                },
                error: function (xhr, status, error) {
                    $('.text-errorInsertNewRow').text('Произошла ошибка при сохранении данных: ', xhr, status, error);
                    $('#alertErrorInsertNewRow').show();

                    setTimeout(function () {
                        $('#alertErrorInsertNewRow').fadeOut();
                    }, 3000);
                }
            })
        }
    });

    $('#btnDeleteRow').click(function () {
        var kodDetalDelete = $('#kodDetalDelete').val();

        if (kodDetalDelete.length === 0) {
            $('#confirmModalDelete').modal('hide');

            setTimeout(function () {
                $('#warningAlertDelete').show();

                setTimeout(function () {
                    $('#warningAlertDelete').fadeOut();
                }, 6000);
            }, 400);

            return;
        }

        $.ajax({
            url: '/Home/DeleteRow',
            method: 'POST',
            data: {
                kodDetalDelete: kodDetalDelete
            },
            success: function (result) {
                if (result.success) {
                    localStorage.setItem('showSuccessAlertDelete', 'true');
                    localStorage.setItem('alertMessageDelete', result.message);
                } else {
                    localStorage.setItem('showErrorAlertDelete', 'true');
                    localStorage.setItem('errorMessageDelete', result.message);
                }
                location.reload();
            },
            error: function () {
                localStorage.setItem('showErrorAlertDelete', 'true');
                localStorage.setItem('errorMessageDelete', 'Произошла ошибка при выполнении AJAX запроса');
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
                    localStorage.setItem('alertMessageCopy', result.message);
                } else {
                    localStorage.setItem('showErrorAlert', 'true');
                    localStorage.setItem('alertMessageCopy', result.message);
                }
                location.reload();
            },
            error: function () {
                localStorage.setItem('showErrorAlert', 'true');
                localStorage.setItem('alertMessageCopy', 'Произошла ошибка при выполнении AJAX запроса');
                location.reload();
            }
        });
    });

    $(document).ready(function () {
        if (localStorage.getItem('showSuccessAlert') === 'true') {
            $('#alertSuccessCopy').show();
            $('.text-successCopy').text(localStorage.getItem('alertMessageCopy'));

            setTimeout(function () {
                $('#alertSuccessCopy').fadeOut();
            }, 3000);

            localStorage.removeItem('showSuccessAlert');
            localStorage.removeItem('alertMessageCopy');
        }

        if (localStorage.getItem('showErrorAlert') === 'true') {
            $('#errorAlertCopy').show();
            $('.text-errorCopy').text(localStorage.getItem('alertMessageCopy'));

            setTimeout(function () {
                $('#errorAlertCopy').fadeOut();
            }, 10000);

            localStorage.removeItem('showErrorAlert');
            localStorage.removeItem('alertMessageCopy');
        }

        if (localStorage.getItem('showSuccessAlertDelete') === 'true') {
            $('#alertSuccessDelete').show();
            $('.text-successDeleteRow').text(localStorage.getItem('alertMessageDelete'));

            setTimeout(function () {
                $('#alertSuccessDelete').fadeOut();
            }, 3000);

            localStorage.removeItem('showSuccessAlertDelete');
            localStorage.removeItem('alertMessageDelete');
        }

        if (localStorage.getItem('showErrorAlertDelete') === 'true') {
            $('#alertErrorDelete').show();
            $('.text-errorDeleteRow').text(localStorage.getItem('errorMessageDelete'));

            setTimeout(function () {
                $('#alertErrorDelete').fadeOut();
            }, 3000);

            localStorage.removeItem('showErrorAlertDelete');
            localStorage.removeItem('errorMessageDelete');
        }

        if (localStorage.getItem('showSuccessAlertInsertNewRow') === 'true') {
            $('$alertSuccessInsertNewrow').show('');
            $('.text-successInsertNewRow').text(localStorage.getItem(''))
        }
    });
});

