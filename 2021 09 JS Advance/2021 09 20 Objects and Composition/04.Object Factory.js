function objectFactory(library, orders){
    const objects = [];

    for (let order of orders){
        const object = Object.assign({}, order.template);

        for(let part of order.parts) {
            object[part] = library[part];
        }

        objects.push(object)
    }

    return objects;
}

function objectFactory(library, orders){
    return orders
    .map( order => Object.assign({}, 
                order.template, 
                order.parts
                .reduce((a, c) => 
                    Object.assign(a, {[c]: library[c]}), {})));
}