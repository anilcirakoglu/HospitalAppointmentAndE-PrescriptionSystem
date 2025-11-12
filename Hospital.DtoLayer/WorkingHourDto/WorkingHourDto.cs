using System;

namespace Hospital.DtoLayer.WorkingHourDto
{
    public class WorkingHourDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string DoctorName { get; set; }
        public string Specialty { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
