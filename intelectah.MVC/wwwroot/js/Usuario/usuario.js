﻿function FctCadastrar(event) {
    event.preventDefault();

    var form = $("#registerForm");

    if (!form.valid()) {
        return;
    }

    var submitButton = document.getElementById('submitButton');
    var spinner = document.getElementById('spinner');

    submitButton.disabled = true;
    spinner.classList.remove('d-none');

    $.ajax({
        type: "POST",
        url: form.attr("action"),
        data: form.serialize(),
        success: function (response) {
            if (response.success) {
                showToast(response.message, 'success');
                form[0].reset();
            } else {
                showToast(response.message, 'danger');
            }
        },
        error: function () {
            showToast('Ocorreu um erro inesperado. Tente novamente.', 'danger');
        },
        complete: function () {
            spinner.classList.add('d-none');
            submitButton.disabled = false;
        }
    });
}
