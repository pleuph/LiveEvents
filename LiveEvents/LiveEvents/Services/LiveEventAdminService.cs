using AutoMapper;
using LiveEvents.Data.Models;
using LiveEvents.Data.Repositories;
using LiveEvents.Models;

namespace LiveEvents.Services
{
    public class LiveEventAdminService : ILiveEventAdminService
    {
        readonly ILiveEventAdminRepository liveEventAdminRepository;
        readonly IMapper mapper;

        public LiveEventAdminService(ILiveEventAdminRepository liveEventAdminRepository, IMapper mapper)
        {
            this.liveEventAdminRepository = liveEventAdminRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<LiveEventSummaryResponse>> GetLiveEventSummaries(bool onlyFutureEvents)
        {
            var result = await liveEventAdminRepository.GetLiveEventSummaries(onlyFutureEvents);

            return mapper.Map<IEnumerable<LiveEventSummaryResponse>>(result);
        }

        public async Task<int> AddLiveEvent(AddLiveEventRequest request, int userId)
        {
            var liveEvent = mapper.Map<LiveEvent>(request);
            liveEvent.CreatedByUserId = userId;
            return await liveEventAdminRepository.AddLiveEvent(liveEvent);
        }
    }
}
