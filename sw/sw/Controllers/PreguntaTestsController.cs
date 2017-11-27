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
using sw.Models;

namespace sw.Controllers
{
    public class PreguntaTestsController : ApiController
    {
        private ContextConocimiento db = new ContextConocimiento();

        // GET: api/PreguntaTests
        public IQueryable<PreguntaTest> GetPreguntaTest()
        {
            return db.PreguntaTest;
        }

        // GET: api/PreguntaTests/5
        [ResponseType(typeof(PreguntaTest))]
        public IHttpActionResult GetPreguntaTest(int id)
        {
            PreguntaTest preguntaTest = db.PreguntaTest.Find(id);
            if (preguntaTest == null)
            {
                return NotFound();
            }

            return Ok(preguntaTest);
        }

        // PUT: api/PreguntaTests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPreguntaTest(int id, PreguntaTest preguntaTest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preguntaTest.PreguntaTestId)
            {
                return BadRequest();
            }

            db.Entry(preguntaTest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntaTestExists(id))
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

        // POST: api/PreguntaTests
        [ResponseType(typeof(PreguntaTest))]
        public IHttpActionResult PostPreguntaTest(PreguntaTest preguntaTest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PreguntaTest.Add(preguntaTest);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = preguntaTest.PreguntaTestId }, preguntaTest);
        }

        // DELETE: api/PreguntaTests/5
        [ResponseType(typeof(PreguntaTest))]
        public IHttpActionResult DeletePreguntaTest(int id)
        {
            PreguntaTest preguntaTest = db.PreguntaTest.Find(id);
            if (preguntaTest == null)
            {
                return NotFound();
            }

            db.PreguntaTest.Remove(preguntaTest);
            db.SaveChanges();

            return Ok(preguntaTest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PreguntaTestExists(int id)
        {
            return db.PreguntaTest.Count(e => e.PreguntaTestId == id) > 0;
        }
    }
}