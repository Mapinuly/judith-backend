using GoGIS_Model.ViewModel;
using System.Collections.Generic;

namespace GoGIS_Services.AuthService
{
    public interface IAuthService
    {
        UserDetails Login(string userEmail, string password);
        UserDetails Signup(string userName, string userEmail, string password);
        List<UserDetails> AllUserDetails();
        UserDetails GetUserById(int id);
        UserDetails UpdateUserDetails(UserDetails user);
        UserDetails DeleteUserDetails(int id);
        UserDetails CheckEmailExists(string userEmail);
    }
}
