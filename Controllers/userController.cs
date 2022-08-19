using salvage_portal.Data;
using salvage_portal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace salvage_portal.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class userController : Controller
    {
        private readonly SalvagePortalDbContext dbContext;

        public userController(SalvagePortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("get-users")]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await dbContext.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetBidders(GetBidders role)
        {
            var users = dbContext.Users.ToListAsync();
            var bidder = new List<Object>();
            foreach (var user in await users)
            {
                if (user.role == role.role)
                {
                    bidder.Add(user);
                }
            }
            return Ok(bidder);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest userLogin)
        {
            var user = await dbContext.Users.SingleOrDefaultAsync(a => a.email.Equals(userLogin.email));

            if (user != null)
            {
                if (Util.Hashing.ComparePassword(userLogin.password, user.password))
                {
                    var userToken = user.Id.ToString();
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(DotNetEnv.Env.GetString("JwtSecret")));
                    var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokenOptions = new JwtSecurityToken(
                        issuer: "Salvage Portal",
                        audience: userToken,
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddHours(2),
                        signingCredentials: signingCredentials
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                    return Ok(new { user, tokenString });
                }
                else
                {

                    return BadRequest("Password does not match " + userLogin.email);
                }
            }

            return BadRequest("No user found with " + userLogin.email);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBidder(CreateBidder createBidder)
        {

            var exitingEmail = await dbContext.Users.SingleOrDefaultAsync(a => a.email == createBidder.email);

            if (exitingEmail == null)
            {
                var bidder = new User()
                {
                    Id = Guid.NewGuid(),
                    firstName = createBidder.firstName,
                    lastName = createBidder.lastName,
                    email = createBidder.email,
                    password = createBidder.password,
                    role = createBidder.role,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };

                bidder.password = Util.Hashing.HashPassword(bidder.password);



                await dbContext.Users.AddAsync(bidder);
                await dbContext.SaveChangesAsync();

                return Ok(bidder);
            }

            return BadRequest("Email already registered with another user.");

        }
    }
}