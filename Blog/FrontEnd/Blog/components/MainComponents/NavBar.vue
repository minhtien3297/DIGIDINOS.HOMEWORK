<template>
  <b-nav class="navbar navbar-light bg-light">
    <div class="container-fluid">
      <h1>DigiDinos</h1>

      <ul class="nav col-5 d-flex justify-content-around">
        <!-- Home -->
        <li class="nav-item">
          <nuxt-link
            class="nav-link"
            to="/"
            style="color: rgb(83, 83, 83); font-weight: bold"
            >HOME</nuxt-link
          >
        </li>

        <!-- about -->
        <li class="nav-item">
          <nuxt-link
            class="nav-link"
            to="/#about"
            style="color: rgb(83, 83, 83); font-weight: bold"
            >ABOUT</nuxt-link
          >
        </li>

        <!-- blogs -->
        <b-nav-item-dropdown
          id="my-nav-dropdown"
          text="BLOG"
          toggle-class="nav-link-custom text-dark"
          style="font-weight: bold"
          right
        >
          <b-dropdown-item
            ><nuxt-link
              class="nav-link"
              to="/#blog"
              style="color: rgb(83, 83, 83); font-weight: bold"
              >BLOG SECTION</nuxt-link
            ></b-dropdown-item
          >
          <b-dropdown-divider></b-dropdown-divider>
          <b-dropdown-item
            ><nuxt-link
              class="nav-link"
              to="/Blog/list"
              style="color: rgb(83, 83, 83); font-weight: bold"
              >BLOG LIST</nuxt-link
            ></b-dropdown-item
          >
          <b-dropdown-divider></b-dropdown-divider>
          <b-dropdown-item
            ><nuxt-link
              class="nav-link"
              to="/Blog/new"
              style="color: rgb(83, 83, 83); font-weight: bold"
              >CREATE NEW BLOG</nuxt-link
            ></b-dropdown-item
          >
        </b-nav-item-dropdown>

        <!-- portfolio -->
        <li class="nav-item">
          <nuxt-link
            class="nav-link"
            to="/#portfolio"
            style="color: rgb(83, 83, 83); font-weight: bold"
            >PORTFOLIO</nuxt-link
          >
        </li>

        <!-- contact -->
        <li class="nav-item">
          <nuxt-link
            class="nav-link"
            to="/#contact"
            style="color: rgb(83, 83, 83); font-weight: bold"
            >CONTACT</nuxt-link
          >
        </li>
      </ul>
    </div>
  </b-nav>
</template>

<script>
export default {};
</script>

<style>
.navbar h1 {
  color: rgb(83, 83, 83);
  font-weight: 600;
  margin-left: 100px;
}

#my-nav-dropdown__BV_toggle_ span {
  color: rgb(83, 83, 83);
}
</style>