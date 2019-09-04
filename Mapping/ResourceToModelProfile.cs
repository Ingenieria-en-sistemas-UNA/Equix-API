using AutoMapper;
using EquixAPI.Entities;
using EquixAPI.Models;

namespace EquixAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<InPhraseDTO, Phrase>();
            CreateMap<InAuthorDTO, Author>();
            CreateMap<InCategoryDTO, Category>();
            CreateMap<OutPhraseDTO, Phrase>();
            CreateMap<OutAuthorDTO, Author>();
            CreateMap<OutCategoryDTO, Category>();
        }
    }
}
