using System.ComponentModel.DataAnnotations;

namespace IS_Projekt.Core
{
    public class AuthenticationRequest
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}