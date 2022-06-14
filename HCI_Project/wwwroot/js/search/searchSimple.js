function searchSimple() {
    var searchBar = document.getElementById('search-bar');
    var value = searchBar.value;

    location.href = '/Home/OffersSearch?Name=' + value;
}