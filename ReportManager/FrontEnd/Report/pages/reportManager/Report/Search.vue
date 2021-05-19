<template>
  <div class="container-fluid">
    <nav class="card">
      <div class="card-header">
        <h1 style="text-align: center">{{ title }}</h1>
      </div>

      <div class="card-body">
        <div>
          <search @dataReport="getData($event)"></search>
        </div>

        <div>
          <table-report
            :isFound="isFound"
            :dataReport="dataReport"
          ></table-report>
        </div>
      </div>
    </nav>
  </div>
</template>

<script>
import Search from "../../../components/Report/SearchReport.vue";
import TableReport from "../../../components/Report/TableReport.vue";

export default {
  components: { Search, TableReport },

  data() {
    return {
      title: "Report Search",
      dataReport: [],
      isFound: false,
    };
  },

  /**
   * Get Data Fron Search Report Component
   */
  methods: {
    getData(data) {
      this.dataReport = data;
      if (data == 0) {
        this.isFound = true;
      }
    },
  },
};
</script>

<style scoped>
.container-fluid {
  padding-left: 0px;
  padding-right: 0px;
}
</style>