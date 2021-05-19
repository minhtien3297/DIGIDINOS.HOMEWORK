<template>
  <nav>
    <div class="card-header">
      <h1 style="text-align: center">{{ title }}</h1>
</div>
    <div class="card-body1">
      <div class="form-inline">
        <input
          class="form-control mr-sm-2"
          type="search"
          placeholder="Search"
          aria-label="Search"
          v-model="searchString"
        />

        <button class="btn btn-outline-success my-2 my-sm-0" @click="search()">
          Search
        </button>
      </div>
    </div>
  </nav>
</template>

<script>
import { Domain } from "@/constant/constant";
import axios from "axios";

export default {
  props: ["title"],

  data() {
    return {
      searchString: "",
      domain: Domain,
    };
  },

  /**
   * Search Team By Name Then Send Data to Search Team Page
   */
  methods: {
    search() {
      const url = this.domain + "Team/SearchByName";
      axios.get(url + "?name=" + this.searchString).then((response) => {
        this.$emit("dataTeam", response.data);
      });
    },
  },
};
</script>
