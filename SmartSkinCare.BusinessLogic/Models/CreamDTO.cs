using System;
namespace SmartSkinCare.BusinessLogic.Models
{
    public class CreamDTO
    {
        public int CreamId { get; set; }
        public string Title { get; set; }
        public int RecommendedAge { get; set; }
        public string TypeOfSkin { get; set; }

        public string ManufacturerName { get; set; }
        public string UserId { get; set; }
    }
}
