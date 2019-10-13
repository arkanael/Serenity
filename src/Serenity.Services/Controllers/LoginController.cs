using Microsoft.AspNetCore.Mvc;
using Serenity.CrossCutting.Contracts.Security;
using Serenity.Infra.Data.Contacts.Repositories;
using Serenity.Services.Models.Logins;
using Serenity.Services.Validations;
using System;

namespace Serenity.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult POST([FromBody] LoginUsuarioViewModel model, [FromServices] IUsuarioRepository usuarioRepository, [FromServices] ICriptografia criptografia)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = usuarioRepository.Get(model.Login, criptografia.GETMD5(model.Senha));

                    if (usuario != null)
                    {
                        //TODO
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(400, "Acesso negado. O Login ou Senha incorreto");
                    }
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