using CarrocinhaDoBem.Api.Context;
using CarrocinhaDoBem.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarrocinhaDoBem.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly ApplicationDbContext _context;

    public AuthController(UserManager<User> userManager, ApplicationDbContext context)
    {
        _context = context;
        _userManager = userManager;
    }
    
    [HttpGet]
    public async Task<IActionResult> ObterTodosUsuarios()
    {
        return Ok(_context.Users.ToList());
    }    
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObterUsuarioPorId(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
        if (user == null) return NotFound();
        
        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, UserUpdate newUser)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user == null)
            return NotFound();

        if (!string.IsNullOrEmpty(newUser.Nome))
            user.UserName = newUser.Nome;

        if (!string.IsNullOrEmpty(newUser.Email))
            user.Email = newUser.Email;

        if (!string.IsNullOrEmpty(newUser.Endereco))
            user.Address = newUser.Endereco;

        if (!string.IsNullOrEmpty(newUser.Telefone))
            user.Phone = newUser.Telefone;

        if (newUser.DataNascimento != default)
            user.BirthDate = newUser.DataNascimento;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(user);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user == null)
            return NotFound();

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return NoContent();
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLogin loginRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userManager.FindByEmailAsync(loginRequest.Email);
        if (user == null)
        {
            ModelState.AddModelError("Email", "Usuário não encontrado.");
            return BadRequest(ModelState);
        }

        var result = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
        if (!result)
        {
            ModelState.AddModelError("Password", "Senha incorreta.");
            return BadRequest(ModelState);
        }

        return Ok(new { login = true });
    }
    
    [HttpPost("registrar")]
    public async Task<IActionResult> CadastrarUsuario(UserRequest userRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (userRequest.Password != userRequest.ConfirmPassword)
        {
            ModelState.AddModelError("Confirmar Senha", "A senha e a confirmação de senha não correspondem.");
            return BadRequest(ModelState);
        }

        var user = new User
        {
            UserName = userRequest.UserName,
            Email = userRequest.Email,
            Password = userRequest.Password,
            Address = "",
            Avatar = new byte[1],
            Phone = "",
            UserType = ""
        };

        var result = _userManager.CreateAsync(user, userRequest.Password);
      
        if (!result.Result.Succeeded)
        {
            return BadRequest(result.Result.Errors);
        }

        return CreatedAtAction(nameof(ObterUsuarioPorId), new { id = user.Id }, user);
    }
}