function SwitchTableOnkeyup(catalogo, json, jsonOnkeyp = true) {
    switch (catalogo) {               
        case 'horas':
            buildTableHours(json, jsonOnkeyp);
            break;          
        //case 'trabajadores':

        //    const statusUsersPromise = fetch('Handlers/requestDataStatusUserHandler.aspx?User=trabajadores');
        //    statusUsersPromise
        //        .then((resp) => resp.json())
        //        .then((resp) => {
        //            if (typeWorker == "Divisional") {
        //                buildTableEmploysDivisionales(json, resp.data.jsonStatusUsers, jsonOnkeyp)
        //            } else if (typeWorker == "General") {
        //                buildTableEmploysGenerales(json, resp.data.jsonStatusUsers, jsonOnkeyp);
        //            }
        //        });
        //    break;        
    }
}