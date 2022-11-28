using LiveEvents.Models;
using LiveEvents.Services;
using Microsoft.AspNetCore.Mvc;

namespace LiveEventsAdminApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiveEventParticipantController : ControllerBase
    {
        readonly ILiveEventParticipantService liveEventParticipantService;

        public LiveEventParticipantController(ILiveEventParticipantService liveEventParticipantService)
        {
            this.liveEventParticipantService = liveEventParticipantService;
        }

        [HttpPut, Route("upsert")]
        public async Task UpsertLiveEventParticipant(UpsertLiveEventParticipantRequest request)
        {
            var userId = 16; // Get from HttpContext.User
            await liveEventParticipantService.UpsertLiveEventParticipant(request, userId);
        }
    }
}