using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.EntityLayer.Enitities
{
    public class WorkingHour
    {
        public Guid Id { get; set; } 

        public Guid DoctorId { get; set; } 
        public Doctor Doctor { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan StartTime { get; set; }  
        public TimeSpan EndTime { get; set; }
    }
    
}
