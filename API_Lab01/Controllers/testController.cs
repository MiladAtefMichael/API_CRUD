using API_Lab01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Lab01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        testAPIContext db;
        public testController(testAPIContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public ActionResult get()
        {
            return Ok(db.Course.ToList());
        }
        [HttpGet("{id:int}")]
        public ActionResult getById(int id) 
        {
            Course crs=db.Course.Find(id);
            if (crs == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(crs);
            }
        }
        //  [HttpGet("{name:alpha}")]
        [HttpGet("/api/course/{name}")]
        public ActionResult CourseByName(string name)
        {
            Course crs=db.Course.Where(a=>a.CrsName==name).FirstOrDefault();
            if (crs == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(crs);
            }
        }
        [HttpPost]
        public ActionResult post(Course crs)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Course.Add(crs);
                    db.SaveChanges();
                    return Created("courses", crs);
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            else return BadRequest();

        }
        [HttpPut]
        public ActionResult put(Course crs)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(crs).State = EntityState.Modified;
                    db.SaveChanges();
                    return NoContent();

                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {

            }
            return BadRequest();
        }
        [HttpDelete]
        public ActionResult delete(int id)
        {
            Course crs=db.Course.Find(id);
            if (crs == null)
            {
                return NotFound();
            }
            else
            {
                db.Course.Remove(crs);
                db.SaveChanges();
                return Ok(crs);
            }
        }


    }
}
