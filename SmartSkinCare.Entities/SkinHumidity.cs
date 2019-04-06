using System;

namespace SmartSkinCare.Entities
{
    public class SkinHumidity
    {
        public int SkinHumidityId { get; set; }
        public double SkinHumidityValue { get; set; }
        public DateTimeOffset DateTime { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
