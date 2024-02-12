using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GoGIS_Data
{
    public interface IDbContext
    {
        IList<T> ExecuteStoredProcedure<T>(string query, params object[] parameters);
        DataTable ExecuteStoredProcedureDataTable(string storedProcedureName, params SqlParameter[] arrParam);
        bool ExecuteInsertQuery(string SqlQuery, params SqlParameter[] arrParam);
        DataTable ExecuteSqlDataTable(string SqlQuery, params SqlParameter[] arrParam);
        DataSet ExecuteStoredProcedureDataSet(string storedProcedureName, params SqlParameter[] arrParam);
    }
}
