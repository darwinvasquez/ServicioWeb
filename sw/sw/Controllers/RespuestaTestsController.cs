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
    public class RespuestaTestsController : ApiController
    {
        private ContextConocimiento db = new ContextConocimiento();

        // GET: api/RespuestaTests
        public IQueryable<RespuestaTest> GetRespuestaTest()
        {
            return db.RespuestaTest;
        }

        // GET: api/RespuestaTests/5
        [ResponseType(typeof(RespuestaTest))]
        public IHttpActionResult GetRespuestaTest(int id)
        {
            RespuestaTest respuestaTest = db.RespuestaTest.Find(id);
            if (respuestaTest == null)
            {
                return NotFound();
            }

            return Ok(respuestaTest);
        }

        // PUT: api/RespuestaTests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRespuestaTest(int id, RespuestaTest respuestaTest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != respuestaTest.RespuestaTestId)
            {
                return BadRequest();
            }

            db.Entry(respuestaTest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RespuestaTestExists(id))
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

        // POST: api/RespuestaTests
        [ResponseType(typeof(RespuestaTest))]
        public IHttpActionResult PostRespuestaTest(RespuestaTest respuestaTest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RespuestaTest.Add(respuestaTest);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = respuestaTest.RespuestaTestId }, respuestaTest);
        }

        // DELETE: api/RespuestaTests/5
        [ResponseType(typeof(RespuestaTest))]
        public IHttpActionResult DeleteRespuestaTest(int id)
        {
            RespuestaTest respuestaTest = db.RespuestaTest.Find(id);
            if (respuestaTest == null)
            {
                return NotFound();
            }

            db.RespuestaTest.Remove(respuestaTest);
            db.SaveChanges();

            return Ok(respuestaTest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RespuestaTestExists(int id)
        {
            return db.RespuestaTest.Count(e => e.RespuestaTestId == id) > 0;
        }
    }
}