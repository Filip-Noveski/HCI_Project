function validateData(name, price, currency, type, image, age) {
    var validData = true;
    if (name == "") {
        validData = false;
        var errorText = document.getElementById("name-error");
        errorText.innerHTML = "Missing Data: Please enter the name of the product.";
        errorText.style.display = "block";
    }
    else {
        document.getElementById("name-error").style.display = "none";
    }
    if (price == "" && currency == "none") {
        validData = false;
        var errorText = document.getElementById("price-error");
        errorText.innerHTML = "Missing Data: Please enter the currency and price of the product.";
        errorText.style.display = "block";
    }
    else if (price == "") {
        validData = false;
        var errorText = document.getElementById("price-error");
        errorText.innerHTML = "Missing Data: Please enter the price of the product.";
        errorText.style.display = "block";
    }
    else if (currency == "none" && isNaN(parseFloat(price))) {
        validData = false;
        var errorText = document.getElementById("price-error");
        errorText.innerHTML = "Missing Data: Please enter the currency and a valid price for the product.";
        errorText.style.display = "block";
    }
    else if (currency == "none") {
        validData = false;
        var errorText = document.getElementById("price-error");
        errorText.innerHTML = "Missing Data: Please enter the currency.";
        errorText.style.display = "block";
    }
    else if (isNaN(parseFloat(price))) {
        validData = false;
        var errorText = document.getElementById("price-error");
        errorText.innerHTML = "Missing Data: Please enter a valid price for the product.";
        errorText.style.display = "block";
    }
    else {
        document.getElementById("price-error").style.display = "none";
    }
    if (type == "none") {
        validData = false;
        var errorText = document.getElementById("type-error");
        errorText.innerHTML = "Missing Data: Please enter the type of the product.";
        errorText.style.display = "block";
    }
    else {
        document.getElementById("type-error").style.display = "none";
    }
    if (image == undefined) {
        validData = false;
        var errorText = document.getElementById("image-error");
        errorText.innerHTML = "Missing Data: Please enter the main image of the product.";
        errorText.style.display = "block";
    }
    else {
        document.getElementById("image-error").style.display = "none";
    }
    if (age == "none") {
        validData = false;
        var errorText = document.getElementById("age-error");
        errorText.innerHTML = "Missing Data: Please enter the age of the product.";
        errorText.style.display = "block";
    }
    else {
        document.getElementById("age-error").style.display = "none";
    }

    return validData;
}

function addOfferEntry() {
    var brand = document.getElementById('input-brand').value;
    var name = document.getElementById('input-name').value;
    var currency = document.getElementById('input-price-cur').value;
    var price = document.getElementById('input-price-num').value;
    var type = document.getElementById('input-type').value;
    var image = document.getElementById('main-img').files[0];
    var description = document.getElementById('input-desc').value;
    var age = document.getElementById('input-age').value;
    var gallery = [];
    for (i = 1, k = 0; i <= 10; i++) {
        if (!freeImgs[i]) {
            gallery[k++] = document.getElementById(`gallery-input${i}`).files[0];
        }
    }
    var validData = validateData(name, price, currency, type, image, age);
    if (!validData)
        return;

    var data = new FormData();

    data.append('brand', brand);
    data.append('name', name);
    data.append('currency', currency);
    data.append('price', price);
    data.append('type', type);
    data.append('image', image);
    data.append('description', description);
    data.append('age', age);
    for (i = 0; i <= gallery.length - 1; i++) {
        data.append(`gallery${i}`, gallery[i]);
    }

    var resultBox = document.getElementById("result-box");
    $.ajax({
        url: '/OfferManagement/AddEntry',
        data: data,
        processData: false,
        contentType: false,
        type: "POST",
        success: function (data) {
            resultBox.style.display = "inline-block";
        },
        error: function (data) {
            alert(data.statusText);
        }
    });
}