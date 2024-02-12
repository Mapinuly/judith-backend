using GoGIS_Data;
using GoGIS_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoGIS_Services.EventService
{
    public class EventService : IEventService
    {
        private readonly IDbContext _dbContext = new GoGISAppContext();

        public Events CreateUpcomingEvents(Events mod)
        {
            Events model = new Events();
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

                SqlParameter _img = new SqlParameter();
                _img.Direction = System.Data.ParameterDirection.Input;
                _img.DbType = System.Data.DbType.String;
                _img.ParameterName = "@img";
                _img.Value = mod.img;

                SqlParameter _start_date = new SqlParameter();
                _start_date.Direction = System.Data.ParameterDirection.Input;
                _start_date.DbType = System.Data.DbType.DateTime;
                _start_date.ParameterName = "@start_date";
                _start_date.Value = mod.start_date;

                SqlParameter _end_date = new SqlParameter();
                _end_date.Direction = System.Data.ParameterDirection.Input;
                _end_date.DbType = System.Data.DbType.DateTime;
                _end_date.ParameterName = "@end_date";
                _end_date.Value = mod.end_date;

                model = _dbContext.ExecuteStoredProcedure<Events>("EXEC Events_SP @actionId,@id,@title,@description,@img,@start_date,@end_date",
                    _ActionId, _Id, _Title, _Description, _img, _start_date, _end_date).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public List<Events> AllUpcomingEventsDetails()
        {
            List<Events> model = new List<Events>();
            try
            {
                SqlParameter _ActionId = new SqlParameter();
                _ActionId.Direction = System.Data.ParameterDirection.Input;
                _ActionId.DbType = System.Data.DbType.String;
                _ActionId.ParameterName = "@actionId";
                _ActionId.Value = 1;

                model = _dbContext.ExecuteStoredProcedure<Events>("EXEC Events_SP @actionId", _ActionId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public Events DeleteUpcomingEventsDetails(int id)
        {
            Events model = new Events();
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

                model = _dbContext.ExecuteStoredProcedure<Events>("EXEC Events_SP @actionId, @id", _ActionId, _Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public Events GetEventsById(int id)
        {
            Events model = new Events();
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

                model = _dbContext.ExecuteStoredProcedure<Events>("EXEC Events_SP @actionId, @id", _ActionId, _Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public Events UpdateUpcomingEventsDetails(Events mod)
        {
            Events model = new Events();
            try
            {
                SqlParameter _ActionId = new SqlParameter();
                _ActionId.Direction = System.Data.ParameterDirection.Input;
                _ActionId.DbType = System.Data.DbType.String;
                _ActionId.ParameterName = "@actionId";
                _ActionId.Value = 5;

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

                SqlParameter _img = new SqlParameter();
                _img.Direction = System.Data.ParameterDirection.Input;
                _img.DbType = System.Data.DbType.String;
                _img.ParameterName = "@img";
                _img.Value = mod.img;

                SqlParameter _start_date = new SqlParameter();
                _start_date.Direction = System.Data.ParameterDirection.Input;
                _start_date.DbType = System.Data.DbType.DateTime;
                _start_date.ParameterName = "@start_date";
                _start_date.Value = mod.start_date;

                SqlParameter _end_date = new SqlParameter();
                _end_date.Direction = System.Data.ParameterDirection.Input;
                _end_date.DbType = System.Data.DbType.DateTime;
                _end_date.ParameterName = "@end_date";
                _end_date.Value = mod.end_date;

                model = _dbContext.ExecuteStoredProcedure<Events>("EXEC Events_SP @actionId,@id,@title,@description,@img,@start_date,@end_date",
                    _ActionId, _Id, _Title, _Description, _img, _start_date, _end_date).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public List<Events> AllEventsDetails()
        {
            List<Events> model = new List<Events>();
            try
            {
                SqlParameter _ActionId = new SqlParameter();
                _ActionId.Direction = System.Data.ParameterDirection.Input;
                _ActionId.DbType = System.Data.DbType.String;
                _ActionId.ParameterName = "@actionId";
                _ActionId.Value = 6;

                model = _dbContext.ExecuteStoredProcedure<Events>("EXEC Events_SP @actionId", _ActionId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
    }
}
