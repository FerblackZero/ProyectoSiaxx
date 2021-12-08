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
    public class TutorsController : ApiController
    {
        private System_UPBCEntities db = new System_UPBCEntities();

        // GET: api/Tutors
        public IQueryable<Tutor> GetTutor()
        {
            return db.Tutor;
        }

        // GET: api/Tutors/5
        [ResponseType(typeof(Tutor))]
        public async Task<IHttpActionResult> GetTutor(int id)
        {
            Tutor tutor = await db.Tutor.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }

            return Ok(tutor);
        }

        // PUT: api/Tutors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTutor(int id, Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tutor.Id_Tutor)
            {
                return BadRequest();
            }

            db.Entry(tutor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(id))
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

        // POST: api/Tutors
        [ResponseType(typeof(Tutor))]
        public async Task<IHttpActionResult> PostTutor(Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tutor.Add(tutor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tutor.Id_Tutor }, tutor);
        }

        // DELETE: api/Tutors/5
        [ResponseType(typeof(Tutor))]
        public async Task<IHttpActionResult> DeleteTutor(int id)
        {
            Tutor tutor = await db.Tutor.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }

            db.Tutor.Remove(tutor);
            await db.SaveChangesAsync();

            return Ok(tutor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TutorExists(int id)
        {
            return db.Tutor.Count(e => e.Id_Tutor == id) > 0;
        }
    }
}