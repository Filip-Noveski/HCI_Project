freeImgs = [];
for (i = 1; i <= 10; i++)
    freeImgs[i] = true;

function addImage() {
    var galleryImgIndex = 0;
    while (!freeImgs[++galleryImgIndex])
        if (galleryImgIndex > 10) return;

    var file = document.getElementById(`gallery-input${galleryImgIndex}`);
    file.click();
}

function imageOnchange(index) {
    var file = document.getElementById(`gallery-input${index}`);
    freeImgs[index] = false;
    document.getElementById(`img-path${index}`).style.display = 'block';
    document.getElementById(`img-path-text${index}`).innerHTML = file.value;
}