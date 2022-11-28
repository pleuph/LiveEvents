using AutoMapper;
using LiveEvents.Data.Models;
using LiveEvents.Data.Repositories;
using LiveEvents.Models;

namespace LiveEvents.Services
{
    public class LiveEventParticipantService : ILiveEventParticipantService
    {
        readonly ILiveEventParticipantRepository liveEventParticipantRepository;
        readonly IMapper mapper;

        public LiveEventParticipantService(ILiveEventParticipantRepository liveEventParticipantRepository, IMapper mapper)
        {
            this.liveEventParticipantRepository = liveEventParticipantRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ParticipantLiveEventSummaryResponse>> GetFutureLiveEventParticipantSummaries(int userId)
        {
            var liveEventParticipantSummaries = await liveEventParticipantRepository.GetFutureLiveEventParticipantSummaries(userId);
            return mapper.Map<IEnumerable<ParticipantLiveEventSummaryResponse>>(liveEventParticipantSummaries);
        }

        public async Task UpsertLiveEventParticipant(UpsertParticipantRequest request, int userId)
        {
            var liveEventParticipant = mapper.Map<LiveEventParticipant>(request);
            liveEventParticipant.UserId = userId;
            await liveEventParticipantRepository.UpsertLiveEventParticipant(liveEventParticipant);
        }
    }
}
