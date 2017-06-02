namespace Auth.API.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Auth.API.Models.AuthenticationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Auth.API.Models.AuthenticationContext context)
        {
            context.Usuarios.AddOrUpdate(x => x.Id,
                 new Usuario() { Login = "Administrador", Senha = "123456" }
                );

            context.Linguagens.AddOrUpdate(x => x.Id,
                new Linguagem() { Nome = "C" },
                new Linguagem() { Nome = "C++" },
                new Linguagem() { Nome = "C#" },
                new Linguagem() { Nome = "Java" },
                new Linguagem() { Nome = "PHP" },
                new Linguagem() { Nome = "Delphi" },
                new Linguagem() { Nome = "Pascal" }
                );
        }
    }
}
