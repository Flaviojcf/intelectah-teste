function FctCadastrarVenda(event) {
    event.preventDefault();

    var form = $("#registerVendaForm");

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
                    FctListVendas();
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

function FctListVendas() {
    window.location.href = "/Venda/Vendas";
}



function FctFiltrarConcessionarias() {
    var input, filter, ul, li, a, i;
    input = document.getElementById('concessionariaInput');
    filter = input.value.toLowerCase();
    ul = document.getElementById("concessionariaDropdown");
    li = ul.getElementsByTagName('li');

    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("a")[0];
        if (a.innerHTML.toLowerCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }
}

function FctSelecionarConcessionaria(id, nome) {
    document.getElementById('concessionariaInput').value = nome;
    document.getElementById('ConcessionariaID').value = id;

}


$('#fabricanteDropdown').on('change', function () {
    var fabricanteId = $(this).val();
    var veiculoDropdown = $('#veiculoDropdown');

    if (fabricanteId) {
        $.ajax({
            url: '/Venda/GetVeiculosByFabricante',
            type: 'GET',
            data: { fabricanteId: fabricanteId },
            success: function (data) {
                veiculoDropdown.empty();
                veiculoDropdown.prop('disabled', false);

                veiculoDropdown.append($('<option>', {
                    value: '',
                    text: 'Selecione um veículo'
                }));

                $.each(data, function (index, veiculo) {
                    veiculoDropdown.append($('<option>', {
                        value: veiculo.id,
                        text: veiculo.modelo
                    }));
                });
            },
            error: function () {
                alert('Erro ao carregar os veículos. Tente novamente.');
            }
        });
    } else {
        veiculoDropdown.empty().append('<option>Selecione um fabricante primeiro</option>');
        veiculoDropdown.prop('disabled', true);
    }
});