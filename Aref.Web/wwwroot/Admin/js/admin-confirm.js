function ConfirmDelete(element, requestUrl, formId = null) {
    Swal.fire({
        title: "Delete",
        text: "Are you sure you want to delete?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Confirm",
        cancelButtonText: "Cancel",
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: requestUrl,
                type: "Get",
                beforeSend: function () {
                    open_waiting();
                },
                success: function (response) {
                    close_waiting();
                    let trElement = $(element).closest('tr');
                    let tdElement = $(element).closest("td");

                    trElement.addClass("removed");
                    tdElement.find('.removeAfterDelete')
                        .addClass("d-none");

                    $(element).html('<iconify-icon icon="solar:undo-left-round-outline" width="24" height="24"></iconify-icon>');
                    $(element).attr("data-bs-original-title", "Recover")
                    $(element).attr("onclick", `ConfirmRecover(this, '${requestUrl}')`)

                    $(element)
                        .removeClass("text-danger")
                        .addClass("text-info");

                    if (formId) {
                        ajaxSubstitutionFormId(formId);
                    }
                    showToaster(response, "success");
                },
                error: function (xhr) {
                    close_waiting();
                    showToaster(response.message, "error");
                }
            });
        }
    });
}

function ConfirmRecover(element, requestUrl, formId = null) {
    Swal.fire({
        title: "Recover",
        text: "Are you sure you want to recover?",
        showDenyButton: true,
        icon: 'warning',
        confirmButtonText: "Confirm",
        denyButtonText: "Cancel"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: requestUrl,
                type: "get",
                beforeSend: function () {
                    open_waiting();
                },
                success: function (response) {
                    close_waiting();

                    let trElement = $(element).closest('tr');
                    let tdElement = $(element).closest("td");

                    trElement.removeClass("removed");
                    tdElement.find('.removeAfterDelete')
                        .removeClass("d-none");

                    $(element).html('<iconify-icon icon="solar:trash-bin-trash-outline" width="22" height="22"></iconify-icon>');

                    $(element).attr("data-bs-original-title", "Delete")
                    $(element).attr("onclick", `ConfirmDelete(this, '${requestUrl}')`)

                    $(element)
                        .removeClass("text-info")
                        .addClass("text-danger");

                    if (formId) {
                        ajaxSubstitutionFormId(formId);
                    }
                    showToaster(response, "success");

                    close_waiting();
                },
                error: function (err) {
                    close_waiting();
                    showToaster(err.responseText, "error");
                }
            });
        }
    });
}

function ConfirmHardDelete(element, requestUrl, formId = null) {
    Swal.fire({
        title: "Delete",
        text: "Are you sure you want to delete?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Confirm",
        cancelButtonText: "Cancel",
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: requestUrl,
                type: "Get",
                beforeSend: function () {
                    open_waiting();
                },
                success: function (response) {
                    close_waiting();
                    let trElement = $(element).closest('tr');
                    let tdElement = $(element).closest("td");

                    trElement.addClass("removed");
                    tdElement.find('.removeAfterDelete')
                        .addClass("d-none");

                    $(element).remove();
                    if (formId) {
                        ajaxSubstitutionFormId(formId);
                    }
                    showToaster(response, "success");
                },
                error: function (xhr) {
                    close_waiting();
                    showToaster(response.message, "error");
                }
            });
        }
    });
}
