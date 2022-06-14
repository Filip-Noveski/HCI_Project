function takeDownOffer(offerId) {
    var data = new FormData();
    data.append("offer-id", offerId);
    var resultBox = document.getElementById("result-box");
    var promptBox = document.getElementById("prompt-box");

    $.ajax({
        url: '/OfferManagement/RemoveEntry',
        data: data,
        processData: false,
        contentType: false,
        type: "POST",
        success: function (data) {
            resultBox.style.display = "inline-block";
            promptBox.style.display = "none";
        },
        error: function (data) {
            alert(data.statusText);
        }
    });
}