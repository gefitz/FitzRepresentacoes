export class ModalErro {
    constructor(log) {
        this.mensagem = log.messagem;
        this.AbrirModalErro();
    }
    AbrirModalErro() {
        document.getElementById("ErrorMessage").innerText = this.mensagem;
        const modalElment = document.getElementById("errorModal");
        if (modalElment) {
            const modal = new window.bootstrap.Modal(modalElment);
            modal.show();
        }
    }
}
//# sourceMappingURL=ModalErro.js.map