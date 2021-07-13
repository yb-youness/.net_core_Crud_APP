using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserMangmentSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Salaire")]
        [Range(100,1000,ErrorMessage ="Salaire Must Be Betwen 100 && 1000")]
        public int  Sal { get; set; }
        [DisplayName("Department Type")]

        [Required(ErrorMessage ="Select A Valid Department")]  
        public int IdDepartment { get; set; }
        [ForeignKey("DepartmentTypeId")]
        public virtual Department Department { get; set; }
    }
}
