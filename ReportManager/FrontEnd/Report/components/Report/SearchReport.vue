<template>
  <div class="form">
    <div class="row">
      <!-- Done Search-->
      <div class="col">
        <input
          class="form-control mr-sm-2"
          type="search"
          placeholder="Done"
          aria-label="Search"
          v-model="searchString.Done"
        />
      </div>

      <!-- Date Search-->
      <div class="col">
        <input
          class="form-control mr-sm-2"
          type="datetime"
          placeholder="Date"
          aria-label="Search"
          v-model="searchString.Date"
        />
      </div>

      <!-- Account Search-->
      <div class="col">
        <input
          class="form-control mr-sm-2"
          type="search"
          placeholder="Account"
          aria-label="Search"
          v-model="searchString.Account_Name"
        />
      </div>

      <!-- Team Search-->
      <div class="col">
        <input
          class="form-control mr-sm-2"
          type="search"
          placeholder="Team"
          aria-label="Search"
          v-model="searchString.Teams_Name"
        />
      </div>

      <button class="btn btn-outline-success my-2 my-sm-0" @click="search()">
        Search
      </button>
    </div>
  </div>
</template>

<script>
import { Domain } from "@/constant/constant";
import axios from "axios";

export default {
  data() {
    return {
      searchString: {
        Done: "",
        Date: "",
        Account_Name: "",
        Teams_Name: "",
      },
      domain: Domain,
      dataReport: [],
    };
  },

  /**
   * Search Report By Done Then Send Data to Search Report Page
   */
  methods: {
    async search() {
      const urlSearch = this.domain + "Report/SearchBySearchString";
      const urlTeam = this.domain + "Team/GetAllTeam";
      const urlAccount = this.domain + "Account/GetAllAccount";

      /**
       * Search Report
       */
      const report = await axios.get(
        urlSearch +
          "?done=" +
          this.searchString.Done +
          "&date=" +
          this.searchString.Date +
          "&account_name=" +
          this.searchString.Account_Name +
          "&teams_name=" +
          this.searchString.Teams_Name
      );
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

      /**
       * Send dataReport to Search Report page
       */
      this.$emit("dataReport", this.dataReport);
    },
  },
};
</script>
