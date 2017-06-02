using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Auth.API.Models
{
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext()
            : base("AuthContext")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Linguagem> Linguagens { get; set; }
    }
}