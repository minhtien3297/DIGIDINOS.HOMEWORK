<template>
  <div class="card mt-5">
    <h1 class="card-header">Comment</h1>
    <div class="card-body">
      <!-- Comments -->
      <div v-if="Comments.length > 0">
        <div
          class="card mt-3"
          v-for="(comment, index) in Comments"
          :key="comment.id"
        >
          <div class="card-header" style="border: 0px">
            <h3 class="card-title mb-2">
              {{ index + 1 }}. {{ comment.Accounts_ID }}
            </h3>
          </div>

          <div class="card-body">
            <div class="row">
              <div class="col-10">
                <p class="card-text">{{ comment.Contents }}</p>
              </div>

              <div class="col-2">
                <button class="btn btn-danger" @click="deleteCmt(comment.ID)">
                  Delete
                </button>
              </div>
            </div>
          </div>

          <div class="card-footer">
            <small class="text-muted">{{ convertDate(comment.Dates) }}</small>
          </div>
        </div>
      </div>

      <!-- Comment input -->
      <div class="form-group">
        <label class="mt-5"><h3>New Comment:</h3></label>

        <textarea
          class="form-control"
          v-model="formComment.Contents"
          placeholder="Input Comment"
        ></textarea>

        <div class="row mt-3">
          <div class="col-1">
            <div class="btn btn-primary" @click="Back()">Back</div>
          </div>

          <div class="col -11 d-flex justify-content-center">
            <button
              class="btn btn-primary"
              @click="createCmt()"
              style="width: 100px"
            >
              Comment
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import moment from "moment";
import { Domain } from "@/constant/constant";
import axios from "axios";

export default {
  props: {
    formComment: Object,
    Comments: Array,
    formReport: Object,
    getCmtByID: Function,
  },

  data() {
    return {
      errors: [],
      domain: Domain,
    };
  },

  methods: {
    /**
     * Create Comment
     */
    async createCmt() {
      this.errors = [];
      this.validate();
      if (this.errors.length > 0) {
        alert(this.errors);
      } else {
        const urlCreateCmt = this.domain + "Comment/CreateComment";

        await axios.post(urlCreateCmt, this.formComment);
        this.getCmtByID();
        this.formComment.Contents = "";
      }
    },

    /**
     *Delete Comment
     */
    async deleteCmt(id) {
      const urlDeleteCmt = this.domain + "Comment/DeleteComment";

      await axios.delete(urlDeleteCmt, { params: { id } });
      this.getCmtByID();
    },

    /**
     * Get back to list page
     */
    async Back() {
      await this.$router.push({
        path: "/reportManager/Report/List",
      });
    },

    /**
     * Validate Cmt input
     */
    validate() {
      if (this.formComment.Contents == "") {
        this.errors.push("Không để trống Comment");
      }
    },

    /**
     * Convert Date
     */
    convertDate(date) {
      date = moment(String(date)).format("DD/MM/YYYY");
      return date;
    },
  },
};
</script>