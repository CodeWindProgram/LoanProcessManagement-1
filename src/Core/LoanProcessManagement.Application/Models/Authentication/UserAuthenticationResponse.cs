using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Models.Authentication

{
    public class UserAuthenticationResponse
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Id { get; set; }
        public string Lg_id { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }
    }
}
