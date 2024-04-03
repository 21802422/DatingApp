using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;
using Microsoft.Data.SqlClient;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
       public AutoMapperProfiles()
       {
          CreateMap<AppUser, MemberDto>()
              .ForMember(dest => dest.PhotoUrl, 
              opt => opt.MapFrom(Src => Src.Photos.FirstOrDefault(x =>x.IsMain).Url))
              .ForMember(dest => dest.Age, opt =>opt.MapFrom(src => src.DateofBirth.CalcuCalcuateAge()));
          CreateMap<Photo, PhotoDto>(); 
       }
    }
}