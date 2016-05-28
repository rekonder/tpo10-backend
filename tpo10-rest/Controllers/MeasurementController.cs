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
using tpo10_rest.Models;

namespace tpo10_rest.Controllers
{
    public class MeasurementController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Measurement
        public IQueryable<Measurement> GetMeasurements()
        {
            return db.Measurements;
        }

        // GET: api/Measurement/5
        [ResponseType(typeof(Measurement))]
        public async Task<IHttpActionResult> GetMeasurement(Guid id)
        {
            Measurement measurement = await db.Measurements.FindAsync(id);
            if (measurement == null)
            {
                return NotFound();
            }

            return Ok(measurement);
        }

        // PUT: api/Measurement/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMeasurement(Guid id, Measurement measurement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != measurement.Id)
            {
                return BadRequest();
            }

            db.Entry(measurement).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasurementExists(id))
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

        // POST: api/Measurement
        [ResponseType(typeof(Measurement))]
        public async Task<IHttpActionResult> PostMeasurement(Measurement measurement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Measurements.Add(measurement);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = measurement.Id }, measurement);
        }

        // DELETE: api/Measurement/5
        [ResponseType(typeof(Measurement))]
        public async Task<IHttpActionResult> DeleteMeasurement(Guid id)
        {
            Measurement measurement = await db.Measurements.FindAsync(id);
            if (measurement == null)
            {
                return NotFound();
            }

            db.Measurements.Remove(measurement);
            await db.SaveChangesAsync();

            return Ok(measurement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeasurementExists(Guid id)
        {
            return db.Measurements.Count(e => e.Id == id) > 0;
        }
    }
}