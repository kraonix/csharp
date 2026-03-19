using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Services
{
    public class JwtService
    {
        private readonly string _key;

        public JwtService(IConfiguration config)
        {
            // 🔥 Get key from appsettings or fallback
            _key = config["Jwt:Key"] ?? "THIS_IS_A_SUPER_SECRET_KEY_123456789";
        }

        public string GenerateToken(ApplicationUser user, IList<string> roles)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var claims = new List<Claim>
            {
                // 🔥 IMPORTANT CLAIMS
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? "")
            };

            // 🔥 ADD ROLES
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_key));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "UniversityApp",
                audience: "UniversityApp",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}