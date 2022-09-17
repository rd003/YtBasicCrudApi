using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YtBasicCrudApi.Models.Domain;
using YtBasicCrudApi.Models.DTO;

namespace YtBasicCrudApi.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DatabaseContext _ctx;
        public StudentController(DatabaseContext ctx)
        {
            this._ctx = ctx;
        }

        [HttpPost]
        public IActionResult AddUpdate(Student model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Validation failed";
                return Ok(status);
            }
            try
            {
                if (model.Id == 0)
                {
                    _ctx.Student.Add(model);
                }
                else
                {
                    _ctx.Student.Update(model);
                }
                _ctx.SaveChanges();
                status.StatusCode = 1;
                status.Message = "Added/Updated successfully";

            }
            catch(Exception ex)
            {
                status.StatusCode = 0;
                status.Message = "Some error occured in server side";
            }
            return Ok(status);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_ctx.Student.Find(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _ctx.Student.ToList();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var status = new Status();

            var data = _ctx.Student.Find(id);
            if (data == null)
                return NotFound("this record does not exist");
            try
            {
                _ctx.Student.Remove(data);
                _ctx.SaveChanges();
                status.StatusCode = 1;
                status.Message = "Delete successfully";
            }
            catch(Exception ex)
            {
                status.StatusCode = 0;
                status.Message = "Error occured in server side";
            }
            return Ok(status);
        }
    }
}
