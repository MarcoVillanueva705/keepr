<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
    <form @submit.prevent="createKeep">
      <input type="text" name="name" placeholder="Name" v-model="newKeep.name" />
      <input type="text" name="description" placeholder="Description" v-model="newKeep.description" />
      <input type="text" name="img" placeholder="Image" v-model="newKeep.img" />
      <input type="checkbox" name="isPrivate" placeholder="Make Private?" v-model="newKeep.isPrivate" />
      <button type="submit">Create This Keep</button>
    </form>
  </div>
  
</template>



<script>
export default {
  name: "dashboard",

  data() {
    return {
      newKeep: {
        name: "",
        description:"",
        img:"",
        isPrivate: true,
      }
    };
  },
  mounted() {},
  methods: {
  createKeep() {
      this.$store.dispatch("createKeep", this.newKeep);
      this.newKeep = {name: "", description:"", img:"", isPrivate:""}
    }
  },
  computed: {}
};
</script>



<style></style>
