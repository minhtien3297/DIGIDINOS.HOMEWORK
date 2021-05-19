using ReportManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportManager.DataAccess
{
    public class ReportAccessLayer
    {
        private const int SEARCHBYDONE = 1;
        private const int INSERTQUERY = 2;
        private const int UPDATEQUERY = 3;
        private const int DELETEQUERY = 4;
        private const int SELECTQUERY = 5;
        private const int SELECTBYIDQUERY = 6;
        private const int SELECTBYACCOUNTIDQUERY = 7;

        #region Insert Data

        /// <summary>
        /// Insert Data
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        public string InsertData(Reports report)
        {
            SqlConnection con = null;
            string result;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

                SqlCommand cmd = new SqlCommand("proc_CRUD_reports", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@done", report.Done);
                cmd.Parameters.AddWithValue("@problem", report.Problem);
                cmd.Parameters.AddWithValue("@solution", report.Solution);
                cmd.Parameters.AddWithValue("@link", report.Link);
                cmd.Parameters.AddWithValue("@dates", DateTime.Now);
                cmd.Parameters.AddWithValue("@accounts_id", report.Account_ID);
                cmd.Parameters.AddWithValue("@teams_id", report.Teams_ID);
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
        /// <param name="report"></param>
        /// <returns></returns>
        public string UpdateData(Reports report)
        {
            SqlConnection con = null;
            string result;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_reports", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", report.ID);
                cmd.Parameters.AddWithValue("@done", report.Done);
                cmd.Parameters.AddWithValue("@problem", report.Problem);
                cmd.Parameters.AddWithValue("@solution", report.Solution);
                cmd.Parameters.AddWithValue("@link", report.Link);
                cmd.Parameters.AddWithValue("@dates", report.Dates);
                cmd.Parameters.AddWithValue("@accounts_id", report.Account_ID);
                cmd.Parameters.AddWithValue("@teams_id", report.Teams_ID);
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
                SqlCommand cmd = new SqlCommand("proc_CRUD_reports", con)
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
        public List<Reports> Selectalldata()
        {
            SqlConnection con = null;
            List<Reports> Reports = new List<Reports>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_reports", con)
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
                    Reports report = new Reports
                    {
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Done = ds.Tables[0].Rows[i]["done"].ToString(),
                        Problem = ds.Tables[0].Rows[i]["problem"].ToString(),
                        Solution = ds.Tables[0].Rows[i]["solution"].ToString(),
                        Link = ds.Tables[0].Rows[i]["link"].ToString(),
                        Dates = Convert.ToDateTime((ds.Tables[0].Rows[i]["dates"])),
                        Account_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["accounts_id"].ToString()),
                        Teams_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["teams_id"].ToString()),
                    };

                    Reports.Add(report);
                }

                return Reports;
            }
            catch (Exception ex)
            {
                return Reports;
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
        public Reports SelectDatabyID(int id)
        {
            SqlConnection con = null;
            Reports report = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_reports", con)
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
                    report = new Reports
                    {
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Done = ds.Tables[0].Rows[i]["done"].ToString(),
                        Problem = ds.Tables[0].Rows[i]["problem"].ToString(),
                        Solution = ds.Tables[0].Rows[i]["solution"].ToString(),
                        Link = ds.Tables[0].Rows[i]["link"].ToString(),
                        Dates = Convert.ToDateTime(ds.Tables[0].Rows[i]["dates"].ToString()),
                        Account_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["accounts_id"].ToString()),
                        Teams_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["teams_id"].ToString()),
                    };
                }

                return report;
            }
            catch (Exception ex)
            {
                return report;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Select Data By ID

        #region Select Data By Account ID

        /// <summary>
        /// Select Data By Account ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Reports> SelectDatabyAccountID(int id)
        {
            SqlConnection con = null;
            List<Reports> Reports = new List<Reports>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_reports", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@select", SELECTBYACCOUNTIDQUERY);

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Reports report = new Reports
                    {
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Done = ds.Tables[0].Rows[i]["done"].ToString(),
                        Problem = ds.Tables[0].Rows[i]["problem"].ToString(),
                        Solution = ds.Tables[0].Rows[i]["solution"].ToString(),
                        Link = ds.Tables[0].Rows[i]["link"].ToString(),
                        Dates = Convert.ToDateTime(ds.Tables[0].Rows[i]["dates"].ToString()),
                        Account_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["accounts_id"].ToString()),
                        Teams_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["teams_id"].ToString()),
                    };

                    Reports.Add(report);
                }

                return Reports;
            }
            catch (Exception ex)
            {
                return Reports;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Select Data By Account ID

        #region Search By SearchString

        /// <summary>
        /// Search By SearchString
        /// </summary>
        /// <returns></returns>
        public List<Reports> SearchBySearchString(string done, string date, string account_name, string teams_name)
        {
            SqlConnection con = null;
            List<Reports> reports = new List<Reports>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_reports", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (done != null)
                {
                    cmd.Parameters.Add("@done", SqlDbType.NVarChar, 1000).Value = done;
                }
                if (date != null)
                {
                    cmd.Parameters.AddWithValue("@dates", date);
                }
                if (account_name != null)
                {
                    cmd.Parameters.Add("@accounts_name", SqlDbType.NVarChar, 1000).Value = account_name;
                }
                if (teams_name != null)
                {
                    cmd.Parameters.Add("@teams_name", SqlDbType.NVarChar, 1000).Value = teams_name;
                }
                cmd.Parameters.AddWithValue("@select", SEARCHBYDONE);

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Reports report = new Reports
                    {
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Done = ds.Tables[0].Rows[i]["done"].ToString(),
                        Problem = ds.Tables[0].Rows[i]["problem"].ToString(),
                        Solution = ds.Tables[0].Rows[i]["solution"].ToString(),
                        Link = ds.Tables[0].Rows[i]["link"].ToString(),
                        Dates = Convert.ToDateTime(ds.Tables[0].Rows[i]["dates"].ToString()),
                        Account_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["accounts_id"].ToString()),
                        Teams_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["teams_id"].ToString()),
                    };

                    reports.Add(report);
                }
                return reports;
            }
            catch (Exception ex)
            {
                return reports;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Search By SearchString
    }
}