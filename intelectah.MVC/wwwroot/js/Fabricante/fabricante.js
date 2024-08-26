$(function () {
    $('#fabricantesTable').DataTable({
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.10.24/i18n/Portuguese.json'
        }
    });
});


function FctEditarFabricante(id) {
    $.ajax({
        url: '/Fabricante/Editar',
        type: 'GET',
        data: { id: id },
        success: function (response) {
            if (response.success === false) {
                showToast(response.message, 'danger');
            } else {
                window.location.href = '/Fabricante/Editar?id=' + id;
            }
        },
        error: function (xhr, status, error) {
            showToast('Ocorreu um erro ao tentar editar o fabricante.', 'danger');
        }
    });
}


function FctDeletarFabricante(id) {

    swal({
        title: "Tem certeza?",
        text: `Você está prestes a deletar o fabricante com ID: ${id}. Você não poderá reverter esta ação!`,
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
                url: '/Fabricante/Deletar',
                type: 'delete',
                data: { id: id },
                success: function (response) {
                    if (response.success === false) {
                        showToast(response.message, 'danger');
                        button.html(originalButtonContent);
                        button.attr('disabled', false);
                        button.on('click', function () {
                            FctDeletarFabricante(id);
                        });
                    } else {
                        showToast(response.message, 'success');
                        setTimeout(function () {
                            window.location.href = '/Fabricante/Fabricantes';
                        }, 500);
                    }
                },
                error: function (xhr, status, error) {
                    showToast('Ocorreu um erro ao tentar deletar o fabricante.', 'danger');
                }
            });
        } else {
            showToast('Ação de exclusão cancelada.', 'info');
        }
    });
}

