function fetchCartItems() {
    var items = localStorage["cart-items"];
    if (items == undefined) {
        items = "";
    }

    var data = new FormData();
    data.append("itemIds", items);

    $.ajax({
        url: "/Partial/CartItems",
        type: "POST",
        async: false,
        data: data,
        processData: false,
        contentType: false,
        success: function (result) {
            document.getElementById("cart-info").innerHTML = result;
        }
    });
}