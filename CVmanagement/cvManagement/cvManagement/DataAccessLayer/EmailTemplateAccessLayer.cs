using cvManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace cvManagement.DataAccessLayer
{
    public class EmailTemplateAccessLayer
    {
        private const int QUERY_INSERT = 1;
        private const int QUERY_UPDATE = 2;
        private const int QUERY_DELETE = 3;
        private const int QUERY_SELECTALL = 4;
        private const int QUERY_SELECTBYID = 5;
        private const int QUERY_SELECTBYNAME = 6;

        #region Selectalldata

        /// <summary>
        /// Lay toan bo email template
        /// </summary>
        /// <returns value="List<emailTemplate>" name="listEmailTemplate"></returns>
        public List<EmailTemplate> Selectalldata()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
            SqlCommand cmd = new SqlCommand("Usp_EmailTemplate", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@id", null);
            cmd.Parameters.AddWithValue("@name", null);
            cmd.Parameters.AddWithValue("@content", null);
            cmd.Parameters.AddWithValue("@Query", QUERY_SELECTALL);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter
            {
                SelectCommand = cmd
            };
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<EmailTemplate> listEmailTemplate = new List<EmailTemplate>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                EmailTemplate cobj = new EmailTemplate
                {
                    Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                    Name = ds.Tables[0].Rows[i]["name"].ToString(),
                    Content = ds.Tables[0].Rows[i]["content"].ToString()
                };
                listEmailTemplate.Add(cobj);
            }

            return listEmailTemplate;
        }

        #endregion Selectalldata

        #region InsertData

        /// <summary>
        /// Them vao 1 email template
        /// </summary>
        /// <param name="emailtemplate" value="emailTemplate"></param>
        /// <returns name="result" value="string"></returns>
        public string Insertdata(EmailTemplate emailtemplate)
        {
            SqlConnection con = null;
            string result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_EmailTemplate", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@name", emailtemplate.Name);
                cmd.Parameters.AddWithValue("@content", emailtemplate.Content);
                cmd.Parameters.AddWithValue("@Query", QUERY_INSERT);
                con.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch (Exception)
            {
                return result = null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion InsertData

        #region Updatedata

        /// <summary>
        /// Cap nhat du lieu 1 email template
        /// </summary>
        /// <param name="emailtemplate" value="emailTemplate"></param>
        /// <returns name="result" value="string"></returns>
        public string Updatedata(EmailTemplate emailtemplate)
        {
            SqlConnection con = null;
            string result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_EmailTemplate", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", emailtemplate.Id);
                cmd.Parameters.AddWithValue("@name", emailtemplate.Name);
                cmd.Parameters.AddWithValue("@content", emailtemplate.Content);
                cmd.Parameters.AddWithValue("@Query", QUERY_UPDATE);
                con.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch (Exception)
            {
                return result = null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Updatedata

        #region SelectDataById

        /// <summary>
        /// Lay ra 1 email template theo id
        /// </summary>
        /// <param name="EmailTemplateId" value="string"></param>
        /// <returns name="foundTemplate" value="emailTemplate"></returns>
        public EmailTemplate SelectDataById(string EmailTemplateId)
        {
            SqlConnection con = null;
            EmailTemplate foundTemplate = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_EmailTemplate", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", EmailTemplateId);
                cmd.Parameters.AddWithValue("@name", null);
                cmd.Parameters.AddWithValue("@content", null);
                cmd.Parameters.AddWithValue("@Query", QUERY_SELECTBYID);

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    foundTemplate = new EmailTemplate
                    {
                        Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Name = ds.Tables[0].Rows[i]["name"].ToString(),
                        Content = ds.Tables[0].Rows[i]["content"].ToString()
                    };
                }

                return foundTemplate;
            }
            catch (Exception)
            {
                return foundTemplate;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion SelectDataById

        #region SearchDataByName

        /// <summary>
        /// Tim template theo ten
        /// </summary>
        /// <param name="templateName" value="string"></param>
        /// <returns name="listFoundTemplate" value="List<emailTemplate>"></returns>
        public List<EmailTemplate> SearchDataByName(string templateName)
        {
            SqlConnection con = null;
            List<EmailTemplate> listFoundTemplate = new List<EmailTemplate>();
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_EmailTemplate", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@name", templateName);
                cmd.Parameters.AddWithValue("@content", null);
                cmd.Parameters.AddWithValue("@Query", QUERY_SELECTBYNAME);

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    EmailTemplate foundTemplate = new EmailTemplate
                    {
                        Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Name = ds.Tables[0].Rows[i]["name"].ToString(),
                        Content = ds.Tables[0].Rows[i]["content"].ToString()
                    };
                    listFoundTemplate.Add(foundTemplate);
                }

                return listFoundTemplate;
            }
            catch (Exception)
            {
                return listFoundTemplate = null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion SearchDataByName

        #region DeleteData

        /// <summary>
        /// Xoa 1 template
        /// </summary>
        /// <param name="ID" value="string"></param>
        /// <returns name="result" value="int"></returns>
        public int DeleteData(String ID)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_EmailTemplate", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", null);
                cmd.Parameters.AddWithValue("@content", null);
                cmd.Parameters.AddWithValue("@Query", QUERY_DELETE);
                con.Open();
                result = cmd.ExecuteNonQuery();

                return result;
            }
            catch
            {
                return result = 0;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion DeleteData
    }
}