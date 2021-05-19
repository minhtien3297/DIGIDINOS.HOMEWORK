<template>
  <div class="card-body">
    <div>
      <table class="table">
        <thead class="table-primary">
          <tr>
            <th scope="col">ID</th>
            <th scope="col">Username</th>
            <th scope="col">Password</th>
            <th scope="col">First Name</th>
            <th scope="col">Last Name</th>
            <th scope="col">Role</th>
            <th scope="col">Mail</th>
            <th scope="col">Team</th>
            <th scope="col">Age</th>
            <th scope="col">Address</th>
            <th scope="col">Sex</th>
            <th scope="col">Status</th>
            <th scope="col">Action</th>
          </tr>
        </thead>

        <tbody>
          <tr v-for="(account, index) in filteredAccounts" :key="account.ID">
            <td>{{ index + 1 }}</td>
            <td>{{ account.Username }}</td>
            <td>{{ account.Password }}</td>
            <td>{{ account.FirstName }}</td>
            <td>{{ account.LastName }}</td>
            <td>{{ changeRole(account.Role) }}</td>
            <td>{{ account.Mail }}</td>
            <td>{{ changeTeam(account.Teams_ID) }}</td>
            <td>{{ account.Age }}</td>
            <td>{{ account.Address }}</td>
            <td>{{ changeSex(account.Sex) }}</td>
            <td>{{ changeStatus(account.Status) }}</td>
            <td>
              <button
                class="btn btn-info mr-2"
                style="width: 70px"
                @click="updateAccount(account, account.ID)"
              >
                Edit
              </button>

              <button
                class="btn btn-danger col-6"
                style="width: 200px"
                @click="deleteAccount(account.ID)"
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

export default {
  data() {
    return {
      form: {
        ID: 0,
        Username: "",
        Password: "",
        Address: "",
        Role: "",
        FirstName: "",
        LastName: "",
        Mail: "",
        Age: 0,
        Sex: 0,
        Status: 0,
        Teams_ID: 0,
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

  props: ["filteredAccounts"],

  mounted() {
    this.getAccounts();
    this.getTeam();
  },

  methods: {
    // setError() {
    //     if(.id == null){
    //         return error.find(e => e.value ="id")
    //     }
    // },

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
          //console.log(this.teams);
        })
        .catch((err) => {
          //console.log(err);
        });
    },

    /**
     * tranfrom sex from number => string
     * @return result of CONST_FUNCTION_OF_ACCOUNT()
     *
     * @since 9-3-2021
     * @author Vu Doan
     */
    changeSex: function (sex) {
      const item = this.sexs.find((e) => e.number === sex);
      return item ? item.text : "";
    },

    /**
     * tranfrom status from number => string
     * @return result of CONST_FUNCTION_OF_ACCOUNT()
     *
     * @since 9-3-2021
     * @author Vu Doan
     */
    changeStatus: function (status) {
      const item = this.status.find((e) => e.number === status);
      return item ? item.text : "";
    },

    /**
     * tranfrom role from number => string
     * @return result of CONST_FUNCTION_OF_ACCOUNT()
     *
     * @since 9-3-2021
     * @author Vu Doan
     */
    changeRole(role) {
      const item = this.roles.find((e) => e.number === role);
      return item ? item.text : "";
    },

    /**
     * transfrom team from number => string
     * @return result of CONST_FUNCTION_OF_ACCOUNT()
     *
     * @since 9-3-2021
     * @author Vu Doan
     */
    changeTeam: function (teams) {
      const item = this.teams.find((e) => e.ID === teams);
      return item ? item.Name : "";
    },

    /**
     * add data to list form account
     * @return result of CONST_getAccounts()
     *
     * @since 9-3-2021
     * @author Vu Doan
     */
    getAccounts: function () {
      axios
        .get("https://localhost:44343/api/Account/GetAllAccount")
        .then((response) => {
          this.accounts = response.data;
        })
        .catch(function (error) {
          //console.log(error);
        });
    },

    /**
     * update data of account
     * @params id: id of account
     * @return result of CONST_updateAccount()
     *
     * @since 9-3-2021
     * @author Vu Doan
     */
    updateAccount: function (data, id) {
      this.$router.push("/reportManager/Account/" + id);
      axios.get("https://localhost:44343/api/Account/GetAccountByID/" + id);
    },
  },

  /**
   * delete data of account
   * @params id: id of account
   * @return result of CONST_deleteAccounts()
   *
   * @since 9-3-2021
   * @author Vu Doan
   */
  deleteAccount: function (id) {
    let conf = confirm(
      "Hành động tiếp theo sẽ thay đổi thông tin tài khoản. Nhấn [OK] để tiếp tục."
    );
    if (conf == true) {
      axios
        .delete("https://localhost:44343/api/Account/DeleteAccount/" + id)
        .then(() => {
          alert("xóa thành công");
          this.getAccounts();
          location.reload();
        });
    }
  },
};
</script>
