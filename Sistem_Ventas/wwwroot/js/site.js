/* Código Principal*/
var principal = new Principal();

$().ready(() => {
    //pathname permite capturar los parámetros pasados en la url 
    let URLactual = window.location.pathname;
    principal.userLink(URLactual);
    $('.sidenav').sidenav();
});