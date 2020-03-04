var app = new Vue({
    el: '#app',
    data: {
        loading: false,
        category: "Shoes",
        search: "",
        products: []
    },
    methods: {        
        getProducts() {
            this.loading = true;
            axios.get(`/Index?handler=Products&category=${this.category}&search=${this.search}`)
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                })
        },
        getClass(product) {
            let cssClass = 'notification is-paddingless has-text-centered';
            if (product.stockCount == 0) {
                cssClass += ' is-danger';
            }
            else if (product.stockCount <= 10 && product.stockCount > 0) {
                cssClass += ' is-warning';
            }
            return cssClass;
        }
    },
    mounted() {
        this.getProducts();
    }
});