function addToCart(itemId) {
    if (localStorage["cart-items"] == undefined || localStorage["cart-items"].length == 0) {
        localStorage["cart-items"] = itemId;
        fetchCartItems();
        return;
    }

    localStorage["cart-items"] += `|${itemId}`;
    fetchCartItems();
}