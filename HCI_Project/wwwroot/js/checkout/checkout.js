function addCartItemsToCheckout() {
    var items = localStorage["cart-items"];
    if (items == undefined) {
        items = "";
    }

    var data = new FormData();
    data.append("itemIds", items);

    $.ajax({
        url: "/Partial/CheckoutItems",
        type: "POST",
        async: false,
        data: data,
        processData: false,
        contentType: false,
        success: function (result) {
            document.getElementById("checkout-items").innerHTML = result;
        }
    });
}

function addItemToCheckout(itemId) {
    var data = new FormData();
    data.append("itemIds", itemId);

    $.ajax({
        url: "/Partial/CheckoutItems",
        type: "POST",
        async: false,
        data: data,
        processData: false,
        contentType: false,
        success: function (result) {
            document.getElementById("checkout-items").innerHTML = result;
        }
    });
}