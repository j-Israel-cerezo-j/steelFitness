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
            text: 'Tu correo electronico y contraseña deben de ser correctos, de no ser asi no se podra mandar el correo a los destinatarios',
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
                document.getElementById("image").setAttribute("src", "");
                document.getElementById("msjImagenCargadaAutomatica").innerHTML = ""
                onkeyupInputEmtyy('asunto');
                onkeyupInputEmtyy('senderMail');
                onkeyupInputEmtyy('senderPassword');
                onkeyupInputEmtyy('formFile');
                onkeyupInputEmtyy('info');
            }
        })
    }  
    form.classList.add('was-validated')
}