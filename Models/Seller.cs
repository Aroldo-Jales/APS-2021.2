using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Projeto.Models;

namespace Projeto.Models
{
    public class Seller
    {
        [Key()]
        public int Id { get; set; }

        [Required]
        [ForeignKey("DepartmentForeignKey")]
        public int DepartmentForeignKey { get; set; }
        [Display(Name = "Departamento")]
        public Department Department { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(50)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        public string BirthDate { get; set; }

        [Required]
        [Display(Name = "Salário")]
        public double BaseSalary { get; set; }

        public List<SaleRecord> SalesRecord { get; set; }
    }
}