<template>
  <div class="container-fluid">
    <!-- search -->
    <div v-if="isVisible" class="container-fluid mb-3 px-0">
      <h3>Search Blogs</h3>

      <div class="row my-5">
        <div class="col-2">
          <label>Tiêu đề</label>
        </div>

        <div class="col-10">
          <input
            class="w-100"
            placeholder="Tiêu đề"
            v-model="titleSearchString"
          />
        </div>
      </div>

      <button
        type="button"
        @click="filteredBlog()"
        class="btn btn-success mb-3"
      >
        Search
      </button>

      <table v-if="filteredBlogs.length > 0" class="table table-bordered">
        <thead>
          <tr>
            <th scope="col">ID</th>
            <th scope="col">Tin</th>
            <th scope="col">Loại</th>
            <th scope="col">Trạng thái</th>
            <th scope="col">Vị trí</th>
            <th scope="col">Ngày public</th>
            <th scope="col">Edit</th>
            <th scope="col">Delete</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="blog in filteredBlogs" :key="blog.BlogID">
            <th scope="row">{{ blog.BlogID }}</th>
            <td>{{ blog.Title }}</td>
            <td>
              <div v-for="(cate, key) in dataCate" :key="key + 1">
                <p v-if="key == blog.Category">{{ cate }}</p>
              </div>
            </td>
            <td v-if="blog.Publics == 'Yes'">Yes</td>
            <td v-else>No</td>
            <td>
              <div v-for="(posit, idxPos) in blog.Position" :key="idxPos">
                <div v-for="(pos, key, index) in dataPos" :key="index">
                  <p v-if="key == posit">{{ pos.name }}</p>
                </div>
              </div>
            </td>
            <td>{{ blog.DatePublic }}</td>
            <td>
              <nuxt-link :to="`/blog/${blog.BlogID}`">Edit</nuxt-link>
            </td>
            <td>
              <button
                type="button"
                class="btn btn-outline-danger"
                @click="deleteBlog(blog.BlogID)"
              >
                Delete
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>

    <!-- list -->
    <div v-if="!isVisible" class="container-fluid">
      <h3>List BLogs</h3>
      <table class="table table-bordered">
        <thead>
          <tr>
            <th scope="col">ID</th>
            <th scope="col">Tin</th>
            <th scope="col">Loại</th>
            <th scope="col">Trạng thái</th>
            <th scope="col">Vị trí</th>
            <th scope="col">Ngày public</th>
            <th scope="col">Edit</th>
            <th scope="col">Delete</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="blog in blogs" :key="blog.BlogID">
            <th scope="row">{{ blog.BlogID }}</th>
            <td>{{ blog.Title }}</td>
            <td>
              <div v-for="(cate, key) in dataCate" :key="key + 1">
                <p v-if="key == blog.Category">{{ cate }}</p>
              </div>
            </td>
            <td v-if="blog.Publics == 'Yes'">Yes</td>
            <td v-else>No</td>
            <td>
              <div v-for="(posit, idxPos) in blog.Position" :key="idxPos">
                <div v-for="(pos, key, index) in dataPos" :key="index">
                  <p v-if="key == posit - 1">{{ pos.name }}</p>
                </div>
              </div>
            </td>
            <td>{{ blog.DatePublic }}</td>
            <td>
              <nuxt-link :to="`/blog/${blog.BlogID}`">Edit</nuxt-link>
            </td>
            <td>
              <button
                type="button"
                class="btn btn-outline-danger"
                @click="deleteBlog(blog.BlogID)"
              >
                Delete
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import { DATA_CATE } from "@/constants/constant.js";
import { DATA_POS } from "@/constants/constant.js";

export default {
  props: {
    isVisible: Boolean,
    blogs: Array,
    getBlogs: Function,
  },

  data() {
    return {
      titleSearchString: "",
      filteredBlogs: [],
      DATA_CATE: DATA_CATE,
      DATA_POS: DATA_POS,
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

  methods: {
    /**
     * Delete Blog
     * @param {int} Blog ID
     */
    deleteBlog(id) {
      const url = "https://localhost:44308/api/Blog/DeleteBlog";
      axios.delete(url, { params: { id } }).then(() => {
        this.getBlogs();
      });
    },

    /**
     * Search Blog
     */
    filteredBlog() {
      const url = "https://localhost:44308/api/Blog/SearchByTitle";
      let searchString = this.titleSearchString ? this.titleSearchString : null;
      axios.get(url + "?title=" + searchString).then((response) => {
        this.filteredBlogs = response.data;
      });
    },
  },
};
</script>