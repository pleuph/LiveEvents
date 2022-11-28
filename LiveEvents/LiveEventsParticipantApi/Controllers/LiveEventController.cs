using LiveEvents.Models;
using LiveEvents.Services;
using Microsoft.AspNetCore.Mvc;

namespace LiveEventsAdminApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiveEventController : ControllerBase
    {
        readonly ILiveEventParticipantService liveEventParticipantService;

        public LiveEventController(ILiveEventParticipantService liveEventParticipantService)
        {
            this.liveEventParticipantService = liveEventParticipantService;
        }

        [HttpGet, Route("summaries")]
        public async Task<IEnumerable<ParticipantLiveEventSummaryResponse>> GetFutureLiveEventSummaries()
        {
            var userId = 16; // Get from HttpContext.User
            return await liveEventParticipantService.GetFutureLiveEventParticipantSummaries(userId);
        }
    }
}