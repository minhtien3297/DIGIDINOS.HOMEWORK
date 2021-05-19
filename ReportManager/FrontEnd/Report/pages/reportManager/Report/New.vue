<template>
  <create-edit-report :title="title" :accounts="accounts"></create-edit-report>
</template>

<script>
import CreateEditReport from "../../../components/Report/CreateEditReport.vue";
import { Domain } from "@/constant/constant";
import axios from "axios";

export default {
  data() {
    return {
      title: "Create Report",
      domain: Domain,
      accounts: [],
    };
  },

  mounted() {
    this.getAccount();
  },

  components: {
    CreateEditReport,
  },

  methods: {
    getAccount() {
      const urlAccount = this.domain + "Account/GetAllAccount";
      axios.get(urlAccount).then((res) => (this.accounts = res.data));
    },
  },
};
</script>
