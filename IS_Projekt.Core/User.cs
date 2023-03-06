using System.Text.Json.Serialization;

namespace IS_Projekt.Server.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public List<Role> Roles { get; set; }

        public User(int id, string username, string password, List<Role> roles)
        {
            Id = id;
            Username = username;
            Password = password;
            Roles = roles;
        }
    }
}
