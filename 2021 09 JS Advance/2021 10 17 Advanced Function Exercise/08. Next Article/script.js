function getArticleGenerator(articles) {
    return () => {
        if(articles.length != 0) {
            let div = document.getElementById('content');
            let articleEl = document.createElement('article');

            articleEl.textContent = articles.shift();
            div.appendChild(articleEl);
        }
    }
}
