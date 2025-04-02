import { MethodGeral } from "../Geral/Geral.js";
import { ModalErro } from "../Geral/ModalErro.js";
import { MontarTable } from "../Geral/MontarTable.js";
import { TpProdutoModel } from "../Models/TpProdutoMode.js";

const geral = new MethodGeral();
document.getElementById("salvar").addEventListener("click", () => SalvarTpProduto())
CarregarTabela();

document.getElementById("NovoTpProduto").addEventListener("click", () => CadastroTpProduto(null))
document.getElementById("btnFiltro").addEventListener("click", () => AbrirModal())
document.getElementById("btnSim").addEventListener("click", () => CarregarTabela())
async function CarregarTabela() {
    const formPesquisa = geral.getFormData<TpProdutoModel>("formPesquisa");
    const json = JSON.stringify(formPesquisa);
    const response = await fetch("/TpProduto/ObterTpProduto",
        {
            headers: {
                "Content-Type": "application/json"
            },
            method: "POST",
            body: json
        });
    if (!response.ok) {
        new ModalErro(await response.json());
        return;
    }
    var data = await response.json();
    new MontarTable(
        ["Tipo", "Descricao"],
        (tpProduto) => CadastroTpProduto(tpProduto),
        (tpProduto) => InativarTpProduto(tpProduto),
        data,
        null,
    )
    geral.AbrirModal("modalPesquisa", true);
}
function CadastroTpProduto(tpProduto) {
    const tipoInput = document.getElementById("CadastroTpProduto") as HTMLInputElement;
    const descricaoInput = document.getElementById("CadastroDescricao") as HTMLInputElement;
    const id = document.getElementById("id") as HTMLInputElement;
    if (tpProduto) {
        document.getElementById("TituloEditar").innerText = "Editar Tipo de Produto: " + tpProduto.tipo
        tipoInput.value = tpProduto.tipo;
        descricaoInput.value = tpProduto.descricao;
        id.value = tpProduto.id;
    } else {
        document.getElementById("TituloEditar").innerText = "Novo Tipo de Produto";
        tipoInput.value = "";
        descricaoInput.value = "";
        id.value = "";
    }
    geral.AbrirModal("tpProdutoModal", false);
}
function InativarTpProduto(tpProduto) {
    geral.ShowModalConfirmacao(
        "Remover " + tpProduto.tipo,
        "Voce deseja realmente remover o Tipo de Produto " + tpProduto.tipo
        , async () => {
            var response = await fetch(window.location.origin + "/TpProduto/InativarTpProduto?id=" + tpProduto.id);
            if (response.ok) {
                CarregarTabela();
                geral.AbrirModal("modalConfirmacao", true)
                return;
            } else {
                var data = await response.json();
                new ModalErro(data);
                return;
            }
        });

}

async function SalvarTpProduto() {
    const tpProdutoForm = geral.getFormData<TpProdutoModel>("formTpProduto");
    const json = JSON.stringify(tpProdutoForm)
    console.log(json)
    const response = await fetch("/TpProduto/CadastrarTpProduto", {
        method: "Post",
        headers: {
            "Content-Type": "application/json"
        },
        body: json
    })
    if (response.ok) {
        geral.AbrirModal("tpProdutoModal", true);
        CarregarTabela();
        return;
    }
    new ModalErro(await response.json());
}

function AbrirModal() {
    geral.AbrirModal("modalPesquisa", false);
}
