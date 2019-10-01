using Microsoft.AspNetCore.Identity;

namespace CourseWork.Areas.Identity.Data
{
    public class User : IdentityUser
    {
        [PersonalData]
        public bool IsAdmin { get; set; }
    }
}