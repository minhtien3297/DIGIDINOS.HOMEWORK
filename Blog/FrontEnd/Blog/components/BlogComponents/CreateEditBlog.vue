<template>
  <div class="create-edit">
    <div class="card">
      <div class="card-header">
        <div v-if="title === 'Edit Blog'">
          <p>Edit Blog</p>
        </div>
        <div v-if="title === 'Create New Blog'">
          <p>Create New Blog</p>
        </div>
      </div>

      <div class="card-body container">
        <!-- Title -->
        <div class="form-group row">
          <label class="col-sm-2 col-form-label"><b>Title</b></label>
          <div class="col-10">
            <input
              class="form-control"
              @change="error()"
              v-model="blogs.Title"
              type="text"
            />
          </div>
        </div>

        <!-- Content -->
        <div class="form-group row">
          <label class="col-sm-2 col-form-label"><b>Content</b></label>
          <div class="col-10">
            <input
              class="form-control"
              @change="error()"
              v-model="blogs.Content"
              type="text"
            />
          </div>
        </div>

        <!-- Time -->
        <div class="form-group row">
          <label class="col-sm-2 col-form-label"><b>Date</b></label>
          <div class="col-10">
            <input
              type="date"
              class="form-control"
              @change="error()"
              v-model="blogs.Times"
            />
          </div>
        </div>

        <!-- Image -->
        <div class="form-group row" v-if="title === 'Create New Blog'">
          <label class="col-sm-2 col-form-label"><b>Select Image:</b></label>
          <div class="col-10">
            <input
              type="file"
              id="img"
              name="img"
              @change="error()"
              accept="image/*"
            />
          </div>
        </div>

        <!-- Image -->
        <div class="form-group row" v-if="title === 'Edit Blog'">
          <label class="col-sm-2 col-form-label"><b>Select Image:</b></label>
          <div class="col-10">
            <input
              type="file"
              id="img"
              name="img"
              @change="error()"
              :v-model="blogs.img"
              accept="image/*"
            />
          </div>
        </div>
        <div class="form-group row" v-if="title === 'Edit Blog'">
          <label class="col-sm-2 col-form-label"><b>Image preview:</b></label>
          <div class="col-10">
            <img
              src="{{}}"
              alt="ảnh chưa được tải lên hoặc không có trong hệ thống"
            />
          </div>
        </div>

        <!-- Button -->
        <div>
          <!-- create button -->
          <button
            v-if="title === 'Create New Blog'"
            type="button"
            style="margin-left: 45%"
            class="btn btn-primary mr-3"
            @click="postBlog()"
          >
            Create
          </button>

          <!-- edit button -->
          <button
            v-if="title === 'Edit Blog'"
            type="button"
            style="margin-left: 45%"
            class="btn btn-primary mr-3"
            @click="updateBlog()"
          >
            Update
          </button>

          <!-- clear button -->
          <button type="button" @click="clear()" class="btn btn-warning mr-3">
            Clear
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import moment from "moment";
import {
  URL_GetBlogByID,
  URL_EditBlog,
  URL_CreateBlog,
} from "../../common/Url";

export default {
  props: ["title"],

  data() {
    return {
      blogs: {
        Image: "",
        Title: "",
        Times: "",
        Content: "",
      },

      errors: [],
    };
  },

  mounted() {
    if (this.$route.params.id) {
      axios.get(URL_GetBlogByID + this.$route.params.id).then((response) => {
        this.blogs = response.data;
        this.blogs.Times = this.convertDate(this.blogs.Times);
        console.log("trước", this.blogs.Times);
      });
    }
  },

  methods: {
    updateBlog() {
      this.errors = [];
      this.error();

      if (this.errors.length > 0) {
        alert(this.errors);
      } else {
        axios.put(URL_EditBlog, this.blogs).catch((err) => {
          console.error(err);
        });
        console.log("sau", this.blogs.Times);

        this.$router.push("/Blog/list");
      }
    },

    postBlog() {
      this.errors = [];
      this.error();

      if (this.errors.length > 0) {
        alert(this.errors);
      } else {
        this.blogs.Times = this.convertDate(this.blogs.Times);

        axios
          .post(URL_CreateBlog, this.blogs)
          .then(() => {
            alert("Tạo mới thành công");
            this.$router.push("/Blog/list");
          })
          .catch(function (error) {
            alert(error);
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

    /**
     * `validate` will check model
     */
    error() {
      console.log(this.blogs.Times);
      if (this.blogs.Title == "") {
        this.errors.push("Title không được để trống\n");
      }
      if (this.blogs.Times == "") {
        this.errors.push("Date time không được để trống\n");
      }
      if (this.blogs.Content == "") {
        this.errors.push("Content không được để trống\n");
      }
    },

    /**
     * `clear` will clear component
     */
    clear() {
      this.blogs.Title = "";
      this.blogs.Content = "";
      this.blogs.Times = "";
      this.blogs.Img = "";
    },
  },
};
</script>

<style>
.create-edit .card {
  height: 75vh;
}
</style>