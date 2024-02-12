using GoGIS_Data;
using GoGIS_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoGIS_Services.SliderService
{
    public class SliderService : ISliderService
    {
        private readonly IDbContext _dbContext = new GoGISAppContext();

        public Slider CreateSlider(Slider mod)
        {
            Slider model = new Slider();
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

                SqlParameter _LinkText = new SqlParameter();
                _LinkText.Direction = System.Data.ParameterDirection.Input;
                _LinkText.DbType = System.Data.DbType.String;
                _LinkText.ParameterName = "@linkText";
                _LinkText.Value = mod.linkText;

                SqlParameter _Tag = new SqlParameter();
                _Tag.Direction = System.Data.ParameterDirection.Input;
                _Tag.DbType = System.Data.DbType.String;
                _Tag.ParameterName = "@tag";
                _Tag.Value = mod.tag;

                SqlParameter _Link = new SqlParameter();
                _Link.Direction = System.Data.ParameterDirection.Input;
                _Link.DbType = System.Data.DbType.String;
                _Link.ParameterName = "@link";
                _Link.Value = mod.link;

                model = _dbContext.ExecuteStoredProcedure<Slider>("EXEC Slider_SP @actionId,@id,@title,@description,@linkText,@tag,@link", 
                    _ActionId, _Id, _Title, _Description, _LinkText, _Tag, _Link).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public List<Slider> AllSliderDetails()
        {
            List<Slider> model = new List<Slider>();
            try
            {
                SqlParameter _ActionId = new SqlParameter();
                _ActionId.Direction = System.Data.ParameterDirection.Input;
                _ActionId.DbType = System.Data.DbType.String;
                _ActionId.ParameterName = "@actionId";
                _ActionId.Value = 1;

                model = _dbContext.ExecuteStoredProcedure<Slider>("EXEC Slider_SP @actionId", _ActionId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public Slider DeleteSliderDetails(int id)
        {
            Slider model = new Slider();
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

                model = _dbContext.ExecuteStoredProcedure<Slider>("EXEC Slider_SP @actionId, @id", _ActionId, _Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public Slider GetSliderById(int id)
        {
            Slider model = new Slider();
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

                model = _dbContext.ExecuteStoredProcedure<Slider>("EXEC Slider_SP @actionId, @id", _ActionId, _Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public Slider UpdateSliderDetails(Slider mod)
        {
            Slider model = new Slider();
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

                SqlParameter _LinkText = new SqlParameter();
                _LinkText.Direction = System.Data.ParameterDirection.Input;
                _LinkText.DbType = System.Data.DbType.String;
                _LinkText.ParameterName = "@linkText";
                _LinkText.Value = mod.linkText;

                SqlParameter _Tag = new SqlParameter();
                _Tag.Direction = System.Data.ParameterDirection.Input;
                _Tag.DbType = System.Data.DbType.String;
                _Tag.ParameterName = "@tag";
                _Tag.Value = mod.tag;

                SqlParameter _Link = new SqlParameter();
                _Link.Direction = System.Data.ParameterDirection.Input;
                _Link.DbType = System.Data.DbType.String;
                _Link.ParameterName = "@link";
                _Link.Value = mod.link;

                model = _dbContext.ExecuteStoredProcedure<Slider>("EXEC Slider_SP @actionId,@id,@title,@description,@linkText,@tag,@link", 
                    _ActionId, _Id, _Title, _Description, _LinkText, _Tag, _Link).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
    }
}
