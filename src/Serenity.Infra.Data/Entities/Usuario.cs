using System;

namespace Serenity.Infra.Data.Entities
{
    public class Usuario
    {
        public Usuario(int idUsuario, string nome, string login, string senha, DateTime dataCriacao)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Login = login;
            Senha = senha;
            DataCriacao = dataCriacao;
        }

        public int IdUsuario { get; private set; }
        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataCriacao { get; private set; }
    }
}
