<template>
  <div id="app">
    <Navbar />
    <router-view></router-view>
  </div>
</template>

<script>
import Navbar from "./components/Navbar.vue";
import axios from "axios";
import { mapMutations, mapState } from "vuex";
export default {
  name: "App",
  data: () => ({
    items: [],
  }),

  components: {
    Navbar,
  },

  created() {
    this.obtainAPIItems();
    this.obtainAPIBuys();
    this.obtainAPIUser();
  },

  methods: {
    ...mapMutations(["StartProducts", "StartUser", "StartAllProducts", "StartProductsBought"]),
    async obtainAPIItems() {
      let response = await axios.get("https://localhost:7185/api/Item");
      this.items = response.data;
      this.StartProducts(this.items);
      this.StartAllProducts(this.items);
    },

    async obtainAPIUser() {
      let response = await axios.get("https://localhost:7185/api/User");
      this.StartUser(response.data);
    },

    async obtainAPIBuys() {
      let response = await axios.get("https://localhost:7185/api/Order/1");
      this.StartProductsBought(response.data);
    }
  },
};
</script>

<style></style>
