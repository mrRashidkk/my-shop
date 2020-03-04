var app = new Vue({
    el: '#app',
    data: {
        username: "",
        password: ""
    },
    methods: {
        createUser() {
            axios.post('/Users/CreateManager/', { username: this.username, password: this.password })
                .then(res => {
                    console.log(res);
                })
                .catch(err => {
                    console.log(err);
                });                
        }        
    },
    mounted() {
        //TODO: get all users
    }
})