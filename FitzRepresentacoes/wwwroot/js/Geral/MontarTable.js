var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
export class MontarTable {
    constructor(cabecalhoTabela, editar, inativar, data, funcaoFormatacao) {
        this._cabecalhoTabela = cabecalhoTabela;
        this.table = document.createElement("table");
        this.editar = editar;
        this.inativar = inativar;
        this.data = data;
        this.funcaoFormatacao = funcaoFormatacao;
        this.GerarTabela();
    }
    GerarTabela() {
        return __awaiter(this, void 0, void 0, function* () {
            document.getElementById("table").innerHTML = "";
            this.GerarCabecalho();
            this.GerarBodyTable();
            const div = document.createElement("div");
            if (div) {
                div.innerHTML = "";
                this.table.className = "table table-bordered";
                div.appendChild(this.table);
                document.getElementById("table").appendChild(div);
            }
        });
    }
    GerarCabecalho() {
        const cabecalho = this.table.createTHead();
        const row = cabecalho.insertRow();
        this._cabecalhoTabela.forEach(cabecalhoText => {
            const th = document.createElement("th");
            th.textContent = cabecalhoText;
            row.appendChild(th);
        });
        row.appendChild(document.createElement("th"));
        row.appendChild(document.createElement("th"));
    }
    GerarBodyTable() {
        const tbody = this.table.createTBody();
        this.data.forEach(obj => {
            const row = tbody.insertRow();
            this._cabecalhoTabela.forEach(key => {
                const cell = row.insertCell();
                var propriedadeJson = obj[key.toLowerCase()];
                if (typeof propriedadeJson == "object") {
                    cell.textContent = this.funcaoFormatacao(propriedadeJson, key);
                }
                else {
                    cell.textContent = propriedadeJson;
                }
            });
            const actionEditar = row.insertCell();
            const actionDelete = row.insertCell();
            const btnEditar = document.createElement("button");
            btnEditar.className = "btn btn-outline-primary border-0";
            const iconEditar = document.createElement("span");
            iconEditar.className = "material-symbols-outlined ";
            iconEditar.textContent = "edit";
            btnEditar.appendChild(iconEditar);
            btnEditar.addEventListener("click", () => this.editar(obj));
            actionEditar.appendChild(btnEditar);
            const btnRemover = document.createElement("button");
            btnRemover.className = "btn btn-outline-danger border-0";
            const iconDelete = document.createElement("span");
            iconDelete.className = "material-symbols-outlined ";
            iconDelete.textContent = "delete";
            btnRemover.appendChild(iconDelete);
            btnRemover.addEventListener("click", () => this.inativar(obj));
            actionDelete.appendChild(btnRemover);
        });
    }
}
//# sourceMappingURL=MontarTable.js.map