using System;

namespace SmartSkinCare.Entities
{
    public class SkinOiliness
    {
        public int SkinOilinessId { get; set; }
        public double SkinOilinessValue { get; set; }
        public DateTimeOffset DateTime { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
