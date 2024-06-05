function sortTable(n, isNumeric) {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementById("table2");
    switching = true;
    while (switching) {
        switching = false;
        rows = table.rows;
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false;
            x = rows[i].getElementsByTagName("TD")[n].querySelector('input').value;
            y = rows[i + 1].getElementsByTagName("TD")[n].querySelector('input').value;
            if (isNumeric) {
                x = x.replace(/\s/g, '').replace(',', '.');
                y = y.replace(/\s/g, '').replace(',', '.');
                if (parseFloat(x) > parseFloat(y)) {
                    shouldSwitch = true;
                    break;
                }
            } else if (x.toLowerCase() > y.toLowerCase()) {
                shouldSwitch = true;
                break;
            }

        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
        }
    }
}


document.addEventListener('DOMContentLoaded', function () {
    var selectAllButton = document.getElementById('selectAll');
    var deselectAllButton = document.getElementById('deselectAll');

    if (selectAllButton && deselectAllButton) {
        selectAllButton.addEventListener('click', function (e) {
            e.preventDefault();
            const cells = document.querySelectorAll('#table2 tbody tr td');
            cells.forEach(cell => {
                cell.classList.add('highlight');
            });
        });

        deselectAllButton.addEventListener('click', function (e) {
            e.preventDefault();
            const cells = document.querySelectorAll('#table2 tbody tr td');
            cells.forEach(cell => {
                cell.classList.remove('highlight');
            });
        });
    }

    $(document).ready(function () {
        $(document).on('keydown', function (e) {
            if (e.keyCode == 119) { // Код клавиши F8
                $('#confirmModalCopy').modal('show');
            }

            if (e.keyCode == 45) { // Код клавиши INSERT
                $('#insertRowsTable').modal('show');
            }

            if (e.keyCode == 115) { // Код клавиши F4
                $('#saveNewRowModal').modal('show');
            }
        });

        setTimeout(function () {
            $('#alertkeyupF8').fadeOut();
            $('#alertkeyupINSERT').fadeOut();
        }, 30000);
    });
});


$(document).ready(function () {
    $('#flexCheckPremia').change(function () {
        if (this.checked) {
            $('#table2 th.dpPrem, #table2 td.dpPrem').show();
        } else {
            $('#table2 th.dpPrem, #table2 td.dpPrem').hide();
        }
    });

    $("#filtr").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#tbody2 tr").each(function () {
            var row = $(this);
            var match = false;
            $(this).find('input').each(function () {
                if ($(this).val().toLowerCase().indexOf(value) > -1) {
                    match = true;
                }
            });
            row.toggle(match);
        });
    });

    $('#insertKodDetal').click(function () {
        $('#newRow').show();
        $('#insertRowsTable').modal('hide');

        $('.text-successAddRow').text('Новая запись успешно добавлена');

        $('#alertSuccessAdd').show();

        setTimeout(function () {
            $('#alertSuccessAdd').fadeOut();
        }, 3000);

        $('.text-warningInfoAdd').html('Для сохранения данных нажмите клавишу <strong>F4</strong>');

        setTimeout(function () {
            $('#alertWarningInfoAdd').show();

            setTimeout(function () {
                $('#alertWarningInfoAdd').fadeOut();
            }, 6000);
        }, 6000)
    });

    $('#btnSave').click(function () {
        $('#circle-plus').hide();
        $('#btnSave').text('').addClass('disabled').append('<span class="spinner-border spinner-border-sm" aria-hidden="true"></span>').append('<span role="status"> Подождите...</span>');
    });

    $('#saveNewRowModal').on('hidden.bs.modal', function () {
        $('#btnSave').removeClass('disabled').html('<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-circle-fill" id="circle-plus" viewBox="0 0 16 16">' +
            '<path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0M8.5 4.5a.5.5 0 0 0-1 0v3h-3a.5.5 0 0 0 0 1h3v3a.5.5 0 0 0 1 0v-3h3a.5.5 0 0 0 0-1h-3z" />' +
            '</svg> Добавить');
    });
});