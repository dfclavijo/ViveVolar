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
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight,FlightInput>().ReverseMap()
            .ForMember(dest => dest.DepartureStation, from => from.MapFrom(x=> $"{x.DepartureStation}"))
            .ForMember(dest => dest.ArrivalStation, from => from.MapFrom(x=> $"{x.ArrivalStation}"))
            .ForMember(dest => dest.DepartureDate, from => from.MapFrom(x=> $"{x.DepartureDate}"))
            .ForMember(dest => dest.Price, from => from.MapFrom(x=> $"{x.Price}"));

            CreateMap<FlightOutput,Flight >().ReverseMap();
            
        }
        
    }
}