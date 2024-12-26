using MyProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.Interfaces
{
    public interface IShoesService
    {
        List<Shoes> GetAll();

        Shoes Get(int id);

        void Add(Shoes shoes);

        void Delete(int id);

        void Update(Shoes shoes);

        int Count { get; }
    }
}