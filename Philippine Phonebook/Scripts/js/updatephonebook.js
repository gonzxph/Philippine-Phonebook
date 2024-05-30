$().ready(function () {

    $('.btn-up').click(function () {
        var row = $(this).closest('tr')
        var id = row.find('.prod-id').text()

        $.ajax({
            url: '../Home/GetPhonebook',
            type: 'GET',
            data: { id: id },
            success: function (data) {
                if (data) {
                    $('#upid').val(data.id);
                    $('#upname').val(data.name);
                    $('#uparea_code').val(data.area_code);
                    $('#upphoneno').val(data.phone_number);
                    $('#upmobileno').val(data.mobile_number);
                    $('#uphouseno').val(data.house_number);
                    $('#upstatus').val(data.status);
                    $('#upstreet').val(data.street);
                    $('#upcity').val(data.city);
                    $('#upprovince').val(data.province);
                    $('#upzcode').val(data.zip_code);
                    $('#upemail').val(data.email);
                }
            }
        })

    })//button update end

    $('#btnUpdate').click(function () {
        var data = new FormData();
        data.append('id', $('#upid').val());
        data.append('name', $('#upname').val());
        data.append('area_code', $('#uparea_code').val());
        data.append('phoneno', $('#upphoneno').val());
        data.append('mobileno', $('#upmobileno').val());
        data.append('houseno', $('#uphouseno').val());
        data.append('status', $('#upstatus').val());
        data.append('street', $('#upstreet').val());
        data.append('city', $('#upcity').val());
        data.append('province', $('#upprovince').val());
        data.append('zcode', $('#upzcode').val());
        data.append('email', $('#upemail').val());

        $.ajax({
            url: '../Home/ModifyPhonebook',
            type: 'POST',
            data: data,
            processData: false,
            contentType: false,
            success: function (data) {
                alert('Product updated successfully.');
                $('#updateModal').modal('hide');
                location.reload()
            }
        })

    })//modal update button end

})//start end

