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
using CrickWorldBackend.Models;

namespace CrickWorldBackend.Controllers
{
    public class TeamDetailsController : ApiController
    {
        private CrickWorldTeamContext db = new CrickWorldTeamContext();

        // GET: api/TeamDetails
        public IQueryable<TeamDetails> GetTeamDetails()
        {
            return db.TeamDetails;
        }

        // GET: api/TeamDetails/5
        [ResponseType(typeof(TeamDetails))]
        public IHttpActionResult GetTeamDetails(int id)
        {
            TeamDetails teamDetails = db.TeamDetails.Find(id);
            if (teamDetails == null)
            {
                return NotFound();
            }

            return Ok(teamDetails);
        }

        // PUT: api/TeamDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeamDetails(int id, TeamDetails teamDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teamDetails.Id)
            {
                return BadRequest();
            }

            db.Entry(teamDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamDetailsExists(id))
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

        // POST: api/TeamDetails
        [ResponseType(typeof(TeamDetails))]
        public IHttpActionResult PostTeamDetails(TeamDetails teamDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TeamDetails.Add(teamDetails);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teamDetails.Id }, teamDetails);
        }

        // DELETE: api/TeamDetails/5
        [ResponseType(typeof(TeamDetails))]
        public IHttpActionResult DeleteTeamDetails(int id)
        {
            TeamDetails teamDetails = db.TeamDetails.Find(id);
            if (teamDetails == null)
            {
                return NotFound();
            }

            db.TeamDetails.Remove(teamDetails);
            db.SaveChanges();

            return Ok(teamDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeamDetailsExists(int id)
        {
            return db.TeamDetails.Count(e => e.Id == id) > 0;
        }
    }
}