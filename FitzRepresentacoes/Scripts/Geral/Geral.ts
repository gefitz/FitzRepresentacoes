export class MethodGeral {
    getFormData<T>(formId: string) {
        const form = document.getElementById(formId) as HTMLFormElement;
        const dataForm = new FormData(form);
        var data: any = {};

        dataForm.forEach((value, key) => {
            if (key === "__Invariant") return;
            const keys = key.split("."); // Divide chaves aninhadas como "Cidade.Estado"


            while (keys.length > 1) {
                const part = keys.shift();
                if (part.toLowerCase() === "id")
                    
                if (!data[part]) data[part] = {}; // Cria objeto se não existir
                data = data[part];
            }
            if (key.toLowerCase() === "id") {
                console.log("Ola")
                   data[keys[0]] = value ? Number(value) : 0;
            }
            else
                data[keys[0]] = value;
        });
        return data as T;
    }
    ShowModalConfirmacao(tituloConfirmacao: string, textoConfirmacao: string, funcaoConfirmacao: () => void) {
        document.getElementById("TituloConfirmacao").innerText = tituloConfirmacao;
        document.getElementById("TextoConfirmacao").innerText = textoConfirmacao;
        const btnSim = document.getElementById("btnSim");
        this.AbrirModal("modalConfirmacao", false);
        //adicionado para remover event duplicado
        const handler = async () => {
            await funcaoConfirmacao();
            btnSim.removeEventListener("click", handler)
        }
        btnSim.addEventListener("click", handler)
    }
    FormataCidade(obj: any): string {
        if (!obj) return "";
        return obj.cidade + " / " + obj.sigla
    }
    AbrirModal(idModal, fechar) {
        if (idModal) {
            const modalHtml = document.getElementById(idModal)
            var modal = (window as any).bootstrap.Modal.getInstance(modalHtml);
            if (!modal)
                    modal = new (window as any).bootstrap.Modal(modalHtml);
            if (fechar)
                modal.hide();

            else
            modal.show();
        }
    }

}