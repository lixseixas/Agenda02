// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#btnPesquisarContas").click(function () {

    BuscarAgendamentos();

});

function BuscarAgendamentos() {

    //limpar tabela
    $('#TabelaAgendamentos').empty();

    dataInicial = $("#DataInicial").val();
    dataFinal = $("#DataFinal").val();

    //Consumindo o serviço
    $.post("http://localhost:50747/Home/ListagemHorasDia/",
        {
            DataInicial: dataInicial,
            DataFinal: dataFinal,
        }, function (dados) {

            //preenchendo a lista de resultados
            for (var i = 0; i < dados.listaAgendamentosConsolidados.length; i++) {

                $('#TabelaAgendamentos').append('<tr><td>' + ConverterDataJson(dados.listaAgendamentosConsolidados[i].data) +
                    '</td><td>' + ConverterHoraSimples(dados.listaAgendamentosConsolidados[i].horas) +
                    '</td><td>' + dados.listaAgendamentosConsolidados[i].totalTarefas +
                    '</td><td>' + ConverterHoraSimples(dados.listaAgendamentosConsolidados[i].mediaHoras) +
                    '</td><td>' + dados.listaAgendamentosConsolidados[i].percentualTarefasConcluidas + "%" +
                    '</td></tr>');
            }


        });
}


function ConverterDataJson(data) {

    if (data == null || data.length == 0) {
        return " /  /  "
    } else {
        var ano = data.substring(0, 4);
        var mes = data.substring(5, 7);
        var dia = data.substring(8, 10);

        return dia + "/" + mes + "/" + ano;

    }
}

function ConverterHoraJson(data) {

    if (data == null || data.length == 0) {
        return " : :  "
    } else {
        var hora = data.substring(11, 13);
        var minuto = data.substring(14, 16);

        return hora + ":" + minuto;

    }
}

function ConverterHoraSimples(data) {

    if (data == null || data.length == 0) {
        return " :  "
    } else {
        var hora = data.substring(0, 2);
        var minuto = data.substring(3, 5);

        return hora + ":" + minuto;

    }
}