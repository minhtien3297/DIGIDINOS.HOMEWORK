<template>
  <div class="card">
    <div class="card-header">
      <h1>{{ title }}</h1>
    </div>

    <div class="card-body">
      <div class="form-group row">
        <div class="col-2 mt-3">
          <label><b>Done:</b></label>
        </div>
        <div class="col-10">
          <textarea
            class="form-control"
            v-model="form.Done"
            placeholder="Input Done"
          ></textarea>
        </div>
      </div>

      <div class="form-group row">
        <div class="col-2 mt-3">
          <label><b>Problem:</b></label>
        </div>
        <div class="col-10">
          <textarea
            class="form-control"
            v-model="form.Problem"
            placeholder="Input Problem"
          ></textarea>
        </div>
      </div>

      <div class="form-group row">
        <div class="col-2 mt-3">
          <label><b>Solution:</b></label>
        </div>
        <div class="col-10">
          <textarea
            class="form-control"
            v-model="form.Solution"
            placeholder="Input Solution"
          ></textarea>
        </div>
      </div>

      <div class="form-group row">
        <div class="col-2 mt-2">
          <label><b>Link:</b></label>
        </div>
        <div class="col-10">
          <input
            class="form-control"
            v-model="form.Link"
            placeholder="Input Link"
          />
        </div>
      </div>

      <div class="form-group row">
        <div class="col-2 mt-2">
          <label><b>Account:</b></label>
        </div>
        <div class="col-10">
          <select style="width: 20%; height: 40px" v-model="form.Account_ID">
            <option
              v-for="account in accounts"
              :value="account.ID"
              :key="account.ID"
            >
              {{ account.Username }}
            </option>
          </select>
        </div>
      </div>

      <div class="row">
        <div class="col-1">
          <div class="btn btn-primary" @click="Back()">Back</div>
        </div>

        <div class="col-11 d-flex justify-content-center">
          <div>
            <button
              v-if="title == 'Edit Report'"
              id="a"
              class="btn btn-primary mr-3"
              @click="updateReport()"
            >
              Save
            </button>

            <button
              v-if="title == 'Create Report'"
              id="a"
              class="btn btn-primary mr-3"
              @click="createReport()"
            >
              Save
            </button>
          </div>

          <div class="btn btn-warning" @click="clear()">Clear</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import { Domain } from "@/constant/constant";

export default {
  props: {
    title: String,
    accounts: Array,
  },

  data() {
    return {
      form: {
        Done: "",
        Problem: "",
        Solution: "",
        Link: "",
        Account_ID: "",
        Teams_ID: "",
      },

      teams: [],

      errors: [],

      domain: Domain,
    };
  },

  /**
   * Call getDataByID Function
   */
  mounted() {
    if (this.$route.params.id != null) {
      this.getDataByID();
    }
  },

  /**
   *Add Team ID By Account ID
   */
  watch: {
    "form.Account_ID"(value) {
      const account = this.accounts.find((item) => item.ID === value);
      if (account) {
        this.form.Teams_ID = account.Teams_ID;
      }
    },
  },

  methods: {
    /**
     * Get Report By ID
     */
    getDataByID() {
      const urlDataByID = this.domain + "Report/GetReportByID/";
      axios
        .get(urlDataByID + this.$route.params.id)
        .then((res) => {
          this.form = res.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },

    /**
     * Update Report
     */
    async updateReport() {
      this.errors = [];
      this.validate();
      if (this.errors.length > 0) {
        alert(this.errors);
      } else {
        const urlEdit = this.domain + "Report/EditReport";
        await axios.put(urlEdit + "/" + this.$route.params.id, this.form);
        this.Back();
      }
    },

    /**
     * Create Report
     */
    async createReport() {
      this.errors = [];
      this.validate();
      if (this.errors.length > 0) {
        alert(this.errors);
      } else {
        const urlCreate = this.domain + "Report/CreateReport";
        await axios.post(urlCreate, this.form);
        this.Back();
      }
    },

    /**
     * Get back to list page
     */
    async Back() {
      await this.$router.push({
        path: "/reportManager/Report/List",
      });
    },

    /**
     * Clear input
     */
    clear() {
      this.form.Done = "";
      this.form.Problem = "";
      this.form.Solution = "";
      this.form.Link = "";
    },

    /**
     * Validate input
     */
    validate() {
      if (this.form.Done == "") {
        this.errors.push("Done không được để trống\n");
      }
      if (this.form.Problem == "") {
        this.errors.push("Problem không được để trống\n");
      }
      if (this.form.Solution == "") {
        this.errors.push("Solution không được để trống\n");
      }
      if (this.form.Link == "") {
        this.errors.push("Link không được để trống\n");
      }
      if (this.form.Account_ID == "") {
        this.errors.push("Account không được để trống");
      }
    },
  },
};
</script>

