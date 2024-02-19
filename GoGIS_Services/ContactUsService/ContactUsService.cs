using GoGIS_Data;
using GoGIS_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace GoGIS_Services.ContactUsService
{
    public class ContactUsService : IContactUsService
    {
        private readonly IDbContext _dbContext = new GoGISAppContext();

        public ContactUs CreateContactUs(ContactUs mod)
        {
            ContactUs model = new ContactUs();
            try
            {
                SqlParameter _ActionId = new SqlParameter();
                _ActionId.Direction = System.Data.ParameterDirection.Input;
                _ActionId.DbType = System.Data.DbType.Int32;
                _ActionId.ParameterName = "@actionId";
                _ActionId.Value = 2;

                SqlParameter _Title = new SqlParameter();
                _Title.Direction = System.Data.ParameterDirection.Input;
                _Title.DbType = System.Data.DbType.String;
                _Title.ParameterName = "@sub_title";
                _Title.Value = mod.sub_title;

                SqlParameter _Email = new SqlParameter();
                _Email.Direction = System.Data.ParameterDirection.Input;
                _Email.DbType = System.Data.DbType.String;
                _Email.ParameterName = "@email";
                _Email.Value = mod.email;

                SqlParameter _Phone = new SqlParameter();
                _Phone.Direction = System.Data.ParameterDirection.Input;
                _Phone.DbType = System.Data.DbType.String;
                _Phone.ParameterName = "@phone";
                _Phone.Value = mod.phone;

                SqlParameter _Message = new SqlParameter();
                _Message.Direction = System.Data.ParameterDirection.Input;
                _Message.DbType = System.Data.DbType.String;
                _Message.ParameterName = "@message";
                _Message.Value = mod.message;

                SqlParameter _Name = new SqlParameter();
                _Name.Direction = System.Data.ParameterDirection.Input;
                _Name.DbType = System.Data.DbType.String;
                _Name.ParameterName = "@name";
                _Name.Value = mod.name;

               SqlParameter _Id = new SqlParameter();
                _Id.Direction = System.Data.ParameterDirection.Input;
                _Id.DbType = System.Data.DbType.Int32;
                _Id.ParameterName = "@id";
                _Id.Value = mod.id;

                model = _dbContext.ExecuteStoredProcedure<ContactUs>("EXEC ContactUs_SP @actionId,@id,@sub_title,@email,@phone,@message,@name",
                    _ActionId, _Id, _Title, _Email, _Phone, _Message, _Name).FirstOrDefault();

                List<Tech_Interest> tech_Interest = new List<Tech_Interest>();
                foreach (var item in mod.Technology_of_interest)
                {
                    Tech_Interest tech_Interest1 = new Tech_Interest();
                    SqlParameter _ActionId1 = new SqlParameter();
                    _ActionId1.Direction = System.Data.ParameterDirection.Input;
                    _ActionId1.DbType = System.Data.DbType.Int32;
                    _ActionId1.ParameterName = "@actionId";
                    _ActionId1.Value = 2;

                    SqlParameter _ContactId = new SqlParameter();
                    _ContactId.Direction = System.Data.ParameterDirection.Input;
                    _ContactId.DbType = System.Data.DbType.Int32;
                    _ContactId.ParameterName = "@contact_us_id";
                    _ContactId.Value = model.id;

                    SqlParameter _Title1 = new SqlParameter();
                    _Title1.Direction = System.Data.ParameterDirection.Input;
                    _Title1.DbType = System.Data.DbType.String;
                    _Title1.ParameterName = "@title";
                    _Title1.Value = item.title;

                    SqlParameter _Options = new SqlParameter();
                    _Options.Direction = System.Data.ParameterDirection.Input;
                    _Options.DbType = System.Data.DbType.String;
                    _Options.ParameterName = "@options";
                    _Options.Value = item.options;

                    tech_Interest1 = _dbContext.ExecuteStoredProcedure<Tech_Interest>("EXEC TechInterest_SP @actionId,@contact_us_id,@title,@options",
                        _ActionId1, _ContactId, _Title1, _Options).FirstOrDefault();

                    tech_Interest.Add(tech_Interest1);
                }
                model.Technology_of_interest = tech_Interest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public List<ContactUs> AllContactUsDetails()
        {
            List<ContactUs> model = new List<ContactUs>();
            try
            {
                SqlParameter _ActionId = new SqlParameter();
                _ActionId.Direction = System.Data.ParameterDirection.Input;
                _ActionId.DbType = System.Data.DbType.String;
                _ActionId.ParameterName = "@actionId";
                _ActionId.Value = 1;

                model = _dbContext.ExecuteStoredProcedure<ContactUs>("EXEC ContactUs_SP @actionId", _ActionId).ToList();

                foreach (var item in model)
                {
                    List<Tech_Interest> tech_Interests = new List<Tech_Interest>();
                    SqlParameter _ActionId1 = new SqlParameter();
                    _ActionId1.Direction = System.Data.ParameterDirection.Input;
                    _ActionId1.DbType = System.Data.DbType.String;
                    _ActionId1.ParameterName = "@actionId";
                    _ActionId1.Value = 1;

                    SqlParameter _ContactId = new SqlParameter();
                    _ContactId.Direction = System.Data.ParameterDirection.Input;
                    _ContactId.DbType = System.Data.DbType.String;
                    _ContactId.ParameterName = "@contact_us_id";
                    _ContactId.Value = item.id;

                    tech_Interests = _dbContext.ExecuteStoredProcedure<Tech_Interest>("EXEC TechInterest_SP @actionId,@contact_us_id", _ActionId1, _ContactId).ToList();
                    item.Technology_of_interest = tech_Interests;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }

        public ContactUs DeleteContactUs(int id)
        {
            ContactUs model = new ContactUs();
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

                model = _dbContext.ExecuteStoredProcedure<ContactUs>("EXEC ContactUs_SP @actionId, @id", _ActionId, _Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;
        }
    }
}
