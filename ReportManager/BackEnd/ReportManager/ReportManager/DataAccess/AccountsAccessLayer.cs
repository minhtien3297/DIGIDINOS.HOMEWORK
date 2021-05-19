using ReportManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportManager.DataAccess
{
    public class AccountsAccessLayer
    {
        private const int SELECTBYUSERNAME = 1;
        private const int INSERTQUERY = 2;
        private const int UPDATEQUERY = 3;
        private const int DELETEQUERY = 4;
        private const int SELECTQUERY = 5;
        private const int SELECTBYIDQUERY = 6;
        private const int SELECTBYTEAMIDQUERY = 7;
        private const int SELECTBYUSERNAMEANDPASSWORD = 8;

        #region Insert Data

        /// <summary>
        /// Insert Data
        /// </summary>
        /// <param name="account"></param>
        /// <returns> "" or "insert"  </returns>
        public string InsertData(Accounts account)
        {
            SqlConnection con = null;
            string result;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

                SqlCommand cmd = new SqlCommand("proc_CRUD_accounts", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@username", account.Username);
                cmd.Parameters.AddWithValue("@passwords", account.Password);
                cmd.Parameters.AddWithValue("@age", account.Age);
                cmd.Parameters.AddWithValue("@addresss", account.Address);
                cmd.Parameters.AddWithValue("@roles", account.Role);
                cmd.Parameters.AddWithValue("@first_name", account.FirstName);
                cmd.Parameters.AddWithValue("@last_name", account.LastName);
                cmd.Parameters.AddWithValue("@mail", account.Mail);
                cmd.Parameters.AddWithValue("@sex", account.Sex);
                cmd.Parameters.AddWithValue("@statuss", account.Status);
                cmd.Parameters.AddWithValue("@teams_id", account.Teams_ID);

                cmd.Parameters.AddWithValue("@select", INSERTQUERY);
                con.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch (Exception ex)
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Insert Data

        #region Update Data

        /// <summary>
        /// Update Data
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public string UpdateData(Accounts account)
        {
            SqlConnection con = null;
            string result;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_accounts", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", account.ID);
                cmd.Parameters.AddWithValue("@username", account.Username);
                cmd.Parameters.AddWithValue("@passwords", account.Password);
                cmd.Parameters.AddWithValue("@age", account.Age);
                cmd.Parameters.AddWithValue("@addresss", account.Address);
                cmd.Parameters.AddWithValue("@roles", account.Role);
                cmd.Parameters.AddWithValue("@first_name", account.FirstName);
                cmd.Parameters.AddWithValue("@last_name", account.LastName);
                cmd.Parameters.AddWithValue("@mail", account.Mail);
                cmd.Parameters.AddWithValue("@sex", account.Sex);
                cmd.Parameters.AddWithValue("@statuss", account.Status);
                cmd.Parameters.AddWithValue("@teams_id", account.Teams_ID);

                cmd.Parameters.AddWithValue("@select", UPDATEQUERY);
                con.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch (Exception ex)
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Update Data

        #region Delete Data

        /// <summary>
        /// Delete Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteData(int id)
        {
            SqlConnection con = null;
            int result;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_accounts", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", id);

                cmd.Parameters.AddWithValue("@select", DELETEQUERY);
                con.Open();
                result = cmd.ExecuteNonQuery();

                return result;
            }
            catch (Exception ex)
            {
                return result = 0;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Delete Data

        #region Select All Data

        /// <summary>
        /// Select all Data
        /// </summary>
        /// <returns></returns>
        public List<Accounts> Selectalldata()
        {
            SqlConnection con = null;
            List<Accounts> Account = new List<Accounts>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_accounts", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@select", SELECTQUERY);
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Accounts account = new Accounts
                    {
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Username = ds.Tables[0].Rows[i]["username"].ToString(),
                        Password = ds.Tables[0].Rows[i]["passwords"].ToString(),
                        Age = Convert.ToInt32(ds.Tables[0].Rows[i]["age"].ToString()),
                        Address = ds.Tables[0].Rows[i]["addresss"].ToString(),
                        Role = Convert.ToInt32(ds.Tables[0].Rows[i]["roles"].ToString()),
                        FirstName = ds.Tables[0].Rows[i]["first_name"].ToString(),
                        LastName = ds.Tables[0].Rows[i]["last_name"].ToString(),
                        Mail = ds.Tables[0].Rows[i]["mail"].ToString(),
                        Sex = Convert.ToInt32(ds.Tables[0].Rows[i]["sex"].ToString()),
                        Status = Convert.ToInt32(ds.Tables[0].Rows[i]["statuss"].ToString()),
                        Teams_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["teams_id"].ToString())
                    };

                    Account.Add(account);
                }

                return Account;
            }
            catch (Exception ex)
            {
                return Account;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Select All Data

        #region Select Data By ID

        /// <summary>
        /// Select Data By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Accounts SelectDatabyID(int id)
        {
            SqlConnection con = null;
            Accounts accounts = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_accounts", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@select", SELECTBYIDQUERY);

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    accounts = new Accounts
                    {
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Username = ds.Tables[0].Rows[i]["username"].ToString(),
                        Password = ds.Tables[0].Rows[i]["passwords"].ToString(),
                        Age = Convert.ToInt32(ds.Tables[0].Rows[i]["age"].ToString()),
                        Address = ds.Tables[0].Rows[i]["addresss"].ToString(),
                        Role = Convert.ToInt32(ds.Tables[0].Rows[i]["roles"].ToString()),
                        FirstName = ds.Tables[0].Rows[i]["first_name"].ToString(),
                        LastName = ds.Tables[0].Rows[i]["last_name"].ToString(),
                        Mail = ds.Tables[0].Rows[i]["mail"].ToString(),
                        Sex = Convert.ToInt32(ds.Tables[0].Rows[i]["sex"].ToString()),
                        Status = Convert.ToInt32(ds.Tables[0].Rows[i]["statuss"].ToString()),
                        Teams_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["teams_id"].ToString())
                    };
                }

                return accounts;
            }
            catch (Exception ex)
            {
                return accounts;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Select Data By ID

        #region Select Data By Team ID

        /// <summary>
        /// Select all Data By Team ID
        /// </summary>
        /// <returns></returns>
        public List<Accounts> SelectAllDataByTeamID(int id)
        {
            SqlConnection con = null;
            List<Accounts> Account = new List<Accounts>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_accounts", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@select", SELECTBYTEAMIDQUERY);
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Accounts account = new Accounts
                    {
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Username = ds.Tables[0].Rows[i]["username"].ToString(),
                        Password = ds.Tables[0].Rows[i]["passwords"].ToString(),
                        Age = Convert.ToInt32(ds.Tables[0].Rows[i]["age"].ToString()),
                        Address = ds.Tables[0].Rows[i]["addresss"].ToString(),
                        Role = Convert.ToInt32(ds.Tables[0].Rows[i]["roles"].ToString()),
                        FirstName = ds.Tables[0].Rows[i]["first_name"].ToString(),
                        LastName = ds.Tables[0].Rows[i]["last_name"].ToString(),
                        Mail = ds.Tables[0].Rows[i]["mail"].ToString(),
                        Sex = Convert.ToInt32(ds.Tables[0].Rows[i]["sex"].ToString()),
                        Status = Convert.ToInt32(ds.Tables[0].Rows[i]["statuss"].ToString()),
                        Teams_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["teams_id"].ToString())
                    };

                    Account.Add(account);
                }

                return Account;
            }
            catch (Exception ex)
            {
                return Account;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Select Data By Team ID

        #region Select Data By Username And Password

        /// <summary>
        /// Select Data By Username And Password For Login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Accounts SelectDataToLogin(string username, string password)
        {
            SqlConnection con = null;
            Accounts accounts = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_accounts", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@passwords", password);
                cmd.Parameters.AddWithValue("@select", SELECTBYUSERNAMEANDPASSWORD);

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    accounts = new Accounts
                    {
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Username = ds.Tables[0].Rows[i]["username"].ToString(),
                        Password = ds.Tables[0].Rows[i]["passwords"].ToString(),
                        Age = Convert.ToInt32(ds.Tables[0].Rows[i]["age"].ToString()),
                        Address = ds.Tables[0].Rows[i]["addresss"].ToString(),
                        Role = Convert.ToInt32(ds.Tables[0].Rows[i]["roles"].ToString()),
                        FirstName = ds.Tables[0].Rows[i]["first_name"].ToString(),
                        LastName = ds.Tables[0].Rows[i]["last_name"].ToString(),
                        Mail = ds.Tables[0].Rows[i]["mail"].ToString(),
                        Sex = Convert.ToInt32(ds.Tables[0].Rows[i]["sex"].ToString()),
                        Status = Convert.ToInt32(ds.Tables[0].Rows[i]["statuss"].ToString()),
                        Teams_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["teams_id"].ToString())
                    };
                }

                return accounts;
            }
            catch (Exception ex)
            {
                return accounts;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Select Data By Username And Password

        #region Search By Username

        /// <summary>
        /// Search By Title
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<Accounts> SearchByUsername(string username)
        {
            SqlConnection con = null;
            List<Accounts> accounts = new List<Accounts>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_accounts", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@tittle_search", username);
                cmd.Parameters.AddWithValue("@select", SELECTBYUSERNAME);

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Accounts account = new Accounts
                    {
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Username = ds.Tables[0].Rows[i]["username"].ToString(),
                        Password = ds.Tables[0].Rows[i]["passwords"].ToString(),
                        Age = Convert.ToInt32(ds.Tables[0].Rows[i]["age"].ToString()),
                        Address = ds.Tables[0].Rows[i]["addresss"].ToString(),
                        Role = Convert.ToInt32(ds.Tables[0].Rows[i]["roles"].ToString()),
                        FirstName = ds.Tables[0].Rows[i]["first_name"].ToString(),
                        LastName = ds.Tables[0].Rows[i]["last_name"].ToString(),
                        Mail = ds.Tables[0].Rows[i]["mail"].ToString(),
                        Sex = Convert.ToInt32(ds.Tables[0].Rows[i]["sex"].ToString()),
                        Status = Convert.ToInt32(ds.Tables[0].Rows[i]["statuss"].ToString()),
                        Teams_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["teams_id"].ToString())
                    };

                    accounts.Add(account);
                }

                return accounts;
            }
            catch (Exception ex)
            {
                return accounts;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Search By Username
    }
}