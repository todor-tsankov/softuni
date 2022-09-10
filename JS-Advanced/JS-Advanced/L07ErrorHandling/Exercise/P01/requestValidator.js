function validate(httpRequest) {
    const {method, uri, version, message} = httpRequest;

    validateMethod(method);
    validateURI(uri);
    validateVersion(version);
    validateMassage(message);

    return httpRequest;

    function validateMethod(method) {
        const methods = ['GET', 'POST', 'DELETE', 'CONNECT'];

        if (!methods.includes(method) || method === undefined) {
            throw new Error('Invalid request header: Invalid Method');
        }
    }

    function validateURI(uri) {
        if (uri === '*') {
            return;
        }

        const regex = /^[\w\n.]+$/;

        if (!regex.test(uri) || uri === undefined){
            throw new Error('Invalid request header: Invalid URI');
        }
    }

    function validateVersion(version){
        const validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

        if (!validVersions.includes(version)){
            throw new Error('Invalid request header: Invalid Version');
        }
    }

    function validateMassage(message){
        if(message === ''){
            return;
        }

        const regex = /^[^<>\\&'"]+$/;

        if(!regex.test(message) || message === undefined){
            throw new Error('Invalid request header: Invalid Message');
        }
    }
}

validate({
        method: 'GET',
        uri: 'svn.public.catalog',
        version: 'HTTP/1.1',
        message: ''
    }
);