var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
export class MethodGeral {
    getFormData(formId) {
        const form = document.getElementById(formId);
        const dataForm = new FormData(form);
        var data = {};
        dataForm.forEach((value, key) => {
            if (key === "__Invariant")
                return;
            const keys = key.split("."); // Divide chaves aninhadas como "Cidade.Estado"
            while (keys.length > 1) {
                const part = keys.shift();
                if (part.toLowerCase() === "id")
                    if (!data[part])
                        data[part] = {}; // Cria objeto se não existir
                data = data[part];
            }
            if (key.toLowerCase() === "id") {
                console.log("Ola");
                data[keys[0]] = value ? Number(value) : 0;
            }
            else
                data[keys[0]] = value;
        });
        return data;
    }
    ShowModalConfirmacao(tituloConfirmacao, textoConfirmacao, funcaoConfirmacao) {
        document.getElementById("TituloConfirmacao").innerText = tituloConfirmacao;
        document.getElementById("TextoConfirmacao").innerText = textoConfirmacao;
        const btnSim = document.getElementById("btnSim");
        this.AbrirModal("modalConfirmacao", false);
        //adicionado para remover event duplicado
        const handler = () => __awaiter(this, void 0, void 0, function* () {
            yield funcaoConfirmacao();
            btnSim.removeEventListener("click", handler);
        });
        btnSim.addEventListener("click", handler);
    }
    FormataCidade(obj) {
        if (!obj)
            return "";
        return obj.cidade + " / " + obj.sigla;
    }
    AbrirModal(idModal, fechar) {
        if (idModal) {
            const modalHtml = document.getElementById(idModal);
            var modal = window.bootstrap.Modal.getInstance(modalHtml);
            if (!modal)
                modal = new window.bootstrap.Modal(modalHtml);
            if (fechar)
                modal.hide();
            else
                modal.show();
        }
    }
}
//# sourceMappingURL=Geral.js.map