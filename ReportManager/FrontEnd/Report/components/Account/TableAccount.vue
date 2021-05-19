<template>
  <div class="card">
    <div class="card-header">
      <div class="row">
        <h2 class="col">Account List</h2>

        <div class="col">
          <nuxt-link
            to="/reportManager/Account/Create"
            style="float: right; width: 20%"
            class="btn btn-info ml-3"
          >
            New
          </nuxt-link>

          <nuxt-link
            class="btn btn-info"
            style="float: right; width: 20%"
            to="/reportManager/Account/Search"
            >Search</nuxt-link
          >
        </div>
      </div>
    </div>

    <!-- list -->
    <list-account
      @deleted="getAccounts()"
      :filteredAccounts="accounts"
    ></list-account>
  </div>
</template>

<script>
import axios from "axios";
import List from "./List.vue";

export default {
  components: {
    "list-account": List,
  },

  data() {
    return {
      accounts: [],
      titleSearchString: "",
      filteredAccounts: [],
    };
  },

  mounted() {
    this.getAccounts();
  },

  methods: {
    //#region search này có nên dùng lại không?
    /**
     * search API
     * @param  form {object} : the form use into search component
     * @return data of server
     *
     * @since 8-3-2021
     * @author Vu Doan
     */
    // searchAPI(form) {
    //     console.log(form);
    //     axios
    //         .get("https://localhost:44343/api/Account/GetAllAccount", {
    //             params: {
    //                 title_like: form.title
    //             }
    //         })
    //         .then((response) => (this.blogs = response.data));
    // },
    //#endregion

    /**
     * title search
     * @return title use input
     *
     * @since 9-3-2021
     * @author Vu Doan
     */
    filteredAccount: function () {
      if (!this.titleSearchString) {
        return this.accounts;
      }

      const searchString = this.titleSearchString.trim().toLowerCase();

      this.filteredAccounts = this.accounts.filter(function (item) {
        if (item.title.toLowerCase().indexOf(searchString) !== -1) {
          return item;
        }
      });
      return this.filteredAccounts;
    },

    /**
     * add data to list form account
     * @return result of CONST_getAccounts()
     *
     * @since 9-3-2021
     * @author Vu Doan
     */
    getAccounts() {
      axios
        .get("https://localhost:44343/api/Account/GetAllAccount")
        .then((response) => (this.accounts = response.data));
    },
  },
};
</script>

<style>
table {
  text-align: center;
}
</style>
