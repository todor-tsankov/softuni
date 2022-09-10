class ChristmasMovies {
    constructor() {
        this.movieCollection = [];
        this.watched = {};
        this.actors = [];
    }

    buyMovie(movieName, actors) {
        let movie = this.movieCollection.find(m => movieName === m.name);
        let uniqueActors = new Set(actors);

        if (movie === undefined) {
            this.movieCollection.push({name: movieName, actors: [...uniqueActors]});
            let output = [];
            [...uniqueActors].map(actor => output.push(actor));
            return `You just got ${movieName} to your collection in which ${output.join(', ')} are taking part!`;
        } else {
            throw new Error(`You already own ${movieName} in your collection!`);
        }
    }

    discardMovie(movieName) {
        let filtered = this.movieCollection.filter(x => x.name === movieName)

        if (filtered.length === 0) {
            throw new Error(`${movieName} is not at your collection!`);
        }
        let index = this.movieCollection.findIndex(m => m.name === movieName);
        this.movieCollection.splice(index, 1);
        let {name, _} = filtered[0];
        if (this.watched.hasOwnProperty(name)) {
            delete this.watched[name];
            return `You just threw away ${name}!`;
        } else {
            throw new Error(`${movieName} is not watched!`);
        }

    }

    watchMovie(movieName) {
        let movie = this.movieCollection.find(m => movieName === m.name);
        if (movie) {
            if (!this.watched.hasOwnProperty(movie.name)) {
                this.watched[movie.name] = 1;
            } else {
                this.watched[movie.name]++;
            }
        } else {
            throw new Error('No such movie in your collection!');
        }
    }

    favouriteMovie() {
        let favourite = Object.entries(this.watched).sort((a, b) => b[1] - a[1]);
        if (favourite.length > 0) {
            return `Your favourite movie is ${favourite[0][0]} and you have watched it ${favourite[0][1]} times!`;
        } else {
            throw new Error('You have not watched a movie yet this year!');
        }
    }

    mostStarredActor() {
        let mostStarred = {};
        if (this.movieCollection.length > 0) {
            this.movieCollection.forEach(el => {
                let {_, actors} = el;
                actors.forEach(actor => {
                    if (mostStarred.hasOwnProperty(actor)) {
                        mostStarred[actor]++;
                    } else {
                        mostStarred[actor] = 1;
                    }
                })
            });
            let theActor = Object.entries(mostStarred).sort((a, b) => b[1] - a[1]);
            return `The most starred actor is ${theActor[0][0]} and starred in ${theActor[0][1]} movies!`;
        } else {
            throw new Error('You have not watched a movie yet this year!')
        }
    }
}

const {expect} = require('chai');

describe('', () => {
    it('buy movie throws 1', () => {
        let movies = new ChristmasMovies();
        movies.buyMovie('1', []);

        expect(() => movies.buyMovie('1', [])).to.throw(Error, 'You already own 1 in your collection!');
    });

    it('buy movie throws 2', () => {
        let movies = new ChristmasMovies();
        movies.buyMovie('1', ['1']);
        movies.buyMovie('2', ['1']);
        movies.buyMovie('3', ['1']);

        expect(() => movies.buyMovie('2', [])).to.throw(Error, 'You already own 2 in your collection!');
    });

    it('buy movie with', () => {
        let movies = new ChristmasMovies();
        let first = movies.buyMovie('1', ['1']);
        let second = movies.buyMovie('2', ['1', '2', '1', '3', '4', '4']);
        let firstMovie = movies.movieCollection[0];
        let secondMovie = movies.movieCollection[1];

        expect(first).to.equal('You just got 1 to your collection in which 1 are taking part!');
        expect(second).to.equal('You just got 2 to your collection in which 1, 2, 3, 4 are taking part!');

        expect(firstMovie.name).to.equal('1');
        expect(firstMovie.actors[0]).to.equal('1');

        expect(secondMovie.name).to.equal('2');
        expect(secondMovie.actors[0]).to.equal('1');
        expect(secondMovie.actors[1]).to.equal('2');
        expect(secondMovie.actors[2]).to.equal('3');
        expect(secondMovie.actors[3]).to.equal('4');
    });

    it('discard movie throws 1', () => {
        let movies = new ChristmasMovies();
        expect(() => movies.discardMovie('123')).to.throw(Error, '123 is not at your collection!');
    });

    it('discard movie throws 2', () => {
        let movies = new ChristmasMovies();
        movies.buyMovie('1', ['1']);
        movies.buyMovie('2', ['1', '2']);
        movies.buyMovie('3', ['3']);

        expect(() => movies.discardMovie('123')).to.throw(Error, '123 is not at your collection!');
    });

    it('discard movie throws when movie is not watched', () => {
        let movies = new ChristmasMovies();
        movies.buyMovie('1', ['1']);
        movies.buyMovie('2', ['1', '2']);
        movies.buyMovie('3', ['3']);

        expect(() => movies.discardMovie('2')).to.throw(Error, '2 is not watched!');
    });

    it('discard movie', () => {
        let movies = new ChristmasMovies();
        movies.buyMovie('1', ['1']);
        movies.buyMovie('2', ['1', '2']);
        movies.buyMovie('3', ['3']);

        movies.watchMovie('1');
        let result = movies.discardMovie('1');

        expect(result).to.equal('You just threw away 1!');
        expect(movies.watched['1']).to.be.undefined;
    });

    it('watch movie throws 1', () => {
        let movies = new ChristmasMovies();
        expect(() => movies.watchMovie('1')).to.throw(Error, 'No such movie in your collection!');
    });

    it('watch movie throws 2', () => {
        let movies = new ChristmasMovies();
        movies.buyMovie('3', []);
        movies.buyMovie('2', ['1', '2', '3']);

        expect(() => movies.watchMovie('1')).to.throw(Error, 'No such movie in your collection!');
    });

    it('watch movie increases counter', () => {
        let movies = new ChristmasMovies();
        movies.buyMovie('3', []);
        movies.buyMovie('2', ['2']);
        movies.buyMovie('1', ['1', '2', '3']);

        movies.watchMovie('3');
        movies.watchMovie('3');
        movies.watchMovie('2');

        expect(movies.watched['3']).to.equal(2);
        expect(movies.watched['2']).to.equal(1);
        expect(movies.watched['1']).to.equal(undefined);
    });

    it('favourite movie throws 1', () => {
       let movies = new ChristmasMovies();
        movies.buyMovie('3', []);
        movies.buyMovie('2', ['2']);
        movies.buyMovie('1', ['1', '2', '3']);

       expect(() => movies.favouriteMovie()).to.throw(Error, 'You have not watched a movie yet this year!');
    });

    it('favourite movie 1', () => {
        let movies = new ChristmasMovies();
        movies.buyMovie('3', []);
        movies.buyMovie('2', ['2']);
        movies.buyMovie('1', ['1', '2', '3']);

        movies.watchMovie('3');
        movies.watchMovie('3');
        movies.watchMovie('2');
        movies.watchMovie('2');
        movies.watchMovie('2');

        expect(movies.favouriteMovie()).equal('Your favourite movie is 2 and you have watched it 3 times!');
    });

    it('favourite movie 1', () => {
        let movies = new ChristmasMovies();
        movies.buyMovie('3', []);
        movies.buyMovie('2', ['2']);
        movies.buyMovie('1', ['1', '2', '3']);

        movies.watchMovie('1');

        expect(movies.favouriteMovie()).equal('Your favourite movie is 1 and you have watched it 1 times!');
    });

    it('most starred actor throws', () => {
        let movies = new ChristmasMovies();
        expect(() => movies.mostStarredActor()).to.throw(Error, 'You have not watched a movie yet this year!')
    });

    it('most starred actor', () => {
        let movies = new ChristmasMovies();
        movies.buyMovie('1', ['2']);
        movies.buyMovie('2', ['1', '2']);
        movies.buyMovie('3', ['1', '2', '3']);
        movies.buyMovie('4', ['4']);

        expect(movies.mostStarredActor()).to.equal('The most starred actor is 2 and starred in 3 movies!');
    });
});


