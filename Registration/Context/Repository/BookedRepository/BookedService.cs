using Microsoft.EntityFrameworkCore;
using Registration.Context;
using Registration.Context.Repository;
using Registration.Model.Hotels;

namespace Registration.Context.Repository.BookedRepository
{
    public class BookedService
    {
        private readonly IBookedRepository<Booked> repository;
        public BookedService(IBookedRepository<Booked> repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Booked> List(int roomid)
        {
            return repository.List(roomid);
        }

        public void Create(Booked booked)
        {
            repository.Create(booked);
        }

        public void Correct(Booked booked)
        {
            repository.Correct(booked);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public Booked Profile(int id)
        {
            return repository.GetById(id);
        }
    }
}
