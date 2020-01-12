using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Users.Service.DTOs
{
    public class Token
    {
        public string AccessToken { get; private set; }
        public int ExpiresIn { get; private set; }

        private Token()
        {

        }
        public static Token CreateToken(string username, Audience audience)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64)
            };
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audience.Secret));

            var jwt = new JwtSecurityToken(
                issuer: audience.Iss,
                audience: audience.Aud,
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(40)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new Token()
            {
                AccessToken = encodedJwt,
                ExpiresIn = (int)TimeSpan.FromMinutes(40).TotalSeconds

            };
        }

    }
}
