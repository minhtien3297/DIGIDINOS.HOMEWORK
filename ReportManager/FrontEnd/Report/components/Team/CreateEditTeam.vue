<template>
<div class="card">
    <div class="card-header">
        <h1>{{ title }}</h1>
    </div>

    <div class="card-body">
        <div class="form-group row">
            <label class="col-sm-2 col-form-label"><b>Name:</b></label>
            <div class="col-10">
                <input type="text" class="form-control" v-model="form.Name" placeholder="Input Team" />
            </div>
        </div>
        <br />
        <div class="d-flex justify-content-center">
            <div>
                <button v-if="title == 'Edit Team'" id="a" class="btn btn-primary mr-3" @click="updateTeam()">
                    Save
                </button>

                <button v-if="title == 'Create Team'" id="a" class="btn btn-primary mr-3" @click="createTeam()">
                    Save
                </button>
            </div>
            <div class="btn btn-warning" @click="clear()">Clear</div>
        </div>
        <br />
    </div>
</div>
</template>

<script>
import axios from "axios";
import {
    Domain
} from "@/constant/constant";

export default {
    props: ["title"],

    data() {
        return {
            form: {
                Name: "",
            },

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

    methods: {
        /**
         * Get Team By ID
         */
        getDataByID() {
            const urlDataByID = this.domain + "Team/GetTeamByID/";
            axios(urlDataByID + this.$route.params.id)
                .then((res) => {
                    this.form = res.data;
                })
                .catch((err) => {
                    console.log(err);
                });
        },

        /**
         * Update Team
         */
        async updateTeam() {
            this.errors = [];
            this.validate();
            if (this.errors.length > 0) {
                alert(this.errors);
            } else {
                const urlEdit = this.domain + "Team/EditTeam";
                await axios.put(urlEdit + "/" + this.$route.params.id, this.form);
                await this.$router.push({
                    path: "/reportManager/Team/List",
                });
            }
        },

        /**
         * Create Team
         */
        async createTeam() {
            this.errors = [];
            this.validate();
            if (this.errors.length > 0) {
                alert(this.errors);
            } else {
                const urlCreate = this.domain + "Team/CreateTeam";
                await axios.post(urlCreate, this.form);
                await this.$router.push({
                    path: "/reportManager/Team/List",
                });
            }
        },

        /**
         * Clear input
         */
        clear() {
            this.form.Name = "";
        },

        /**
         * Validate input
         */
        validate() {
            if (this.form.Name == "") {
                this.errors.push("Name không được để trống");
            }
        },
    },
};
</script>
