using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.EntityLayer.Enitities
{
    public class User
    {
        public Guid Id { get; set; }
        public string IdentityNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public Role Role { get; set; }


    }
}
