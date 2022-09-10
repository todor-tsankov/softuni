function extract(id) {
    const text = document.getElementById(id).textContent;
    const regex = /\((.+?)\)/g;
    const matches = [...text.matchAll(regex)];

    return matches.map(x => x[1] + ';').join(' ');
}