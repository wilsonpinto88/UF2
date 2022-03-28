<template>
  <div class="gallery__box">
    <h1>Gallery</h1>
    <div class="destinations">
      <router-link
        v-for="destination in destinations"
        :key="destination.id"
        :to="destination.slug"
      >
        <h2 style="margin-left: 80px">{{ destination.name }}</h2>
        <div class="flex-container">
          <div class="gallery">
            <a href="/images/${destination.image[0]}" target="_blank">
              <img
                :src="`/images/${destination.image[0]}`"
                :alt="destination.description[0]"
              />
            </a>
            <p>{{ destination.description[0] }}</p>
          </div>
        </div>
        <div class="flex-container">
          <div class="gallery">
            <a href="/images/${destination.image[1]}">
              <img
                :src="`/images/${destination.image[1]}`"
                :alt="destination.description[1]"
              />
            </a>
            <p>{{ destination.description[1] }}</p>
          </div>
        </div>
        <div class="flex-container">
          <div class="gallery">
            <a href="/images/${destination.image[2]}">
              <img
                :src="`/images/${destination.image[2]}`"
                :alt="destination.description[2]"
              />
            </a>
            <p>{{ destination.description[2] }}</p>
          </div>
        </div>
      </router-link>
    </div>
  </div>
</template>

<script scoped>
import sourceData from "@/data.json";
export default {
  data() {
    return {
      destinations: sourceData.destinations,
    };
  },
};
</script>

<style scoped>
div.gallery {
  justify-content: left;
}

div.destinations {
  display: flex;
  justify-content: space-around;
}

img {
  width: 600px;
  height: 200px;
}

.flex-container {
  padding: 70px;
  gap: 100px 300px;
}

.flex-container {
  height: 400px;
  overflow: hidden;
}

.flex-container img {
  transition: transform 0.5s ease;
}

.flex-container:hover img {
  transform: scale(1.5);
}
</style>
