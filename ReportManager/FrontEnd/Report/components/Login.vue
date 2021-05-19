<template >
  <div
    class="container d-flex align-items-center justify-content-center"
    id="login"
  >
    <div style="width: 100%; max-width: 330px; margin: auto">
      <!--logo-->
      <div class="d-flex align-items-center justify-content-center my-4">
        <img
          style="margin-left: 0px"
          src="https://digidinos.com/assets/images/logo.png"
          width="100px"
          height="100px"
        />
      </div>

      <h1 class="h3 mb-3 font-weight-normal d-flex justify-content-center">
        Sign in
      </h1>

      <input
        class="form-control mt-3"
        placeholder="Enter Username"
        v-model="userInfo.Username"
      />

      <!--Password-->
      <input
        type="password"
        class="form-control my-3"
        placeholder="Enter Password"
        v-model="userInfo.Password"
      />

      <button class="btn btn-lg btn-primary btn-block" @click="login(userInfo)">
        Sign in
      </button>
    </div>

    <!-- Errors alert -->
    <div
      class="fixed-bottom d-flex justify-content-center"
      v-if="errors.length > 0"
    >
      <div
        class="alert alert-danger"
        role="alert"
        style="width: 200px; margin-bottom: 10%; margin-left: 10px"
        v-for="error in errors"
        :key="error.index"
      >
        {{ error }}
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      userInfo: {
        Username: "",
        Password: "",
        grant_type: "password",
      },

      errors: [],
    };
  },

  methods: {
    /**
     * Login
     */
    async login(data) {
      this.errors = [];
      this.validate();
      if (this.errors.length == 0) {
        try {
          const res = await this.$auth.loginWith("local", {
            headers: {
              "Content-Type": "application/x-www-form-urlencoded",
              "Cache-Control": "no-cache",
            },
            withCredentials: true,
            crossDomain: true,
            data: $.param(data),
          });
          if (res && res.data) {
            console.warn("Login successful!");
            this.$router.push({
              path: "/reportManager/Report/List",
            });
          }
        } catch (error) {
          this.errors.push("The username or password is incorrect!");
        }
      }
    },

    /**
     * Validate input
     */
    validate() {
      if (this.userInfo.Username == "") {
        this.errors.push("Username không được trống");
      }
      if (this.userInfo.Password == "") {
        this.errors.push("Password không được trống");
      }
    },
  },
};
</script>

<style>
body,
html {
  height: 100%;
  width: 100%;
  margin: 0;
}

#login {
  height: 100vh;
}
</style>