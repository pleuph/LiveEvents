using LiveEvents.Models;
using LiveEvents.Services;
using Microsoft.AspNetCore.Mvc;

namespace LiveEventsAdminApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiveEventController : ControllerBase
    {
        readonly ILiveEventsAdminService liveEventAdminService;

        public LiveEventController(ILiveEventsAdminService liveEventAdminService)
        {
            this.liveEventAdminService = liveEventAdminService;
        }

        [HttpGet, Route("summaries/{onlyFutureEvents}")]
        public async Task<IEnumerable<LiveEventSummaryResponse>> GetLiveEventSummaries(bool onlyFutureEvents)
        {
            return await liveEventAdminService.GetLiveEventSummaries(onlyFutureEvents);
        }

        [HttpPut, Route("")]
        public async Task<int> AddLiveEvent(AddLiveEventRequest addLiveEventRequest)
        {
            var userId = 12; // Get from HttpContext.User
            return await liveEventAdminService.AddLiveEvent(addLiveEventRequest, userId);
        }
    }
}