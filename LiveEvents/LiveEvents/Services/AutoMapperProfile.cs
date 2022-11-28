using AutoMapper;
using LiveEvents.Data.Models;
using LiveEvents.Models;

namespace LiveEvents.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<LiveEventSummary, LiveEventSummaryResponse>();

            CreateMap<AddLiveEventRequest, LiveEvent>();

            CreateMap<ParticipantLiveEventSummary, ParticipantLiveEventSummaryResponse>();

            CreateMap<UpsertParticipantRequest, LiveEventParticipant>();

            CreateMap<ParticipantSummary, ParticipantSummaryResponse>();
        }
    }
}
