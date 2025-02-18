$(document).ready(function () {
    $("#formLogin").on('keydown', function (event) {
        if (event.key === "Enter") {
            event.preventDefault(); // Evita o comportamento padrão do Enter
            Authentiar(); // Chama a função de autenticação
        }
    });
});
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