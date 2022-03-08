using HotelFinderBusiness.Abstract;
using HotelFinderEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinderWebAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService hotelServise;
        public HotelsController(IHotelService _hotelServise)
        {
            hotelServise = _hotelServise;
        }
        [HttpGet]
        public IActionResult GetAllHotel()
        {
            var hotels = hotelServise.GetAllHotel();
            return Ok(hotels);
        }
        [HttpGet("{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotel = hotelServise.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult CreateHotel(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                var createhotel = hotelServise.CreateHotel(hotel);
                return Ok();
            }
            return BadRequest(ModelState);//400 +error mesajı
        }
        [HttpPut]
        public IActionResult UpdateHotel(Hotel hotel)
        {
            if (hotelServise.GetHotelById(hotel.Id) != null)
            {
                hotelServise.UpdateHotel(hotel);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (hotelServise.GetHotelById(id)!=null)
            {
                hotelServise.DeleteHotel(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
