function Init() {
    callScript('DataGrid', 'Index');
}
function RunClick() {
    document.getElementById('tblbody').innerHTML = '';
    let textArea = document.getElementById('textArea').value;
    let dataToVar = eval(textArea);
    let jsonData = JSON.stringify(dataToVar);

    let data = {
        textArea: jsonData,
        otherData: 'value'
    };
    callScript('DataGrid', 'Convert', data);
}