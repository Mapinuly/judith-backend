using GoGIS_Data;
using GoGIS_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoGIS_Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IDbContext _dbContext = new GoGISAppContext();

        public UserDetails Login(string userEmail, string password)
        {
            UserDetails model = new UserDetails();
            try
            {
                SqlParameter _UserEmail = new SqlParameter();
                _UserEmail.Direction = System.Data.ParameterDirection.Input;
                _UserEmail.DbType = System.Data.DbType.String;
                _UserEmail.ParameterName = "@userEmail";
                _UserEmail.Value = userEmail;

                SqlParameter _Password = new SqlParameter();
                _Password.Direction = System.Data.ParameterDirection.Input;
                _Password.DbType = System.Data.DbType.String;
                _Password.ParameterName = "@password";
                _Password.Value = password;

                model = _dbContext.ExecuteStoredProcedure<UserDetails>("EXEC UserLogin @userEmail,@password", _UserEmail, _Password).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public UserDetails Signup(string userName, string userEmail, string password)
        {
            UserDetails model = new UserDetails();
            try
            {
                SqlParameter _UserName = new SqlParameter();
                _UserName.Direction = System.Data.ParameterDirection.Input;
                _UserName.DbType = System.Data.DbType.String;
                _UserName.ParameterName = "@userName";
                _UserName.Value = userName;

                SqlParameter _UserEmail = new SqlParameter();
                _UserEmail.Direction = System.Data.ParameterDirection.Input;
                _UserEmail.DbType = System.Data.DbType.String;
                _UserEmail.ParameterName = "@userEmail";
                _UserEmail.Value = userEmail;

                SqlParameter _Password = new SqlParameter();
                _Password.Direction = System.Data.ParameterDirection.Input;
                _Password.DbType = System.Data.DbType.String;
                _Password.ParameterName = "@password";
                _Password.Value = password;

                model = _dbContext.ExecuteStoredProcedure<UserDetails>("EXEC UserSignup @userName, @userEmail,@password", _UserName, _UserEmail, _Password).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public List<UserDetails> AllUserDetails()
        {
            List<UserDetails> model = new List<UserDetails>();
            try
            {
                model = _dbContext.ExecuteStoredProcedure<UserDetails>("EXEC AllUserDetails").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public UserDetails DeleteUserDetails(int id)
        {
            UserDetails user = new UserDetails();
            try
            {
                SqlParameter _Id = new SqlParameter();
                _Id.Direction = System.Data.ParameterDirection.Input;
                _Id.DbType = System.Data.DbType.Int32;
                _Id.ParameterName = "@id";
                _Id.Value = id;

                user = _dbContext.ExecuteStoredProcedure<UserDetails>("EXEC DeleteUserDetails @id", _Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }

        public UserDetails GetUserById(int id)
        {
            UserDetails model = new UserDetails();
            try
            {
                SqlParameter _Id = new SqlParameter();
                _Id.Direction = System.Data.ParameterDirection.Input;
                _Id.DbType = System.Data.DbType.Int32;
                _Id.ParameterName = "@id";
                _Id.Value = id;

                model = _dbContext.ExecuteStoredProcedure<UserDetails>("EXEC UserDetailsById @id", _Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public UserDetails UpdateUserDetails(UserDetails user)
        {
            UserDetails model = new UserDetails();
            try
            {
                SqlParameter _Id = new SqlParameter();
                _Id.Direction = System.Data.ParameterDirection.Input;
                _Id.DbType = System.Data.DbType.Int32;
                _Id.ParameterName = "@id";
                _Id.Value = user.id;

                SqlParameter _UserName = new SqlParameter();
                _UserName.Direction = System.Data.ParameterDirection.Input;
                _UserName.DbType = System.Data.DbType.String;
                _UserName.ParameterName = "@userName";
                _UserName.Value = user.name;

                model = _dbContext.ExecuteStoredProcedure<UserDetails>("EXEC UpdateUserDetails @id, @userName", _Id, _UserName).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public UserDetails CheckEmailExists(string userEmail)
        {
            UserDetails model = new UserDetails();
            try
            {
                SqlParameter _UserEmail = new SqlParameter();
                _UserEmail.Direction = System.Data.ParameterDirection.Input;
                _UserEmail.DbType = System.Data.DbType.String;
                _UserEmail.ParameterName = "@userEmail";
                _UserEmail.Value = userEmail;

                model = _dbContext.ExecuteStoredProcedure<UserDetails>("EXEC CheckEmail @userEmail", _UserEmail).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
    }
}
