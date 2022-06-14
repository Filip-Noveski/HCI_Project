function loadDialCode() {
    var country = document.getElementById("country");
    var flag = document.getElementById("flag");
    var code = document.getElementById("phone-code");

    if (country.value == "") {
        flag.style.backgroundImage = "none";
        code.value = "";
        return;
    }

    var countryCode = country.value.split('|')[0];
    var dialCode = country.value.split('|')[1];

    flag.style.backgroundImage = `url('/Countries/flags/${countryCode}.jpg')`;
    code.value = dialCode;
}