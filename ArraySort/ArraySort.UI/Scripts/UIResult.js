var DataGridResult = {
    Index: function (result, route, data) {
        CallServices(result, route, data);
    },
    Convert: function (result) {
        let dta = eval(result.textArea);
        
        let tblbody = document.getElementById('tblbody');

        for (let i = 0; i < dta.length; i++) {
            let tr = document.createElement('tr');
            
            for (let j = 0; j < dta[i].length; j++) {
                let td = document.createElement('td');
                let tn = document.createTextNode(dta[i][j]);
                td.appendChild(tn);
                tr.appendChild(td);
            }
            tblbody.appendChild(tr);
        }
        
    },
};