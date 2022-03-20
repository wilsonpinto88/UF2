<template>
  <body>
    <div class="main">  	
      <input type="checkbox" id="chk" aria-hidden="true">

        <div class="signup">
          <form>
            <label for="chk" aria-hidden="true">Sign up</label>
            <input type="text" name="txt" placeholder="User name" required="">
            <input type="email" name="email" placeholder="Email" required="">
            <input type="password" name="pswd" placeholder="Password" required="">
            <button>Sign up</button>
          </form>
        </div>

        <div class="login">
          <form>
            <label for="chk" aria-hidden="true">Login</label>
            <input type="email" name="email" placeholder="Email" required="">
            <input type="password" name="pswd" placeholder="Password" required="">
            <button>Login</button>
          </form>
        </div>
    </div>
  </body>
</template>
<style>
  @import "@/assets/css/login.css";
  /* @import url("slide navbar style.css"); */
  @import url("https://fonts.googleapis.com/css2?family=Jost:wght@500&display=swap");
</style>


