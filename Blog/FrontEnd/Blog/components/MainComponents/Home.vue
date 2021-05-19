<template>
  <div class="home" id="home">
    <div class="description">
      <h1 class="flex-wrap">
        Hello ,Welcome To My official <span>Website</span>
        <marquee behaviour="scroll" direction="left" class="w-75">
          cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat
          cupidatat non proident, sunt in culpa qui officia deserunt mollit anim
          id est laborum.
        </marquee>
        <br />
        <button class="btn btn-outline-light btn-lg">See more</button>
      </h1>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style>
.home {
  background-image: linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.5)),
    url("../../assets/Cover/954-2000x900.jpg");
  background-attachment: fixed;
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  height: 85vh;
}

.description {
  position: absolute;
  top: 30%;
  left: 20%;
  margin: auto;
  padding: 2em;
  width: 50%;
}

.description h1 {
  color: white;
  font-weight: 600;
  font-size: 70px;
}

.description span {
  color: #28a7e9;
}

.description marquee {
  color: white;
  font-size: 20px;
  width: 100%;
  line-height: 1.5;
}
</style>