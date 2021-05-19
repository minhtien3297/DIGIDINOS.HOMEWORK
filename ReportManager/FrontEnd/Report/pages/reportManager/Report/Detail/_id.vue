<template>
  <div class="card" style="border: 0px">
    <div class="card-header">
      <h1>Report Detail</h1>
    </div>

    <!-- Detail Report -->
    <div class="card-body">
      <detail-report :formReport="formReport"></detail-report>
    </div>

    <!-- Comment section -->
    <comment
      :formComment="formComment"
      :Comments="Comments"
      :formReport="formReport"
      :getCmtByID="getCmtByID"
    ></comment>
  </div>
</template>

<script>
import DetailReport from "../../../../components/Report/DetailReport.vue";
import Comment from "../../../../components/Report/Comment.vue";
import { Domain } from "@/constant/constant";
import axios from "axios";

export default {
  components: {
    DetailReport,
    Comment,
  },

  data() {
    return {
      formReport: {
        Done: "",
        Problem: "",
        Solution: "",
        Link: "",
        Accounts_ID: "",
        Teams_ID: "",
      },

      formComment: {
        Contents: "",
        Accounts_ID: "",
        Reports_ID: this.$route.params.id,
      },

      Comments: [],

      dataAccount: [],

      domain: Domain,
    };
  },

  mounted() {
    this.getDataByID();
    this.getCmtByID();
  },

  methods: {
    /**
     * Get Report By ID
     */
    async getDataByID() {
      const urlDataByID = this.domain + "Report/GetReportByID/";

      const res = await axios.get(urlDataByID + this.$route.params.id);
      this.formReport = res.data;
      this.formComment.Accounts_ID = res.data.Account_ID;
    },

    /**
     * Get Comment By ID
     */
    async getCmtByID() {
      const urlCmtByID = this.domain + "Comment/GetCommentByID/";
      const urlAccount = this.domain + "Account/GetAllAccount";

      const Cmt = await axios.get(urlCmtByID + this.$route.params.id);
      this.Comments = Cmt.data;

      /**
       * Get Account Name By Account_ID
       */
      const account = await axios.get(urlAccount);
      this.dataAccount = account.data;
      this.dataAccount.map((account) => {
        this.Comments.map((comment) => {
          if (comment.Accounts_ID == account.ID) {
            comment.Accounts_ID = account.Username;
          }
        });
      });
    },
  },
};
</script>