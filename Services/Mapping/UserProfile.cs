using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Entities;
using Services.Dtos.Outgoing;

namespace Services.Mapping
{
    public class UserProfile : Profile
    {
       public UserProfile()
       {
           /*   CreateMap<User,UserInput>().ReverseMap()
            .ForMember(dest => dest.Date, from => from.MapFrom(x=> DateTime.UtcNow)); 
 */
             CreateMap<UserOutput,User>().ReverseMap()
                .ForMember(d => d.FirstName, s => s.MapFrom(x => x.FirstName))
                .ForMember(d => d.LastName, s => s.MapFrom(x => x.LastName))
                .ForMember(d => d.Country, s => s.MapFrom(x => x.Country))
                .ForMember(d => d.DateOfBirth, s => s.MapFrom(x => x.DateOfBirth))
                .ForMember(d => d.Bookings, s => s.MapFrom(x => x.Bookings))
                ;
           
       }

    }
}