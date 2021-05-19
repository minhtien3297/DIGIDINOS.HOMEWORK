using cvManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace cvManagement.DataAccessLayer
{
    public class PositionLayer
    {
        private const int QUERY_SELECTALL = 1;

        #region Selectalldata

        /// <summary>
        /// Lay toan bo account
        /// </summary>
        /// <returns value="List<Account>" name="listAccount"></returns>
        public List<Position> Selectalldata()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
            SqlCommand cmd = new SqlCommand("Usp_Position", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@id", null);
            cmd.Parameters.AddWithValue("@name", null);
            cmd.Parameters.AddWithValue("@Query", QUERY_SELECTALL);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter
            {
                SelectCommand = cmd
            };
            DataSet ds = new DataSet();
            da.Fill(ds);
            List<Position> listPositon = new List<Position>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Position positionObject = new Position
                {
                    Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                    Name = ds.Tables[0].Rows[i]["name"].ToString()
                };
                listPositon.Add(positionObject);
            }

            return listPositon;
        }

        #endregion Selectalldata
    }
}