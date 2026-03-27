
let _url = '/luckynumber';
_url = '';

$(document).ready(function () {
    GetAllPrize();
    GetCustomerAward();
})


//Sự kiện click mở form đăng ký
function onOpenModal() {
    $('.Prize-ID').val(0);
    $('#modalPrize').modal('show');
}


//Sự kiện get danh sách Lịch sử mượn
function GetAllPrize() {

    let data = {
        year: $('#year').val(),
        luckynumber: $('#luckynumber').val(),
        keyword: $('#keyword').val() || "",
    }

    //console.log(data);

    $.ajax({
        url: _url + '/Prize/GetAll',
        type: 'GET',
        dataType: 'json',
        data: data,
        contentType: 'application/json',
        success: function (response) {
            //console.log(response);
            let html = '';
            if (response.status == 1) {
                //LoadDataTable(response.data);

                $.each(response.data, function (key, item) {
                    html += `<tr class="align-middle">
                            <td data-label="Action" class="text-center">
                                <button class="btn btn-info" type="button" title="Sửa" onclick="onEdit(${item.ID});">
                                    <i class="fa-solid fa-pen-to-square"></i>
                                </button>
                                <button class="btn btn-danger" type="button" title="Xoá" onclick="DeletePrize(${item.ID},'${item.LuckyNumber}');">
                                    <i class="fa-solid fa-trash"></i>
                                </button>
                            </td>
                            <td data-label="ID" class="text-center">${item.LuckyNumber}</td>
                            <td data-label="Tên quà">${item.PrizeName}</td>
                        </tr>`;
                });

                $($('#tblPrize').find('tbody')).html(html);
            } else {
                Swal.fire({
                    title: "Thông báo",
                    text: response.message,
                    icon: "info"
                });
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


function GetCustomerAward() {

    let data = {
        luckynumber: $('#luckynumber').val(),
        keyword: $('#keyword').val() || "",
    }

    //console.log(data);

    $.ajax({
        url: _url + '/Home/GetAllCustomerAward',
        type: 'GET',
        dataType: 'json',
        data: data,
        contentType: 'application/json',
        success: function (response) {
            //console.log(response);
            if (response.status == 1) {

                LoadDataAward(response.data);
            } else {
                Swal.fire({
                    title: "Thông báo",
                    text: response.message,
                    icon: "info"
                });
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

//Sự kiện click sửa đăng ký mượn
function onEdit(id) {
    $.ajax({
        url: _url + '/Prize/GetByID',
        type: 'GET',
        dataType: 'json',
        data: {
            id: id
        },
        contentType: 'application/json',
        success: function (response) {
            //console.log('response: ', response);
            if (response.status == 1) {
                $('.Prize-ID').val(response.data.ID);
                $('.Prize-LuckyNumber').val(response.data.LuckyNumber);
                $('.Prize-PrizeName').val(response.data.PrizeName);

                $('#modalPrize').modal('show');
            } else {
                Swal.fire({
                    title: "Thông báo",
                    text: response.message,
                    icon: "info"
                });
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


//Sự kiện xoá đăng ký mượn
function DeletePrize(id, luckyNumber) {
    Swal.fire({
        title: "Thông báo",
        html: `Bạn có chắc muốn xoá quà có ID [${luckyNumber}] không?`,
        icon: "question",
        showCancelButton: true,
        confirmButtonColor: "#3659cd",
        cancelButtonColor: "#c74115",
        confirmButtonText: "Có",
        cancelButtonText: "Không",
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: _url + '/Prize/Delete',
                type: 'GET',
                dataType: 'json',
                data: {
                    id: id
                },
                contentType: 'application/json',
                success: function (response) {
                    //console.log('response: ', response);
                    if (response.status == 1) {
                        GetAllPrize();
                    } else {
                        Swal.fire({
                            title: "Thông báo",
                            text: response.message,
                            icon: "info"
                        });
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
    });
}


//Sự kiện Đăng ký mượn
function SaveData() {
    let obj = {
        ID: parseInt($('.Prize-ID').val()) || 0,
        PrizeName: $('.Prize-PrizeName').val(),
        LuckyNumber: $('.Prize-LuckyNumber').val(),
    }

    //console.log(listProducts);

    $.ajax({
        url: _url + '/Prize/SaveData',
        type: 'POST',
        dataType: 'json',
        data: JSON.stringify(obj),
        contentType: 'application/json',
        success: function (response) {
            console.log('response: ', response);
            //Swal.fire(response.message);
            if (parseInt(response.status) == 1) {
                //$('#modalHistoryProductRTC').modal('hide');
                $('.Prize-ID').val(0);
                $('.Prize-LuckyNumber').val(response.data.LuckyNumber + 1);
                $('.Prize-PrizeName').val('');
                $('.Prize-PrizeName').focus();
                GetAllPrize();
            } else {
                Swal.fire({
                    title: "Thông báo",
                    text: response.message,
                    icon: "info"
                });
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


//Load data to datatable
function LoadDataTable(dataSource) {

    let _table = new Tabulator('#tbl_data_Prize', {
        data: dataSource,
        layout: "fitColumns",
        //rowContextMenu: rowMenu,
        maxHeight: "100%",
        //groupBy: ["TypeText"],
        columnDefaults: {
            vertAlign: "middle", headerHozAlign: "center", headerWordWrap: true, hozAlign: "center"
        },
        //rowHeader: {
        //    headerSort: false, resizable: false, frozen: true, headerHozAlign: "center", hozAlign: "center", formatter: "rowSelection", titleFormatter: "rowSelection", width: 50,
        //    cellClick: function (e, cell) {
        //        cell.getRow().toggleSelect();
        //    }
        //},
        columns: [
            {
                title: "",
                field: "ID",
                //width: 100,
                headerSort: false,
                frozen: true,
                formatter: function (cell, formatterParams) {
                    var rowData = cell.getRow()._row.data;
                    let htmlAction = `<button class="btn btn-info" type="button" title="Sửa" onclick="onEdit(${rowData.ID});">
                                        <i class="fa-solid fa-pen-to-square"></i>
                                    </button>
                                    <button class="btn btn-danger mx-1" type="button" title="Xoá" onclick="DeletePrize(${rowData.ID},'${rowData.LuckyNumber}');">
                                        <i class="fa-solid fa-trash"></i>
                                    </button>`;


                    if (cell.getValue() <= 0) htmlAction = '';
                    return htmlAction;
                },
                //hozAlign: "left",
                download: false

            },
            {
                title: "ID",
                field: "LuckyNumber",
                width: 100,
                //formatter: "textarea",
                //hozAlign: "left",
            },

            {
                title: "Tên quà",
                field: "PrizeName",
                //width: 150,
                formatter: "textarea",
                hozAlign: "left",
                bottomCalc: "count",
                bottomCalcFormatterParams: { thousand: "," }
            },
        ],
    });
}



function LoadDataAward(dataSource) {

    let _table = new Tabulator('#tbl_data_Award', {
        data: dataSource,
        layout: "fitColumns",
        //rowContextMenu: rowMenu,
        maxHeight: "100%",
        //groupBy: ["TypeText"],
        columnDefaults: {
            vertAlign: "middle", headerHozAlign: "center", headerWordWrap: true, hozAlign: "center"
        },
        //rowHeader: {
        //    headerSort: false, resizable: false, frozen: true, headerHozAlign: "center", hozAlign: "center", formatter: "rowSelection", titleFormatter: "rowSelection", width: 50,
        //    cellClick: function (e, cell) {
        //        cell.getRow().toggleSelect();
        //    }
        //},
        columns: [
            //{
            //    title: "",
            //    field: "ID",
            //    //width: 100,
            //    headerSort: false,
            //    frozen: true,
            //    formatter: function (cell, formatterParams) {
            //        var rowData = cell.getRow()._row.data;
            //        let htmlAction = `<button class="btn btn-info" type="button" title="Sửa" onclick="onEdit(${rowData.ID});">
            //                            <i class="fa-solid fa-pen-to-square"></i>
            //                        </button>
            //                        <button class="btn btn-danger mx-1" type="button" title="Xoá" onclick="DeletePrize(${rowData.ID},'${rowData.LuckyNumber}');">
            //                            <i class="fa-solid fa-trash"></i>
            //                        </button>`;


            //        if (cell.getValue() <= 0) htmlAction = '';
            //        return htmlAction;
            //    },
            //    //hozAlign: "left",
            //    download: false

            //},




            {
                title: "ID Khách hàng",
                field: "ID",
                width: 150,
                formatter: "textarea",
                //hozAlign: "left",
                //bottomCalc: "count",
                //bottomCalcFormatterParams: { thousand: "," }
            },

            {
                title: "Number",
                field: "LuckyNumber",
                width: 200,
                //formatter: "textarea",
                //hozAlign: "left",
            },
            {
                title: "Mã quà",
                field: "LuckyNumberPrize",
                width: 200,
                //formatter: "textarea",
                //hozAlign: "left",
            },
            {
                title: "Tên khách hàng",
                field: "FullName",
                //width: 150,
                formatter: "textarea",
                hozAlign: "left",
                bottomCalc: "count",
                bottomCalcFormatterParams: { thousand: "," }
            },

            {
                title: "Số điện thoại",
                field: "PhoneNumber",
                //width: 100,
                formatter: "textarea",
                hozAlign: "left",
            },
            {
                title: "Công ty",
                field: "Company",
                //width: 100,
                formatter: "textarea",
                hozAlign: "left",
            },
        ],
    });
}