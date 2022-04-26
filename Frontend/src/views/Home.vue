<template>
  <b-container class="mt-5">
    <h3>
      Hola {{ nombre }}, estas son las compras que has hecho anteriormente
    </h3>
    <b-container class="mt-3">
      <b-list-group v-for="item in infoDataProducts" :key="item.id" class="mb-3">
        <b-list-group-item>Ha comprado {{ item.quantity }} de {{ item.name }} en la orden
           {{ item.idOrder }}</b-list-group-item>
      </b-list-group>
    </b-container>
  </b-container>
</template>

<script>
// <router-link to="/">Home</router-link>
import axios from "axios";
import { mapMutations, mapState } from "vuex";

export default {
  name: "Home",
  data: () => ({
    infoUser: "",
    infoDataBuys: null,
    infoDataProducts: null,
    nombre: "",
  }),
  components: {},

  mounted() {
    setTimeout(() => {
      this.obtainDataShop();
      this.obtainData();
    }, 1500);
  },

  computed: {
    ...mapState(["productsCount", "productsBought", "user"]),
  },

  methods: {
    ...mapMutations(["StartProductsBought"]),
    obtainData() {
      this.infoUser = this.user;
      this.nombre =
        this.infoUser[0].firstName + " " + this.infoUser[0].secondName;
    },

    async obtainDataShop() {
      let response = await axios.get("https://localhost:7185/api/Order/1");
      this.StartProductsBought(response.data);
      this.infoDataProducts = this.productsBought;
    },
  },
};
</script>
