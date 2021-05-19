<template>
  <div class="container-fluid">
    <!-- Done -->
    <div class="form-group row">
      <label class="col-sm-2 col-form-label"><b>Done:</b></label>
      <div class="col-10">
        <textarea class="form-control" v-model="formReport.Done" disabled>
        </textarea>
      </div>
    </div>

    <!-- Problem -->
    <div class="form-group row">
      <label class="col-sm-2 col-form-label"><b>Problem:</b></label>
      <div class="col-10">
        <textarea class="form-control" v-model="formReport.Problem" disabled>
        </textarea>
      </div>
    </div>

    <!-- Solution -->
    <div class="form-group row">
      <label class="col-sm-2 col-form-label"><b>Solution:</b></label>
      <div class="col-10">
        <textarea class="form-control" v-model="formReport.Solution" disabled>
        </textarea>
      </div>
    </div>

    <!-- Link -->
    <div class="form-group row">
      <label class="col-sm-2 col-form-label"><b>Link:</b></label>
      <div class="col-10">
        <textarea class="form-control" v-model="formReport.Link" disabled>
        </textarea>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    formReport: Object,
  },
};
</script>