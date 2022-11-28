using LiveEvents.Models;
using LiveEvents.Services;
using Microsoft.AspNetCore.Mvc;

namespace LiveEventsAdminApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantController : ControllerBase
    {
        readonly ILiveEventParticipantService liveEventParticipantService;

        public ParticipantController(ILiveEventParticipantService liveEventParticipantService)
        {
            this.liveEventParticipantService = liveEventParticipantService;
        }

        [HttpPut, Route("upsert")]
        public async Task UpsertLiveEventParticipant(UpsertParticipantRequest request)
        {
            var userId = 16; // Get from HttpContext.User
            await liveEventParticipantService.UpsertLiveEventParticipant(request, userId);
        }
    }
}