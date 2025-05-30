using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DtoLayer.DoctorDto
{
    public class CreateDoctorDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Qualification { get; set; }
        public string Specialty { get; set; }
        public string Description { get; set; }
        public string RoomNumber { get; set; }
        public string IdentityNumber { get; set; }
        public string Password { get; set; }
    }
}
