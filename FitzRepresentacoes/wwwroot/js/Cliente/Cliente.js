var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
import { MontarTable } from "../Geral/MontarTable.js";
import { ModalErro } from "../Geral/ModalErro.js";
import { MethodGeral } from "../Geral/Geral.js";
const geral = new MethodGeral();
CarregarTabela();
document.getElementById("filtro").addEventListener("click", () => AbrirModalFiltro());
function CarregarTabela() {
    return __awaiter(this, void 0, void 0, function* () {
        var filtro = geral.getFormData("formPesquisa");
        var response = yield fetch(window.location.origin + "/Cliente/ObterClientes", {
            headers: {
                "Content-Type": "application/json"
            },
            method: "POST",
            body: JSON.stringify(filtro)
        });
        if (response.ok) {
            var data = yield response.json();
            var colunasTable = ["Nome", "Documento", "Telefone", "Cidade", "Rua", "Pedidos"];
            new MontarTable(colunasTable, (cliente) => EditarCliente(cliente), (cliente) => InativarCliente(cliente), data, (obj, propriedade) => {
                if (propriedade == "Pedidos")
                    return obj.length;
                return geral.FormataCidade(obj);
            });
        }
    });
}
function EditarCliente(cliente) {
    window.location.href = "/Cliente/Cadastrar?id=" + cliente.id;
}
function InativarCliente(cliente) {
    geral.ShowModalConfirmacao("Remover " + cliente.nome, "Voce deseja realmente remover o cliente " + cliente.nome, () => __awaiter(this, void 0, void 0, function* () {
        var response = yield fetch(window.location.origin + "/Cliente/InativarCliente?id=" + cliente.id);
        if (response.ok) {
            CarregarTabela();
        }
        else {
            var data = yield response.json();
            new ModalErro(data.Messagem);
        }
    }));
}
function AbrirModalFiltro() {
    const modalHtml = document.getElementById("modalPesquisa");
    if (modalHtml) {
        const modal = new window.bootstrap.Modal(modalHtml);
        modal.show();
        const btnFiltrar = document.getElementById("filtrar");
        if (btnFiltrar) {
            btnFiltrar.removeEventListener("click", () => Filtrar(modal));
            btnFiltrar.addEventListener('click', () => Filtrar(modal));
        }
    }
}
function Filtrar(modal) {
    CarregarTabela();
    modal.hide();
}
//# sourceMappingURL=Cliente.js.map