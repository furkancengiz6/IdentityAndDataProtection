using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentityAndDataProtection.Enities
{
    public class ApplicationUser:IdentityUser
    {
        //IdentityUserdan miras aldığı için otomotik Id ve Email vbalanları gelecektir.//sadece FullName ekledik.
        public string FullName { get; set; }
    }
}
