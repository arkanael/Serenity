using System;

namespace Serenity.Infra.Data.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
