var infos = new Map([
    ["Item Brand", "Provide the brand i.e. the manufacturer of the item you are offering.<br />Max: 64 characters; Optional"],
    ["Item Name", "Provide the model name of the item you are offering.<br />Max: 256 characters; Required"],
    ["Price", "Provide the price you are selling the item for.<br />Input 1: Currency.<br />Input 2: Price in chosen currency → Max: 12 characters<br />Required"],
    ["Item Type", "Choose the type of computer part you are offering.<br />Required"],
    ["Main Image", "Provide the main image of the item. This image will be displayed on all adverts for the offer as well as the main one when browsing offers.<br />Required"],
    ["Gallery Images", "Provide addional images of the item you are offering. These images will be viewable when browsing offers and viewing this offer.<br />Add an image by clicking on the Add Image button; Remove an image using the Remove button next to the image you want to remove.<br />Max: 10 images; Optional"],
    ["Description", "Provide a description of the item you are offering.<br />Optional"],
    ["Use and age", "Choose the age of the item: New or used for a given amount of time.<br />Required"]
]);

function showInfo(category) {
    var box = document.getElementById("info-box");
    var header = document.getElementById("info-head");
    var text = document.getElementById("info-text");

    box.style.display = "inline-block";
    header.innerHTML = category;
    text.innerHTML = infos.get(category);
}