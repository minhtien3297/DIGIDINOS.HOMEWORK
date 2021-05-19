<template>
  <blog-create-edit :title="title"></blog-create-edit>
</template>

<script>
import BlogCreateEdit from "../../components/BlogCreateEdit";

export default {
  data() {
    return {
      title: "Edit Blogs",
    };
  },

  components: { BlogCreateEdit },
};
</script>