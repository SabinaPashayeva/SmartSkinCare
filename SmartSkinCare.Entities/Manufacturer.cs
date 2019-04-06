using System;
using System.Collections.Generic;

namespace SmartSkinCare.Entities
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual IEnumerable<Cream> Creams { get; set; }
    }
}
