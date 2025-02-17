function ValidaForm(form) {
    if ($(form).valid()) {
        return true;
    }
    var listElementError = $(form).validate().errorList;
    for (var i = 0; i < listElementError.length; i++) {
        var element = listElementError[i].element;
        $(element).addClass("alert-danger");
        listElementError[i].message = '';
        
    }
    console.log(listElementError);
    return false;
}
function CriaValidacaoForm(form, regras) {
    $.extend($.validator.messages, {
        required: "" // Deixa a mensagem vazia
    });
    $(form).validate({
        errorClass: "is-invalid",
        errorElement: "div",
        errorPlacement: function (error, element) {
            error.addClass("invalid-feedback").insertAfter(element);
        },
        rules: regras,
        messages: "",
        showErrors: function (errorMap, errorList) {
            // Não exibe mensagens de erro
            this.defaultShowErrors();
        }

    })
}
function ShowModalError(messagem) {
    $("#ErrorMessage").text(messagem);
    $('#errorModal').modal('show');
    
}