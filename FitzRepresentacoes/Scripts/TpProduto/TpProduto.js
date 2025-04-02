"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g = Object.create((typeof Iterator === "function" ? Iterator : Object).prototype);
    return g.next = verb(0), g["throw"] = verb(1), g["return"] = verb(2), typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (g && (g = 0, op[0] && (_ = 0)), _) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
Object.defineProperty(exports, "__esModule", { value: true });
var Geral_js_1 = require("../Geral/Geral.js");
var ModalErro_js_1 = require("../Geral/ModalErro.js");
var MontarTable_js_1 = require("../Geral/MontarTable.js");
var geral = new Geral_js_1.MethodGeral();
CarregarTabela();
document.getElementById("NovoTpProduto").addEventListener("click", function () { return CadastroTpProduto(null); });
function CarregarTabela() {
    return __awaiter(this, void 0, void 0, function () {
        var response, _a, data;
        return __generator(this, function (_b) {
            switch (_b.label) {
                case 0: return [4 /*yield*/, fetch("/TpProduto/ObterTpProduto", {
                        headers: {
                            "Content-Type": "application/json"
                        },
                        method: "POST",
                        body: null
                    })];
                case 1:
                    response = _b.sent();
                    if (!!response.ok) return [3 /*break*/, 3];
                    _a = ModalErro_js_1.ModalErro.bind;
                    return [4 /*yield*/, response.json()];
                case 2:
                    new (_a.apply(ModalErro_js_1.ModalErro, [void 0, _b.sent()]))();
                    return [2 /*return*/];
                case 3: return [4 /*yield*/, response.json()];
                case 4:
                    data = _b.sent();
                    new MontarTable_js_1.MontarTable(["Tipo", "Descricao"], function (tpProduto) { return CadastroTpProduto(tpProduto); }, function (tpProduto) { return InativarTpProduto(tpProduto); }, data, null);
                    return [2 /*return*/];
            }
        });
    });
}
function CadastroTpProduto(tpProduto) {
    var tipoInput = document.getElementById("CadastroTpProduto");
    var descricaoInput = document.getElementById("CadastroDescricao");
    if (tpProduto) {
        document.getElementById("TituloEditar").innerText = "Editar Tipo de Produto: " + tpProduto.tipo;
        tipoInput.value = tpProduto.tipo;
        descricaoInput.value = tpProduto.descricao;
    }
    else {
        document.getElementById("TituloEditar").innerText = "Novo Tipo de Produto";
        tipoInput.value = "";
        descricaoInput.value = "";
    }
    geral.AbrirModal("tpProdutoModal", false);
    document.getElementById("salvar").addEventListener("click", function () { return SalvarTpProduto(); });
}
function InativarTpProduto(tpProduto) {
    var _this = this;
    geral.ShowModalConfirmacao("Remover " + tpProduto.tipo, "Voce deseja realmente remover o Tipo de Produto " + tpProduto.tipo, function () { return __awaiter(_this, void 0, void 0, function () {
        var response, data;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0: return [4 /*yield*/, fetch(window.location.origin + "/TpProduto/InativarTpProduto?id=" + tpProduto.id)];
                case 1:
                    response = _a.sent();
                    if (!response.ok) return [3 /*break*/, 2];
                    CarregarTabela();
                    return [2 /*return*/];
                case 2: return [4 /*yield*/, response.json()];
                case 3:
                    data = _a.sent();
                    new ModalErro_js_1.ModalErro(data.Messagem);
                    return [2 /*return*/];
            }
        });
    }); });
}
function SalvarTpProduto() {
    return __awaiter(this, void 0, void 0, function () {
        var tpProdutoForm, jsonTpProduto, response, _a;
        return __generator(this, function (_b) {
            switch (_b.label) {
                case 0:
                    tpProdutoForm = geral.getFormData("formTpProduto");
                    jsonTpProduto = JSON.stringify(tpProdutoForm);
                    return [4 /*yield*/, fetch("/TpProduto/CadastrarTpProduto", {
                            headers: {
                                "Content-Type": "application/json"
                            },
                            method: "POST",
                            body: jsonTpProduto
                        })];
                case 1:
                    response = _b.sent();
                    if (response.ok) {
                        CarregarTabela();
                        geral.AbrirModal("tpProdutoModal", true);
                        return [2 /*return*/];
                    }
                    _a = ModalErro_js_1.ModalErro.bind;
                    return [4 /*yield*/, response.json()];
                case 2:
                    new (_a.apply(ModalErro_js_1.ModalErro, [void 0, _b.sent()]))();
                    return [2 /*return*/];
            }
        });
    });
}
//# sourceMappingURL=TpProduto.js.map