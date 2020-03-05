var app = new Vue({
    el: '#app',
    data: {
        selectedArticle: null,
        articles: []
    },
    methods: {
        getImagePath(article) {
            return `/images/articles/${article.imageName}`
        },
        getArticles() {
            axios.get('/Article')
                .then(res => {
                    console.log(res);
                    this.articles = res.data;
                    this.selectArticle(this.articles[0]);
                })
                .catch(err => {
                    console.log(err);
                })                
        },
        selectArticle(article) {
            this.selectedArticle = article;
        }
    },
    mounted() {
        this.getArticles();
    }
});