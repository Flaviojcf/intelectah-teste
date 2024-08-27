$(function () {
    $('#clientesTable').DataTable({
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.10.24/i18n/Portuguese.json'
        }
    });
});


function FctEditarCliente(id) {
    $.ajax({
        url: '/Cliente/Editar',
        type: 'GET',
        data: { id: id },
        success: function (response) {
            if (response.success === false) {
                showToast(response.message, 'danger');
            } else {
                window.location.href = '/Cliente/Editar?id=' + id;
            }
        },
        error: function (xhr, status, error) {
            showToast('Ocorreu um erro ao tentar editar o cliente.', 'danger');
        }
    });
}


function FctDeletarCliente(id) {

    swal({
        title: "Tem certeza?",
        text: `Você está prestes a deletar o cliente com ID: ${id}. Você não poderá reverter esta ação!`,
        icon: "warning",
        buttons: {
            cancel: {
                text: "Cancelar",
                value: null,
                visible: true,
                className: "",
                closeModal: true,
            },
            confirm: {
                text: "Deletar",
                value: true,
                visible: true,
                className: "btn-danger",
                closeModal: true
            }
        },
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: '/Cliente/Deletar',
                type: 'delete',
                data: { id: id },
                success: function (response) {
                    if (response.success === false) {
                        showToast(response.message, 'danger');

                    } else {
                        showToast(response.message, 'success');
                        setTimeout(function () {
                            window.location.href = '/Cliente/Clientes';
                        }, 500);
                    }
                },
                error: function (xhr, status, error) {
                    showToast('Ocorreu um erro ao tentar deletar o cliente.', 'danger');
                }
            });
        } else {
            showToast('Ação de exclusão cancelada.', 'info');
        }
    });
}

