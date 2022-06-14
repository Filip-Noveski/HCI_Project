function loadCountries() {
    var continent = document.getElementById("continent").value;
    var data = new FormData();
    data.append("continent", continent);

    $.ajax({
        url: "/Partial/LoadCountries",
        type: "POST",
        async: false,
        data: data,
        processData: false,
        contentType: false,
        success: function (result) {
            document.getElementById("country").innerHTML = result;
        },
        error: function (res) {
            alert(res.responseText);
        },
        failure: function (res) {
            alert(res.responseText);
        }
    });

    var flag = document.getElementById("flag");
    var code = document.getElementById("phone-code");

    flag.style.backgroundImage = "none";
    code.value = "";
}