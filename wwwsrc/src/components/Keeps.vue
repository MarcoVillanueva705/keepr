<template>

      <div class="row">
        <div class="col-2">
        <p>{{ keepData.name }}</p>
        </div>

          <div class="col-2">
          <p>{{ keepData.description }}</p>
          </div>

          <div class="col-2">
          <p>{{ keepData.img }}</p>
          </div>

          <div class="col-2">
          <p>{{ keepData.isPrivate }}</p>
          </div>

        </div>

</template>



<script>

export default {

name: "keeps",
props: ["keepData"],
computed: {   
  },
methods: {  
  },
};
</script>