<template>
  <div>
    <app-header></app-header>
    <div class="container-fluid row mt-3">
      <div class="col-3">
        <app-menu></app-menu>
      </div>
      <div class="col-9">
        <Nuxt />
      </div>
    </div>
  </div>
</template>

<script>
import AppHeader from "../components/AppHeader.vue";
import AppMenu from "../components/AppMenu.vue";
export default {
  components: { AppHeader, AppMenu },
};
</script>

