using IS_Projekt.Server.Entities;
using System.Text.Json.Serialization;

namespace IS_Projekt.Core
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public AuthenticationResponse(User user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Token = token;
        }
        [JsonConstructor]
        public AuthenticationResponse(int id, string username, string token)
        {
            Id = id;
            Username = username;
            Token = token;
        }
    }
}
