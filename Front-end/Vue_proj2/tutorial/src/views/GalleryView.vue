<template>
  <div class="gallery">
    <h1>Gallery</h1>
    <div class="destinations">
      <router-link
        v-for="destination in destinations"
        :key="destination.id"
        :to="destination.slug"
      >
        <h2>{{ destination.name }}</h2>
        <img
          :src="`/images/${destination.image[0]}`"
          :alt="destination.description[0]"
        />
        <p style="color: black">{{ destinations.description }}</p>
        <img
          :src="`/images/${destination.image[1]}`"
          :alt="destination.description[1]"
        />
        <img
          :src="`/images/${destination.image[2]}`"
          :alt="destination.description[2]"
        />
      </router-link>
    </div>
  </div>
</template>

<script>
import sourceData from "@/data.json";
export default {
  data() {
    return {
      destinations: sourceData.destinations,
    };
  },
};
</script>
