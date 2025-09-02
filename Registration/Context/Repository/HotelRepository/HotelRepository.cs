
using Microsoft.EntityFrameworkCore;
using Registration.Context;
using Registration.Context.Repository;
using Registration.Model.Hotels;

namespace Registration.Context.Repository.HotelRepository
{
    public class HotelRepository : IRepository<Hotel>
    {
        private readonly AppDbContext context;
        public HotelRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Create(Hotel hotel)
        {
            context.Add(hotel);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var hotel = context.Hotels.Find(id);
            
            if (hotel != null)
            {
                context.Remove(hotel);
                context.SaveChanges();
            }
        }

        public IEnumerable<Hotel> List()
        {
            return context.Hotels.ToList();
        }

        public void Correct(Hotel hotel)
        {
            if (hotel != null)
            {
                context.Hotels.Attach(hotel);
                context.Entry(hotel).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Hotel GetById(int id)
        {
            if (id > 0) return context.Hotels.Find(id);
            else throw new Exception("При поиске отеля по ID, ID<=0");
        }
    }
}
