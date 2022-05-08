<template>
  <div>
    <form>
      <input v-model="todo.name" placeholder="Todo's name" /><br><br>
      <button @click="validate">Add Task</button>
    </form>

    <div v-show="!valid">Please enter a task to add</div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      todo: {
        name: null,
        checked: false,
      },
      valid: true,
    };
  },
  methods: {
    validate() {
      this.valid = true;
      if (this.todo.name != null) {
        this.$router.push({name:'mainPage', params:{newTodoName: this.todo.name}})
      } else {
        this.valid = false;
        setTimeout(() => {
          this.valid = true;
        }, 3000);
      }
    },
  },
};
</script>
