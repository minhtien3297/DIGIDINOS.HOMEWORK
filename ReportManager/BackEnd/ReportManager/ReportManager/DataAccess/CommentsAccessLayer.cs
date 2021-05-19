using ReportManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportManager.DataAccess
{
    public class CommentsAccessLayer
    {
        private const int INSERTQUERY = 1;
        private const int DELETEQUERY = 2;
        private const int SELECTBYIDQUERY = 3;

        #region Insert Data

        /// <summary>
        /// Insert Data
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public string InsertData(Comments comment)
        {
            SqlConnection con = null;
            string result;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

                SqlCommand cmd = new SqlCommand("proc_CRUD_comments", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@contents", comment.Contents);
                cmd.Parameters.AddWithValue("@dates", DateTime.Now);
                cmd.Parameters.AddWithValue("@reports_id", comment.Reports_ID);
                cmd.Parameters.AddWithValue("@accounts_id", comment.Accounts_ID);
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
                SqlCommand cmd = new SqlCommand("proc_CRUD_comments", con)
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

        #region Select Data By ID

        /// <summary>
        /// Select Data By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Comments> SelectDatabyID(int id)
        {
            SqlConnection con = null;
            List<Comments> Comments = new List<Comments>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_comments", con)
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
                    Comments comment = new Comments
                    {
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Contents = ds.Tables[0].Rows[i]["contents"].ToString(),
                        Dates = Convert.ToDateTime(ds.Tables[0].Rows[i]["dates"].ToString()),
                        Reports_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["reports_id"].ToString()),
                        Accounts_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["accounts_id"].ToString())
                    };

                    Comments.Add(comment);
                }

                return Comments;
            }
            catch (Exception ex)
            {
                return Comments;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Select Data By ID

        #region Select Data By Report ID

        /// <summary>
        /// Select Data By Report ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Comments> SelectDataByReportID(int id)
        {
            SqlConnection con = null;
            List<Comments> Comments = new List<Comments>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_comments", con)
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
                    Comments comment = new Comments
                    {
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Contents = ds.Tables[0].Rows[i]["contents"].ToString(),
                        Dates = Convert.ToDateTime(ds.Tables[0].Rows[i]["dates"].ToString()),
                        Reports_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["reports_id"].ToString()),
                        Accounts_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["accounts_id"].ToString())
                    };

                    Comments.Add(comment);
                }

                return Comments;
            }
            catch (Exception ex)
            {
                return Comments;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Select Data By Report ID
    }
}