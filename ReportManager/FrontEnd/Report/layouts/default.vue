<template>
  <Nuxt />
</template>

<script>
export default {
  middleware: "auth",
};
</script>

<style>
.all {
  width: 100%;
  min-height: 100vh;
  display: flex;
}

.menuMain {
  width: 15%;
  max-height: 100vh;
  background-color: #212529;
}

.menuMain > .header > img {
  width: 30%;
  margin-left: 35%;
}

.conten {
  display: flex;
  flex-wrap: wrap;
  flex-direction: column;
  width: 85%;
  min-height: 100vh;
}

.user {
  width: 20%;
  float: right;
  height: 8vh;
}

.user > img {
  margin-top: 4%;
  margin-left: 20%;
  float: left;
}

.header {
  width: 100%;
  min-height: 1vh;
  background-color: #342c75;
  top: 0;
  right: 0;
  left: 0;
}

.khungnoidung {
  width: 100%;
}

.noidung {
  width: 96%;
  height: auto;
  margin: 2%;
  background-color: whitesmoke;
}

.tilie {
  width: 100%;
  height: 50px;
}

.tilie > h1 {
  text-align: center;
}

.new {
  width: 100%;
  height: 50px;
}

.new > .btn-primary {
  width: 8%;
  margin-left: 90%;
  margin-top: 10px;
}

.btn-info {
  width: 38%;
}

.table {
  margin-top: 3vh;
}

footer {
  width: 100%;
  min-height: 8vh;
  background-color: #342c75;
  display: flex;
  position: fixed;
  bottom: 0;
  right: 0;
  left: 0;
}
.card-body {
  background-color: white;
  border: 1px solid black;
  border-bottom: 1px solid black;
}
.card-body1 {
  background-color: white;
  border: 1px solid black;
  border-bottom: 1px solid black;
}
.card-body2 {
  background-color: white;
  border: 1px solid black;
  border-top: 1px solid black;
}
.card-header {
  border: 1px solid black;
  border-bottom: 1px solid black;
}
.phanTrang {
  width: 100%;
  height: 60px;
}

.phanTrang > .phant {
  float: right;
  margin-top: 1%;
}
#layoutSidenav {
  flex: 1 0 auto;
}
.fixed-top,
.sb-nav-fixed #layoutSidenav #layoutSidenav_nav,
.sb-nav-fixed .sb-topnav {
  position: fixed;
  top: 0;
  right: 0;
  left: 0;
  z-index: 1030;
}

#layoutSidenav {
  display: flex;
}

#layoutSidenav #layoutSidenav_nav {
  flex-basis: 225px;
  flex-shrink: 0;
  transition: transform 0.15s ease-in-out;
  z-index: 1038;
  transform: translateX(-225px);
}

#layoutSidenav #layoutSidenav_content {
  position: relative;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  min-width: 0;
  flex-grow: 1;
  min-height: calc(100vh - 56px);
  margin-left: -225px;
}

.sb-sidenav-toggled #layoutSidenav #layoutSidenav_nav {
  transform: translateX(0);
}

.sb-sidenav-toggled #layoutSidenav #layoutSidenav_content:before {
  content: "";
  display: block;
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: #000;
  z-index: 1037;
  opacity: 0.5;
  transition: opacity 0.3s ease-in-out;
}

@media (min-width: 992px) {
  #layoutSidenav #layoutSidenav_nav {
    transform: translateX(0);
  }

  #layoutSidenav #layoutSidenav_content {
    margin-left: 0;
    transition: margin 0.15s ease-in-out;
  }

  .sb-sidenav-toggled #layoutSidenav #layoutSidenav_nav {
    transform: translateX(-225px);
  }

  .sb-sidenav-toggled #layoutSidenav #layoutSidenav_content {
    margin-left: -225px;
  }

  .sb-sidenav-toggled #layoutSidenav #layoutSidenav_content:before {
    display: none;
  }
}

.sb-nav-fixed .sb-topnav {
  z-index: 1039;
}

.sb-nav-fixed #layoutSidenav #layoutSidenav_nav {
  width: 225px;
  height: 100vh;
  z-index: 1038;
}

.sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav {
  padding-top: 56px;
}

.sb-nav-fixed #layoutSidenav #layoutSidenav_nav .sb-sidenav .sb-sidenav-menu {
  overflow-y: auto;
}

.sb-nav-fixed #layoutSidenav #layoutSidenav_content {
  padding-left: 225px;
  top: 56px;
}
.shadow {
  font-family: Mr Dafoe, sans-serif;
  font-size: 2em;
  text-align: center;
  text-shadow: 0 -3px 0 #333, 0 6px 8px rgba(0, 0, 0, 0.4),
    0 9px 10px rgba(0, 0, 0, 0.15), 0 30px 10px rgba(0, 0, 0, 0.18),
    0 15px 10px rgba(0, 0, 0, 0.21);
}
.form-inline {
  margin-left: 70%;
  margin-top: 2%;
}
</style>