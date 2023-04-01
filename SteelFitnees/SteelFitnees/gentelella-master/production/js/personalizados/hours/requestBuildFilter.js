function requestBuildFilter() {    
    var select = document.getElementById("filter")
    var value = select.value
    var text = select.options[select.selectedIndex].innerText; //El texto de la opción seleccionada
    request(buildFilterBySlc, 'Handlers/filterByController.aspx?filterByValue=' + value+'&action=filterBy');

    document.getElementById("filterByLbl").innerHTML = text;
}