<template>
  <div class="container-fluid">
    <h3>{{ title }}</h3>

    <!-- title -->
    <div class="form-group">
      <label class="col-2 ml-2">Tiêu đề</label>
      <div class="col-10">
        <input class="w-75 form-control" v-model="form.Title" type="text" />
      </div>
    </div>

    <!-- description -->
    <div class="form-group">
      <label class="col-2 ml-2">Mô tả ngắn</label>
      <div class="col-10">
        <input
          class="w-75 form-control"
          v-model="form.Description"
          type="text"
        />
      </div>
    </div>

    <!-- detail -->
    <div class="form-group">
      <label class="col-2 ml-2">Chi tiết</label>
      <div class="col-10">
        <textarea
          v-model="form.Detail"
          rows="10"
          class="form-control"
        ></textarea>
      </div>
    </div>

    <!-- thumbs -->
    <div class="form-group">
      <label class="col-2 ml-2">Hình ảnh</label>
      <div class="col-10">
        <button>Choose files</button>
      </div>
    </div>

    <!-- category -->
    <div class="form-group">
      <label class="col-2 ml-2">Loại</label>
      <div class="col-10">
        <select v-model="form.Category">
          <option
            v-for="(category, index) in dataCate"
            :value="index"
            :key="index"
          >
            {{ category }}
          </option>
        </select>
      </div>
    </div>

    <!-- position -->
    <div class="form-group">
      <label class="col-2 ml-2">Vị trí</label>
      <div v-for="position in dataPos" :key="position.index" class="col-10">
        <input
          type="checkbox"
          :value="position.value"
          v-model="form.Position"
        />
        <label>{{ position.name }}</label>
      </div>
    </div>

    <!-- public -->
    <div class="form-group">
      <label class="col-2 ml-2">Public</label>
      <div v-for="item in publics" :key="item.value" class="col-10">
        <input type="radio" :value="item.text" v-model="form.Publics" />
        <label>{{ item.text }}</label>
      </div>
    </div>

    <!-- date -->
    <div class="form-group">
      <label class="col-2 ml-2">Date Public</label>
      <div class="col-10">
        <input type="date" v-model="form.DatePublic" />

        <!-- button -->
        <div class="form-group d-flex justify-content-center">
          <!--  create button -->
          <button
            v-if="title === 'New Blogs'"
            type="button"
            class="btn btn-success mr-2"
            @click="postBlog()"
          >
            Submit
          </button>

          <!-- edit button -->
          <button
            v-if="title === 'Edit Blogs'"
            type="button"
            class="btn btn-success mr-2"
            @click="updateBlog()"
          >
            Submit
          </button>

          <button type="button" @click="clear()" class="btn btn-primary">
            Clear
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import { DATA_CATE } from "@/constants/constant.js";
import { DATA_POS } from "@/constants/constant.js";

export default {
  props: ["title"],

  data: function () {
    return {
      form: {
        Title: "",
        Description: "",
        Detail: "",
        Category: "",
        Publics: "",
        Position: [],
        DatePublic: "",
      },

      errors: [],

      DATA_CATE: DATA_CATE,
      DATA_POS: DATA_POS,

      //public array
      publics: [
        { text: "Yes", value: "Yes" },
        { text: "No", value: "No" },
      ],
    };
  },

  computed: {
    /**
     * Lay Data cua Category
     */
    dataCate: function () {
      return this.DATA_CATE;
    },

    /**
     * Lay Data cua Position
     */
    dataPos: function () {
      return this.DATA_POS;
    },
  },

  /**
   * Truyen Data Blog can Edit vao cac Input
   */
  created() {
    if (this.$route.params.id >= 0) {
      this.getBlogByID();
    }
  },

  methods: {
    /**
     * Post Blog
     */
    postBlog() {
      this.errors = [];
      this.validate();
      if (this.errors.length > 0) {
        return alert(this.errors);
      } else {
        const url = "https://localhost:44308/api/Blog/CreateBlog";
        let model = this.form;
        model.Position = JSON.stringify(this.form.Position);
        axios({
          method: "post",
          url: url,
          data: model,
        });
        this.$router.push({ path: "/blog/list" });
      }
    },

    /**
     * Clear Input
     */
    clear() {
      this.form.Title = "";
      this.form.Description = "";
      this.form.Detail = "";
      this.form.Category = "";
      this.form.Publics = "";
      this.form.Position = [];
      this.form.DatePublic = "";
    },

    /**
     * Get Blog By ID
     */
    getBlogByID() {
      const url = "https://localhost:44308/api/Blog/GetBlogByID";
      axios
        .get(url, { params: { id: this.$route.params.id } })
        .then((response) => {
          this.form = response.data;
          this.form.Position = JSON.parse(this.form.Position);
        });
    },

    /**
     * Put Blog
     */
    updateBlog() {
      this.errors = [];
      this.validate();
      if (this.errors.length > 0) {
        return alert(this.errors);
      } else {
        const url = "https://localhost:44308/api/Blog/EditBlog";
        this.form.Position = JSON.stringify(this.form.Position);
        axios.put(url + "/" + this.$route.params.id, this.form);
        this.$router.push({ path: "/blog/list" });
      }
    },

    /**
     * Validate Input
     */
    validate() {
      if (this.form.Title == "") {
        this.errors.push("tiêu đề không được trống\n");
      }
      if (this.form.Description == "") {
        this.errors.push("mô tả ngắn không được trống\n");
      }
      if (this.form.Detail == "") {
        this.errors.push("chi tiết không được trống\n");
      }
      if (this.form.Category == -1) {
        this.errors.push("loại không được trống\n");
      }
      if (this.form.Publics == "") {
        this.errors.push("public không được trống\n");
      }
      if (this.form.DatePublic == "") {
        this.errors.push("date public không được trống\n");
      }
      if (this.form.Position == []) {
        this.errors.push("vị trí không được trống\n");
      }
    },
  },
};
</script>
