using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserMangmentSystem.Models
{
    public class Department
    {
        [Key]
        public int IdDepartment { get; set; }
        [Required( ErrorMessage ="Departement Name Is Required !!!")]
        [DisplayName("Department Name")]
        public string NameDepartemnt { get; set; }

    }
}
