using Microsoft.Build.Framework;

namespace beverageHelper.Areas.Admin.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
