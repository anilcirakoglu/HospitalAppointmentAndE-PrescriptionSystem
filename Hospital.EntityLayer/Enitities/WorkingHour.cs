using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hospital.EntityLayer.Enitities
{
    public class WorkingHour
    {
        public Guid Id { get; set; } 

        public Guid UserId { get; set; }
        [JsonIgnore]
        public Doctor Doctor { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan StartTime { get; set; }  
        public TimeSpan EndTime { get; set; }
    }
    
}
