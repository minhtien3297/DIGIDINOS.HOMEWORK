<template>
  <div>
    <!-- Header -->
    <div class="header">
      <header-blog></header-blog>
    </div>

    <div>
      <Nuxt />
    </div>

    <!-- Footer -->
    <div>
      <footer-blog></footer-blog>
    </div>
  </div>
</template>

<script>
import FooterBlog from "../components/FooterBlog.vue";
import Header from "../components/HeaderBlog";

export default {
  components: {
    Header,
    FooterBlog,
  },
};
</script>

<style>
html,
body {
  height: 100%;
  margin: 0;
  background-color: #303030;
}

html {
  font-family: "Source Sans Pro", -apple-system, BlinkMacSystemFont, "Segoe UI",
    Roboto, "Helvetica Neue", Arial, sans-serif;
  font-size: 16px;
  word-spacing: 1px;
  -ms-text-size-adjust: 100%;
  -webkit-text-size-adjust: 100%;
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  box-sizing: border-box;
  scroll-behavior: smooth;
}

*,
*::before,
*::after {
  box-sizing: border-box;
  margin: 0;
}

.header {
  background: #303030;
  color: white;
  padding: 10px 0px 5px 0px;
}
</style>
