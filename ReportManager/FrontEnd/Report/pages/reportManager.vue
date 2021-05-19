<template >
  <div>
    <header-index></header-index>
    <div id="layoutSidenav">
      <menu-index></menu-index>
      <div id="layoutSidenav_content">
        <div class="khungnoidung">
          <div class="noidung">
            <nuxt-child></nuxt-child>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Header from "../components/Header.vue";
import Menu from "../components/Menu.vue";

export default {
  components: {
    "header-index": Header,
    "menu-index": Menu,
  },
};
</script>
