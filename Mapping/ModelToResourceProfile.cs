using AutoMapper;
using EquixAPI.Entities;
using EquixAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquixAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Phrase, InPhraseDTO>();
            CreateMap<Author, InAuthorDTO>();
            CreateMap<Category, InCategoryDTO>();

            CreateMap<Phrase, OutPhraseDTO>();
            CreateMap<Author, OutAuthorDTO>();
            CreateMap<Category, OutCategoryDTO>();
        }
    }
}
