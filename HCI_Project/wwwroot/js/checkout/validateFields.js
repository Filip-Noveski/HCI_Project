function validateFields() {
    var continent = document.getElementById("continent").value;
    var country = document.getElementById("country").value;
    var province = document.getElementById("province").value;
    var city = document.getElementById("city").value;
    var address = document.getElementById("address").value;
    var zip = document.getElementById("zip").value;
    var first = document.getElementById("first").value;
    var last = document.getElementById("last").value;
    var email = document.getElementById("email").value;
    var phone = document.getElementById("phone-num").value;
    var errorText = document.getElementById("error-text");
    if (continent == "") {
        errorText.innerHTML = "Please fill in all fields. Continent is empty";
        return false;
    }
    if (country == "") {
        errorText.innerHTML = "Please fill in all fields. Country is empty";
        return false;
    }
    if (province == "") {
        errorText.innerHTML = "Please fill in all fields. Province/County/Municipality is empty";
        return false;
    }
    if (city == "") {
        errorText.innerHTML = "Please fill in all fields. City is empty";
        return false;
    }
    if (address == "") {
        errorText.innerHTML = "Please fill in all fields. Address is empty";
        return false;
    }
    if (zip == "") {
        errorText.innerHTML = "Please fill in all fields. ZIP Code is empty";
        return false;
    }
    if (first == "") {
        errorText.innerHTML = "Please fill in all fields. First Name is empty";
        return false;
    }
    if (last == "") {
        errorText.innerHTML = "Please fill in all fields. Last Name is empty";
        return false;
    }
    if (email == "") {
        errorText.innerHTML = "Please fill in all fields. Email is empty";
        return false;
    }
    if (phone == "") {
        errorText.innerHTML = "Please fill in all fields. Phone Number is empty";
        return false;
    }
    return true;
}