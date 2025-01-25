using MyProject.Models;
using MyProject.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.Services
{
    public class ShoesService : IShoesService
    {
        List<Shoes> Shoeses { get; }
        int nextId = 5;
        public ShoesService()
        {
            Shoeses = new List<Shoes>
            {
                new Shoes { Id = 1, Name = "Sports", Size = 36, IsSale = true },
                new Shoes { Id = 2, Name = "Heel", Size = 37, IsSale = false },
                new Shoes { Id = 3, Name = "Rubber", Size = 34, IsSale = false },
                new Shoes { Id = 4, Name = "Crocs", Size = 35, IsSale = true }
            };
        }

        public List<Shoes> GetAll() => Shoeses;

        public Shoes Get(int id)
        {
            var shoes = Shoeses.FirstOrDefault(p => p.Id == id);
            if (shoes is null)
            {
                throw new KeyNotFoundException($"Shoe with id {id} not found.");
            }
            return shoes;
        }
        public void Add(Shoes shoes)
        {
            shoes.Id = nextId++;
            Shoeses.Add(shoes);
        }

        public void Delete(int id)
        {
            var shoes = Get(id);
            if (shoes is null)
                return;
            Shoeses.Remove(shoes);
        }

        public void Update(Shoes shoes)
        {
            var index = Shoeses.FindIndex(p => p.Id == shoes.Id);
            if (index == -1)
                return;

            Shoeses[index] = shoes;
        }

        public int Count { get => Shoeses.Count(); }
    }
}