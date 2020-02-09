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
using wine_API.Models;

namespace wine_API.Controllers
{
    public class winequalityRedController : ApiController
    {
        private wineSetEntities db = new wineSetEntities();

        // GET: api/winequalityRed
        [HttpGet]
        [ResponseType(typeof(winequalityRed))]
        [Route("api/winequalityRed/GetPodaciZaTreniranje")]
        public List<winequalityRed> GetPodaciZaTreniranje()
        {
            return db.asp_Podaci_Za_Treniranje_KNN().ToList();
        }
        //Get; trening podaci
        [HttpGet]
        [ResponseType(typeof(winequalityRed))]
        [Route("api/winequalityRed/GetTreniraniPodaci")]
        public List<winequalityRed> GetTreniraniPodaci()
        {
            return db.asp_Trening_Podaci_Za_KNN().ToList();
        }
        // GET: api/winequalityRed/5
        [ResponseType(typeof(winequalityRed))]
        public IHttpActionResult GetwinequalityRed(int id)
        {
            winequalityRed winequalityRed = db.winequalityRed.Find(id);
            if (winequalityRed == null)
            {
                return NotFound();
            }

            return Ok(winequalityRed);
        }

        // PUT: api/winequalityRed/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutwinequalityRed(int id, winequalityRed winequalityRed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != winequalityRed.ID)
            {
                return BadRequest();
            }

            db.Entry(winequalityRed).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!winequalityRedExists(id))
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

        // POST: api/winequalityRed
        [ResponseType(typeof(winequalityRed))]
        public IHttpActionResult PostwinequalityRed(winequalityRed winequalityRed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.winequalityRed.Add(winequalityRed);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = winequalityRed.ID }, winequalityRed);
        }

        // DELETE: api/winequalityRed/5
        [ResponseType(typeof(winequalityRed))]
        public IHttpActionResult DeletewinequalityRed(int id)
        {
            winequalityRed winequalityRed = db.winequalityRed.Find(id);
            if (winequalityRed == null)
            {
                return NotFound();
            }

            db.winequalityRed.Remove(winequalityRed);
            db.SaveChanges();

            return Ok(winequalityRed);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool winequalityRedExists(int id)
        {
            return db.winequalityRed.Count(e => e.ID == id) > 0;
        }
    }
}