<template>
  <create-edit-team :title="title"></create-edit-team>
</template>

<script>
import CreateEditTeam from "../../../components/Team/CreateEditTeam.vue";
export default {
  data() {
    return {
      title: "Create Team",
    };
  },
  components: {
    CreateEditTeam,
  },
};
</script>
