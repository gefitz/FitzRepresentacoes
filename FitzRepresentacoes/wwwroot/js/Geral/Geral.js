export class MethodGeral {
    getFormData(formId) {
        const form = document.getElementById(formId);
        const dataForm = new FormData(form);
        const data = {};
        dataForm.forEach((value, key) => {
            const keys = key.split("."); // Divide chaves aninhadas como "Cidade.Estado"
            let ref = data;
            while (keys.length > 1) {
                const part = keys.shift();
                if (!ref[part])
                    ref[part] = {}; // Cria objeto se não existir
                ref = ref[part];
            }
            ref[keys[0]] = value;
        });
        return data;
    }
    ShowModalConfirmacao(tituloConfirmacao, textoConfirmacao, funcaoConfirmacao) {
        document.getElementById("TituloConfirmacao").innerText = tituloConfirmacao;
        document.getElementById("TextoConfirmacao").innerText = textoConfirmacao;
        const modalConfirmacao = document.getElementById("modalConfirmacao");
        if (modalConfirmacao) {
            const modal = new window.bootstrap.Modal(modalConfirmacao);
            modal.show();
            document.getElementById("btnSim").addEventListener("click", () => {
                funcaoConfirmacao();
                modal.hide();
            });
        }
    }
    FormataCidade(obj) {
        if (!obj)
            return "";
        return obj.cidade + " / " + obj.sigla;
    }
}
//# sourceMappingURL=Geral.js.map