using Microsoft.EntityFrameworkCore;
using Registration.Context;
using Registration.Context.Repository;
using Registration.Model.Hotels;

namespace Registration.Context.Repository.BookedRepository
{
    public class BookedService
    {
        private readonly IRepository<Booked> repository;
        public BookedService(IRepository<Booked> repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Booked> List()
        {
            return repository.List();
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
