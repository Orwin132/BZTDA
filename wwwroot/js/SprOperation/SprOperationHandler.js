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
            if (isNumeric ? parseFloat(x) > parseFloat(y) : x.toLowerCase() > y.toLowerCase()) {
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
        });
    });
});


$(document).ready(function () {
    $('#flexCheckPremia').change(function () {
        if (this.checked) {
            $('#table2 thead tr, #table thead tr').append($('<th>').text('Доп.премия'));

            $('#table2 tbody tr, #table tbody tr').each(function () {
                $(this).append($('<td>').append($('<input type="text" class="focus-ring form-control" value="0">')));
            });
        } else {
            $('#table2 thead tr th:last-child, #table thead tr th:last-child, #table2 tbody tr td:last-child, #table tbody tr td:last-child').remove();
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

        $('.text-warningInfoAdd').html('Для сохранения данных нажмите клавишу <strong>F1</strong>');

        setTimeout(function () {
            $('#alertWarningInfoAdd').show();

            setTimeout(function () {
                $('#alertWarningInfoAdd').fadeOut();
            }, 6000);
        }, 6000)
    });
});