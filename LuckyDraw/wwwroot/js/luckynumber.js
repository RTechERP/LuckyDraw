const delay = 5000;
let interval;

//let luckyNumber = 70;
// DisplayLuckyNumber();

let _url = '/luckynumber';
_url = '';

$(document).ready(function () {

    //$("#exampleModal").modal('show');
    DisplayLuckyNumber();
})
function DisplayLuckyNumber() {

    $('#canvas').css('display', 'none');
    $('#img_lucky').css('display', 'none');
    $('#img_nonlucky').css('display', 'none');

    if (interval) {
        clearInterval(interval);
    }

    //$('#staticBackdrop').css('background-image', 'url()')
    // Tạo interval mới để hiển thị số ngẫu nhiên
    if (true) {
        interval = setInterval(function () {

            const randomNumber1 = Math.floor(Math.random() * 10);
            $('#number_one').text(randomNumber1);

            const randomNumber2 = Math.floor(Math.random() * 10);
            $('#number_two').text(randomNumber2);

            const randomNumber3 = Math.floor(Math.random() * 10);
            $('#number_three').text(randomNumber3);


        }, 100); // Hiển thị mỗi 100ms

        // Dùng setTimeout để dừng interval sau 10 giây
        setTimeout(function () {
            clearInterval(interval);

            let luckyNumber = $('#Customer_LuckyNumber').val();
            //console.log(luckyNumber);
            while (luckyNumber.length < 3) {
                luckyNumber = `0${luckyNumber}`;
            }

            $('#number_one').text(luckyNumber[0]);
            $('#number_two').text(luckyNumber[1]);
            $('#number_three').text(luckyNumber[2]);

            //$('#exampleModal').modal('show');
            GetCustomerAward();

        }, delay); // 10000ms = 10 giây
    } else {

    }

}


//get người trúng thưởng
function GetCustomerAward() {
    console.log('url:', _url + '/Home/GetCustomerAward');
    $.ajax({
        url: _url + '/Home/GetCustomerAward',
        type: 'GET',
        dataType: 'json',
        data: {
            luckyNumber: parseInt($("#Customer_LuckyNumber").val())
        },
        contentType: 'application/json',
        success: function (response) {

            let title = 'Chúc bạn may mắn lần sau!';
            let id = `ID: ${response.data.ID}`;

            let text = '';
            if (response.status != 0) {
                title = `Chúc mừng ${response.data.FullName} đã trúng giải.`;
                text = 'Vui lòng đến quầy để nhận thưởng. Xin cảm ơn!';
                

                $('#canvas').css('display', 'block');
                $('.info-award-id').html(id);
                $('.info-award').html(`${title}<br />${text}`);

                $('#img_lucky').css('display', 'block');
                $('#img_nonlucky').css('display', 'none');

                //Swal.fire({
                //    title: title,
                //    text: text,
                //    width: 600,
                //    padding: "3em",
                //    color: "#000",
                //    background: "url(/congra.jpg) no-repeat center",
                //    //backdrop: `
                //    //    rgba(0,0,123,0.4)
                //    //    url(/congratulations-7600.gif)
                //    //    center
                //    //    no-repeat
                //    //    `
                //});
            } else {
                $('.info-award-id').html(id);
                $('.info-award').html(`${title}<br />${text}`);

                $('#img_nonlucky').css('display', 'block');
                //Swal.fire({
                //    title: "Thông báo",
                //    text: response.message,
                //    icon: "info"
                //});
            }


        },

        error: function (err) {
            Swal.fire({
                title: "Thông báo",
                text: err.responseText,
                icon: "error"
            });
        }
    });
}