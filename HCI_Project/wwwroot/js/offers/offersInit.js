for (var i = 4; true; i++) {
    var card = document.getElementById(`ad-card${i}`);
    if (card == undefined)
        break;

    card.style.width = "0px";
    card.style.display = "none";
    card.style.margin = "0px";
}