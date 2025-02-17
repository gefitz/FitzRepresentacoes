function Authentiar() {
    var formValue = {
        Email: $("#Email").val(),
        Password: $("#Password").val()
    }
    var parametro = {
        url: "/Login/Login",
        data: formValue
    }
    ChamadasAjax(parametro);
}