<template>
  <b-container class="mt-5">
    <h3>Productos disponibles</h3>
    <b-container>
      <b-row class="mt-4">
        <b-col v-for="(item, index) in items" :key="item.id">
          <b-card-group deck columns>
            <b-card
              :title="item.name"
              :img-src="item.image"
              img-top
              style="max-width: 20rem"
              class="mb-5"
            >
              <b-card-text class="mb-2">
                {{ item.description }}
              </b-card-text>
              <b-button variant="primary" v-on:click="AddItem(item, index)"
                >Agregar</b-button
              >
              <b-button
                class="ml-2"
                variant="warning"
                v-on:click="RemoveItem(item, index)"
                >Remover</b-button
              >
              <template #footer>
                <b-badge variant="primary" pill
                  >{{ productsCount[index] }} productos agregados al
                  carrito</b-badge
                >
              </template>
            </b-card>
          </b-card-group>
        </b-col>
      </b-row>
    </b-container>
  </b-container>
</template>

<script>
import axios from "axios";
import { mapMutations, mapState } from "vuex";
export default {
  name: "Product",
  data: () => ({
    items: [],
  }),
  components: {},
  computed: {
    ...mapState(["productsCount", "products"]),
  },

  mounted() {
    setTimeout(() => {      
      this.obtainData();
    }, 500);
  },

  methods: {
    ...mapMutations(["Add", "Remove", "AddProduct", "RemoveProduct"]),
    obtainData() {      
      this.items = this.products;
    },

    AddItem(item, index) {
      this.Add(index);
      this.AddProduct(item);
    },

    RemoveItem(item, index) {
      this.Remove(index);
      this.RemoveProduct(item);
    },
  },
};
</script>

<style></style>
