<template>
  <div class="mt-3">
    <table v-if="dataReport.length > 0" class="table">
      <thead class="table-primary">
        <tr>
          <th scope="col">ID</th>
          <th scope="col">Done</th>
          <th scope="col">Problem</th>
          <th scope="col">Solution</th>
          <th scope="col">Link</th>
          <th scope="col">Date</th>
          <th scope="col">Account</th>
          <th scope="col">Team</th>
          <th scope="col">Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(reports, index) in dataReport" :key="reports.id">
          <td>{{ index + 1 }}</td>
          <td>{{ reports.Done }}</td>
          <td>{{ reports.Problem }}</td>
          <td>{{ reports.Solution }}</td>
          <td>{{ reports.Link }}</td>
          <td>{{ convertDate(reports.Dates) }}</td>
          <td>{{ reports.Account_ID }}</td>
          <td>{{ reports.Teams_ID }}</td>
          <td class="row d-flex justify-content-center">
            <nuxt-link :to="`/reportManager/Report/${reports.ID}`">
              <button class="btn btn-info mr-2" style="width: 70px">
                Edit
              </button></nuxt-link
            >

            <nuxt-link :to="`/reportManager/Report/Detail/${reports.ID}`">
              <button class="btn btn-primary mr-2" style="width: 70px">
                Detail
              </button></nuxt-link
            >

            <div class="btn btn-danger" @click="deleteReport(reports.ID)">
              Delete
            </div>
          </td>
        </tr>
      </tbody>
    </table>
    <div v-else-if="isFound" class="alert alert-danger" role="alert">
      Không tìm thấy
    </div>
  </div>
</template>

<script>
import { Domain } from "@/constant/constant";
import axios from "axios";
import moment from "moment";

export default {
  props: {
    title: String,
    dataReport: Array,
    isFound: Boolean,
    getReport: Function,
  },

  data() {
    return {
      domain: Domain,
    };
  },

  methods: {
    /**
     * Convert Date
     */
    convertDate(date) {
      date = moment(String(date)).format("DD/MM/YYYY");
      return date;
    },

    /**
     * Delete Report
     */
    deleteReport(id) {
      const url = this.domain + "Report/DeleteReport";

      let confirmDelete = confirm("Bạn có chắc chắn muốn xoá ?");
      if (confirmDelete == true) {
        axios
          .delete(url, { params: { id } })
          .then(
            this.$router.push({
              path: "/reportManager/Report/List",
            })
          )
          .then(() => {
            this.getReport();
          });
      }
    },
  },
};
</script>
