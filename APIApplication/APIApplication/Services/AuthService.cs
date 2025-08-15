using APIApplication.Data;
using APIApplication.Entities;
using APIApplication.Models.Request;
using APIApplication.Models.Respone;
using APIApplication.Services.Interfaces;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace APIApplication.Services
{
    public class AuthService(NoteDbContext context, IConfiguration configuration) : IAuthService
    {
    
        public async Task<User?> RegiserAsync(LoginRequest request)
        {
            if (await context.User.AnyAsync(u => u.Username == request.Username))
            {
                return null;
            }

            var user = new User();
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password);

            user.Username = request.Username;
            user.PasswordHash = hashedPassword;
            user.Role = "User";//request.Role;

            context.User.Add(user);

            await context.SaveChangesAsync();

            return user;
        }

        public async Task<TokenRespone?> LoginAsync(LoginRequest request)
        {
            var user = await context.User.FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user is null)
            {
                return null;
            }

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password)
                == PasswordVerificationResult.Failed)
            {
                return null;
            }
            return await CreateTokenResponse(user);
        }

        private string GenerateRefeshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }

        private async Task<String> GenerateAndSaveRefreshTokenAsync(User user)
        {
            var refreshToken = GenerateRefeshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await context.SaveChangesAsync();

            return refreshToken;

        }

        private string CreateToken(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                claims: claims,
                signingCredentials: creds,
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                expires: DateTime.UtcNow.AddDays(1)
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public async Task<TokenRespone?> RefreshTokensAsync(RefreshTokenRespone requestDto)
        {
            var user = await ValidateRefreshTokenAsync(requestDto.UserId, requestDto.RefreshToken);
            if(user is null)
                return null;

            return await CreateTokenResponse(user);
        }

        private async Task<User?> ValidateRefreshTokenAsync(Guid userId, string refreshToken)
        {
            var user = await context.User.FindAsync(userId);
            if (user is null || user.RefreshToken != refreshToken
                || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {

                return null;
            }
            return user;
        }

        private async Task<TokenRespone> CreateTokenResponse(User? user)
        {
            return new TokenRespone
            {
                AccessToken = CreateToken(user),
                RefreshToken = await GenerateAndSaveRefreshTokenAsync(user),
                UserRespone = new UserRespone
                {
                    Username = user.Username,
                    Id = user.Id,
                    Role = user.Role
                }
            };
        }

        public async Task<User?> getUserAsync()
        {
            var user = await context.User.FirstOrDefaultAsync(u => u.Username == "sokna");

            if (user is null)
            {
                return null;
            }

            return user;

        }
    }


}
