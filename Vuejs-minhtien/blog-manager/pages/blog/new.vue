<template>
  <blog-create-edit :title="title"></blog-create-edit>
</template>

<script>
import BlogCreateEdit from "../../components/BlogCreateEdit";

export default {
  data() {
    return {
      title: "New Blogs",
    };
  },

  components: { BlogCreateEdit },
};
</script>