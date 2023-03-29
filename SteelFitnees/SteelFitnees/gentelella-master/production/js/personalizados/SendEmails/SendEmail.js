function send() {
    var form = document.getElementById("form1");
    if (!form.checkValidity()) {
        event.preventDefault()
        event.stopPropagation()
        onkeyupInputEmtyy('asunto');
        onkeyupInputEmtyy('info');
    } else {
        Swal.fire({
            title: '¿Estas seguro de tus datos?',
            text: '',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: 'Darkgreen',
            cancelButtonColor: 'blue',
            confirmButtonText: '¡ Correcto !',
            cancelButtonText: 'Regresar'
        }).then((result) => {
            if (result.isConfirmed) {
                var formData = new FormData(document.getElementById("form1"));
                sendAjax(formData);
                document.getElementById("form1").reset();
            }
        })
    }
    onkeyupInputEmtyy('asunto');
    onkeyupInputEmtyy('info');
    form.classList.add('was-validated')
}