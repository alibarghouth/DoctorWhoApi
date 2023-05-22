using DoctorWho.Web.DTOs.DoctorsDTOs;
using DoctorWho.Web.Services.DoctorService;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("doctors/all")]
        public async Task<ActionResult> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllDoctors();
            return Ok(doctors);
        }

        [HttpPut("update_doctor/{doctorId:int}")]
        public async Task<IActionResult> UpdateDoctorAsync(DoctorRequest doctorDtOs, int doctorId)
        {
            var doctor = await _doctorService.UpdateDoctor(doctorDtOs, doctorId);
            return Ok(doctor);
        }

        [HttpPost("add_doctor")]
        public async Task<IActionResult> AddDoctorAsync(DoctorRequest doctorDtOs)
        {
            return Ok(await _doctorService.AddDoctor(doctorDtOs));
        }
    }
}