using Microsoft.EntityFrameworkCore;
using Registration.Context;
using Registration.Context.Repository;
using Registration.Model.Hotels;

namespace Registration.Context.Repository.BookedRepository
{
    public class BookedRepository : IBookedRepository<Booked>
    {
        private readonly AppDbContext context;
        public BookedRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Create(Booked booked)
        {
            context.Add(booked);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var booked = context.Bookeds.Find(id);

            if (booked != null)
            {
                context.Remove(booked);
                context.SaveChanges();
            }
        }
        public IEnumerable<Booked> List(int roomId)
        {
            var Booked = context.Bookeds.ToList();
            var result = new List<Booked>();
            if (Booked != null) 
            {
                foreach (var booked in Booked)
                {
                    if (booked.Roomid == roomId)
                        result.Add(booked);
                }
            }
            return result;
        }
        public void Correct(Booked booked)
        {
            if (booked != null)
            {
                var bookeddb = context.Bookeds.Find(booked.Id);
                if (bookeddb != null)
                {
                    bookeddb.dateStartBooked = booked.dateStartBooked;
                    bookeddb.dateEndBooked = booked.dateEndBooked;
                    bookeddb.GuestFirstName = booked.GuestFirstName;
                    bookeddb.GuestSecondName = booked.GuestSecondName;
                    bookeddb.GuestLastName = booked.GuestLastName;
                    bookeddb.GuestPhone = booked.GuestPhone;
                    bookeddb.NumberGuest = booked.NumberGuest;
                    bookeddb.SpecialRequests = booked.SpecialRequests;

                    context.Bookeds.Attach(bookeddb);
                    context.SaveChanges();
                }
            }
        }
        public Booked GetById(int id)
        {
            if (id > 0) return context.Bookeds.Include(x => x.Room).FirstOrDefault(x => x.Id == id);
            else throw new Exception("При поиске бронирования по ID, ID<=0");
        }
    }
}
