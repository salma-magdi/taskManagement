using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using taskManagementDomain;
using TaskManagmentApplication.DTO.request;
using TaskManagmentApplication.helper;
using TaslManagementinfrastructure;

namespace TaskManagmentApplication.service
{
    public class authService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public authService(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<Auth> Register(RegisterDTO registeredModel)
        {
            // check email
            var emailUser = await userManager.FindByEmailAsync(registeredModel.Email);

            if (emailUser != null)
            {
                return new Auth
                {
                    message = "Email is already registered"
                };
            }

            // check username
            var nameUser = await userManager.FindByNameAsync(registeredModel.UserName);

            if (nameUser != null)
            {
                return new Auth
                {
                    message = "Username is already registered"
                };
            }

            // create user
            var user = new ApplicationUser
            {
                Email = registeredModel.Email,
                UserName = registeredModel.UserName
            };

            // save user
            var result = await userManager.CreateAsync(user, registeredModel.Password);

            if (!result.Succeeded)
            {
                string errors = string.Empty;

                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description}, ";
                }

                return new Auth
                {
                    message = errors
                };
            }

            // add role
            await userManager.AddToRoleAsync(user, "User");

            // create token
            var jwtSecurityToken = await CreateJwtToken(user);

            return new Auth
            {
                email = user.Email,
               Username = user.UserName,
                IsAuthenticated = true,
               token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
               expireOn = jwtSecurityToken.ValidTo,
               Roles= new List<string> { "User" },
                message = "Registered Successfully"
            };
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["JWT:Key"])
            );

            var signingCredentials = new SigningCredentials(
                symmetricSecurityKey,
                SecurityAlgorithms.HmacSha256
            );

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signingCredentials
            );

            return jwtSecurityToken;
        }

        public async Task<Auth> Login(LoginDTO user)
        {
            var auth = new Auth();

            // Find user by email
            var User = await userManager.FindByEmailAsync(user.Email);

            if (User == null)
            {
                return new Auth
                {
                    IsAuthenticated = false,
                    message = "Invalid email or password"
                };
            }

            //  Check password
            var PasswordValid = await userManager.CheckPasswordAsync(User, user.Password);

            if (!PasswordValid)
            {
                return new Auth
                {
                    IsAuthenticated = false,
                    message = "Invalid email or password"
                };
            }

            //  Get roles
            var roles = await userManager.GetRolesAsync(User);

            //  Create JWT
            var jwtToken = await CreateJwtToken(User);

            //  Return response
            auth.IsAuthenticated = true;
            auth.Username = User.UserName;
            auth.email =User.Email;
            auth.Roles = roles.ToList();
            auth.token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            auth.expireOn = jwtToken.ValidTo;
            auth.message = "Login successful";

            return auth;
        }
    }
}