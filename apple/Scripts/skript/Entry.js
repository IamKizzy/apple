$('#btnEntry').click(function () {
    var txtMv = $('#txtMv').val();
    var txtPlate = $('#txtPlate').val();
    var txtMotorNum = $('#txtMotorNum').val();
    var txtSer = $('#txtSer').val();
    var txtOR = $('#txtOR').val();
    var txtCoc = $('#txtCoc').val();
    var txtPol = $('#txtPol').val();
    var txtRec = $('#txtRec').val();
    var txtAddress = $('#txtAddress').val();
    var txtPlace = $('#txtPlace').val();
    var make = $('#make').val();
    var txtSeries = $('#txtSeries').val();
    var txtBody = $('#txtBody').val();
    var txtModelNo = $('#txtModelNo').val();
    var txtOth = $('#txtOth').val();
    var txtDoc1 = $('#txtDoc1').val();
    var txtLgt = $('#txtLgt').val();
    var txtPrem = $('#txtPrem').val();
    var txtDoc2 = $('#txtDoc2').val();
    var txtLg = $('#txtLg').val();
    var datepicker1 = $('#datepicker1').val();
    var datepicker2 = $('#datepicker2').val();
    var datepicker3 = $('#datepicker3').val();
    var txtColor = $('#txtColor').val();
    var txtDay = $('#txtDay').val();
    var txtMonth = $('#txtMonth').val();
    var txtYear = $('#txtYear').val();
    var txtMisc = $('#txtMisc').val();
    var txtTotal = $('#txtTotal').val();
    var txtSum = $('#txtSum').val();
    var txttranstyp = $('#txttranstyp').val();


    if (txtMv == "" || txtMv == null) {
        alert("MV FILE No. required");
        return false;
    }
    if (txtPlate == "" || txtPlate == null) {
        alert("PLATE No. required");
        return false;
    }
    if (txtMotorNum == "" || txtMotorNum == null) {
        alert("USERNAME required");
        return false;
    }
    if (txtSer == "" || txtSer == null) {
        alert("PASSWORD required");
        return false;
    }
    if (txtOR == "" || txtOR == null) {
        alert("PASSWORD required");
        return false;
    }
    if (txtCoc == "" || txtCoc == null) {
        alert(" COC required");
        return false;
    }
    if (txtPol == "" || txtPol  == null) {
        alert("Policy No. required");
        return false;
    }
    if (txtRec == "" || txtRec == null) {
        alert("RECEIVED FROM required");
        return false;
    }
    if (txtAddress == "" || txtAddress == null) {
        alert("Address required");
        return false;
    }
    if (txtPlace == "" || txtPlace == null) {
        alert("Place Issue required");
        return false;
    }
    if (make == "" || make == null) {
        alert("MAKE required");
        return false;
    }
    if (txtSeries == "" || txtSeries == null) {
        alert("SERIES required");
        return false;
    }
    if (txtBody == "" || txtBody == null) {
        alert("TYPE of Body required");
        return false;
    }
    if (txtModelNo == "" || txtModelNo == null) {
        alert("Model No. required");
        return false;
    }
    if (txtOth == "" || txtOth == null) {
        alert("Other required");
        return false;
    }
    if (txtDoc1 == "" || txtDoc1 == null) {
        alert("Docs Stamp required");
        return false;
    }
    if (txtLgt == "" || txtLgt == null) {
        alert("LGT required");
        return false;
    }
    if (txtPrem == "" || txtPrem == null) {
        alert("Premium Sales required");
        return false;
    }
    if (txtDoc2 == "" || txtDoc2 == null) {
        alert("Docs Stamp required");
        return false;
    }
    if (txtLg == "" || txtLg == null) {
        alert("Lgtax required");
        return false;
    }
    if (datepicker1 == "" || datepicker1 == null) {
        alert(" Date required");
        return false;
    }
    if (datepicker2 == "" || datepicker2 == null) {
        alert(" Date required");
        return false;
    }
    if (datepicker3 == "" || datepicker3 == null) {
        alert(" Date required");
        return false;
    }
    if (txtColor == "" || txtColor == null) {
        alert("Color required");
        return false;
    }
    if (txtDay == "" || txtDay == null) {
        alert("Day required");
        return false;
    }
    if (txtMonth == "" || txtMonth == null) {
        alert("Month required");
        return false;
    }
    if (txtYear == "" || txtYear == null) {
        alert("Year required");
        return false;
    }
    if (txtMisc == "" || txtMisc == null) {
        alert("MISC required");
        return false;
    }
    if (txtTotal == "" || txtTotal == null) {
        alert("TOTAL required");
        return false;
    }
    if (txtSum == "" || txtSum == null) {
        alert("Sum of Pesos required");
        return false;
    }
    if (txttranstyp == "" || txttranstyp == null) {
        alert("TRANSACTION TYPE required");
        return false;
    }
    

    //ajax
    $.post("../Home/DetailsEntry", { mvfl: txtMv, pltno: txtPlate, mtrno: txtMotorNum, srlno: txtSer, ofclrcpt: txtOR, cocno: txtCoc, plcyno: txtPol, rcvdfrm: txtRec, address: txtAddress, plcissue: txtPlace, make: make, series: txtSeries, bodytyp: txtBody, mdlno: txtModelNo, othrs: txtOth, stamp1: txtDoc1, lgt: txtLgt, premsls: txtPrem, stamp2: txtDoc2, lgtax: txtLg, dtissue: datepicker1, frm: datepicker2, to: datepicker3, clr: txtColor, day: txtDay, mnths: txtMonth, year: txtYear, misc: txtMisc, total: txtTotal, sumpesos: txtSum, transtype: txttranstyp }, function (res) {
        if (res[0].mess != 1) {
            window.location.href = "../Home/History";
        }
        else {
            alert('Invalid Credentials!');
        }
    });

});

$('#btnView').click(function () {

});