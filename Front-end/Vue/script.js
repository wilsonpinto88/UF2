new Vue({
    el: '#app',
    data:{
        message: 'Wilson',
        fuzz: 'whiskey on the rocks!',
        checkedNames: [],
        picked: [],
        selected: '',
        count: 0,
        parentMessage: 'Parent',
        items:[
            {message: 'Foo'},
            {message: 'Bar'}
        ],
        contdown: [5, 4, 3, 2, 1],
        fruits: ["apple", "banana", "orange", "mango", "grapes"],
        profile: {
            name: 'Tushar',
            age: '31',
            degree: 'Masters',
            position: 'Full Stack Developer'
        },
        greeting: '',
        name: ''
    },
    methods:{
        increment() {
            this.count++;
        },
        greet: function(greeting){
            this.greeting = greeting + ", How are you?";
        }
    },
    computed:{
        charcount: function(){
            return this.name.length;
        }
    }
});