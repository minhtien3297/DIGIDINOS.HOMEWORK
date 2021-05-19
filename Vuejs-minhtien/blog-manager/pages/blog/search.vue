<template>
  <blog-list :isVisible="isVisible"></blog-list>
</template>

<script>
import BlogList from "../../components/BlogList.vue";

export default {
  data() {
    return {
      isVisible: true,
    };
  },

  components: { BlogList },
};
</script>