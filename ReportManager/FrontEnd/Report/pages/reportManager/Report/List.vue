<template>
  <div class="card">
    <div class="card-header">
      <div class="row">
        <h2 class="col">{{ title }}</h2>

        <div class="col">
          <nuxt-link
            class="btn btn-info ml-3"
            to="/reportManager/Report/New"
            style="width: 20%; float: right"
            >New</nuxt-link
          >

          <nuxt-link
            class="btn btn-info ml-3"
            to="/reportManager/Report/Search"
            style="width: 20%; float: right"
            >Search</nuxt-link
          >
        </div>
      </div>
    </div>

    <div class="card-body">
      <table-report
        :dataReport="dataReport"
        :title="title"
        :getReport="getReport"
      ></table-report>
    </div>
  </div>
</template>

<script>
import TableReport from "../../../components/Report/TableReport";
import axios from "axios";
import { Domain } from "@/constant/constant.js";

export default {
  components: {
    TableReport,
  },

  data() {
    return {
      dataReport: [],
      title: "Report List",
      domain: Domain,
    };
  },

  /**
   * Call List Data Function
   */
  mounted() {
    this.getReport();
  },

  methods: {
    async getReport() {
      const urlReport = this.domain + "Report/GetAllReport";
      const urlTeam = this.domain + "Team/GetAllTeam";
      const urlAccount = this.domain + "Account/GetAllAccount";

      /**
       * Get All Report
       */
      const report = await axios.get(urlReport);
      this.dataReport = report.data;

      /**
       * Get Team Name By Teams_ID
       */
      const team = await axios.get(urlTeam);
      this.dataTeam = team.data;
      this.dataTeam.map((team) => {
        this.dataReport.map((report) => {
          if (report.Teams_ID == team.ID) {
            report.Teams_ID = team.Name;
          }
        });
      });

      /**
       * Get Account Name By Account_ID
       */
      const account = await axios.get(urlAccount);
      this.dataAccount = account.data;
      this.dataAccount.map((account) => {
        this.dataReport.map((report) => {
          if (report.Account_ID == account.ID) {
            report.Account_ID = account.Username;
          }
        });
      });
    },
  },
};
</script>