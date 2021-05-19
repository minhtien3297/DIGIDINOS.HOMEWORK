using cvManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace cvManagement.DataAccessLayer
{
    public class UserProfileLayer
    {
        private const int QUERY_INSERT = 1;
        private const int QUERY_UPDATE = 2;
        private const int QUERY_SELECTALL = 3;
        private const int QUERY_SELECTBYID = 4;

        /// <summary>
        /// Insert profile
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public string InsertData(UserProfile pro)
        {
            SqlConnection conn = null;
            String result = "";
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_UserProfile", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@name", pro.Name);
                cmd.Parameters.AddWithValue("@positionId", pro.PositionId);
                cmd.Parameters.AddWithValue("@sourceId", pro.SourceId);
                cmd.Parameters.AddWithValue("@applyDate", pro.ApplyDate);
                cmd.Parameters.AddWithValue("@cvResult", 0);
                cmd.Parameters.AddWithValue("@interviewDate", "0001-01-01");
                cmd.Parameters.AddWithValue("@interviewResult", 0);
                cmd.Parameters.AddWithValue("@status", pro.Status);
                cmd.Parameters.AddWithValue("@cvLink", pro.CvLink);
                cmd.Parameters.AddWithValue("@note", pro.Note);
                cmd.Parameters.AddWithValue("@Query", QUERY_INSERT);
                conn.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch (Exception)
            {
                return result = null;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Update profile
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public string UpdateData(UserProfile pro)
        {
            SqlConnection conn = null;
            String result = "";
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_UserProfile", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", pro.Id);
                cmd.Parameters.AddWithValue("@name", null);
                cmd.Parameters.AddWithValue("@positionId", null);
                cmd.Parameters.AddWithValue("@sourceId", null);
                cmd.Parameters.AddWithValue("@applyDate", null);
                cmd.Parameters.AddWithValue("@cvResult", pro.CvResult);
                cmd.Parameters.AddWithValue("@interviewDate", pro.InterviewDate.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@interviewResult", pro.InterviewResult);
                cmd.Parameters.AddWithValue("@status", pro.Status);
                cmd.Parameters.AddWithValue("@cvLink", null);
                cmd.Parameters.AddWithValue("@note", pro.Note);
                cmd.Parameters.AddWithValue("@Query", QUERY_UPDATE);
                conn.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch (Exception)
            {
                return result = null;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Select all profiles
        /// </summary>
        /// <returns></returns>
        public List<UserProfile> Selectalldata()
        {
            SqlConnection con = null;
            List<UserProfile> ListProfile = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_UserProfile", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@name", null);
                cmd.Parameters.AddWithValue("@positionId", null);
                cmd.Parameters.AddWithValue("@sourceId", null);
                cmd.Parameters.AddWithValue("@applyDate", null);
                cmd.Parameters.AddWithValue("@cvResult", null);
                cmd.Parameters.AddWithValue("@interviewDate", null);
                cmd.Parameters.AddWithValue("@interviewResult", null);
                cmd.Parameters.AddWithValue("@status", null);
                cmd.Parameters.AddWithValue("@cvLink", null);
                cmd.Parameters.AddWithValue("@note", null);
                cmd.Parameters.AddWithValue("@Query", QUERY_SELECTALL);
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);
                ListProfile = new List<UserProfile>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    UserProfile pro = new UserProfile();
                    pro.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                    pro.Name = ds.Tables[0].Rows[i]["name"].ToString();
                    pro.PositionId = Convert.ToInt32(ds.Tables[0].Rows[i]["positionId"].ToString());
                    pro.SourceId = Convert.ToInt32(ds.Tables[0].Rows[i]["sourceId"].ToString());
                    pro.ApplyDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["applyDate"].ToString()).Date;
                    if (ds.Tables[0].Rows[i]["cvResult"] != DBNull.Value)
                    {
                        pro.CvResult = Convert.ToInt32(ds.Tables[0].Rows[i]["cvResult"].ToString());
                    }
                    else pro.CvResult = 0;

                    if (ds.Tables[0].Rows[i]["interviewDate"] != DBNull.Value)
                    {
                        pro.InterviewDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["interviewDate"].ToString());
                    }
                    else pro.InterviewDate = Convert.ToDateTime("0001-01-01");

                    if (ds.Tables[0].Rows[i]["interviewResult"] != DBNull.Value)
                    {
                        pro.InterviewResult = Convert.ToInt32(ds.Tables[0].Rows[i]["interviewResult"].ToString());
                    }
                    else pro.InterviewResult = 0;

                    pro.Status = Convert.ToInt32(ds.Tables[0].Rows[i]["status"].ToString());
                    pro.CvLink = ds.Tables[0].Rows[i]["cvLink"].ToString();
                    pro.Note = ds.Tables[0].Rows[i]["note"].ToString();
                    ListProfile.Add(pro);
                }

                return ListProfile;
            }
            catch
            {
                return ListProfile;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Select profile by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserProfile SelectDatabyID(string Id)
        {
            SqlConnection con = null;
            UserProfile pro = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_UserProfile", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@name", null);
                cmd.Parameters.AddWithValue("@sourceId", null);
                cmd.Parameters.AddWithValue("@positionId", null);
                cmd.Parameters.AddWithValue("@applyDate", null);
                cmd.Parameters.AddWithValue("@cvResult", null);
                cmd.Parameters.AddWithValue("@interviewDate", null);
                cmd.Parameters.AddWithValue("@interviewResult", null);
                cmd.Parameters.AddWithValue("@status", null);
                cmd.Parameters.AddWithValue("@cvLink", null);
                cmd.Parameters.AddWithValue("@note", null);
                cmd.Parameters.AddWithValue("@Query", QUERY_SELECTBYID);

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    pro = new UserProfile
                    {
                        Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Name = ds.Tables[0].Rows[i]["name"].ToString(),
                        PositionId = Convert.ToInt32(ds.Tables[0].Rows[i]["positionId"].ToString()),
                        SourceId = Convert.ToInt32(ds.Tables[0].Rows[i]["sourceId"].ToString()),
                        ApplyDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["applyDate"].ToString()),
                        CvResult = Convert.ToInt32(ds.Tables[0].Rows[i]["cvResult"].ToString()),
                        InterviewDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["interviewDate"].ToString()),
                        InterviewResult = Convert.ToInt32(ds.Tables[0].Rows[i]["interviewResult"].ToString()),
                        Status = Convert.ToInt32(ds.Tables[0].Rows[i]["status"].ToString()),
                        CvLink = ds.Tables[0].Rows[i]["name"].ToString(),
                        Note = ds.Tables[0].Rows[i]["name"].ToString()
                    };
                }

                return pro;
            }
            catch
            {
                return pro;
            }
            finally
            {
                con.Close();
            }
        }
    }
}