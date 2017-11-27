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
    public class CategoriaTestsController : ApiController
    {
        private ContextConocimiento db = new ContextConocimiento();

        // GET: api/CategoriaTests
        public IQueryable<CategoriaTest> GetCategoriaTest()
        {
            return db.CategoriaTest;
        }

        // GET: api/CategoriaTests/5
        [ResponseType(typeof(CategoriaTest))]
        public IHttpActionResult GetCategoriaTest(int id)
        {
            CategoriaTest categoriaTest = db.CategoriaTest.Find(id);
            if (categoriaTest == null)
            {
                return NotFound();
            }

            return Ok(categoriaTest);
        }

        // PUT: api/CategoriaTests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoriaTest(int id, CategoriaTest categoriaTest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoriaTest.CategoriaTestId)
            {
                return BadRequest();
            }

            db.Entry(categoriaTest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaTestExists(id))
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

        // POST: api/CategoriaTests
        [ResponseType(typeof(CategoriaTest))]
        public IHttpActionResult PostCategoriaTest(CategoriaTest categoriaTest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CategoriaTest.Add(categoriaTest);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoriaTest.CategoriaTestId }, categoriaTest);
        }

        // DELETE: api/CategoriaTests/5
        [ResponseType(typeof(CategoriaTest))]
        public IHttpActionResult DeleteCategoriaTest(int id)
        {
            CategoriaTest categoriaTest = db.CategoriaTest.Find(id);
            if (categoriaTest == null)
            {
                return NotFound();
            }

            db.CategoriaTest.Remove(categoriaTest);
            db.SaveChanges();

            return Ok(categoriaTest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriaTestExists(int id)
        {
            return db.CategoriaTest.Count(e => e.CategoriaTestId == id) > 0;
        }
    }
}