$(document).ready(function () {
    var newRow = {};
    $(document).keyup(function (e) {
        if (e.which === 113) { // Код клавиши F2

            $.ajax({
                url: '/Home/RashRascenki',
                type: 'POST',
                success: function (response) {
                    if (response.success) {
                        localStorage.setItem('showAlertRash', 'true');
                        localStorage.setItem('showTextRash', response.message);

                        location.reload();
                    } else {
                        localStorage.setItem('showErrorAlertRash', 'true');
                        localStorage.setItem('showErrorTextRash', 'Произошла ошибка');

                        location.reload();
                    }
                },
                error: function (xhr, status, error) {
                    localStorage.setItem('showErrorAlertRash', 'true');
                    localStorage.setItem('shwoErrorTextRash', 'Произошла ошибка при выполнении AJAX-запроса: ', xhr, status, error);
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
            });
        }

        if (e.which === 36) {
            var selectedRow = $('input[name="selection"]:checked').closest('tr');

            var NomStr = selectedRow.find('input[type="hidden"]').val();
            var KodDetal = selectedRow.find('input[type="text"]').eq(0).val();
            var NameDetal = selectedRow.find('input[type="text"]').eq(1).val();
            var ShifrDetal = selectedRow.find('input[type="text"]').eq(2).val();
            var TimeComput = selectedRow.find('input[type="text"]').eq(3).val();
            var Rascenka = selectedRow.find('input[type="text"]').eq(4).val();

            localStorage.setItem('NomStr', NomStr);
            localStorage.setItem('KodDetal', KodDetal);
            localStorage.setItem('NameDetal', NameDetal);
            localStorage.setItem('ShifrDetal', ShifrDetal);
            localStorage.setItem('TimeComput', TimeComput);
            localStorage.setItem('Rascenka', Rascenka);

            $.ajax({
                url: '/Home/UpdateTable',
                type: 'POST',
                data: JSON.stringify({
                    'updatedSprOperList': [{
                        'NomStr': NomStr,
                        'KodDetal': KodDetal,
                        'Rascenka': Rascenka
                    }],
                    'updatedSprDetList': [{
                        'KodDetal': KodDetal,
                        'NameDetal': NameDetal,
                        'ShifrDetal': ShifrDetal
                    }]
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.success) {

                        localStorage.setItem('showAlertUpdateTabe', 'true');
                        localStorage.setItem('showAlertUpdateTableText', response.message);

                        location.reload();
                    } else {
                        localStorage.setItem('showErrorAlertUpdateTable', 'true');
                        localStorage.setItem('showErrorAlertUpdateTableText', response.message);

                        location.reload();
                    }
                },
                error: function () {
                    localStorage.setItem('showErrorAlertUpdateTable', 'true');
                    localStorage.setItem('showErrorAlertUpdateTableText', 'An error occurred while updating the table.');

                    location.reload();
                }
            });
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

    $('#btnAnalyze').click(function () {
        $.ajax({
            url: '/Home/Compare',
            method: 'GET',
            success: function (result) {
                if (result.success) {
                    localStorage.setItem('showSuccessAlertCompare', 'true');
                    localStorage.setItem('alertMessageCompare', result.message);
                    localStorage.setItem('dataCompare', JSON.stringify(result.data));
                } else {
                    localStorage.setItem('showErrorCompare', 'true');
                    localStorage.setItem('alertErrorMessageCompare', result.message);
                }

                location.reload();
            },
            error: function () {
                localStorage.setItem('showErrorCompare', 'true');
                localStorage.setItem('alertErrorMessageCompare', 'Произошла ошибка при выполнении запроса');

                location.reload();
            }
        });
    });

    $('#btn-close-alert1').click(function () {
        localStorage.setItem('hideAlert1', 'true');
    });

    $('#btn-close-alert2').click(function () {
        localStorage.setItem('hideAlert2', 'true');
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

        if (localStorage.getItem('showSuccessAlertCompare') === 'true') {
            $('#alertSuccessCompare').show();
            $('.text-successCompare').text(localStorage.getItem('alertMessageCompare'));

            setTimeout(function () {
                $('#alertSuccessCompare').fadeOut();
            }, 3000);

            localStorage.removeItem('showSuccessAlertCompare');
            localStorage.removeItem('alertMessageCompare');
        }

        if (localStorage.getItem('showErrorCompare') === 'true') {
            $('#alertErrorCompare').show();
            $('.text-errorCompare').text(localStorage.getItem('alertErrorMessageCompare'));

            setTimeout(function () {
                $('#alertErrorCompare').fadeOut();
            }, 3000);

            localStorage.removeItem('showErrorCompare');
            localStorage.removeItem('alertErrorMessageCompare');
        }

        if (localStorage.getItem('showAlertRash') === 'true') {
            $('#alertSuccessRash').show();
            $('.text-successRash').text(localStorage.getItem('showTextRash'));

            setTimeout(function () {
                $('#alertSuccessRash').fadeOut();
            }, 3000);

            localStorage.removeItem('showAlertRash');
            localStorage.removeItem('showTextRash');
        }

        if (localStorage.getItem('showErrorAlertRash') === 'true') {
            $('#alertErrorRash').show();
            $('.text-errorRash').text(localStorage.getItem('showErrorTextRash'));

            setTimeout(function () {
                $('#alertErrorRash').fadeOut();
            }, 3000);
        }

        if (localStorage.getItem('hideAlert1') === 'true') {
            $('#alertkeyupF8').hide();
        }

        if (localStorage.getItem('hideAlert2') === 'true') {
            $('#alertkeyupINSERT').hide();
        }

        if (localStorage.getItem('showAlertUpdateTable') === 'true') {
            $('#alertSuccessUpdateTable').show();
            $('.text-successUpdateTable').text(localStorage.getItem('showAlertUpdateTableText'));

            setTimeout(function () {
                $('#alertSuccessUpdateTable').fadeOut();
            }, 3000);

            localStorage.removeItem('showAlertUpdateTable');
            localStorage.removeItem('showAlertUpdateTableText');
        }

        if (localStorage.getItem('showErrorAlertUpdateTable') === 'true') {
            $('#alertErrorUpdateTable').show();
            $('.text-errorUpdateTable').text(localStorage.getItem('showErrorAlertUpdateTableText'));

            setTimeout(function () {
                $('#alertErrorUpdateTable').fadeOut();
            }, 3000);

            localStorage.removeItem('showErrorAlertUpdateTable');
            localStorage.removeItem('showErrorAlertUpdateTableText');
        }
    });
});

