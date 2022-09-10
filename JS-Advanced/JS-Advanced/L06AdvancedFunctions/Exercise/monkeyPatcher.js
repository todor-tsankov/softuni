solve = (() => {
    const operations = {
        upvote: (obj) => obj.upvotes++,
        downvote: (obj) => obj.downvotes++,
        score: (obj) => {
            let upvotes = obj.upvotes;
            let downvotes = obj.downvotes;

            let totalVotes = upvotes + downvotes;

            let rating = 'new';

            if (upvotes > totalVotes * 0.66 && totalVotes > 10) {
                rating = 'hot';
            } else if ((upvotes > 100 || downvotes > 100) && upvotes >= downvotes) {
                rating = 'controversial';
            } else if (upvotes < downvotes) {
                rating = 'unpopular';
            }

            if (totalVotes > 50) {
                let numberToBeAdded = Math.ceil(Math.max(upvotes, downvotes) * 0.25);

                upvotes += numberToBeAdded;
                downvotes += numberToBeAdded;
            }


            return [upvotes, downvotes, upvotes - downvotes, rating];
        },
    };

    return {
        call: (object, argument) => operations[argument](object),
    };
})();

let result = solve();

let forumPost = {
    id: '1',
    author: 'pesho',
    content: 'hi guys',
    upvotes: 0,
    downvotes: 0
};

result.call(forumPost, 'upvote');
let expected = [1, 0, 1, 'new'];
console.log(result.call(forumPost, 'score'));


