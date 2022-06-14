function searchDetailed() {
    var brand = document.getElementById("input-brand").value;
    var name = document.getElementById("input-name").value;
    var type = document.getElementById("input-type").value;
    var priceFrom = document.getElementById("input-price-from").value;
    var priceTo = document.getElementById("input-price-to").value;
    var priceCurrency = document.getElementById("input-price-cur").value;

    var data = '?';
    if (brand != undefined && brand != "") {
        data += `Brand=${brand}&`;
    }
    if (name != undefined && name != "") {
        data += `Name=${name}&`;
    }
    if (type != undefined && type != "") {
        data += `TypeString=${type}&`;
    }
    if (priceFrom != undefined && priceFrom != "") {
        data += `PriceFrom=${priceFrom}&`;
    }
    if (priceTo != undefined && priceTo != "") {
        data += `PriceTo=${priceTo}&`;
    }
    if (priceCurrency != undefined && priceCurrency != "") {
        data += `CurrencyString=${priceCurrency}&`;
    }

    data = data.replace(/\&+$/g, "");

    location.href = '/Home/OffersSearch' + data;
}