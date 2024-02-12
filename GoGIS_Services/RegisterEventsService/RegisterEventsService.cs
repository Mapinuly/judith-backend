using GoGIS_Data;
using GoGIS_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoGIS_Services.RegisterEventsService
{
    public class RegisterEventsService : IRegisterEventsService
    {
        private readonly IDbContext _dbContext = new GoGISAppContext();

        public RegisterEvents CreateRegisterEvents(RegisterEvents mod)
        {
            RegisterEvents model = new RegisterEvents();
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

                SqlParameter _eventname = new SqlParameter();
                _eventname.Direction = System.Data.ParameterDirection.Input;
                _eventname.DbType = System.Data.DbType.String;
                _eventname.ParameterName = "@eventname";
                _eventname.Value = mod.eventname;

                SqlParameter _firstname = new SqlParameter();
                _firstname.Direction = System.Data.ParameterDirection.Input;
                _firstname.DbType = System.Data.DbType.String;
                _firstname.ParameterName = "@firstname";
                _firstname.Value = mod.firstname;

                SqlParameter _lastname = new SqlParameter();
                _lastname.Direction = System.Data.ParameterDirection.Input;
                _lastname.DbType = System.Data.DbType.String;
                _lastname.ParameterName = "@lastname";
                _lastname.Value = mod.lastname;

                SqlParameter _jobdescription = new SqlParameter();
                _jobdescription.Direction = System.Data.ParameterDirection.Input;
                _jobdescription.DbType = System.Data.DbType.String;
                _jobdescription.ParameterName = "@jobdescription";
                _jobdescription.Value = mod.jobdescription;

                SqlParameter _organisation = new SqlParameter();
                _organisation.Direction = System.Data.ParameterDirection.Input;
                _organisation.DbType = System.Data.DbType.String;
                _organisation.ParameterName = "@organisation";
                _organisation.Value = mod.organisation;

                SqlParameter _phone1 = new SqlParameter();
                _phone1.Direction = System.Data.ParameterDirection.Input;
                _phone1.DbType = System.Data.DbType.String;
                _phone1.ParameterName = "@phone1";
                _phone1.Value = mod.phone1;

                SqlParameter _phone2 = new SqlParameter();
                _phone2.Direction = System.Data.ParameterDirection.Input;
                _phone2.DbType = System.Data.DbType.String;
                _phone2.ParameterName = "@phone2";
                _phone2.Value = mod.phone2;

                SqlParameter _email = new SqlParameter();
                _email.Direction = System.Data.ParameterDirection.Input;
                _email.DbType = System.Data.DbType.String;
                _email.ParameterName = "@email";
                _email.Value = mod.email;

                model = _dbContext.ExecuteStoredProcedure<RegisterEvents>("EXEC RegisterEvents_SP @actionId,@id,@eventname,@firstname,@lastname,@jobdescription,@organisation,@phone1,@phone2,@email",
                    _ActionId, _Id, _eventname, _firstname, _lastname, _jobdescription, _organisation, _phone1, _phone2, _email).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public List<RegisterEvents> AllRegisterEventsDetails()
        {
            List<RegisterEvents> model = new List<RegisterEvents>();
            try
            {
                SqlParameter _ActionId = new SqlParameter();
                _ActionId.Direction = System.Data.ParameterDirection.Input;
                _ActionId.DbType = System.Data.DbType.String;
                _ActionId.ParameterName = "@actionId";
                _ActionId.Value = 1;

                model = _dbContext.ExecuteStoredProcedure<RegisterEvents>("EXEC RegisterEvents_SP @actionId", _ActionId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public RegisterEvents DeleteRegisterEventsDetails(int id)
        {
            RegisterEvents model = new RegisterEvents();
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

                model = _dbContext.ExecuteStoredProcedure<RegisterEvents>("EXEC RegisterEvents_SP @actionId, @id", _ActionId, _Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public RegisterEvents GetEventsById(int id)
        {
            RegisterEvents model = new RegisterEvents();
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

                model = _dbContext.ExecuteStoredProcedure<RegisterEvents>("EXEC RegisterEvents_SP @actionId, @id", _ActionId, _Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public RegisterEvents UpdateRegisterEventsDetails(RegisterEvents mod)
        {
            RegisterEvents model = new RegisterEvents();
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

                SqlParameter _eventname = new SqlParameter();
                _eventname.Direction = System.Data.ParameterDirection.Input;
                _eventname.DbType = System.Data.DbType.String;
                _eventname.ParameterName = "@eventname";
                _eventname.Value = mod.eventname;

                SqlParameter _firstname = new SqlParameter();
                _firstname.Direction = System.Data.ParameterDirection.Input;
                _firstname.DbType = System.Data.DbType.String;
                _firstname.ParameterName = "@firstname";
                _firstname.Value = mod.firstname;

                SqlParameter _lastname = new SqlParameter();
                _lastname.Direction = System.Data.ParameterDirection.Input;
                _lastname.DbType = System.Data.DbType.String;
                _lastname.ParameterName = "@lastname";
                _lastname.Value = mod.lastname;

                SqlParameter _jobdescription = new SqlParameter();
                _jobdescription.Direction = System.Data.ParameterDirection.Input;
                _jobdescription.DbType = System.Data.DbType.String;
                _jobdescription.ParameterName = "@jobdescription";
                _jobdescription.Value = mod.jobdescription;

                SqlParameter _organisation = new SqlParameter();
                _organisation.Direction = System.Data.ParameterDirection.Input;
                _organisation.DbType = System.Data.DbType.String;
                _organisation.ParameterName = "@organisation";
                _organisation.Value = mod.organisation;

                SqlParameter _phone1 = new SqlParameter();
                _phone1.Direction = System.Data.ParameterDirection.Input;
                _phone1.DbType = System.Data.DbType.String;
                _phone1.ParameterName = "@phone1";
                _phone1.Value = mod.phone1;

                SqlParameter _phone2 = new SqlParameter();
                _phone2.Direction = System.Data.ParameterDirection.Input;
                _phone2.DbType = System.Data.DbType.String;
                _phone2.ParameterName = "@phone2";
                _phone2.Value = mod.phone2;

                SqlParameter _email = new SqlParameter();
                _email.Direction = System.Data.ParameterDirection.Input;
                _email.DbType = System.Data.DbType.String;
                _email.ParameterName = "@email";
                _email.Value = mod.email;

                model = _dbContext.ExecuteStoredProcedure<RegisterEvents>("EXEC RegisterEvents_SP @actionId,@id,@eventname,@firstname,@lastname,@jobdescription,@organisation,@phone1,@phone2,@email",
                    _ActionId, _Id, _eventname, _firstname, _lastname, _jobdescription, _organisation, _phone1, _phone2, _email).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
    }
}
