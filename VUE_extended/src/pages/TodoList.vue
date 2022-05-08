<template>
  <div>
    <div>Todo List</div>
    <router-link to="add">Add new task</router-link>

    <div v-for="todo in $store.state.todoList"
    :key="todo.id">
    
    <router-link :to= "{name: 'details' , params:{id: todo.id, todo: todo.name}}">{{todo.name}} -></router-link>
    </div>

  <br><br>
  </div>
</template>
<script>
import todoList from "../data/todoList.js"
export default {
  mounted(){
    console.log(todoList);
  },
  beforeRouteEnter (to, from, next) {
  next(vm => {
    if(to.params.newTodoName){
      console.log(vm)
    vm.$store.commit("addTodo",to.params.newTodoName)
    }
  })
}
};
</script>

