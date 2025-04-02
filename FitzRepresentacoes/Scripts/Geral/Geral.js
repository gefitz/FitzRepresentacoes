"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.MethodGeral = void 0;
var MethodGeral = /** @class */ (function () {
    function MethodGeral() {
    }
    MethodGeral.prototype.getFormData = function (formId) {
        var form = document.getElementById(formId);
        var dataForm = new FormData(form);
        var data = {};
        dataForm.forEach(function (value, key) {
            var keys = key.split("."); // Divide chaves aninhadas como "Cidade.Estado"
            var ref = data;
            while (keys.length > 1) {
                var part = keys.shift();
                if (!ref[part])
                    ref[part] = {}; // Cria objeto se não existir
                ref = ref[part];
            }
            ref[keys[0]] = value;
        });
        return data;
    };
    MethodGeral.prototype.ShowModalConfirmacao = function (tituloConfirmacao, textoConfirmacao, funcaoConfirmacao) {
        document.getElementById("TituloConfirmacao").innerText = tituloConfirmacao;
        document.getElementById("TextoConfirmacao").innerText = textoConfirmacao;
        var modalConfirmacao = document.getElementById("modalConfirmacao");
        if (modalConfirmacao) {
            var modal_1 = new window.bootstrap.Modal(modalConfirmacao);
            modal_1.show();
            document.getElementById("btnSim").addEventListener("click", function () {
                funcaoConfirmacao();
                modal_1.hide();
            });
        }
    };
    MethodGeral.prototype.FormataCidade = function (obj) {
        if (!obj)
            return "";
        return obj.cidade + " / " + obj.sigla;
    };
    MethodGeral.prototype.AbrirModal = function (idModal, fechar) {
        if (idModal) {
            var modalHtml = document.getElementById(idModal);
            var modal = new window.bootstrap.Modal(modalHtml);
            if (fechar)
                modal.hide();
            else
                modal.show();
        }
    };
    return MethodGeral;
}());
exports.MethodGeral = MethodGeral;
//# sourceMappingURL=Geral.js.map