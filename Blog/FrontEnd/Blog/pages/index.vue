<template>
  <div>
    <!-- NavBar -->
    <div class="sticky-top">
      <nav-bar></nav-bar>
    </div>

    <!-- Home -->
    <div>
      <home-blog></home-blog>
    </div>

    <!-- About -->
    <div>
      <about></about>
    </div>

    <!-- Blogs -->
    <div>
      <blogs></blogs>
    </div>

    <!-- Portfolio -->
    <div>
      <port-folio></port-folio>
    </div>

    <!-- Contact -->
    <div>
      <contact></contact>
    </div>
  </div>
</template>

<script>
import HomeBlog from "../components/MainComponents/Home";
import NavBar from "../components/MainComponents/NavBar";
import About from "../components/MainComponents/About.vue";
import Blogs from "../components/MainComponents/Blogs.vue";
import PortFolio from "../components/MainComponents/PortFolio.vue";
import Contact from "../components/MainComponents/Contact.vue";

export default {
  components: {
    NavBar,
    HomeBlog,
    About,
    Blogs,
    PortFolio,
    Contact,
  },
};
</script>

<style>
.title {
  font-family: "Quicksand", "Source Sans Pro", -apple-system, BlinkMacSystemFont,
    "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif;
  display: block;
  font-weight: 300;
  font-size: 100px;
  color: #35495e;
  letter-spacing: 1px;
}

.subtitle {
  font-weight: 300;
  font-size: 42px;
  color: #526488;
  word-spacing: 5px;
  padding-bottom: 15px;
}

.links {
  padding-top: 15px;
}
</style>
