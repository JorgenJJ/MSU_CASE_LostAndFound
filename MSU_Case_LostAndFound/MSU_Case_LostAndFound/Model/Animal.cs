using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MSU_Case_LostAndFound.Model
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Lost { get; set; }
        //public string Area { get; set; }
        //public string Adress { get; set; }
        //public string Race { get; set; }
        public string Sex { get; set; }
        //public string Fur { get; set; }
        //public string Color { get; set; }
    }
}
