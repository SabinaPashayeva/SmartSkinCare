// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function(){
    $('.header').height($(window).height());
    changeHref($("#flowerhouse"));
    if (getCookie("lang") !== "") {
        $("#select").val(getCookie("lang")).change();
    }
});

let base_url = "https://13f1b505.ngrok.io";

$(".navbar a").click(function(){
    if ($(this).data('value') != undefined){
        $("body,html").animate({
            scrollTop:$("#" + $(this).data('value')).offset().top
        },1000)
    }
});

$("#register-button").click(function(){
    var name = $("input[name='username']").val();
    var email = $("input[name='email']").val();
    if (!validateEmail(email)) {
        alert("Wrong email!");
        return;
    }
    var password = $("input[name='psw']").val();
    var rptpassword = $("input[name='psw-repeat']").val();

    if (password !== rptpassword) {
        alert("Passwords are different!")
        return;
    }

    var role = "User";

    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open( "POST", base_url + "/api/authorization/register", false ); // false for synchronous request
    xmlHttp.setRequestHeader('Content-type', 'application/json');

    var obj = {
        userName: name,
        password: password,
        username: email,
        role: role
    };
    xmlHttp.send(JSON.stringify(obj));

    var response_object = JSON.parse(xmlHttp.responseText);
    document.cookie = "access_token="+response_object.access_token;

    alert("Success!");
});

$("#login-button").click(function(){
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open( "POST", base_url + "/api/authorization/login", false ); // false for synchronous request
    xmlHttp.setRequestHeader('Content-type', 'application/json');

    if ($("#username").val() == "" ||
        $("#inputPassword").val() == ""
    ) {
        alert("Please enter Username/Password!");
        return;
    }

    var obj = { username: $("#username").val(), password: $("#inputPassword").val()};
    xmlHttp.send(JSON.stringify(obj));

    if (xmlHttp.responseText === "Wrong credentials!")
    {
        alert("Wrong credentials!");
        return;
    }

    var response_object = JSON.parse(xmlHttp.responseText);

    $("#Login").attr("action", "skinCare.html");

    setCookie("access_token", response_object.access_token, 15)
});

function changeHref(name)
{
    if (getCookie("access_token")!=""){
        name.attr('href','skinCare.html');
    }
}

function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}


function onLocalized() {
    var l10n = document.webL10n,
        textProp = document.body.textContent ? 'textContent' : 'innerText';

    if (l10n.getLanguage() === "en" || l10n.getLanguage() === "ua") {
        setCookie("lang", l10n.getLanguage(), 100);
    }
    document.getElementsByTagName('select')[0].value = l10n.getLanguage();
    document.getElementById('l10n').getElementsByTagName('textarea')[0][textProp] =
        l10n.getText();
    document.getElementById('json').getElementsByTagName('textarea')[0][textProp] =
        window.JSON ? JSON.stringify(l10n.getData(), undefined, 2) : 'no JSON support';
};

if (document.addEventListener) {
    window.addEventListener('localized', onLocalized, false);
} else {
    document.documentElement.localized = 0;
    document.documentElement.attachEvent('onpropertychange', function(e) {
        if (e.propertyName === 'localized')
            onLocalized();
    });
}

