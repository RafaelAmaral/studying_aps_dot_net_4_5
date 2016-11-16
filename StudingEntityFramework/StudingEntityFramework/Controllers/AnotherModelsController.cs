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
using StudingEntityFramework.Models;

namespace StudingEntityFramework.Controllers
{
    public class AnotherModelsController : ApiController
    {
        private StudingEntityFrameworkContext db = new StudingEntityFrameworkContext();

        // GET: api/AnotherModels
        public IQueryable<AnotherModel> GetAnotherModels()
        {
            return db.AnotherModels;
        }

        // GET: api/AnotherModels/5
        [ResponseType(typeof(AnotherModel))]
        public async Task<IHttpActionResult> GetAnotherModel(int id)
        {
            AnotherModel anotherModel = await db.AnotherModels.FindAsync(id);
            if (anotherModel == null)
            {
                return NotFound();
            }

            return Ok(anotherModel);
        }

        // PUT: api/AnotherModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAnotherModel(int id, AnotherModel anotherModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != anotherModel.Id)
            {
                return BadRequest();
            }

            db.Entry(anotherModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnotherModelExists(id))
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

        // POST: api/AnotherModels
        [ResponseType(typeof(AnotherModel))]
        public async Task<IHttpActionResult> PostAnotherModel(AnotherModel anotherModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AnotherModels.Add(anotherModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = anotherModel.Id }, anotherModel);
        }

        // DELETE: api/AnotherModels/5
        [ResponseType(typeof(AnotherModel))]
        public async Task<IHttpActionResult> DeleteAnotherModel(int id)
        {
            AnotherModel anotherModel = await db.AnotherModels.FindAsync(id);
            if (anotherModel == null)
            {
                return NotFound();
            }

            db.AnotherModels.Remove(anotherModel);
            await db.SaveChangesAsync();

            return Ok(anotherModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnotherModelExists(int id)
        {
            return db.AnotherModels.Count(e => e.Id == id) > 0;
        }
    }
}