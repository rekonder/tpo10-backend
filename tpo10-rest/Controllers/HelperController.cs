using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using tpo10_rest.Models;

namespace tpo10_rest.Controllers
{
    [RoutePrefix("api/Helper")]
    public class HelperController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET api/Helper/Post
        [HttpGet]
        [Route("Post")]
        public IHttpActionResult GetPosts()
        {
            var posts = db.Posts.ToList();
            return Ok(posts);
        }

        // GET api/Helper/HealthCareProvider
        [HttpGet]
        [Route("HealthCareProvider")]
        public IHttpActionResult GetHealthCareProviders()
        {
            List<HelperHealthCareProvider> seznam = new List<HelperHealthCareProvider>();
            foreach (var line in db.HealthCareProviders)
            {
                HelperHealthCareProvider health = new HelperHealthCareProvider {
                    Key = line.Key,
                    Name = line.Name
                };
                seznam.Add(health);
               
            }

            return Ok(seznam);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
