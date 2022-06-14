function swapImg(imgId, imgPath) {
    var img = document.getElementById(`full-img${imgId}`);
    img.style.backgroundImage = `url('${imgPath}')`;
}