<template>
  <blog-list
    :isVisible="isVisible"
    :blogs="blogs"
    :getBlogs="getBlogs"
  ></blog-list>
</template>

<script>
import BlogList from "../../components/BlogList.vue";
import axios from "axios";

export default {
  data() {
    return {
      isVisible: false,
      blogs: [],
    };
  },

  mounted() {
    this.getBlogs();
  },

  methods: {
    /**
     * Get All Blogs
     */
    getBlogs: function () {
      const url = "https://localhost:44308/api/Blog/GetAllBlog";
      axios({
        method: "get",
        url: url,
      }).then((response) => {
        this.blogs = response.data;
      });
    },
  },

  components: { BlogList },
};
</script>