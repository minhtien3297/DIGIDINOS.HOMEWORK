<template>
  <div class="list-group">
    <NuxtLink
      to="/blog/list"
      class="list-group-item list-group-item-action d-flex justify-content-center font-weight-bold rounded-0"
      >List</NuxtLink
    >

    <NuxtLink
      to="/blog/new"
      class="list-group-item list-group-item-action d-flex justify-content-center font-weight-bold rounded-0"
      >New</NuxtLink
    >

    <NuxtLink
      to="/blog/search"
      class="list-group-item list-group-item-action d-flex justify-content-center font-weight-bold rounded-0"
      >Search</NuxtLink
    >

    <NuxtLink
      to="/blog/_id"
      class="list-group-item list-group-item-action d-flex justify-content-center font-weight-bold rounded-0"
      >Edit</NuxtLink
    >
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
.list-group {
  margin-left: 100px;
}
</style>