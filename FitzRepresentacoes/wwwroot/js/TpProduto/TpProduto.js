var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { MethodGeral } from "../Geral/Geral.js";
import { ModalErro } from "../Geral/ModalErro.js";
import { MontarTable } from "../Geral/MontarTable.js";
const geral = new MethodGeral();
document.getElementById("salvar").addEventListener("click", () => SalvarTpProduto());
CarregarTabela();
document.getElementById("NovoTpProduto").addEventListener("click", () => CadastroTpProduto(null));
document.getElementById("btnFiltro").addEventListener("click", () => AbrirModal());
document.getElementById("btnSim").addEventListener("click", () => CarregarTabela());
function CarregarTabela() {
    return __awaiter(this, void 0, void 0, function* () {
        const formPesquisa = geral.getFormData("formPesquisa");
        const json = JSON.stringify(formPesquisa);
        const response = yield fetch("/TpProduto/ObterTpProduto", {
            headers: {
                "Content-Type": "application/json"
            },
            method: "POST",
            body: json
        });
        if (!response.ok) {
            new ModalErro(yield response.json());
            return;
        }
        var data = yield response.json();
        new MontarTable(["Tipo", "Descricao"], (tpProduto) => CadastroTpProduto(tpProduto), (tpProduto) => InativarTpProduto(tpProduto), data, null);
        geral.AbrirModal("modalPesquisa", true);
    });
}
function CadastroTpProduto(tpProduto) {
    const tipoInput = document.getElementById("CadastroTpProduto");
    const descricaoInput = document.getElementById("CadastroDescricao");
    const id = document.getElementById("id");
    if (tpProduto) {
        document.getElementById("TituloEditar").innerText = "Editar Tipo de Produto: " + tpProduto.tipo;
        tipoInput.value = tpProduto.tipo;
        descricaoInput.value = tpProduto.descricao;
        id.value = tpProduto.id;
    }
    else {
        document.getElementById("TituloEditar").innerText = "Novo Tipo de Produto";
        tipoInput.value = "";
        descricaoInput.value = "";
        id.value = "";
    }
    geral.AbrirModal("tpProdutoModal", false);
}
function InativarTpProduto(tpProduto) {
    geral.ShowModalConfirmacao("Remover " + tpProduto.tipo, "Voce deseja realmente remover o Tipo de Produto " + tpProduto.tipo, () => __awaiter(this, void 0, void 0, function* () {
        var response = yield fetch(window.location.origin + "/TpProduto/InativarTpProduto?id=" + tpProduto.id);
        if (response.ok) {
            CarregarTabela();
            geral.AbrirModal("modalConfirmacao", true);
            return;
        }
        else {
            var data = yield response.json();
            new ModalErro(data);
            return;
        }
    }));
}
function SalvarTpProduto() {
    return __awaiter(this, void 0, void 0, function* () {
        const tpProdutoForm = geral.getFormData("formTpProduto");
        const json = JSON.stringify(tpProdutoForm);
        console.log(json);
        const response = yield fetch("/TpProduto/CadastrarTpProduto", {
            method: "Post",
            headers: {
                "Content-Type": "application/json"
            },
            body: json
        });
        if (response.ok) {
            geral.AbrirModal("tpProdutoModal", true);
            CarregarTabela();
            return;
        }
        new ModalErro(yield response.json());
    });
}
function AbrirModal() {
    geral.AbrirModal("modalPesquisa", false);
}
//# sourceMappingURL=TpProduto.js.map