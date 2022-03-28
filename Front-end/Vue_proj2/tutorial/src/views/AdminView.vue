<template>
  <div class="admin">
    <form action="/action_page.php">
      <label for="fname">Event</label>
      <input
        type="text"
        id="fname"
        name="firstname"
        placeholder="Type of event.."
      />

      <label for="lname">Destination</label>
      <input
        type="text"
        id="lname"
        name="lastname"
        placeholder="Type in Location.."
      />

      <label for="country">URL</label>
      <input
        type="file"
        id="lname"
        name="lastname"
        placeholder="Upload Photo.."
      />
      <input type="submit" value="Submit" />
    </form>
  </div>
</template>

<script scoped>
// import { createApp } from "vue";
// import { UploadMedia, UpdateMedia } from "vue-media-upload";
// import axios from "axios";

// export default {
//   name: "Admin",
//   data() {
//     return {
//       destinations: "",
//       photographer: "",
//       image: URL,
//     };
//   },
//   methods: {
//       save() {
//           axios.post("https://testing-5c7cf-default-rtdb.firebaseio.com/.json"){
//               destinations: this.destinations,
//               photographer: this.photographer,
//               image: this.image
//           },
//       },
//   },
// };

// let app = createApp({});

// app.component("upload-media", UploadMedia);
// app.component("update-media", UpdateMedia);

// app.mount("#app");
</script>

<style scoped>
input[type="text"],
select {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

input[type="submit"] {
  width: 100%;
  background-color: #4caf50;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

input[type="submit"]:hover {
  background-color: #45a049;
}

div {
  border-radius: 5px;
  background-color: #f2f2f2;
  padding: 20px;
}
</style>
