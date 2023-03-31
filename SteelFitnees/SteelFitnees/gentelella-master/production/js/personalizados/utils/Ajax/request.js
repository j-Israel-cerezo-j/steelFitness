function request(callback, url) {
    Swal.fire({
        title: 'Cargando...',
        showConfirmButton: false
    })
    const table = fetch(url);
    table
        .then((resp) => resp.json())
        .then((resp) => {
            swal.close()
            callback(resp.data.recoverData);
        });
}
