import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    productsCount: [],
    productsShop: [],
    productsBought: [],
    products: [],
    user: {}
  },
  mutations: {
    Add(state, index) {
      state.productsCount[index] ++;
    },

    Remove(state, index) {
      state.productsCount[index] --;
    },

    StartProducts(state, items) {
      state.productsCount = items.map(() => 0);
    },

    StartAllProducts(state, products) {
      state.products = products;
    },

    StartProductsBought(state, products) {
      state.productsBought = products;
    },

    StartUser(state, user) {
      state.user = user;
    },

    AddProduct(state, item) {
      let flag = false;
      state.productsShop.forEach((element) => {
        if (item.id === element.id) {
          element.count ++;
          flag = true;
        }
      });
      if (!flag) {
        state.productsShop.push({
          id: item.id,
          name: item.name,
          image: item.image,
          count: 1
        });
      }
    },

    RemoveProduct(state, item) {
      let id = 0;
      state.productsShop.forEach((element) => {
        if (item.id === element.id) {
          element.count --;
          if (element.count === 0) {
            state.productsShop.splice(id, 1);
          }
        }
        id ++;
      });
    },
  },
  actions: {
  },
  modules: {
  }
})
