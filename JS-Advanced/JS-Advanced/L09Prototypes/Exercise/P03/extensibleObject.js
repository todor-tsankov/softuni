function solve() {
    const object = {};
    const prototype = {};


    object.extend = function (template) {
        for (let prop in template) {
            let propertyValue = template[prop];

            if (typeof propertyValue === 'function') {
                prototype[prop] = propertyValue;
            } else {
                object[prop] = propertyValue;
            }
        }
    }

    Object.setPrototypeOf(object, prototype);


    return object;
}

let obj = solve();
let template = {
    extensionMethod: function () {},
    extensionProperty: 'someString'
};

obj.extend(template);
let a;

