using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos.Incomming;
using Services.IConfiguration;

namespace ViveVolar.Api.Controllers.v1
{
    public class FlightController : BaseController
    {
        public FlightController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

         //Get
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lstFlights = await _unitOfWork.Flights.GetAll();
            return Ok(lstFlights);
        }
        //GetById
        [HttpGet]
        [Route ("GetFlightById", Name= "GetFlightById")]
        public async Task<IActionResult> GetById(int id)
        {
            var Flight = await _unitOfWork.Flights.GetById(id);
            return Ok(Flight);
        }
        //Post
        [HttpPost]
        public async Task<IActionResult> Add(FlightInput Flight)
        {
            //var Flightmapped = _mapper.Map<FlightInput>(Flight);
            await _unitOfWork.Flights.AddFlight(Flight);
            await _unitOfWork.CompleteAsync();
            return  Ok("Agregado!"); //Return 201
        }
    }
}