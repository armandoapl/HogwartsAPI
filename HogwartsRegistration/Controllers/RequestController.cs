using HogwartsRegistration.Entities;
using HogwartsRegistration.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HogwartsRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestRepository _requestRepo;
        public RequestController(IRequestRepository requestRepo)
        {
            _requestRepo = requestRepo;
        }

        [HttpPost]
        public async Task<ActionResult> Sendrequest([FromBody] InscriptionRequest request)
        {
            await _requestRepo.InsertAsync(request);
            return Ok("Your inscription request has been sent successfully.");
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InscriptionRequest>>> GetInscriptions()
        {
            return Ok(await _requestRepo.GetInscriptionsAsync());
        }


        [HttpPut]
        public async Task<ActionResult> Update([FromBody] InscriptionRequest request)
        {
            await _requestRepo.UpdateAsync(request);

            return Ok("Your inscription request has been updated successfully.");
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery]int hogwartsId)
        {
            await _requestRepo.DeleteAsync(hogwartsId);
            return Ok("The inscription request has been deleted successfully.");
        }

    }
}
