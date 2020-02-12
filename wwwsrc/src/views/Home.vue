

<template>
  <div class="home">
    <h1>Welcome Home</h1>
    

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
name: "home",

  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.publicKeeps;
    }
    },
 mounted() {
  this.$store.dispatch("getKeeps");
  },

  methods: {
    logout() {
      this.$store.dispatch("logout");
    },

  },
  components: {
    keeps
  }

};

</script>