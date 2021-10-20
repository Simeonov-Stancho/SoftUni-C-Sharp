function solve(obj) {
    const methods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const uriPattern = /^([A-Za-z\d\.]+|\*)$/g;
    const versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    const message = /^([^<>\\&'"]*)$/g;

    if (!methods.includes(obj.method) || !obj.hasOwnProperty('method')) {
        throw new Error('Invalid request header: Invalid Method');
    };

    if (!uriPattern.test(obj.uri) || !obj.hasOwnProperty('uri')) {
        throw new Error('Invalid request header: Invalid URI');
    };

    if (!versions.includes(obj.version) || !obj.hasOwnProperty('version')) {
        throw new Error('Invalid request header: Invalid Version');
    };

    if (!message.test(obj.message) || !obj.hasOwnProperty('message')) {
        throw new Error('Invalid request header: Invalid Message');
    };

    return obj;
}

console.log(solve({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}));

// console.log(solve({
//     method: 'OPTIONS',
//     uri: 'git.master',
//     version: 'HTTP/1.1',
//     message: '-recursive'
// }));

// console.log(solve({
//     method: 'POST',
//     uri: 'home.bash',
//     message: 'rm -rf /*'
// }));

console.log(solve({
    method: 'GET',
  uri: 'svn.public.catalog',
  version: 'HTTP/1.1',
  message: '<'
}));