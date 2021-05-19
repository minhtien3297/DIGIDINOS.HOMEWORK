using BlogManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Management;
using System.Threading.Tasks;

namespace BlogManager.DataAccess
{
    public class DataAccessLayer
    {
        const int INSERTQUERY = 1;
        const int UPDATEQUERY = 2;
        const int DELETEQUERY = 3;
        const int SELECTQUERY = 4;
        const int SELECTBYIDQUERY = 5;
        const int SEARCHBYTITLE = 6;

        #region Insert Data
        /// <summary>
        /// Insert Data
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public string InsertData(Blog blog)
        {
            SqlConnection con = null;
            string result;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Title", blog.Title);
                cmd.Parameters.AddWithValue("@Description", blog.Description);
                cmd.Parameters.AddWithValue("@Detail", blog.Detail);
                cmd.Parameters.AddWithValue("@Category", blog.Category);
                cmd.Parameters.AddWithValue("@Publics", blog.Publics);
                cmd.Parameters.AddWithValue("@Position", blog.Position.Replace("/", ""));
                cmd.Parameters.AddWithValue("@Thumbs", blog.Thumbs);
                cmd.Parameters.AddWithValue("@DatePublic", blog.DatePublic);
                cmd.Parameters.AddWithValue("@Query", INSERTQUERY);
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
        #endregion

        #region Update Data
        /// <summary>
        /// Update Data
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public string UpdateData(Blog blog)
        {
            SqlConnection con = null;
            string result;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@BlogID", blog.BlogID);
                cmd.Parameters.AddWithValue("@Title", blog.Title);
                cmd.Parameters.AddWithValue("@Description", blog.Description);
                cmd.Parameters.AddWithValue("@Detail", blog.Detail);
                cmd.Parameters.AddWithValue("@Category", blog.Category);
                cmd.Parameters.AddWithValue("@Publics", blog.Publics);
                cmd.Parameters.AddWithValue("@Position", blog.Position);
                cmd.Parameters.AddWithValue("@Thumbs", blog.Thumbs);
                cmd.Parameters.AddWithValue("@DatePublic", blog.DatePublic);
                cmd.Parameters.AddWithValue("@Query", UPDATEQUERY);
                con.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

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
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@BlogID", id);
                cmd.Parameters.AddWithValue("@Query", DELETEQUERY);
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
        #endregion

        #region Select All Data
        /// <summary>
        /// Select all Data
        /// </summary>
        /// <returns></returns>
        public List<Blog> Selectalldata()
        {
            SqlConnection con = null;
            List<Blog> Blogs = new List<Blog>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Query", SELECTQUERY);
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Blog blog = new Blog
                    {
                        BlogID = Convert.ToInt32(ds.Tables[0].Rows[i]["BlogID"].ToString()),
                        Title = ds.Tables[0].Rows[i]["Title"].ToString(),
                        Description = ds.Tables[0].Rows[i]["Description"].ToString(),
                        Detail = ds.Tables[0].Rows[i]["Detail"].ToString(),
                        Category = Convert.ToInt32(ds.Tables[0].Rows[i]["Category"].ToString()),
                        Publics = ds.Tables[0].Rows[i]["Publics"].ToString(),
                        Position = ds.Tables[0].Rows[i]["Position"].ToString(),
                        Thumbs = ds.Tables[0].Rows[i]["Thumbs"].ToString(),
                        DatePublic = Convert.ToDateTime(ds.Tables[0].Rows[i]["DatePublic"].ToString())
                    };

                    Blogs.Add(blog);
                }

                return Blogs;
            }
            catch
            {
                return Blogs;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Select Data By ID
        /// <summary>
        /// Select Data By ID
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public Blog SelectDatabyID(int id)
        {
            SqlConnection con = null;
            Blog blog = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@BlogID", id);
                cmd.Parameters.AddWithValue("@Query", SELECTBYIDQUERY);

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    blog = new Blog
                    {
                        BlogID = Convert.ToInt32(ds.Tables[0].Rows[i]["BlogID"].ToString()),
                        Title = ds.Tables[0].Rows[i]["Title"].ToString(),
                        Description = ds.Tables[0].Rows[i]["Description"].ToString(),
                        Detail = ds.Tables[0].Rows[i]["Detail"].ToString(),
                        Category = Convert.ToInt32(ds.Tables[0].Rows[i]["Category"].ToString()),
                        Publics = ds.Tables[0].Rows[i]["Publics"].ToString(),
                        Position = ds.Tables[0].Rows[i]["Position"].ToString(),
                        Thumbs = ds.Tables[0].Rows[i]["Thumbs"].ToString(),
                        DatePublic = Convert.ToDateTime(ds.Tables[0].Rows[i]["DatePublic"].ToString())
                    };

                }

                return blog;
            }
            catch
            {
                return blog;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Search By Title
        /// <summary>
        /// Search By Title
        /// </summary>
        /// <param name="BlogID"></param>
        /// <returns></returns>
        public List<Blog> SearchByTitle(string title)
        {
            SqlConnection con = null;
            List<Blog> blogs = new List<Blog>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Blog", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Query", SEARCHBYTITLE);

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Blog blog = new Blog
                    {
                        BlogID = Convert.ToInt32(ds.Tables[0].Rows[i]["BlogID"].ToString()),
                        Title = ds.Tables[0].Rows[i]["Title"].ToString(),
                        Description = ds.Tables[0].Rows[i]["Description"].ToString(),
                        Detail = ds.Tables[0].Rows[i]["Detail"].ToString(),
                        Category = Convert.ToInt32(ds.Tables[0].Rows[i]["Category"].ToString()),
                        Publics = ds.Tables[0].Rows[i]["Publics"].ToString(),
                        Position = ds.Tables[0].Rows[i]["Position"].ToString(),
                        Thumbs = ds.Tables[0].Rows[i]["Thumbs"].ToString(),
                        DatePublic = Convert.ToDateTime(ds.Tables[0].Rows[i]["DatePublic"].ToString())
                    };

                    blogs.Add(blog);
                }

                return blogs;
            }
            catch
            {
                return blogs;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
    }
}
