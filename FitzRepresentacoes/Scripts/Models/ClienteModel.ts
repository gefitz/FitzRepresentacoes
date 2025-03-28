import { CidadeModel } from "./CidadeModel.js"

export interface ClienteModel {
    id: number,
    nome: string,
    documento: string,
    cidade: CidadeModel,
    rua: string,
    bairro: string,
    cep: string,
    dthNascimento: Date,
    email: string,
    telefone: string

}