function generateReport() {
    let properties = document.querySelectorAll('tr th input');
    let columns = document.querySelectorAll('tbody tr');
    let result = [];

    for (let c = 0; c < columns.length; c++){
        let columnsProperties = columns[c].children;
        let obj = {};

        for(let x = 0; x < properties.length; x++){
            let currentProp = properties[x];

            if (!currentProp.checked){
                continue;
            }

            let propName = currentProp.name;
            obj[propName] = columnsProperties[x].textContent;
        }

        result.push(obj);
    }

    document.getElementById('output').value = JSON.stringify(result);
}
