var app = new Vue({
    el: '#app',
    data: {
        price: 0,
        showPrice: true,
        loading: true
    },
    methods: {
        togglePrice: function () {
            this.showPrice = !this.showPrice;
        },
        getProducts() {
            this.loading = true;
            axios.get('/Admin/products')
                .then(res => {
                    console.log(res);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                })
        }
    },
    computed: {
        formatPrice: function() {
            return "$ " + this.price;
        }
    }
});