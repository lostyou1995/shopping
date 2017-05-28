
    function fullname()
    {
        var name = document.getElementById("customer_Fullname").value;
        document.getElementById("fullname").innerHTML = "";
        if (name == "")
        {
            document.getElementById("fullname").innerHTML = "không được để trống";
        } 
    }
function address() {
    var name = document.getElementById("customer_Address").value;
    document.getElementById("address").innerHTML = "";
    if (name == "") {
        document.getElementById("address").innerHTML = "không được để trống";
    }
}
function phone() {
    var name = document.getElementById("customer_Phone").value;
    document.getElementById("phone").innerHTML = "";
    if (name == "") {
        document.getElementById("phone").innerHTML = "không được để trống ";
    }else if(name.length<10 || name.length>11)
    {
        document.getElementById("phone").innerHTML = "số điện thoại không hợp lệ";
    }
}
function email() {
    var name = document.getElementById("customer_Email").value;
    document.getElementById("email").innerHTML = "";
    if (name == "") {
        document.getElementById("email").innerHTML = "không được để trống";
    } else {
        document.getElementById("btnSubmit").disabled = false;
    }
}
