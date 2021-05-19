<template>
<div class="card">
    <search @dataTeam="getData($event)" :title="tilte"></search>

    <div class="card-body2">
        <table-team :isFound="isFound" :dataTeam="dataTeam"></table-team>
    </div>
</div>
</template>

<script>
import Search from "../../../components/Team/SearchTeam.vue";
import TableTeam from "../../../components/Team/TableTeam.vue";

export default {
    components: {
        Search,
        TableTeam
    },

    data() {
        return {
            tilte: "Team Search",
            dataTeam: [],
            isFound: false,
        };
    },

    /**
     * Get Data Fron Search Team Component
     */
    methods: {
        getData(data) {
            this.dataTeam = data;
            if (data == 0) {
                this.isFound = true;
            }
        },
    },
};
</script>
