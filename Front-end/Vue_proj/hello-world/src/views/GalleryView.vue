<template>
    <!-- Navbar Section -->
    <nav class="navbar">
      <div class="navbar__container">
        <a href="/" id="navbar__logo">
          EXTREME E<i class="fab fa-think-peaks"></i>RTH</a
        >
        <div class="navbar__toggle" id="mobile-menu">
          <span class="bar"></span>
          <span class="bar"></span>
          <span class="bar"></span>
        </div>
        <ul class="navbar__menu">
          <li class="navbar__item">
            <a href="/" class="navbar__links"> Home </a>
          </li>
          <li class="navbar__item">
            <a href="/gallery" class="navbar__links"> Gallery </a>
          </li>
          <li class="navbar__item">
            <a href="/about" class="navbar__links"> About </a>
          </li>
          <li class="navbar__btn">
            <a href="/login" class="button"> Sign Up </a>
          </li>
        </ul>
      </div>
    </nav>
    <!-- End Navbar Section -->
    <!-- Gallery Section-->
    <div class="gallery">
        <br>
        <br>
        <br>
      <h1>Featured Gallery</h1>
      <div class="gallery__container">
        <div class="gallery__card">
          <h2>Everlasting Storm</h2>
          <p>Catatumbo, Venezuela</p>
        </div>
        <div class="gallery__card">
          <h2>Are you Ready?</h2>
          <p>Take the Leap</p>
        </div>
      </div>
    </div>

</template>
