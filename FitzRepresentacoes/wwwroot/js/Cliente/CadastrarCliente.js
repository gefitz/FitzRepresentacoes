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
const methodGeral = new MethodGeral();
document.getElementById("CadastrarCliente").addEventListener("submit", (e) => __awaiter(void 0, void 0, void 0, function* () {
    e.preventDefault();
    const cliente = methodGeral.getFormData("CadastrarCliente");
    const dataString = JSON.stringify(cliente);
    console.log(dataString);
    const response = yield fetch("/Cliente/Cadastrar", {
        headers: {
            "Content-Type": "application/json"
        },
        method: "POST",
        body: dataString
    });
    if (!response.ok) {
        new ModalErro(yield response.json());
        return;
    }
    window.location.href = "/Cliente";
}));
//# sourceMappingURL=CadastrarCliente.js.map