using HotelFinderDataAccess.Abstract;
using HotelFinderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinderDataAccess.Concreate
{
    public class HotelRepository : IHotelRepository
    {
        public Hotel CreateHotel(Hotel hotel)
        {
            using (var db = new HotelDbContext())
            {
                db.MyProperty.Add(hotel);
                db.SaveChanges();
                return hotel;
            }
        }

        public void DeleteHotel(int id)
        {
            using (var db = new HotelDbContext())
            {
                var deleted = GetHotelById(id);
                db.MyProperty.Remove(deleted);
                db.SaveChanges();
            }
        }

        public List<Hotel> GetAllHotel()
        {
            using (var db = new HotelDbContext())
            {
                return db.MyProperty.ToList();
            }
        }

        public Hotel GetHotelById(int id)
        {
            using (var db = new HotelDbContext())
            {
                return db.MyProperty.FirstOrDefault(x => x.Id == id);
            }
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            using (var db = new HotelDbContext())
            {
                db.MyProperty.Update(hotel);
                db.SaveChanges();
                return hotel;
            }
        }
    }
}
