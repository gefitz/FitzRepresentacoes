export class MethodGeral {
    getFormData<T>(formId: string) {
        const form = document.getElementById(formId) as HTMLFormElement;
        const dataForm = new FormData(form);
        const data: any = {};


        dataForm.forEach((value, key) => {
            const keys = key.split("."); // Divide chaves aninhadas como "Cidade.Estado"
            let ref = data;

            while (keys.length > 1) {
                const part = keys.shift();
                if (!ref[part]) ref[part] = {}; // Cria objeto se não existir
                ref = ref[part];
            }

            ref[keys[0]] = value;
        });
        return data as T;
    }
    ShowModalConfirmacao(tituloConfirmacao: string, textoConfirmacao: string, funcaoConfirmacao: () => void) {
        document.getElementById("TituloConfirmacao").innerText = tituloConfirmacao;
        document.getElementById("TextoConfirmacao").innerText = textoConfirmacao;
        const modalConfirmacao = document.getElementById("modalConfirmacao");
        if (modalConfirmacao) {

            const modal = new (window as any).bootstrap.Modal(modalConfirmacao);
            modal.show();
            document.getElementById("btnSim").addEventListener("click", () => {
                funcaoConfirmacao();
                modal.hide();
            })
        }
    }
    FormataCidade(obj: any): string {
        if (!obj) return "";
        return obj.cidade + " / " + obj.sigla
    }
}