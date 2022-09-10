function delimiter(arr, del) {
    return arr.join(del);
}

console.log(delimiter(
    ['One',
        'Two',
        'Three',
        'Four',
        'Five'],
    '-'
));

console.log(delimiter(
    ['How about no?',
        'I',
        'will',
        'not',
        'do',
        'it!'],
    '_'
));