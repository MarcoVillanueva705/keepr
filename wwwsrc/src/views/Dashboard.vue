<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    <!-- public {{ publicKeeps }} user {{ userKeeps }} -->
    <form @submit.prevent="createKeep">
      <input type="text" name="name" placeholder="Name" v-model="newKeep.name" />
      <input type="text" name="description" placeholder="Description" v-model="newKeep.description" />
      <input type="text" name="img" placeholder="Image" v-model="newKeep.img" />
      <input type="checkbox" name="isPrivate" placeholder="Make Private?" v-model="newKeep.isPrivate" /><span>Mark Private?</span>
      <button type="submit">Create This Keep</button>
    </form>
    
    <main class="row-keeps">
        <div class="col-12" v-for="keep in keeps" :key="keep.id"> <!--should this be for bug in newBug?-->
          <!-- Props are data passed from parent to child with :propName="DATA" -->
          <keeps
           :keepData="keep" />
        </div>
    </main>
  </div>


</template>



<script>
import keeps from "@/components/Keeps.vue";
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
  mounted() {
    this.$store.dispatch("getUserKeeps")
  },
  methods: {
  createKeep() {
      this.$store.dispatch("createKeep", this.newKeep);
      this.newKeep = {name: "", description:"", img:"", isPrivate:""}
    }
  },
  computed: {
  keeps() {
    return this.$store.state.userKeeps;
    }
  },
  components: {
    keeps
  }
};
</script>



<style></style>
