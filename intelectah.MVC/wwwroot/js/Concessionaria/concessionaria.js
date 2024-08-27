$(function () {
    $('#concessionariasTable').DataTable({
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.10.24/i18n/Portuguese.json'
        }
    });
});

function FctEditarConcessionaria(id) {
    $.ajax({
        url: '/Concessionaria/Editar',
        type: 'GET',
        data: { id: id },
        success: function (response) {
            if (response.success === false) {
                showToast(response.message, 'danger');
            } else {
                window.location.href = '/Concessionaria/Editar?id=' + id;
            }
        },
        error: function (xhr, status, error) {
            showToast('Ocorreu um erro ao tentar editar o concessionaria.', 'danger');
        }
    });
}


function FctDeletarConcessionaria(id) {
    swal({
        title: "Tem certeza?",
        text: `Você está prestes a deletar a concesionaria com ID: ${id}. Você não poderá reverter esta ação!`,
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
                url: '/Concessionaria/Deletar',
                type: 'delete',
                data: { id: id },
                success: function (response) {
                    if (response.success === false) {
                        showToast(response.message, 'danger');

                    } else {
                        showToast(response.message, 'success');
                        setTimeout(function () {
                            window.location.href = '/Concessionaria/Concessionarias';
                        }, 500);
                    }
                },
                error: function (xhr, status, error) {
                    showToast('Ocorreu um erro ao tentar deletar o concessionaria.', 'danger');
                }
            });
        } else {
            showToast('Ação de exclusão cancelada.', 'info');
        }
    });
}

