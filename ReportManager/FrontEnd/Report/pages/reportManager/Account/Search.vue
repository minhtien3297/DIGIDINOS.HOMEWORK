<template>
  <div class="container-fluid">
    <div>
      <search @search="getData($event)" :title="tilte"></search>
    </div>

    <div>
      <table-account :filteredAccounts="accounts"></table-account>
    </div>
  </div>
</template>

<script>
import Search from "../../../components/Account/Search.vue";
import TableAccount from "../../../components/Account/List.vue";
import axios from "axios";

export default {
  components: {
    Search,
    TableAccount,
  },

  data() {
    return {
      accounts: [],
      searchString: "",
      filteredAccounts: [],
      tilte: "Account Search",
    };
  },

  methods: {
    /**
     * Search account
     */
    search() {
      axios
        .get(
          "https://localhost:44343/api/Account/SearchByUsername?username=" +
            this.searchString
        )
        .then((response) => {
          this.accounts = response.data;
        });
    },

    /**
     * Get searchString from search components
     */
    getData(value) {
      this.searchString = value;
      this.search();
    },
  },
};
</script>
