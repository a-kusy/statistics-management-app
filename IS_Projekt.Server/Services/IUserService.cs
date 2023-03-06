using IS_Projekt.Core;
using IS_Projekt.Server.Entities;

namespace IS_Projekt.Server.Services
{
    public interface IUserService
    {
        AuthenticationResponse? Authenticate(AuthenticationRequest request);
        IEnumerable<User> GetUsers();
        User? GetByUsername(string username);
        User? GetById(int id);
        int GetUsersNumber();
    }
}
