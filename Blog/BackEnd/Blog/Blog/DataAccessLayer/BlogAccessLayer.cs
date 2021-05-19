using Blog.DynamicLinkLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Blog.DataAccessLayer
{
    public class BlogAccessLayer
    {
        private BlogLibrary library = new BlogLibrary();

        private const int SELECTALL = 1;
        private const int INSERT = 2;
        private const int UPDATE = 3;
        private const int DELETE = 4;
        private const int SELECTBYID = 5;
        private const int SELECTBYTITLE = 6;
        private const int SELECTBYCONTENT = 7;
        private const int SELECTBYTIME = 8;

        #region Convert Image => Byte

        /// <summary>
        ///     Convert Image => Byte, used save db
        /// </summary>
        /// <param name="imageIn"></param>
        /// <returns> array byte </returns>
        public byte[] ConvertImage(Image imageIn)
        {
            return library.ImageToByteArray(imageIn);
        }

        #endregion Convert Image => Byte

        #region Convert Byte => Image

        /// <summary>
        ///     Convert Byte => Image, used show iamge
        /// </summary>
        /// <param name="imageIn"></param>
        /// <returns> array byte </returns>
        public Image ConvertByte(string byteString)
        {
            return library.ByteToImg(byteString);
        }

        #endregion Convert Byte => Image

        #region Insert Data

        /// <summary>
        /// Insert Data
        /// </summary>
        /// <param name="account"></param>
        /// <returns> "" or "insert"  </returns>
        public string InsertData(Blog blog)
        {
            SqlConnection con = null;
            string result = "";


            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

                SqlCommand cmd = new SqlCommand("PROC_CRUD_BLOG", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                //cmd.Parameters.AddWithValue("@IMG", blog.Image);
                cmd.Parameters.AddWithValue("@TITLE", blog.Title);
                cmd.Parameters.AddWithValue("@CONTENT", blog.Content);
                cmd.Parameters.AddWithValue("@TIMES", blog.Times);


                cmd.Parameters.AddWithValue("@SELECT", INSERT);
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
        public string UpdateData(Blog blog)
        {
            SqlConnection con = null;
            string result;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("PROC_CRUD_BLOG", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                //cmd.Parameters.AddWithValue("@IMG", blog.Image);
                cmd.Parameters.AddWithValue("@TITLE", blog.Title);
                cmd.Parameters.AddWithValue("@CONTENT", blog.Content);
                cmd.Parameters.AddWithValue("@ID", blog.ID);
                cmd.Parameters.AddWithValue("@TIMES", blog.Times);

                cmd.Parameters.AddWithValue("@SELECT", UPDATE);
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
                SqlCommand cmd = new SqlCommand("PROC_CRUD_BLOG", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ID", id);

                cmd.Parameters.AddWithValue("@SELECT", DELETE);
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
        public List<Blog> Selectalldata()
        {
            SqlConnection con = null;
            List<Blog> blogs = new List<Blog>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("PROC_CRUD_BLOG", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@SELECT", SELECTALL);
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
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString()),
                        Title = ds.Tables[0].Rows[i]["TITLE"].ToString(),
                        //Image = byte.Parse(ds.Tables[0].Rows[i]["IMG"].ToString()),
                        Times = DateTime.Parse(ds.Tables[0].Rows[i]["TIMES"].ToString()),
                        Content = ds.Tables[0].Rows[i]["CONTENT"].ToString(),
                    };

                    blogs.Add(blog);
                }

                return blogs;
            }
            catch (Exception ex)
            {
                return blogs;
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
        public Blog SelectDatabyID(int id)
        {
            SqlConnection con = null;
            Blog blogs = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("PROC_CRUD_BLOG", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@SELECT", SELECTBYID);

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    blogs = new Blog
                    {
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString()),
                        Title = ds.Tables[0].Rows[i]["TITLE"].ToString(),
                        //Image = byte.Parse(ds.Tables[0].Rows[i]["IMG"].ToString()),
                        Times = DateTime.Parse(ds.Tables[0].Rows[i]["TIMES"].ToString()),
                        Content = ds.Tables[0].Rows[i]["CONTENT"].ToString(),
                    };
                }

                return blogs;
            }
            catch (Exception ex)
            {
                return blogs;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Select Data By ID

        #region Search By Title

        /// <summary>
        /// Search By Title
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Blog> SearchByTitle(string name)
        {
            SqlConnection con = null;
            List<Blog> blogs = new List<Blog>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("PROC_CRUD_BLOG", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@TITLE", name);
                cmd.Parameters.AddWithValue("@SELECT", SELECTBYTITLE);

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
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString()),
                        Title = ds.Tables[0].Rows[i]["TITLE"].ToString(),
                        //Image = byte.Parse(ds.Tables[0].Rows[i]["IMG"].ToString()),
                        Times = DateTime.Parse(ds.Tables[0].Rows[i]["TIMES"].ToString()),
                        Content = ds.Tables[0].Rows[i]["CONTENT"].ToString()
                    };

                    blogs.Add(blog);
                }

                return blogs;
            }
            catch (Exception ex)
            {
                return blogs;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Search By Title

        #region Search By Content

        /// <summary>
        /// Search By Content
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Blog> SearchByContent(string name)
        {
            SqlConnection con = null;
            List<Blog> blogs = new List<Blog>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("PROC_CRUD_BLOG", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@CONTENT", name);
                cmd.Parameters.AddWithValue("@SELECT", SELECTBYCONTENT);

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
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString()),
                        Title = ds.Tables[0].Rows[i]["TITLE"].ToString(),
                        //Image = byte.Parse(ds.Tables[0].Rows[i]["IMG"].ToString()),
                        Times = DateTime.Parse(ds.Tables[0].Rows[i]["TIMES"].ToString()),
                        Content = ds.Tables[0].Rows[i]["CONTENT"].ToString()
                    };

                    blogs.Add(blog);
                }

                return blogs;
            }
            catch (Exception ex)
            {
                return blogs;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Search By Content

        #region Search By Time

        /// <summary>
        /// Search By Time
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public List<Blog> SearchByTime(string time)
        {
            SqlConnection con = null;
            List<Blog> blogs = new List<Blog>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("PROC_CRUD_BLOG", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@TIMES", time);
                cmd.Parameters.AddWithValue("@SELECT", SELECTBYTIME);

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
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString()),
                        Title = ds.Tables[0].Rows[i]["TITLE"].ToString(),
                        //Image = byte.Parse(ds.Tables[0].Rows[i]["IMG"].ToString()),
                        Times = DateTime.Parse(ds.Tables[0].Rows[i]["TIMES"].ToString()),
                        Content = ds.Tables[0].Rows[i]["CONTENT"].ToString()
                    };

                    blogs.Add(blog);
                }

                return blogs;
            }
            catch (Exception ex)
            {
                return blogs;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Search By Time
    }
}