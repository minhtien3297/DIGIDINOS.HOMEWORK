using BlogManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlogManager.App_Common.DataAccess
{
    public class DataAccessLayer
    {
        /// <summary>
        ///  Them data vao database
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public string InsertData(Blog blog)
        {
            SqlConnection con = null;

            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Name", blog.Name);
                cmd.Parameters.AddWithValue("@Type", blog.Type);
                cmd.Parameters.AddWithValue("@Condition", blog.Condition);
                cmd.Parameters.AddWithValue("@Address", blog.Address);
                cmd.Parameters.AddWithValue("@Date", blog.Date);
                cmd.Parameters.AddWithValue("@Query", 1);
                con.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch
            {
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Edit data trong database
        /// </summary>
        /// <param name="objblog"></param>
        /// <returns></returns>
        public string UpdateData(Blog blog)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BlogID", blog.BlogID);
                cmd.Parameters.AddWithValue("@Name", blog.Name);
                cmd.Parameters.AddWithValue("@Type", blog.Type);
                cmd.Parameters.AddWithValue("@Condition", blog.Condition);
                cmd.Parameters.AddWithValue("@Address", blog.Address);
                cmd.Parameters.AddWithValue("@Date", blog.Date);
                cmd.Parameters.AddWithValue("@Query", 2);
                con.Open();
                result = cmd.ExecuteScalar().ToString();

                return result;
            }
            catch
            {
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Xoa data trong database
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DeleteData(String ID)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BlogID", ID);
                cmd.Parameters.AddWithValue("@Name", null);
                cmd.Parameters.AddWithValue("@Type", null);
                cmd.Parameters.AddWithValue("@Condition", null);
                cmd.Parameters.AddWithValue("@Address", null);
                cmd.Parameters.AddWithValue("@Date", null);
                cmd.Parameters.AddWithValue("@Query", 3);
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

        /// <summary>
        /// Lay danh sach tat ca data trong database
        /// </summary>
        /// <returns></returns>
        public List<Blog> Selectalldata()
        {
            SqlConnection con = null;
            List<Blog> blogList = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BlogID", null);
                cmd.Parameters.AddWithValue("@Name", null);
                cmd.Parameters.AddWithValue("@Type", null);
                cmd.Parameters.AddWithValue("@Condition", null);
                cmd.Parameters.AddWithValue("@Address", null);
                cmd.Parameters.AddWithValue("@Date", null);
                cmd.Parameters.AddWithValue("@Query", 4);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);
                blogList = new List<Blog>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Blog blog = new Blog
                    {
                        BlogID = Convert.ToInt32(ds.Tables[0].Rows[i]["BlogID"].ToString()),
                        Name = ds.Tables[0].Rows[i]["Name"].ToString(),
                        Type = ds.Tables[0].Rows[i]["Type"].ToString(),
                        Condition = ds.Tables[0].Rows[i]["Condition"].ToString(),
                        Address = ds.Tables[0].Rows[i]["Address"].ToString(),
                        Date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"].ToString())
                    };

                    blogList.Add(blog);
                }

                return blogList;
            }
            catch
            {
                return blogList;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Lay data theo id truyen vao
        /// </summary>
        /// <param name="BlogID"></param>
        /// <returns></returns>
        public Blog SelectDatabyID(string BlogID)
        {
            SqlConnection con = null;
            Blog blog = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BlogID", BlogID);
                cmd.Parameters.AddWithValue("@Name", null);
                cmd.Parameters.AddWithValue("@Type", null);
                cmd.Parameters.AddWithValue("@Condition", null);
                cmd.Parameters.AddWithValue("@Address", null);
                cmd.Parameters.AddWithValue("@Date", null);
                cmd.Parameters.AddWithValue("@Query", 5);
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
                        Name = ds.Tables[0].Rows[i]["Name"].ToString(),
                        Type = ds.Tables[0].Rows[i]["Type"].ToString(),
                        Condition = ds.Tables[0].Rows[i]["Condition"].ToString(),
                        Address = ds.Tables[0].Rows[i]["Address"].ToString(),
                        Date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"].ToString())
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

        /// <summary>
        /// Tim kiem data theo Name truyen vao
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public List<Blog> SearchDataByName(string Name)
        {
            SqlConnection con = null;
            Blog searchBlog;
            List<Blog> listSearchBlog = new List<Blog>();
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Customer", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BlogID", null);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Type", null);
                cmd.Parameters.AddWithValue("@Condition", null);
                cmd.Parameters.AddWithValue("@Address", null);
                cmd.Parameters.AddWithValue("@Date", null);
                cmd.Parameters.AddWithValue("@Query", 6);
                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    searchBlog = new Blog
                    {
                        BlogID = Convert.ToInt32(ds.Tables[0].Rows[i]["BlogID"].ToString()),
                        Name = ds.Tables[0].Rows[i]["Name"].ToString(),
                        Type = ds.Tables[0].Rows[i]["Type"].ToString(),
                        Condition = ds.Tables[0].Rows[i]["Condition"].ToString(),
                        Address = ds.Tables[0].Rows[i]["Address"].ToString(),
                        Date = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"].ToString())
                    };
                    listSearchBlog.Add(searchBlog);
                }

                return listSearchBlog;
            }
            catch (Exception)
            {
                return listSearchBlog = null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}