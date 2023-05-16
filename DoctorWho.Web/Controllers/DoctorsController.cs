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

        [HttpGet("get_all_doctors")]
        public async Task<ActionResult> GetAllDoctorAsync()
        {
            var doctors = await _doctorService.GetAllDoctorAsync();
            return Ok(new { doctor = doctors });
        }

        [HttpPut("update_doctor/{doctorId:int}")]
        public async Task<IActionResult> UpdateDoctorAsync(DoctorDTOs doctorDtOs, int doctorId)
        {
            var doctor = await _doctorService.UpdateDoctorAsync(doctorDtOs, doctorId);
            return Ok(doctor);
        }

        [HttpPost("add_doctor")]
        public async Task<IActionResult> AddDoctorAsync(DoctorDTOs doctorDtOs)
        {
            return Ok(await _doctorService.AddDoctorAsync(doctorDtOs));
        }
    }
}