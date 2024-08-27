$(function () {
    $('#veiculosTable').DataTable({
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.10.24/i18n/Portuguese.json'
        }
    });
});


function FctEditarVeiculo(id) {
    $.ajax({
        url: '/Veiculo/Editar',
        type: 'GET',
        data: { id: id },
        success: function (response) {
            if (response.success === false) {
                showToast(response.message, 'danger');
            } else {
                window.location.href = '/Veiculo/Editar?id=' + id;
            }
        },
        error: function (xhr, status, error) {
            showToast('Ocorreu um erro ao tentar editar o veiculo.', 'danger');
        }
    });
}


function FctDeletarVeiculo(id) {

    swal({
        title: "Tem certeza?",
        text: `Você está prestes a deletar o veiculo com ID: ${id}. Você não poderá reverter esta ação!`,
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
                url: '/Veiculo/Deletar',
                type: 'delete',
                data: { id: id },
                success: function (response) {
                    if (response.success === false) {
                        showToast(response.message, 'danger');

                    } else {
                        showToast(response.message, 'success');
                        setTimeout(function () {
                            window.location.href = '/Veiculo/Veiculos';
                        }, 500);
                    }
                },
                error: function (xhr, status, error) {
                    showToast('Ocorreu um erro ao tentar deletar o veiculo.', 'danger');
                }
            });
        } else {
            showToast('Ação de exclusão cancelada.', 'info');
        }
    });
}

