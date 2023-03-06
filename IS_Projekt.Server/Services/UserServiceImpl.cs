using IS_Projekt.Core;
using IS_Projekt.Server.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IS_Projekt.Server.Services
{
    public class UserServiceImpl : IUserService
    {
        private static readonly List<User> users = new()
        {
            new User(id: 1, username: "Andrzej", password: "Andrzej", roles: new List<Role>
            {
                new Role("admin"),
                new Role("user")
            }),
            new User(id: 2, username: "Ania", password: "Andrzej", new List<Role>
            {
                new Role("user")
            })
        };

        private readonly IConfiguration configuration;

        public UserServiceImpl(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public AuthenticationResponse? Authenticate(AuthenticationRequest request)
        {
            if (request.Username is null)
                return null;

            var user = GetByUsername(request.Username);
            if (user == null || user.Password != request.Password)
            {
                return null;
            }
            string token = GenerateJwtToken(user);
            return new AuthenticationResponse(user, token);
        }

        public User? GetById(int id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        public User? GetByUsername(string username)
        {
            return users.FirstOrDefault(x => x.Username == username);
        }

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public int GetUsersNumber()
        {
            return users.Count;
        }

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:key"]);
            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString())
            };
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);


        }
    }
}
