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
using WebServiceQReader.Models;

namespace WebServiceQReader.Controllers
{
    public class CheckpointsController : ApiController
    {
        private qreaderContext db = new qreaderContext();

        // GET: api/Checkpoints
        public IQueryable<Checkpoint> GetCheckpoints()
        {
            return db.Checkpoints;
        }

        // GET: api/Checkpoints/5
        [ResponseType(typeof(Checkpoint))]
        public async Task<IHttpActionResult> GetCheckpoint(int id)
        {
            Checkpoint checkpoint = await db.Checkpoints.FindAsync(id);
            if (checkpoint == null)
            {
                return NotFound();
            }

            return Ok(checkpoint);
        }

        // PUT: api/Checkpoints/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCheckpoint(int id, Checkpoint checkpoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != checkpoint.Id)
            {
                return BadRequest();
            }

            db.Entry(checkpoint).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckpointExists(id))
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

        // POST: api/Checkpoints
        [ResponseType(typeof(Checkpoint))]
        public async Task<IHttpActionResult> PostCheckpoint(Checkpoint checkpoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Checkpoints.Add(checkpoint);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CheckpointExists(checkpoint.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = checkpoint.Id }, checkpoint);
        }

        // DELETE: api/Checkpoints/5
        [ResponseType(typeof(Checkpoint))]
        public async Task<IHttpActionResult> DeleteCheckpoint(int id)
        {
            Checkpoint checkpoint = await db.Checkpoints.FindAsync(id);
            if (checkpoint == null)
            {
                return NotFound();
            }

            db.Checkpoints.Remove(checkpoint);
            await db.SaveChangesAsync();

            return Ok(checkpoint);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CheckpointExists(int id)
        {
            return db.Checkpoints.Count(e => e.Id == id) > 0;
        }
    }
}