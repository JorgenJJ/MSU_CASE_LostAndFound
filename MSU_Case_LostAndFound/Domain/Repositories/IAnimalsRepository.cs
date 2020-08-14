using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IAnimalsRepository
    {
        // Query methods.
        IEnumerable<Animals> GetAll();
        IEnumerable<Animals> GetLike(string partialName);
        Animals GetById(int id);

        // Modification methods.
        Animals Insert(Animals item);
        bool Update(Animals item);
        bool Delete(int id);
    }
}
