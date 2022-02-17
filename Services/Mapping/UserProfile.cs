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
                .ForMember(d => d.Bookings, s => s.MapFrom(x => x.Bookings));
           
       }

    }
}