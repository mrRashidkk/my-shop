var app = new Vue({
    el: '#app',
    data: {
        objectIndex: 0,
        editing: false,
        loading: false,
        products: [],
        image: "",
        productModel: {
            id: 0,
            name: "Product name",
            category: "Shoes",
            description: "Product description",
            value: 1.99
        }
    },
    computed: {
        imageName: function () {
            if (this.image != null && this.image != "") {
                return this.image.name;
            }
        }
    },
    methods: {
        handleFileUpload() {
            this.image = this.$refs.image.files[0];
        },
        getProduct(id) {
            this.loading = true;
            axios.get('/products/' + id)
                .then(res => {
                    console.log(res);
                    var product = res.data;
                    this.productModel = {
                        id: product.id,
                        name: product.name,
                        category: product.category,
                        description: product.description,
                        value: product.value
                    }
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                })
        },
        getProducts() {
            this.loading = true;
            axios.get('/products')
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
        createProduct() {
            this.loading = true;

            var formData = new FormData();
            formData.append("name", this.productModel.name);
            formData.append("category", this.productModel.category);
            formData.append("description", this.productModel.description);
            formData.append("value", this.productModel.value);
            formData.append("image", this.image);

            axios.post('/products', formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            })
                .then(res => {
                    console.log(res);
                    this.products.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                    this.editing = false;
                })
        },
        updateProduct() {
            this.loading = true;
            axios.put('/products', this.productModel)
                .then(res => {
                    console.log(res);
                    this.products.splice(this.objectIndex, 1, res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                    this.editing = false;
                })
        },
        editProduct(id, index) {
            this.objectIndex = index;
            this.getProduct(id);
            this.editing = true;
        },
        deleteProduct(id, index) {
            this.loading = true;
            axios.delete('/products/' + id)
                .then(res => {
                    console.log(res);
                    this.products.splice(index, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                })
        },
        newProduct() {
            this.editing = true;
            this.productModel.id = 0;
        },
        cancel() {
            this.editing = false;
        }
    },    
    mounted() {
        this.getProducts();
    }
});