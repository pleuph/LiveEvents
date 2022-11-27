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

        [HttpGet(Name = "GetLiveEventSummaries")]
        public async Task<IEnumerable<LiveEventSummaryDto>> GetLiveEventSummaries(bool onlyFutureEvents)
        {
            return await liveEventAdminService.GetLiveEventSummaries(onlyFutureEvents);
        }
    }
}