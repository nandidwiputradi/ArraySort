function callRoute(controllerName, actionName, data) {

    let route = {
        controllerName: controllerName,
        actionName: actionName
    };

    let rawData = {
        data: ''
    };

    if (data != null) {
        //rawData = Object.assign(route, data);
        rawData = {
            data: data
        };
    }

    const routeData = JSON.stringify(route);
    const paramData = JSON.stringify(rawData);
    let scriptResult = controllerName + 'Result.' + actionName;
    let scriptAction = controllerName + 'Action.' + actionName + '(' + scriptResult + ', ' + routeData + ', ' + paramData + ');';

    eval(scriptAction);
}

function CallServices(result, route, data) {
    UIServices.API(route, data).then(function (response) {
        result(response);
    });
}

function callScript(controllerName, actionName, data) {

    if (actionName == 'Index') {
        document.getElementById('content').innerHTML = '';
        let href = '/ArraySort/Views/' + controllerName + 'View.cshtml';

        $('#content').load(href, function (response, status, xhr) {
            callRoute(controllerName, actionName, data);
        });              
    }
    else {
        callRoute(controllerName, actionName, data);
    }
}

function UIServices() { };

UIServices.prototype.API = function (route, data) {
    return $.when(
        $.ajax({
            type: 'POST',
            url: '/ArraySort/API/' + route.controllerName + '/' + route.actionName,
            crossDomain: true,
            data: data,
            async: true,
            dataType: 'json',
            contentType: 'application/x-www-form-urlencoded',
            xhrFields: { withCredentials: true, cors: false },
            success: function (response) {
                return response;
            },
            error: function (xhr, ajaxOptions, thrownError) {
                let result = {
                    xhr: xhr,
                    ajaxOptions: ajaxOptions,
                    thrownError: thrownError
                };
                console.log('UIServices', result);
                return result;
            }
        })
    );
};