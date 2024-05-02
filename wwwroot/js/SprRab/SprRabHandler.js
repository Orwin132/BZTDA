$(document).ready(function () {
    $("#search-id").on("keyup", function () {
        var filter = $(this).val().toLowerCase();
        $("#sprRab tbody tr").each(function () {
            var tabNomer = $(this).find("td:eq(0)").text().toLowerCase();
            if (tabNomer.includes(filter)) {
                $(this).show();
            } else {
                $(this).hide();
            }
        });
    });

    $("#search-proffessia").on("keyup", function () {
        var filter = $(this).val().toLowerCase();
        $("#proff tbody tr").each(function () {
            var profName = $(this).find("td:eq(1)").text().toLowerCase();
            if (profName.includes(filter)) {
                $(this).show();
            } else {
                $(this).hide();
            }
        });
    });

    $("#search-surname").on("keyup", function () {
        var filter = $(this).val().toLowerCase();
        $("#sprRab tbody tr").each(function () {
            var fio = $(this).find("td:eq(3)").text().toLowerCase();
            if (fio.includes(filter)) {
                $(this).show();
            } else {
                $(this).hide();
            }
        });
    });

    $("#search-kod").on("keyup", function () {
        var filter = $(this).val().toLowerCase();
        $("#proff tbody tr").each(function () {
            var kodProf = $(this).find("td:eq(0)").text().toLowerCase();
            if (kodProf.includes(filter)) {
                $(this).show();
            } else {
                $(this).hide();
            }
        });
    });
});
