using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Auth.API.Models;

namespace Auth.API.Controllers
{
    [Authorize]
    public class LinguagensController : ApiController
    {
        private AuthenticationContext db = new AuthenticationContext();

        // GET: api/Linguagens
        public IQueryable<Linguagem> GetLinguagens()
        {
            return db.Linguagens;
        }

        // GET: api/Linguagens/5
        [ResponseType(typeof(Linguagem))]
        public IHttpActionResult GetLinguagem(int id)
        {
            Linguagem linguagem = db.Linguagens.Find(id);
            if (linguagem == null)
            {
                return NotFound();
            }

            return Ok(linguagem);
        }

        // PUT: api/Linguagens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLinguagem(int id, Linguagem linguagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != linguagem.Id)
            {
                return BadRequest();
            }

            db.Entry(linguagem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinguagemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Linguagens
        [ResponseType(typeof(Linguagem))]
        public IHttpActionResult PostLinguagem(Linguagem linguagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Linguagens.Add(linguagem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = linguagem.Id }, linguagem);
        }

        // DELETE: api/Linguagens/5
        [ResponseType(typeof(Linguagem))]
        public IHttpActionResult DeleteLinguagem(int id)
        {
            Linguagem linguagem = db.Linguagens.Find(id);
            if (linguagem == null)
            {
                return NotFound();
            }

            db.Linguagens.Remove(linguagem);
            db.SaveChanges();

            return Ok(linguagem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LinguagemExists(int id)
        {
            return db.Linguagens.Count(e => e.Id == id) > 0;
        }
    }
}