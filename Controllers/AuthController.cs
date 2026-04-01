using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestauranteAPI.Data;
using RestauranteAPI.Models;

namespace RestauranteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RestauranteContext _context;
        private readonly IConfiguration _config; //permite leer el appsettings.json.
        public AuthController(RestauranteContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("Registro")]

        public async Task<ActionResult> Registro(RegistroDTO dto)
        {
            var usuarioExistente = await _context.Clientes.AnyAsync(c => c.Correo == dto.Correo);
            if (usuarioExistente) return BadRequest("Este correo ya está en uso.");
            var nuevoCliente = new Clientes
            {
                NombreCliente = dto.NombreCliente,
                ApellidoCliente = dto.ApellidoCliente,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                Contraseña = BCrypt.Net.BCrypt.HashPassword(dto.Contraseña) //Contraseña encriptada
            };

            _context.Clientes.Add(nuevoCliente);
            await _context.SaveChangesAsync();
            return Ok("Usuario registrado exitosamente!");
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDTO dto)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Correo == dto.Correo);
            
            if(cliente == null || !BCrypt.Net.BCrypt.Verify(dto.Contraseña, cliente.Contraseña))
            {
                return Unauthorized("Credenciales incorrectas");
            }

            var token = GenerarJwtToken(cliente);
            return Ok(new { token = token });
        }

        private string GenerarJwtToken(Clientes cliente)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //Estas líneas funcionan para comparar las credenciales

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, cliente.IdCliente.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, cliente.Correo)
            };

            // C. Armar el Token con fecha de caducidad (ej. dura 2 horas)
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            // D. Escribir el token como una cadena de texto y devolverlo
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
