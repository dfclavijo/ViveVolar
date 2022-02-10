using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Entities;
using Services.Dtos.Incomming;
using Services.Dtos.Outgoing;

namespace Services.Mapping
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
             CreateMap<Booking,BookingInput>().ReverseMap()
            .ForMember(dest => dest.Date, from => from.MapFrom(x=> DateTime.UtcNow)); 

             CreateMap<BookingOutput,Booking >().ReverseMap()
                .ForMember(d => d.UserName, s => s.MapFrom(x => x.UserNavigation.FirstName))
                .ForMember(d => d.LastName, s => s.MapFrom(x => x.UserNavigation.LastName))
                .ForMember(d => d.DepartureDate, s => s.MapFrom(x => x.FlightNavigation.DepartureStation))
                .ForMember(d => d.ArrivalStation, s => s.MapFrom(x => x.FlightNavigation.ArrivalStation))
                .ForMember(d => d.DepartureDate, s => s.MapFrom(x => x.FlightNavigation.DepartureDate));
           
           
        }
    }
}