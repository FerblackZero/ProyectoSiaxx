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
    public class AlumnosController : ApiController
    {
        private System_UPBCEntities db = new System_UPBCEntities();

        // GET: api/Alumnos
        public IQueryable<Alumnos> GetAlumnos()
        {
            return db.Alumnos;
        }

        // GET: api/Alumnos/5
        [ResponseType(typeof(Alumnos))]
        public async Task<IHttpActionResult> GetAlumnos(int id)
        {
            Alumnos alumnos = await db.Alumnos.FindAsync(id);
            if (alumnos == null)
            {
                return NotFound();
            }

            return Ok(alumnos);
        }

        // PUT: api/Alumnos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlumnos(int id, Alumnos alumnos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alumnos.Id_Alumno)
            {
                return BadRequest();
            }

            db.Entry(alumnos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnosExists(id))
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

        // POST: api/Alumnos
        [ResponseType(typeof(Alumnos))]
        public async Task<IHttpActionResult> PostAlumnos(Alumnos alumnos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Alumnos.Add(alumnos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = alumnos.Id_Alumno }, alumnos);
        }

        // DELETE: api/Alumnos/5
        [ResponseType(typeof(Alumnos))]
        public async Task<IHttpActionResult> DeleteAlumnos(int id)
        {
            Alumnos alumnos = await db.Alumnos.FindAsync(id);
            if (alumnos == null)
            {
                return NotFound();
            }

            db.Alumnos.Remove(alumnos);
            await db.SaveChangesAsync();

            return Ok(alumnos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlumnosExists(int id)
        {
            return db.Alumnos.Count(e => e.Id_Alumno == id) > 0;
        }
    }
}