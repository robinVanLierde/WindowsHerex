using RestServiceAugustus.DbContext;
using RestServiceAugustus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RestServiceAugustus.Controllers
{
    public class NewsfeedsController : ApiController
    {
        private RestServiceDbContext db = new RestServiceDbContext();
        // GET: api/Newsfeeds
        public IQueryable<Newsfeed> GetNewsfeeds()
        {


            return db.Newsfeed;
        }

        // GET: api/Newsfeeds/5
        [ResponseType(typeof(Newsfeed))]
        public IHttpActionResult GetNewsfeed(int id)
        {
            Newsfeed newsfeed = db.Newsfeed.Find(id);
            if (newsfeed == null)
            {
                return NotFound();
            }
            return Ok(newsfeed);
        }

        // POST: api/Newsfeeds
        [ResponseType(typeof(Newsfeed))]
        public IHttpActionResult PostNewsfeed(Newsfeed newsfeed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Newsfeed.Add(newsfeed);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = newsfeed.NewsfeedId }, newsfeed);

        }

        // PUT: api/Newsfeeds/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Newsfeeds/5
        [ResponseType(typeof(Newsfeed))]
        public IHttpActionResult DeleteLeerling(int id)
        {
            Newsfeed newsfeed = db.Newsfeed.Find(id);
            if (newsfeed == null)
            {
                return NotFound();
            }
            db.Newsfeed.Remove(newsfeed);
            db.SaveChanges();

            return Ok(newsfeed);
        }
    }
}
