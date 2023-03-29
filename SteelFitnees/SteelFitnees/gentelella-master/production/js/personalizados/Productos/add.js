function addP() {

    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
        onkeyupInputEmtyy('product');
        onkeyupInputEmtyy('description');
        onkeyupInputEmtyy('formFile');
    } else {
        var formData = new FormData(document.getElementById("form1"));
        console.log(formData);
        console.log(document.getElementById("formFile").value);
        catalogosAddUpdateDelete('add', formData)
        $("#resert").click();
    }

    form.classList.add('was-validated')
}