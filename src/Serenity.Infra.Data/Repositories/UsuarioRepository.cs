using Dapper;
using Microsoft.Extensions.Configuration;
using Serenity.Infra.Data.Contacts.Repositories;
using Serenity.Infra.Data.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Serenity.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //private IConfiguration configuration;

        //private readonly string ConnectionString;

        //public UsuarioRepository(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //    ConnectionString = "SerenityDB";
        //}

        private readonly SqlConnection sqlConnection;

        public UsuarioRepository(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }
        
        public void Create(Usuario usuario)
        {
            var query = "Insert into Usuario(Nome, Login, Senha, DataCriacao) values(@Nome, @Login, @Senha, getdate())";
            sqlConnection.Execute(query, usuario);
        }

        public void Update(Usuario usuario)
        {
            var query = "Update Usuario set = Nome = @Nome, Login = @Login, Senha = @Senha where IdUsuario = @IdUsuario";
            sqlConnection.Execute(query, usuario);
        }

        public void Remove(int key)
        {
            var query = "Delete from Usuario where IdUsuario = @IdUsuario";
            sqlConnection.Execute(query, new { IdUsuario = key });
        }

        public List<Usuario> GetAll()
        {
            var query = "Select * from Usuario";
            return sqlConnection.Query<Usuario>(query).ToList();
        }

        public Usuario Get(int key)
        {
            var query = "Select * from Usuario where IdUsuario = @IdUsuario";
            return sqlConnection.QuerySingleOrDefault<Usuario>(query, new { IdUsuario = key });
        }

        public Usuario Get(string login)
        {
            var query = "Select * from Usuario where Login = @Login";
            return sqlConnection.QuerySingleOrDefault<Usuario>(query, new { login });
        }

        public Usuario Get(string login, string senha)
        {
            var query = "Select * from Usuario where Login = @Login and senha = @Senha";
            return sqlConnection.QuerySingleOrDefault<Usuario>(query, new { login, senha });
        }

        public void Dispose()
        {
            sqlConnection.Dispose();
        }
    }
}