using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GoGIS_Data
{
    public class DBConnect
    {
        public DataTable ExecuteDataTable(string storedProcedureName, params SqlParameter[] arrParam)
        {
            DataTable dt = new DataTable();

            // Open the connection 
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                cnn.Open();

                // Define the command 
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandTimeout = 500;
                    // Handle the parameters 
                    if (arrParam != null)
                    {
                        foreach (SqlParameter param in arrParam)
                            cmd.Parameters.Add(param);
                    }

                    // Define the data adapter and fill the dataset 
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;

        }
        public DataSet ExecuteDataSet(string storedProcedureName, params SqlParameter[] arrParam)
        {
            DataSet dt = new DataSet();

            // Open the connection 
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                cnn.Open();

                // Define the command 
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandTimeout = 500;
                    // Handle the parameters 
                    if (arrParam != null)
                    {
                        foreach (SqlParameter param in arrParam)
                            cmd.Parameters.Add(param);
                    }

                    // Define the data adapter and fill the dataset 
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;

        }
        public DataTable ExecuteSqlQuery(string SqlQuery, params SqlParameter[] arrParam)
        {
            DataTable dt = new DataTable();

            // Open the connection 
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                cnn.Open();

                // Define the command 
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SqlQuery;

                    // Handle the parameters 
                    if (arrParam != null)
                    {
                        foreach (SqlParameter param in arrParam)
                            cmd.Parameters.Add(param);
                    }

                    // Define the data adapter and fill the dataset 
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;

        }
        public int InsertData(string SqlQuery, params SqlParameter[] arrParam)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    if (cnn.State == ConnectionState.Closed)
                    {
                        cnn.Open();
                    }

                    // Define the command 
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = SqlQuery;

                        // Handle the parameters 
                        if (arrParam != null)
                        {
                            foreach (SqlParameter param in arrParam)
                                cmd.Parameters.Add(param);
                        }


                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

            return rowsAffected;
        }
    }
}
