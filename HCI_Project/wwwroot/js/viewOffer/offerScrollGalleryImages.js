firstGalleryImage = -1;

function delay(time) {
    return new Promise((resolve) => {
        setTimeout(() => resolve(), time);
    });
}

async function hideGallery(elementId) {
    var element = document.getElementById(elementId);

    element.style.width = '0px';
    await delay(500);
    element.style.display = 'none';
}

async function showGallery(elementId) {
    var element = document.getElementById(elementId);

    element.style.display = 'inline-block';
    element.style.width = '79.8px';
}

function scrollNextGallery(galleryCount, displayedCount) {
    if (firstGalleryImage + displayedCount >= galleryCount)
        return;

    if (firstGalleryImage == -1) {
        hideGallery("main-img");
    }
    else {
        hideGallery(`img-gallery${firstGalleryImage}`);
    }
    showGallery(`img-gallery${firstGalleryImage++ + displayedCount}`);
}

function scrollPrevGallery(displayedCount) {
    if (firstGalleryImage <= -1)
        return;

    hideGallery(`img-gallery${--firstGalleryImage + displayedCount}`);
    if (firstGalleryImage == -1) {
        showGallery("main-img");
    }
    else {
        showGallery(`img-gallery${firstGalleryImage}`);
    }
}