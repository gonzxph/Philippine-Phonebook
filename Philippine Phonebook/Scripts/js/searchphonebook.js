$(document).ready(function () {
    $('#btnSearch').click(function () {
        var searchQuery = $('#searchQuery').val();
        if (searchQuery !== '') {
            window.location.href = '@Url.Action("Index", "Home")?searchQuery=' + searchQuery;
        } else {
            window.location.href = '@Url.Action("Index", "Home")';
        }
    });
});