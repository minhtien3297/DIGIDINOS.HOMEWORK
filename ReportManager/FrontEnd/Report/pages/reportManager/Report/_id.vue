<template>
  <edit-report :title="title" :accounts="accounts"></edit-report>
</template>

<script>
import EditReport from "../../../components/Report/CreateEditReport.vue";
import { Domain } from "@/constant/constant";
import axios from "axios";

export default {
  data() {
    return {
      title: "Edit Report",
      domain: Domain,
      accounts: [],
    };
  },

  components: { EditReport },

  mounted() {
    this.getAccount();
  },

  methods: {
    getAccount() {
      const urlAccount = this.domain + "Account/GetAllAccount";
      axios.get(urlAccount).then((res) => (this.accounts = res.data));
    },
  },
};
</script>