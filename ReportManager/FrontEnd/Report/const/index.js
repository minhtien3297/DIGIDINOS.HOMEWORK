const BASE_LINK = "https://localhost:44343/";
export const SOURCE_LINK = (enpoint, id) => {
    let link = ""
    switch (enpoint) {
        case "POST":
            link = BASE_LINK + "api/Account/CreateAccount";
            break;
        case "GET_ALL":
            link = BASE_LINK + "api/Account/GetAllAccount";
            break;
        case "GET_ID":
            link = BASE_LINK + "api/Account/GetAccountByID/" + id;
            break;
        case "PUT":
            link = BASE_LINK + "api/Account/EditAccount";
            break;
        case "DELETE":
            link = BASE_LINK + "api/Account/DeleteAccount/" + id;
            break;
        default:
            link = ""
            break;
    }

    return link;
};

export const FORM = {
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
}

//#region function of Account
export const SEX = [
    { value: 0, text: 'Nữ' },
    { value: 1, text: 'Nam' },
    { value: 2, text: 'Khác' },
];

export const STATUS = [
    { value: 0, text: "Không" },
    { value: 1, text: "Đã khóa" },
];

export const ROLE = [
    { value: 0, text: "HR" },
    { value: 1, text: "Nhân viên" },
];

export const TEAM = [
    { value: 0, text: "Thực tập sinh" },
    { value: 1, text: "BA" },
    { value: 2, text: "HR" },
    { value: 3, text: "Tester" },
];
//#endregion 

import axios from "axios";

/** 
 * call data account from API
 * 
 * @since 7-3-2021
 * @author Vu Doan
 */
export function CONST_getAccounts(accounts) {
    axios
        .get(SOURCE_LINK("GET_ALL", ""))
        .then((response) => (accounts = response.data));

    //console.log(accounts);
}

/** 
 * delete data account
 * 
 * @since 7-3-2021
 * @author Vu Doan
 */
export function CONST_deleteAccount(id, accounts) {
    axios.delete(SOURCE_LINK("DELETE", id)).then(() => {
        alert("xóa thành công")
        CONST_getAccounts(accounts)
    });
    //console.log(SOURCE_LINK("DELETE", id));
}


/** 
 * update data account
 * 
 * @since 7-3-2021
 * @author Vu Doan
 */
export function CONST_updateAccount(data, id) {
    this.$router.push('/reportManager/Account/' + id)
    axios
        .get(SOURCE_LINK("GET_ID", ""))
        .then((response) => (accounts = response.data));
}

/** 
 * add new data account
 * 
 * @since 7-3-2021
 * @author Vu Doan
 */
export function CONST_postAccounts(form, accounts) {
    axios.post(SOURCE_LINK, form).then(() => {
        alert("thêm thành công")
        CONST_getAccounts(accounts)
    })
}

/** 
 * Compare value => text or opposite of it, use into function of Account
 * 
 * @param role {string} SHOW_LIST or ADD_TO_DATABASE: use compare text => value of array [functionAccount] 
 * @param functionAccount {string}: function of Account
 * @param valueCompare {string} or {number}: value input option into role
 * 
 * @since 7-3-2021
 * @author Vu Doan
 */
export const CONST_FUNCTION_OF_ACCOUNT = (role, functionAccount, valueCompare) => {
    if (functionAccount && role && valueCompare) {
        if (role == "SHOW_LIST" && typeof valueCompare === "number") {
            if (functionAccount == "SEX") return SEX.find((element) => element.value = valueCompare).text
            else if (functionAccount == "STATUS") return STATUS.find((element) => element.value = valueCompare).text
            else if (functionAccount == "ROLE") return ROLE.find((element) => element.value = valueCompare).text
            else if (functionAccount == "TEAM") return TEAM.find((element) => element.value = valueCompare).text
            else return "Chưa được phân loại"
        } else return "Chưa được phân loại"
    } else return "Chưa được phân loại"
}