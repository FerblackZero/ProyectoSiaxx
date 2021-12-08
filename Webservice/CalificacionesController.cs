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
    public class CalificacionesController : ApiController
    {
        private System_UPBCEntities db = new System_UPBCEntities();

        // GET: api/Calificaciones
        public IQueryable<Calificaciones> GetCalificaciones()
        {
            return db.Calificaciones;
        }

        // GET: api/Calificaciones/5
        [ResponseType(typeof(Calificaciones))]
        public async Task<IHttpActionResult> GetCalificaciones(int id)
        {
            Calificaciones calificaciones = await db.Calificaciones.FindAsync(id);
            if (calificaciones == null)
            {
                return NotFound();
            }

            return Ok(calificaciones);
        }

        // PUT: api/Calificaciones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCalificaciones(int id, Calificaciones calificaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calificaciones.Id_Calificaciones)
            {
                return BadRequest();
            }

            db.Entry(calificaciones).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacionesExists(id))
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

        // POST: api/Calificaciones
        [ResponseType(typeof(Calificaciones))]
        public async Task<IHttpActionResult> PostCalificaciones(Calificaciones calificaciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Calificaciones.Add(calificaciones);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = calificaciones.Id_Calificaciones }, calificaciones);
        }

        // DELETE: api/Calificaciones/5
        [ResponseType(typeof(Calificaciones))]
        public async Task<IHttpActionResult> DeleteCalificaciones(int id)
        {
            Calificaciones calificaciones = await db.Calificaciones.FindAsync(id);
            if (calificaciones == null)
            {
                return NotFound();
            }

            db.Calificaciones.Remove(calificaciones);
            await db.SaveChangesAsync();

            return Ok(calificaciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CalificacionesExists(int id)
        {
            return db.Calificaciones.Count(e => e.Id_Calificaciones == id) > 0;
        }
    }
}