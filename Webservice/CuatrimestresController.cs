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
    public class CuatrimestresController : ApiController
    {
        private System_UPBCEntities db = new System_UPBCEntities();

        // GET: api/Cuatrimestres
        public IQueryable<Cuatrimestres> GetCuatrimestres()
        {
            return db.Cuatrimestres;
        }

        // GET: api/Cuatrimestres/5
        [ResponseType(typeof(Cuatrimestres))]
        public async Task<IHttpActionResult> GetCuatrimestres(int id)
        {
            Cuatrimestres cuatrimestres = await db.Cuatrimestres.FindAsync(id);
            if (cuatrimestres == null)
            {
                return NotFound();
            }

            return Ok(cuatrimestres);
        }

        // PUT: api/Cuatrimestres/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCuatrimestres(int id, Cuatrimestres cuatrimestres)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuatrimestres.Id_Cuatrimestre)
            {
                return BadRequest();
            }

            db.Entry(cuatrimestres).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuatrimestresExists(id))
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

        // POST: api/Cuatrimestres
        [ResponseType(typeof(Cuatrimestres))]
        public async Task<IHttpActionResult> PostCuatrimestres(Cuatrimestres cuatrimestres)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cuatrimestres.Add(cuatrimestres);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cuatrimestres.Id_Cuatrimestre }, cuatrimestres);
        }

        // DELETE: api/Cuatrimestres/5
        [ResponseType(typeof(Cuatrimestres))]
        public async Task<IHttpActionResult> DeleteCuatrimestres(int id)
        {
            Cuatrimestres cuatrimestres = await db.Cuatrimestres.FindAsync(id);
            if (cuatrimestres == null)
            {
                return NotFound();
            }

            db.Cuatrimestres.Remove(cuatrimestres);
            await db.SaveChangesAsync();

            return Ok(cuatrimestres);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CuatrimestresExists(int id)
        {
            return db.Cuatrimestres.Count(e => e.Id_Cuatrimestre == id) > 0;
        }
    }
}