function addRemove(commands){
    let arr = [];
    let number = 1;

    for(let command of commands){
        if(command == 'add'){
            arr.push(number);
        } else if(command == 'remove'){
            arr.pop();
        }

        number++;
    }

    if(arr.length == 0){
        return 'Empty';
    }

    return arr.join('\n');
}

console.log(addRemove(['add', 'add', 'add', 'add']));
console.log(addRemove(['add', 'add', 'remove', 'add', 'add']));
console.log(addRemove(['remove', 'remove', 'remove']));