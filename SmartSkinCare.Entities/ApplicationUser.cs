using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SmartSkinCare.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Password { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Role { get; set; }

        public IEnumerable<SkinHumidity> SkinHumidities { get; set; }
        public IEnumerable<SkinOiliness> SkinOilinesses { get; set; }
    }
}
