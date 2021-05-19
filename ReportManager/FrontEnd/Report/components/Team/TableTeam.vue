<template>
  <div>
    <div>
      <table v-if="dataTeam.length > 0" class="table">
        <thead>
          <tr class="table-primary">
            <th scope="col">ID</th>
            <th scope="col">Team Name</th>
            <th scope="col">Action</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(team, index) in dataTeam" :key="team.id">
            <td scope="row">{{ index + 1 }}</td>
            <td>{{ team.Name }}</td>
            <td>
              <nuxt-link :to="`/reportManager/Team/${team.ID}`">
                <button
                  class="btn btn-info col-6 ml-5"
                  data-toggle="modal"
                  style="width: 10%"
                  data-target="#Edit"
                >
                  Edit
                </button></nuxt-link
              >

              <div
                class="btn btn-danger"
                style="width: 10%"
                @click="deleteTeam(team.ID)"
              >
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
  </div>
</template>

<script>
import { Domain } from "@/constant/constant";
import axios from "axios";

export default {
  props: {
    title: String,
    dataTeam: Array,
    isFound: Boolean,
    getTeam: Function,
  },

  data() {
    return {
      domain: Domain,
    };
  },

  methods: {
    /**
     * Delete Team
     */
    deleteTeam(id) {
      const url = this.domain + "Team/DeleteTeam";
      let conf = confirm("Xác Nhận Xóa");
      if (conf == true) {
        axios
          .delete(url, {
            params: {
              id,
            },
          })
          .then(
            this.$router.push({
              path: "/reportManager/Team/List",
            })
          )
          .then(() => {
            this.getTeam();
          });
      }
    },
  },
};
</script>
