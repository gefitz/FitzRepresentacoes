export class ModalErro {
    constructor(log) {
        console.log(log);
        this.mensagem = log.messagem;
        console.log(this.mensagem);
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