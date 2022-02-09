using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace umitHastanesiWeb.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DegreeId { get; set; }
        public int? LanguageId { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string Image { get; set; }
        public Department Department { get; set; }
        public Language Language { get; set; }
        public Degree Degree { get; set; }
    }

    public enum Gender
    {
        Kadin,
        Erkek
    }
}
