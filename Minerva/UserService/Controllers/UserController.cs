using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Enums;
using SharedLibrary.Helpers;
using SharedLibrary.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.Data;
using UserService.UnitsOfWork.Interfaces;

namespace UserService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUsersUnitOfWork _usersUnitOfWork;
    private readonly IConfiguration _configuration;
    private readonly IMailHelper _mailHelper;
    private readonly DataContext _conext;
    private readonly IFileStorage _fileStorage;

    public UserController(IUsersUnitOfWork usersUnitOfWork, IConfiguration configuration, IMailHelper mailHelper, DataContext Conext, IFileStorage fileStorage)
    {
        _usersUnitOfWork = usersUnitOfWork;
        _configuration = configuration;
        _mailHelper = mailHelper;
        _conext = Conext;
        _fileStorage = fileStorage;
    }

    [HttpPost("RecoverPassword")]
    public async Task<IActionResult> RecoverPasswordAsync([FromBody] EmailDTO model)
    {
        var user = await _usersUnitOfWork.GetUserAsync(model.Email);

        if (user==null)
        {
           
            return Ok(new ActionResponse<User>.ActionResponseBuilder().SetSuccess(false).SetMessage("Usuario no existe").Build());
        }

      
            var response = await SendRecoverEmailAsync(user: user, model.Language);

            if (response.WasSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        
    }

    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordDTO model)
    {
        Guid guid = Guid.Parse(model.UserId!);

        var user =await _usersUnitOfWork.GetUserAsync(guid);

        user = await _usersUnitOfWork.GetUserAsync(user.Email!);
        if (user == null)
        {
            return NotFound();
        }

        var result = await _usersUnitOfWork.ResetPasswordAsync(user, model.Token, model.NewPassword);
        if (result.Succeeded)
        {
            return NoContent();
        }

        return BadRequest(result.Errors.FirstOrDefault()!.Description);
    }

    [HttpGet("ResetPasswordView")]
    public  IActionResult ResetPasswordView([FromQuery] string userid, [FromQuery] string token)
    {
        var baseUrl = _configuration["UrlFrontend"]; // URL base del frontend
        var tokenLink = $"http://{baseUrl}/reset-password?userid={userid}&token={token}";

        return Redirect(tokenLink);
    }


    [HttpPost("changePassword")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> ChangePasswordAsync(ChangePasswordDTO model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _usersUnitOfWork.GetUserAsync(User.Identity!.Name!);
        if (user == null)
        {
            return NotFound();
        }

        var result = await _usersUnitOfWork.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors.FirstOrDefault()!.Description);
        }

        return Ok(result);
    }

    [HttpPost("ResedToken")]
    public async Task<IActionResult> ResedTokenAsync([FromBody] EmailDTO model)
    {
        var user = await _usersUnitOfWork.GetUserAsync(model.Email);
        if (user == null)
        {
            return NotFound();
        }

        var response = await SendConfirmationEmailAsync(user, model.Language);
        if (response.WasSuccess)
        {
            return NoContent();
        }

        return BadRequest(response.Message);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPut]
    public async Task<IActionResult> PutAsync(User user)
    {
        try
        {
            var currentUser = await _usersUnitOfWork.GetUserAsync(User.Identity!.Name!);

            if (currentUser == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(user.Photo))
            {
                var photoUser = Convert.FromBase64String(user.Photo);
                user.Photo = await _fileStorage.SaveFileAsync(photoUser, ".jpg", "users");
            }

            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.PhoneNumber = user.PhoneNumber;
            currentUser.Photo = !string.IsNullOrEmpty(user.Photo) && user.Photo != currentUser.Photo ? user.Photo : currentUser.Photo;

            var result = await _usersUnitOfWork.UpdateUserAsync(currentUser);
            if (result.Succeeded)
            {
                return Ok(result); //BuildToken(currentUser)
            }

            return BadRequest(result.Errors.FirstOrDefault());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _usersUnitOfWork.GetUserAsync(User.Identity!.Name!));
    }


    [HttpGet("User")]
    public async Task<IActionResult> GetUserAsync(string id)
    {
        return Ok(await _usersUnitOfWork.GetUserAsync(new Guid(id)));
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser([FromBody] UserDTO model)
    {
        //TODO: create departament.
        //var departament = await _context.Countries.FindAsync(model.CountryId);
        //if (departament == null)
        //{
        //    return BadRequest("ERR004");
        //}

        User user = model;

        if (!string.IsNullOrEmpty(model.Photo))
        {
            var photoUser = Convert.FromBase64String(model.Photo);
            user.Photo = await _fileStorage.SaveFileAsync(photoUser, ".jpg", "users");
        }

        //user.Country = country;
        user.UserType = UserType.User;
        var result = await _usersUnitOfWork.AddUserAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _usersUnitOfWork.AddUserToRoleAsync(user, UserType.User.ToString());
            var response = await SendConfirmationEmailAsync(user, model.Language);
            if (response.WasSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        return BadRequest(result.Errors.FirstOrDefault());
    }


    [HttpPost("ResendConfirmationEmail")]
    public async Task<IActionResult> ResendConfirmationEmail([FromBody] UserEmailDTO model)
    {

        var user = await _usersUnitOfWork.GetUserAsync(model.Email??"");
        var response = await SendConfirmationEmailAsync(user, model.Language??"");

        if (response.WasSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response.Message);

    }


    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDTO model)
    {
        var result = await _usersUnitOfWork.LoginAsync(model);
        if (result.Succeeded)
        {
            var user = await _usersUnitOfWork.GetUserAsync(model.Email);
            return Ok(BuildToken(user));
        }

        if (result.IsLockedOut)
        {
            return BadRequest("ERR007");
        }

        if (result.IsNotAllowed)
        {
            return BadRequest("ERR008");
        }
        
        return  Ok(result);
    }

    [HttpGet("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmailAsync(string userId, string token)
    {
        token = token.Replace(" ", "+");
        var user = await _usersUnitOfWork.GetUserAsync(new Guid(userId));
        if (user == null)
        {
            return NotFound();
        }

        var result = await _usersUnitOfWork.ConfirmEmailAsync(user, token);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors.FirstOrDefault());
        }


        var baseUrl = _configuration["UrlFrontend"]; // URL base del frontend
        var tokenLink = $"http://{baseUrl}/verified-account?userid={userId}";
        return Redirect(tokenLink);
    }

    private async Task<ActionResponse<string>> SendRecoverEmailAsync(User user, string language)
    {
        var myToken = await _usersUnitOfWork.GeneratePasswordResetTokenAsync(user);

        var tokenLink = Url.Action("ResetPasswordView", "user", new
        {
            userid = user.Id,
            token = myToken
        }, HttpContext.Request.Scheme, _configuration["UrlBackend"]);

        if (language == "es")
        {
            return _mailHelper.SendMail(user.FullName, user.Email!, _configuration["Mail:SubjectRecoveryEs"]!, string.Format(_configuration["Mail:BodyRecoveryEs"]!, tokenLink), language);
        }

        return _mailHelper.SendMail(user.FullName, user.Email!, _configuration["Mail:SubjectRecoveryEn"]!, string.Format(_configuration["Mail:BodyRecoveryEn"]!, tokenLink), language);
    }

    private async Task<ActionResponse<string>> SendConfirmationEmailAsync(User user, string language)
    {
        var myToken = await _usersUnitOfWork.GenerateEmailConfirmationTokenAsync(user);
        var tokenLink = Url.Action("ConfirmEmail", "User", new
        {
            userid = user.Id,
            token = myToken
        }, HttpContext.Request.Scheme, _configuration["UrlBackend"]);

        if (language == "es")
        {
            return _mailHelper.SendMail(user.FullName, user.Email!, _configuration["Mail:SubjectConfirmationEs"]!, string.Format(_configuration["Mail:BodyConfirmationEs"]!, tokenLink), language);
        }
        return _mailHelper.SendMail(user.FullName, user.Email!, _configuration["Mail:SubjectConfirmationEn"]!, string.Format(_configuration["Mail:BodyConfirmationEn"]!, tokenLink), language);
    }

    private TokenDTO BuildToken(User user)
    {
       
        var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Email!),
                new(ClaimTypes.Role, user.UserType.ToString()),
                new("FirstName", user.FirstName),
                new("LastName", user.LastName),
                new("Photo", user.Photo ?? string.Empty),
                new("Id", user.Id ?? string.Empty),
                new("Rol",user.UserType.ToString() )
                //TODO:Departament
                //new("DepartamentId", user.Departament.Id.ToString())
            };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtKey"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddDays(30);
        var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials);

        return new TokenDTO
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }
}