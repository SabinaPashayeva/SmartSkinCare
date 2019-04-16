using System;
namespace SmartSkinCare.BusinessLogic.Models
{
    public class SkinOilinessDTO
    {
        public int SkinOilinessId { get; set; }
        public double SkinOilinessValue { get; set; }
        public DateTimeOffset DateTime { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
