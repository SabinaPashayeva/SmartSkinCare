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

        public virtual IEnumerable<SkinHumidity> SkinHumidities { get; set; }
        public virtual IEnumerable<SkinOiliness> SkinOilinesses { get; set; }
        public virtual IEnumerable<Cream> Creams { get; set; }
    }
}
