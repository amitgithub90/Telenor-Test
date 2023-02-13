using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    
    public class AppointmentController : Controller
    {
        

        IAppointmentRepository appointmentRepository;
        public AppointmentController(IAppointmentRepository _appointmentRepository)
        {
            appointmentRepository = _appointmentRepository;
        }

        List<Appointment> _Appointment = new List<Appointment>();
        
        [HttpGet]
        [Route("/api/GetAppointments")]
        public async Task<IActionResult> GetAppointments()
        {
            try
            {
                var appointments = await appointmentRepository.GetAppointments();
                if (appointments == null)
                {
                    return NotFound();
                }

                return Ok(appointments);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }



        [HttpGet]
        [Route("/api/GetAppointment")]
        public async Task<IActionResult> GetAppointment(int appId)
        {
            if (appId == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await appointmentRepository.GetAppointment(appId);

                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/api/CreateAppointment")]
        public async Task<IActionResult> CreateAppointment([FromBody] Appointment model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var appoinmentId = await appointmentRepository.AddAppointment(model);
                    if (appoinmentId > 0)
                    {
                        return Ok(appoinmentId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }
        [HttpDelete]
        [Route("/api/RemoveAppointment")]
        public async Task<IActionResult> RemoveAppointment( int appId)
        {
            int result = 0;

            if (appId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await appointmentRepository.DeleteAppointment(appId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok("Deleted"+ appId);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("/api/UpdateAppointment")]
        public async Task<IActionResult> UpdateAppointment([FromBody] Appointment model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await appointmentRepository.UpdateAppointment(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("/api/UploadAppointments")]
        public async Task<JsonResult> UploadAppointments(List<Appointment> model)
        {


            _Appointment = await appointmentRepository.UploadAppointments(model);
             return Json(_Appointment);
                    
           
        }
    }
}
