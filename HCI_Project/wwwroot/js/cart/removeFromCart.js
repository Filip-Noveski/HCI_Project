function removeFromCart(itemId, containerIndex) {
    var container = document.getElementById(`item${containerIndex}`);
    container.style.maxHeight = "0px";
    delay(500);
    container.style.display = "none";
    var ret = localStorage["cart-items"].replace(`${itemId}|`, '');
    if (ret == localStorage["cart-items"]) {
        ret = localStorage["cart-items"].replace(`${itemId}`, '');
    }

    localStorage["cart-items"] = ret;
}

function delay(time) {
    return new Promise((resolve) => {
        setTimeout(() => resolve(), time);
    });
}