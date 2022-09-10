function solve() {
    Array.from(document.querySelectorAll('section ul li div p')).forEach(x => x.addEventListener('click', onclick));
    let sections = document.querySelectorAll('section');
    let counter = 0;
    let rightAnswers = 0;

    function onclick(event) {
        let targetText = event.target.textContent;

        if (targetText === 'onclick' || targetText === 'JSON.stringify()' || targetText === 'A programming API for HTML and XML documents') {
            rightAnswers++;
        }

        sections[counter].style.display = 'none';

        if (counter == 2) {
            let resultDiv = document.getElementById('results');
            resultDiv.style.display = 'block';

            let resultHeading = document.getElementById('results').children[0].children[0];

            if (rightAnswers === 3) {
                resultHeading.textContent = 'You are recognized as top JavaScript fan!';
            } else {
                resultHeading.textContent = `You have ${rightAnswers} right answers`;
            }

            return;
        }

        sections[counter + 1].style.display = 'block';
        counter++;
    }
}
