<template>
  <edit-team :title="title"></edit-team>
</template>

<script>
import EditTeam from "../../../components/Team/CreateEditTeam.vue";
export default {
  data() {
    return {
      title: "Edit Team"
    };
  },
  components: { EditTeam },
};
</script>