﻿function update() {
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
        
    } else {
        var id = $("#save").val();
        var formData = new FormData(document.getElementById("form1"));
        formData.append('id', id)
        catalogosAddUpdateDelete('update', formData)
        document.getElementById("labelMsjAction").innerText = "Agregar horario"
        document.getElementById("save").value = "";        
    }
    onkeyupNoSelectInSlc("days")
    onkeyupNoSelectInSlc("branches")
    form.classList.add('was-validated')   
}