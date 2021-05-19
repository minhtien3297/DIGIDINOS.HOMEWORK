<template>
  <div>
    <!-- NavBar -->
    <div class="sticky-top">
      <nav-bar></nav-bar>
    </div>

    <div class="img-title">
      <h1 class="text-white">BLOG LIST</h1>
    </div>
    <listBlogs :DATALIST="blogsData" :getBlog="getBlog" />
  </div>
</template>

<script>
import axios from "axios";
import navBar from "../../components/MainComponents/NavBar";
import { URL_GetAllBlog } from "../../common/Url";
import listBlogs from "../../components/BlogComponents/ListBlog";

export default {
  components: {
    listBlogs,
    navBar,
  },

  data() {
    return {
      blogsData: [],
    };
  },

  mounted() {
    this.getBlog();
  },

  methods: {
    /**
     * Get Blog
     */
    getBlog() {
      axios
        .get(URL_GetAllBlog)
        .then((res) => {
          this.blogsData = res.data;
        })
        .catch((err) => {
          console.error(err);
        });
    },
  },
};
</script>

<style>
.img-title {
  background-image: linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.5)),
    url("../../assets/Cover/781-1000x400.jpg");
  background-attachment: fixed;
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  height: 40vh;
  display: flex;
  justify-content: center;
  align-items: center;
}

.img-title h1 {
  margin: auto;
}
</style>