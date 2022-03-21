<template>
  <body>
    <div class="main">
      <input type="checkbox" id="chk" aria-hidden="true" />

      <div class="signup">
        <label for="chk" aria-hidden="true">Sign up</label>
        <input type="text" placeholder="Email" v-model="email" />
        <input type="password" placeholder="Password" v-model="password" />
        <button @click="register">Signup</button>
      </div>

      <div class="login">
        <form>
          <label for="chk" aria-hidden="true">Login</label>
          <input type="text" placeholder="Email" v-model="email" />
          <input type="password" placeholder="Password" v-model="password" />
          <p v-if="errMsg">{{ errMsg }}</p>
          <button @click="checkin">Login</button>
        </form>
      </div>
    </div>
  </body>
</template>

<script setup>
/* eslint-disable */
import { ref } from "vue";
// import {
//   getAuth,
//   createUserWithEmailAndPassword,
//   signInWithEmailAndPassword,
// } from "firebase/firebase-auth";
import firebase from 'firebase';

import { useRouter } from "vue-router";
const email = ref("");
const password = ref("");
const errMsg = ref(); // ERROR MESSAGE
const router = useRouter(); // get a reference to our vue router

const register = () => {
  // need .value because ref()
  firebase
    .auth()
    .createUserWithEmailAndPassword(email.value, password.value)
    .then((data) => {
      console.log("Successfully registered!");
      router.push("/"); // redirect to the home
    })
    .catch((error) => {
      console.log(error.code);
      alert(error.message);
    });
};

const checkin = () => {
  // need .value because ref()
  firebase
    .auth()
    .signInWithEmailAndPassword(email.value, password.value)
    .then((data) => {
      console.log("Successfully logged in!");
      router.push("/"); // redirect to the home
    })
    .catch((error) => {
      console.log(error.code);
      switch (error.code) {
        case "auth/invalid-email":
          errMsg.value = "Invalid email";
          break;
        case "auth/user-not-found":
          errMsg.value = "No account with that email was found";
          break;
        case "auth/wrong-password":
          errMsg.value = "Incorrect password";
          break;
        default:
          errMsg.value = "Email or password was incorrect";
          break;
      }
    });
};

// import userValidate from "@vuelidate/core";
// import { required, email, minLength } from "@vuelidate/validators";
// import firebase from "firebase";

// export default {
//   name: "LoginView",
//   components: {},
//   data() {
//     return {
//       v$: userValidate(),
//       email: "",
//       password: ""
//     };
//   },
//   validations() {
//     return {
//       email: { required, email },
//       password: { required, minLength: minLength(6) }
//     };
//   },
//   methods: {
//     submitSignUpForm() {
//       this.v$.$validate(); // check all inputs
//       if (!this.v$.$error) {
//         alert("Form successfully submitted.");
//         this.signupRequest();
//         this.$router.push("/");
//       } else {
//         alert("Form failed validation");
//       }
//     },
//     signupRequest() {
//       firebase
//         .auth()
//         .createUserWithEmailAndPassword(this.email, this.password)
//         .then(() => {
//           // Signed in
//           this.successMessage = "Sign up Successfully.";
//           // ...
//         })
//         .catch((error) => {
//           let errorResponse = JSON.parse(error.message);
//           this.errorMessage = errorResponse.error.message;
//           // ..
//         });
//     }
//   }
// };
</script>

<style>
.main {
  width: 350px;
  height: 500px;
  background: red;
  overflow: hidden;
  background: url("https://doc-08-2c-docs.googleusercontent.com/docs/securesc/68c90smiglihng9534mvqmq1946dmis5/fo0picsp1nhiucmc0l25s29respgpr4j/1631524275000/03522360960922298374/03522360960922298374/1Sx0jhdpEpnNIydS4rnN4kHSJtU1EyWka?e=view&authuser=0&nonce=gcrocepgbb17m&user=03522360960922298374&hash=tfhgbs86ka6divo3llbvp93mg4csvb38")
    no-repeat center/ cover;
  border-radius: 10px;
  box-shadow: 5px 20px 50px #000;
}
#chk {
  display: none;
}
.signup {
  position: relative;
  width: 100%;
  height: 100%;
}
label {
  color: #2c3e50;
  font-size: 2.3em;
  justify-content: center;
  display: flex;
  margin: 60px;
  font-weight: bold;
  cursor: pointer;
  transition: 0.5s ease-in-out;
}
input {
  width: 60%;
  height: 20px;
  background: #e0dede;
  justify-content: center;
  display: flex;
  margin: 20px auto;
  padding: 10px;
  border: none;
  outline: none;
  border-radius: 5px;
}
button {
  width: 60%;
  height: 40px;
  margin: 10px auto;
  justify-content: center;
  display: block;
  color: #fff;
  background: #131c25;
  font-size: 1em;
  font-weight: bold;
  margin-top: 20px;
  outline: none;
  border: none;
  border-radius: 5px;
  transition: 0.2s ease-in;
  cursor: pointer;
}
button:hover {
  background: #4981b9;
}
.login {
  height: 460px;
  background: #2c3e50;
  border-radius: 60% / 10%;
  transform: translateY(-180px);
  transition: 0.8s ease-in-out;
}
.login label {
  color: #fff;
  transform: scale(0.6);
}

#chk:checked ~ .login {
  transform: translateY(-500px);
}
#chk:checked ~ .login label {
  transform: scale(1);
}
#chk:checked ~ .signup label {
  transform: scale(0.6);
}
</style>
