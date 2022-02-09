using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace umitHastanesiWeb.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        //public IdentityUser User { get; set; }
        public Doctor Doctor { get; set; }
    }
}
