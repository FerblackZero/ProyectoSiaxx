using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Webservice
{
    public class DocentesController : ApiController
    {
        private System_UPBCEntities db = new System_UPBCEntities();

        // GET: api/Docentes
        public IQueryable<Docentes> GetDocentes()
        {
            return db.Docentes;
        }

        // GET: api/Docentes/5
        [ResponseType(typeof(Docentes))]
        public async Task<IHttpActionResult> GetDocentes(int id)
        {
            Docentes docentes = await db.Docentes.FindAsync(id);
            if (docentes == null)
            {
                return NotFound();
            }

            return Ok(docentes);
        }

        // PUT: api/Docentes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDocentes(int id, Docentes docentes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != docentes.Id_Docente)
            {
                return BadRequest();
            }

            db.Entry(docentes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocentesExists(id))
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

        // POST: api/Docentes
        [ResponseType(typeof(Docentes))]
        public async Task<IHttpActionResult> PostDocentes(Docentes docentes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Docentes.Add(docentes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = docentes.Id_Docente }, docentes);
        }

        // DELETE: api/Docentes/5
        [ResponseType(typeof(Docentes))]
        public async Task<IHttpActionResult> DeleteDocentes(int id)
        {
            Docentes docentes = await db.Docentes.FindAsync(id);
            if (docentes == null)
            {
                return NotFound();
            }

            db.Docentes.Remove(docentes);
            await db.SaveChangesAsync();

            return Ok(docentes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocentesExists(int id)
        {
            return db.Docentes.Count(e => e.Id_Docente == id) > 0;
        }
    }
}