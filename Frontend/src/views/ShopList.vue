<template>
  <b-container class="mt-5">
      <h3>Productos seleccionados en el carrito de compra</h3>
    <b-container>
      <b-row class="mt-4">
        <b-col v-for="item in productsShop" :key="item.id">
          <b-card-group deck columns>
            <b-card
              overlay
              :title = item.name
              :img-src = item.image
              img-top
              style="max-width: 20rem;"
              class="mb-3"
            >
              <template #footer>
                <b-badge variant="primary" pill
                  >{{ item.count }} productos en el carrito</b-badge>
              </template>
            </b-card>
          </b-card-group>
        </b-col>
      </b-row>
    </b-container>
    <b-button :disabled = "productsShop.length === 0" v-on:click = "Buy()" variant="success">Comprar</b-button>
    <b-modal id="shop">Se realizó la compra satisfactoriamente</b-modal>
    <b-modal id="noShop">No se pudo realizar la compra</b-modal>
  </b-container>
</template>

<script>
import axios from "axios";
import { mapMutations, mapState } from "vuex";
export default {
  name: "ShopList",
  data: () => ({
    items: [],
  }),
  components: {},
  computed: {
    ...mapState(["productsShop"]),
  },

  methods: {
    async Buy() {
      const shopProducts = this.productsShop.map(element => element.id);
      const res = await axios.post('https://localhost:7185/api/Order', {
        date: new Date(),
        userId: 1,
        itemIdList: shopProducts,
      });
      if (res.data) {
        this.$bvModal.show('shop');
      } else {
        this.$bvModal.show('noShop');
      }
    }
  },
};
</script>

<style></style>
