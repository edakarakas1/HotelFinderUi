using HotelFinderBusiness.Abstract;
using HotelFinderDataAccess.Abstract;
using HotelFinderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinderBusiness.Concrete
{
    public class HotelManeger : IHotelService
    {
        private IHotelRepository rep;
        public HotelManeger(IHotelRepository _rep)
        {
            rep = _rep;
        }
        public Hotel CreateHotel(Hotel hotel)
        {
            return rep.CreateHotel(hotel);
        }

        public void DeleteHotel(int id)
        {
            rep.DeleteHotel(id);
        }

        public List<Hotel> GetAllHotel()
        {
            return rep.GetAllHotel();
        }

        public Hotel GetHotelById(int id)
        {
            if (id>0)
            {
             return   rep.GetHotelById(id);
            }
            throw new Exception("Id 1'den küçük olamaz");
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            return rep.UpdateHotel(hotel);
        }
    }
}
