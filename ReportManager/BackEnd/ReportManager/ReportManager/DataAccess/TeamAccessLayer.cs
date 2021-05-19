using ReportManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReportManager.DataAccess
{
    public class TeamAccessLayer
    {
        private const int SEARCHBYDONE = 1;
        private const int INSERTQUERY = 2;
        private const int UPDATEQUERY = 3;
        private const int DELETEQUERY = 4;
        private const int SELECTQUERY = 5;
        private const int SELECTBYIDQUERY = 6;

        #region Insert Data

        /// <summary>
        /// Insert Data
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public string InsertData(Teams team)
        {
            SqlConnection con = null;
            string result;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

                SqlCommand cmd = new SqlCommand("proc_CRUD_teams", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@name", team.Name);
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
        /// <param name="team"></param>
        /// <returns></returns>
        public string UpdateData(Teams team)
        {
            SqlConnection con = null;
            string result;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_teams", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", team.ID);
                cmd.Parameters.AddWithValue("@name", team.Name);
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
                SqlCommand cmd = new SqlCommand("proc_CRUD_teams", con)
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
        public List<Teams> Selectalldata()
        {
            SqlConnection con = null;
            List<Teams> Teams = new List<Teams>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_teams", con)
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
                    Teams team = new Teams
                    {
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Name = ds.Tables[0].Rows[i]["name"].ToString(),
                    };

                    Teams.Add(team);
                }

                return Teams;
            }
            catch (Exception ex)
            {
                return Teams;
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
        public Teams SelectDatabyID(int id)
        {
            SqlConnection con = null;
            Teams team = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_teams", con)
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
                    team = new Teams
                    {
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Name = ds.Tables[0].Rows[i]["name"].ToString(),
                    };
                }

                return team;
            }
            catch (Exception ex)
            {
                return team;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Select Data By ID

        #region Search By Name

        /// <summary>
        /// Search By Title
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Teams> SearchByTitle(string name)
        {
            SqlConnection con = null;
            List<Teams> teams = new List<Teams>();

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("proc_CRUD_teams", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@select", SEARCHBYDONE);

                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Teams team = new Teams
                    {
                        ID = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        Name = ds.Tables[0].Rows[i]["name"].ToString(),
                    };

                    teams.Add(team);
                }

                return teams;
            }
            catch (Exception ex)
            {
                return teams;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion Search By Name
    }
}