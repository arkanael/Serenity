using Microsoft.AspNetCore.Mvc;
using Serenity.CrossCutting.Contracts.Security;
using Serenity.Infra.Data.Contacts.Repositories;
using Serenity.Infra.Data.Entities;
using Serenity.Services.Models.Usuarios;
using Serenity.Services.Validations;
using System;

namespace Serenity.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult POST([FromBody] CadastroUsuarioViewModel model, 
            [FromServices] IUsuarioRepository usuarioRepository,
            [FromServices] ICriptografia criptografia)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (usuarioRepository.Get(model.Login) == null)
                    {
                        var usuario = new Usuario
                        {
                            Nome = model.Nome,
                            Login = model.Login,
                            DataCriacao = DateTime.Now,
                            Senha = criptografia.GETMD5(model.Senha)
                        };

                        usuarioRepository.Create(usuario);

                        return StatusCode(200, "Usuário cadastrado com sucesso");
                    }

                    return StatusCode(400, "O login informado já encontra-se cadastrado.");

                }
                catch (Exception erro)
                {
                    return StatusCode(500, erro.Message);
                }
            }
            else
            {
                return StatusCode(400, ModelStateValidation.GetErrors(ModelState));
            }
        }
    }
}