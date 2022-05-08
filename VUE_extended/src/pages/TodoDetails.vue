<template>
  <div>
      Todo details: <br>
      Task name: 
    <strong>{{$route.params.todo}}</strong>
    <br>
    <button @click="goBack">back to home</button>
  </div>
</template>
<script>
export default {
    props: ["todo"],
  data() {
    return {
     
    };
  },
  methods:{
      goBack(){
          this.$router.push({name:'mainPage'})
      }
  }
};
</script>
