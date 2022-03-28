<template>
  <div class="divWraper">
    <div id="nav">
      <router-link to="/">Home</router-link> |
      <router-link to="/gallery">Gallery</router-link> |
      <router-link to="/about">About</router-link> |
      <span v-if="isLoggedIn"
        >>
        <button @click="signOut">Logout</button>
      </span>
      <span v-else>
        <router-link to="/login">Login</router-link>
      </span>
      <!-- <router-link to="/login">Login</router-link> -->
      <!-- <button @click="handleSignOut" v-if="isLoggedIn">Sign out</button> -->
    </div>
    <div class="container">
      <router-view></router-view>
    </div>
    <footer class="footer">
      <div class="footer-left">
        <p class="footer-links">
          <a class="link-1" href="/">Home</a>
          <a href="/gallery">Gallery</a>
          <a href="/about">About</a>
          <a href="/login">Login</a>
          <a id="admin__hiden" href="/admin">Admin</a>
        </p>
        <p>Extreme Earth &copy; 2022</p>
      </div>
    </footer>
  </div>
</template>

<script setup>
// /* eslint-disable */

// import { onMounted, ref } from "vue";
// import { getAuth, onAuthStateChanged, signOut } from "firebase/firebase-auth";
// import { useRouter } from "vue-router";

// const router = useRouter();
// const isLoggedIn = ref(false);

// let auth;
// onMounted(() => {
//   auth = getAuth();
//   onAuthStateChanged(auth, (user) => {
//     if (user) {
//       isLoggedIn.value = true;
//     } else {
//       isLoggedIn.value = false;
//     }
//   });
// });

// const handleSignOut = () => {
//   signOut(auth).then(() => {
//     router.push("/");
//   });
// };
</script>

<style>
*,
*:before,
*:after {
  box-sizing: border-box;
}
body {
  display: grid;
  align-items: center;
  padding: 0;
  margin: 0;
  margin-top: 100px;
  background: #eee;
}
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}

a,
a:visited {
  color: #2c3e50;
}
.container {
  margin: 0 200px auto;
  max-width: 960px;
}

/* Home */
.home img {
  max-width: 230px;
}
.home .destinations {
  display: grid;
  justify-content: space-between;
}
/* Gallery */
.gallery img {
  max-width: 300px;
  height: auto;
  margin-left: 10px;
}
.gallery .destinations {
  display: grid;
  justify-content: space-between;
}

/* Navigation */
#nav {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  margin-top: 0;
  padding: 30px;
  background: #2c3e50;
  color: white;
  display: flex;
  align-items: center;
  border-bottom: 5px solid #4e6c71;
  z-index: 2;
}
#nav a {
  display: inline-block;
  margin-right: 20px;
  color: white;
  opacity: 0.7;
  transition: 0.2 ease color;
}
#nav a.router-link-active,
#nav a:hover {
  opacity: 1;
}
#logo {
  font-weight: bold;
  font-size: 1.5rem;
  opacity: 1 !important;
}

a {
  text-decoration: none;
  font-weight: bold;
}

/* Destination Details */
.destination-details {
  display: flex;
  gap: 30px;
  align-items: center;
}
.destination-details img {
  border-radius: 4px;
  border: 3px solid white;
  box-shadow: 0 0 10px 0 rgba(0, 0, 0, 0.2);
}

/*Modal Overlay*/
.modal-overlay:before {
  content: "";
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: rgba(0, 0, 0, 0.7);
  z-index: 3;
}
.modal-overlay-content {
  border-radius: 3px;
  position: fixed;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  z-index: 3;
  min-width: 300px;
  max-width: 800px;
  background: white;
  padding: 15px;
  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.3);
}
.close {
  position: absolute;
  top: 0px;
  right: 10px;
  padding: 10px;
  font-size: 1.4rem;
}

.go-back {
  display: inline-block;
  margin-bottom: 15px;
}
/* Form */
.form {
  display: flex;
  flex-direction: column;
  max-width: 400px;
  margin: 0 auto;
}

.input {
  border: 1px solid gray;
  padding: 10px;
  margin-bottom: 20px;
  border-radius: 5px;
}

.btn {
  background-color: #2c3e50;
  color: white;
  padding: 10px;
  border-radius: 5px;
  border: none;
}
/* Footer */
.footer {
  position: relative;
  padding: 45px 50px;
  bottom: 0;
  width: 100%;
  background-color: #2c3e50;
  box-shadow: 0 1px 1px 0 rgba(0, 0, 0, 0.12);
  box-sizing: border-box;
  text-align: left;
  font: normal 16px;
}

.footer .footer-left p {
  color: #8f9296;
  font-size: 14px;
  margin: 0;
}
/* Footer links */

.footer p.footer-links {
  font-size: 18px;
  font-weight: bold;
  color: #ffffff;
  margin: 0 0 10px;
  padding: 0;
  transition: ease 0.25s;
}

.footer p.footer-links a {
  display: inline-block;
  line-height: 1.8;
  text-decoration: none;
  color: inherit;
  transition: ease 0.25s;
}

.footer .footer-links a:before {
  content: " · ";
  font-size: 20px;
  left: 0;
  color: #fff;
  display: inline-block;
  padding-right: 5px;
}

.footer .footer-links .link-1:before {
  content: none;
}

.footer .footer-right {
  float: right;
  margin-top: 6px;
  max-width: 180px;
}

.footer .footer-right a {
  display: inline-block;
  width: 35px;
  height: 35px;
  background-color: #33383b;
  border-radius: 2px;
  font-size: 20px;
  color: #ffffff;
  text-align: center;
  line-height: 35px;
  margin-left: 3px;
  transition: all 0.25s;
}

.footer .footer-right a:hover {
  transform: scale(1.1);
  -webkit-transform: scale(1.1);
}

.footer p.footer-links a:hover {
  text-decoration: underline;
}

#admin__hiden {
  color: #2c3e50;
}

#admin__hiden:hover {
  color: #fff;
}
</style>
