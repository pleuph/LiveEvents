using LiveEvents.Models;
using LiveEvents.Services;
using Microsoft.AspNetCore.Mvc;

namespace LiveEventsAdminApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantController : ControllerBase
    {
        readonly ILiveEventAdminService liveEventAdminService;

        public ParticipantController(ILiveEventAdminService liveEventAdminService)
        {
            this.liveEventAdminService = liveEventAdminService;
        }

        [HttpGet, Route("{liveEventId}")]
        public async Task<IEnumerable<ParticipantSummaryResponse>> GetEventParticipantSummaries(int liveEventId)
        {
            return await liveEventAdminService.GetParticipantSummaries(liveEventId);
        }
    }
}