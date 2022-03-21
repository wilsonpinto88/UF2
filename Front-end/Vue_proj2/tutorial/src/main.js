import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";

// Import the functions you need from the SDKs you need
// import { initializeApp } from "firebase/firebase-app";
import firebase from "firebase";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: "AIzaSyA1me5zOER4M_L-0kjol0GnkFrW0mva1LQ",
  authDomain: "testing-5c7cf.firebaseapp.com",
  projectId: "testing-5c7cf",
  storageBucket: "testing-5c7cf.appspot.com",
  messagingSenderId: "807609636635",
  appId: "1:807609636635:web:7925e4ac993485671f65be",
  measurementId: "G-4M3QVSBJBM",
};

firebase.initializeApp(firebaseConfig);

const app = createApp(App);

app.use(router);

app.mount("#app");
