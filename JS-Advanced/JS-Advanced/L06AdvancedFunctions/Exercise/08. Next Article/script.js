function getArticleGenerator(articles) {
    let index = 0;
    let div = document.getElementById('content');

    return function showArticle(){
        if (index >= articles.length){
            return;
        }

        let article = document.createElement('article');
        article.textContent = articles[index++];

        div.appendChild(article);
    }
}
