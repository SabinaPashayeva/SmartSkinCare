using System;
namespace SmartSkinCare.Entities
{
    public class Cream
    {
        public int CreamId { get; set; }
        public string Title { get; set; }
        public int RecommendedAge { get; set; }
        public string TypeOfSkin { get; set; }

        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
