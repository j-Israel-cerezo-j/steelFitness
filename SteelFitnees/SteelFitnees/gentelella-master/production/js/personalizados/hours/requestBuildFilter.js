function requestBuildFilter() {    
    var select = document.getElementById("filter")
    var value = select.value
    if (value == "fullRecords") {
        document.getElementById("filterByLbl").innerHTML = 'Filtrar por..';
        buildTableOnload()
        
    } else {        
        request(buildFilterBySlc, 'Handlers/filterByController.aspx?filterByValue=' + value + '&action=filterBy');
    }   
    var text = select.options[select.selectedIndex].innerText; //El texto de la opción seleccionada
    document.getElementById("filterByLbl").innerHTML = text;
}