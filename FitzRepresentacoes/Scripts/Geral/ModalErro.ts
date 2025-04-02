import {Modal } from "bootstrap"
import { LogErroModel } from "../Models/LogErroModel";
export class ModalErro {
    private mensagem: string
    constructor(log: LogErroModel) {

        this.mensagem = log.messagem;

        this.AbrirModalErro();
    }
    AbrirModalErro() {
        document.getElementById("ErrorMessage").innerText = this.mensagem;
        const modalElment = document.getElementById("errorModal");
        if (modalElment) {

            const modal = new (window as any).bootstrap.Modal(modalElment);
            modal.show();
        }
    }
}