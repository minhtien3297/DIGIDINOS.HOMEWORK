<template>
<div class="card">
    <div class="card-header">
        <div class="row">
            <h2 class="col">{{ title }}</h2>

            <div class="col">
                <nuxt-link class="btn btn-info ml-3" to="/reportManager/Team/New" style="width: 20%; float: right">New</nuxt-link>

                <nuxt-link class="btn btn-info" to="/reportManager/Team/Search" style="width: 20%; float: right">Search</nuxt-link>
            </div>
        </div>
    </div>
   <div class="card-body">
    <table-team :dataTeam="dataTeam" :title="title" :getTeam="getTeam"></table-team>
    </div>
</div>
</template>

<script>
import TableTeam from "../../../components/Team/TableTeam";
import axios from "axios";
import {
    Domain
} from "@/constant/constant";

export default {
    components: {
        TableTeam,
    },

    data() {
        return {
            dataTeam: [],
            title: "Team List",
            domain: Domain,
        };
    },

    /**
     * Call listData Function
     */
    mounted() {
        this.getTeam();
    },

    methods: {
        /**
         * Get All Team
         */
        getTeam() {
            axios({
                    method: "GET",
                    url: this.domain + "Team/GetAllTeam",
                })
                .then((res) => {
                    this.dataTeam = res.data;
                })
                .catch((err) => {
                    console.log(err);
                });
        },
    },
};
</script>
