using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ISecurityHelper
    {
        LoginModel GetUser(UserViewModel user);
        TokenModel Login(UserViewModel user);

    }
}
