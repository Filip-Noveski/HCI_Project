offersFirst = 0;

function delay(time) {
    return new Promise((resolve) => {
        setTimeout(() => resolve(), time);
    });
}

async function hide(elementId) {
    var element = document.getElementById(elementId);

    element.style.width = '0px';
    await delay(500);
    element.style.display = 'none';
}

async function show(elementId) {
    var element = document.getElementById(elementId);

    element.style.display = 'inline-block';
    element.style.width = '240px';
}

function scrollNext(offersCount, displayedCount) {
    if (offersFirst + displayedCount >= offersCount)
        return;

    hide(`ad-card${offersFirst}`);
    show(`ad-card${offersFirst++ + displayedCount}`);
}

function scrollPrev(displayedCount) {
    if (offersFirst <= 0)
        return;

    hide(`ad-card${--offersFirst + displayedCount}`);
    show(`ad-card${offersFirst}`);
}