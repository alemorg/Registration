using Microsoft.EntityFrameworkCore;
using Registration.Context;

namespace Registration.Model.Hotels.Repository.BookedRepository
{
    public class BookedRepository : IRepository<Booked>
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
            var booked = context.Booked.Find(id);

            if (booked != null)
            {
                context.Remove(booked);
                context.SaveChanges();
            }
        }
        public IEnumerable<Booked> List()
        {
            return context.Booked.ToList();
        }
        public void Correct(Booked booked)
        {
            if (booked != null)
            {
                var bookeddb = context.Booked.Find(booked.Id);
                if (bookeddb != null)
                {
                    bookeddb.dateBooked = booked.dateBooked;
                    bookeddb.GuestFirstName = booked.GuestFirstName;
                    bookeddb.GuestSecondName = booked.GuestSecondName;
                    bookeddb.GuestLastName = booked.GuestLastName;
                    bookeddb.GuestPhone = booked.GuestPhone;
                    bookeddb.NumberGuest = booked.NumberGuest;
                    bookeddb.SpecialRequests = booked.SpecialRequests;

                    context.Booked.Attach(bookeddb);
                    context.SaveChanges();
                }
            }
        }
        public Booked GetById(int id)
        {
            if (id > 0) return context.Booked.Include(x => x.Room).FirstOrDefault(x => x.Id == id);
            else throw new Exception("При поиске бронирования по ID, ID<=0");
        }
    }
}
