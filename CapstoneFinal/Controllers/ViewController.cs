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
using CapstoneFinal.Models;

namespace CapstoneFinal.Controllers
{
    [RoutePrefix("api/cars")]   
    public class ViewController : ApiController
    {
        private CarContext db = new CarContext();

        // GET: api/View
        [Route("")]
        public IQueryable<Car> GetCars()
        {
            return db.Cars;
        }

        [Route("")]
        public List<Car> GetCars(string Make, string Model, int Year, string Color)
        {
            var query = db.Cars.Where(c => c.Make.Contains(Make) && c.Model.Contains(Model) && c.Year == Year && c.Color.Contains(Color));
            List<Car> search = query.ToList<Car>();
            return search;
        }

        [Route("Make={Make}")]
        [HttpGet]
        public List<Car> GetMakeCars(string Make)
        {
            var Makes = db.Cars.Where(c => c.Make.Contains(Make)).ToList();
            return Makes;
        }

        [Route("Model={Model}")]
        [HttpGet]
        public List<Car> GetModelCars(string Model)
        {
            var Models = db.Cars.Where(c => c.Make.Contains(Model)).ToList();
            return Models;
        }

        [Route("Year={Year}")]
        [HttpGet]
        public List<Car> GetYearCars(int Year)
        {
            var Years = db.Cars.Where(c => c.Year == Year).ToList();
            return Years;
        }

        [Route("Color={Color}")]
        [HttpGet]
        public List<Car> GetColorCars(string Color)
        {
            var Colors = db.Cars.Where(c => c.Color.Contains(Color)).ToList();
            return Colors;
        }


        // GET: api/View/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult GetCar(int id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/View/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCar(int id, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.ID)
            {
                return BadRequest();
            }

            db.Entry(car).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/View
        [ResponseType(typeof(Car))]
        public IHttpActionResult PostCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cars.Add(car);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = car.ID }, car);
        }

        // DELETE: api/View/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult DeleteCar(int id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            db.Cars.Remove(car);
            db.SaveChanges();

            return Ok(car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarExists(int id)
        {
            return db.Cars.Count(e => e.ID == id) > 0;
        }
    }
}