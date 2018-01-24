using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookTestingApp.Tests.Models
{
   public class FacebookProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string LinkUrl { get; set; }
        public string Locale { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Location { get; set; }
        public string Bio { get; set; }
    }
}
