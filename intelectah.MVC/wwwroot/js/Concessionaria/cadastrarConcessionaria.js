﻿function FctCadastrarConcessionaria(event) {
    event.preventDefault();

    var form = $("#registerConcessionariaForm");

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

                setTimeout(function () {
                    FctListConcessionarias();
                }, 2000);
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

function FctListConcessionarias() {
    window.location.href = "/Concessionaria/Concessionarias";
}
