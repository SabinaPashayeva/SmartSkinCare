using System;
namespace SmartSkinCare.BusinessLogic.Models
{
    public class ApplicationUserDTO
    {
        public string UserId { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
