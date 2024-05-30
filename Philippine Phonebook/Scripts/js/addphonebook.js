$().ready(function () {

    $('#btnAddPhonebook').click(function () {
        var formData = new FormData();
        formData.append('name', $('#name').val())
        formData.append('area_code', $('#area_code').val())
        formData.append('phone_number', $('#phoneno').val())
        formData.append('mobile_number', $('#mobileno').val())
        formData.append('house_number', $('#houseno').val())
        formData.append('street', $('#street').val())
        formData.append('city', $('#city').val())
        formData.append('province', $('#province').val())
        formData.append('zip_code', $('#zcode').val())
        formData.append('email', $('#email').val())
        formData.append('status', $('#status').val())

        $.ajax({
            url: '../Home/AddPhonebook',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (phonebook) {
                alert('Phonebook Successfully Created')
                $('#addPhonebookModal').modal('hide');
                location.reload();
            },
            error: function(){
                alert('Error!')
            }
        })

    })

})//ready end