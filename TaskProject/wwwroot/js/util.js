//-------------------------------- Tabelas -------------------------------------------

// Remover corpo da tabela
$("#tblResultados tbody").children().remove();

//Remover tabela de div
$('#divTabela table').remove();

// Adicinar informações ao corpo da tabela
 $("#tblResultados tbody").append("linha");

//Remover uma linha da tabela por ID
var linha = document.getElementById("idLinha");
linha.parentElement.removeChild(linha);

//Atualizar conteúdo da célula de uma tabela por ID
var coluna = document.getElementById("idCampo");
coluna.innerText = "valor atualizado";

// Inserir linha no começo da tabela
$('#Tabela').prepend("<tr>");

// Obter total de linhas de uma tabela
var linha = document.getElementById("nomeTabela").rows.length;

//-------------------------------- Checkbox ------------------------------------------

//Marcar checkBox 
$("#campo").prop("checked", true);

//Verificar se checkBox está marcado
$("#Campo").is(':checked')

//-------------------------------- Combobox ------------------------------------------

//Mudar um select option
$("#Option").val("ValorDesejado").change();

//Pegar o texto do combobox
var nomeFornecedor = $("#cmbCli option:selected").text();

//-----Percorrer um dicionário e adicionar a um option-----
Object.keys(dicionario).forEach(function (key) {
   $('#option').append($('<option/>', {
      value: key,
      text: dicionario[key]
   }));
});

//pegar o valor no onchange
 $("#CodigoStatus").change(function () {
            val = $(this).val(); //pegar valor        
            val = $("#CodigoStatus option:selected").text();// pegar texto          
		  
});

//Obter o valor do combobox
var codigo = $("#cmbFrn option:selected").val();

//Pegar texto pelo valor
var texto = $("option[value=" + valor + "]").text();

//----------------------------- RadioBox --------------------------------------------
 
// On change para radio button
$(document).on("change", "input[type=radio]", function () {

// Pegar o valor do readio button marcado
var valor = $('[name="Nome"]:checked').val();

});

//Verificar radioBox marcado
if (document.getElementById('RadioBox').checked){}

//----------------------------- Máscaras --------------------------------------------

//Máscara para números inteiros sem limite de tamanho
<script src="~/Scripts/jquery.maskMoney.min.js"></script>
$("#Campo").maskMoney({ decimal: '', allowZero: true, thousands: '', allowNegative: false, precision: 0 })

//----------------------------- Botões ---------------------------------------------- 

//Trocar texto do botão
$("#Botao").html('texto');

//Colocar o tooltip em um botão
//<button type="button" class="btn btn-primary btn-xs" id="btnManterMargem" title="Manter margem">

$("#TabelaProdutos button").tooltip({
    html: true,
    placement: "bottom"
});	
  
//Botão fazendo POST na página depois de executar o evento Click
//Adicionar o atributo type="button":
//<button type="button" class="btn btn-primary btn-xs"> </button>

// Incluir atributos a um componente (atributo, valor)
$("#componente").attr("hidden", "hidden");

// Remover atributo de um componente
$("#componente").removeAttr("hidden");

// Adiciona um espaço em branco
//&nbsp;

// Linha pontilhada
<div class="hr-line-dashed"></div>

//Quantos registro em um dicionário
Object.keys(dicionario).length

//CallBack
Metodo(funcaoCallBack); //chamada

function Metodo2(callBack){    //método que executa
    callBack();
}

//Verifica se string contem outra string
if ($("#Variavel").val().indexOf('-') >= 0) {
	//contem
}else{
	//não contem
}

//Converter string para número
var numero = parseFloat(string.replace(',', '.'));
document.getElementById("Total" + idLinha).innerText = total.toFixed(2).replace(".", ",");

//Abrir uam URL
window.open("Endereço", "_self (mesma aba) OU _blank (nova aba)");

//Acentuação da viewBag no javascript
$("#txt").val('@Html.Raw(ViewBag.Valor)');


//Capturar o submit
$("#NomeDoForm").on("submit", function (event) {
	event.preventDefault();

	//O que deseja fazer antes do post

	//faz o submit normal do form
	this.submit(); 
});

//Definir nome para o form
//@using (Html.BeginForm("MetodoPost", "Controller", Model, FormMethod.Post, htmlAttributes: new { @id = "id" }))

//Autocomplete
for (var i = 0; i < dados.ListaEntidades.length; i++) {
	listaEntidades[i] = {
		value: dados.ListaEntidades[i].Codigo,
		label: dados.ListaEntidades[i].Descricao
	}
}

$("#Campo").autocomplete({
	source: listaEntidades,

	//quando for selecionado na lista de resultados
	select: function (event, ui) {
		event.preventDefault();

		Limpar();
		$("#Campo").val("");

		//setar valores e desabilitar campo descrição
		$("#CampoCodigo").val(ui.item.value);
		$('#Campo').val(ui.item.label);
		$("#Campo").attr("readonly", true);
		$("#btnPesquisarPlano").html("Limpar");
	},
	focus: function (event, ui) {
		event.preventDefault();
		$("#Campo").val(ui.item.label);
	},
	minLength: 0,

}).on("focus", function () {
	if ($("#Campo").val().length > 0) {
		$(this).autocomplete("search", "");
	}
});

$('#Campo').autocomplete("search", busca);

// Obter o número máximo do enumerador
Enum.GetNames(typeof(NomeEnum)).Length

// Evitar injeção de código malicioso em parâmetros
httpUtility.HtmlEncode();

// Foreach de uma linha só
Lista.ForEach(o => o.Telefone = (string.IsNullOrWhiteSpace(cli.Telefone) == true) ? "" : cli.Telefone2.Trim());

// if de uma linha só
// operador ternario
cli.Telefone = (string.IsNullOrWhiteSpace(cli.Telefone) == true) ? "" : cli.Telefone2.Trim();

// Desativar o async (assincrono)
jQuery.ajaxSetup({ async: false });
alert("teste");
jQuery.ajaxSetup({ async: true });

// Função com callback para outra função com parametros
ObterNovo(function () {
	Salvar(idTransacaoAtualizada, "");
});

// Posicionar o cursor no começo do texto
document.getElementById('idCampo').setSelectionRange(0, 0);

//----------------------------- Input --------------------------------------------

// Ao apertar enter em um campo
$("#Campo").keypress(function (event) {
	var keycode = (event.keyCode ? event.keyCode : event.which);
	if (keycode === '13' || keycode === 13) {
		// O que fazer
		
		event.preventDefault();
	}
});

//----------------------------- Modal --------------------------------------------

// Abrir modal
$("#modalId").modal({ backdrop: 'static', keyboard: false });

// Esconder a modal
$("#modalIncluir").modal("hide");

//----------------------------- Cookie --------------------------------------------

//criando o COOKIE com a data atual
var date = new Date();
date.setTime(date.getTime() + (1 * 24 * 60 * 60 * 1000)); // Validade
var expires = date.toUTCString();
document.cookie = nomeFiltro + "=" + valorASerSalvo + "; expires=" + expires + "; path=/";

//---------------------------------------------------------------------------

// Voltar a um migration, 
//Update-Database -TargetMigration:"20170511014315_NomeMigration"
//-----------------------------------------------------------

// deserializar a model inteira
//@Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model.ListaItens));

//----------------------------------
//versao do javascript
//<script src="/Scripts/Clientes.js?version=2"></script>

//---------------------------------
//erro guid null sql server
// The cast to value type 'System.Guid' failed because the materialized value is null.
// Either the result type's generic parameter or the query must use a nullable type.
 
//isnull( Cli.Id, '00000000-0000-0000-0000-000000000000') AS Id,
//isnull(RTRIM(Cli.Nome), 'Não localizado') AS Nome,
	

//----------------------------------------
//declarar variaves sql server
//declare @codigo varchar(2) = '007309'

//----------------------------
//trocar o campo null por espaço em branco
(Descricao == null) ? "" : Descricao.Trim();

//----------------------------
//select produtos repetidos 
//  SELECT MAX(id), codigo, 
//   FROM produtos
//GROUP BY codigo
//  HAVING COUNT(codigo) > 1  

//-------------------------------------
//incluir o calendar no datepicker
 $("#Data").mask('99/99/9999').datepicker();

//evitar que o datepicker fique por tras
//<style type='text/css'>  
//    .ui-datepicker {
//        z-index: 10000 !important;
//    }
//</style>
//--------------------------

//tabela responsiva
 /*<div class="table-responsive">*/
 

//----------------
//de todas parcelas
//faça uma interseccao com os adquirentes obtidos
query = query.ToList()
.Where(x => listaCli.Any(y => y.Codigo == x.CodigoCli)).AsQueryable();
break;
