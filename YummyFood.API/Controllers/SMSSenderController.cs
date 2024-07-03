using Messager.EskizUz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace YummyFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSSenderController : ControllerBase
    {
        private readonly MessagerAgent _agent;

        public SMSSenderController(MessagerAgent agent)
        {
            _agent = agent;
        }

        [HttpPost]
        public async Task<IActionResult> SendOTP(string phoneNumber)
        {
            var result = await _agent.SendOtpAsync(phoneNumber);

            if (result.Success)
            {
                return Ok(result.Code);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> SendSMS(string phoneNumber, string body)
        {
            var result = await _agent.SendSMSAsync(phoneNumber, body);

            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
