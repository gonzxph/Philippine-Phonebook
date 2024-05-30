$().ready(function () {
    $('.btn-del').click(function () {
        var row = $(this).closest('tr')
        var id = row.find('.prod-id').text()
        alert("Are you sure you want to delete this phonebook?")
        $.ajax({
            url: '../Home/DeletePhonebook',
            type: 'POST',
            data: {prod_id: id},
            success: function (data) {
                if (data) {
                    location.reload();
                }
            }
        })

    })//delete end
})//start end