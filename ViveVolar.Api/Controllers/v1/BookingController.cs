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
    public class BookingController : BaseController
    {
        public BookingController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
         //Get
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lstBookings = await _unitOfWork.Bookings.GetAll();
            return Ok(lstBookings);
        }
        
        //Get
        [HttpGet]
        [Route ("GetBookingsByCustomer", Name= "GetBookingsByCustomer")]
        public async Task<IActionResult> GetBookingsByCustomer(int id)
        {
            var lstBookings = await _unitOfWork.Bookings.GetBookingsByCustomer(id);
            return Ok(lstBookings);
        }

        //GetById
        [HttpGet]
        [Route ("GetBookingById", Name= "GetBookingById")]
        public async Task<IActionResult> GetById(int id)
        {
            var Booking = await _unitOfWork.Bookings.GetById(id);
            return Ok(Booking);
        }
        //Post
        [HttpPost]
        public async Task<IActionResult> Add(BookingInput Booking)
        {
            //var Bookingmapped = _mapper.Map<BookingInput>(Booking);
            await _unitOfWork.Bookings.AddBooking(Booking);
            await _unitOfWork.CompleteAsync();
            return  Ok("Agregado!"); //Return 201
        }
        
    }
}