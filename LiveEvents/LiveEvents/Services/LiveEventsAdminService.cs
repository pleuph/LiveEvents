using AutoMapper;
using LiveEvents.Data.Repositories;
using LiveEvents.Models;

namespace LiveEvents.Services
{
    public class LiveEventsAdminService : ILiveEventsAdminService
    {
        readonly ILiveEventsAdminRepository liveEventAdminRepository;
        readonly IMapper mapper;

        public LiveEventsAdminService(ILiveEventsAdminRepository liveEventAdminRepository, IMapper mapper)
        {
            this.liveEventAdminRepository = liveEventAdminRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<LiveEventSummaryDto>> GetLiveEventSummaries(bool onlyFutureEvents)
        {
            var result = await liveEventAdminRepository.GetLiveEventSummaries(onlyFutureEvents);

            return mapper.Map<IEnumerable<LiveEventSummaryDto>>(result);
        }
    }
}
