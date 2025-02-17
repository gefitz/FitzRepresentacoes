function ChamadasAjax(parametros) {
    console.log(parametros);
    $.ajax({
        url: parametros.url,
        type: "POST",
        data: parametros.data,
        success: function (resp) {
            console.log(resp);
            if (!resp.succes) {
                console.log("Ola");
                ShowModalError(resp.errors)
            } else {
                location.reload();
            }
        }
    })
}