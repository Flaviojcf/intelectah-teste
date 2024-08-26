function FctLogin(event) {
    event.preventDefault();

    var form = $("#loginForm");

    if (!form.valid()) {
        return;
    }

    var submitButton = document.getElementById('loginButton');
    var spinner = document.getElementById('spinnerLogin');

    submitButton.disabled = true;
    spinner.classList.remove('d-none');

    $.ajax({
        type: "POST",
        url: form.attr("action"),
        data: form.serialize(),
        success: function (response) {
            if (response.success) {
                window.location.href = response.redirectUrl;
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
