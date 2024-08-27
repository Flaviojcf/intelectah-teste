function FctEditarCliente(event) {
    event.preventDefault();

    var form = $("#editClienteForm");

    if (!form.valid()) {
        return;
    }

    var submitButton = document.getElementById('submitButton');
    var spinner = document.getElementById('spinner');

    submitButton.disabled = true;
    spinner.classList.remove('d-none');

    $.ajax({
        type: "PUT",
        url: form.attr("action"),
        data: form.serialize(),
        success: function (response) {
            if (response.success) {
                showToast(response.message, 'success');

                setTimeout(function () {
                    FctListClientes();
                }, 1000);
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

function FctListClientes() {
    window.location.href = "/Cliente/Clientes";
}
