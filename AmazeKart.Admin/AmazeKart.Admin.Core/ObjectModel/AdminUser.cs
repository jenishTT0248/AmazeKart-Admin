using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazeKart.Admin.Core.ObjectModel
{
    public class AdminUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public string PasswordHash { get; set; }
    }
}
