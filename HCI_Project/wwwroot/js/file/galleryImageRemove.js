function imgRemove(index) {
    if (index > 10 || index < 1)
        return;

    var file = document.getElementById(`gallery-input${index}`);
    file.value = "";
    document.getElementById(`img-path${index}`).style.display = 'none';
    document.getElementById(`img-path-text${index}`).innerHTML = "";
    freeImgs[index] = true;
}