import { MethodGeral } from "../Geral/Geral.js";
import { ModalErro } from "../Geral/ModalErro.js";
import { ClienteModel } from "../Models/ClienteModel.js";

const methodGeral = new MethodGeral();
document.getElementById("CadastrarCliente").addEventListener("submit",async (e) => {
    e.preventDefault();
    const cliente = methodGeral.getFormData<ClienteModel>("CadastrarCliente");
    const dataString = JSON.stringify(cliente);
    console.log(dataString);
    const response = await fetch("/Cliente/Cadastrar", {
        headers: {
            "Content-Type": "application/json"
        },
        method: "POST",
        body: dataString
    })
    if (!response.ok) {
        new ModalErro(await response.json())
        return;
    }

    window.location.href = "/Cliente";
})