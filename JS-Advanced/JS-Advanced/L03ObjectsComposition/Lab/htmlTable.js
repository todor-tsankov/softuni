function solve(input) {
    let parse = JSON.parse(input)
    let str = '<table>\n'
    str += `   <tr>${Object.keys(parse[0]).map(x => `<th>${replace(x)}</th>`).join('')}</tr>\n`
    parse.forEach( x => { str += `   <tr>${Object.values(x).map( x => `<td>${replace(x)}</td>`).join('')}</tr>\n` })
    str += '</table>'
    function replace(str) {
        return String(str)
            .replace(/&/g , '&amp;')
            .replace(/</g , "&lt;")
            .replace(/>/g , "&gt;")
            .replace(/"/g , "&quot;")
            .replace(/'/g , "&#39;")
    }
    return str
}

solve('[{"Name":"Sta&mat","Score":5.5},{"Name":"Rumen","Score":6}]');
solve('[{"Name":"Pesho","Score":4," Grade":8},{"Name":"Gosho","Score":5," Grade":8},{"Name":"Angel","Score":5.50," Grade":10}]');
