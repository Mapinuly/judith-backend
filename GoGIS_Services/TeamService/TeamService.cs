using GoGIS_Data;
using GoGIS_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoGIS_Services.TeamService
{
    public class TeamService : ITeamService
    {
        private readonly IDbContext _dbContext = new GoGISAppContext();

        public Team CreateTeam(Team mod)
        {
            Team model = new Team();
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

                SqlParameter _Name = new SqlParameter();
                _Name.Direction = System.Data.ParameterDirection.Input;
                _Name.DbType = System.Data.DbType.String;
                _Name.ParameterName = "@name";
                _Name.Value = mod.name;

                SqlParameter _Designation = new SqlParameter();
                _Designation.Direction = System.Data.ParameterDirection.Input;
                _Designation.DbType = System.Data.DbType.String;
                _Designation.ParameterName = "@designation";
                _Designation.Value = mod.designation;

                SqlParameter _Bio = new SqlParameter();
                _Bio.Direction = System.Data.ParameterDirection.Input;
                _Bio.DbType = System.Data.DbType.String;
                _Bio.ParameterName = "@bio";
                _Bio.Value = mod.bio;

                SqlParameter _Img = new SqlParameter();
                _Img.Direction = System.Data.ParameterDirection.Input;
                _Img.DbType = System.Data.DbType.String;
                _Img.ParameterName = "@img";
                _Img.Value = mod.img;

                model = _dbContext.ExecuteStoredProcedure<Team>("EXEC Team_SP @actionId,@id,@name,@designation,@bio,@img",
                    _ActionId, _Id, _Name, _Designation, _Bio, _Img).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public List<Team> AllTeamDetails()
        {
            List<Team> model = new List<Team>();
            try
            {
                SqlParameter _ActionId = new SqlParameter();
                _ActionId.Direction = System.Data.ParameterDirection.Input;
                _ActionId.DbType = System.Data.DbType.String;
                _ActionId.ParameterName = "@actionId";
                _ActionId.Value = 1;

                model = _dbContext.ExecuteStoredProcedure<Team>("EXEC Team_SP @actionId", _ActionId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public Team DeleteTeamDetails(int id)
        {
            Team model = new Team();
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

                model = _dbContext.ExecuteStoredProcedure<Team>("EXEC Team_SP @actionId, @id", _ActionId, _Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public Team GetTeamById(int id)
        {
            Team model = new Team();
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

                model = _dbContext.ExecuteStoredProcedure<Team>("EXEC Team_SP @actionId, @id", _ActionId, _Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public Team UpdateTeamDetails(Team mod)
        {
            Team model = new Team();
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

                SqlParameter _Name = new SqlParameter();
                _Name.Direction = System.Data.ParameterDirection.Input;
                _Name.DbType = System.Data.DbType.String;
                _Name.ParameterName = "@name";
                _Name.Value = mod.name;

                SqlParameter _Designation = new SqlParameter();
                _Designation.Direction = System.Data.ParameterDirection.Input;
                _Designation.DbType = System.Data.DbType.String;
                _Designation.ParameterName = "@designation";
                _Designation.Value = mod.designation;

                SqlParameter _Bio = new SqlParameter();
                _Bio.Direction = System.Data.ParameterDirection.Input;
                _Bio.DbType = System.Data.DbType.String;
                _Bio.ParameterName = "@bio";
                _Bio.Value = mod.bio;

                SqlParameter _Img = new SqlParameter();
                _Img.Direction = System.Data.ParameterDirection.Input;
                _Img.DbType = System.Data.DbType.String;
                _Img.ParameterName = "@img";
                _Img.Value = mod.img;

                model = _dbContext.ExecuteStoredProcedure<Team>("EXEC Team_SP @actionId,@id,@name,@designation,@bio,@img",
                    _ActionId, _Id, _Name, _Designation, _Bio, _Img).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
    }
}
