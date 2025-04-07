import { MontarTable } from "../Geral/MontarTable.js"
import { ModalErro } from "../Geral/ModalErro.js"
import { ClienteModel } from "../Models/ClienteModel.js";
import { MethodGeral } from "../Geral/Geral.js";

const geral = new MethodGeral();
CarregarTabela();

document.getElementById("filtro").addEventListener("click", () => AbrirModalFiltro())
async function CarregarTabela() {
    var filtro = geral.getFormData<ClienteModel>("formPesquisa");
    var response = await fetch(window.location.origin + "/Cliente/ObterClientes", {
        headers: {
            "Content-Type": "application/json"
        },
        method: "POST",
        body: JSON.stringify(filtro)
    });
    if (response.ok) {
        var data = await response.json();
        var colunasTable = ["Nome", "Documento", "Telefone", "Cidade", "Rua", "Pedidos"]
        new MontarTable(
            colunasTable,
            (cliente) => EditarCliente(cliente),
            (cliente) => InativarCliente(cliente),
            data,
            (obj, propriedade) => {
                if (propriedade == "Pedidos")
                    return obj.length
                return geral.FormataCidade(obj)
            }
        )
    }

}
function EditarCliente(cliente: ClienteModel) {
    window.location.href = "/Cliente/Cadastrar?id=" + cliente.id;
}
function InativarCliente(cliente: ClienteModel) {
    geral.ShowModalConfirmacao(
        "Remover " + cliente.nome,
        "Voce deseja realmente remover o cliente " + cliente.nome
        , async () => {
            var response = await fetch(window.location.origin + "/Cliente/InativarCliente?id=" + cliente.id);
            if (response.ok) {
                CarregarTabela();
            } else {
                var data = await response.json();
                new ModalErro(data.Messagem);
            }
        });

}
function AbrirModalFiltro() {
    const modalHtml = document.getElementById("modalPesquisa");
    if (modalHtml) {
        const modal = new (window as any).bootstrap.Modal(modalHtml);
        modal.show();
        const btnFiltrar = document.getElementById("filtrar");
        if (btnFiltrar) {
            btnFiltrar.removeEventListener("click", () =>Filtrar(modal))
            btnFiltrar.addEventListener('click', () =>  Filtrar(modal))
        }
    }
}
function Filtrar(modal) {
    CarregarTabela();
    modal.hide();
}


