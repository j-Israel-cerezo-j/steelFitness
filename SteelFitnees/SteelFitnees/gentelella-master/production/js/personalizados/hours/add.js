﻿function addHour() {
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
        onkeyupNoSelectInSlc("days")
        onkeyupNoSelectInSlc("branches")
    } else {
        var formData = new FormData(document.getElementById("form1"));
        catalogosAddUpdateDelete('add', formData)
    }
    form.classList.add('was-validated')    
}