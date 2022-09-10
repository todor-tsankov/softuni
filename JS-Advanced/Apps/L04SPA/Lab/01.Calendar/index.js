const body = document.querySelector('body');
const years = document.getElementById('years');

const months = [...document.querySelectorAll('.monthCalendar')].reduce((a, c) => {
    a[c.id] = c;
    return a;
}, {});

const days = [...document.querySelectorAll('.daysCalendar')].reduce((a, c) => {
    a[c.id] = c
    return a;
}, {});

const monthsDict = {'Jan': 1, 'Feb': 2, 'Mar': 3, 'Apr': 4, 'May': 5, 'Jun': 6, 'Jul': 7, 'Aug': 8, 'Sept': 9, 'Oct': 10, 'Nov': 11, 'Dec': 12,};
show(years);

let pre = [years];

body.addEventListener('click', (e) => {
    const target = e.target;

    if (target.nodeName === 'CAPTION' && pre.length > 1) {
        pre.pop();

        show(pre[pre.length - 1]);
        return;
    }

    if (target.classList.contains('date') || target.classList.contains('day')) {
        const value = target.textContent.trim();
        let next;

        if (pre.length === 1) {
            const id = 'year-' + value;
            next = months[id];
        } else if (pre.length === 2) {
            const id = `month-${pre[1].id.replace('year-', '')}-${monthsDict[value]}`;
            next = days[id];
        } else {
            return;
        }

        show(next);
        pre.push(next);
    }
});

function show(el) {
    body.innerHTML = '';
    body.appendChild(el);
}
