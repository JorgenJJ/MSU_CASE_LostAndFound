using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repositories
{
    class MemoryAnimal
    {
        public class MemoryAnimalRepository : IAnimalsRepository
        {
            // Dummy (hard-coded) list of product suggestions to start with.
            private static IList<Animals> items = new List<Animals> {
            new Animals { Id=1, Name="Buddy", Lost=DateTime.Today },
            new Animals { Id=2, Name="Heinz", Lost=DateTime.Today },
            new Animals { Id=3, Name="Tomato",      Lost=DateTime.Today },
            new Animals { Id=4, Name="Alex",       Lost=DateTime.Today },
            new Animals { Id=5, Name="Sugar",            Lost=DateTime.Today },
            new Animals { Id=6, Name="Erik van Appeldoorn", Lost=DateTime.Today },
            new Animals { Id=7, Name="Leo",    Lost=DateTime.Today },
            new Animals { Id=8, Name="Alexis",     Lost=DateTime.Today },
        };

            private static int nextId = 9;

            #region Query repository methods

            // Get all items.
            public IEnumerable<Animals> GetAll()
            {
                return items;
            }

            // Get items that contain specified text in the Name.
            public IEnumerable<Animals> GetLike(string partialName)
            {
                var matches = from i in items
                              where i.Name.ToLower().Contains(partialName.ToLower())
                              select i;

                return matches.ToList();
            }

            // Get the single item with the specified ID, or null if not found.
            public Animals GetById(int id)
            {
                var matches = from i in items
                              where i.Id == id
                              select i;

                return matches.Count() > 0 ? matches.First() : null;
            }

            #endregion

            #region Modify repository methods

            // Insert the new item into the collection.
            public Animals Insert(Animals item)
            {
                item.Id = nextId++;
                items.Add(item);
                return item;
            }

            // Update the existing item in the collection, with the info passed in the parameter object.
            public bool Update(Animals item)
            {
                Animals existingItem = GetById(item.Id);
                if (existingItem == null)
                {
                    return false;
                }
                else
                {
                    existingItem.Name = item.Name;
                    existingItem.Lost = item.Lost;
                    return true;
                }
            }

            // Delete the existing item in the collection.
            public bool Delete(int id)
            {
                Animals existingItem = GetById(id);
                if (existingItem == null)
                {
                    return false;
                }
                else
                {
                    items.Remove(existingItem);
                    return true;
                }
            }

            #endregion
        }
    }
}
