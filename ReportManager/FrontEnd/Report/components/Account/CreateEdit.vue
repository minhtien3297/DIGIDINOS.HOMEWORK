<template>
  <div class="card">
    <div class="card-header">
      <h3>{{ title }}</h3>
    </div>
    <div class="card-body">
      <!-- username -->
      <div class="form-group row">
        <label class="col-sm-2 col-form-label"><b>Username</b></label>
        <div class="col-10">
          <input
            class="form-control"
            id="title"
            v-model="form.Username"
            type="text"
          />
        </div>
      </div>

      <!-- passwords -->
      <div class="form-group row">
        <label class="col-sm-2 col-form-label"><b>Password</b></label>
        <div class="col-10">
          <input
            class="form-control"
            id="password"
            v-model="form.Password"
            type="text"
          />
        </div>
      </div>

      <!-- first_name -->
      <div class="form-group row">
        <label class="col-sm-2 col-form-label"><b>First Name</b></label>
        <div class="col-10">
          <input
            class="form-control"
            id="first_name"
            v-model="form.FirstName"
            type="text"
          />
        </div>
      </div>

      <!-- last_name -->
      <div class="form-group row">
        <label class="col-sm-2 col-form-label"><b>Last Name</b></label>
        <div class="col-10">
          <input
            class="form-control"
            id="last_name"
            v-model="form.LastName"
            type="text"
          />
        </div>
      </div>

      <!-- age -->
      <div class="form-group row">
        <label class="col-sm-2 col-form-label"><b>Age</b></label>
        <div class="col-10">
          <input class="form-control" id="age" v-model="form.Age" type="text" />
        </div>
      </div>

      <!-- sex -->
      <fieldset class="form-group row">
        <legend class="col-form-label col-sm-2 float-sm-left pt-0">
          <b>Sex</b>
        </legend>
        <div class="form-check" style="margin-left: 40px">
          <input
            class="form-check-input"
            type="radio"
            name="gridRadios"
            id="gridRadios1"
            v-model="form.Sex"
            :value="sexs[1].number"
            checked
          />
          <label class="form-check-label" for="gridRadios1">
            {{ sexs[1].text }}
          </label>
        </div>
        <div class="form-check" style="margin-left: 40px">
          <input
            class="form-check-input"
            type="radio"
            name="gridRadios"
            id="gridRadios2"
            v-model="form.Sex"
            :value="sexs[0].number"
          />
          <label class="form-check-label" for="gridRadios2">
            {{ this.sexs[0].text }}
          </label>
        </div>
        <div class="form-check disabled" style="margin-left: 40px">
          <input
            class="form-check-input"
            type="radio"
            name="gridRadios"
            id="gridRadios3"
            v-model="form.Sex"
            :value="sexs[2].number"
          />
          <label class="form-check-label" for="gridRadios3">
            {{ this.sexs[2].text }}
          </label>
        </div>
      </fieldset>

      <!-- mail -->
      <div class="form-group row">
        <label class="col-sm-2 col-form-label"><b>Mail</b></label>
        <div class="col-10">
          <input
            class="form-control"
            id="mail"
            v-model="form.Mail"
            type="text"
          />
        </div>
      </div>

      <!-- addresss -->
      <div class="form-group row">
        <label class="col-sm-2 col-form-label"><b>Address</b></label>
        <div class="col-10">
          <input
            class="form-control"
            id="address"
            v-model="form.Address"
            type="text"
          />
        </div>
      </div>

      <!-- roles -->
      <div class="form-group row">
        <label class="col-sm-2 col-form-label"><b>Role</b></label>
        <div class="col-10">
          <select
            id="caterogy"
            style="width: 20%; height: 40px"
            v-model="form.Role"
          >
            <option
              v-for="(role, index) in roles"
              :value="role.number"
              :key="index"
            >
              {{ role.text }}
            </option>
          </select>
        </div>
      </div>

      <!-- teams -->
      <div class="form-group row">
        <label class="col-sm-2 col-form-label"><b>Team</b></label>
        <div class="col-10">
          <select
            id="caterogy"
            style="width: 20%; height: 40px"
            v-model="form.Teams_ID"
          >
            <option v-for="team in teams" :value="team.ID" :key="team.ID">
              {{ team.Name }}
            </option>
          </select>
        </div>
      </div>

      <!-- status -->
      <div class="form-group row">
        <label class="col-sm-2 col-form-label"><b>Status</b></label>
        <div class="col-10">
          <select
            id="caterogy"
            style="width: 20%; height: 40px"
            v-model="form.Status"
          >
            <option
              v-for="(stt, index) in status"
              :value="stt.number"
              :key="index"
            >
              {{ stt.text }}
            </option>
          </select>
        </div>
      </div>

      <!-- button -->
      <!--  create button -->
      <button
        v-if="title === 'Create New Account'"
        type="button"
        style="margin-left: 45%"
        class="btn btn-primary mr-3"
        @click="postAccount()"
      >
        Create
      </button>

      <!-- edit button -->
      <button
        v-if="title === 'Edit Account'"
        type="button"
        style="margin-left: 45%"
        class="btn btn-primary mr-3"
        @click="updateAccount()"
      >
        Update
      </button>

      <!--  clear button -->
      <button type="button" @click="clear()" class="btn btn-warning">
        Clear
      </button>
    </div>
  </div>
</template>

<script>
//#region Import
import axios from "axios";

export default {
  props: ["title"],

  data() {
    return {
      messError: "",

      form: {
        Username: "",
        Password: "",
        Address: "",
        Role: "",
        FirstName: "",
        LastName: "",
        Mail: "",
        Age: 0,
        Sex: "",
        Status: 0,
        Teams_ID: "",
      },

      sexs: [
        {
          number: 0,
          text: "Nữ",
        },
        {
          number: 1,
          text: "Nam",
        },
        {
          number: 2,
          text: "Khác",
        },
      ],

      roles: [
        {
          number: 0,
          text: "Quản lý",
        },
        {
          number: 1,
          text: "Nhân viên",
        },
      ],

      errors: [],

      teams: [], // lấy data teams từ API của teams

      status: [
        {
          number: 0,
          text: "Không khóa",
        },
        {
          number: 1,
          text: "Khóa",
        },
      ],
    };
  },

  mounted() {
    this.getAccount();
    this.getTeam();
  },

  methods: {
    // validate
    validate() {
      if (this.form.Username == "") {
        this.errors.push("Username không được để trống\n");
      }
      if (this.form.Password == "") {
        this.errors.push("Password không được để trống\n");
      }
      if (this.form.Teams_ID == "") {
        this.errors.push("Team không được để trống\n");
      }
      if (this.form.Address == "") {
        this.errors.push("Address không được để trống\n");
      }
      if (this.form.FirstName == "") {
        this.errors.push("FirstName không được để trống\n");
      }
      if (this.form.LastName == "") {
        this.errors.push("LastName không được để trống\n");
      }
      if (this.form.Mail == "") {
        this.errors.push("Mail không được để trống\n");
      }
      if (this.form.Age <= 0) {
        this.errors.push("Age phải lớn hơn 0\n");
      }
    },

    /**
     * clear textbox into form
     *
     * @since 7-3-2021
     * @author Vu Doan
     */
    clear: function () {
      this.form.Username = "";
      this.form.Password = "";
      this.form.Addresss = "";
      this.form.Role = "";
      this.form.First_name = "";
      this.form.Last_name = "";
      this.form.Mail = "";
      this.form.Age = 0;
      this.form.Sex = 0;
    },

    /**
     * get team name from API
     * @return team name
     *
     * @since 9-3-2021
     * @author Vu Doan
     */
    getTeam() {
      axios
        .get("https://localhost:44343/api/Team/GetAllTeam")
        .then((response) => {
          this.teams = response.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },

    /**
     * add data to list form account
     * @return result of CONST_getAccounts()
     *
     * @since 9-3-2021
     * @author Vu Doan
     */
    getAccount: function () {
      if (this.$route.params.id) {
        axios
          .get(
            "https://localhost:44343/api/Account/GetAccountByID/" +
              this.$route.params.id
          )
          .then((response) => {
            this.form = response.data;
            this.getTeam();
          })
          .catch((err) => {
            console.log(err);
          });
      }
    },

    /**
     * add account into [accounts list]
     * @params null
     * @return result of CONST_postAccounts()
     *
     * @since 9-3-2021
     * @author Vu Doan
     */
    postAccount: function () {
      this.errors = [];
      this.validate();
      if (this.errors.length > 0) {
        alert(this.errors);
      } else {
        axios
          .post("https://localhost:44343/api/Account/CreateAccount", this.form)
          .then(() => {
            alert("thêm thành công");
          });
        this.$router.push("/reportManager/Account/List");
      }
    },

    /**
     * update data of account
     * @params id: id of account
     * @return result of CONST_updateAccount()
     *
     * @since 9-3-2021
     * @author Vu Doan
     */
    updateAccount: function (id) {
      this.errors = [];
      this.validate();
      if (this.errors.length > 0) {
        alert(this.errors);
      } else {
        axios
          .put(
            "https://localhost:44343/api/Account/EditAccount/" +
              this.$route.params.id,
            this.form
          )
          .then(() => {
            alert("Cập nhật thông tin thành công");
          });
        this.$router.push("/reportManager/Account/List");
      }
    },
  },
};
</script>
