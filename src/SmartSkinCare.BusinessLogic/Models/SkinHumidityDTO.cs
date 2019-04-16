using System;
namespace SmartSkinCare.BusinessLogic.Models
{
    public class SkinHumidityDTO
    {
        public int SkinHumidityId { get; set; }
        public double SkinHumidityValue { get; set; }
        public DateTimeOffset DateTime { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
