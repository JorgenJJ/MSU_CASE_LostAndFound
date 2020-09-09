﻿using System;
using System.Collections.Generic;

namespace MSU_Case_LostAndFound.Models
{
    public partial class AnimalsLost
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public Animal Animal { get; set; }
        public Gender Gender { get; set; }
        public DateTime LostDate { get; set; }
        public DateTime? Updated { get; set; }
        public string NearArea { get; set; }
        public string History { get; set; }
        public string Image { get; set; }
        public string Color { get; set; }
        public string FurLenght { get; set; }
        public string FurPattern { get; set; }
        public string Description { get; set; }
    }

    public enum Animal
    {
        Cat, 
        Dog, 
        Rabbit,
        Parrot,
        Other
    }

    public enum Gender
    {
        Male,
        Female
    }
}
