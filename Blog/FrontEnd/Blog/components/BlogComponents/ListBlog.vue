<template>
  <div class="listBlog">
    <div class="container">
      <div v-for="(blog, index) in DATALIST" :key="index">
        <div class="card m-5">
          <img
            src="https://webitkurigram.com/html/visapro/assets/images/blog1.jpg"
            class="rounded"
            alt="không thể hiển thị ảnh"
          />
          <div class="card-body">
            <div class="text-left">
              <h2>
                <p class="title-blog">{{ blog.Title }}</p>
              </h2>
              <p>
                {{ blog.Content }}
              </p>
            </div>
          </div>
          <div class="card-footer text-center">
            <p class="card-text">
              <small class="text-muted"> {{ convertDate(blog.Times) }}</small>
            </p>
            <div class="btn btn-primary" @click="editBlog(blog.ID)">Edit</div>
            <div class="btn btn-danger" @click="deleteBlog(blog.ID)">
              Delete
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { URL_DeleteBlog } from "../../common/Url";
import axios from "axios";
import moment from "moment";

export default {
  props: {
    DATALIST: Array,
    getBlog: Function,
  },

  data() {
    return {};
  },

  methods: {
    /**
     * Edit Blog
     */
    editBlog(id) {
      this.$router.push("/Blog/" + id);
    },

    /**
     * Delete Blog
     */
    deleteBlog(id) {
      const url = URL_DeleteBlog;
      let confirmDelete = confirm("Bạn có chắc chắn muốn xoá ?");
      if (confirmDelete == true) {
        axios.delete(url, { params: { id } }).then(() => {
          this.getBlog();
        });
      }
    },

    /**
     * `Convert Date` wwil convert date time to dd/mm/yyyy
     */
    convertDate(date) {
      if (date === "") return "";

      date = date.substring(0, 10);
      return date;
    },
  },
};
</script>

<style>
.listBlog .title-blog {
  text-align: left;
  font-size: 20px;
  font-weight: 700;
  display: block;
  color: #232323;
  transition: 0.3s;
  margin-top: -8px;
}
</style>