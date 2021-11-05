// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#btnFindTasks").click(function () {

    FindTasks();

});

function FindTasks() {

    //limpar tabela
    $('#TableTasks').empty();

    dataInicial = $("#InitialDate").val();
    dataFinal = $("#FinalDate").val();

    //Consumindo o serviço
    $.post("http://localhost:50747/Home/ListHoursPerDay/",
        {
            InitialDate: dataInicial,
            FinalDate: dataFinal,
        }, function (dados) {

            //preenchendo a lista de resultados
            for (var i = 0; i < dados.listTasksSummarized.length; i++) {

                $('#TableTasks').append('<tr><td>' + ConverterDataJson(dados.listTasksSummarized[i].date) +
                    '</td><td>' + ConverterHoraSimples(dados.listTasksSummarized[i].hours) +
                    '</td><td>' + dados.listTasksSummarized[i].totalTasks +
                    '</td><td>' + ConverterHoraSimples(dados.listTasksSummarized[i].averageHours) +
                    '</td><td>' + dados.listTasksSummarized[i].percentualConcludedTasks + "%" +
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