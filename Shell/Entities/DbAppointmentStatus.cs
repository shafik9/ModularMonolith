using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell.Entities
{
    public class DbAppointmentStatus
    {
        public Guid Id { get; set; }
        public Guid AppointmentId { get; set; }
        public int StatusId { get; set; }
    }
}
