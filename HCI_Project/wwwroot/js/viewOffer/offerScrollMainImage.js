displayedImg = -1;

function scrollNextImage(imgCount) {
    if (displayedImg >= imgCount - 1)
        return;

    var imgPath = document.getElementById(`img-gallery${++displayedImg}`).style.backgroundImage;
    document.getElementById("full-img0").style.backgroundImage = imgPath;
}

function scrollPrevImage() {
    if (displayedImg <= -1)
        return;

    var imgPath;
    if (--displayedImg == -1) {
        imgPath = document.getElementById(`main-img`).style.backgroundImage;
    }
    else {
        imgPath = document.getElementById(`img-gallery${displayedImg}`).style.backgroundImage;
    }
    document.getElementById("full-img0").style.backgroundImage = imgPath;
}