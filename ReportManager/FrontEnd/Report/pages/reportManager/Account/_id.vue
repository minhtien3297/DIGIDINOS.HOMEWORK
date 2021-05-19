<template>
<create-edit :title="title"></create-edit>
</template>

<script>
import CreateEdit from "../../../components/Account/CreateEdit.vue";

export default {
    data() {
        return {
            title: "Edit Account",
        };
    },

    components: {
        CreateEdit
    },
}
</script>

<style>

</style>
