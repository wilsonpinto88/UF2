/* Ex 2 */
function myFunction(){
    document.getElementById("my_p").innerHTML="Hello from Javascript!";
    var my_paragraph = document.getElementById("my_p");
    my_paragraph.style.color = "blue";
}

/* Ex 3 */
function alert_me(){
    alert(document.test.boxes.value);
}
/* Ex 4 */
function user_input(){
    var userName = prompt("Type in your name...", "");
    if (userName != null){
        document.getElementById("printUserName").innerHTML = 
        `Hello${userName}! How are you?`;
    }
}
/* Ex 5 */
function mathThis(obj){
    obj.value = eval(obj.value);
}

/* EX 6 */
$("button").click(function(){
    alert("OK Clicked");
});

/* Ex 7 */
$("#radioSelect").click(function(){
    var favorite= [];
    $.each($("input[name='myRadio']:checked"), function(){
        favorite.push($(this).val());
    });
    alert("The: " + favorite.join(",") + "radio was selected");
});

/*  TPC - Form  */
$("#commentForm").validate();

// Submit Form
$().ready(function(){
    // validate signup form on keyup and submit
    $("#signupForm").validate({
        rules: {
            firstname: "required",
            lastname: "required",
            username: {
                required: true,
                minlength: 2
            },
            password: {
                required: true,
                minlength: 5
            },
            confirmPassword: {
                required: true,
                minlength: 5,
                equalTo: "#password"
            },
            email: {
                required: true,
                email: true
            },
            topic: {
                required: "#newsletter:checked",
                minlength: 2
            },
            agree: "required"
        },
        messages: {
            firstname: "Please enter your firstname",
            lastname: "Please enter your lastname",
            username: {
                required: "Please enter a username",
                minlength: "Your username must consist of at least 2 characters"
            },
            password: {
                required: "Please provide a password",
                minlength: "Your password must be at least 5 characters long"
            },
            confirmPassword: {
                required: "Please provide a password",
                minlength: "Your password must be at least 5 characters long",
                equalTo: "Please enter the same password as above"
            },
            agree: "Please accept our policy",
            topic: "Please select at least two topics"
        }
    });
    // propose username by combining first- and lastname
    $("#username").focus(function() {
        var firstname = $("#firstname").val();
        var lastname = $("#lastname").val();
        if (firstname && lastname && !this.value){
            this.value = firstname + "." + lastname;
        }
    });

    // code to hide topic selection, disable for demo
    var newsletter = $("#newsletter");
    // newsletter topics are optional, hide at first
    var initial = newsletter.is(":checked");
    var topics = $("#newsletterTopics")[initial ? "removeClass" : "addClass"]("hide");
    var topicInputs = topics.find("input").attr("disabled", !initial);
    // show when newsletter is checked
    newsletter.click(function() {
        topics[this.checked ? "removeClass" : "addClass"]("hide");
        topicInputs.attr("disabled", !this.checked);
    });
});
