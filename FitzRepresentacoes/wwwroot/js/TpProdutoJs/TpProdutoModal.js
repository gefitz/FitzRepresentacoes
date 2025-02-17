function PreencherFormulario(id, tpProduto, descricao) {
    var formValidacao = {
        TpProduto: { required: true },
        Descricao: { required: true }
    }
    CriaValidacaoForm("#formTpProduto", formValidacao)
    if (id != '' && tpProduto != '' && descricao != '') {
        $("#TituloEditar").text("Editar - " + tpProduto)
        $("#CadastroTpProduto").val(tpProduto);
        $("#CadastroDescricao").val(descricao);
        $("#id").val(id);
    } else {
        $("#TituloEditar").text("Cadastar Tipo Produto");
        $("#CadastroTpProduto").val("");
        $("#CadastroDescricao").val("");
    }
}

function SalvarTipoProduto() {
    if ($("#formTpProduto").valid()) {
        console.log("Entro no if");
        var tpProdutoJSO = {
            id: $("#id").val(),
            TpProduto: $("#CadastroTpProduto").val(),
            Descricao: $("#CadastroDescricao").val()

        }
        $.ajax({
            url: "/TpProduto/CadastrarTpProduto",
            type: "POST",
            data: tpProdutoJSO,
            success: function (resp) {
                if (!resp.success) {
                ShowModalError(resp.errors)
                }
                    $("#tpProdutoModal").hide();
                    location.reload();
                    return;
            }
        })
    }
}