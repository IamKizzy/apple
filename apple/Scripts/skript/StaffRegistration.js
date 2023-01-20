$('#btnSaveUser').click(function () {
    var lastname = $('#lastname').val();
    var firstname = $('#firstname').val();
    var usr = $('#usr').val();
    var pwd = $('#pwd').val();
    var cpwd = $('#cpwd').val();

    if (firstname == "" || firstname == null) {
        alert("FIRSTNAME required");
        return false;
    }
    if (lastname == "" || lastname == null) {
        alert("LASTNAME required");
        return false;
    }
    if (usr == "" || usr == null) {
        alert("USERNAME required");
        return false;
    }
    if (pwd == "" || pwd == null) {
        alert("PASSWORD required");
        return false;
    }
    if (cpwd == "" || cpwd == null) {
        alert("PASSWORD required");
        return false;
    }

    //ajax
    $.post("../Home/StaffRegistration", { lname: lastname, fname: firstname, addr: address, cntct: contactno, email: email, usr: usr, pwd: pwd }, function (res) {
        if (res[0].mess != 1) {
            window.location.href = "../Home/Login";
        }
        else {
            alert('Invalid Credentials!');
        }
    });

});

$('#btnView').click(function () {

});