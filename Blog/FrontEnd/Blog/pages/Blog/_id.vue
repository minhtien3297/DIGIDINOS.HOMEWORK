<template>
  <div>
    <nav-bar></nav-bar>
    <createEdit :title="title" />
  </div>
</template>

<script>
import createEdit from "../../components/BlogComponents/CreateEditBlog";
import NavBar from "../../components/MainComponents/NavBar.vue";
export default {
  components: {
    createEdit,
    NavBar,
  },

  data() {
    return {
      title: "Edit Blog",
    };
  },
};
</script>

<style>
</style>