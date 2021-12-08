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
    public class MateriasController : ApiController
    {
        private System_UPBCEntities db = new System_UPBCEntities();

        // GET: api/Materias
        public IQueryable<Materias> GetMaterias()
        {
            return db.Materias;
        }

        // GET: api/Materias/5
        [ResponseType(typeof(Materias))]
        public async Task<IHttpActionResult> GetMaterias(int id)
        {
            Materias materias = await db.Materias.FindAsync(id);
            if (materias == null)
            {
                return NotFound();
            }

            return Ok(materias);
        }

        // PUT: api/Materias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMaterias(int id, Materias materias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materias.Id_Materias)
            {
                return BadRequest();
            }

            db.Entry(materias).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriasExists(id))
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

        // POST: api/Materias
        [ResponseType(typeof(Materias))]
        public async Task<IHttpActionResult> PostMaterias(Materias materias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Materias.Add(materias);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = materias.Id_Materias }, materias);
        }

        // DELETE: api/Materias/5
        [ResponseType(typeof(Materias))]
        public async Task<IHttpActionResult> DeleteMaterias(int id)
        {
            Materias materias = await db.Materias.FindAsync(id);
            if (materias == null)
            {
                return NotFound();
            }

            db.Materias.Remove(materias);
            await db.SaveChangesAsync();

            return Ok(materias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MateriasExists(int id)
        {
            return db.Materias.Count(e => e.Id_Materias == id) > 0;
        }
    }
}