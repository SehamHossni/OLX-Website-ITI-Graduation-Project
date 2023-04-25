using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;


using Talabat.BLL.Interfaces;
using Talabat.DAL.Entities.Identity;
using Talabat.DTO;
using Talabat.Errors;
using Talabat.Extensions;

namespace Talabat.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, 
            ITokenService tokenService, 
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if(user == null) return Unauthorized(new ApiResponse(401));
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if(!result.Succeeded) return Unauthorized(new ApiResponse(401));
            var userDto = new UserDto()
            {
                Email = loginDto.Email,
                DisplayName = $"{user.DisplayName}",
                Token = await _tokenService.CreateToken(user, _userManager)
            };
            return Ok(userDto);
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if(CheckEmailExistsAsync(registerDto.Email).Result.Value)
                return new BadRequestObjectResult(new ApiValidationErrorResponse() { Errors = new[] { "Email Address already is in Use !!" } });
            var user = new AppUser()
            {
                Email = registerDto.Email,
                UserName = registerDto.Email.Split("@")[0],
                DisplayName = registerDto.DisplayName,
                PhoneNumber = registerDto.PhoneNumber,
                Address = new Address()
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    City = registerDto.City,
                    Country = registerDto.Country,
                    Street = registerDto.Street,
                    ZipCode = registerDto.ZipCode
                }
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));
            var userDto = new UserDto()
            {
                Email = registerDto.Email,
                DisplayName = $"{user.DisplayName}",
                Token = await _tokenService.CreateToken(user, _userManager)
            };
            return Ok(userDto);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            return Ok(new UserDto()
            {
                Email = user.Email,
                DisplayName = $"{user.DisplayName}",
                Token = await _tokenService.CreateToken(user, _userManager)
            });
        }


        [HttpGet("userinfo")]
        public async Task<ActionResult<UserDto>> getanyuserinfo([FromQuery] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) {
            return BadRequest(new ApiResponse(400, "Vendor is not found"));
            }
            return Ok(new UserProfileDTO()
            {
                email = user.Email,
                ShownName = $"{user.DisplayName}",
                phone = user.PhoneNumber,


            });
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
            var user = await _userManager.FindByEmailWithAddressAsync(User);
            return Ok(_mapper.Map<Address, AddressDto>(user.Address));
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto address)
        {
            var user = await _userManager.FindByEmailWithAddressAsync(User);
            user.Address =  _mapper.Map<AddressDto, Address>(address);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) return Ok(_mapper.Map<Address, AddressDto>(user.Address));
            return BadRequest(new ApiResponse(400, "A Problem occured With Updating User Address"));
        }
    }
}
