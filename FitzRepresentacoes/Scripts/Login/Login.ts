import { LoginModel } from "../Models/LoginModel.js"
import { MethodGeral } from "../Geral/Geral.js"
import { ModalErro } from "../Geral/ModalErro.js"

const methodGeral = new MethodGeral();
document.getElementById("formLogin").addEventListener(("submit"), async (e) => {
    e.preventDefault();
    const login = methodGeral.getFormData<LoginModel>("formLogin");
    const JsonString = JSON.stringify(login);
    console.log(JsonString);
    const response = await fetch("/Login/Login", {
        method:"Post",
        headers: {
            "Content-Type":"application/json"
        },
        body: JsonString
    })
    if (!response.ok) {
        new ModalErro(await response.json())
        return;
    }
    window.location.href = "/Home";

})

