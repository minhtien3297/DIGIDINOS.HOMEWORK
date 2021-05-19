<template>
  <nav class="navbar navbar-dark sticky-top bg-dark flex-md-nowrap p-0">
    <div style="width: 20%">
      <img
        src="https://digidinos.com/assets/images/logo.png"
        width="13%"
        style="margin-left: 5%"
      />

      <div
        class="navbar-brand col-sm-3 col-md-2 mr-0"
        href="#"
        style="margin-left: 3%"
      >
        Digidinos
      </div>
    </div>

    <button class="btn text-white-50" @click="logOut()">Sign out</button>
  </nav>
</template>

<script>
export default {
  methods: {
    async logOut() {
      await this.$auth.logout();
      await this.$router.push("/login");
    },
  },
};
</script>

<style>
.nav-link:hover {
  color: white !important;
}
</style>
