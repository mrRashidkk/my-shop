var app = new Vue({
    el: '#app',
    data: {
        article: {
            title: "",
            preview: "",
            text: "",
            image: ""
        }
    }, 
    computed: {
        imageName: function () {
            if (this.article.image != null && this.article.image != "") {
                return this.article.image.name;
            }
        }
    },
    methods: {
        handleFileUpload() {            
            this.article.image = this.$refs.image.files[0];
        },
        createArticle() {
            var formData = new FormData();
            formData.append("title", this.article.title);
            formData.append("preview", this.article.preview);
            formData.append("text", this.article.text);
            formData.append("image", this.article.image);
            axios.post('/Article/CreateArticle/', formData,
                {
                    headers: {
                        'Content-Type': 'multipart/form-data'
                    }
                })
                .then(result => {
                    this.article = {
                        title: "",
                        preview: "",
                        text: "",
                        image: ""
                    }
                })
                .catch(err => {
                    console.log(err);
                })
        }        
    }
});