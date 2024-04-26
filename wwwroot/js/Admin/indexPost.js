$(document).ready(function () {
    $('form[id^="approveForm"]').submit(function (event) {
        event.preventDefault();

        var form = $(this);
        var roleAssignmentId = form.find('button[type="submit"]').data('role-assignment-id');
        var roleName = form.find('button[type="submit"]').data('role');

        var formData = {
            roleAssignmentId: roleAssignmentId,
            roleName: roleName
        };

        $.ajax({
            type: 'POST',
            url: '/RoleAssignment/ApproveRole',
            data: formData,
            success: function (response) {
                if (response.success) {
                    location.reload();
                } else {
                    $('#alert-response').removeClass("alert-success").addClass("alert-danger").html('<i class="bi bi-exclamation-circle-fill"></i> ' + response.errorMessage).show();
                    var alert = $('#alert-response');

                    if (alert.length) {
                        setTimeout(function () {
                            alert.fadeOut('slow');
                        }, 3000);
                    }
                }
            },
            error: function (xhr, status, error) {
                $('#alert-response').removeClass("alert-success").addClass("alert-danger").html('<i class="bi bi-exclamation-circle-fill"></i> ' + error.errorMessage).show();
                console.error(error);
            }
        });
    });

    $('form[id^="rejectForm"]').submit(function (event) {
        event.preventDefault();

        var form = $(this);
        var roleAssignmentId = form.find('button[type="submit"]').data('role-assignment-id');

        var formData = {
            roleAssignmentId: roleAssignmentId
        };

        $.ajax({
            type: 'POST',
            url: '/RoleAssignment/RejectRole',
            data: formData,
            success: function () {
                location.reload();
            },
            error: function (xhr, status, error) {
                $('#alert-response').removeClass("alert-success").addClass("alert-danger").html('<i class="bi bi-exclamation-circle-fill"></i> ' + error.errorMessage).show();
                console.error(error);
            }
        });
    });
});
