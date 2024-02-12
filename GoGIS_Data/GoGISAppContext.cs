using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace GoGIS_Data
{
    public class GoGISAppContext : DbContext, IDbContext
    {
        #region CTor
        public GoGISAppContext() : base("DefaultConnection")
        {

        }
        #endregion

        #region Model Builders
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
        #endregion

        #region Special Methods
        public IList<T> ExecuteStoredProcedure<T>(string query, params object[] parameters)
        {
            try
            {
                this.Database.CommandTimeout = 600;
                return this.Database.SqlQuery<T>(query, parameters).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ExecuteStoredProcedureDataTable(string storedProcedureName, params SqlParameter[] arrParam)
        {
            DBConnect connaction = new DBConnect();
            DataTable dt = new DataTable();
            try
            {
                dt = connaction.ExecuteDataTable(storedProcedureName, arrParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataSet ExecuteStoredProcedureDataSet(string storedProcedureName, params SqlParameter[] arrParam)
        {
            DBConnect connaction = new DBConnect();
            DataSet dt = new DataSet();
            try
            {
                dt = connaction.ExecuteDataSet(storedProcedureName, arrParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable ExecuteSqlDataTable(string SqlQuery, params SqlParameter[] arrParam)
        {
            DBConnect connaction = new DBConnect();
            DataTable dt = new DataTable();
            try
            {
                dt = connaction.ExecuteSqlQuery(SqlQuery, arrParam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public bool ExecuteInsertQuery(string SqlQuery, params SqlParameter[] arrParam)
        {
            bool status = false;

            DBConnect connaction = new DBConnect();
            try
            {
                int rowsAffected = connaction.InsertData(SqlQuery, arrParam);
                status = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        #endregion
    }
}
