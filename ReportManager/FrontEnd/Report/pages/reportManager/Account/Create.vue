<template>
<create :title="title"></create>
</template>

<script>
import Create from "../../../components/Account/CreateEdit.vue";
export default {
    components: {
        Create,
    },

    data() {
        return {
            title: "Create New Account",
        };
    },
};
</script>

<style>
</style>