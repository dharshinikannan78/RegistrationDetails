using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegDetails.Data;
using RegDetails.Model;
using System;
using System.Linq;

namespace RegDetails.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RegDetail : ControllerBase
    {
        public readonly UserDbContext dataModel;
        public RegDetail(UserDbContext userData)
        {
            dataModel = userData;

        }

        [HttpPost]
        public IActionResult RegistrationCandidateForm([FromBody] RegistrationModel obj)
        {


            dataModel.registerData.Add(obj);
            dataModel.SaveChanges();
            return Ok(obj);
        }

        [HttpPut]
        public IActionResult updateStatus([FromBody] RegistrationModel obj)
        {
           if(obj == null)
            {
                return BadRequest();
            }
           var status = dataModel.registerData.AsNoTracking().FirstOrDefault(x=>x.CandidateId == obj.CandidateId);
            if(status == null)
            {
                return BadRequest();
            }
            else
            {
                dataModel.Entry(obj).State = EntityState.Modified;
                dataModel.SaveChanges();
                return Ok(obj);
            }
           
        }



        [HttpGet("GetAllEmp")]
        public IActionResult GetCandidateDetails()
        {
            var user = dataModel.registerData.AsQueryable();
            return Ok(user);
        }

       [HttpGet("Emila")]
        public IActionResult getEmail(string obj)
        {
            var CandidateEmail = dataModel.registerData.Where(a => a.EmailId == obj).FirstOrDefault();

            if (CandidateEmail == null)
            {
                return Ok(new
                {
                    message = "You Can Enter"
                }); ;
            }
            else
            {
                return Ok(new
                {
                    message = "already Exist"
                });
            }
        }

        [HttpGet("applicant")]
        public IActionResult applicantStatus(int obj)
        {
            var appl = dataModel.registerData.Where(a => a.CandidateId == obj).FirstOrDefault();
            if (appl == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(appl);
            }
        }

        [HttpDelete("delete")]
        public IActionResult deleteCandidate(int id)
        {
            var deleteCandidateDetails = dataModel.registerData.Find(id);
            if(deleteCandidateDetails == null)
            {
                return NotFound();
            }
            else
            {
                dataModel.registerData.Remove(deleteCandidateDetails);
                dataModel.SaveChanges();
                return Ok();
            }

        }

    }

     
}
