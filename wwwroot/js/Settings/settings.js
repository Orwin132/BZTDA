function switchTheme() {
    var body = document.getElementById("body");
    var theme;
    if (body.className === "light-mode") {
        body.className = "dark-mode";
        theme = "dark-mode";
    } else {
        body.className = "light-mode";
        theme = "light-mode";
    }

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/Settings/SwitchTheme", true);
    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    xhr.send("theme=" + encodeURIComponent(theme));
}

let textFieldVich = document.getElementById('CalculationAccuracy');
let textFieldTarif = document.getElementById('MonthlyRate');

let btnClear = document.getElementById('btnClear');

btnClear.addEventListener('click', () => {
    if (textFieldVich.value !== "" || textFieldTarif.value !== "") {
        textFieldTarif.value = '';
        textFieldVich.value = '';
    }
});
