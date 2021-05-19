using cvManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace cvManagement.DataAccessLayer
{
    public class SourceLayer
    {
        #region Selectalldata

        /// <summary>
        /// Lay toan bo account
        /// </summary>
        /// <returns value="List<Account>" name="listAccount"></returns>
        public List<Source> Selectalldata()
        {
            SqlConnection conn = null;
            DataSet ds = null;
            List<Source> listSource = null;

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CVMANAGEMENT"].ToString());
            SqlCommand cmd = new SqlCommand("Usp_Position", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", null);
            cmd.Parameters.AddWithValue("@name", null);
            cmd.Parameters.AddWithValue("@Query", 2);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);
            listSource = new List<Source>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Source sourceObject = new Source();
                sourceObject.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                sourceObject.Name = ds.Tables[0].Rows[i]["name"].ToString();
                listSource.Add(sourceObject);
            }

            return listSource;
        }

        #endregion Selectalldata
    }
}