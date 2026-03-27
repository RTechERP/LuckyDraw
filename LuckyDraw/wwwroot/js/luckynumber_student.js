const delay = 5000;
let interval;

let _url = '/luckynumber';
//_url = '';
//let luckyNumber = 70;
// DisplayLuckyNumber();

$(document).ready(function () {
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
            const randomNumber = Math.floor(Math.random() * 10);
            $('#number_one').text(randomNumber);
            $('#number_two').text(randomNumber);
            $('#number_three').text(randomNumber);

        }, 100); // Hiển thị mỗi 100ms

        // Dùng setTimeout để dừng interval sau 10 giây
        setTimeout(function () {
            clearInterval(interval);

            let luckyNumber = $('#Student_LuckyNumber').val();
            //console.log(luckyNumber);
            while (luckyNumber.length < 3) {
                luckyNumber = `0${luckyNumber}`;
            }

            //console.log(luckyNumber);

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
    $.ajax({
        url: _url + '/Student/GetStudentAward',
        type: 'GET',
        dataType: 'json',
        data: {
            luckyNumber: parseInt($("#Student_LuckyNumber").val())
        },
        contentType: 'application/json',
        success: function (response) {
            //console.log('response: ', response);

            let title = 'Chúc bạn may mắn lần sau!';

            let text = '';
            if (response.status != 0) {
                title = `Chúc mừng ${response.data.FullName} đã trúng giải ${response.data.PrizeName}.`;
                text = 'Vui lòng đến quầy để nhận thưởng. Xin cảm ơn!';

                $('#canvas').css('display', 'block');
                $('.info-award').html(`${title}<br />${text}`);

                $('#img_lucky').css('display', 'block');
                $('#img_nonlucky').css('display', 'none');

                
            } else {
                $('.info-award').html(`${title}<br />${text}`);

                $('#img_nonlucky').css('display', 'block');
                
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