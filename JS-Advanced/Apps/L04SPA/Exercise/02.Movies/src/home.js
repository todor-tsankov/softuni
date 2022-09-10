import createMovieCard from './cardHelper.js';

const moviesUrl = 'http://localhost:3030/data/movies';

let parent;
let home;
let addBtn;
let cardsContainer;
let heading;

export function setupHome(parentTarget, homeTarget, addBtnTarget, cardsTarget, headingTarget) {
    parent = parentTarget;
    home = homeTarget;
    addBtn = addBtnTarget;
    cardsContainer = cardsTarget;
    heading = headingTarget;
}

export async function showHome() {
    parent.innerHTML = ''
    parent.appendChild(home);
    parent.appendChild(heading);

    if(sessionStorage.getItem('accessToken')){
        parent.appendChild(addBtn);
    }

    const response = await fetch(moviesUrl);
    const movies = await response.json();

    const cardList = cardsContainer.querySelector('#cardsList');
    cardList.innerHTML = '';

    movies.forEach(x => cardList.appendChild(createMovieCard(x._id, x.title, x.img)));

    parent.appendChild(cardsContainer);
}