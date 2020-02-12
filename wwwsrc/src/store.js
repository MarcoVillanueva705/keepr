import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "./router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost") ? "https://localhost:5001/" : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    userKeeps:[]
  },
  mutations: {
    setAllKeeps(state, data) {
      state.publicKeeps = data;
    },
    setUserKeeps(state, data) {
      state.userKeeps = data;
    },
    createKeep(state, keep) {
      state.publicKeeps.push(keep);
    },
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    async getKeeps({ commit, dispatch }) {
    let res = await api.get('keeps');
    commit("setAllKeeps", res.data);
    },

    async getUserKeeps({commit, dispatch}) {
    let res = await api.get('keeps/user');
    commit("setUserKeeps", res.data);
    },

    async createKeep({ commit, dispatch }, keep) {
    let res = await api.post('keeps', keep);
    commit("createKeep", res.data);
      
    }
  }
});
