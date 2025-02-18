function ChamadasAjax(parametros) {
    $.ajax({
        url: parametros.url,
        type: "POST",
        data: parametros.data,
        success: function (resp) {
            console.log(resp);
            if (!resp.succes) {
                ShowModalError(resp.errors)
            } else {
                location.reload();
            }
        }
    })
}