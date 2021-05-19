<template>
  <div class="blog" id="blog">
    <div class="container-fluid">
      <h1 class="text-center">BLOG <span>DIGIDINOS</span></h1>

      <div class="row">
        <div class="col" v-for="blog in blogsData" :key="blog.index">
          <div class="card text-white bg-transparent border-light">
            <div class="card-img">
              <img
                src="https://webitkurigram.com/html/visapro/assets/images/blog1.jpg"
                class="img-fluid"
              />
            </div>

            <div class="card-body">
              <h4 class="card-title text-white">
                {{ blog.Title }}
              </h4>
              <p class="card-text">
                {{ blog.Content }}
              </p>
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
  </div>
</template>

<script>
import axios from "axios";
import { URL_DeleteBlog, URL_GetAllBlog } from "../../common/Url";
import moment from "moment";

export default {
  data() {
    return {
      blogsData: [],
    };
  },

  mounted() {
    this.getBlogs();
  },

  methods: {
    /**
     * Get Blogs
     */
    async getBlogs() {
      const res = await axios.get(URL_GetAllBlog);
      this.blogsData = res.data;
    },

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
          this.getBlogs();
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
.blog {
  margin: 4em 0;
  position: relative;
}

.blog h1 {
  color: white;
  margin-top: 6em;
  margin-bottom: 2em;
}

.blog span {
  color: #28a7e9;
}

.blog .card img {
  width: 100%;
  height: 12em;
}

.blog .card-title {
  color: black;
}

.blog .card-body {
  padding: 1em;
}

.blog .container-fluid {
  padding-left: 5%;
  padding-right: 5%;
}
</style>