<template>
  <div>
    <p>
      Completed Tasks:
      {{
        todos.filter((todo) => {
          return todo.done === true;
        }).length
      }}
    </p>
    <p>
      Pending Tasks:
      {{
        todos.filter((todo) => {
          return todo.done === false;
        }).length
      }}
    </p>
    <todo v-on:delete-todo="deleteTodo" v-on:complete-todo="completeTodo(todo)" v-for="todo in todos" :todo="todo" :key="todo.title"></todo>
  </div>
</template>

<script type = "text/javascript" >
import Todo from './Todo.vue'

export default {
  components: {
    Todo
  },
  props: ['todos'],
  methods: {
    deleteTodo (todo) {
      const todoIndex = this.todos.indexOf(todo)
      this.todos.splice(todoIndex, 1)
    },
    completeTodo (todo) {
      const todoIndex = this.todos.indexOf(todo)
      this.todos[todoIndex].done = true
    }
  }
}
</script>

<style>
</style>
