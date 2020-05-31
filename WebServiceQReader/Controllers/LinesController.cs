﻿using System;
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
    public class LinesController : ApiController
    {
        private qreaderContext db = new qreaderContext();

        // GET: api/Lines
        public IQueryable<Line> GetLines()
        {
            return db.Lines;
        }

        // GET: api/Lines/5
        [ResponseType(typeof(Line))]
        public async Task<IHttpActionResult> GetLine(int id)
        {
            Line line = await db.Lines.FindAsync(id);
            if (line == null)
            {
                return NotFound();
            }

            return Ok(line);
        }

        // PUT: api/Lines/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLine(int id, Line line)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != line.Id)
            {
                return BadRequest();
            }

            db.Entry(line).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineExists(id))
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

        // POST: api/Lines
        [ResponseType(typeof(Line))]
        public async Task<IHttpActionResult> PostLine(Line line)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lines.Add(line);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LineExists(line.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = line.Id }, line);
        }

        // DELETE: api/Lines/5
        [ResponseType(typeof(Line))]
        public async Task<IHttpActionResult> DeleteLine(int id)
        {
            Line line = await db.Lines.FindAsync(id);
            if (line == null)
            {
                return NotFound();
            }

            db.Lines.Remove(line);
            await db.SaveChangesAsync();

            return Ok(line);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LineExists(int id)
        {
            return db.Lines.Count(e => e.Id == id) > 0;
        }
    }
}