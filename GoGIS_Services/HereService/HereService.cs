using GoGIS_Data;
using GoGIS_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoGIS_Services.HereService
{
    public class HereService : IHereService
    {
        private readonly IDbContext _dbContext = new GoGISAppContext();

        public Here CreateHere(Here mod)
        {
            Here model = new Here();
            try
            {
                SqlParameter _ActionId = new SqlParameter();
                _ActionId.Direction = System.Data.ParameterDirection.Input;
                _ActionId.DbType = System.Data.DbType.Int32;
                _ActionId.ParameterName = "@actionId";
                _ActionId.Value = 4;

                SqlParameter _Id = new SqlParameter();
                _Id.Direction = System.Data.ParameterDirection.Input;
                _Id.DbType = System.Data.DbType.Int32;
                _Id.ParameterName = "@id";
                _Id.Value = mod.id;

                SqlParameter _Title = new SqlParameter();
                _Title.Direction = System.Data.ParameterDirection.Input;
                _Title.DbType = System.Data.DbType.String;
                _Title.ParameterName = "@title";
                _Title.Value = mod.title;

                SqlParameter _Description = new SqlParameter();
                _Description.Direction = System.Data.ParameterDirection.Input;
                _Description.DbType = System.Data.DbType.String;
                _Description.ParameterName = "@description";
                _Description.Value = mod.description;

                model = _dbContext.ExecuteStoredProcedure<Here>("EXEC Here_SP @actionId,@id,@title,@description",
                    _ActionId, _Id, _Title, _Description).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public List<Here> AllHereDetails()
        {
            List<Here> model = new List<Here>();
            try
            {
                SqlParameter _ActionId = new SqlParameter();
                _ActionId.Direction = System.Data.ParameterDirection.Input;
                _ActionId.DbType = System.Data.DbType.String;
                _ActionId.ParameterName = "@actionId";
                _ActionId.Value = 1;

                model = _dbContext.ExecuteStoredProcedure<Here>("EXEC Here_SP @actionId", _ActionId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public Here DeleteHereDetails(int id)
        {
            Here model = new Here();
            try
            {
                SqlParameter _ActionId = new SqlParameter();
                _ActionId.Direction = System.Data.ParameterDirection.Input;
                _ActionId.DbType = System.Data.DbType.String;
                _ActionId.ParameterName = "@actionId";
                _ActionId.Value = 3;

                SqlParameter _Id = new SqlParameter();
                _Id.Direction = System.Data.ParameterDirection.Input;
                _Id.DbType = System.Data.DbType.Int32;
                _Id.ParameterName = "@id";
                _Id.Value = id;

                model = _dbContext.ExecuteStoredProcedure<Here>("EXEC Here_SP @actionId, @id", _ActionId, _Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public Here GetHereById(int id)
        {
            Here model = new Here();
            try
            {
                SqlParameter _ActionId = new SqlParameter();
                _ActionId.Direction = System.Data.ParameterDirection.Input;
                _ActionId.DbType = System.Data.DbType.String;
                _ActionId.ParameterName = "@actionId";
                _ActionId.Value = 2;

                SqlParameter _Id = new SqlParameter();
                _Id.Direction = System.Data.ParameterDirection.Input;
                _Id.DbType = System.Data.DbType.Int32;
                _Id.ParameterName = "@id";
                _Id.Value = id;

                model = _dbContext.ExecuteStoredProcedure<Here>("EXEC Here_SP @actionId, @id", _ActionId, _Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        //public Here UpdateHereDetails(Here mod)
        //{
        //    Here model = new Here();
        //    try
        //    {
        //        SqlParameter _ActionId = new SqlParameter();
        //        _ActionId.Direction = System.Data.ParameterDirection.Input;
        //        _ActionId.DbType = System.Data.DbType.String;
        //        _ActionId.ParameterName = "@actionId";
        //        _ActionId.Value = 5;

        //        SqlParameter _Id = new SqlParameter();
        //        _Id.Direction = System.Data.ParameterDirection.Input;
        //        _Id.DbType = System.Data.DbType.Int32;
        //        _Id.ParameterName = "@id";
        //        _Id.Value = mod.id;

        //        SqlParameter _Title = new SqlParameter();
        //        _Title.Direction = System.Data.ParameterDirection.Input;
        //        _Title.DbType = System.Data.DbType.String;
        //        _Title.ParameterName = "@title";
        //        _Title.Value = mod.title;

        //        SqlParameter _Description = new SqlParameter();
        //        _Description.Direction = System.Data.ParameterDirection.Input;
        //        _Description.DbType = System.Data.DbType.String;
        //        _Description.ParameterName = "@description";
        //        _Description.Value = mod.description;

        //        model = _dbContext.ExecuteStoredProcedure<Here>("EXEC Here_SP @actionId,@id,@title,@description",
        //            _ActionId, _Id, _Title, _Description).FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return model;
        //}
    }
}
