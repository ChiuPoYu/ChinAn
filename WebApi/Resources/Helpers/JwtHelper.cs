using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Resources.Helpers
{
    public class JwtHelper
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _secretKey;

        public JwtHelper(IConfiguration configuration)
        {
            _issuer = configuration.GetValue<string>(AppSettingsKey.JwtIssuer) 
                      ?? throw new ArgumentNullException(nameof(AppSettingsKey.JwtIssuer), "Issuer cannot be null");
            _audience = configuration.GetValue<string>(AppSettingsKey.JwtAudience) 
                        ?? throw new ArgumentNullException(nameof(AppSettingsKey.JwtAudience), "Audience cannot be null");
            _secretKey = configuration.GetValue<string>(AppSettingsKey.JwtSecretKey) 
                         ?? throw new ArgumentNullException(nameof(AppSettingsKey.JwtSecretKey), "SecretKey cannot be null");
        }

        /// <summary>
        /// 生成 JWT Token。
        /// </summary>
        /// <param name="claims">使用者的 Claims。</param>
        /// <param name="expires">Token 的過期時間。</param>
        /// <returns>JWT Token 字串。</returns>
        public string GenerateToken(IEnumerable<Claim> claims, DateTime expires)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expires,
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }

        /// <summary>
        /// 驗證 JWT Token。
        /// </summary>
        /// <param name="token">JWT Token 字串。</param>
        /// <returns>驗證結果，若成功則回傳 ClaimsPrincipal，否則回傳 null。</returns>
        public ClaimsPrincipal? ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _issuer,
                ValidAudience = _audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey))
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}
