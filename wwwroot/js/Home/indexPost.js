$(document).ready(function () {
    $('#roleRequestForm').submit(function (event) {
        event.preventDefault();

        var formData = {
            selectedRole: $('#selectRoles').val()
        };

        $.ajax({
            type: 'POST',
            url: '/RoleAssignment/SendRoleAssignment',
            data: formData,
            success: function (response) {
                location.reload();
            },
            error: function (xhr, status, error) {
                $(".alert").removeClass("alert-success").addClass("alert-danger").html('<i class="bi bi-exclamation-circle-fill"></i> Произошла ошибка при отправке заявки. Пожалуйста, попробуйте еще раз.').show();
                console.error(error);
            }
        });
    });
});
