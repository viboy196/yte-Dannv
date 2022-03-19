var comHub = new signalR.HubConnectionBuilder().withUrl("/comHub").build();
var connectionId = "";


comHub.on("onConnected", function (id) {
    connectionId = id;
    Connected();
});

comHub.on("mes", function (mes) {
    alert(mes);
});

comHub.on("addnewTinHieu", function (mes) {
    alert(mes);
});



function khoitao() {
    if ($("#auth_nguoidungid").html() != "") { comHub.start(); }
}

window.onload = khoitao;



//Xử lý thông báo---------------
comHub.on("updateThongBao", function (id) {
   
    $.ajax({
        type: 'POST',
        url: '/nguoidung/_thongbao?id=' + id,
        success: function (result) {
            $('#vtb-'+id).html(result);
            console.log(result);
        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    })
});

comHub.on("updateSoLuongThongBao", function (sl) {
    if (sl > 0) $('#soluongthongbaomoi').html(sl); else $('#soluongthongbaomoi').html("");
});

function tat_thongbao() {
    var md = $('#thongbaoModal');
    md.hide();
    comHub.invoke("tatThongBao");
}

function show_thongbao(st) {
    var md = $('#thongbaoModal');
    md.show();
    $.ajax({
        type: 'POST',
        url: '/nguoidung/_listThongBao?st='+st,
        success: function (result) {
            $('#thongbaoList').html(result);
            console.log(result);
        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    })
}

function xuly_thongbao(idtb, luachon) {
    comHub.invoke("xulyThongBao", idtb, luachon);
}

//Xử lý tín hiệu-----------------------------

comHub.on("themTinHieuCa", function (idca, idtinhieu) {

    
    $.ajax({
        type: 'POST',
        url: '/nguoidung/_tinhieu?id=' + idtinhieu,
        success: function (result) {
            $("#tinhieu").prepend(result);
            console.log(result);
        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    })
    

});
function gui_tinhieu(codelth, idti, idca, nguon) {    
    comHub.invoke("guiTinHieu", codelth, idti, idca, nguon,'');
}

function dangky_roomtructinhieu(idnhanvien, phansu) {
    comHub.invoke("dangkyRoomTrucTinHieu", idnhanvien, phansu);
}
