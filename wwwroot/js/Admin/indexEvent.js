function updateRowCount() {
    $.ajax({
        type: "GET",
        url: "/RoleAssignment/GetRowCount",
        success: function (data) {
            // Обновляем отображаемое количество записей
            $("#rowCount").text(data);

            if (data === 0) {
                $('#rowCount').hide();
            } else {
                $('#rowCount').show();
            }
        },
        error: function (xhr, status, error) {
            console.log("Произошла ошибка при получении количества записей.");
        }
    });
}

$(document).ready(function () {
    updateRowCount();

    setInterval(updateRowCount, 5000);
});
