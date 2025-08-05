// function open_waiting() {
//     $.blockUI({
//         message: `<div id="preloader"><div class="loading-area"><div class="circle"></div></div><div class="left-side"></div><div class="right-side"></div></div>`,
//         css: {
//             background: "transparent",
//             border: "none",
//             outline: "none",
//             left: "unset",
//             top: "0",
//         }
//     });
// }
//
//
// function close_waiting() {
//     $.unblockUI();
// }

function open_waiting() {
    $("#page_loader").fadeIn();
}

function close_waiting() {
    $("#page_loader").fadeOut();
}

function initializeSelect2Components() {
    $("[data-select2-url]").each(function () {
        let $dropdownParent = $(this).closest(".modal");
        if ($dropdownParent.length === 0) {
            $dropdownParent = null;
        }

        let url = $(this).attr("data-select2-url")
        let additionalData = $(this).attr("data-select2-additional-item") | undefined;
        let currentPage;
        $(this).select2({
            language: {
                searching: function () {
                    return "Searching...";
                },
                noResults: function () {
                    return "No results found";
                },
                loadingMore: function () {
                    return "Loading more...";
                }
            },
            ajax: {
                url: url,
                dataType: 'json',
                delay: 250,
                data: function (params) {
                    currentPage = params.page || 1;
                    if (additionalData !== undefined && additionalData !== null && additionalData !== "null") {
                        return {
                            additionalItem: additionalData,
                            parameter: params.term,
                            currentPage: params.page || 1
                        };
                    }
                    return {
                        parameter: params.term,
                        currentPage: params.page || 1
                    };
                },
                processResults: function (data) {

                    let totalPageCount = data.pageCount;
                    let results = data.entities;
                    if (currentPage === 1) {
                        results.unshift({id: "", text: 'Please select...'});
                    }

                    if (totalPageCount > currentPage) {
                        return {
                            results: results,
                            pagination: {
                                more: true
                            }
                        };
                    } else {
                        return {
                            results: results,
                        };
                    }
                },
                cache: true
            },
            dropdownParent: $dropdownParent// Ensures dropdown is within the modal
        });
        $(this).on('select2:opening', function (event) {
            additionalData = event.target.getAttribute("data-select2-additional-item");
        });
    });
}


function reinitializeTemplateComponents() {
    try {
        initializeCkEditor();
        initializeSelect2Components()
        $('[data-bs-toggle="tooltip"]').tooltip();
    } catch {
    }
}

function validateForm(event) {
    $(event.target).data('validator', null);
    $.validator.unobtrusive.parse(event.target);
}

function validateFormByElement(elem) {
    $(elem).removeData('validator');
    $(elem).removeData('unobtrusiveValidation');
    $.validator.unobtrusive.parse(elem);

    let isValid = $(elem).valid();

    // Prevent form submission if not valid
    if (!isValid) {
        event.preventDefault();
        event.stopPropagation();
    }
}


function getModalSelectorByType(type) {
    let selector;
    switch (type) {
        case "sm": {
            selector = "#modal-center-sm";
            break;
        }
        case "md": {
            selector = "#modal-center-md";
            break;
        }
        case "lg": {
            selector = "#modal-center-lg";
            break;
        }
        case "left": {
            selector = "#modal-left";
            break;
        }
        case "right": {
            selector = "#modal-right";
            break;
        }
    }
    return selector;
}


function getModalDataAttributeByType(type) {
    let attribute;
    switch (type) {
        case "sm": {
            attribute = "data-modal-sm-index";
            break;
        }
        case "md": {
            attribute = "data-modal-md-index";
            break;
        }
        case "lg": {
            attribute = "data-modal-lg-index";
            break;
        }
        case "left": {
            attribute = "data-modal-left-index";
            break;
        }
        case "right": {
            attribute = "data-modal-right-index";
            break;
        }
    }
    return attribute;
}


function setModalBodyIdByType(type, index) {
    let id;
    switch (type) {
        case "sm": {
            id = "modal-center-sm-body-";
            break;
        }
        case "md": {
            id = "modal-center-md-body-";
            break;
        }
        case "lg": {
            id = "modal-center-lg-body-";
            break;
        }
        case "left": {
            id = "modal-center-left-body-";
            break;
        }
        case "right": {
            id = "modal-center-right-body-";
            break;
        }
    }
    return `${id}${index}`;
}

function cloneModal(type, index) {
    let selector = getModalSelectorByType(type);
    index = Number(index);
    if (index === 1) {
        return;
    }
    let modalDataAttribute = getModalDataAttributeByType(type);
    if ($(`[${modalDataAttribute}="${index}"]`).length > 0) {
        return;
    }

    let clonedModal = $(selector).clone(false, false);

    clonedModal.attr("id", "");
    clonedModal.attr(modalDataAttribute, index);
    clonedModal.find(".modal-title").attr("id", "");
    clonedModal.find(".modal-body").attr("id", setModalBodyIdByType(type, index));
    $("body").append(clonedModal);
    let clonedModalZIndex = Number(clonedModal.css("z-index"));
    clonedModal.css("z-index", clonedModalZIndex + index);
    let modalInstance = new bootstrap.Modal(clonedModal[0]);

}

function openModal(type, title, index) {
    let selector = getModalSelectorByType(type);
    index = Number(index);

    if (index === 1) {
        $(selector).modal('show');
        $(selector).find(".modal-title").html(title);
        return;
    }
    let modal = $(`[${getModalDataAttributeByType(type)}="${index}"]`);
    modal.modal("show");
}


function opSmModal(title, index) {
    openModal("sm", title, index);
}

function opModal(title, index) {
    openModal("md", title, index);
}

function opLgModal(title, index) {
    openModal("lg", title, index);
}


function opLeftModal(title, index) {
    openModal("left", title, index);
}

function opRightModal(title, index) {
    openModal("right", title, index);
}

function closeModalByType(type, index) {
    let selector = getModalSelectorByType(type);
    if (index === 1) {
        let selectedModal = $(selector);
        selectedModal.modal('hide');
        selectedModal.find(".modal-title").html("");
        return;
    }
    let modal = $(`[${getModalDataAttributeByType(type)}="${index}"]`);
    modal.modal("hide");
    modal.removeClass("show");

}

function closeLgModal(index = 1) {
    closeModalByType("lg", index);
}

function closeModal(index = 1) {
    closeModalByType("md", index);
}


function closeSmModal(index = 1) {
    closeModalByType("sm", index);
}

function closeLeftModal(index = 1) {
    closeModalByType("left", index);
}


function closeRightModal(index = 1) {
    closeModalByType("right", index);
}

function onAjaxSuccess(data, status, xhr) {
    close_waiting();
    showToaster(xhr.responseText, 'success');
}

function ajaxSubmitSuccess(data, status, xhr) {
    showToaster(xhr.responseText, 'success');
}

function ajaxSubmitLoginSuccess(data, status, xhr) {
    alert(xhr.responseText);
}

async function onAjaxFailure(xhr, status, error) {
    close_waiting();
    const errorMessage = xhr.responseText;
    showToaster(xhr.responseText, 'error');
    // await showErrorToaster(errorMessage);
}


$(() => {
    $(document).on('click', '[data-bs-dismiss="modal"]', function () {
        $(this).closest('.modal').removeClass("show");
    });
    initializeSelect2Components();
})

function initializeTagifyInstances() {
    $("[tagify]").each(function () {
        let tagify = new Tagify(this, {
            delimiters: ",",
        });


        tagify.on('change', function () {
            formatTags(tagify);
        });


        $(this).closest('form').on('submit', function (e) {
            formatTags(tagify);
        });
    });
}

function onMainCategoryChange(elem, id) {
    let value = $(elem).val();
    $("#subCategory").attr("data-select2-additional-item", value).val("").trigger("change");
    $(`#${id}`).val("");
}

function onSubCategoryChange(elem, id) {
    let value = $(elem).val();
    $(`#${id}`).attr("data-select2-additional-item", value).val("").trigger("change");
}