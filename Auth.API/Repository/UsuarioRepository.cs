using Auth.API.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Auth.API.Repository
{
    public class UsuarioRepository : IDisposable
    {
            private AuthenticationContext _ctx;

            public UsuarioRepository()
            {
                _ctx = new AuthenticationContext();
            }

            public Usuario FindUser(string login, string senha)
            {
                Usuario user = this._ctx.Usuarios
                    .FirstOrDefault(x => x.Login == login && x.Senha == senha);

                return user;
            }

            public void Dispose()
            {
                _ctx.Dispose();
            }
        
    }
}